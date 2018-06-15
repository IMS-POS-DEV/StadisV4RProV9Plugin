<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmScanTicket
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnOK = New Infragistics.Win.Misc.UltraButton()
        Me.txtCustomerID = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblCaption = New Infragistics.Win.Misc.UltraLabel()
        CType(Me.txtCustomerID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Appearance1.FontData.BoldAsString = "True"
        Appearance1.FontData.SizeInPoints = 10.0!
        Appearance1.ForeColor = System.Drawing.Color.Teal
        Appearance1.Image = Global.StadisV4RProV9Plugin.My.Resources.Resources.delete24
        Me.btnCancel.Appearance = Appearance1
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnCancel.Location = New System.Drawing.Point(214, 137)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Padding = New System.Drawing.Size(4, 0)
        Me.btnCancel.Size = New System.Drawing.Size(103, 53)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseOsThemes = Infragistics.Win.DefaultableBoolean.[True]
        '
        'btnOK
        '
        Appearance2.FontData.BoldAsString = "True"
        Appearance2.FontData.SizeInPoints = 10.0!
        Appearance2.ForeColor = System.Drawing.Color.Teal
        Appearance2.Image = Global.StadisV4RProV9Plugin.My.Resources.Resources.check24
        Me.btnOK.Appearance = Appearance2
        Me.btnOK.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnOK.Location = New System.Drawing.Point(64, 137)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Padding = New System.Drawing.Size(4, 0)
        Me.btnOK.Size = New System.Drawing.Size(103, 53)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        Me.btnOK.UseOsThemes = Infragistics.Win.DefaultableBoolean.[True]
        '
        'txtCustomerID
        '
        Appearance3.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(235, Byte), Integer))
        Appearance3.FontData.BoldAsString = "True"
        Appearance3.FontData.SizeInPoints = 14.0!
        Appearance3.TextHAlignAsString = "Left"
        Me.txtCustomerID.Appearance = Appearance3
        Me.txtCustomerID.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.txtCustomerID.Location = New System.Drawing.Point(23, 75)
        Me.txtCustomerID.Name = "txtCustomerID"
        Me.txtCustomerID.Size = New System.Drawing.Size(331, 31)
        Me.txtCustomerID.TabIndex = 0
        '
        'lblCaption
        '
        Appearance4.FontData.BoldAsString = "True"
        Appearance4.FontData.Name = "Arial Black"
        Appearance4.FontData.SizeInPoints = 12.0!
        Appearance4.ForeColor = System.Drawing.Color.Teal
        Appearance4.TextHAlignAsString = "Center"
        Me.lblCaption.Appearance = Appearance4
        Me.lblCaption.Location = New System.Drawing.Point(16, 29)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(348, 23)
        Me.lblCaption.TabIndex = 6
        Me.lblCaption.Text = "Your caption here!"
        '
        'FrmScanTicket
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(380, 223)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblCaption)
        Me.Controls.Add(Me.txtCustomerID)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FrmScanTicket"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        CType(Me.txtCustomerID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Private WithEvents btnOK As Infragistics.Win.Misc.UltraButton
    Private WithEvents txtCustomerID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Private WithEvents lblCaption As Infragistics.Win.Misc.UltraLabel
End Class
