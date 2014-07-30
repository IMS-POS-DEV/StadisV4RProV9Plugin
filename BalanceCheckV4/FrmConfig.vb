Imports Microsoft.Win32
Imports System.Drawing.Printing
Imports System

Public Class FrmConfig
    Dim Config As System.Configuration.Configuration = Configuration.ConfigurationManager.OpenExeConfiguration(Configuration.ConfigurationUserLevel.None)

    Private Sub FrmConfig_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim mOPOSKey As RegistryKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\OLEforRetail\ServiceOPOS\POSPrinter")

        cmbOPOS.Items.Add("DISABLED")
        cmbRaster.Items.Add("DISABLED")
        cmbPrinter.Items.Add("DISABLED")

        For Each mKey As String In mOPOSKey.GetSubKeyNames
            cmbOPOS.Items.Add(mKey)
        Next

        For Each mPrinter As String In PrinterSettings.InstalledPrinters
            cmbRaster.Items.Add(mPrinter)
            cmbPrinter.Items.Add(mPrinter)
        Next

        cmbOPOS.SelectedIndex = 0
        cmbRaster.SelectedIndex = 0
        cmbPrinter.SelectedIndex = 0

        ' LOAD CURRENT CONFIG BELOW

        With Config.AppSettings.Settings
            txtWebURL.Text = .Item("StadisBalanceCheck_STADIS1_StadisTransactionsService").Value
            txtWebUser.Text = .Item("WebServiceUserID").Value
            txtWebPassword.Text = .Item("WebServicePassword").Value
            txtLogoFile.Text = .Item("LogoFile").Value
            txtHeader.Text = .Item("ProgramHeaderText").Value
            txtTender.Text = .Item("STADISTenderText").Value
            chkPrint.Checked = CBool(.Item("PrintButtonEnabled").Value)
            chkMerge.Checked = CBool(.Item("UseMergeFunction").Value)
            chkAction.Checked = CBool(.Item("ShowSTADISActions").Value)
            chkPrint.Checked = CBool(.Item("PrintButtonEnabled").Value)
            chkMerge.Checked = CBool(.Item("UseMergeFunction").Value)
            chkAction.Checked = CBool(.Item("ShowSTADISActions").Value)
            If .Item("OPOSPrinterName").Value = "" Then
                cmbOPOS.SelectedIndex = 0
            Else
                cmbOPOS.Text = .Item("OPOSPrinterName").Value
            End If
            If .Item("RasterPrinter").Value = "" Then
                cmbRaster.SelectedIndex = 0
            Else
                cmbRaster.Text = .Item("RasterPrinter").Value
            End If
            If .Item("WindowsPrinterName").Value = "" Then
                cmbPrinter.SelectedIndex = 0
            Else
                cmbPrinter.Text = .Item("WindowsPrinterName").Value
            End If
        End With

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        'FrmBalChk.Show()
        Me.Close()
    End Sub

    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        With Config.AppSettings.Settings
            .Remove("StadisBalanceCheck_STADIS1_StadisTransactionsService")
            .Add("StadisBalanceCheck_STADIS1_StadisTransactionsService", txtWebURL.Text)
            .Remove("WebServiceUserID")
            .Add("WebServiceUserID", txtWebUser.Text)
            .Remove("WebServicePassword")
            .Add("WebServicePassword", txtWebPassword.Text)
            .Remove("LogoFile")
            .Add("LogoFile", txtLogoFile.Text)
            .Remove("OPOSPrinterName")
            If cmbOPOS.Text = "DISABLED" Then
                .Add("OPOSPrinterName", "")
            Else
                .Add("OPOSPrinterName", cmbOPOS.Text)
            End If
            .Remove("WindowsPrinterName")
            If cmbPrinter.Text = "DISABLED" Then
                .Add("WindowsPrinterName", "")
            Else
                .Add("WindowsPrinterName", cmbPrinter.Text)
            End If
            .Remove("RasterPrinter")
            If cmbRaster.Text = "DISABLED" Then
                .Add("RasterPrinter", "")
            Else
                .Add("RasterPrinter", cmbRaster.Text)
            End If
            .Remove("STADISTenderText")
            .Add("STADISTenderText", txtTender.Text)
            .Remove("ProgramHeaderText")
            .Add("ProgramHeaderText", txtHeader.Text)
            .Remove("UseMergeFunction")
            .Add("UseMergeFunction", chkMerge.Checked.ToString)
            .Remove("PrintButtonEnabled")
            .Add("PrintButtonEnabled", chkPrint.Checked.ToString)
            .Remove("ShowSTADISActions")
            .Add("ShowSTADISActions", chkAction.Checked.ToString)
        End With
        Config.Save()
        Application.Exit()
    End Sub

    Private Sub btnLogoFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogoFile.Click
        Using mLogoDialog As New OpenFileDialog
            With mLogoDialog
                .CheckFileExists = True
                .CheckPathExists = True
                .FileName = txtLogoFile.Text
                .InitialDirectory = Application.StartupPath
                .Multiselect = False
                .ShowReadOnly = False
                .Title = "Specify Logo File"
                .Filter = "JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|BMP Files (*.bmp)|*.bmp|All Files (*.*)|*.*"
                If .ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
                txtLogoFile.Text = .FileName
            End With
        End Using
    End Sub
End Class