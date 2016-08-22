Imports CommonV4
Imports CommonV4.CommonRoutines
Imports CommonV4.WebReference
Imports RetailPro.CustomPluginClasses
Imports RetailPro.Plugins
Imports System
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
'----------------------------------------------------------------------------------------------
'   Class: TenderProcessing
'    Type: Tender / CancelTransaction
' Purpose: Called when various tender events occur.  The only one we handle here is CancelTransaction.
'----------------------------------------------------------------------------------------------
<GuidAttribute(Discover.CLASS_TenderProcessing)> _
Public Class TenderProcessing
    Inherits TCustomTenderPlugin

    Private Shared Ctr As Integer = 0

    '----------------------------------------------------------------------------------------------
    ' Called when plugin is loaded
    '----------------------------------------------------------------------------------------------
    Public Overrides Sub Initialize()
        'MessageBox.Show("Initialize EFT", "DEBUG")
        MyBase.Initialize()
        fEnabled = True
        If fEnabled = False Then
            MessageBox.Show("TenderPlugin disabled", "DEBUG")
        End If
        fGUID = New Guid(Discover.CLASS_TenderProcessing)
        fBusinessObjectType = RetailPro.Plugins.BusinessObjectType.btTender

    End Sub  'Initialize

    '----------------------------------------------------------------------------------------------
    ' 
    '----------------------------------------------------------------------------------------------
    Public Overrides Function PluginCapability(ACapability As Integer) As Boolean
        MessageBox.Show("PluginCapability", "DEBUG")
        If ACapability = 0 Then
            Return True
        Else
            Return False
        End If
    End Function  'PluginCapability

    '----------------------------------------------------------------------------------------------
    ' Use the list we were keeping to back out charges.
    '----------------------------------------------------------------------------------------------
    Public Overrides Function CancelTransaction() As Boolean

        ' Get pointers to receipt components
        Dim invoiceHandle As Integer = 0
        Dim itemHandle As Integer = fAdapter.GetReferenceBOForAttribute(invoiceHandle, "Items")
        Dim tenderHandle As Integer = fAdapter.GetReferenceBOForAttribute(invoiceHandle, "Tenders")

        'Back out all charges
        Dim rproReceiptID As String = CommonRoutines.BOGetStrAttributeValueByName(fAdapter, invoiceHandle, "Invoice Number")
        For Each sc As StadisCharge In stadisChargeList
            Dim sr As New StadisRequest
            With sr
                .SiteID = gSiteID
                .TenderTypeID = sc.TenderTypeID
                .TenderID = sc.TenderID
                .Amount = sc.Amount
                .ReferenceNumber = CommonRoutines.BOGetStrAttributeValueByName(fAdapter, invoiceHandle, "Invoice Number")
                '.CustomerID =  
                .VendorID = gVendorID
                .LocationID = gLocationID
                .RegisterID = CommonRoutines.BOGetStrAttributeValueByName(fAdapter, invoiceHandle, "Invoice Workstion")
                .ReceiptID = CommonRoutines.BOGetStrAttributeValueByName(fAdapter, invoiceHandle, "Invoice Number")
                .VendorCashier = CommonRoutines.BOGetStrAttributeValueByName(fAdapter, invoiceHandle, "Cashier")
            End With
            Dim sys As StadisReply() = CommonRoutines.StadisAPI.SVAccountReverse(sr)
            If sys(0).ReturnCode < 0 Then
                MsgBox(sys(0).ReturnMessage, MsgBoxStyle.Critical, "Error while reversing Stadis charge.TenderID = " & sc.TenderID & ", AuthID = " & sc.StadisAuthorizationID & ".")
            End If
        Next
        stadisChargeList.Clear()
        Return MyBase.CancelTransaction()
    End Function  'CancelTransaction

