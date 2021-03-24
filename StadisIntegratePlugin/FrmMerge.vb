Public Class frmMerge

    Private Sub frmMerge_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub  'frmMerge_Load

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub  'btnExit_Click

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

    End Sub  'btnDelete_Click

    Private Sub btnScrollUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScrollUp.Click
        grdTickets.DisplayLayout.RowScrollRegions(0).Scroll(Infragistics.Win.UltraWinGrid.RowScrollAction.LineUp)
    End Sub  'btnScrollUp_Click

    Private Sub btnScrollDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScrollDown.Click
        grdTickets.DisplayLayout.RowScrollRegions(0).Scroll(Infragistics.Win.UltraWinGrid.RowScrollAction.LineDown)
    End Sub  'btnScrollDown_Click

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub  'btnCancel_Click

End Class  'frmMerge