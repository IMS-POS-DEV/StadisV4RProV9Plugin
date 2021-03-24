<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmSelectTenderType
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
        Me.btnStadis = New System.Windows.Forms.Button()
        Me.btnTappit = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnStadis
        '
        Me.btnStadis.Location = New System.Drawing.Point(23, 36)
        Me.btnStadis.Name = "btnStadis"
        Me.btnStadis.Size = New System.Drawing.Size(120, 75)
        Me.btnStadis.TabIndex = 0
        Me.btnStadis.Text = "Stadis"
        Me.btnStadis.UseVisualStyleBackColor = True
        '
        'btnTappit
        '
        Me.btnTappit.Location = New System.Drawing.Point(171, 36)
        Me.btnTappit.Name = "btnTappit"
        Me.btnTappit.Size = New System.Drawing.Size(120, 75)
        Me.btnTappit.TabIndex = 1
        Me.btnTappit.Text = "Tappit"
        Me.btnTappit.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(319, 36)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(120, 75)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'FrmSelectTenderType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(474, 147)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnTappit)
        Me.Controls.Add(Me.btnStadis)
        Me.Name = "FrmSelectTenderType"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select In House Tender"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnStadis As Button
    Friend WithEvents btnTappit As Button
    Friend WithEvents btnCancel As Button
End Class
