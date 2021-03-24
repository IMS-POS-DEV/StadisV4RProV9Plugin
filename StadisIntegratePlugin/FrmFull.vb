Public Class FrmFull

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub  'btnExit_Click

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        With txtEntry
            .Clear()
            .Focus()
        End With
    End Sub  'btnClear_Click

    Private Sub btnMerge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMerge.Click
        Dim frmMerge As New frmMerge
        frmMerge.ShowDialog()
    End Sub  'btnMerge_Click

    Private Sub btnReceipt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReceipt.Click

        If MessageBox.Show("Print Transaction History?", "Print Receipt", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            'do whatever
        End If
        If MessageBox.Show("Print Linked Tickets?", "Print Receipt", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            'do whatever
        End If
    End Sub  'btnReceipt_Click

    Private Sub btn0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn0.Click
        With txtEntry
            .Text = .Text & "0"
            .SelectionStart = Len(.Text)
            .Focus()
        End With
    End Sub

    Private Sub btn00_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn00.Click
        With txtEntry
            .Text = .Text & "00"
            .SelectionStart = Len(.Text)
            .Focus()
        End With
    End Sub

    Private Sub btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1.Click
        With txtEntry
            .Text = .Text & "1"
            .SelectionStart = Len(.Text)
            .Focus()
        End With
    End Sub

    Private Sub btn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn2.Click
        With txtEntry
            .Text = .Text & "2"
            .SelectionStart = Len(.Text)
            .Focus()
        End With
    End Sub

    Private Sub btn3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn3.Click
        With txtEntry
            .Text = .Text & "3"
            .SelectionStart = Len(.Text)
            .Focus()
        End With
    End Sub

    Private Sub btn4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn4.Click
        With txtEntry
            .Text = .Text & "4"
            .SelectionStart = Len(.Text)
            .Focus()
        End With
    End Sub

    Private Sub btn5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn5.Click
        With txtEntry
            .Text = .Text & "5"
            .SelectionStart = Len(.Text)
            .Focus()
        End With
    End Sub

    Private Sub btn6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn6.Click
        With txtEntry
            .Text = .Text & "6"
            .SelectionStart = Len(.Text)
            .Focus()
        End With
    End Sub

    Private Sub btn7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn7.Click
        With txtEntry
            .Text = .Text & "7"
            .SelectionStart = Len(.Text)
            .Focus()
        End With
    End Sub

    Private Sub btn8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn8.Click
        With txtEntry
            .Text = .Text & "8"
            .SelectionStart = Len(.Text)
            .Focus()
        End With
    End Sub

    Private Sub btn9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn9.Click
        With txtEntry
            .Text = .Text & "9"
            .SelectionStart = Len(.Text)
            .Focus()
        End With
    End Sub

    Private Sub FrmFull_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class  'FrmFull