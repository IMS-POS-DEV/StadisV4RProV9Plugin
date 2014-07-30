Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
'------------------------------------------------------------------------------
' Draws a "selected" row with the normal row colors
'------------------------------------------------------------------------------
Friend Class MyDrawFilter
    Implements IUIElementDrawFilter

    Friend Function DrawElement(ByVal drawPhase As Infragistics.Win.DrawPhase, ByRef drawParams As Infragistics.Win.UIElementDrawParams) As Boolean Implements Infragistics.Win.IUIElementDrawFilter.DrawElement
        Dim aCell As UltraGridCell
        Select Case drawPhase
            Case drawPhase.BeforeDrawForeground
                aCell = CType(drawParams.Element.SelectableItem, Infragistics.Win.UltraWinGrid.UltraGridCell)
                If aCell.Selected OrElse aCell.Row.Selected OrElse aCell.Column.Header.Selected OrElse aCell.Activated OrElse aCell.Row.Activated Then
                    If (aCell.HasAppearance) AndAlso (Not aCell.Appearance.ForeColor.IsEmpty) Then
                        drawParams.AppearanceData.ForeColor = aCell.Appearance.ForeColor
                    ElseIf (aCell.Column.HasCellAppearance) AndAlso (Not aCell.Column.CellAppearance.ForeColor.IsEmpty) Then
                        drawParams.AppearanceData.ForeColor = aCell.Column.CellAppearance.ForeColor
                    ElseIf (aCell.Row.HasCellAppearance) AndAlso (Not aCell.Row.CellAppearance.ForeColor.IsEmpty) Then
                        drawParams.AppearanceData.ForeColor = aCell.Row.CellAppearance.ForeColor
                    End If
                End If
        End Select
    End Function  'DrawElement

    Friend Function GetPhasesToFilter(ByRef drawParams As Infragistics.Win.UIElementDrawParams) As Infragistics.Win.DrawPhase Implements Infragistics.Win.IUIElementDrawFilter.GetPhasesToFilter
        'In order to handle the drawing, we need to override the drawing of the TextUIElement inside the cell. So first, we check to see if the Element
        'is a TextUIElementBase. Second, we check to see if it's context is a cell.  If so, we return the BeforeDrawForeGround phase, so we can override it. 
        If (TypeOf drawParams.Element Is TextUIElementBase) AndAlso (Not drawParams.Element.GetContext(GetType(UltraGridCell)) Is Nothing) Then
            Return DrawPhase.BeforeDrawForeground
        End If
    End Function  'GetPhasesToFilter

End Class  'MyDrawFilter
