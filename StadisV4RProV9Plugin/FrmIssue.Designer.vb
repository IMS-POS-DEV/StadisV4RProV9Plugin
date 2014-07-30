<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmIssue
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
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo2 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Leave without adding these gift cards.", Infragistics.Win.ToolTipImage.[Default], Nothing, Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo1 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Add these gift cards to the Invoice.", Infragistics.Win.ToolTipImage.[Default], Nothing, Infragistics.Win.DefaultableBoolean.[Default])
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmIssue))
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance55 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance56 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance57 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance58 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.sbStatusBar = New Infragistics.Win.UltraWinStatusBar.UltraStatusBar()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.grdGiftCards = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnOK = New Infragistics.Win.Misc.UltraButton()
        Me.DSGiftCard = New StadisV4RProV9Plugin.DSGiftCard()
        Me.DSGiftCardBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.pbLogo = New Infragistics.Win.UltraWinEditors.UltraPictureBox()
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        Me.btnGiftCard6 = New Infragistics.Win.Misc.UltraButton()
        Me.btnGiftCard5 = New Infragistics.Win.Misc.UltraButton()
        Me.btnGiftCard4 = New Infragistics.Win.Misc.UltraButton()
        Me.btnGiftCard3 = New Infragistics.Win.Misc.UltraButton()
        Me.btnGiftCard2 = New Infragistics.Win.Misc.UltraButton()
        Me.btnGiftCard1 = New Infragistics.Win.Misc.UltraButton()
        Me.cbGiftCardType = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        CType(Me.sbStatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdGiftCards, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSGiftCard, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSGiftCardBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbGiftCardType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'sbStatusBar
        '
        Appearance14.FontData.BoldAsString = "True"
        Appearance14.FontData.SizeInPoints = 10.0!
        Appearance14.ForeColor = System.Drawing.Color.Teal
        Appearance14.TextHAlignAsString = "Center"
        Me.sbStatusBar.Appearance = Appearance14
        Me.sbStatusBar.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft
        Me.sbStatusBar.Location = New System.Drawing.Point(0, 571)
        Me.sbStatusBar.Name = "sbStatusBar"
        Me.sbStatusBar.Size = New System.Drawing.Size(794, 23)
        Me.sbStatusBar.TabIndex = 13
        Me.sbStatusBar.Text = "Please scan or enter barcode"
        '
        'UltraLabel1
        '
        Appearance13.FontData.BoldAsString = "True"
        Appearance13.FontData.Name = "Arial Black"
        Appearance13.FontData.SizeInPoints = 14.0!
        Appearance13.ForeColor = System.Drawing.Color.Teal
        Appearance13.TextHAlignAsString = "Center"
        Me.UltraLabel1.Appearance = Appearance13
        Me.UltraLabel1.Location = New System.Drawing.Point(138, 19)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(518, 23)
        Me.UltraLabel1.TabIndex = 11
        Me.UltraLabel1.Text = "Issue Gift Card(s)"
        '
        'btnCancel
        '
        Appearance18.BackColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(195, Byte), Integer))
        Appearance18.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
        Appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.BackwardDiagonal
        Appearance18.FontData.BoldAsString = "True"
        Appearance18.FontData.SizeInPoints = 10.0!
        Appearance18.ForeColor = System.Drawing.Color.Teal
        Appearance18.Image = Global.StadisV4RProV9Plugin.My.Resources.Resources.delete24
        Me.btnCancel.Appearance = Appearance18
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnCancel.Location = New System.Drawing.Point(437, 507)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Padding = New System.Drawing.Size(4, 0)
        Me.btnCancel.Size = New System.Drawing.Size(103, 53)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "Cancel"
        UltraToolTipInfo2.ToolTipText = "Leave without adding these gift cards."
        Me.UltraToolTipManager1.SetUltraToolTip(Me.btnCancel, UltraToolTipInfo2)
        Me.btnCancel.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'grdGiftCards
        '
        Appearance15.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
        Appearance15.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.grdGiftCards.DisplayLayout.Appearance = Appearance15
        Me.grdGiftCards.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grdGiftCards.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance1.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance1.BorderColor = System.Drawing.SystemColors.Window
        Me.grdGiftCards.DisplayLayout.GroupByBox.Appearance = Appearance1
        Appearance2.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdGiftCards.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance2
        Me.grdGiftCards.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance16.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance16.BackColor2 = System.Drawing.SystemColors.Control
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance16.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdGiftCards.DisplayLayout.GroupByBox.PromptAppearance = Appearance16
        Me.grdGiftCards.DisplayLayout.MaxColScrollRegions = 1
        Me.grdGiftCards.DisplayLayout.MaxRowScrollRegions = 1
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Appearance12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grdGiftCards.DisplayLayout.Override.ActiveCellAppearance = Appearance12
        Appearance19.BackColor = System.Drawing.SystemColors.Highlight
        Appearance19.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdGiftCards.DisplayLayout.Override.ActiveRowAppearance = Appearance19
        Me.grdGiftCards.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.grdGiftCards.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance20.BackColor = System.Drawing.SystemColors.Window
        Me.grdGiftCards.DisplayLayout.Override.CardAreaAppearance = Appearance20
        Appearance21.BorderColor = System.Drawing.Color.Silver
        Appearance21.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.grdGiftCards.DisplayLayout.Override.CellAppearance = Appearance21
        Me.grdGiftCards.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.grdGiftCards.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.grdGiftCards.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance11.TextHAlignAsString = "Left"
        Me.grdGiftCards.DisplayLayout.Override.HeaderAppearance = Appearance11
        Me.grdGiftCards.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdGiftCards.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance10.BackColor = System.Drawing.SystemColors.Window
        Appearance10.BorderColor = System.Drawing.Color.Silver
        Me.grdGiftCards.DisplayLayout.Override.RowAppearance = Appearance10
        Me.grdGiftCards.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance22.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grdGiftCards.DisplayLayout.Override.TemplateAddRowAppearance = Appearance22
        Me.grdGiftCards.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.grdGiftCards.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.grdGiftCards.Location = New System.Drawing.Point(13, 108)
        Me.grdGiftCards.Name = "grdGiftCards"
        Me.grdGiftCards.Size = New System.Drawing.Size(770, 393)
        Me.grdGiftCards.TabIndex = 9
        Me.grdGiftCards.Text = "UltraGrid1"
        '
        'btnOK
        '
        Appearance17.BackColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(195, Byte), Integer))
        Appearance17.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
        Appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.BackwardDiagonal
        Appearance17.FontData.BoldAsString = "True"
        Appearance17.FontData.SizeInPoints = 10.0!
        Appearance17.ForeColor = System.Drawing.Color.Teal
        Appearance17.Image = Global.StadisV4RProV9Plugin.My.Resources.Resources.check24
        Me.btnOK.Appearance = Appearance17
        Me.btnOK.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnOK.Location = New System.Drawing.Point(255, 507)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Padding = New System.Drawing.Size(4, 0)
        Me.btnOK.Size = New System.Drawing.Size(103, 53)
        Me.btnOK.TabIndex = 8
        Me.btnOK.Text = "OK"
        UltraToolTipInfo1.ToolTipText = "Add these gift cards to the Invoice."
        Me.UltraToolTipManager1.SetUltraToolTip(Me.btnOK, UltraToolTipInfo1)
        Me.btnOK.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'DSGiftCard
        '
        Me.DSGiftCard.DataSetName = "DSGiftCard"
        Me.DSGiftCard.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DSGiftCardBindingSource
        '
        Me.DSGiftCardBindingSource.DataSource = Me.DSGiftCard
        Me.DSGiftCardBindingSource.Position = 0
        '
        'pbLogo
        '
        Me.pbLogo.BorderShadowColor = System.Drawing.Color.Empty
        Me.pbLogo.Image = CType(resources.GetObject("pbLogo.Image"), Object)
        Me.pbLogo.Location = New System.Drawing.Point(4, -5)
        Me.pbLogo.Name = "pbLogo"
        Me.pbLogo.ScaleImage = Infragistics.Win.ScaleImage.Always
        Me.pbLogo.Size = New System.Drawing.Size(111, 63)
        Me.pbLogo.TabIndex = 12
        '
        'UltraToolTipManager1
        '
        Me.UltraToolTipManager1.ContainingControl = Me
        '
        'btnGiftCard6
        '
        Appearance5.BackColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(195, Byte), Integer))
        Appearance5.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.BackwardDiagonal
        Appearance5.FontData.BoldAsString = "True"
        Appearance5.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.btnGiftCard6.Appearance = Appearance5
        Me.btnGiftCard6.Enabled = False
        Me.btnGiftCard6.Location = New System.Drawing.Point(659, 62)
        Me.btnGiftCard6.Name = "btnGiftCard6"
        Me.btnGiftCard6.Size = New System.Drawing.Size(122, 40)
        Me.btnGiftCard6.TabIndex = 19
        Me.btnGiftCard6.Text = "btnGiftCard6"
        Me.btnGiftCard6.Visible = False
        '
        'btnGiftCard5
        '
        Appearance54.BackColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(195, Byte), Integer))
        Appearance54.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
        Appearance54.BackGradientStyle = Infragistics.Win.GradientStyle.BackwardDiagonal
        Appearance54.FontData.BoldAsString = "True"
        Appearance54.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.btnGiftCard5.Appearance = Appearance54
        Me.btnGiftCard5.Enabled = False
        Me.btnGiftCard5.Location = New System.Drawing.Point(530, 62)
        Me.btnGiftCard5.Name = "btnGiftCard5"
        Me.btnGiftCard5.Size = New System.Drawing.Size(122, 40)
        Me.btnGiftCard5.TabIndex = 18
        Me.btnGiftCard5.Text = "btnGiftCard5"
        Me.btnGiftCard5.Visible = False
        '
        'btnGiftCard4
        '
        Appearance55.BackColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(195, Byte), Integer))
        Appearance55.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
        Appearance55.BackGradientStyle = Infragistics.Win.GradientStyle.BackwardDiagonal
        Appearance55.FontData.BoldAsString = "True"
        Appearance55.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.btnGiftCard4.Appearance = Appearance55
        Me.btnGiftCard4.Enabled = False
        Me.btnGiftCard4.Location = New System.Drawing.Point(401, 62)
        Me.btnGiftCard4.Name = "btnGiftCard4"
        Me.btnGiftCard4.Size = New System.Drawing.Size(122, 40)
        Me.btnGiftCard4.TabIndex = 17
        Me.btnGiftCard4.Text = "btnGiftCard4"
        Me.btnGiftCard4.Visible = False
        '
        'btnGiftCard3
        '
        Appearance56.BackColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(195, Byte), Integer))
        Appearance56.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
        Appearance56.BackGradientStyle = Infragistics.Win.GradientStyle.BackwardDiagonal
        Appearance56.FontData.BoldAsString = "True"
        Appearance56.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.btnGiftCard3.Appearance = Appearance56
        Me.btnGiftCard3.Enabled = False
        Me.btnGiftCard3.Location = New System.Drawing.Point(272, 62)
        Me.btnGiftCard3.Name = "btnGiftCard3"
        Me.btnGiftCard3.Size = New System.Drawing.Size(122, 40)
        Me.btnGiftCard3.TabIndex = 16
        Me.btnGiftCard3.Text = "btnGiftCard3"
        Me.btnGiftCard3.Visible = False
        '
        'btnGiftCard2
        '
        Appearance57.BackColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(195, Byte), Integer))
        Appearance57.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
        Appearance57.BackGradientStyle = Infragistics.Win.GradientStyle.BackwardDiagonal
        Appearance57.FontData.BoldAsString = "True"
        Appearance57.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.btnGiftCard2.Appearance = Appearance57
        Me.btnGiftCard2.Enabled = False
        Me.btnGiftCard2.Location = New System.Drawing.Point(143, 62)
        Me.btnGiftCard2.Name = "btnGiftCard2"
        Me.btnGiftCard2.Size = New System.Drawing.Size(122, 40)
        Me.btnGiftCard2.TabIndex = 15
        Me.btnGiftCard2.Text = "btnGiftCard2"
        Me.btnGiftCard2.Visible = False
        '
        'btnGiftCard1
        '
        Appearance58.BackColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(195, Byte), Integer))
        Appearance58.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
        Appearance58.BackGradientStyle = Infragistics.Win.GradientStyle.BackwardDiagonal
        Appearance58.FontData.BoldAsString = "True"
        Appearance58.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.btnGiftCard1.Appearance = Appearance58
        Me.btnGiftCard1.Enabled = False
        Me.btnGiftCard1.Location = New System.Drawing.Point(14, 62)
        Me.btnGiftCard1.Name = "btnGiftCard1"
        Me.btnGiftCard1.Size = New System.Drawing.Size(122, 40)
        Me.btnGiftCard1.TabIndex = 14
        Me.btnGiftCard1.Text = "btnGiftCard1"
        Me.btnGiftCard1.Visible = False
        '
        'cbGiftCardType
        '
        Appearance3.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(235, Byte), Integer))
        Appearance3.FontData.BoldAsString = "True"
        Appearance3.FontData.SizeInPoints = 14.0!
        Me.cbGiftCardType.Appearance = Appearance3
        Me.cbGiftCardType.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cbGiftCardType.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Appearance4.ForeColor = System.Drawing.Color.Teal
        Me.cbGiftCardType.ItemAppearance = Appearance4
        Me.cbGiftCardType.Location = New System.Drawing.Point(81, 382)
        Me.cbGiftCardType.MaxDropDownItems = 6
        Me.cbGiftCardType.Name = "cbGiftCardType"
        Me.cbGiftCardType.Size = New System.Drawing.Size(120, 31)
        Me.cbGiftCardType.TabIndex = 21
        '
        'FrmIssue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(794, 594)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnGiftCard6)
        Me.Controls.Add(Me.btnGiftCard5)
        Me.Controls.Add(Me.btnGiftCard4)
        Me.Controls.Add(Me.btnGiftCard3)
        Me.Controls.Add(Me.btnGiftCard2)
        Me.Controls.Add(Me.btnGiftCard1)
        Me.Controls.Add(Me.sbStatusBar)
        Me.Controls.Add(Me.UltraLabel1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.grdGiftCards)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.pbLogo)
        Me.Controls.Add(Me.cbGiftCardType)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FrmIssue"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        CType(Me.sbStatusBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdGiftCards, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSGiftCard, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSGiftCardBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbGiftCardType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents sbStatusBar As Infragistics.Win.UltraWinStatusBar.UltraStatusBar
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents grdGiftCards As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnOK As Infragistics.Win.Misc.UltraButton
    Friend WithEvents pbLogo As Infragistics.Win.UltraWinEditors.UltraPictureBox
    Friend WithEvents DSGiftCard As StadisV4RProV9Plugin.DSGiftCard
    Friend WithEvents DSGiftCardBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
    Friend WithEvents btnGiftCard6 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnGiftCard5 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnGiftCard4 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnGiftCard3 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnGiftCard2 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnGiftCard1 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cbGiftCardType As Infragistics.Win.UltraWinEditors.UltraComboEditor
End Class
