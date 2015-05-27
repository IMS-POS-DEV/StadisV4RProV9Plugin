Imports CommonV4
Imports CommonV4.WebReference
Imports RetailPro.CustomPluginClasses
Imports RetailPro.Plugins
Imports System
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Public Class FrmBalChk

#Region " Data Declarations "

    Private Const CARD_PATTERN As String = "(?<=;)[0-9]+(?=([=\?]|$))"
    Private initBalance As Decimal
    Private mainBalance As Decimal
    Private bkupBalance As Decimal
    Private totlBalance As Decimal
    Private mainAvail As Decimal
    Private bkupAvail As Decimal
    Private totlAvail As Decimal
    Private sScanTimeStamp As String

    'Private OPOSPrinter As New POS.Devices.OPOSPOSPrinter
    'Private mStarComm As New StarComm
    'Private WithEvents mWinPrint As New Printing.PrintDocument

    Private Const LF As Char = Chr(10)

    'Private Const SC_EMPHASIZE_ON As StarComm.PrinterCommands = StarComm.PrinterCommands.SC_EMPHASIZE_ON
    'Private Const SC_EMPHASIZE_OFF As StarComm.PrinterCommands = StarComm.PrinterCommands.SC_EMPHASIZE_OFF
    'Private Const SC_FEED_FULL_CUT As StarComm.PrinterCommands = StarComm.PrinterCommands.SC_FEED_FULL_CUT
    'Private Const SC_HEIGHT_X1 As StarComm.PrinterCommands = StarComm.PrinterCommands.SC_HEIGHT_X1
    'Private Const SC_HEIGHT_X2 As StarComm.PrinterCommands = StarComm.PrinterCommands.SC_HEIGHT_X2
    'Private Const SC_INITIALISE As StarComm.PrinterCommands = StarComm.PrinterCommands.SC_INITIALISE
    'Private Const SC_WIDTH_X1 As StarComm.PrinterCommands = StarComm.PrinterCommands.SC_WIDTH_X1
    'Private Const SC_WIDTH_X2 As StarComm.PrinterCommands = StarComm.PrinterCommands.SC_WIDTH_X2
    'Private Const SC_INVERT_OFF As StarComm.PrinterCommands = StarComm.PrinterCommands.SC_INVERT_OFF
    'Private Const SC_UNDERLINE_OFF As StarComm.PrinterCommands = StarComm.PrinterCommands.SC_UNDERLINE_OFF
    'Private Const SC_UPPERLINE_OFF As StarComm.PrinterCommands = StarComm.PrinterCommands.SC_UPPERLINE_OFF

    Private mAdapter As RetailPro.Plugins.IPluginAdapter
    Friend Property Adapter() As RetailPro.Plugins.IPluginAdapter
        Get
            Return mAdapter
        End Get
        Set(ByVal value As RetailPro.Plugins.IPluginAdapter)
            mAdapter = value
        End Set
    End Property

#End Region  'Data Declarations

#Region " Form Load and Initialization "

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            'If gIsPrintingEnabled = False Then
            btnPrint.Visible = False
            tblMenu.ColumnStyles(1).Width = 0
            'End If

            If gIsMergeFunctionEnabled = False Then
                btnMerge.Visible = False
                tblMenu.ColumnStyles(3).Width = 0
            End If

            pbLogo.Image = New Bitmap(gFormLogoImage)

        Catch ex As Exception
            pbLogo.Image = Nothing
        End Try
    End Sub  'frmMain_Load

#End Region  'Form Load and Initialization

