<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMerge
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TicketBarcode")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Amount")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMerge))
        Me.grdTickets = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.txtNewRemaining = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.Label()
        Me.txtCurrentRemaining = New System.Windows.Forms.Label()
        Me.txtSlave = New System.Windows.Forms.TextBox()
        Me.txtSlaveAmount = New System.Windows.Forms.TextBox()
        Me.txtMaster = New System.Windows.Forms.TextBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblNewRem = New System.Windows.Forms.Label()
        Me.lblAmount = New System.Windows.Forms.Label()
        Me.lblCurrentRem = New System.Windows.Forms.Label()
        Me.lblMaster = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnOK = New Infragistics.Win.Misc.UltraButton()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnScrollUp = New Infragistics.Win.Misc.UltraButton()
        Me.btnScrollDown = New Infragistics.Win.Misc.UltraButton()
        Me.btnDelete = New Infragistics.Win.Misc.UltraButton()
        CType(Me.grdTickets, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdTickets
        '
        Appearance1.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.grdTickets.DisplayLayout.Appearance = Appearance1
        UltraGridColumn1.Header.Caption = "Barcode"
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Width = 336
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn2.CellAppearance = Appearance2
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Width = 158
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2})
        Me.grdTickets.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.grdTickets.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grdTickets.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.BorderColor = System.Drawing.SystemColors.Window
        Me.grdTickets.DisplayLayout.GroupByBox.Appearance = Appearance3
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdTickets.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance4
        Me.grdTickets.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grdTickets.DisplayLayout.GroupByBox.Hidden = True
        Appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance5.BackColor2 = System.Drawing.SystemColors.Control
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdTickets.DisplayLayout.GroupByBox.PromptAppearance = Appearance5
        Me.grdTickets.DisplayLayout.MaxColScrollRegions = 1
        Me.grdTickets.DisplayLayout.MaxRowScrollRegions = 1
        Appearance6.BackColor = System.Drawing.SystemColors.Window
        Appearance6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grdTickets.DisplayLayout.Override.ActiveCellAppearance = Appearance6
        Appearance7.BackColor = System.Drawing.SystemColors.Highlight
        Appearance7.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdTickets.DisplayLayout.Override.ActiveRowAppearance = Appearance7
        Me.grdTickets.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.grdTickets.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
        Me.grdTickets.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None
        Me.grdTickets.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed
        Me.grdTickets.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdTickets.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdTickets.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdTickets.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.grdTickets.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance8.BackColor = System.Drawing.SystemColors.Window
        Me.grdTickets.DisplayLayout.Override.CardAreaAppearance = Appearance8
        Appearance9.BorderColor = System.Drawing.Color.Silver
        Appearance9.FontData.BoldAsString = "True"
        Appearance9.FontData.Name = "Arial"
        Appearance9.FontData.SizeInPoints = 16.0!
        Appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.grdTickets.DisplayLayout.Override.CellAppearance = Appearance9
        Me.grdTickets.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.grdTickets.DisplayLayout.Override.CellPadding = 0
        Appearance10.BackColor = System.Drawing.SystemColors.Control
        Appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance10.BorderColor = System.Drawing.SystemColors.Window
        Me.grdTickets.DisplayLayout.Override.GroupByRowAppearance = Appearance10
        Appearance11.BackColor = System.Drawing.Color.LightSeaGreen
        Appearance11.BackColor2 = System.Drawing.Color.Teal
        Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance11.FontData.BoldAsString = "True"
        Appearance11.FontData.Name = "Arial"
        Appearance11.FontData.SizeInPoints = 12.0!
        Appearance11.ForeColor = System.Drawing.Color.White
        Appearance11.TextHAlignAsString = "Left"
        Me.grdTickets.DisplayLayout.Override.HeaderAppearance = Appearance11
        Me.grdTickets.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdTickets.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Me.grdTickets.DisplayLayout.Override.MaxSelectedCells = 1
        Me.grdTickets.DisplayLayout.Override.MaxSelectedRows = 1
        Appearance12.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.grdTickets.DisplayLayout.Override.RowAlternateAppearance = Appearance12
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Appearance13.BorderColor = System.Drawing.Color.Silver
        Me.grdTickets.DisplayLayout.Override.RowAppearance = Appearance13
        Me.grdTickets.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance14.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grdTickets.DisplayLayout.Override.TemplateAddRowAppearance = Appearance14
        Me.grdTickets.DisplayLayout.Scrollbars = Infragistics.Win.UltraWinGrid.Scrollbars.None
        Me.grdTickets.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.grdTickets.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.grdTickets.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.grdTickets.Location = New System.Drawing.Point(18, 291)
        Me.grdTickets.Name = "grdTickets"
        Me.grdTickets.Size = New System.Drawing.Size(496, 160)
        Me.grdTickets.TabIndex = 32
        Me.grdTickets.Text = "UltraGrid1"
        '
        'txtNewRemaining
        '
        Me.txtNewRemaining.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNewRemaining.Location = New System.Drawing.Point(282, 126)
        Me.txtNewRemaining.Name = "txtNewRemaining"
        Me.txtNewRemaining.Size = New System.Drawing.Size(304, 32)
        Me.txtNewRemaining.TabIndex = 24
        Me.txtNewRemaining.Text = "$0.00"
        Me.txtNewRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtStatus
        '
        Me.txtStatus.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatus.Location = New System.Drawing.Point(282, 62)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(304, 32)
        Me.txtStatus.TabIndex = 20
        Me.txtStatus.Text = "ACTIVE"
        Me.txtStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCurrentRemaining
        '
        Me.txtCurrentRemaining.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCurrentRemaining.Location = New System.Drawing.Point(282, 94)
        Me.txtCurrentRemaining.Name = "txtCurrentRemaining"
        Me.txtCurrentRemaining.Size = New System.Drawing.Size(304, 32)
        Me.txtCurrentRemaining.TabIndex = 22
        Me.txtCurrentRemaining.Text = "$0.00"
        Me.txtCurrentRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtSlave
        '
        Me.txtSlave.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.txtSlave.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSlave.Location = New System.Drawing.Point(282, 191)
        Me.txtSlave.MaxLength = 20
        Me.txtSlave.Name = "txtSlave"
        Me.txtSlave.Size = New System.Drawing.Size(304, 32)
        Me.txtSlave.TabIndex = 26
        '
        'txtSlaveAmount
        '
        Me.txtSlaveAmount.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.txtSlaveAmount.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSlaveAmount.Location = New System.Drawing.Point(282, 229)
        Me.txtSlaveAmount.MaxLength = 10
        Me.txtSlaveAmount.Name = "txtSlaveAmount"
        Me.txtSlaveAmount.Size = New System.Drawing.Size(216, 32)
        Me.txtSlaveAmount.TabIndex = 28
        '
        'txtMaster
        '
        Me.txtMaster.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.txtMaster.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMaster.Location = New System.Drawing.Point(282, 22)
        Me.txtMaster.MaxLength = 20
        Me.txtMaster.Name = "txtMaster"
        Me.txtMaster.Size = New System.Drawing.Size(304, 32)
        Me.txtMaster.TabIndex = 18
        '
        'lblStatus
        '
        Me.lblStatus.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(26, 62)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(256, 32)
        Me.lblStatus.TabIndex = 19
        Me.lblStatus.Text = "Ticket Status:"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNewRem
        '
        Me.lblNewRem.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNewRem.Location = New System.Drawing.Point(26, 126)
        Me.lblNewRem.Name = "lblNewRem"
        Me.lblNewRem.Size = New System.Drawing.Size(256, 32)
        Me.lblNewRem.TabIndex = 23
        Me.lblNewRem.Text = "New Remaining Amount:"
        Me.lblNewRem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblAmount
        '
        Me.lblAmount.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmount.Location = New System.Drawing.Point(26, 229)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(248, 32)
        Me.lblAmount.TabIndex = 27
        Me.lblAmount.Text = "Amount to Transfer:"
        Me.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCurrentRem
        '
        Me.lblCurrentRem.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentRem.Location = New System.Drawing.Point(26, 94)
        Me.lblCurrentRem.Name = "lblCurrentRem"
        Me.lblCurrentRem.Size = New System.Drawing.Size(256, 32)
        Me.lblCurrentRem.TabIndex = 21
        Me.lblCurrentRem.Text = "Currently Remaining:"
        Me.lblCurrentRem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMaster
        '
        Me.lblMaster.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMaster.Location = New System.Drawing.Point(26, 22)
        Me.lblMaster.Name = "lblMaster"
        Me.lblMaster.Size = New System.Drawing.Size(256, 32)
        Me.lblMaster.TabIndex = 17
        Me.lblMaster.Text = "Scan/Enter TO Ticket:"
        Me.lblMaster.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 190)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(256, 32)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Scan/Enter FROM Ticket(s):"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnOK
        '
        Appearance15.Image = Global.StadisIntegratePlugin.My.Resources.Resources.check32
        Appearance15.ImageHAlign = Infragistics.Win.HAlign.Left
        Me.btnOK.Appearance = Appearance15
        Me.btnOK.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnOK.Location = New System.Drawing.Point(176, 469)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(112, 51)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "&Apply"
        '
        'btnCancel
        '
        Appearance16.Image = Global.StadisIntegratePlugin.My.Resources.Resources.delete32
        Appearance16.ImageHAlign = Infragistics.Win.HAlign.Left
        Me.btnCancel.Appearance = Appearance16
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnCancel.Location = New System.Drawing.Point(312, 469)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(112, 51)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "&Cancel"
        '
        'btnScrollUp
        '
        Appearance17.Image = Global.StadisIntegratePlugin.My.Resources.Resources.arrow_up_blue32
        Appearance17.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance17.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.btnScrollUp.Appearance = Appearance17
        Me.btnScrollUp.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnScrollUp.Location = New System.Drawing.Point(522, 291)
        Me.btnScrollUp.Name = "btnScrollUp"
        Me.btnScrollUp.Size = New System.Drawing.Size(64, 48)
        Me.btnScrollUp.TabIndex = 36
        '
        'btnScrollDown
        '
        Appearance18.Image = Global.StadisIntegratePlugin.My.Resources.Resources.arrow_down_blue32
        Appearance18.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance18.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.btnScrollDown.Appearance = Appearance18
        Me.btnScrollDown.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnScrollDown.Location = New System.Drawing.Point(522, 403)
        Me.btnScrollDown.Name = "btnScrollDown"
        Me.btnScrollDown.Size = New System.Drawing.Size(64, 48)
        Me.btnScrollDown.TabIndex = 37
        '
        'btnDelete
        '
        Appearance19.Image = Global.StadisIntegratePlugin.My.Resources.Resources.delete232
        Appearance19.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance19.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.btnDelete.Appearance = Appearance19
        Me.btnDelete.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnDelete.Location = New System.Drawing.Point(522, 347)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(64, 48)
        Me.btnDelete.TabIndex = 38
        '
        'frmMerge
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(605, 538)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnScrollDown)
        Me.Controls.Add(Me.btnScrollUp)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.grdTickets)
        Me.Controls.Add(Me.txtNewRemaining)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.txtCurrentRemaining)
        Me.Controls.Add(Me.txtSlave)
        Me.Controls.Add(Me.txtSlaveAmount)
        Me.Controls.Add(Me.txtMaster)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lblNewRem)
        Me.Controls.Add(Me.lblAmount)
        Me.Controls.Add(Me.lblCurrentRem)
        Me.Controls.Add(Me.lblMaster)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMerge"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "STADIS - Merge Tickets"
        CType(Me.grdTickets, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grdTickets As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents txtNewRemaining As System.Windows.Forms.Label
    Friend WithEvents txtStatus As System.Windows.Forms.Label
    Friend WithEvents txtCurrentRemaining As System.Windows.Forms.Label
    Friend WithEvents txtSlave As System.Windows.Forms.TextBox
    Friend WithEvents txtSlaveAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtMaster As System.Windows.Forms.TextBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblNewRem As System.Windows.Forms.Label
    Friend WithEvents lblAmount As System.Windows.Forms.Label
    Friend WithEvents lblCurrentRem As System.Windows.Forms.Label
    Friend WithEvents lblMaster As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnOK As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnScrollUp As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnScrollDown As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnDelete As Infragistics.Win.Misc.UltraButton
End Class
