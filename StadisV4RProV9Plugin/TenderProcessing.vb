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

    'Public Function HandleBOUIEvent(ByVal ABOHandle As Integer, ByVal AEventType As String, ByVal AParameters As String, ByRef AReturnValues As String, ByRef AHandled As Boolean) As Boolean
    '    MessageBox.Show("HandleBOUIEvent", "DEBUG")
    'End Function  'HandleBOUIEvent

    'Public Overrides Function Prepare() As Boolean
    '    MessageBox.Show("Prepare", "DEBUG")
    '    Return MyBase.Prepare()
    'End Function  'Prepare

    ''----------------------------------------------------------------------------------------------
    '' 
    ''----------------------------------------------------------------------------------------------
    'Public Overrides Function HandleEvent() As Boolean
    '    MessageBox.Show("HandleEvent", "DEBUG")
    '    Return MyBase.HandleEvent()
    'End Function  'HandleEvent

    ''----------------------------------------------------------------------------------------------
    '' 
    ''----------------------------------------------------------------------------------------------
    'Public Overrides Function AddTender(TenderType As Integer, ByRef Data As String) As Integer
    '    MessageBox.Show("AddTender " & TenderType.ToString & " " & Data, "DEBUG")
    '    Dim ret As Integer = MyBase.AddTender(TenderType, Data)
    '    'Ctr += 1
    '    'Dim ret As Integer = Ctr
    '    MessageBox.Show("AddTender ret " & ret.ToString, "DEBUG")
    '    Return ret
    'End Function  'AddTender

    ''----------------------------------------------------------------------------------------------
    '' 
    ''----------------------------------------------------------------------------------------------
    'Public Overrides Function Settle(TenderType As Integer, All As Boolean) As Boolean
    '    MessageBox.Show("Settle", "DEBUG")
    '    Return MyBase.Settle(TenderType, All)
    'End Function  'Settle

    ''----------------------------------------------------------------------------------------------
    '' 
    ''----------------------------------------------------------------------------------------------
    'Public Overrides Function IsTenderActiveInBatch(TenderID As String) As Boolean
    '    MessageBox.Show("IsTenderActiveInBatch", "DEBUG")
    '    Return MyBase.IsTenderActiveInBatch(TenderID)
    'End Function  'IsTenderActiveInBatch

    ''----------------------------------------------------------------------------------------------
    '' 
    ''----------------------------------------------------------------------------------------------
    'Public Overrides Function CommitTransaction() As Boolean
    '    MessageBox.Show("CommitTransaction", "DEBUG")
    '    Return MyBase.CommitTransaction()
    'End Function  'CommitTransaction

    ''----------------------------------------------------------------------------------------------
    '' 
    ''----------------------------------------------------------------------------------------------
    'Public Overrides Function RemoveTender(TenderIndex As Integer) As Boolean

    '    ' Get pointers to receipt components
    '    Dim invoiceHandle As Integer = 0
    '    Dim itemHandle As Integer = fAdapter.GetReferenceBOForAttribute(invoiceHandle, "Items")
    '    Dim tenderHandle As Integer = fAdapter.GetReferenceBOForAttribute(invoiceHandle, "Tenders")

    '    'Back out any deletes we didn't catch.  Build a Stadis tender list from RPro, then check our earlier list against it.
    '    Dim rproChargeList As New ArrayList
    '    CommonRoutines.BOOpen(fAdapter, tenderHandle)
    '    CommonRoutines.BOFirst(fAdapter, tenderHandle)
    '    While Not fAdapter.EOF(tenderHandle)
    '        Dim tenderType As Integer = CommonRoutines.BOGetIntAttributeValueByName(fAdapter, tenderHandle, "TENDER_TYPE")
    '        If tenderType = gStadisTenderType Then
    '            Dim rc As New StadisCharge()
    '            rc.TenderTypeID = tenderType
    '            rc.TenderID = BOGetStrAttributeValueByName(Adapter, tenderHandle, "TRANSACTION_ID")
    '            rc.Amount = CommonRoutines.BOGetDecAttributeValueByName(fAdapter, tenderHandle, "AMT")
    '            Dim auth() As String = BOGetStrAttributeValueByName(Adapter, tenderHandle, "AUTH").Split("\"c)
    '            If auth(0).Length = 6 Then
    '                rc.StadisAuthorizationID = auth(0)
    '            End If
    '            rproChargeList.Add(rc)
    '        End If
    '        fAdapter.BONext(tenderHandle)
    '    End While
    '    Dim rproReceiptID As String = CommonRoutines.BOGetStrAttributeValueByName(fAdapter, invoiceHandle, "Invoice Number")
    '    For Each sc As StadisCharge In stadisChargeList
    '        If sc.ReceiptID = rproReceiptID Then
    '            For Each rc As StadisCharge In rproChargeList
    '                If sc.TenderID = rc.TenderID Then
    '                    If sc.Amount <> rc.Amount Then
    '                        Throw New Exception("Stadis charge altered outside of Stadis.")
    '                    End If
    '                    Continue For
    '                End If
    '            Next
    '            'No match, back it out
    '            Dim sr As New StadisRequest
    '            With sr
    '                .SiteID = gSiteID
    '                .TenderTypeID = sc.TenderTypeID
    '                .TenderID = sc.TenderID
    '                .Amount = sc.Amount
    '                .ReferenceNumber = CommonRoutines.BOGetStrAttributeValueByName(fAdapter, invoiceHandle, "Invoice Number")
    '                '.CustomerID =  
    '                .VendorID = gVendorID
    '                .LocationID = gLocationID
    '                .RegisterID = CommonRoutines.BOGetStrAttributeValueByName(fAdapter, invoiceHandle, "Invoice Workstion")
    '                .ReceiptID = CommonRoutines.BOGetStrAttributeValueByName(fAdapter, invoiceHandle, "Invoice Number")
    '                .VendorCashier = CommonRoutines.BOGetStrAttributeValueByName(fAdapter, invoiceHandle, "Cashier")
    '            End With
    '            Dim sys As StadisReply() = CommonRoutines.StadisAPI.SVAccountReverse(sr)
    '            If sys(0).ReturnCode < 0 Then
    '                MsgBox(sys(0).ReturnMessage, MsgBoxStyle.Critical, "Error while reversing Stadis charge.TenderID = " & sc.TenderID & ", AuthID = " & sc.StadisAuthorizationID & ".")
    '            End If
    '        End If
    '    Next
    '    Return MyBase.RemoveTender(TenderIndex)
    'End Function  'RemoveTender

    ''----------------------------------------------------------------------------------------------
    '' 
    ''----------------------------------------------------------------------------------------------
    'Public Overrides Function StartTransaction() As Boolean
    '    MessageBox.Show("StartTransaction", "DEBUG")
    '    Return MyBase.StartTransaction()
    'End Function  'StartTransaction

#End Region  'Not Used

End Class  'TenderProcessing
