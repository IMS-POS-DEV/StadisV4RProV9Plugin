'Copyright 2020 International Micro Systems
'All rights reserved
'F r e d C. May Jr 07/25/2020
'

Public Class FrmSelectTenderType
    Private Sub btnStadis_Click(sender As Object, e As EventArgs) Handles btnStadis.Click
        SelectNone()
        gDoStadis = True
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub FrmSelectTenderType_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Note that an array of buttons may be the desired approach to solve organizing the buttons
        'However, currently there are only 2 possible buttons, and if this form is being raised they BOTH must be present
        'Therefore, currently a centered array of buttons does not need to be implemented yet
        'F r e d has an example button array form setup routine started
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        SelectNone()
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub SelectNone()
        gDoStadis = False
        gDoTappit = False
    End Sub

    Private Sub btnTappit_Click(sender As Object, e As EventArgs) Handles btnTappit.Click
        SelectNone()
        gDoTappit = True
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
End Class