#Region " Buttons "

    Private Sub btnBalChk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBalChk.Click
        Try
            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            BalanceCheck()
            Windows.Forms.Cursor.Current = Cursors.Default
        Catch ex As Exception
            MsgBox("An error has occurred..." & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical, "STADIS Balance Check")
        End Try
    End Sub  'btnBalChk_Click

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click

    End Sub  'btnPrint_Click

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtInput.Text = ""
        lblStatus.Text = ""
        ResetAmountFields("Zero")
        SetStatusMessageIcon("None")
        txtInput.Focus()
    End Sub  'btnClear_Click

    Private Sub btnMerge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMerge.Click
        Dim frmMerge As New frmMerge
        frmMerge.ShowDialog()
    End Sub  'btnMerge_Click

    Private Sub btnHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHistory.Click
        If txtInput.Text = Nothing Then
            MsgBox("Please scan ticket or gift card.")
            txtInput.Focus()
            Exit Sub
        End If
        Try
            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            BalanceCheck()
            Windows.Forms.Cursor.Current = Cursors.Default
        Catch ex As Exception
            MsgBox("An error has occurred..." & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical, "STADIS Balance Check")
        End Try
        Dim frmHistory As New FrmHistory
        With frmHistory
            .TicketID = Trim(txtInput.Text)
            .TicketStatus = Trim(lblStatus.Text)
            .Balance = CDec(totlBalance)
            .ScanTimeStamp = sScanTimeStamp
            .ShowDialog()
        End With
        txtInput.Focus()
        txtInput.SelectAll()
    End Sub  'btnHistory_Click

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        txtInput.Text = ""
        lblStatus.Text = ""
        ResetAmountFields("Zero")
        lblMainBal.Text = "$0.00"
        lblBackBal.Text = "$0.00"
        lblTotlBal.Text = "$0.00"
        lblMainAvail.Text = "$0.00"
        lblBackAvail.Text = "$0.00"
        lblTotlAvail.Text = "$0.00"
        SetStatusMessageIcon("None")
        txtInput.Focus()
        'Me.WindowState = FormWindowState.Minimized
        'Me.ShowInTaskbar = False
        Me.Close()
    End Sub  'btnExit_Click

#End Region  'Buttons

#Region " Print Routines "

    'Private Sub PrintBalanceToWindows()
    '    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    '    sbStatus.Text = "Printing Balance..."
    '    Dim balancePrint As New BalancePrint
    '    With balancePrint
    '        .SetParameterValue(0, "N/A")
    '        .SetParameterValue(1, gStadisTenderText)
    '        .SetParameterValue(2, "xxxxxxxxxx" & Mid(Trim(txtInput.Text), Len(Trim(txtInput.Text)) - 3, 4))
    '        .SetParameterValue(3, totlBalance.ToString("""$""#,##0.00"))
    '        .PrintOptions.PrinterName = gWindowsPrinterName
    '        .PrintToPrinter(1, True, 1, 1)
    '    End With
    '    sbStatus.Text = "Ready..."
    '    Windows.Forms.Cursor.Current = Cursors.Default
    'End Sub  'PrintBalanceToWindows

    'Private Sub PrintBalanceToStarRaster()
    '    Application.DoEvents()
    '    StarC.Visible = True
    '    Dim ESC As String = Mid(Chr(&H1B), 1, 1)
    '    Try
    '        With StarC
    '            .ShowSpooler = True
    '            .Protocol = StarComm.Protocols.SC_Spooler
    '            .SpoolPrinter = gRasterPrinterName
    '            .StarComm_Command(SC_INITIALISE)
    '            .StarComm_InitializePrintJob()
    '            .StarComm_Command(SC_EMPHASIZE_ON)
    '            .StarComm_Command(SC_HEIGHT_X1)
    '            .StarComm_Command(SC_INVERT_OFF)
    '            .StarComm_Command(SC_UNDERLINE_OFF)
    '            .StarComm_Command(SC_UPPERLINE_OFF)
    '            .StarComm_Command(SC_WIDTH_X2)
    '            .StarComm_Output("  BALANCE STATEMENT" & LF & LF)
    '            .StarComm_Command(SC_EMPHASIZE_OFF)
    '            .StarComm_Command(SC_WIDTH_X1)

    '            .StarComm_Output(LF)
    '            .StarComm_Output("----------------------------------------" & LF)
    '            .StarComm_Command(SC_HEIGHT_X2)
    '            .StarComm_Command(SC_EMPHASIZE_ON)
    '            .StarComm_Output(Space(CInt((40 - Len("BALANCE AS OF " & sScanTimeStamp)) / 2)) & "BALANCE AS OF " & sScanTimeStamp & LF)
    '            .StarComm_Command(SC_WIDTH_X2)
    '            .StarComm_Output(Space(CInt((20 - Len(totlBalance)) / 2)) & totlBalance.ToString("""$""#,##0.00") & LF)
    '            .StarComm_Command(SC_HEIGHT_X1)
    '            .StarComm_Command(SC_WIDTH_X1)
    '            .StarComm_Output(LF & LF)
    '            .StarComm_Command(SC_FEED_FULL_CUT)
    '            .StarComm_Print()
    '        End With
    '    Catch ex As Exception
    '        MsgBox("Error Printing:" & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Print Balance")
    '    End Try
    '    StarC.Visible = False
    'End Sub  'PrintBalanceToStarRaster

    'Private Sub PrintBalanceToOPOS()
    '    sbStatus.Text = "Printing..."
    '    Application.DoEvents()
    '    Dim ESC As String = Mid(Chr(&H1B), 1, 1)
    '    Try
    '        With OPOSPrinter
    '            .Open(gOPOSPrinterName)
    '            .ClaimDevice(10000)
    '            .DeviceEnabled = True
    '            .TransactionPrint(PTR_S_RECEIPT, PTR_TP_TRANSACTION)
    '            .PrintNormal(PTR_S_RECEIPT, ESC & "|cA" & ESC & "|2C" & ESC & "|bC" & "BALANCE STATEMENT" & LF & LF)
    '            .PrintNormal(PTR_S_RECEIPT, LF)
    '            .PrintNormal(PTR_S_RECEIPT, "----------------------------------------" & LF)
    '            .PrintNormal(PTR_S_RECEIPT, ESC & "|cA" & ESC & "|bC" & ESC & "|3C" & "BALANCE AS OF " & sScanTimeStamp & LF)
    '            .PrintNormal(PTR_S_RECEIPT, ESC & "|cA" & ESC & "|bC" & ESC & "|4C" & totlBalance.ToString("""$""#,##0.00") & LF)
    '            .PrintNormal(PTR_S_RECEIPT, LF & LF)
    '            .PrintNormal(PTR_S_RECEIPT, Chr(&H1BS) + "|100fP")
    '            .TransactionPrint(PTR_S_RECEIPT, PTR_TP_NORMAL)
    '            .DeviceEnabled = False
    '            .ReleaseDevice()
    '            .Close()
    '        End With
    '    Catch ex As Exception
    '        MsgBox("Error Printing:" & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Print Balance")
    '        sbStatus.Text = "Ready..."
    '    End Try
    '    sbStatus.Text = "Ready..."
    'End Sub  'PrintBalanceToOPOS

