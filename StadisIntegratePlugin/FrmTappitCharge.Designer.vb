<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmTappitCharge
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
        Me.lblTenderID = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.lblHeader = New Infragistics.Win.Misc.UltraLabel()
        Me.pbLogo = New Infragistics.Win.UltraWinEditors.UltraPictureBox()
        Me.txtTenderID = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txtAmountDue = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor()
        Me.btnKeyboard = New Infragistics.Win.Misc.UltraButton()
        Me.btnClear = New Infragistics.Win.Misc.UltraButton()
        Me.btnOK = New Infragistics.Win.Misc.UltraButton()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.txtMessage = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel7 = New Infragistics.Win.Misc.UltraLabel()
        Me.lblOriginalDocID = New Infragistics.Win.Misc.UltraLabel()
        Me.txtOriginalDocID = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblOriginalDocAmt = New Infragistics.Win.Misc.UltraLabel()
        Me.txtOriginalDocAmt = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor()
        Me.chkCertify = New System.Windows.Forms.CheckBox()
        CType(Me.txtTenderID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAmountDue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMessage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOriginalDocID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOriginalDocAmt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTenderID
        '
        Appearance1.ForeColor = System.Drawing.Color.Teal
        Appearance1.TextHAlignAsString = "Right"
        Me.lblTenderID.Appearance = Appearance1
        Me.lblTenderID.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTenderID.Location = New System.Drawing.Point(60, 138)
        Me.lblTenderID.Name = "lblTenderID"
        Me.lblTenderID.Size = New System.Drawing.Size(237, 23)
        Me.lblTenderID.TabIndex = 12
        Me.lblTenderID.Text = "Tappit Barcode"
        '
        'UltraLabel1
        '
        Appearance2.ForeColor = System.Drawing.Color.Teal
        Appearance2.TextHAlignAsString = "Right"
        Me.UltraLabel1.Appearance = Appearance2
        Me.UltraLabel1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel1.Location = New System.Drawing.Point(99, 89)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(198, 23)
        Me.UltraLabel1.TabIndex = 7
        Me.UltraLabel1.Text = "Amount Due"
        '
        'lblHeader
        '
        Appearance3.FontData.BoldAsString = "True"
        Appearance3.FontData.Name = "Arial Black"
        Appearance3.FontData.SizeInPoints = 14.0!
        Appearance3.ForeColor = System.Drawing.Color.Teal
        Appearance3.TextHAlignAsString = "Center"
        Me.lblHeader.Appearance = Appearance3
        Me.lblHeader.Location = New System.Drawing.Point(79, 16)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(541, 23)
        Me.lblHeader.TabIndex = 13
        Me.lblHeader.Text = "Redeem Gift Card / STADIS"
        '
        'pbLogo
        '
        Me.pbLogo.BorderShadowColor = System.Drawing.Color.Empty
        Me.pbLogo.ImageTransparentColor = System.Drawing.Color.White
        Me.pbLogo.Location = New System.Drawing.Point(12, 12)
        Me.pbLogo.Name = "pbLogo"
        Me.pbLogo.ScaleImage = Infragistics.Win.ScaleImage.Always
        Me.pbLogo.Size = New System.Drawing.Size(110, 66)
        Me.pbLogo.TabIndex = 14
        '
        'txtTenderID
        '
        Appearance4.BackColor = System.Drawing.Color.White
        Appearance4.FontData.BoldAsString = "True"
        Appearance4.FontData.Name = "Arial"
        Appearance4.FontData.SizeInPoints = 12.0!
        Appearance4.TextHAlignAsString = "Left"
        Me.txtTenderID.Appearance = Appearance4
        Me.txtTenderID.BackColor = System.Drawing.Color.White
        Me.txtTenderID.BorderStyle = Infragistics.Win.UIElementBorderStyle.Inset
        Me.txtTenderID.Location = New System.Drawing.Point(303, 134)
        Me.txtTenderID.Name = "txtTenderID"
        Me.txtTenderID.Size = New System.Drawing.Size(317, 27)
        Me.txtTenderID.TabIndex = 0
        Me.txtTenderID.Text = "12345678901234567890"
        '
        'txtAmountDue
        '
        Appearance5.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
        Appearance5.FontData.BoldAsString = "True"
        Appearance5.FontData.Name = "Arial"
        Appearance5.FontData.SizeInPoints = 12.0!
        Me.txtAmountDue.Appearance = Appearance5
        Me.txtAmountDue.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.txtAmountDue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmountDue.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.txtAmountDue.FormatString = """$""#,##0.00"
        Me.txtAmountDue.Location = New System.Drawing.Point(303, 85)
        Me.txtAmountDue.Name = "txtAmountDue"
        Me.txtAmountDue.ReadOnly = True
        Me.txtAmountDue.Size = New System.Drawing.Size(115, 27)
        Me.txtAmountDue.TabIndex = 22
        Me.txtAmountDue.TabStop = False
        '
        'btnKeyboard
        '
        Appearance6.FontData.BoldAsString = "True"
        Appearance6.FontData.SizeInPoints = 10.0!
        Appearance6.Image = Global.StadisIntegratePlugin.My.Resources.Resources.keyboard32
        Appearance6.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance6.ImageVAlign = Infragistics.Win.VAlign.Top
        Me.btnKeyboard.Appearance = Appearance6
        Me.btnKeyboard.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKeyboard.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnKeyboard.Location = New System.Drawing.Point(78, 344)
        Me.btnKeyboard.Name = "btnKeyboard"
        Me.btnKeyboard.Size = New System.Drawing.Size(87, 58)
        Me.btnKeyboard.TabIndex = 68
        Me.btnKeyboard.TabStop = False
        Me.btnKeyboard.Text = "Keyboard"
        '
        'btnClear
        '
        Appearance7.TextHAlignAsString = "Center"
        Appearance7.TextVAlignAsString = "Bottom"
        Me.btnClear.Appearance = Appearance7
        Me.btnClear.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.Location = New System.Drawing.Point(209, 344)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(87, 58)
        Me.btnClear.TabIndex = 67
        Me.btnClear.TabStop = False
        Me.btnClear.Text = "Clear" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Entries"
        '
        'btnOK
        '
        Appearance8.FontData.BoldAsString = "True"
        Appearance8.FontData.SizeInPoints = 10.0!
        Appearance8.Image = Global.StadisIntegratePlugin.My.Resources.Resources.check32
        Appearance8.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance8.ImageVAlign = Infragistics.Win.VAlign.Top
        Me.btnOK.Appearance = Appearance8
        Me.btnOK.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnOK.Location = New System.Drawing.Point(400, 344)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(87, 58)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "Process"
        '
        'btnCancel
        '
        Appearance9.FontData.BoldAsString = "True"
        Appearance9.FontData.SizeInPoints = 10.0!
        Appearance9.Image = Global.StadisIntegratePlugin.My.Resources.Resources.delete32
        Appearance9.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance9.ImageVAlign = Infragistics.Win.VAlign.Top
        Me.btnCancel.Appearance = Appearance9
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnCancel.Location = New System.Drawing.Point(532, 344)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(87, 58)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.TabStop = False
        Me.btnCancel.Text = "Cancel"
        '
        'txtMessage
        '
        Appearance10.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
        Appearance10.FontData.BoldAsString = "True"
        Appearance10.FontData.Name = "Arial"
        Appearance10.FontData.SizeInPoints = 14.0!
        Appearance10.ForeColor = System.Drawing.Color.Firebrick
        Appearance10.TextHAlignAsString = "Left"
        Me.txtMessage.Appearance = Appearance10
        Me.txtMessage.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.txtMessage.Location = New System.Drawing.Point(302, 185)
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.ReadOnly = True
        Me.txtMessage.Size = New System.Drawing.Size(317, 31)
        Me.txtMessage.TabIndex = 64
        Me.txtMessage.TabStop = False
        Me.txtMessage.Text = "Message Here"
        '
        'UltraLabel7
        '
        Appearance11.ForeColor = System.Drawing.Color.Teal
        Appearance11.TextHAlignAsString = "Right"
        Me.UltraLabel7.Appearance = Appearance11
        Me.UltraLabel7.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel7.Location = New System.Drawing.Point(78, 189)
        Me.UltraLabel7.Name = "UltraLabel7"
        Me.UltraLabel7.Size = New System.Drawing.Size(218, 23)
        Me.UltraLabel7.TabIndex = 63
        Me.UltraLabel7.Text = "Charge Result"
        '
        'lblOriginalDocID
        '
        Appearance12.ForeColor = System.Drawing.Color.Teal
        Appearance12.TextHAlignAsString = "Right"
        Me.lblOriginalDocID.Appearance = Appearance12
        Me.lblOriginalDocID.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOriginalDocID.Location = New System.Drawing.Point(59, 243)
        Me.lblOriginalDocID.Name = "lblOriginalDocID"
        Me.lblOriginalDocID.Size = New System.Drawing.Size(237, 23)
        Me.lblOriginalDocID.TabIndex = 69
        Me.lblOriginalDocID.Text = "Original Doc ID"
        '
        'txtOriginalDocID
        '
        Appearance13.BackColor = System.Drawing.Color.White
        Appearance13.FontData.BoldAsString = "True"
        Appearance13.FontData.Name = "Arial"
        Appearance13.FontData.SizeInPoints = 12.0!
        Appearance13.TextHAlignAsString = "Left"
        Me.txtOriginalDocID.Appearance = Appearance13
        Me.txtOriginalDocID.BackColor = System.Drawing.Color.White
        Me.txtOriginalDocID.BorderStyle = Infragistics.Win.UIElementBorderStyle.Inset
        Me.txtOriginalDocID.Location = New System.Drawing.Point(303, 239)
        Me.txtOriginalDocID.Name = "txtOriginalDocID"
        Me.txtOriginalDocID.Size = New System.Drawing.Size(317, 27)
        Me.txtOriginalDocID.TabIndex = 1
        Me.txtOriginalDocID.Text = "12345678901234567890"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(22, 45)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(118, 87)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 71
        Me.PictureBox1.TabStop = False
        '
        'lblOriginalDocAmt
        '
        Appearance14.ForeColor = System.Drawing.Color.Teal
        Appearance14.TextHAlignAsString = "Right"
        Me.lblOriginalDocAmt.Appearance = Appearance14
        Me.lblOriginalDocAmt.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOriginalDocAmt.Location = New System.Drawing.Point(12, 295)
        Me.lblOriginalDocAmt.Name = "lblOriginalDocAmt"
        Me.lblOriginalDocAmt.Size = New System.Drawing.Size(285, 23)
        Me.lblOriginalDocAmt.TabIndex = 73
        Me.lblOriginalDocAmt.Text = "Full Total on the Original Receipt"
        '
        'txtOriginalDocAmt
        '
        Appearance15.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
        Appearance15.FontData.BoldAsString = "True"
        Appearance15.FontData.Name = "Arial"
        Appearance15.FontData.SizeInPoints = 12.0!
        Me.txtOriginalDocAmt.Appearance = Appearance15
        Me.txtOriginalDocAmt.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.txtOriginalDocAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOriginalDocAmt.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.txtOriginalDocAmt.FormatString = """$""#,##0.00"
        Me.txtOriginalDocAmt.Location = New System.Drawing.Point(303, 291)
        Me.txtOriginalDocAmt.Name = "txtOriginalDocAmt"
        Me.txtOriginalDocAmt.Size = New System.Drawing.Size(115, 27)
        Me.txtOriginalDocAmt.TabIndex = 74
        Me.txtOriginalDocAmt.TabStop = False
        '
        'chkCertify
        '
        Me.chkCertify.AutoSize = True
        Me.chkCertify.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCertify.Location = New System.Drawing.Point(432, 296)
        Me.chkCertify.Name = "chkCertify"
        Me.chkCertify.Size = New System.Drawing.Size(256, 22)
        Me.chkCertify.TabIndex = 2
        Me.chkCertify.Text = "I certify the original total is correct"
        Me.chkCertify.UseVisualStyleBackColor = True
        '
        'FrmTappitCharge
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(705, 410)
        Me.Controls.Add(Me.chkCertify)
        Me.Controls.Add(Me.txtOriginalDocAmt)
        Me.Controls.Add(Me.lblOriginalDocAmt)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.txtOriginalDocID)
        Me.Controls.Add(Me.lblOriginalDocID)
        Me.Controls.Add(Me.btnKeyboard)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtMessage)
        Me.Controls.Add(Me.UltraLabel7)
        Me.Controls.Add(Me.txtAmountDue)
        Me.Controls.Add(Me.lblHeader)
        Me.Controls.Add(Me.txtTenderID)
        Me.Controls.Add(Me.pbLogo)
        Me.Controls.Add(Me.lblTenderID)
        Me.Controls.Add(Me.UltraLabel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FrmTappitCharge"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Tender:  Stadis"
        CType(Me.txtTenderID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAmountDue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMessage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOriginalDocID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOriginalDocAmt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents lblTenderID As Infragistics.Win.Misc.UltraLabel
    Private WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Private WithEvents lblHeader As Infragistics.Win.Misc.UltraLabel
    Private WithEvents pbLogo As Infragistics.Win.UltraWinEditors.UltraPictureBox
    Private WithEvents txtTenderID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Private WithEvents txtAmountDue As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents btnKeyboard As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnClear As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnOK As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Private WithEvents txtMessage As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Private WithEvents UltraLabel7 As Infragistics.Win.Misc.UltraLabel
    Private WithEvents lblOriginalDocID As Infragistics.Win.Misc.UltraLabel
    Private WithEvents txtOriginalDocID As UltraTextEditor
    Friend WithEvents PictureBox1 As PictureBox
    Private WithEvents lblOriginalDocAmt As Infragistics.Win.Misc.UltraLabel
    Private WithEvents txtOriginalDocAmt As UltraCurrencyEditor
    Friend WithEvents chkCertify As CheckBox
End Class
