Public Class FrmLoginMerge

    Private Sub FrmLoginMerge_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Label3.Text = ""
        PasswordTextBox.Clear()
        PasswordTextBox.Focus()
    End Sub  'FrmLoginMerge_Load

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim sHour As String
        Dim sDay As String
        sHour = CStr(DatePart(DateInterval.Hour, Now))
        sDay = CStr(DatePart(DateInterval.Day, Now))
        'Label3.Text = sDay & sHour
        If PasswordTextBox.Text = sDay & sHour Then
            PasswordTextBox.Clear()
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            Label3.Text = "Password is Invalid"
            PasswordTextBox.Clear()
            'Threading.Thread.Sleep(2000)
            'Me.Close()
        End If
    End Sub  ' OK_Click

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub  'Cancel_Click

End Class  'FrmLoginMerge
