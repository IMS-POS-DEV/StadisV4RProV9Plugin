'Imports CommonV4
'Imports CommonV4.CommonRoutines
'Imports CommonV4.WebReference
'Imports RetailPro.CustomPluginClasses
'Imports RetailPro.Plugins
'Imports System
'Imports System.Runtime.InteropServices
'Imports System.Windows.Forms
''----------------------------------------------------------------------------------------------
''   Class: TenderProcessing
''    Type: Tender 
'' Purpose: Called when various tender events occur. 
''----------------------------------------------------------------------------------------------
'<GuidAttribute(Discover.CLASS_TenderProcessing)> _
'Public Class TenderProcessing
'    Inherits TCustomTenderPlugin

'    Private Shared Ctr As Integer = 0

'    '----------------------------------------------------------------------------------------------
'    ' Called during discovery
'    ' Called when Sales/Receipts selected from menu
'    '----------------------------------------------------------------------------------------------
'    Public Overrides Sub Initialize()
'        'MessageBox.Show("Initialize EFT", "DEBUG")
'        MyBase.Initialize()
'        fEnabled = True
'        If fEnabled = False Then
'            MessageBox.Show("TenderPlugin disabled", "DEBUG")
'        End If
'        fGUID = New Guid(Discover.CLASS_TenderProcessing)
'        fBusinessObjectType = RetailPro.Plugins.BusinessObjectType.btInvoice
'    End Sub  'Initialize

'    '----------------------------------------------------------------------------------------------
'    ' 
'    '----------------------------------------------------------------------------------------------
'    Public Overrides Function AddTender(ByVal TenderType As Integer, ByRef Data As String) As Integer
'        'MsgBox("AddTender")
'        'Dim tenderHandle As Integer = fAdapter.GetReferenceBOForAttribute(0, "Tenders")
'        'If TenderType = gTenderDialogTenderType Then
'        '    If stadisChargeList.Count > 1 Then
'        '        For Each sc As StadisCharge In stadisChargeList
'        '            If sc.TenderTypeID = 11 Then
'        '                Try
'        '                    CommonRoutines.BORefreshRecord(fAdapter, 0)
'        '                    CommonRoutines.BOOpen(fAdapter, tenderHandle)
'        '                    CommonRoutines.BOInsert(fAdapter, tenderHandle)
'        '                    CommonRoutines.BOSetAttributeValueByName(fAdapter, tenderHandle, "TENDER_TYPE", gTenderDialogTenderType)
'        '                    CommonRoutines.BOSetAttributeValueByName(fAdapter, tenderHandle, "AMT", sc.Amount)
'        '                    CommonRoutines.BOSetAttributeValueByName(fAdapter, tenderHandle, "MANUAL_REMARK", "@PR#" & sc.TenderID & "#" & sc.StadisAuthorizationID)
'        '                    If gTenderDialogTenderType = RetailPro.Plugins.TenderTypes.ttGiftCard Then
'        '                        CommonRoutines.BOSetAttributeValueByName(fAdapter, tenderHandle, "CRD_EXP_MONTH", 1)
'        '                        CommonRoutines.BOSetAttributeValueByName(fAdapter, tenderHandle, "CRD_EXP_YEAR", 1)
'        '                        CommonRoutines.BOSetAttributeValueByName(fAdapter, tenderHandle, "CRD_TYPE", 1)
'        '                        CommonRoutines.BOSetAttributeValueByName(fAdapter, tenderHandle, "CRD_PRESENT", 1)
'        '                    End If
'        '                    CommonRoutines.BOPost(fAdapter, tenderHandle)
'        '                Catch ex As Exception
'        '                    MessageBox.Show("Error while adding STADIS tender(s)." & vbCrLf & ex.Message, "STADIS")
'        '                End Try
'        '            End If
'        '        Next
'        '    End If
'        'End If
'        'stadisChargeList.Clear()
'        Return MyBase.AddTender(TenderType, Data)
'    End Function  'AddTender

'    '----------------------------------------------------------------------------------------------
'    ' Catch tenders deleted through tenders screen
'    '----------------------------------------------------------------------------------------------
'    Public Overrides Function RemoveTender(TenderIndex As Integer) As Boolean

'        'MsgBox("RemoveTender")
'        '' Get pointers to receipt components
'        'Dim invoiceHandle As Integer = 0
'        'Dim tenderHandle As Integer = fAdapter.GetReferenceBOForAttribute(invoiceHandle, "Tenders")

