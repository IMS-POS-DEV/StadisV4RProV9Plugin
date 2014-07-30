<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFull
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFull))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.gbKeyPad = New System.Windows.Forms.GroupBox
        Me.btnClear = New System.Windows.Forms.Button
        Me.btnEnter = New System.Windows.Forms.Button
        Me.btn00 = New System.Windows.Forms.Button
        Me.btn0 = New System.Windows.Forms.Button
        Me.btn3 = New System.Windows.Forms.Button
        Me.btn2 = New System.Windows.Forms.Button
        Me.btn1 = New System.Windows.Forms.Button
        Me.btn6 = New System.Windows.Forms.Button
        Me.btn5 = New System.Windows.Forms.Button
        Me.btn4 = New System.Windows.Forms.Button
        Me.btn9 = New System.Windows.Forms.Button
        Me.btn8 = New System.Windows.Forms.Button
        Me.btn7 = New System.Windows.Forms.Button
        Me.gbDetail = New System.Windows.Forms.GroupBox
        Me.btnView = New System.Windows.Forms.Button
        Me.dgHistory = New System.Windows.Forms.DataGridView
        Me.gidDateTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnDOWN = New System.Windows.Forms.Button
        Me.btnUP = New System.Windows.Forms.Button
        Me.gbAction = New System.Windows.Forms.GroupBox
        Me.btnReceipt = New System.Windows.Forms.Button
        Me.btnConfig = New System.Windows.Forms.Button
        Me.btnLinked = New System.Windows.Forms.Button
        Me.btnHistory = New System.Windows.Forms.Button
        Me.btnMerge = New System.Windows.Forms.Button
        Me.btnReports = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnAddEdit = New System.Windows.Forms.Button
        Me.gbInfo = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.lblEventID = New System.Windows.Forms.Label
        Me.lblEntry = New System.Windows.Forms.Label
        Me.txtEntry = New System.Windows.Forms.TextBox
        Me.pbLogo = New System.Windows.Forms.PictureBox
        Me.gbKeyPad.SuspendLayout()
        Me.gbDetail.SuspendLayout()
        CType(Me.dgHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbAction.SuspendLayout()
        Me.gbInfo.SuspendLayout()
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbKeyPad
        '
        Me.gbKeyPad.Controls.Add(Me.btnClear)
        Me.gbKeyPad.Controls.Add(Me.btn00)
        Me.gbKeyPad.Controls.Add(Me.btnEnter)
        Me.gbKeyPad.Controls.Add(Me.btn0)
        Me.gbKeyPad.Controls.Add(Me.btn3)
        Me.gbKeyPad.Controls.Add(Me.btn2)
        Me.gbKeyPad.Controls.Add(Me.btn1)
        Me.gbKeyPad.Controls.Add(Me.btn6)
        Me.gbKeyPad.Controls.Add(Me.btn5)
        Me.gbKeyPad.Controls.Add(Me.btn4)
        Me.gbKeyPad.Controls.Add(Me.btn9)
        Me.gbKeyPad.Controls.Add(Me.btn8)
        Me.gbKeyPad.Controls.Add(Me.btn7)
        Me.gbKeyPad.Location = New System.Drawing.Point(600, 248)
        Me.gbKeyPad.Name = "gbKeyPad"
        Me.gbKeyPad.Size = New System.Drawing.Size(200, 296)
        Me.gbKeyPad.TabIndex = 0
        Me.gbKeyPad.TabStop = False
        '
        'btnClear
        '
        Me.btnClear.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.Image = CType(resources.GetObject("btnClear.Image"), System.Drawing.Image)
        Me.btnClear.Location = New System.Drawing.Point(104, 239)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(88, 48)
        Me.btnClear.TabIndex = 12
        Me.btnClear.Text = "Clear"
        Me.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnEnter
        '
        Me.btnEnter.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEnter.Image = CType(resources.GetObject("btnEnter.Image"), System.Drawing.Image)
        Me.btnEnter.Location = New System.Drawing.Point(8, 239)
        Me.btnEnter.Name = "btnEnter"
        Me.btnEnter.Size = New System.Drawing.Size(88, 48)
        Me.btnEnter.TabIndex = 11
        Me.btnEnter.Text = "Enter"
        Me.btnEnter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEnter.UseVisualStyleBackColor = True
        '
        'btn00
        '
        Me.btn00.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn00.Location = New System.Drawing.Point(136, 182)
        Me.btn00.Name = "btn00"
        Me.btn00.Size = New System.Drawing.Size(56, 48)
        Me.btn00.TabIndex = 10
        Me.btn00.Text = "00"
        Me.btn00.UseVisualStyleBackColor = True
        '
        'btn0
        '
        Me.btn0.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn0.Location = New System.Drawing.Point(8, 182)
        Me.btn0.Name = "btn0"
        Me.btn0.Size = New System.Drawing.Size(120, 48)
        Me.btn0.TabIndex = 9
        Me.btn0.Text = "0"
        Me.btn0.UseVisualStyleBackColor = True
        '
        'btn3
        '
        Me.btn3.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn3.Location = New System.Drawing.Point(136, 126)
        Me.btn3.Name = "btn3"
        Me.btn3.Size = New System.Drawing.Size(56, 48)
        Me.btn3.TabIndex = 8
        Me.btn3.Text = "3"
        Me.btn3.UseVisualStyleBackColor = True
        '
        'btn2
        '
        Me.btn2.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn2.Location = New System.Drawing.Point(72, 126)
        Me.btn2.Name = "btn2"
        Me.btn2.Size = New System.Drawing.Size(56, 48)
        Me.btn2.TabIndex = 7
        Me.btn2.Text = "2"
        Me.btn2.UseVisualStyleBackColor = True
        '
        'btn1
        '
        Me.btn1.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn1.Location = New System.Drawing.Point(8, 126)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(56, 48)
        Me.btn1.TabIndex = 6
        Me.btn1.Text = "1"
        Me.btn1.UseVisualStyleBackColor = True
        '
        'btn6
        '
        Me.btn6.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn6.Location = New System.Drawing.Point(136, 70)
        Me.btn6.Name = "btn6"
        Me.btn6.Size = New System.Drawing.Size(56, 48)
        Me.btn6.TabIndex = 5
        Me.btn6.Text = "6"
        Me.btn6.UseVisualStyleBackColor = True
        '
        'btn5
        '
        Me.btn5.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn5.Location = New System.Drawing.Point(72, 70)
        Me.btn5.Name = "btn5"
        Me.btn5.Size = New System.Drawing.Size(56, 48)
        Me.btn5.TabIndex = 4
        Me.btn5.Text = "5"
        Me.btn5.UseVisualStyleBackColor = True
        '
        'btn4
        '
        Me.btn4.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn4.Location = New System.Drawing.Point(8, 70)
        Me.btn4.Name = "btn4"
        Me.btn4.Size = New System.Drawing.Size(56, 48)
        Me.btn4.TabIndex = 3
        Me.btn4.Text = "4"
        Me.btn4.UseVisualStyleBackColor = True
        '
        'btn9
        '
        Me.btn9.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn9.Location = New System.Drawing.Point(136, 14)
        Me.btn9.Name = "btn9"
        Me.btn9.Size = New System.Drawing.Size(56, 48)
        Me.btn9.TabIndex = 2
        Me.btn9.Text = "9"
        Me.btn9.UseVisualStyleBackColor = True
        '
        'btn8
        '
        Me.btn8.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn8.Location = New System.Drawing.Point(72, 14)
        Me.btn8.Name = "btn8"
        Me.btn8.Size = New System.Drawing.Size(56, 48)
        Me.btn8.TabIndex = 1
        Me.btn8.Text = "8"
        Me.btn8.UseVisualStyleBackColor = True
        '
        'btn7
        '
        Me.btn7.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn7.Location = New System.Drawing.Point(8, 14)
        Me.btn7.Name = "btn7"
        Me.btn7.Size = New System.Drawing.Size(56, 48)
        Me.btn7.TabIndex = 0
        Me.btn7.Text = "7"
        Me.btn7.UseVisualStyleBackColor = True
        '
        'gbDetail
        '
        Me.gbDetail.Controls.Add(Me.btnView)
        Me.gbDetail.Controls.Add(Me.dgHistory)
        Me.gbDetail.Controls.Add(Me.btnDOWN)
        Me.gbDetail.Controls.Add(Me.btnUP)
        Me.gbDetail.Location = New System.Drawing.Point(8, 344)
        Me.gbDetail.Name = "gbDetail"
        Me.gbDetail.Size = New System.Drawing.Size(584, 200)
        Me.gbDetail.TabIndex = 1
        Me.gbDetail.TabStop = False
        '
        'btnView
        '
        Me.btnView.Image = CType(resources.GetObject("btnView.Image"), System.Drawing.Image)
        Me.btnView.Location = New System.Drawing.Point(528, 80)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(48, 48)
        Me.btnView.TabIndex = 3
        Me.btnView.UseVisualStyleBackColor = True
        '
        'dgHistory
        '
        Me.dgHistory.AllowUserToDeleteRows = False
        Me.dgHistory.AllowUserToResizeRows = False
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgHistory.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgHistory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gidDateTime})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgHistory.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgHistory.Location = New System.Drawing.Point(8, 16)
        Me.dgHistory.MultiSelect = False
        Me.dgHistory.Name = "dgHistory"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgHistory.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgHistory.RowHeadersVisible = False
        Me.dgHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgHistory.Size = New System.Drawing.Size(512, 176)
        Me.dgHistory.TabIndex = 2
        '
        'gidDateTime
        '
        Me.gidDateTime.HeaderText = "Date/Time"
        Me.gidDateTime.Name = "gidDateTime"
        Me.gidDateTime.ReadOnly = True
        '
        'btnDOWN
        '
        Me.btnDOWN.Image = CType(resources.GetObject("btnDOWN.Image"), System.Drawing.Image)
        Me.btnDOWN.Location = New System.Drawing.Point(528, 128)
        Me.btnDOWN.Name = "btnDOWN"
        Me.btnDOWN.Size = New System.Drawing.Size(48, 64)
        Me.btnDOWN.TabIndex = 1
        Me.btnDOWN.UseVisualStyleBackColor = True
        '
        'btnUP
        '
        Me.btnUP.Image = CType(resources.GetObject("btnUP.Image"), System.Drawing.Image)
        Me.btnUP.Location = New System.Drawing.Point(528, 16)
        Me.btnUP.Name = "btnUP"
        Me.btnUP.Size = New System.Drawing.Size(48, 64)
        Me.btnUP.TabIndex = 0
        Me.btnUP.UseVisualStyleBackColor = True
        '
        'gbAction
        '
        Me.gbAction.Controls.Add(Me.btnReceipt)
        Me.gbAction.Controls.Add(Me.btnConfig)
        Me.gbAction.Controls.Add(Me.btnLinked)
        Me.gbAction.Controls.Add(Me.btnHistory)
        Me.gbAction.Controls.Add(Me.btnMerge)
        Me.gbAction.Controls.Add(Me.btnReports)
        Me.gbAction.Controls.Add(Me.btnExit)
        Me.gbAction.Controls.Add(Me.btnAddEdit)
        Me.gbAction.Location = New System.Drawing.Point(600, 8)
        Me.gbAction.Name = "gbAction"
        Me.gbAction.Size = New System.Drawing.Size(200, 240)
        Me.gbAction.TabIndex = 2
        Me.gbAction.TabStop = False
        '
        'btnReceipt
        '
        Me.btnReceipt.Enabled = False
        Me.btnReceipt.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReceipt.Image = CType(resources.GetObject("btnReceipt.Image"), System.Drawing.Image)
        Me.btnReceipt.Location = New System.Drawing.Point(104, 72)
        Me.btnReceipt.Name = "btnReceipt"
        Me.btnReceipt.Size = New System.Drawing.Size(88, 48)
        Me.btnReceipt.TabIndex = 2
        Me.btnReceipt.Text = "Receipt"
        Me.btnReceipt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnReceipt.UseVisualStyleBackColor = True
        '
        'btnConfig
        '
        Me.btnConfig.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfig.Image = CType(resources.GetObject("btnConfig.Image"), System.Drawing.Image)
        Me.btnConfig.Location = New System.Drawing.Point(8, 16)
        Me.btnConfig.Name = "btnConfig"
        Me.btnConfig.Size = New System.Drawing.Size(88, 48)
        Me.btnConfig.TabIndex = 6
        Me.btnConfig.Text = "Config"
        Me.btnConfig.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnConfig.UseVisualStyleBackColor = True
        '
        'btnLinked
        '
        Me.btnLinked.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLinked.Image = CType(resources.GetObject("btnLinked.Image"), System.Drawing.Image)
        Me.btnLinked.Location = New System.Drawing.Point(104, 184)
        Me.btnLinked.Name = "btnLinked"
        Me.btnLinked.Size = New System.Drawing.Size(88, 48)
        Me.btnLinked.TabIndex = 5
        Me.btnLinked.Text = "View Linked"
        Me.btnLinked.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnLinked.UseVisualStyleBackColor = True
        '
        'btnHistory
        '
        Me.btnHistory.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHistory.Image = CType(resources.GetObject("btnHistory.Image"), System.Drawing.Image)
        Me.btnHistory.Location = New System.Drawing.Point(8, 184)
        Me.btnHistory.Name = "btnHistory"
        Me.btnHistory.Size = New System.Drawing.Size(88, 48)
        Me.btnHistory.TabIndex = 4
        Me.btnHistory.Text = "View History"
        Me.btnHistory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnHistory.UseVisualStyleBackColor = True
        '
        'btnMerge
        '
        Me.btnMerge.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMerge.Image = CType(resources.GetObject("btnMerge.Image"), System.Drawing.Image)
        Me.btnMerge.Location = New System.Drawing.Point(104, 128)
        Me.btnMerge.Name = "btnMerge"
        Me.btnMerge.Size = New System.Drawing.Size(88, 48)
        Me.btnMerge.TabIndex = 3
        Me.btnMerge.Text = "Merge"
        Me.btnMerge.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnMerge.UseVisualStyleBackColor = True
        '
        'btnReports
        '
        Me.btnReports.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReports.Image = CType(resources.GetObject("btnReports.Image"), System.Drawing.Image)
        Me.btnReports.Location = New System.Drawing.Point(8, 72)
        Me.btnReports.Name = "btnReports"
        Me.btnReports.Size = New System.Drawing.Size(88, 48)
        Me.btnReports.TabIndex = 2
        Me.btnReports.Text = "Reports"
        Me.btnReports.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnReports.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.Location = New System.Drawing.Point(104, 16)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(88, 48)
        Me.btnExit.TabIndex = 1
        Me.btnExit.Text = "Exit"
        Me.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnAddEdit
        '
        Me.btnAddEdit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddEdit.Image = CType(resources.GetObject("btnAddEdit.Image"), System.Drawing.Image)
        Me.btnAddEdit.Location = New System.Drawing.Point(8, 128)
        Me.btnAddEdit.Name = "btnAddEdit"
        Me.btnAddEdit.Size = New System.Drawing.Size(88, 48)
        Me.btnAddEdit.TabIndex = 0
        Me.btnAddEdit.Text = "Add / Edit"
        Me.btnAddEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAddEdit.UseVisualStyleBackColor = True
        '
        'gbInfo
        '
        Me.gbInfo.Controls.Add(Me.Label9)
        Me.gbInfo.Controls.Add(Me.Label2)
        Me.gbInfo.Controls.Add(Me.Label15)
        Me.gbInfo.Controls.Add(Me.Label13)
        Me.gbInfo.Controls.Add(Me.Label11)
        Me.gbInfo.Controls.Add(Me.Label8)
        Me.gbInfo.Controls.Add(Me.Label1)
        Me.gbInfo.Controls.Add(Me.Label5)
        Me.gbInfo.Controls.Add(Me.Label3)
        Me.gbInfo.Controls.Add(Me.Label7)
        Me.gbInfo.Controls.Add(Me.Label4)
        Me.gbInfo.Controls.Add(Me.Label6)
        Me.gbInfo.Controls.Add(Me.Label14)
        Me.gbInfo.Controls.Add(Me.Label12)
        Me.gbInfo.Controls.Add(Me.lblEventID)
        Me.gbInfo.Controls.Add(Me.lblEntry)
        Me.gbInfo.Controls.Add(Me.txtEntry)
        Me.gbInfo.Location = New System.Drawing.Point(8, 8)
        Me.gbInfo.Name = "gbInfo"
        Me.gbInfo.Size = New System.Drawing.Size(584, 336)
        Me.gbInfo.TabIndex = 3
        Me.gbInfo.TabStop = False
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(456, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 32)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "ACTIVE"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(297, 274)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(167, 51)
        Me.Label15.TabIndex = 4
        Me.Label15.Text = "$0.00"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(292, 213)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(168, 32)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "$0.00"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(292, 245)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(168, 32)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "$0.00"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(184, 59)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(392, 32)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "1234567890 - Default Customer"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(184, 91)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(392, 32)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Section: 000    Row: 000    Seat: 000"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(184, 155)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 32)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "12345678"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(184, 123)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 32)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "12345678"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Teal
        Me.Label7.Location = New System.Drawing.Point(33, 59)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(151, 32)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Customer:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Teal
        Me.Label4.Location = New System.Drawing.Point(56, 155)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(128, 32)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Level ID:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Teal
        Me.Label6.Location = New System.Drawing.Point(59, 91)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(125, 32)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Location:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Teal
        Me.Label14.Location = New System.Drawing.Point(120, 289)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(169, 32)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "Total Remaining:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Teal
        Me.Label12.Location = New System.Drawing.Point(120, 216)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(169, 32)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "Ticket Remaining:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Teal
        Me.Label9.Location = New System.Drawing.Point(120, 248)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(169, 32)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Account Remaining:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblEventID
        '
        Me.lblEventID.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEventID.ForeColor = System.Drawing.Color.Teal
        Me.lblEventID.Location = New System.Drawing.Point(63, 123)
        Me.lblEventID.Name = "lblEventID"
        Me.lblEventID.Size = New System.Drawing.Size(121, 32)
        Me.lblEventID.TabIndex = 1
        Me.lblEventID.Text = "Event ID:"
        Me.lblEventID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblEntry
        '
        Me.lblEntry.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEntry.ForeColor = System.Drawing.Color.Teal
        Me.lblEntry.Location = New System.Drawing.Point(8, 16)
        Me.lblEntry.Name = "lblEntry"
        Me.lblEntry.Size = New System.Drawing.Size(176, 32)
        Me.lblEntry.TabIndex = 1
        Me.lblEntry.Text = "Scan/Enter Ticket #:"
        Me.lblEntry.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEntry
        '
        Me.txtEntry.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.txtEntry.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEntry.Location = New System.Drawing.Point(184, 16)
        Me.txtEntry.Name = "txtEntry"
        Me.txtEntry.Size = New System.Drawing.Size(264, 32)
        Me.txtEntry.TabIndex = 0
        Me.txtEntry.Text = "12345678901234567890"
        '
        'pbLogo
        '
        Me.pbLogo.Location = New System.Drawing.Point(8, 352)
        Me.pbLogo.Name = "pbLogo"
        Me.pbLogo.Size = New System.Drawing.Size(584, 192)
        Me.pbLogo.TabIndex = 4
        Me.pbLogo.TabStop = False
        '
        'frmFull
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(811, 556)
        Me.Controls.Add(Me.gbInfo)
        Me.Controls.Add(Me.gbAction)
        Me.Controls.Add(Me.gbDetail)
        Me.Controls.Add(Me.gbKeyPad)
        Me.Controls.Add(Me.pbLogo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFull"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "STADIS - Balance Check"
        Me.gbKeyPad.ResumeLayout(False)
        Me.gbDetail.ResumeLayout(False)
        CType(Me.dgHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbAction.ResumeLayout(False)
        Me.gbInfo.ResumeLayout(False)
        Me.gbInfo.PerformLayout()
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbKeyPad As System.Windows.Forms.GroupBox
    Friend WithEvents btn00 As System.Windows.Forms.Button
    Friend WithEvents btn0 As System.Windows.Forms.Button
    Friend WithEvents btn3 As System.Windows.Forms.Button
    Friend WithEvents btn2 As System.Windows.Forms.Button
    Friend WithEvents btn1 As System.Windows.Forms.Button
    Friend WithEvents btn6 As System.Windows.Forms.Button
    Friend WithEvents btn5 As System.Windows.Forms.Button
    Friend WithEvents btn4 As System.Windows.Forms.Button
    Friend WithEvents btn9 As System.Windows.Forms.Button
    Friend WithEvents btn8 As System.Windows.Forms.Button
    Friend WithEvents btn7 As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnEnter As System.Windows.Forms.Button
    Friend WithEvents gbDetail As System.Windows.Forms.GroupBox
    Friend WithEvents btnView As System.Windows.Forms.Button
    Friend WithEvents dgHistory As System.Windows.Forms.DataGridView
    Friend WithEvents btnDOWN As System.Windows.Forms.Button
    Friend WithEvents btnUP As System.Windows.Forms.Button
    Friend WithEvents gbAction As System.Windows.Forms.GroupBox
    Friend WithEvents gbInfo As System.Windows.Forms.GroupBox
    Friend WithEvents btnAddEdit As System.Windows.Forms.Button
    Friend WithEvents txtEntry As System.Windows.Forms.TextBox
    Friend WithEvents btnLinked As System.Windows.Forms.Button
    Friend WithEvents btnHistory As System.Windows.Forms.Button
    Friend WithEvents btnMerge As System.Windows.Forms.Button
    Friend WithEvents btnReports As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents lblEntry As System.Windows.Forms.Label
    Friend WithEvents btnReceipt As System.Windows.Forms.Button
    Friend WithEvents pbLogo As System.Windows.Forms.PictureBox
    Friend WithEvents btnConfig As System.Windows.Forms.Button
    Friend WithEvents lblEventID As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents gidDateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
