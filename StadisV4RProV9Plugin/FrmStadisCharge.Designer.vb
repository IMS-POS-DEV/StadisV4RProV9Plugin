<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmStadisCharge
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
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmStadisCharge))
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.btnKeyboard = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblTenderID = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.lblHeader = New Infragistics.Win.Misc.UltraLabel()
        Me.pbLogo = New Infragistics.Win.UltraWinEditors.UltraPictureBox()
        Me.txtTenderID = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txtMessage = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel7 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtAmountDue = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor()
        Me.txtAvailAmount = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor()
        Me.txtAcctBalance = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor()
        Me.txtRemAmountDue = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor()
        Me.txtTenderAmount = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor()
        Me.btnClear = New System.Windows.Forms.Button()
        CType(Me.txtTenderID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMessage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAmountDue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAvailAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAcctBalance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRemAmountDue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTenderAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnKeyboard
        '
        Me.btnKeyboard.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKeyboard.ForeColor = System.Drawing.Color.Black
        Me.btnKeyboard.Image = Global.StadisV4RProV9Plugin.My.Resources.Resources.keyboard32
        Me.btnKeyboard.Location = New System.Drawing.Point(79, 332)
        Me.btnKeyboard.Name = "btnKeyboard"
        Me.btnKeyboard.Size = New System.Drawing.Size(87, 58)
        Me.btnKeyboard.TabIndex = 4
        Me.btnKeyboard.Text = "Keyboard"
        Me.btnKeyboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnKeyboard.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.ForeColor = System.Drawing.Color.Black
        Me.btnOK.Image = Global.StadisV4RProV9Plugin.My.Resources.Resources.check32
        Me.btnOK.Location = New System.Drawing.Point(320, 332)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(87, 58)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        Me.btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.Black
        Me.btnCancel.Image = Global.StadisV4RProV9Plugin.My.Resources.Resources.delete32
        Me.btnCancel.Location = New System.Drawing.Point(413, 332)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(87, 58)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblTenderID
        '
        Appearance1.ForeColor = System.Drawing.Color.Teal
        Appearance1.TextHAlignAsString = "Right"
        Me.lblTenderID.Appearance = Appearance1
        Me.lblTenderID.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTenderID.Location = New System.Drawing.Point(60, 120)
        Me.lblTenderID.Name = "lblTenderID"
        Me.lblTenderID.Size = New System.Drawing.Size(237, 23)
        Me.lblTenderID.TabIndex = 12
        Me.lblTenderID.Text = "Gift Card ID / Ticket Barcode"
        '
        'UltraLabel5
        '
        Appearance2.ForeColor = System.Drawing.Color.Teal
        Appearance2.TextHAlignAsString = "Right"
        Me.UltraLabel5.Appearance = Appearance2
        Me.UltraLabel5.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel5.Location = New System.Drawing.Point(79, 244)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(218, 23)
        Me.UltraLabel5.TabIndex = 11
        Me.UltraLabel5.Text = "Remaining Amount Due"
        '
        'UltraLabel4
        '
        Appearance3.ForeColor = System.Drawing.Color.Teal
        Appearance3.TextHAlignAsString = "Right"
        Me.UltraLabel4.Appearance = Appearance3
        Me.UltraLabel4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel4.Location = New System.Drawing.Point(99, 182)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(198, 23)
        Me.UltraLabel4.TabIndex = 10
        Me.UltraLabel4.Text = "Tender Amount"
        '
        'UltraLabel3
        '
        Appearance4.ForeColor = System.Drawing.Color.Teal
        Appearance4.TextHAlignAsString = "Right"
        Me.UltraLabel3.Appearance = Appearance4
        Me.UltraLabel3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel3.Location = New System.Drawing.Point(50, 213)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(247, 23)
        Me.UltraLabel3.TabIndex = 9
        Me.UltraLabel3.Text = "Account Balance After Charge"
        '
        'UltraLabel2
        '
        Appearance5.ForeColor = System.Drawing.Color.Teal
        Appearance5.TextHAlignAsString = "Right"
        Me.UltraLabel2.Appearance = Appearance5
        Me.UltraLabel2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel2.Location = New System.Drawing.Point(99, 151)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(198, 23)
        Me.UltraLabel2.TabIndex = 8
        Me.UltraLabel2.Text = "Available Amount"
        '
        'UltraLabel1
        '
        Appearance6.ForeColor = System.Drawing.Color.Teal
        Appearance6.TextHAlignAsString = "Right"
        Me.UltraLabel1.Appearance = Appearance6
        Me.UltraLabel1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel1.Location = New System.Drawing.Point(99, 89)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(198, 23)
        Me.UltraLabel1.TabIndex = 7
        Me.UltraLabel1.Text = "Amount Due"
        '
        'lblHeader
        '
        Appearance7.FontData.BoldAsString = "True"
        Appearance7.FontData.Name = "Arial Black"
        Appearance7.FontData.SizeInPoints = 14.0!
        Appearance7.ForeColor = System.Drawing.Color.Teal
        Appearance7.TextHAlignAsString = "Center"
        Me.lblHeader.Appearance = Appearance7
        Me.lblHeader.Location = New System.Drawing.Point(89, 16)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(440, 23)
        Me.lblHeader.TabIndex = 13
        Me.lblHeader.Text = "Redeem Gift Card / STADIS"
        '
        'pbLogo
        '
        Me.pbLogo.BorderShadowColor = System.Drawing.Color.Empty
        Me.pbLogo.Image = CType(resources.GetObject("pbLogo.Image"), Object)
        Me.pbLogo.ImageTransparentColor = System.Drawing.Color.White
        Me.pbLogo.Location = New System.Drawing.Point(12, 12)
        Me.pbLogo.Name = "pbLogo"
        Me.pbLogo.ScaleImage = Infragistics.Win.ScaleImage.Always
        Me.pbLogo.Size = New System.Drawing.Size(110, 66)
        Me.pbLogo.TabIndex = 14
        '
        'txtTenderID
        '
        Appearance8.BackColor = System.Drawing.Color.White
        Appearance8.FontData.BoldAsString = "True"
        Appearance8.FontData.Name = "Arial"
        Appearance8.FontData.SizeInPoints = 12.0!
        Appearance8.TextHAlignAsString = "Left"
        Me.txtTenderID.Appearance = Appearance8
        Me.txtTenderID.BackColor = System.Drawing.Color.White
        Me.txtTenderID.BorderStyle = Infragistics.Win.UIElementBorderStyle.Inset
        Me.txtTenderID.Location = New System.Drawing.Point(303, 116)
        Me.txtTenderID.Name = "txtTenderID"
        Me.txtTenderID.Size = New System.Drawing.Size(197, 27)
        Me.txtTenderID.TabIndex = 0
        Me.txtTenderID.Text = "12345678901234567890"
        '
        'txtMessage
        '
        Appearance9.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
        Appearance9.FontData.BoldAsString = "True"
        Appearance9.FontData.Name = "Arial"
        Appearance9.FontData.SizeInPoints = 14.0!
        Appearance9.ForeColor = System.Drawing.Color.Firebrick
        Appearance9.TextHAlignAsString = "Left"
        Me.txtMessage.Appearance = Appearance9
        Me.txtMessage.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.txtMessage.Location = New System.Drawing.Point(303, 271)
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.ReadOnly = True
        Me.txtMessage.Size = New System.Drawing.Size(263, 31)
        Me.txtMessage.TabIndex = 21
        Me.txtMessage.Text = "Message Here"
        '
        'UltraLabel7
        '
        Appearance10.ForeColor = System.Drawing.Color.Teal
        Appearance10.TextHAlignAsString = "Right"
        Me.UltraLabel7.Appearance = Appearance10
        Me.UltraLabel7.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel7.Location = New System.Drawing.Point(79, 275)
        Me.UltraLabel7.Name = "UltraLabel7"
        Me.UltraLabel7.Size = New System.Drawing.Size(218, 23)
        Me.UltraLabel7.TabIndex = 20
        Me.UltraLabel7.Text = "Charge Result"
        '
        'txtAmountDue
        '
        Appearance11.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
        Appearance11.FontData.BoldAsString = "True"
        Appearance11.FontData.Name = "Arial"
        Appearance11.FontData.SizeInPoints = 12.0!
        Me.txtAmountDue.Appearance = Appearance11
        Me.txtAmountDue.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.txtAmountDue.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.txtAmountDue.FormatString = """$""#,##0.00"
        Me.txtAmountDue.Location = New System.Drawing.Point(303, 85)
        Me.txtAmountDue.Name = "txtAmountDue"
        Me.txtAmountDue.ReadOnly = True
        Me.txtAmountDue.Size = New System.Drawing.Size(115, 27)
        Me.txtAmountDue.TabIndex = 22
        Me.txtAmountDue.TabStop = False
        '
        'txtAvailAmount
        '
        Appearance12.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
        Appearance12.FontData.BoldAsString = "True"
        Appearance12.FontData.Name = "Arial"
        Appearance12.FontData.SizeInPoints = 12.0!
        Me.txtAvailAmount.Appearance = Appearance12
        Me.txtAvailAmount.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.txtAvailAmount.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.txtAvailAmount.FormatString = """$""#,##0.00"
        Me.txtAvailAmount.Location = New System.Drawing.Point(303, 147)
        Me.txtAvailAmount.Name = "txtAvailAmount"
        Me.txtAvailAmount.ReadOnly = True
        Me.txtAvailAmount.Size = New System.Drawing.Size(115, 27)
        Me.txtAvailAmount.TabIndex = 23
        Me.txtAvailAmount.TabStop = False
        '
        'txtAcctBalance
        '
        Appearance13.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
        Appearance13.FontData.BoldAsString = "True"
        Appearance13.FontData.Name = "Arial"
        Appearance13.FontData.SizeInPoints = 12.0!
        Me.txtAcctBalance.Appearance = Appearance13
        Me.txtAcctBalance.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.txtAcctBalance.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.txtAcctBalance.FormatString = """$""#,##0.00"
        Me.txtAcctBalance.Location = New System.Drawing.Point(303, 209)
        Me.txtAcctBalance.Name = "txtAcctBalance"
        Me.txtAcctBalance.ReadOnly = True
        Me.txtAcctBalance.Size = New System.Drawing.Size(115, 27)
        Me.txtAcctBalance.TabIndex = 25
        Me.txtAcctBalance.TabStop = False
        '
        'txtRemAmountDue
        '
        Appearance14.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
        Appearance14.FontData.BoldAsString = "True"
        Appearance14.FontData.Name = "Arial"
        Appearance14.FontData.SizeInPoints = 12.0!
        Me.txtRemAmountDue.Appearance = Appearance14
        Me.txtRemAmountDue.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.txtRemAmountDue.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.txtRemAmountDue.FormatString = """$""#,##0.00"
        Me.txtRemAmountDue.Location = New System.Drawing.Point(303, 240)
        Me.txtRemAmountDue.Name = "txtRemAmountDue"
        Me.txtRemAmountDue.ReadOnly = True
        Me.txtRemAmountDue.Size = New System.Drawing.Size(115, 27)
        Me.txtRemAmountDue.TabIndex = 26
        Me.txtRemAmountDue.TabStop = False
        '
        'txtTenderAmount
        '
        Appearance15.FontData.BoldAsString = "True"
        Appearance15.FontData.Name = "Arial"
        Appearance15.FontData.SizeInPoints = 12.0!
        Me.txtTenderAmount.Appearance = Appearance15
        Me.txtTenderAmount.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.txtTenderAmount.FormatString = """$""#,##0.00"
        Me.txtTenderAmount.Location = New System.Drawing.Point(303, 178)
        Me.txtTenderAmount.Name = "txtTenderAmount"
        Me.txtTenderAmount.Size = New System.Drawing.Size(115, 27)
        Me.txtTenderAmount.TabIndex = 1
        '
        'btnClear
        '
        Me.btnClear.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.Color.Black
        Me.btnClear.Location = New System.Drawing.Point(172, 332)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(87, 58)
        Me.btnClear.TabIndex = 27
        Me.btnClear.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Clear" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Entries"
        Me.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'FrmStadisCharge
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(592, 404)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.txtTenderAmount)
        Me.Controls.Add(Me.txtRemAmountDue)
        Me.Controls.Add(Me.txtAcctBalance)
        Me.Controls.Add(Me.txtAvailAmount)
        Me.Controls.Add(Me.txtAmountDue)
        Me.Controls.Add(Me.txtMessage)
        Me.Controls.Add(Me.UltraLabel7)
        Me.Controls.Add(Me.lblHeader)
        Me.Controls.Add(Me.txtTenderID)
        Me.Controls.Add(Me.pbLogo)
        Me.Controls.Add(Me.lblTenderID)
        Me.Controls.Add(Me.UltraLabel5)
        Me.Controls.Add(Me.UltraLabel4)
        Me.Controls.Add(Me.UltraLabel3)
        Me.Controls.Add(Me.UltraLabel2)
        Me.Controls.Add(Me.UltraLabel1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnKeyboard)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmStadisCharge"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tender:  Stadis"
        CType(Me.txtTenderID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMessage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAmountDue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAvailAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAcctBalance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRemAmountDue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTenderAmount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnKeyboard As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Private WithEvents lblTenderID As Infragistics.Win.Misc.UltraLabel
    Private WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Private WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Private WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Private WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Private WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Private WithEvents lblHeader As Infragistics.Win.Misc.UltraLabel
    Private WithEvents pbLogo As Infragistics.Win.UltraWinEditors.UltraPictureBox
    Private WithEvents txtTenderID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Private WithEvents txtMessage As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Private WithEvents UltraLabel7 As Infragistics.Win.Misc.UltraLabel
    Private WithEvents txtAmountDue As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Private WithEvents txtAvailAmount As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Private WithEvents txtAcctBalance As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Private WithEvents txtRemAmountDue As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Private WithEvents txtTenderAmount As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
End Class
