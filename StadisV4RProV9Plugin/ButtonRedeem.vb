Imports CommonV4
Imports CommonV4.WebReference
Imports RetailPro.CustomPluginClasses
Imports RetailPro.Plugins
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
'----------------------------------------------------------------------------------------------
'   Class: ButtonRedeem
'    Type: SideButton - Tender
' Purpose: Invokes FrmRedeem to collect tender information
'          During initialization, loads installation settings and WS settings
'----------------------------------------------------------------------------------------------
<GuidAttribute(Discover.CLASS_ButtonRedeem)> _
Public Class ButtonRedeem
    Inherits TCustomSideButtonPlugin

    '----------------------------------------------------------------------------------------------
    ' Called when plugin is loaded
    '----------------------------------------------------------------------------------------------
    Public Overrides Sub Initialize()
        MyBase.Initialize()

        LoadLocalSettings()
        CommonRoutines.LoadInstallationSettings()
        'MessageBox.Show("Hey there.", "STADIS")

        fButtonEnabled = gRedeemButtonEnabled
        fHint = gRedeemButtonHint
        fCaption = "Disabled"
        fPictureFilename = gRedeemButtonImage
        fLayoutActionName = "actStadisRedeemButton"
        fChecked = True
        fEnabled = False
        fGUID = New Guid(Discover.CLASS_ButtonRedeem)
        fBusinessObjectType = RetailPro.Plugins.BusinessObjectType.btInvoice
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
    ' Called when button is clicked
    '----------------------------------------------------------------------------------------------
    Public Overrides Function HandleEvent() As Boolean
        Return MyBase.HandleEvent()
    End Function  'HandleEvent

    '----------------------------------------------------------------------------------------------
    ' Enables/disables button based on Receipt Type
    '----------------------------------------------------------------------------------------------
    Public Overrides ReadOnly Property ButtonEnabled() As Boolean
        Get
            Try
                If CInt(fAdapter.BOGetAttributeValueByName(0, "Invoice Type")) = 0 Then
                    fEnabled = True
                    gIsAReturn = False
                Else
                    fEnabled = False
                    gIsAReturn = True
                End If
            Catch ex As Exception

            End Try
            Return MyBase.Enabled
        End Get
    End Property

End Class  'ButtonRedeem
