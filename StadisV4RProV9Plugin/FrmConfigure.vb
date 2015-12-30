Imports CommonV4
Imports Microsoft.Win32
Imports System.Drawing.Printing
Imports System.Windows.Forms
'----------------------------------------------------------------------------------------------
'   Class: FrmConfigure
'    Type: Windows Form
' Purpose: Screen for specifying WS preferences - invoked from Configure.vb.
'          Settings are stored in user.config in AppData.
'          The config file only supplies starter values.
'----------------------------------------------------------------------------------------------
Public Class FrmConfigure

#Region " Form Load and Initialization "

    Private Sub FrmConfigure_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DisplayVersionNumber()
        LoadPrinterDropdowns()
        LoadSettings()
    End Sub  'FrmConfigure_Load

    Private Sub DisplayVersionNumber()
        Dim mExecutingApp As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly
        Dim mName As System.Reflection.AssemblyName = mExecutingApp.GetName
        lblHAVer.Text = "Plugin Version: " & mName.Version.ToString
    End Sub  'DisplayVersionNumber

    Private Sub LoadPrinterDropdowns()
        'cbOPOS.Items.Add("Disabled")
        'cbRaster.Items.Add("Disabled")
        cbPrinter.Items.Add("Disabled")
        'Dim mOPOSKey As RegistryKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\OLEforRetail\ServiceOPOS\POSPrinter")
        'For Each mKey As String In mOPOSKey.GetSubKeyNames
        '    cbOPOS.Items.Add(mKey)
        'Next
        For Each mPrinter As String In PrinterSettings.InstalledPrinters
            'cbRaster.Items.Add(mPrinter)
            cbPrinter.Items.Add(mPrinter)
        Next
        'cbOPOS.SelectedIndex = 0
        'cbRaster.SelectedIndex = 0
        cbPrinter.SelectedIndex = 0
    End Sub  'LoadPrinterDropdowns

    Private Sub LoadSettings()
        txtSiteID.Text = My.Settings.SiteID
        txtVendorID.Text = My.Settings.VendorID
        txtLocationID.Text = My.Settings.LocationID
        txtStadisWebServiceURL.Text = My.Settings.StadisV4WebServiceURL
        txtStadisUserID.Text = My.Settings.StadisUserID
        txtStadisPassword.Text = My.Settings.StadisPassword
        txtOverrideSettingID.Text = My.Settings.OverrideSettingID
        'cbOPOS.Text = My.Settings.OPOSPrinterName
        'cbRaster.Text = My.Settings.RasterPrinterName
        cbPrinter.Text = My.Settings.WindowsPrinterName
        chkLog.Checked = My.Settings.Log
        chkNetworkChecking.Checked = My.Settings.NetworkChecking
    End Sub  'LoadSettings

#End Region  'Form Load and Initialization

#Region " Buttons "

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        My.Settings.SiteID = txtSiteID.Text
        gSiteID = txtSiteID.Text
        My.Settings.VendorID = txtVendorID.Text
        gVendorID = txtVendorID.Text
        My.Settings.LocationID = txtLocationID.Text
        gLocationID = txtLocationID.Text
        My.Settings.StadisV4WebServiceURL = txtStadisWebServiceURL.Text
        gStadisV4WebServiceURL = txtStadisWebServiceURL.Text
        My.Settings.StadisUserID = txtStadisUserID.Text
        gStadisUserID = txtStadisUserID.Text
        My.Settings.StadisPassword = txtStadisPassword.Text
        gStadisPassword = txtStadisPassword.Text
        My.Settings.OverrideSettingID = txtOverrideSettingID.Text
        gOverrideSettingComponent = txtOverrideSettingID.Text
        'My.Settings.OPOSPrinterName = cbOPOS.Text
        'gOPOSPrinterName = cbOPOS.Text
        'My.Settings.RasterPrinterName = cbRaster.Text
        'gRasterPrinterName = cbRaster.Text
        My.Settings.WindowsPrinterName = cbPrinter.Text
        gWindowsPrinterName = cbPrinter.Text
        My.Settings.Log = chkLog.Checked
        gLog = chkLog.Checked
        My.Settings.NetworkChecking = chkNetworkChecking.Checked
        gNetworkChecking = chkNetworkChecking.Checked
        My.Settings.Save()
        Me.Close()
    End Sub  'btnSave_Click

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub  'btnCancel_Click

#End Region  'Buttons

End Class  'FrmConfigure