#Region " Not Used "

    Public Overrides Function Prepare() As Boolean
        Return MyBase.Prepare()
    End Function  'Prepare

    Public Overrides Function HandleEvent() As Boolean
        Return MyBase.HandleEvent()
    End Function  'HandleEvent

    Public Overrides Function AddTender(TenderType As Integer, ByRef Data As String) As Integer
        Return MyBase.AddTender(TenderType, Data)
    End Function  'AddTender

    Public Overrides Function StartTransaction() As Boolean
        Return MyBase.StartTransaction()
    End Function  'StartTransaction

    Public Overrides Function CommitTransaction() As Boolean
        Return MyBase.CommitTransaction()
    End Function  'CommitTransaction

    '----------------------------------------------------------------------------------------------
    ' 
    '----------------------------------------------------------------------------------------------
    Public Overrides Function RemoveTender(TenderIndex As Integer) As Boolean

        ' Get pointers to receipt components
        Dim invoiceHandle As Integer = 0
        Dim tenderHandle As Integer = fAdapter.GetReferenceBOForAttribute(invoiceHandle, "Tenders")

        'Find tender being deleted
        'Dim trackingIndex As Integer = 0
        'CommonRoutines.BOOpen(fAdapter, tenderHandle)
        'CommonRoutines.BOFirst(fAdapter, tenderHandle, "TP - RemoveTender")
        'While Not fAdapter.EOF(tenderHandle)
        '    If trackingIndex = TenderIndex Then
        Dim tenderType As Integer = CommonRoutines.BOGetIntAttributeValueByName(fAdapter, tenderHandle, "TENDER_TYPE")
        If tenderType = gStadisTenderType Then
            Dim auth() As String = BOGetStrAttributeValueByName(Adapter, tenderHandle, "AUTH").Split("\"c)
            If auth(0).Length = 6 Then
                Dim sr As New StadisRequest
                With sr
                    .SiteID = gSiteID
                    .TenderTypeID = gStadisTenderType
                    .TenderID = CommonRoutines.BOGetStrAttributeValueByName(fAdapter, tenderHandle, "TRANSACTION_ID")
                    .Amount = CommonRoutines.BOGetIntAttributeValueByName(fAdapter, tenderHandle, "AMT")
                    .ReferenceNumber = CommonRoutines.BOGetStrAttributeValueByName(fAdapter, invoiceHandle, "Invoice Number")
                    .StadisAuthorizationID = auth(0)
                    '.CustomerID =  
                    .VendorID = gVendorID
                    .LocationID = gLocationID
                    .RegisterID = CommonRoutines.BOGetStrAttributeValueByName(fAdapter, invoiceHandle, "Invoice Workstion")
                    .ReceiptID = CommonRoutines.BOGetStrAttributeValueByName(fAdapter, invoiceHandle, "Invoice Number")
                    .VendorCashier = CommonRoutines.BOGetStrAttributeValueByName(fAdapter, invoiceHandle, "Cashier")
                End With
                Dim sys As StadisReply() = CommonRoutines.StadisAPI.SVAccountReverse(sr)
                If sys(0).ReturnCode < 0 Then
                    MsgBox(sys(0).ReturnMessage, MsgBoxStyle.Critical, "Error while reversing Stadis charge.  TenderID = " & sr.TenderID & ", AuthID = " & auth(0) & ".")
                End If
                Dim idx As Integer = -99
                For i As Integer = 0 To stadisChargeList.Count - 1
                    Dim sc As StadisCharge = CType(stadisChargeList(i), StadisCharge)
                    If sc.TenderID = sr.TenderID Then
                        idx = i
                    End If
                Next
                If idx <> -99 Then
                    stadisChargeList.Remove(stadisChargeList(idx))
                End If
            End If
        End If
        'End If
        'trackingIndex += 1
        'fAdapter.BONext(tenderHandle)
        'End While
        Return MyBase.RemoveTender(TenderIndex)
    End Function  'RemoveTender

#End Region  'Not Used

End Class  'TenderProcessing
