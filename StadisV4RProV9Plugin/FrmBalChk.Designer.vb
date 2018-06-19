<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBalChk
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBalChk))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.nIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.cmSysT = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OpenSTADISBalanceCheckToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.pbInfo = New System.Windows.Forms.PictureBox()
        Me.pbInactive = New System.Windows.Forms.PictureBox()
        Me.pbActive = New System.Windows.Forms.PictureBox()
        Me.tblMenu = New System.Windows.Forms.TableLayoutPanel()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnBalChk = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnHistory = New System.Windows.Forms.Button()
        Me.btnMerge = New System.Windows.Forms.Button()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblBackBal = New System.Windows.Forms.Label()
        Me.lblTotlBal = New System.Windows.Forms.Label()
        Me.lblMainBal = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblBackupAcct1 = New System.Windows.Forms.Label()
        Me.lblMainAcct = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblInput = New System.Windows.Forms.Label()
        Me.sbStatus = New Infragistics.Win.UltraWinStatusBar.UltraStatusBar()
        Me.pbLogo = New Infragistics.Win.UltraWinEditors.UltraPictureBox()
        Me.txtInput = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblBackAvail = New System.Windows.Forms.Label()
        Me.lblTotlAvail = New System.Windows.Forms.Label()
        Me.lblMainAvail = New System.Windows.Forms.Label()
        Me.cmSysT.SuspendLayout()
        CType(Me.pbInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbInactive, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbActive, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tblMenu.SuspendLayout()
        CType(Me.sbStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInput, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblHeader
        '
        Me.lblHeader.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.ForeColor = System.Drawing.Color.Teal
        Me.lblHeader.Location = New System.Drawing.Point(128, 8)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(408, 64)
        Me.lblHeader.TabIndex = 0
        Me.lblHeader.Text = "Gift Card / Ticket Balance Check"
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'nIcon
        '
        Me.nIcon.ContextMenuStrip = Me.cmSysT
        Me.nIcon.Icon = CType(resources.GetObject("nIcon.Icon"), System.Drawing.Icon)
        Me.nIcon.Text = "STADIS Balance Check"
        Me.nIcon.Visible = True
        '
        'cmSysT
        '
        Me.cmSysT.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenSTADISBalanceCheckToolStripMenuItem, Me.ToolStripSeparator1, Me.ExitToolStripMenuItem})
        Me.cmSysT.Name = "cmSysT"
        Me.cmSysT.Size = New System.Drawing.Size(178, 54)
        '
        'OpenSTADISBalanceCheckToolStripMenuItem
        '
        Me.OpenSTADISBalanceCheckToolStripMenuItem.Image = CType(resources.GetObject("OpenSTADISBalanceCheckToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OpenSTADISBalanceCheckToolStripMenuItem.Name = "OpenSTADISBalanceCheckToolStripMenuItem"
        Me.OpenSTADISBalanceCheckToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.OpenSTADISBalanceCheckToolStripMenuItem.Text = "&Run Balance Check"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(174, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Image = CType(resources.GetObject("ExitToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.ExitToolStripMenuItem.Text = "Sh&utdown Program"
        '
        'pbInfo
        '
        Me.pbInfo.Image = CType(resources.GetObject("pbInfo.Image"), System.Drawing.Image)
        Me.pbInfo.Location = New System.Drawing.Point(486, 135)
        Me.pbInfo.Name = "pbInfo"
        Me.pbInfo.Size = New System.Drawing.Size(48, 48)
        Me.pbInfo.TabIndex = 28
        Me.pbInfo.TabStop = False
        Me.pbInfo.Visible = False
        '
        'pbInactive
        '
        Me.pbInactive.Image = CType(resources.GetObject("pbInactive.Image"), System.Drawing.Image)
        Me.pbInactive.Location = New System.Drawing.Point(486, 135)
        Me.pbInactive.Name = "pbInactive"
        Me.pbInactive.Size = New System.Drawing.Size(48, 48)
        Me.pbInactive.TabIndex = 27
        Me.pbInactive.TabStop = False
        Me.pbInactive.Visible = False
        '
        'pbActive
        '
        Me.pbActive.Image = CType(resources.GetObject("pbActive.Image"), System.Drawing.Image)
        Me.pbActive.Location = New System.Drawing.Point(486, 135)
        Me.pbActive.Name = "pbActive"
        Me.pbActive.Size = New System.Drawing.Size(48, 48)
        Me.pbActive.TabIndex = 26
        Me.pbActive.TabStop = False
        Me.pbActive.Visible = False
        '
        'tblMenu
        '
        Me.tblMenu.ColumnCount = 6
        Me.tblMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.0!))
        Me.tblMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.0!))
        Me.tblMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.0!))
        Me.tblMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.0!))
        Me.tblMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.0!))
        Me.tblMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.0!))
        Me.tblMenu.Controls.Add(Me.btnPrint, 1, 0)
        Me.tblMenu.Controls.Add(Me.btnBalChk, 0, 0)
        Me.tblMenu.Controls.Add(Me.btnClear, 2, 0)
        Me.tblMenu.Controls.Add(Me.btnExit, 5, 0)
        Me.tblMenu.Controls.Add(Me.btnHistory, 4, 0)
        Me.tblMenu.Controls.Add(Me.btnMerge, 3, 0)
        Me.tblMenu.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.tblMenu.Location = New System.Drawing.Point(14, 411)
        Me.tblMenu.Name = "tblMenu"
        Me.tblMenu.RowCount = 1
        Me.tblMenu.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblMenu.Size = New System.Drawing.Size(520, 68)
        Me.tblMenu.TabIndex = 25
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.AutoSize = True
        Me.btnPrint.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.Location = New System.Drawing.Point(95, 3)
        Me.btnPrint.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(79, 62)
        Me.btnPrint.TabIndex = 1
        Me.btnPrint.Text = "&Print"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnBalChk
        '
        Me.btnBalChk.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBalChk.AutoSize = True
        Me.btnBalChk.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBalChk.Image = CType(resources.GetObject("btnBalChk.Image"), System.Drawing.Image)
        Me.btnBalChk.Location = New System.Drawing.Point(3, 3)
        Me.btnBalChk.Name = "btnBalChk"
        Me.btnBalChk.Size = New System.Drawing.Size(87, 62)
        Me.btnBalChk.TabIndex = 0
        Me.btnBalChk.Text = "&Bal Chk"
        Me.btnBalChk.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBalChk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnBalChk.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClear.AutoSize = True
        Me.btnClear.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.Image = CType(resources.GetObject("btnClear.Image"), System.Drawing.Image)
        Me.btnClear.Location = New System.Drawing.Point(179, 3)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(77, 62)
        Me.btnClear.TabIndex = 2
        Me.btnClear.Text = "&Clear"
        Me.btnClear.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.AutoSize = True
        Me.btnExit.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.Location = New System.Drawing.Point(438, 3)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(79, 62)
        Me.btnExit.TabIndex = 5
        Me.btnExit.Text = "E&xit"
        Me.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnHistory
        '
        Me.btnHistory.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnHistory.AutoSize = True
        Me.btnHistory.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHistory.Image = CType(resources.GetObject("btnHistory.Image"), System.Drawing.Image)
        Me.btnHistory.Location = New System.Drawing.Point(350, 3)
        Me.btnHistory.Name = "btnHistory"
        Me.btnHistory.Size = New System.Drawing.Size(82, 62)
        Me.btnHistory.TabIndex = 4
        Me.btnHistory.Text = "&History"
        Me.btnHistory.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnHistory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnHistory.UseVisualStyleBackColor = True
        '
        'btnMerge
        '
        Me.btnMerge.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMerge.AutoSize = True
        Me.btnMerge.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        'Me.btnMerge.Image = Global.My.Resources.Resources.replace21
        Me.btnMerge.Location = New System.Drawing.Point(262, 3)
        Me.btnMerge.Name = "btnMerge"
        Me.btnMerge.Size = New System.Drawing.Size(82, 62)
        Me.btnMerge.TabIndex = 3
        Me.btnMerge.Text = "&Merge"
        Me.btnMerge.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnMerge.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnMerge.UseVisualStyleBackColor = True
        '
        'lblStatus
        '
        Me.lblStatus.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(228, 143)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(185, 31)
        Me.lblStatus.TabIndex = 16
        Me.lblStatus.Text = "Unknown"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBackBal
        '
        Me.lblBackBal.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBackBal.Location = New System.Drawing.Point(186, 275)
        Me.lblBackBal.Name = "lblBackBal"
        Me.lblBackBal.Size = New System.Drawing.Size(154, 32)
        Me.lblBackBal.TabIndex = 22
        Me.lblBackBal.Text = "$0.00"
        Me.lblBackBal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotlBal
        '
        Me.lblTotlBal.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotlBal.Location = New System.Drawing.Point(186, 311)
        Me.lblTotlBal.Name = "lblTotlBal"
        Me.lblTotlBal.Size = New System.Drawing.Size(154, 45)
        Me.lblTotlBal.TabIndex = 23
        Me.lblTotlBal.Text = "$0.00"
        Me.lblTotlBal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMainBal
        '
        Me.lblMainBal.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMainBal.Location = New System.Drawing.Point(186, 239)
        Me.lblMainBal.Name = "lblMainBal"
        Me.lblMainBal.Size = New System.Drawing.Size(154, 32)
        Me.lblMainBal.TabIndex = 21
        Me.lblMainBal.Text = "$0.00"
        Me.lblMainBal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Teal
        Me.Label5.Location = New System.Drawing.Point(119, 326)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 22)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Total:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBackupAcct1
        '
        Me.lblBackupAcct1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBackupAcct1.ForeColor = System.Drawing.Color.Teal
        Me.lblBackupAcct1.Location = New System.Drawing.Point(32, 282)
        Me.lblBackupAcct1.Name = "lblBackupAcct1"
        Me.lblBackupAcct1.Size = New System.Drawing.Size(150, 24)
        Me.lblBackupAcct1.TabIndex = 17
        Me.lblBackupAcct1.Text = "Backing Account:"
        Me.lblBackupAcct1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMainAcct
        '
        Me.lblMainAcct.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMainAcct.ForeColor = System.Drawing.Color.Teal
        Me.lblMainAcct.Location = New System.Drawing.Point(36, 246)
        Me.lblMainAcct.Name = "lblMainAcct"
        Me.lblMainAcct.Size = New System.Drawing.Size(146, 24)
        Me.lblMainAcct.TabIndex = 20
        Me.lblMainAcct.Text = "Main Account:"
        Me.lblMainAcct.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Teal
        Me.Label2.Location = New System.Drawing.Point(86, 153)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 19)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Status Message:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblInput
        '
        Me.lblInput.AutoSize = True
        Me.lblInput.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInput.ForeColor = System.Drawing.Color.Teal
        Me.lblInput.Location = New System.Drawing.Point(54, 100)
        Me.lblInput.Name = "lblInput"
        Me.lblInput.Size = New System.Drawing.Size(168, 19)
        Me.lblInput.TabIndex = 13
        Me.lblInput.Text = "Scan/Enter Barcode:"
        Me.lblInput.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'sbStatus
        '
        Appearance1.FontData.Name = "Tahoma"
        Me.sbStatus.Appearance = Appearance1
        Me.sbStatus.BorderStyle = Infragistics.Win.UIElementBorderStyle.Raised
        Me.sbStatus.Location = New System.Drawing.Point(0, 500)
        Me.sbStatus.Name = "sbStatus"
        Me.sbStatus.Size = New System.Drawing.Size(549, 23)
        Me.sbStatus.TabIndex = 29
        Me.sbStatus.Text = "Ready ..."
        '
        'pbLogo
        '
        Me.pbLogo.BorderShadowColor = System.Drawing.Color.Empty
        Me.pbLogo.ImageTransparentColor = System.Drawing.Color.White
        Me.pbLogo.Location = New System.Drawing.Point(16, 8)
        Me.pbLogo.Name = "pbLogo"
        Me.pbLogo.Size = New System.Drawing.Size(104, 64)
        Me.pbLogo.TabIndex = 30
        '
        'txtInput
        '
        Appearance2.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(235, Byte), Integer))
        Appearance2.FontData.BoldAsString = "True"
        Appearance2.FontData.Name = "Arial"
        Appearance2.FontData.SizeInPoints = 18.0!
        Me.txtInput.Appearance = Appearance2
        Me.txtInput.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.txtInput.Location = New System.Drawing.Point(225, 87)
        Me.txtInput.Name = "txtInput"
        Me.txtInput.Size = New System.Drawing.Size(282, 37)
        Me.txtInput.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Teal
        Me.Label6.Location = New System.Drawing.Point(14, 375)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(512, 19)
        Me.Label6.TabIndex = 33
        Me.Label6.Text = "* Checking of backing account balances goes only one level deep."
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Teal
        Me.Label3.Location = New System.Drawing.Point(417, 206)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 24)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "Available"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Arial", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Teal
        Me.Label7.Location = New System.Drawing.Point(252, 206)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 24)
        Me.Label7.TabIndex = 35
        Me.Label7.Text = "Balance"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Teal
        Me.Label1.Location = New System.Drawing.Point(505, 317)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(17, 22)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "*"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBackAvail
        '
        Me.lblBackAvail.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBackAvail.Location = New System.Drawing.Point(352, 275)
        Me.lblBackAvail.Name = "lblBackAvail"
        Me.lblBackAvail.Size = New System.Drawing.Size(154, 32)
        Me.lblBackAvail.TabIndex = 37
        Me.lblBackAvail.Text = "$0.00"
        Me.lblBackAvail.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotlAvail
        '
        Me.lblTotlAvail.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotlAvail.Location = New System.Drawing.Point(356, 311)
        Me.lblTotlAvail.Name = "lblTotlAvail"
        Me.lblTotlAvail.Size = New System.Drawing.Size(154, 45)
        Me.lblTotlAvail.TabIndex = 38
        Me.lblTotlAvail.Text = "$0.00"
        Me.lblTotlAvail.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMainAvail
        '
        Me.lblMainAvail.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMainAvail.Location = New System.Drawing.Point(352, 239)
        Me.lblMainAvail.Name = "lblMainAvail"
        Me.lblMainAvail.Size = New System.Drawing.Size(154, 32)
        Me.lblMainAvail.TabIndex = 36
        Me.lblMainAvail.Text = "$0.00"
        Me.lblMainAvail.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FrmBalChk
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(549, 523)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblBackAvail)
        Me.Controls.Add(Me.lblTotlAvail)
        Me.Controls.Add(Me.lblMainAvail)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtInput)
        Me.Controls.Add(Me.pbLogo)
        Me.Controls.Add(Me.sbStatus)
        Me.Controls.Add(Me.pbInfo)
        Me.Controls.Add(Me.pbInactive)
        Me.Controls.Add(Me.pbActive)
        Me.Controls.Add(Me.tblMenu)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lblBackBal)
        Me.Controls.Add(Me.lblTotlBal)
        Me.Controls.Add(Me.lblMainBal)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblBackupAcct1)
        Me.Controls.Add(Me.lblMainAcct)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblInput)
        Me.Controls.Add(Me.lblHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmBalChk"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "STADIS - Ticket Balance Check"
        Me.cmSysT.ResumeLayout(False)
        CType(Me.pbInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbInactive, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbActive, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tblMenu.ResumeLayout(False)
        Me.tblMenu.PerformLayout()
        CType(Me.sbStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInput, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents nIcon As System.Windows.Forms.NotifyIcon
    Friend WithEvents cmSysT As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents OpenSTADISBalanceCheckToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pbInfo As System.Windows.Forms.PictureBox
    Friend WithEvents pbInactive As System.Windows.Forms.PictureBox
    Friend WithEvents pbActive As System.Windows.Forms.PictureBox
    Friend WithEvents tblMenu As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnBalChk As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnHistory As System.Windows.Forms.Button
    Friend WithEvents btnMerge As System.Windows.Forms.Button
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblBackBal As System.Windows.Forms.Label
    Friend WithEvents lblTotlBal As System.Windows.Forms.Label
    Friend WithEvents lblMainBal As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblBackupAcct1 As System.Windows.Forms.Label
    Friend WithEvents lblMainAcct As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblInput As System.Windows.Forms.Label
    Friend WithEvents sbStatus As Infragistics.Win.UltraWinStatusBar.UltraStatusBar
    Friend WithEvents pbLogo As Infragistics.Win.UltraWinEditors.UltraPictureBox
    Friend WithEvents txtInput As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblBackAvail As System.Windows.Forms.Label
    Friend WithEvents lblTotlAvail As System.Windows.Forms.Label
    Friend WithEvents lblMainAvail As System.Windows.Forms.Label
    Friend WithEvents btnPrint As System.Windows.Forms.Button
End Class
