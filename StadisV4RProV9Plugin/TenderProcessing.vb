Imports StadisV4RProV9Plugin.WebReference
Imports CustomPluginClasses
Imports Plugins
Imports System
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
'----------------------------------------------------------------------------------------------
'   Class: TenderProcessing
'    Type: Tender 
' Purpose: Called when various tender events occur. 
'----------------------------------------------------------------------------------------------
<GuidAttribute(Discover.CLASS_TenderProcessing)> _
Public Class TenderProcessing
    Inherits TCustomTenderPlugin

    Private Shared Ctr As Integer = 0

    '----------------------------------------------------------------------------------------------
    ' Called during discovery
    ' Called when Sales/Receipts selected from menu
    '----------------------------------------------------------------------------------------------
    Public Overrides Sub Initialize()
        'MessageBox.Show("Initialize EFT", "DEBUG")
        MyBase.Initialize()
        fEnabled = True
        If fEnabled = False Then
            MessageBox.Show("TenderPlugin disabled", "DEBUG")
        End If
        fGUID = New Guid(Discover.CLASS_TenderProcessing)
        fBusinessObjectType = Plugins.BusinessObjectType.btInvoice
    End Sub  'Initialize

    '----------------------------------------------------------------------------------------------
    ' 
    '----------------------------------------------------------------------------------------------
    Public Overrides Function AddTender(ByVal TenderType As Integer, ByRef Data As String) As Integer
        'MsgBox("AddTender")
        'Dim tenderHandle As Integer = fAdapter.GetReferenceBOForAttribute(0, "Tenders")
        'If TenderType = gTenderDialogTenderType Then
        '    If stadisChargeList.Count > 1 Then
        '        For Each sc As StadisCharge In stadisChargeList
        '            If sc.TenderTypeID = 11 Then
        '                Try
        '                    Common.BORefreshRecord(fAdapter, 0)
        '                    Common.BOOpen(fAdapter, tenderHandle)
        '                    Common.BOInsert(fAdapter, tenderHandle)
        '                    Common.BOSetAttributeValueByName(fAdapter, tenderHandle, "TENDER_TYPE", gTenderDialogTenderType)
        '                    Common.BOSetAttributeValueByName(fAdapter, tenderHandle, "AMT", sc.Amount)
        '                    Common.BOSetAttributeValueByName(fAdapter, tenderHandle, "MANUAL_REMARK", "@PR#" & sc.TenderID & "#" & sc.StadisAuthorizationID)
        '                    If gTenderDialogTenderType = Plugins.TenderTypes.ttGiftCard Then
        '                        Common.BOSetAttributeValueByName(fAdapter, tenderHandle, "CRD_EXP_MONTH", 1)
        '                        Common.BOSetAttributeValueByName(fAdapter, tenderHandle, "CRD_EXP_YEAR", 1)
        '                        Common.BOSetAttributeValueByName(fAdapter, tenderHandle, "CRD_TYPE", 1)
        '                        Common.BOSetAttributeValueByName(fAdapter, tenderHandle, "CRD_PRESENT", 1)
        '                    End If
        '                    Common.BOPost(fAdapter, tenderHandle)
        '                Catch ex As Exception
        '                    MessageBox.Show("Error while adding STADIS tender(s)." & vbCrLf & ex.Message, "STADIS")
        '                End Try
        '            End If
        '        Next
        '    End If
        'End If
        'stadisChargeList.Clear()
        Return MyBase.AddTender(TenderType, Data)
    End Function  'AddTender

    '----------------------------------------------------------------------------------------------
    ' Catch tenders deleted through tenders screen
    '----------------------------------------------------------------------------------------------
    Public Overrides Function RemoveTender(TenderIndex As Integer) As Boolean

        ' Get pointers to receipt components
        Dim invoiceHandle As Integer = 0
        Dim tenderHandle As Integer = fAdapter.GetReferenceBOForAttribute(invoiceHandle, "Tenders")

        'Find tender being deleted
        Dim trackingIndex As Integer = 0
        Common.BOOpen(fAdapter, tenderHandle)
        Common.BOFirst(fAdapter, tenderHandle, "TP - RemoveTender")
        While Not fAdapter.EOF(tenderHandle)
            If trackingIndex = TenderIndex Then
                Dim tenderType As Integer = Common.BOGetIntAttributeValueByName(fAdapter, tenderHandle, "TENDER_TYPE")
                If tenderType = gTenderDialogTenderType Then
                    Dim auth() As String = Common.BOGetStrAttributeValueByName(Adapter, tenderHandle, "AUTH").Split("\"c)
                    If auth(0).Length = 6 Then
                        Dim sr As New StadisRequest
                        With sr
                            .SiteID = gSiteID
                            .TenderTypeID = 1
                            .TenderID = Common.BOGetStrAttributeValueByName(fAdapter, tenderHandle, "TRANSACTION_ID")
                            .Amount = Common.BOGetIntAttributeValueByName(fAdapter, tenderHandle, "AMT")
                            .ReferenceNumber = Common.BOGetStrAttributeValueByName(fAdapter, invoiceHandle, "Invoice Number")
                            .StadisAuthorizationID = auth(0)
                            .VendorID = gVendorID
                            .LocationID = gLocationID
                            .RegisterID = Common.BOGetStrAttributeValueByName(fAdapter, invoiceHandle, "Invoice Workstion")
                            .ReceiptID = Common.BOGetStrAttributeValueByName(fAdapter, invoiceHandle, "Invoice Number")
                            .VendorCashier = Common.BOGetStrAttributeValueByName(fAdapter, invoiceHandle, "Cashier")
                        End With
                        Dim sys As StadisReply() = Common.StadisAPI.SVAccountReverse(sr)
                        If sys(0).ReturnCode < 0 Then
                            MsgBox(sys(0).ReturnMessage, MsgBoxStyle.Critical, "Error while reversing Stadis charge.  TenderID = " & sr.TenderID & ", AuthID = " & auth(0) & ".")
                        End If
                    End If
                End If
            End If
            trackingIndex += 1
            fAdapter.BONext(tenderHandle)
        End While
        Return MyBase.RemoveTender(TenderIndex)
    End Function  'RemoveTender

    '----------------------------------------------------------------------------------------------
    ' Use the list we were keeping to back out charges.
    '----------------------------------------------------------------------------------------------
    Public Overrides Function CancelTransaction() As Boolean

        'Get pointers to receipt components
        Dim invoiceHandle As Integer = 0
        Dim itemHandle As Integer = fAdapter.GetReferenceBOForAttribute(invoiceHandle, "Items")
        Dim tenderHandle As Integer = fAdapter.GetReferenceBOForAttribute(invoiceHandle, "Tenders")

        Common.BOOpen(fAdapter, tenderHandle)
        Dim mRProTenderCount As Integer = Common.BOGetIntAttributeValueByName(fAdapter, tenderHandle, "TENDER_COUNT")
        If mRProTenderCount > 0 Then
            Common.BOFirst(fAdapter, tenderHandle, "PUSP - PrepItemsAndTenders 2")
            While Not fAdapter.EOF(tenderHandle)
                Dim tenderType As Integer = Common.BOGetIntAttributeValueByName(fAdapter, tenderHandle, "TENDER_TYPE")
                If tenderType = gTenderDialogTenderType Then
                    Dim remark() As String = Common.BOGetStrAttributeValueByName(fAdapter, tenderHandle, "MANUAL_REMARK").Split("#"c)
                    If remark.Length > 1 AndAlso remark(1).Length = 34 Then
                        Common.DoSVReverseTransaction(fAdapter, remark(1))
                    Else
                        If remark(0) = "@TK" OrElse remark(0) = "@GC" Then
                            Common.DoSVAccountReverse(fAdapter, remark(2))
                        End If
                    End If
                End If
                fAdapter.BONext(tenderHandle)
            End While
        End If
        Return MyBase.CancelTransaction()
    End Function  'CancelTransaction

    '----------------------------------------------------------------------------------------------
    ' Called when RPro is shut down
    '----------------------------------------------------------------------------------------------
    Public Overrides Sub Cleanup()
        fBusinessObjectType = Nothing
        fDescription = Nothing
        fGUID = Nothing
        MyBase.CleanUp()
    End Sub  'Cleanup

#Region " Not Used "

    Public Overrides Function Prepare() As Boolean
        'MsgBox("Prepare")
        Return MyBase.Prepare()
    End Function  'Prepare

    Public Overrides Function PluginCapability(ByVal cap As Integer) As Boolean
        'MsgBox(" PluginCapability")
        Return MyBase.PluginCapability(cap)
    End Function  'Prepare

    Public Overrides Function HandleEvent() As Boolean
        'MsgBox("HandleEvent")
        Return MyBase.HandleEvent()
    End Function  'HandleEvent

    Public Overrides Function StartTransaction() As Boolean
        'MsgBox("StartTransaction")
        Return MyBase.StartTransaction()
    End Function  'StartTransaction

    Public Overrides Function CommitTransaction() As Boolean
        'MsgBox("CommitTransaction")
        Return MyBase.CommitTransaction()
    End Function  'CommitTransaction

#End Region  'Not Used

End Class  'TenderProcessing