#End Region  'Print Routines

#Region " Other Methods "

    Private Sub txtInput_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtInput.KeyDown
        Select Case e.KeyCode
            Case Keys.Tab, Keys.Enter, Keys.Right
                Try
                    BalanceCheck()
                Catch ex As Exception
                    MsgBox("An error has occurred..." & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical, "STADIS Balance Check")
                End Try
                e.Handled = True
        End Select
    End Sub  'txtInput_KeyDown

    Public Sub BalanceCheck()
        If txtInput.Text = Nothing Then Exit Sub


        'Strip out extra characters from scanner
        Dim processedScan As String = CommonRoutines.ExtractScan(txtInput.Text)
        If processedScan <> txtInput.Text Then
            txtInput.Text = processedScan
        End If

        'check barcode length and other rules
        If CommonRoutines.ValidateScan(txtInput.Text) = False Then
            MsgBox("Invalid scan or number entry.", MsgBoxStyle.Exclamation, "Card or Ticket Tender")
            Exit Sub
        End If

        lblStatus.Text = ""
        ResetAmountFields("Blank")
        Dim invoiceHandle As Integer = 0
        Try
            sbStatus.Text = "Connecting to STADIS..."
            Dim sr As New StadisRequest
            With sr
                .SiteID = gSiteID
                .TenderTypeID = 1
                .TenderID = txtInput.Text
                .Amount = 0
                .ReferenceNumber = ""
                .VendorID = gVendorID
                .LocationID = gLocationID
                .RegisterID = gRegisterID
                .ReceiptID = ""
                .VendorCashier = gVendorCashier
            End With
            sbStatus.Text = "Checking Balance..."
            Me.Refresh()
            Dim ts As TicketStatus = CommonRoutines.StadisAPI.GetTicketStatus(sr)
            With ts
                sbStatus.Text = "Receiving Response..."
                Me.Refresh()
                sScanTimeStamp = Now.ToString("%M/%d/yy @ %h:mm tt")
                initBalance = .SVA1InitialDeposit
                totlBalance = .SVA1Balance + .SVA2Balance
                totlAvail = .SVA1Avail + .SVA2Avail
                lblMainBal.Text = .SVA1Balance.ToString("""$""#,##0.00")
                lblBackBal.Text = .SVA2Balance.ToString("""$""#,##0.00")
                lblTotlBal.Text = totlBalance.ToString("""$""#,##0.00")
                lblMainAvail.Text = .SVA1Avail.ToString("""$""#,##0.00")
                lblBackAvail.Text = .SVA2Avail.ToString("""$""#,##0.00")
                lblTotlAvail.Text = totlAvail.ToString("""$""#,##0.00")
                If .TicketExists = False Then
                    lblStatus.Text = "NOT FOUND!"
                    lblStatus.ForeColor = Color.Red
                    SetStatusMessageIcon("Info")
                Else
                    Select Case .TicketEventTicketStatusID
                        Case 1
                            If .EventTicketEventID = "9999" Then
                                lblStatus.Text = "Active VIP"
                            Else
                                lblStatus.Text = "Active"
                            End If
                            lblStatus.ForeColor = Color.Black
                            SetStatusMessageIcon("Active")
                        Case 2, 21, 22
                            lblStatus.Text = "CLOSED"
                            lblStatus.ForeColor = Color.Red
                            SetStatusMessageIcon("Inactive")
                        Case 3
                            lblStatus.Text = "PENDING"
                            lblStatus.ForeColor = Color.Red
                            SetStatusMessageIcon("Inactive")
                        Case 4
                            lblStatus.Text = "SUSPENDED"
                            lblStatus.ForeColor = Color.Red
                            SetStatusMessageIcon("Inactive")
                        Case Else
                            lblStatus.Text = ts.ReturnMessage
                            lblStatus.ForeColor = Color.Black
                            SetStatusMessageIcon("None")
                    End Select
                End If
            End With
            With txtInput
                .Focus()
                .SelectAll()
            End With
            sbStatus.Text = "Ready..."
            Me.Refresh()
            Application.DoEvents()
            Me.Refresh()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error!")
            sbStatus.Text = "Ready..."
            lblStatus.Text = Nothing
            txtInput.Text = Nothing
            ResetAmountFields("Zero")
            txtInput.Focus()
        End Try
    End Sub  'CheckTicket

    Private Sub txtInput_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(Keys.Enter) Then
            e.Handled = True
            If txtInput.Text = Nothing Then Exit Sub
            Try
                BalanceCheck()
            Catch ex As Exception
                MsgBox("An error has occurred..." & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical, "STADIS Balance Check")
            End Try
        End If
    End Sub  'txtInput_KeyPress

    Private Sub OpenSTADISBalanceCheckToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenSTADISBalanceCheckToolStripMenuItem.Click
        Me.WindowState = FormWindowState.Normal
    End Sub  'OpenSTADISBalanceCheckToolStripMenuItem_Click

    'Private Sub frmMain_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
    '    If Me.WindowState = FormWindowState.Normal Then Me.ShowInTaskbar = True
    'End Sub  'frmMain_Resize

    Private Sub nIcon_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles nIcon.MouseDoubleClick
        Me.WindowState = FormWindowState.Normal
        Me.ShowInTaskbar = True
    End Sub  'nIcon_MouseDoubleClick

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub  'ExitToolStripMenuItem_Click

    Private Sub SetStatusMessageIcon(ByVal operation As String)
        pbActive.Visible = False
        pbInactive.Visible = False
        pbInfo.Visible = False
        Select Case operation
            Case "Active"
                pbActive.Visible = True
            Case "Inactive"
                pbInactive.Visible = True
            Case "Info"
                pbInfo.Visible = True
        End Select
    End Sub  'SetStatusMessageIcon

    Private Sub ResetAmountFields(ByVal operation As String)
        Select Case operation
            Case "Blank"
                lblMainBal.Text = ""
                lblBackBal.Text = ""
                lblTotlBal.Text = ""
                lblMainAvail.Text = ""
                lblBackAvail.Text = ""
                lblTotlAvail.Text = ""
            Case "Zero"
                lblMainBal.Text = "$0.00"
                lblBackBal.Text = "$0.00"
                lblTotlBal.Text = "$0.00"
                lblMainAvail.Text = "$0.00"
                lblBackAvail.Text = "$0.00"
                lblTotlAvail.Text = "$0.00"
        End Select
    End Sub  'ResetAmountFields

#End Region  'Other Methods

End Class  'FrmBalChk
