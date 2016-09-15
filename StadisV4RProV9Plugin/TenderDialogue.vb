Imports CommonV4
Imports CommonV4.CommonRoutines
Imports CommonV4.WebReference
Imports RetailPro.CustomPluginClasses
Imports RetailPro.Plugins
Imports System
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
'----------------------------------------------------------------------------------------------
'   Class: TenderDialogue
'    Type: Tender 
' Purpose: Called when tender button is pressed on tender screen. 
'----------------------------------------------------------------------------------------------
<GuidAttribute(Discover.CLASS_TenderDialogue)> _
Public Class TenderDialogue
    Inherits TCustomTenderDialoguePlugin

    '----------------------------------------------------------------------------------------------
    ' Called during discovery
    ' Called when Sales/Receipts selected from menu (1)
    '----------------------------------------------------------------------------------------------
    Public Overrides Sub Initialize()
        MyBase.Initialize()
        LoadLocalSettings()
        CommonRoutines.LoadInstallationSettings()
        fBusinessObjectType = RetailPro.Plugins.BusinessObjectType.btInvoice
        fDescription = "Stadis tender dialog"
        fGUID = New Guid(Discover.CLASS_TenderDialogue)
        fTenderType = RetailPro.Plugins.TenderTypes.ttTravelerCheck
        fUseDefaultDialog = False
    End Sub  'Initialize

    Private Sub LoadLocalSettings()
        gStadisV4WebServiceURL = My.Settings.StadisV4WebServiceURL
        gOverrideSettingComponent = My.Settings.OverrideSettingID
        gStadisUserID = My.Settings.StadisUserID
        gStadisPassword = My.Settings.StadisPassword
        gLog = My.Settings.Log
        gNetworkChecking = My.Settings.NetworkChecking
        'gOPOSPrinterName = My.Settings.OPOSPrinterName
        'gRasterPrinterName = My.Settings.RasterPrinterName
        gWindowsPrinterName = My.Settings.WindowsPrinterName
    End Sub  'LoadLocalSettings

    '----------------------------------------------------------------------------------------------
    ' Called when Sales/Receipts selected from menu (2)
    '----------------------------------------------------------------------------------------------
    Public Overrides Function Prepare() As Boolean
        UseDefaultDialog = False
        Return MyBase.Prepare()
    End Function  'Prepare

    '----------------------------------------------------------------------------------------------
    ' Called when button is pressed (1)
    '----------------------------------------------------------------------------------------------
    Public Overrides Sub Clear()
        If Not stadisChargeList Is Nothing Then
            stadisChargeList.Clear()
        End If
        MyBase.Clear()
    End Sub  'Clear

    '----------------------------------------------------------------------------------------------
    ' Called when button is pressed (2)
    '----------------------------------------------------------------------------------------------
    Public Overrides Function HandleEvent() As Boolean
        Dim mFrmStadisCharge As New FrmStadisCharge
        With mFrmStadisCharge
            .Adapter = fAdapter
            .ParentDialog = Me
        End With
        Select Case mFrmStadisCharge.ShowDialog()
            Case Windows.Forms.DialogResult.OK
                Return True
            Case Windows.Forms.DialogResult.Cancel
                Return False
        End Select
        mFrmStadisCharge = Nothing
        Return MyBase.HandleEvent()
    End Function  'HandleEvent

    '----------------------------------------------------------------------------------------------
    ' Called when deleting
    '----------------------------------------------------------------------------------------------
    Public Overrides Function DeleteTender() As Boolean
        If fTenderType = gTenderDialogTenderType Then
            'todo reverse charge
            Dim tenderHandle As Integer = fAdapter.GetReferenceBOForAttribute(0, "Tenders")
            Dim remark() As String = CommonRoutines.BOGetStrAttributeValueByName(fAdapter, tenderHandle, "MANUAL_REMARK").Split("#"c)
            If remark.Length > 0 Then
                If remark(0) = "PR@" Then
                    MsgBox("To delete a Promoton tender, you must delete" & vbCrLf & "the Stadis tender which generated it.", MsgBoxStyle.Exclamation, "STADIS Tender")
                    Return False
                End If
                If remark.Length = 3 Then
                    Dim successful As Boolean = DoSVAccountReverse(remark(2))
                    If successful Then
                        Return True
                    Else
                        Return False
                    End If
                End If
            End If
        Else
            Return MyBase.DeleteTender()
        End If
    End Function  'DeleteTender

    Private Function DoSVAccountReverse(ByVal AuthID As String) As Boolean
        Dim invoiceHandle As Integer = 0
        Dim sr As New StadisRequest
        With sr
            .SiteID = gSiteID
            .StadisAuthorizationID = AuthID
            .VendorID = gVendorID
            .LocationID = gLocationID
            .RegisterID = CommonRoutines.BOGetStrAttributeValueByName(fAdapter, invoiceHandle, "Invoice Workstion")
            .ReceiptID = CommonRoutines.BOGetStrAttributeValueByName(fAdapter, invoiceHandle, "Invoice Number")
            .VendorCashier = CommonRoutines.BOGetStrAttributeValueByName(fAdapter, invoiceHandle, "Cashier")
        End With
        Dim sys As StadisReply() = CommonRoutines.StadisAPI.SVAccountReverse(sr)
        Dim hasBadReply As Boolean = False
        For Each sy As StadisReply In sys
            If sy.ReturnCode < 0 Then
                hasBadReply = True
                'LogStadisEvent(Guid.Empty, "Reverse Charge", "DoReverse", "A", sy.ReturnCode, "Unable to reverse charge for StadisAuthorizationID", "", "", "StadisAuthorizationID = " & sy.StadisAuthorizationID)
            End If
        Next
        If hasBadReply = True Then
            MsgBox("Unable to reverse charge for StadisAuthorizationID " & AuthID, MsgBoxStyle.Exclamation, "Reverse Charge")
            Return False
        Else
            Return True
        End If
    End Function  'DoSVAccountReverse

    '----------------------------------------------------------------------------------------------
    ' Called when RPro is shut down
    '----------------------------------------------------------------------------------------------
    Public Overrides Sub Cleanup()
        fBusinessObjectType = Nothing
        fDescription = Nothing
        fGUID = Nothing
        fTenderType = Nothing
        fUseDefaultDialog = Nothing
        stadisChargeList = Nothing
        MyBase.CleanUp()
    End Sub  'Cleanup

End Class  'TenderDialogue

