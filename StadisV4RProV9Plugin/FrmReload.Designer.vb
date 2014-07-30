<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReload
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
        Me.components = New System.ComponentModel.Container
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraToolTipInfo6 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Leave without processing.", Infragistics.Win.ToolTipImage.[Default], Nothing, Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraToolTipInfo5 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Add this item to the Receipt.", Infragistics.Win.ToolTipImage.[Default], Nothing, Infragistics.Win.DefaultableBoolean.[Default])
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReload))
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraToolTipInfo4 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Scan or enter number of gift card that is being reloaded.", Infragistics.Win.ToolTipImage.[Default], Nothing, Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraToolTipInfo3 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Funds currently available on the above gift card.", Infragistics.Win.ToolTipImage.[Default], Nothing, Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraToolTipInfo2 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Amount being added to the gift card.", Infragistics.Win.ToolTipImage.[Default], Nothing, Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraToolTipInfo1 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Funds available on the gift card after the reload.", Infragistics.Win.ToolTipImage.[Default], Nothing, Infragistics.Win.DefaultableBoolean.[Default])
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton
        Me.btnOK = New Infragistics.Win.Misc.UltraButton
        Me.pbLogo = New Infragistics.Win.UltraWinEditors.UltraPictureBox
        Me.txtGiftCardID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel
        Me.txtCurrentBalance = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel
        Me.txtAmount = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel
        Me.txtBalanceAfter = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        CType(Me.txtGiftCardID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCurrentBalance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBalanceAfter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraLabel1
        '
        Appearance7.FontData.BoldAsString = "True"
        Appearance7.FontData.Name = "Arial Black"
        Appearance7.FontData.SizeInPoints = 14.0!
        Appearance7.ForeColor = System.Drawing.Color.Teal
        Appearance7.TextHAlignAsString = "Center"
        Me.UltraLabel1.Appearance = Appearance7
        Me.UltraLabel1.Location = New System.Drawing.Point(175, 19)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(279, 23)
        Me.UltraLabel1.TabIndex = 15
        Me.UltraLabel1.Text = "Reload Gift Card"
        '
        'btnCancel
        '
        Appearance18.FontData.BoldAsString = "True"
        Appearance18.FontData.SizeInPoints = 10.0!
        Appearance18.ForeColor = System.Drawing.Color.Teal
        Appearance18.Image = Global.StadisV4RProV9Plugin.My.Resources.Resources.delete24
        Me.btnCancel.Appearance = Appearance18
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnCancel.Location = New System.Drawing.Point(354, 306)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Padding = New System.Drawing.Size(4, 0)
        Me.btnCancel.Size = New System.Drawing.Size(103, 53)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        UltraToolTipInfo6.ToolTipText = "Leave without processing."
        Me.UltraToolTipManager1.SetUltraToolTip(Me.btnCancel, UltraToolTipInfo6)
        Me.btnCancel.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'btnOK
        '
        Appearance17.FontData.BoldAsString = "True"
        Appearance17.FontData.SizeInPoints = 10.0!
        Appearance17.ForeColor = System.Drawing.Color.Teal
        Appearance17.Image = Global.StadisV4RProV9Plugin.My.Resources.Resources.check24
        Me.btnOK.Appearance = Appearance17
        Me.btnOK.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnOK.Location = New System.Drawing.Point(172, 306)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Padding = New System.Drawing.Size(4, 0)
        Me.btnOK.Size = New System.Drawing.Size(103, 53)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        UltraToolTipInfo5.ToolTipText = "Add this item to the Receipt."
        Me.UltraToolTipManager1.SetUltraToolTip(Me.btnOK, UltraToolTipInfo5)
        Me.btnOK.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'pbLogo
        '
        Me.pbLogo.BorderShadowColor = System.Drawing.Color.Empty
        Me.pbLogo.Image = CType(resources.GetObject("pbLogo.Image"), Object)
        Me.pbLogo.Location = New System.Drawing.Point(4, -2)
        Me.pbLogo.Name = "pbLogo"
        Me.pbLogo.ScaleImage = Infragistics.Win.ScaleImage.Always
        Me.pbLogo.Size = New System.Drawing.Size(111, 63)
        Me.pbLogo.TabIndex = 16
        '
        'txtGiftCardID
        '
        Appearance8.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(235, Byte), Integer))
        Appearance8.FontData.BoldAsString = "True"
        Appearance8.FontData.SizeInPoints = 14.0!
        Appearance8.ForeColor = System.Drawing.Color.Black
        Me.txtGiftCardID.Appearance = Appearance8
        Me.txtGiftCardID.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.txtGiftCardID.Location = New System.Drawing.Point(247, 88)
        Me.txtGiftCardID.Name = "txtGiftCardID"
        Me.txtGiftCardID.Size = New System.Drawing.Size(331, 31)
        Me.txtGiftCardID.TabIndex = 0
        UltraToolTipInfo4.ToolTipText = "Scan or enter number of gift card that is being reloaded."
        Me.UltraToolTipManager1.SetUltraToolTip(Me.txtGiftCardID, UltraToolTipInfo4)
        '
        'UltraLabel2
        '
        Appearance9.FontData.BoldAsString = "False"
        Appearance9.FontData.Name = "Arial Black"
        Appearance9.FontData.SizeInPoints = 12.0!
        Appearance9.ForeColor = System.Drawing.Color.Teal
        Appearance9.TextHAlignAsString = "Right"
        Me.UltraLabel2.Appearance = Appearance9
        Me.UltraLabel2.Location = New System.Drawing.Point(23, 93)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(218, 23)
        Me.UltraLabel2.TabIndex = 19
        Me.UltraLabel2.Text = "Scan or Enter Ticket:"
        '
        'UltraLabel3
        '
        Appearance10.FontData.BoldAsString = "False"
        Appearance10.FontData.Name = "Arial Black"
        Appearance10.FontData.SizeInPoints = 12.0!
        Appearance10.ForeColor = System.Drawing.Color.Teal
        Appearance10.TextHAlignAsString = "Right"
        Me.UltraLabel3.Appearance = Appearance10
        Me.UltraLabel3.Location = New System.Drawing.Point(23, 138)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(218, 23)
        Me.UltraLabel3.TabIndex = 21
        Me.UltraLabel3.Text = "Current Balance:"
        '
        'txtCurrentBalance
        '
        Appearance6.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(235, Byte), Integer))
        Appearance6.FontData.BoldAsString = "True"
        Appearance6.FontData.SizeInPoints = 14.0!
        Appearance6.ForeColor = System.Drawing.Color.Teal
        Appearance6.TextHAlignAsString = "Right"
        Me.txtCurrentBalance.Appearance = Appearance6
        Me.txtCurrentBalance.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.txtCurrentBalance.Location = New System.Drawing.Point(247, 133)
        Me.txtCurrentBalance.Name = "txtCurrentBalance"
        Me.txtCurrentBalance.ReadOnly = True
        Me.txtCurrentBalance.Size = New System.Drawing.Size(156, 31)
        Me.txtCurrentBalance.TabIndex = 1
        Me.txtCurrentBalance.TabStop = False
        UltraToolTipInfo3.ToolTipText = "Funds currently available on the above gift card."
        Me.UltraToolTipManager1.SetUltraToolTip(Me.txtCurrentBalance, UltraToolTipInfo3)
        '
        'UltraLabel4
        '
        Appearance11.FontData.BoldAsString = "False"
        Appearance11.FontData.Name = "Arial Black"
        Appearance11.FontData.SizeInPoints = 12.0!
        Appearance11.ForeColor = System.Drawing.Color.Teal
        Appearance11.TextHAlignAsString = "Right"
        Me.UltraLabel4.Appearance = Appearance11
        Me.UltraLabel4.Location = New System.Drawing.Point(23, 183)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(218, 23)
        Me.UltraLabel4.TabIndex = 23
        Me.UltraLabel4.Text = "Amount to Add:"
        '
        'txtAmount
        '
        Appearance5.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(235, Byte), Integer))
        Appearance5.FontData.BoldAsString = "True"
        Appearance5.FontData.SizeInPoints = 14.0!
        Appearance5.ForeColor = System.Drawing.Color.Black
        Appearance5.TextHAlignAsString = "Right"
        Me.txtAmount.Appearance = Appearance5
        Me.txtAmount.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.txtAmount.Location = New System.Drawing.Point(247, 178)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(156, 31)
        Me.txtAmount.TabIndex = 1
        UltraToolTipInfo2.ToolTipText = "Amount being added to the gift card."
        Me.UltraToolTipManager1.SetUltraToolTip(Me.txtAmount, UltraToolTipInfo2)
        '
        'UltraLabel5
        '
        Appearance13.FontData.BoldAsString = "False"
        Appearance13.FontData.Name = "Arial Black"
        Appearance13.FontData.SizeInPoints = 12.0!
        Appearance13.ForeColor = System.Drawing.Color.Teal
        Appearance13.TextHAlignAsString = "Right"
        Me.UltraLabel5.Appearance = Appearance13
        Me.UltraLabel5.Location = New System.Drawing.Point(23, 228)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(218, 23)
        Me.UltraLabel5.TabIndex = 25
        Me.UltraLabel5.Text = "Balance After Reload:"
        '
        'txtBalanceAfter
        '
        Appearance2.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(235, Byte), Integer))
        Appearance2.FontData.BoldAsString = "True"
        Appearance2.FontData.SizeInPoints = 14.0!
        Appearance2.ForeColor = System.Drawing.Color.Teal
        Appearance2.TextHAlignAsString = "Right"
        Me.txtBalanceAfter.Appearance = Appearance2
        Me.txtBalanceAfter.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.txtBalanceAfter.Location = New System.Drawing.Point(247, 223)
        Me.txtBalanceAfter.Name = "txtBalanceAfter"
        Me.txtBalanceAfter.ReadOnly = True
        Me.txtBalanceAfter.Size = New System.Drawing.Size(156, 31)
        Me.txtBalanceAfter.TabIndex = 3
        Me.txtBalanceAfter.TabStop = False
        UltraToolTipInfo1.ToolTipText = "Funds available on the gift card after the reload."
        Me.UltraToolTipManager1.SetUltraToolTip(Me.txtBalanceAfter, UltraToolTipInfo1)
        '
        'UltraToolTipManager1
        '
        Me.UltraToolTipManager1.ContainingControl = Me
        '
        'FrmReload
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(628, 397)
        Me.ControlBox = False
        Me.Controls.Add(Me.UltraLabel5)
        Me.Controls.Add(Me.txtBalanceAfter)
        Me.Controls.Add(Me.UltraLabel4)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.UltraLabel3)
        Me.Controls.Add(Me.txtCurrentBalance)
        Me.Controls.Add(Me.UltraLabel2)
        Me.Controls.Add(Me.txtGiftCardID)
        Me.Controls.Add(Me.UltraLabel1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.pbLogo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FrmReload"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        CType(Me.txtGiftCardID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCurrentBalance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBalanceAfter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnOK As Infragistics.Win.Misc.UltraButton
    Friend WithEvents pbLogo As Infragistics.Win.UltraWinEditors.UltraPictureBox
    Friend WithEvents txtGiftCardID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtCurrentBalance As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtAmount As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtBalanceAfter As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
End Class
