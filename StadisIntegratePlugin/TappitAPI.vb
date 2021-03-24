Imports StadisIntegratePlugin.WebReference
Imports System.Diagnostics
Imports System.ComponentModel
Imports System.Configuration.ConfigurationManager
Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Runtime
Imports System.Security.Cryptography
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Threading.Tasks
Imports Newtonsoft.Json
'Imports StadisV4

Public Class TappitAPI
#Region " Data Declarations "

    Shared handler As HttpClientHandler = New HttpClientHandler()

    Shared tappitClient As HttpClient = New HttpClient(handler)

    'Public Shared tappitBaseAddress As String = "https://retailpro-aramark-chiefs.tappitprod.com/"

    Private Loc As String = ""



#End Region  'Data Declarations



#Region " Initialization "



    Private Sub New()

        'isTicketmaster = CBool(ConfigurationManager.AppSettings("IsTM"))

        SetUpHttpClient()

    End Sub



    Public Shared Sub SetUpHttpClient()


        Try
            If gTappitHTTPClientIsSetup = False Then
                Dim blnTestMode As Boolean = False
                'blnTestMode = True
                If blnTestMode = True Then MsgBox("TappitAPI.SetUpHttpClient blnTestMode = true")

                handler.UseDefaultCredentials = True

                If blnTestMode = True Then MsgBox("TappitAPI.SetUpHttpClient gTappitBaseAddress " & gTappitBaseAddress)
                tappitClient.BaseAddress = New Uri(gTappitBaseAddress)

                tappitClient.DefaultRequestHeaders.Clear()
                tappitClient.DefaultRequestHeaders.Add("User-Agent", "RPro plugin")

                'tappitClient.DefaultRequestHeaders.Add("x-api-key", "befb05f6-8a6a-41f1-8368-73c8abfda442")

                If blnTestMode = True Then MsgBox("TappitAPI.SetUpHttpClient gTappitAPIKey " & gTappitAPIKey)

                tappitClient.DefaultRequestHeaders.Add("x-api-key", gTappitAPIKey)
                tappitClient.DefaultRequestHeaders.Accept.Clear()

                If blnTestMode = True Then MsgBox("TappitAPI.SetUpHttpClient calling add json")
                tappitClient.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))
                If blnTestMode = True Then MsgBox("TappitAPI.SetUpHttpClient finished")

                gTappitHTTPClientIsSetup = True
            End If
        Catch ex As Exception
            MsgBox("Exception setting up HTTP client")
            gTappitHTTPClientIsSetup = False
        End Try



    End Sub  'SetUpHttpClient()



#End Region  'Initialization



