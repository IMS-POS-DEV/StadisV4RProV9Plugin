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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMerge))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TicketBarcode")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Amount")
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.btnApply = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.grdTickets = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.btnScrollDown = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnScrollUp = New System.Windows.Forms.Button
        Me.txtNewRemaining = New System.Windows.Forms.Label
        Me.txtStatus = New System.Windows.Forms.Label
        Me.txtCurrentRemaining = New System.Windows.Forms.Label
        Me.txtSlave = New System.Windows.Forms.TextBox
        Me.txtSlaveAmount = New System.Windows.Forms.TextBox
        Me.txtMaster = New System.Windows.Forms.TextBox
        Me.lblStatus = New System.Windows.Forms.Label
        Me.lblNewRem = New System.Windows.Forms.Label
        Me.lblAmount = New System.Windows.Forms.Label
        Me.lblCurrentRem = New System.Windows.Forms.Label
        Me.lblMaster = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.grdTickets, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnApply
        '
        Me.btnApply.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnApply.Image = CType(resources.GetObject("btnApply.Image"), System.Drawing.Image)
        Me.btnApply.Location = New System.Drawing.Point(176, 469)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(112, 51)
        Me.btnApply.TabIndex = 1
        Me.btnApply.Text = "&Apply"
        Me.btnApply.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnApply.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.Location = New System.Drawing.Point(312, 469)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(112, 51)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'grdTickets
        '
        Appearance1.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.grdTickets.DisplayLayout.Appearance = Appearance1
        UltraGridColumn1.Header.Caption = "Barcode"
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Width = 336
        Appearance13.TextHAlignAsString = "Right"
        UltraGridColumn2.CellAppearance = Appearance13
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Width = 158
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2})
        Me.grdTickets.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.grdTickets.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grdTickets.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.grdTickets.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdTickets.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.grdTickets.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grdTickets.DisplayLayout.GroupByBox.Hidden = True
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdTickets.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.grdTickets.DisplayLayout.MaxColScrollRegions = 1
        Me.grdTickets.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grdTickets.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdTickets.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.grdTickets.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.grdTickets.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
        Me.grdTickets.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None
        Me.grdTickets.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed
        Me.grdTickets.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdTickets.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdTickets.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdTickets.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.grdTickets.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.grdTickets.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.FontData.BoldAsString = "True"
        Appearance8.FontData.Name = "Arial"
        Appearance8.FontData.SizeInPoints = 16.0!
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.grdTickets.DisplayLayout.Override.CellAppearance = Appearance8
        Me.grdTickets.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.grdTickets.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.grdTickets.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.BackColor = System.Drawing.Color.LightSeaGreen
        Appearance10.BackColor2 = System.Drawing.Color.Teal
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance10.FontData.BoldAsString = "True"
        Appearance10.FontData.Name = "Arial"
        Appearance10.FontData.SizeInPoints = 12.0!
        Appearance10.ForeColor = System.Drawing.Color.White
        Appearance10.TextHAlignAsString = "Left"
        Me.grdTickets.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.grdTickets.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdTickets.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Me.grdTickets.DisplayLayout.Override.MaxSelectedCells = 1
        Me.grdTickets.DisplayLayout.Override.MaxSelectedRows = 1
        Appearance14.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.grdTickets.DisplayLayout.Override.RowAlternateAppearance = Appearance14
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.grdTickets.DisplayLayout.Override.RowAppearance = Appearance11
        Me.grdTickets.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grdTickets.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
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
        'btnScrollDown
        '
        Me.btnScrollDown.Image = CType(resources.GetObject("btnScrollDown.Image"), System.Drawing.Image)
        Me.btnScrollDown.Location = New System.Drawing.Point(522, 403)
        Me.btnScrollDown.Name = "btnScrollDown"
        Me.btnScrollDown.Size = New System.Drawing.Size(64, 48)
        Me.btnScrollDown.TabIndex = 31
        Me.btnScrollDown.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.Location = New System.Drawing.Point(522, 347)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(64, 48)
        Me.btnDelete.TabIndex = 30
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnScrollUp
        '
        Me.btnScrollUp.Image = CType(resources.GetObject("btnScrollUp.Image"), System.Drawing.Image)
        Me.btnScrollUp.Location = New System.Drawing.Point(522, 291)
        Me.btnScrollUp.Name = "btnScrollUp"
        Me.btnScrollUp.Size = New System.Drawing.Size(64, 48)
        Me.btnScrollUp.TabIndex = 29
        Me.btnScrollUp.UseVisualStyleBackColor = True
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
        'frmMerge
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(605, 538)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.grdTickets)
        Me.Controls.Add(Me.btnScrollDown)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnScrollUp)
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
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnApply)
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
    Friend WithEvents btnApply As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents grdTickets As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnScrollDown As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnScrollUp As System.Windows.Forms.Button
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
End Class
