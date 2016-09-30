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
        fTenderType = gTenderDialogTenderType
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
            Dim remark() As String = fRemark.Split("#"c)
            If remark.Length > 0 Then
                If remark(0) = "@PR" Then
                    Return True
                End If
                Dim successful As Boolean = DoSVAccountReverse(fAdapter, remark(2))
                If successful Then
                    Return True
                Else
                    MsgBox("Unable to delete tender from Stadis.", MsgBoxStyle.Exclamation, "STADIS Tender")
                    Return True
                End If
            End If
        Else
            Return MyBase.DeleteTender()
        End If
    End Function  'DeleteTender

    '----------------------------------------------------------------------------------------------
    ' Called when RPro is shut down
    '----------------------------------------------------------------------------------------------
    Public Overrides Sub Cleanup()
        fBusinessObjectType = Nothing
        fDescription = Nothing
        fGUID = Nothing
        fTenderType = Nothing
        fUseDefaultDialog = Nothing
        MyBase.CleanUp()
    End Sub  'Cleanup

End Class  'TenderDialogue