#Region " Tappit "

    Public Shared Function Tappit_POS_Spend(ByVal Request As StadisRequest, ByVal Items As StadisTranItem()) As StadisReply()
        Dim sendSpend As TappitSpendPost = New TappitSpendPost()
        sendSpend.client_tran_id = Request.ReferenceNumber
        sendSpend.qr_code = Request.TenderID
        sendSpend.terminal_id = Request.RegisterID
        sendSpend.terminal_location = Request.LocationID

        sendSpend.total_sales_amount = Request.Amount
        sendSpend.sub_total = gTappitSubtotal
        'MsgBox("setting donation amount into tappit request")
        sendSpend.donation_amount = gTappitDonationAmount
        'MsgBox("donation amount set")
        sendSpend.discount_amount = CDec(0)
        sendSpend.tax_amount = gTappitTaxTotal
        For Each itm As StadisTranItem In Items
            Dim item As TappitItem = New TappitItem()
            With item
                .SKU = itm.ItemID
                .name = itm.Description
                .quantity = itm.Quantity
                .unit_price = itm.Price
                'MsgBox("tappitapi.tappit_pos_spend PRICE " & CStr(itm.Price))
                .tax_amount = itm.Tax
                .tax_percent = itm.AdditionalTax
                .tax_included = False
                .discount = CDec(0)
                .amount = (itm.Quantity * itm.Price) + (item.quantity * itm.Tax) + (itm.Quantity * CDec(0))
                .type = itm.Field1
            End With
            sendSpend.items.Add(item)
        Next
        Dim recvSpend As TappitSpendReply = New TappitSpendReply()
        TappitSpendPost("/pos_spend", sendSpend, recvSpend)
        Dim sys(0) As StadisReply
        Dim sy As StadisReply = New StadisReply
        With sy
            .TenderTypeID = Request.TenderTypeID
            .TenderID = Request.TenderID
            .RequestedAmount = Request.Amount
            '.ChargedAmount = Request.Amount
            .ChargedAmount = recvSpend.charged_amount
            .ReferenceNumber = Request.ReferenceNumber
            .CustomerID = Request.CustomerID
            .Comment = recvSpend.tappit_tran_id
            .ReturnCode = recvSpend.rc
            .ReturnMessage = recvSpend.message
        End With
        sys(0) = sy
        Return sys
    End Function  'Tappit_POS_Spend

    Private Shared Sub TappitSpendPost(ByVal url As String, ByVal input As TappitSpendPost, ByRef recvSpend As TappitSpendReply)
        Dim i As Integer
        Dim blnTestComplimentary As Boolean = False
        Dim blnTestToken As Boolean = False

        Try
            Dim json As String = JsonConvert.SerializeObject(input)
            If gDebugMode = True Then MsgBox("Tappit spend request " & Common.FormattedJson(json))
            Dim data = New StringContent(json, Encoding.UTF8, "application/json")
            Dim response As HttpResponseMessage = tappitClient.PostAsync(url, data).Result
            gTappitComplimentaryUsageArrayRowCount = 0
            gTappitTokenUsageArrayRowCount = 0
            gTappitSkiDataUsageArrayRowCount = 0
            gTappitApprovedTenderAmount = 0
            gTappitComplimentaryUsageTotal = 0
            gTappitTokenUsageTotal = 0

            json = response.Content.ReadAsStringAsync().Result
            If gDebugMode = True Then MsgBox("Tappit spend response " & Common.FormattedJson(json))
            'On 405 error (something on Tappit's side), observed that json was = "" here
            'In that case, JsonConvert.DeserializeObject replaced recvSpend with an empty object
            'That caused an unmeaningful exception attempting to reference a non existent object

            'Fred was unable to test the following solution because the 405 error stopped
            'The idea is only to use the DeserializeObject method if json <> ""
            'and to simply set the values if json = ""
            'Maybe this could have been trapped, but it was not an HttpRequestException 

            If json <> "" Then
                recvSpend = JsonConvert.DeserializeObject(Of TappitSpendReply)(json)
                gTappitApprovedTenderAmount = CDec(recvSpend.charged_amount)
                gTappitComplimentaryUsageTotal = CDec(recvSpend.complimentary_amount)
                gTappitTokenUsageTotal = CDec(recvSpend.token_amount)

                gTappitSkiDataUsageArrayRowCount = recvSpend.items.Count
                ReDim gTappitSkiDataUsageArray(gTappitSkiDataUsageArrayColCount, gTappitSkiDataUsageArrayRowCount - 1)
                For i = 0 To gTappitSkiDataUsageArrayRowCount - 1
                    'origin 0, 11 columns amount, discount, name, quantity, sku, tax_amount, tax_included, tax_percent, type, unit_price, applied
                    gTappitSkiDataUsageArray(0, i) = CStr(recvSpend.items(i).amount) 'decimal
                    gTappitSkiDataUsageArray(1, i) = CStr(recvSpend.items(i).discount) 'decimal
                    gTappitSkiDataUsageArray(2, i) = CStr(recvSpend.items(i).name) 'string
                    gTappitSkiDataUsageArray(3, i) = CStr(recvSpend.items(i).quantity) 'deicimal
                    gTappitSkiDataUsageArray(4, i) = CStr(recvSpend.items(i).sku) 'string
                    gTappitSkiDataUsageArray(5, i) = CStr(recvSpend.items(i).tax_amount) 'decimal
                    gTappitSkiDataUsageArray(6, i) = CStr(recvSpend.items(i).tax_included) '?
                    gTappitSkiDataUsageArray(7, i) = CStr(recvSpend.items(i).tax_percent) 'decimal
                    gTappitSkiDataUsageArray(8, i) = CStr(recvSpend.items(i).type) 'string
                    gTappitSkiDataUsageArray(9, i) = CStr(recvSpend.items(i).unit_price) 'decimal
                    gTappitSkiDataUsageArray(10, i) = "N" 'applied
                    If CDec(recvSpend.items(i).quantity) = 0 Then gTappitSkiDataUsageArray(10, i) = "Y"
                Next i


                blnTestComplimentary = False
                If blnTestComplimentary = True Then
                    MsgBox("test complimentary")
                    gTappitComplimentaryUsageArrayRowCount = 1
                    ReDim gTappitComplimentaryUsageArray(gTappitComplimentaryUsageArrayColCount, gTappitComplimentaryUsageArrayRowCount - 1)
                    i = 0
                    gTappitComplimentaryUsageArray(0, i) = "test complimentary item" ' description
                    gTappitComplimentaryUsageArray(1, i) = "10" ' used_amount
                    gTappitComplimentaryUsageTotal = CDec(gTappitComplimentaryUsageArray(1, i))
                    gTappitApprovedTenderAmount = gTappitApprovedTenderAmount - gTappitComplimentaryUsageTotal
                    gTappitComplimentaryUsageArray(2, i) = "0" 'remaining amount
                    gTappitComplimentaryUsageArray(3, i) = "1234" 'expire date
                Else
                    gTappitComplimentaryUsageArrayRowCount = 0
                    If gTappitComplimentaryUsageTotal > 0 Then
                        gTappitComplimentaryUsageArrayRowCount = recvSpend.complimentary_usage.Count
                        If gTappitComplimentaryUsageArrayRowCount > 0 Then
                            ReDim gTappitComplimentaryUsageArray(gTappitComplimentaryUsageArrayColCount, gTappitComplimentaryUsageArrayRowCount - 1)
                            For i = 0 To gTappitComplimentaryUsageArrayRowCount - 1
                                'origin 0 four columns description, used_amount, remaining_amount, expire_date
                                gTappitComplimentaryUsageArray(0, i) = recvSpend.complimentary_usage(i).description 'string
                                gTappitComplimentaryUsageArray(1, i) = CStr(recvSpend.complimentary_usage(i).used_amount) 'decimal
                                gTappitComplimentaryUsageArray(2, i) = CStr(recvSpend.complimentary_usage(i).remaining_amount) 'decimal
                                gTappitComplimentaryUsageArray(3, i) = CStr(recvSpend.complimentary_usage(i).expire_date) 'string
                            Next i
                        End If
                    End If
                End If
                'blnTestToken = True
                If blnTestToken = True Then
                    MsgBox("TappitAPI.TappitSpendPost test token TRUE")
                    gTappitTokenUsageArrayRowCount = 1
                    ReDim gTappitTokenUsageArray(gTappitTokenUsageArrayColCount, gTappitTokenUsageArrayRowCount - 1)
                    i = 0
                    gTappitTokenUsageArray(0, i) = "Token description" 'description 'string
                    gTappitTokenUsageArray(1, i) = "10" ' used_amount 'decimal
                    gTappitTokenUsageTotal = CDec(gTappitTokenUsageArray(1, i))
                    gTappitApprovedTenderAmount = gTappitApprovedTenderAmount - gTappitTokenUsageTotal
                    gTappitTokenUsageArray(2, i) = "100002" ' sku 'string
                    gTappitTokenUsageArray(3, i) = "Token Item Description" ' product_name 'string
                    gTappitTokenUsageArray(4, i) = "mm/dd/yy" ' epire_date 'string

                Else
                    gTappitTokenUsageArrayRowCount = 0
                    If gTappitTokenUsageTotal > 0 Then
                        gTappitTokenUsageArrayRowCount = recvSpend.token_usage.Count
                        If gTappitTokenUsageArrayRowCount > 0 Then
                            ReDim gTappitTokenUsageArray(gTappitTokenUsageArrayColCount, gTappitTokenUsageArrayRowCount - 1)
                            For i = 0 To gTappitTokenUsageArrayRowCount - 1
                                'origin 0 five columns description, used_amount, sku, product_name, expire_date
                                gTappitTokenUsageArray(0, i) = recvSpend.token_usage(i).description 'string
                                gTappitTokenUsageArray(1, i) = CStr(recvSpend.token_usage(i).used_amount) 'decimal
                                gTappitTokenUsageArray(2, i) = recvSpend.token_usage(i).sku 'string
                                gTappitTokenUsageArray(3, i) = recvSpend.token_usage(i).product_name 'string
                                gTappitTokenUsageArray(4, i) = recvSpend.token_usage(i).expire_date 'string
                            Next i
                        End If
                    End If
                End If
                recvSpend.rc = response.StatusCode
            End If

            If json = "" Then
                recvSpend.rc = response.StatusCode
                recvSpend.message = response.ReasonPhrase
            End If

        Catch e As HttpRequestException
            recvSpend.rc = 400
            recvSpend.message = e.Message
        End Try
    End Sub  'TappitSpendPostAsync

    'Public Shared Function Tappit_POS_Refund(ByVal Request As StadisRequest, ByVal Items As StadisTranItem()) As StadisReply()
    Public Shared Function Tappit_POS_Refund(ByVal Request As StadisRequest) As StadisReply()
        Dim strDateTime As String = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.ffZ")
        Dim sendRefund As TappitRefundPost = New TappitRefundPost()
        sendRefund.client_tran_id = Request.ReferenceNumber
        sendRefund.spend_tran_id = Request.ReceiptID
        sendRefund.local_time = strDateTime

        sendRefund.qr_code = Request.TenderID
        sendRefund.terminal_id = Request.RegisterID
        sendRefund.terminal_location = Request.LocationID
        'sendRefund.total_refund_amount = Request.Amount * (-1)
        'For Each itm As StadisTranItem In Items
        ' Dim item As TappitItem = New TappitItem()
        ' With item
        ' .SKU = itm.ItemID
        ' .name = itm.Description
        ' .quantity = itm.Quantity * (-1)
        ' .unit_price = itm.Price
        ' .amount = itm.Quantity * itm.Price * (-1)
        ' .type = itm.Field1
        ' End With
        ' sendRefund.items.Add(item)
        'Next
        Dim recvRefund As TappitRefundReply = New TappitRefundReply()
        TappitRefundPost("/pos_refund", sendRefund, recvRefund)
        Dim sys(0) As StadisReply
        Dim sy As StadisReply = New StadisReply
        With sy
            .TenderTypeID = Request.TenderTypeID
            .TenderID = Request.TenderID
            .RequestedAmount = Request.Amount
            .ChargedAmount = Request.Amount
            .ReferenceNumber = Request.ReferenceNumber
            .CustomerID = Request.CustomerID
            .Comment = recvRefund.tappit_tran_id
            .ReturnCode = recvRefund.rc
            .ReturnMessage = recvRefund.message

        End With
        sys(0) = sy
        Return sys
    End Function  'Tappit_POS_Refund

    Private Shared Sub TappitRefundPost(ByVal url As String, ByVal input As TappitRefundPost, ByRef recvRefund As TappitRefundReply)
        Try
            Dim json As String = JsonConvert.SerializeObject(input)
            If gDebugMode = True Then MsgBox("Tappit refund request " & Common.FormattedJson(json))

            Dim data = New StringContent(json, Encoding.UTF8, "application/json")
            Dim response As HttpResponseMessage = tappitClient.PostAsync(url, data).Result
            json = response.Content.ReadAsStringAsync().Result
            If gDebugMode = True Then MsgBox("Tappit refund response " & Common.FormattedJson(json))

            'see note in TappitSpendPost regarding handling json = ""

            If json <> "" Then
                recvRefund = JsonConvert.DeserializeObject(Of TappitRefundReply)(json)
                recvRefund.rc = response.StatusCode
            End If
            If json = "" Then
                recvRefund.rc = response.StatusCode
                recvRefund.message = response.ReasonPhrase

            End If
        Catch e As HttpRequestException
            recvRefund.rc = 400
            recvRefund.message = e.Message
        End Try
    End Sub  'TappitRefundPostAsync

    Public Function Tappit_Check_Balance(ByVal Request As StadisRequest) As StadisReply
        Dim sendBalChk As TappitBalChkPost = New TappitBalChkPost()
        sendBalChk.qr_code = Request.TenderID
        Dim recvBalChk As TappitBalChkReply = New TappitBalChkReply()
        TappitBalChkPost("/check_balance", sendBalChk, recvBalChk)
        Dim sy As StadisReply = New StadisReply
        With sy
            .FromSVAccountBalance = recvBalChk.balance
            .ReturnCode = recvBalChk.rc
            .ReturnMessage = recvBalChk.message
        End With
        Return sy
    End Function  'Tappit_Check_Balance

    Private Sub TappitBalChkPost(ByVal url As String, ByVal input As TappitBalChkPost, ByRef recvBalChk As TappitBalChkReply)
        Try
            Dim json As String = JsonConvert.SerializeObject(input)
            Dim data = New StringContent(json, Encoding.UTF8, "application/json")
            Dim response As HttpResponseMessage = tappitClient.PostAsync(url, data).Result
            json = response.Content.ReadAsStringAsync().Result
            recvBalChk = JsonConvert.DeserializeObject(Of TappitBalChkReply)(json)
            recvBalChk.rc = response.StatusCode
            If response.IsSuccessStatusCode Then
                recvBalChk.message = "Success"
            Else
                recvBalChk.message = "Fail"
            End If
        Catch e As HttpRequestException
            recvBalChk.rc = 400
            recvBalChk.message = e.Message
        End Try
    End Sub  'TappitBalChkPostAsync

#End Region  'Tappit

End Class  'API
'End Class
