<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAbout
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAbout))
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.lblHAVer = New Infragistics.Win.Misc.UltraLabel
        Me.UltraPictureBox1 = New Infragistics.Win.UltraWinEditors.UltraPictureBox
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.lblHAWarning = New Infragistics.Win.Misc.UltraLabel
        Me.btnHAOK = New Infragistics.Win.Misc.UltraButton
        Me.UltraPictureBox3 = New Infragistics.Win.UltraWinEditors.UltraPictureBox
        Me.SuspendLayout()
        '
        'lblHAVer
        '
        Appearance1.ForeColor = System.Drawing.Color.MidnightBlue
        Appearance1.TextHAlignAsString = "Right"
        Me.lblHAVer.Appearance = Appearance1
        Me.lblHAVer.BackColorInternal = System.Drawing.Color.Transparent
        Me.lblHAVer.Location = New System.Drawing.Point(122, 116)
        Me.lblHAVer.Name = "lblHAVer"
        Me.lblHAVer.Size = New System.Drawing.Size(202, 16)
        Me.lblHAVer.TabIndex = 17
        Me.lblHAVer.Text = "0.0.0"
        '
        'UltraPictureBox1
        '
        Me.UltraPictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.UltraPictureBox1.BorderShadowColor = System.Drawing.Color.Empty
        Me.UltraPictureBox1.Image = CType(resources.GetObject("UltraPictureBox1.Image"), Object)
        Me.UltraPictureBox1.ImageTransparentColor = System.Drawing.Color.White
        Me.UltraPictureBox1.Location = New System.Drawing.Point(12, 6)
        Me.UltraPictureBox1.Name = "UltraPictureBox1"
        Me.UltraPictureBox1.ScaleImage = Infragistics.Win.ScaleImage.Always
        Me.UltraPictureBox1.Size = New System.Drawing.Size(99, 99)
        Me.UltraPictureBox1.TabIndex = 18
        '
        'UltraLabel2
        '
        Appearance2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.UltraLabel2.Appearance = Appearance2
        Me.UltraLabel2.BackColorInternal = System.Drawing.Color.Transparent
        Me.UltraLabel2.Location = New System.Drawing.Point(28, 116)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(312, 32)
        Me.UltraLabel2.TabIndex = 16
        Me.UltraLabel2.Text = "Stadis     " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Copyright © International Micro Systems.  All rights reserved."
        '
        'lblHAWarning
        '
        Appearance4.BackColor = System.Drawing.Color.Transparent
        Appearance4.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance4.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblHAWarning.Appearance = Appearance4
        Me.lblHAWarning.BackColorInternal = System.Drawing.Color.Transparent
        Me.lblHAWarning.Location = New System.Drawing.Point(28, 166)
        Me.lblHAWarning.Name = "lblHAWarning"
        Me.lblHAWarning.Size = New System.Drawing.Size(312, 72)
        Me.lblHAWarning.TabIndex = 14
        Me.lblHAWarning.Text = resources.GetString("lblHAWarning.Text")
        '
        'btnHAOK
        '
        Appearance5.FontData.SizeInPoints = 12.0!
        Me.btnHAOK.Appearance = Appearance5
        Me.btnHAOK.Location = New System.Drawing.Point(132, 252)
        Me.btnHAOK.Name = "btnHAOK"
        Me.btnHAOK.Size = New System.Drawing.Size(88, 57)
        Me.btnHAOK.TabIndex = 13
        Me.btnHAOK.Text = "OK"
        '
        'UltraPictureBox3
        '
        Me.UltraPictureBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.UltraPictureBox3.BorderShadowColor = System.Drawing.Color.Empty
        Me.UltraPictureBox3.DefaultImage = Global.StadisRProV9Plugin.My.Resources.Resources.STADIS_LOGO140x90
        Me.UltraPictureBox3.Location = New System.Drawing.Point(233, 10)
        Me.UltraPictureBox3.Name = "UltraPictureBox3"
        Me.UltraPictureBox3.Size = New System.Drawing.Size(95, 91)
        Me.UltraPictureBox3.TabIndex = 46
        '
        'FrmAbout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(352, 326)
        Me.Controls.Add(Me.UltraPictureBox3)
        Me.Controls.Add(Me.lblHAVer)
        Me.Controls.Add(Me.UltraPictureBox1)
        Me.Controls.Add(Me.UltraLabel2)
        Me.Controls.Add(Me.lblHAWarning)
        Me.Controls.Add(Me.btnHAOK)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmAbout"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "About Stadis"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblHAVer As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraPictureBox1 As Infragistics.Win.UltraWinEditors.UltraPictureBox
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblHAWarning As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnHAOK As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraPictureBox3 As Infragistics.Win.UltraWinEditors.UltraPictureBox
End Class
