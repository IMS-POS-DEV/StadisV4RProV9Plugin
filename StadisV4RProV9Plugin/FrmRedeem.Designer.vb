<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRedeem
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo3 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Process these tenders and charge Stadis account.", Infragistics.Win.ToolTipImage.[Default], Nothing, Infragistics.Win.DefaultableBoolean.[Default])
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
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo1 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Leave without processing.", Infragistics.Win.ToolTipImage.[Default], Nothing, Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo2 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Amount to be paid on the Invoice.", Infragistics.Win.ToolTipImage.[Default], Nothing, Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRedeem))
        Me.btnOK = New Infragistics.Win.Misc.UltraButton()
        Me.grdTenders = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.sbStatusBar = New Infragistics.Win.UltraWinStatusBar.UltraStatusBar()
        Me.lblRemainingAmount = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        Me.dsTenderBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSTender = New StadisV4RProV9Plugin.DSTender()
        Me.pbLogo = New Infragistics.Win.UltraWinEditors.UltraPictureBox()
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        CType(Me.grdTenders, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sbStatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsTenderBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSTender, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Appearance1.FontData.BoldAsString = "True"
        Appearance1.FontData.SizeInPoints = 10.0!
        Appearance1.ForeColor = System.Drawing.Color.Teal
        Appearance1.Image = Global.StadisV4RProV9Plugin.My.Resources.Resources.check24
        Me.btnOK.Appearance = Appearance1
        Me.btnOK.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnOK.Location = New System.Drawing.Point(230, 477)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Padding = New System.Drawing.Size(4, 0)
        Me.btnOK.Size = New System.Drawing.Size(103, 53)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "OK"
        UltraToolTipInfo3.ToolTipText = "Process these tenders and charge Stadis account."
        Me.UltraToolTipManager1.SetUltraToolTip(Me.btnOK, UltraToolTipInfo3)
        Me.btnOK.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'grdTenders
        '
        Appearance5.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
        Appearance5.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.grdTenders.DisplayLayout.Appearance = Appearance5
        Me.grdTenders.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grdTenders.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance6.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance6.BorderColor = System.Drawing.SystemColors.Window
        Me.grdTenders.DisplayLayout.GroupByBox.Appearance = Appearance6
        Appearance7.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdTenders.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance7
        Me.grdTenders.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance8.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance8.BackColor2 = System.Drawing.SystemColors.Control
        Appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance8.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdTenders.DisplayLayout.GroupByBox.PromptAppearance = Appearance8
        Me.grdTenders.DisplayLayout.MaxColScrollRegions = 1
        Me.grdTenders.DisplayLayout.MaxRowScrollRegions = 1
        Appearance9.BackColor = System.Drawing.SystemColors.Window
        Appearance9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grdTenders.DisplayLayout.Override.ActiveCellAppearance = Appearance9
        Appearance10.BackColor = System.Drawing.SystemColors.Highlight
        Appearance10.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdTenders.DisplayLayout.Override.ActiveRowAppearance = Appearance10
        Me.grdTenders.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.grdTenders.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Me.grdTenders.DisplayLayout.Override.CardAreaAppearance = Appearance11
        Appearance12.BorderColor = System.Drawing.Color.Silver
        Appearance12.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.grdTenders.DisplayLayout.Override.CellAppearance = Appearance12
        Me.grdTenders.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.grdTenders.DisplayLayout.Override.CellPadding = 0
        Appearance13.BackColor = System.Drawing.SystemColors.Control
        Appearance13.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance13.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance13.BorderColor = System.Drawing.SystemColors.Window
        Me.grdTenders.DisplayLayout.Override.GroupByRowAppearance = Appearance13
        Appearance14.TextHAlignAsString = "Left"
        Me.grdTenders.DisplayLayout.Override.HeaderAppearance = Appearance14
        Me.grdTenders.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdTenders.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance15.BackColor = System.Drawing.SystemColors.Window
        Appearance15.BorderColor = System.Drawing.Color.Silver
        Me.grdTenders.DisplayLayout.Override.RowAppearance = Appearance15
        Me.grdTenders.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance16.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grdTenders.DisplayLayout.Override.TemplateAddRowAppearance = Appearance16
        Me.grdTenders.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.grdTenders.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.grdTenders.Location = New System.Drawing.Point(13, 78)
        Me.grdTenders.Name = "grdTenders"
        Me.grdTenders.Size = New System.Drawing.Size(718, 393)
        Me.grdTenders.TabIndex = 1
        Me.grdTenders.Text = "UltraGrid1"
        '
        'btnCancel
        '
        Appearance2.FontData.BoldAsString = "True"
        Appearance2.FontData.SizeInPoints = 10.0!
        Appearance2.ForeColor = System.Drawing.Color.Teal
        Appearance2.Image = Global.StadisV4RProV9Plugin.My.Resources.Resources.delete24
        Me.btnCancel.Appearance = Appearance2
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnCancel.Location = New System.Drawing.Point(412, 477)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Padding = New System.Drawing.Size(4, 0)
        Me.btnCancel.Size = New System.Drawing.Size(103, 53)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        UltraToolTipInfo1.ToolTipText = "Leave without processing."
        Me.UltraToolTipManager1.SetUltraToolTip(Me.btnCancel, UltraToolTipInfo1)
        Me.btnCancel.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'UltraLabel1
        '
        Appearance4.FontData.BoldAsString = "True"
        Appearance4.FontData.Name = "Arial Black"
        Appearance4.FontData.SizeInPoints = 14.0!
        Appearance4.ForeColor = System.Drawing.Color.Teal
        Appearance4.TextHAlignAsString = "Center"
        Me.UltraLabel1.Appearance = Appearance4
        Me.UltraLabel1.Location = New System.Drawing.Point(148, 14)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(448, 23)
        Me.UltraLabel1.TabIndex = 3
        Me.UltraLabel1.Text = "Redeem Gift Card / STADIS"
        '
        'sbStatusBar
        '
        Appearance3.FontData.BoldAsString = "True"
        Appearance3.FontData.SizeInPoints = 10.0!
        Appearance3.ForeColor = System.Drawing.Color.Teal
        Appearance3.TextHAlignAsString = "Center"
        Me.sbStatusBar.Appearance = Appearance3
        Me.sbStatusBar.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft
        Me.sbStatusBar.Location = New System.Drawing.Point(0, 543)
        Me.sbStatusBar.Name = "sbStatusBar"
        Me.sbStatusBar.Size = New System.Drawing.Size(744, 23)
        Me.sbStatusBar.TabIndex = 5
        Me.sbStatusBar.Text = "Please scan or enter barcode"
        '
        'lblRemainingAmount
        '
        Appearance18.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(235, Byte), Integer))
        Appearance18.FontData.BoldAsString = "True"
        Appearance18.FontData.Name = "Arial"
        Appearance18.FontData.SizeInPoints = 16.0!
        Appearance18.ForeColor = System.Drawing.Color.Teal
        Appearance18.TextHAlignAsString = "Right"
        Appearance18.TextVAlignAsString = "Bottom"
        Me.lblRemainingAmount.Appearance = Appearance18
        Me.lblRemainingAmount.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.InsetSoft
        Me.lblRemainingAmount.Location = New System.Drawing.Point(612, 38)
        Me.lblRemainingAmount.Name = "lblRemainingAmount"
        Me.lblRemainingAmount.Padding = New System.Drawing.Size(4, 0)
        Me.lblRemainingAmount.Size = New System.Drawing.Size(117, 40)
        Me.lblRemainingAmount.TabIndex = 6
        Me.lblRemainingAmount.Text = "$0,000.00"
        UltraToolTipInfo2.ToolTipText = "Amount to be paid on the Invoice."
        Me.UltraToolTipManager1.SetUltraToolTip(Me.lblRemainingAmount, UltraToolTipInfo2)
        '
        'UltraLabel3
        '
        Appearance17.FontData.BoldAsString = "True"
        Appearance17.FontData.ItalicAsString = "True"
        Appearance17.FontData.Name = "Arial"
        Appearance17.FontData.SizeInPoints = 12.0!
        Appearance17.ForeColor = System.Drawing.Color.Teal
        Appearance17.TextHAlignAsString = "Right"
        Me.UltraLabel3.Appearance = Appearance17
        Me.UltraLabel3.Location = New System.Drawing.Point(449, 55)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(161, 23)
        Me.UltraLabel3.TabIndex = 7
        Me.UltraLabel3.Text = "Amount Due  >>>"
        '
        'dsTenderBindingSource
        '
        Me.dsTenderBindingSource.DataSource = Me.DSTender
        Me.dsTenderBindingSource.Position = 0
        '
        'DSTender
        '
        Me.DSTender.DataSetName = "DSTender"
        Me.DSTender.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'pbLogo
        '
        Me.pbLogo.BorderShadowColor = System.Drawing.Color.Empty
        Me.pbLogo.Image = CType(resources.GetObject("pbLogo.Image"), Object)
        Me.pbLogo.ImageTransparentColor = System.Drawing.Color.White
        Me.pbLogo.Location = New System.Drawing.Point(7, 10)
        Me.pbLogo.Name = "pbLogo"
        Me.pbLogo.ScaleImage = Infragistics.Win.ScaleImage.Always
        Me.pbLogo.Size = New System.Drawing.Size(110, 66)
        Me.pbLogo.TabIndex = 4
        '
        'UltraToolTipManager1
        '
        Me.UltraToolTipManager1.ContainingControl = Me
        '
        'FrmRedeem
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(744, 566)
        Me.ControlBox = False
        Me.Controls.Add(Me.sbStatusBar)
        Me.Controls.Add(Me.UltraLabel1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.grdTenders)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.pbLogo)
        Me.Controls.Add(Me.UltraLabel3)
        Me.Controls.Add(Me.lblRemainingAmount)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FrmRedeem"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        CType(Me.grdTenders, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sbStatusBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsTenderBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSTender, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOK As Infragistics.Win.Misc.UltraButton
    Friend WithEvents grdTenders As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents pbLogo As Infragistics.Win.UltraWinEditors.UltraPictureBox
    Friend WithEvents dsTenderBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DSTender As StadisV4RProV9Plugin.DSTender
    Friend WithEvents sbStatusBar As Infragistics.Win.UltraWinStatusBar.UltraStatusBar
    Friend WithEvents lblRemainingAmount As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
End Class