'        ''Find tender being deleted
'        ''Dim trackingIndex As Integer = 0
'        'CommonRoutines.BOOpen(fAdapter, tenderHandle)
'        ''CommonRoutines.BOFirst(fAdapter, tenderHandle, "TP - RemoveTender")
'        ''While Not fAdapter.EOF(tenderHandle)
'        ''    If trackingIndex = TenderIndex Then
'        'Dim tenderType As Integer = CommonRoutines.BOGetIntAttributeValueByName(fAdapter, tenderHandle, "TENDER_TYPE")
'        'If tenderType = gStadisTenderType Then
'        '    Dim auth() As String = BOGetStrAttributeValueByName(Adapter, tenderHandle, "AUTH").Split("\"c)
'        '    If auth(0).Length = 6 Then
'        '        Dim sr As New StadisRequest
'        '        With sr
'        '            .SiteID = gSiteID
'        '            .TenderTypeID = gStadisTenderType
'        '            .TenderID = CommonRoutines.BOGetStrAttributeValueByName(fAdapter, tenderHandle, "TRANSACTION_ID")
'        '            .Amount = CommonRoutines.BOGetIntAttributeValueByName(fAdapter, tenderHandle, "AMT")
'        '            .ReferenceNumber = CommonRoutines.BOGetStrAttributeValueByName(fAdapter, invoiceHandle, "Invoice Number")
'        '            .StadisAuthorizationID = auth(0)
'        '            '.CustomerID =  
'        '            .VendorID = gVendorID
'        '            .LocationID = gLocationID
'        '            .RegisterID = CommonRoutines.BOGetStrAttributeValueByName(fAdapter, invoiceHandle, "Invoice Workstion")
'        '            .ReceiptID = CommonRoutines.BOGetStrAttributeValueByName(fAdapter, invoiceHandle, "Invoice Number")
'        '            .VendorCashier = CommonRoutines.BOGetStrAttributeValueByName(fAdapter, invoiceHandle, "Cashier")
'        '        End With
'        '        Dim sys As StadisReply() = CommonRoutines.StadisAPI.SVAccountReverse(sr)
'        '        If sys(0).ReturnCode < 0 Then
'        '            MsgBox(sys(0).ReturnMessage, MsgBoxStyle.Critical, "Error while reversing Stadis charge.  TenderID = " & sr.TenderID & ", AuthID = " & auth(0) & ".")
'        '        End If
'        '        Dim idx As Integer = -99
'        '        For i As Integer = 0 To stadisChargeList.Count - 1
'        '            Dim sc As StadisCharge = CType(stadisChargeList(i), StadisCharge)
'        '            If sc.TenderID = sr.TenderID Then
'        '                idx = i
'        '            End If
'        '        Next
'        '        If idx <> -99 Then
'        '            stadisChargeList.Remove(stadisChargeList(idx))
'        '        End If
'        '    End If
'        'End If
'        ''End If
'        ''trackingIndex += 1
'        ''fAdapter.BONext(tenderHandle)
'        ''End While
'        Return MyBase.RemoveTender(TenderIndex)
'    End Function  'RemoveTender

'    '----------------------------------------------------------------------------------------------
'    ' Use the list we were keeping to back out charges.
'    '----------------------------------------------------------------------------------------------
'    Public Overrides Function CancelTransaction() As Boolean

'        ' Get pointers to receipt components
'        'Dim invoiceHandle As Integer = 0
'        'Dim itemHandle As Integer = fAdapter.GetReferenceBOForAttribute(invoiceHandle, "Items")
'        'Dim tenderHandle As Integer = fAdapter.GetReferenceBOForAttribute(invoiceHandle, "Tenders")

'        ''Back out all charges
'        'Dim rproReceiptID As String = CommonRoutines.BOGetStrAttributeValueByName(fAdapter, invoiceHandle, "Invoice Number")
'        'For Each sc As StadisCharge In stadisChargeList
'        '    Dim sr As New StadisRequest
'        '    With sr
'        '        .SiteID = gSiteID
'        '        .TenderTypeID = sc.TenderTypeID
'        '        .TenderID = sc.TenderID
'        '        .Amount = sc.Amount
'        '        .ReferenceNumber = CommonRoutines.BOGetStrAttributeValueByName(fAdapter, invoiceHandle, "Invoice Number")
'        '        '.CustomerID =  
'        '        .VendorID = gVendorID
'        '        .LocationID = gLocationID
'        '        .RegisterID = CommonRoutines.BOGetStrAttributeValueByName(fAdapter, invoiceHandle, "Invoice Workstion")
'        '        .ReceiptID = CommonRoutines.BOGetStrAttributeValueByName(fAdapter, invoiceHandle, "Invoice Number")
'        '        .VendorCashier = CommonRoutines.BOGetStrAttributeValueByName(fAdapter, invoiceHandle, "Cashier")
'        '    End With
'        '    Dim sys As StadisReply() = CommonRoutines.StadisAPI.SVAccountReverse(sr)
'        '    If sys(0).ReturnCode < 0 Then
'        '        MsgBox(sys(0).ReturnMessage, MsgBoxStyle.Critical, "Error while reversing Stadis charge.TenderID = " & sc.TenderID & ", AuthID = " & sc.StadisAuthorizationID & ".")
'        '    End If
'        'Next
'        'stadisChargeList.Clear()
'        Return MyBase.CancelTransaction()
'    End Function  'CancelTransaction

'    '----------------------------------------------------------------------------------------------
'    ' Called when RPro is shut down
'    '----------------------------------------------------------------------------------------------
'    Public Overrides Sub Cleanup()
'        fBusinessObjectType = Nothing
'        fDescription = Nothing
'        fGUID = Nothing
'        MyBase.CleanUp()
'    End Sub  'Cleanup

'#Region " Not Used "

'    Public Overrides Function Prepare() As Boolean
'        'MsgBox("Prepare")
'        Return MyBase.Prepare()
'    End Function  'Prepare

'    Public Overrides Function PluginCapability(ByVal cap As Integer) As Boolean
'        'MsgBox(" PluginCapability")
'        Return MyBase.PluginCapability(cap)
'    End Function  'Prepare

'    Public Overrides Function HandleEvent() As Boolean
'        'MsgBox("HandleEvent")
'        Return MyBase.HandleEvent()
'    End Function  'HandleEvent

'    Public Overrides Function StartTransaction() As Boolean
'        'MsgBox("StartTransaction")
'        Return MyBase.StartTransaction()
'    End Function  'StartTransaction

'    Public Overrides Function CommitTransaction() As Boolean
'        'MsgBox("CommitTransaction")
'        Return MyBase.CommitTransaction()
'    End Function  'CommitTransaction

'#End Region  'Not Used

'End Class  'TenderProcessing
