<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConfig
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConfig))
        Me.gbGeneral = New System.Windows.Forms.GroupBox()
        Me.btnLogoFile = New System.Windows.Forms.Button()
        Me.txtTender = New System.Windows.Forms.TextBox()
        Me.txtHeader = New System.Windows.Forms.TextBox()
        Me.txtLogoFile = New System.Windows.Forms.TextBox()
        Me.txtWebPassword = New System.Windows.Forms.TextBox()
        Me.txtWebUser = New System.Windows.Forms.TextBox()
        Me.txtWebURL = New System.Windows.Forms.TextBox()
        Me.chkAction = New System.Windows.Forms.CheckBox()
        Me.chkMerge = New System.Windows.Forms.CheckBox()
        Me.chkPrint = New System.Windows.Forms.CheckBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblOPOSPrinter = New System.Windows.Forms.Label()
        Me.gbPrint = New System.Windows.Forms.GroupBox()
        Me.cmbPrinter = New System.Windows.Forms.ComboBox()
        Me.cmbRaster = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbOPOS = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnApply = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.gbGeneral.SuspendLayout()
        Me.gbPrint.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbGeneral
        '
        Me.gbGeneral.Controls.Add(Me.btnLogoFile)
        Me.gbGeneral.Controls.Add(Me.txtTender)
        Me.gbGeneral.Controls.Add(Me.txtHeader)
        Me.gbGeneral.Controls.Add(Me.txtLogoFile)
        Me.gbGeneral.Controls.Add(Me.txtWebPassword)
        Me.gbGeneral.Controls.Add(Me.txtWebUser)
        Me.gbGeneral.Controls.Add(Me.txtWebURL)
        Me.gbGeneral.Controls.Add(Me.chkAction)
        Me.gbGeneral.Controls.Add(Me.chkMerge)
        Me.gbGeneral.Controls.Add(Me.chkPrint)
        Me.gbGeneral.Controls.Add(Me.Label11)
        Me.gbGeneral.Controls.Add(Me.Label10)
        Me.gbGeneral.Controls.Add(Me.Label9)
        Me.gbGeneral.Controls.Add(Me.Label8)
        Me.gbGeneral.Controls.Add(Me.Label7)
        Me.gbGeneral.Controls.Add(Me.Label6)
        Me.gbGeneral.Controls.Add(Me.Label4)
        Me.gbGeneral.Controls.Add(Me.Label5)
        Me.gbGeneral.Controls.Add(Me.lblOPOSPrinter)
        Me.gbGeneral.Location = New System.Drawing.Point(8, 8)
        Me.gbGeneral.Name = "gbGeneral"
        Me.gbGeneral.Size = New System.Drawing.Size(465, 248)
        Me.gbGeneral.TabIndex = 0
        Me.gbGeneral.TabStop = False
        Me.gbGeneral.Text = "General"
        '
        'btnLogoFile
        '
        Me.btnLogoFile.Image = CType(resources.GetObject("btnLogoFile.Image"), System.Drawing.Image)
        Me.btnLogoFile.Location = New System.Drawing.Point(400, 96)
        Me.btnLogoFile.Name = "btnLogoFile"
        Me.btnLogoFile.Size = New System.Drawing.Size(37, 24)
        Me.btnLogoFile.TabIndex = 8
        Me.btnLogoFile.UseVisualStyleBackColor = True
        '
        'txtTender
        '
        Me.txtTender.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.txtTender.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTender.Location = New System.Drawing.Point(168, 144)
        Me.txtTender.Name = "txtTender"
        Me.txtTender.Size = New System.Drawing.Size(269, 20)
        Me.txtTender.TabIndex = 12
        '
        'txtHeader
        '
        Me.txtHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.txtHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHeader.Location = New System.Drawing.Point(168, 120)
        Me.txtHeader.Name = "txtHeader"
        Me.txtHeader.Size = New System.Drawing.Size(269, 20)
        Me.txtHeader.TabIndex = 10
        '
        'txtLogoFile
        '
        Me.txtLogoFile.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.txtLogoFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLogoFile.Location = New System.Drawing.Point(168, 96)
        Me.txtLogoFile.Name = "txtLogoFile"
        Me.txtLogoFile.Size = New System.Drawing.Size(245, 20)
        Me.txtLogoFile.TabIndex = 7
        '
        'txtWebPassword
        '
        Me.txtWebPassword.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.txtWebPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWebPassword.Location = New System.Drawing.Point(168, 72)
        Me.txtWebPassword.Name = "txtWebPassword"
        Me.txtWebPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtWebPassword.Size = New System.Drawing.Size(269, 20)
        Me.txtWebPassword.TabIndex = 5
        '
        'txtWebUser
        '
        Me.txtWebUser.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.txtWebUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWebUser.Location = New System.Drawing.Point(168, 48)
        Me.txtWebUser.Name = "txtWebUser"
        Me.txtWebUser.Size = New System.Drawing.Size(269, 20)
        Me.txtWebUser.TabIndex = 3
        '
        'txtWebURL
        '
        Me.txtWebURL.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.txtWebURL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWebURL.Location = New System.Drawing.Point(168, 24)
        Me.txtWebURL.Name = "txtWebURL"
        Me.txtWebURL.Size = New System.Drawing.Size(269, 20)
        Me.txtWebURL.TabIndex = 1
        '
        'chkAction
        '
        Me.chkAction.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkAction.Location = New System.Drawing.Point(168, 216)
        Me.chkAction.Name = "chkAction"
        Me.chkAction.Size = New System.Drawing.Size(24, 16)
        Me.chkAction.TabIndex = 18
        Me.chkAction.UseVisualStyleBackColor = False
        '
        'chkMerge
        '
        Me.chkMerge.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkMerge.Location = New System.Drawing.Point(168, 192)
        Me.chkMerge.Name = "chkMerge"
        Me.chkMerge.Size = New System.Drawing.Size(24, 16)
        Me.chkMerge.TabIndex = 16
        Me.chkMerge.UseVisualStyleBackColor = False
        '
        'chkPrint
        '
        Me.chkPrint.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkPrint.Location = New System.Drawing.Point(168, 168)
        Me.chkPrint.Name = "chkPrint"
        Me.chkPrint.Size = New System.Drawing.Size(24, 16)
        Me.chkPrint.TabIndex = 14
        Me.chkPrint.UseVisualStyleBackColor = False
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(16, 216)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(144, 16)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "Show STADIS Action Grid:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(16, 192)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(144, 16)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Merge Function Enabled:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(16, 168)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(144, 16)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Printing Enabled:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(16, 144)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(144, 16)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "STADIS Tender Text:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(16, 120)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(144, 16)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Screen Header Text:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(16, 96)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(144, 16)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Logo File:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(144, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Web Service Password:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(16, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(144, 16)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "STADIS Web Service URL:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblOPOSPrinter
        '
        Me.lblOPOSPrinter.Location = New System.Drawing.Point(16, 48)
        Me.lblOPOSPrinter.Name = "lblOPOSPrinter"
        Me.lblOPOSPrinter.Size = New System.Drawing.Size(144, 16)
        Me.lblOPOSPrinter.TabIndex = 2
        Me.lblOPOSPrinter.Text = "Web Service User Name:"
        Me.lblOPOSPrinter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gbPrint
        '
        Me.gbPrint.Controls.Add(Me.cmbPrinter)
        Me.gbPrint.Controls.Add(Me.cmbRaster)
        Me.gbPrint.Controls.Add(Me.Label3)
        Me.gbPrint.Controls.Add(Me.cmbOPOS)
        Me.gbPrint.Controls.Add(Me.Label2)
        Me.gbPrint.Controls.Add(Me.Label1)
        Me.gbPrint.Location = New System.Drawing.Point(8, 264)
        Me.gbPrint.Name = "gbPrint"
        Me.gbPrint.Size = New System.Drawing.Size(465, 128)
        Me.gbPrint.TabIndex = 1
        Me.gbPrint.TabStop = False
        Me.gbPrint.Text = "Transaction Printing"
        '
        'cmbPrinter
        '
        Me.cmbPrinter.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cmbPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrinter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPrinter.FormattingEnabled = True
        Me.cmbPrinter.Location = New System.Drawing.Point(168, 88)
        Me.cmbPrinter.Name = "cmbPrinter"
        Me.cmbPrinter.Size = New System.Drawing.Size(269, 21)
        Me.cmbPrinter.TabIndex = 5
        '
        'cmbRaster
        '
        Me.cmbRaster.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cmbRaster.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRaster.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRaster.FormattingEnabled = True
        Me.cmbRaster.Location = New System.Drawing.Point(168, 56)
        Me.cmbRaster.Name = "cmbRaster"
        Me.cmbRaster.Size = New System.Drawing.Size(269, 21)
        Me.cmbRaster.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(144, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Windows Printer:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbOPOS
        '
        Me.cmbOPOS.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cmbOPOS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOPOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOPOS.FormattingEnabled = True
        Me.cmbOPOS.Location = New System.Drawing.Point(168, 24)
        Me.cmbOPOS.Name = "cmbOPOS"
        Me.cmbOPOS.Size = New System.Drawing.Size(269, 21)
        Me.cmbOPOS.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(144, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Star/Raster Receipt Printer:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "OPOS Receipt Printer:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnApply
        '
        Me.btnApply.Image = CType(resources.GetObject("btnApply.Image"), System.Drawing.Image)
        Me.btnApply.Location = New System.Drawing.Point(129, 401)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(96, 40)
        Me.btnApply.TabIndex = 2
        Me.btnApply.Text = "&Apply"
        Me.btnApply.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnApply.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.Location = New System.Drawing.Point(249, 401)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(96, 40)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'FrmConfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(473, 450)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.gbPrint)
        Me.Controls.Add(Me.gbGeneral)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrmConfig"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " STADIS Balance Check Config"
        Me.gbGeneral.ResumeLayout(False)
        Me.gbGeneral.PerformLayout()
        Me.gbPrint.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents lblOPOSPrinter As System.Windows.Forms.Label
    Friend WithEvents gbPrint As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbOPOS As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbRaster As System.Windows.Forms.ComboBox
    Friend WithEvents cmbPrinter As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents chkAction As System.Windows.Forms.CheckBox
    Friend WithEvents chkMerge As System.Windows.Forms.CheckBox
    Friend WithEvents chkPrint As System.Windows.Forms.CheckBox
    Friend WithEvents btnLogoFile As System.Windows.Forms.Button
    Friend WithEvents txtTender As System.Windows.Forms.TextBox
    Friend WithEvents txtHeader As System.Windows.Forms.TextBox
    Friend WithEvents txtLogoFile As System.Windows.Forms.TextBox
    Friend WithEvents txtWebPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtWebUser As System.Windows.Forms.TextBox
    Friend WithEvents txtWebURL As System.Windows.Forms.TextBox
    Friend WithEvents btnApply As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
