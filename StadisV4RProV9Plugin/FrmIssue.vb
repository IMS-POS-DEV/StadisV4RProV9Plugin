Imports CommonV4
Imports CommonV4.WebReference
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Drawing
Imports System.Windows.Forms
'----------------------------------------------------------------------------------------------
'   Class: FrmIssue
'    Type: Windows Form
' Purpose: Issue gift cards.  Invoked by ButtonIssue.
'----------------------------------------------------------------------------------------------
Friend Class FrmIssue

#Region " Data Declarations "

    Private mAdapter As RetailPro.Plugins.IPluginAdapter
    Private mGiftCards As New DSGiftCard
    Private mCardTotal As Decimal = 0D
    Private mAddTotal As Decimal = 0D
    Private mGiftCardTotal As Decimal = 0D
    Private mCustomerID As String = gDefaultCustomerID
    Private mGridUpdateLock As Boolean = False

    'Const AllStatusesGood As Integer = 0
    'Const TicketIsInactive As Integer = -1
    'Const CustomerIsInactive As Integer = -2
    'Const TicketNotFound As Integer = -3
    'Const Unknown As Integer = 0
    Const ACTIVE As Integer = 1
    Const PENDING As Integer = 3

    Friend Property Adapter() As RetailPro.Plugins.IPluginAdapter
        Get
            Return mAdapter
        End Get
        Set(ByVal value As RetailPro.Plugins.IPluginAdapter)
            mAdapter = value
        End Set
    End Property

#End Region  'Data Declarations

#Region " Form Load and Initialization "

    '----------------------------------------------------------------------------------------------
    ' Called when form is loaded
    '----------------------------------------------------------------------------------------------
    Private Sub FrmIssue_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'pbLogo.Image = New Bitmap(gFormLogoImage)
        SetCustomerID()
        SetUpGiftCardButtons()
        SetUpGridAndConnectToGiftCardsDataset()
        LoadGiftCardDropdown()
    End Sub  'FrmIssue_Load

    '----------------------------------------------------------------------------------------------
    ' Display FrmScanTicket if option is set to collect CustomerID
    '----------------------------------------------------------------------------------------------
    Private Sub SetCustomerID()
        mCustomerID = gDefaultCustomerID
        If gAskForTicketOnIssue = True Then
            Dim mFrmScanTicket As New FrmScanTicket
            mFrmScanTicket.Owner = Me
            mFrmScanTicket.Caption = "Please Scan the Customer's Ticket"
            Select Case mFrmScanTicket.ShowDialog()
                Case Windows.Forms.DialogResult.OK
                    mCustomerID = mFrmScanTicket.TicketID
                Case Windows.Forms.DialogResult.Cancel
                    mCustomerID = gDefaultCustomerID
            End Select
            mFrmScanTicket = Nothing
        End If
    End Sub  'SetCustomerID

    '----------------------------------------------------------------------------------------------
    ' Set the size, number and location of buttons based on info from GiftCardInfo table
    '----------------------------------------------------------------------------------------------
    Private Sub SetUpGiftCardButtons()
        grdGiftCards.Size = New System.Drawing.Size(770, 393)
        grdGiftCards.Left = 14
        grdGiftCards.Top = 108
        Dim buttonCount As Integer = gGCI.GiftCardInfo.Count
        If buttonCount < 1 Then Exit Sub
        If buttonCount > 6 Then buttonCount = 6
        Dim span As Integer = grdGiftCards.Width
        Dim startPoint As Integer = grdGiftCards.Left
        Dim gap As Integer = 8
        Dim gaps As Integer = (buttonCount - 1) * gap
        Dim distFromTop As Integer = 62
        Dim buttonHeight As Integer = 40
        Dim buttonWidth As Integer = (span - gaps) \ buttonCount
        Dim extra As Integer = (span - gaps) Mod buttonCount
        If extra > 1 Then startPoint += 1
        If extra > 3 Then startPoint += 1
        btnGiftCard1.Text = gGCI.GiftCardInfo(0).ButtonCaption
        btnGiftCard1.Tag = gGCI.GiftCardInfo(0).RProLookupALU
        btnGiftCard1.Appearance.FontData.Bold = DefaultableBoolean.True
        btnGiftCard1.Enabled = True
        btnGiftCard1.Visible = True

        'Button1
        If buttonCount = 1 Then
            btnGiftCard1.Size = New Size(254, buttonHeight)
            btnGiftCard1.Location = New Point(530, distFromTop)
            btnGiftCard1.Appearance.FontData.SizeInPoints = SizeFont(254, btnGiftCard1.Text.Length)
        Else
            btnGiftCard1.Size = New Size(buttonWidth, buttonHeight)
            btnGiftCard1.Location = New Point(startPoint, distFromTop)
            btnGiftCard1.Appearance.FontData.SizeInPoints = SizeFont(buttonWidth, btnGiftCard1.Text.Length)
        End If

        'Button2
        If buttonCount > 1 Then
            btnGiftCard2.Size = New Size(buttonWidth, buttonHeight)
            btnGiftCard2.Location = New Point(startPoint + buttonWidth + gap, distFromTop)
            btnGiftCard2.Text = gGCI.GiftCardInfo(1).ButtonCaption
            btnGiftCard2.Tag = gGCI.GiftCardInfo(1).RProLookupALU
            btnGiftCard2.Appearance.FontData.Bold = DefaultableBoolean.True
            btnGiftCard2.Appearance.FontData.SizeInPoints = SizeFont(buttonWidth, btnGiftCard2.Text.Length)
            btnGiftCard2.Enabled = True
            btnGiftCard2.Visible = True
        End If

        'Button3
        If buttonCount > 2 Then
            btnGiftCard3.Size = New Size(buttonWidth, buttonHeight)
            btnGiftCard3.Location = New Point(startPoint + (2 * (buttonWidth + gap)), distFromTop)
            btnGiftCard3.Text = gGCI.GiftCardInfo(2).ButtonCaption
            btnGiftCard3.Tag = gGCI.GiftCardInfo(2).RProLookupALU
            btnGiftCard3.Appearance.FontData.Bold = DefaultableBoolean.True
            btnGiftCard3.Appearance.FontData.SizeInPoints = SizeFont(buttonWidth, btnGiftCard3.Text.Length)
            btnGiftCard3.Enabled = True
            btnGiftCard3.Visible = True
        End If

        'Button4
        If buttonCount > 3 Then
            btnGiftCard4.Size = New Size(buttonWidth, buttonHeight)
            btnGiftCard4.Location = New Point(startPoint + (3 * (buttonWidth + gap)), distFromTop)
            btnGiftCard4.Text = gGCI.GiftCardInfo(3).ButtonCaption
            btnGiftCard4.Tag = gGCI.GiftCardInfo(3).RProLookupALU
            btnGiftCard4.Appearance.FontData.Bold = DefaultableBoolean.True
            btnGiftCard4.Appearance.FontData.SizeInPoints = SizeFont(buttonWidth, btnGiftCard4.Text.Length)
            btnGiftCard4.Enabled = True
            btnGiftCard4.Visible = True
        End If

        'Button5
        If buttonCount > 4 Then
            btnGiftCard5.Size = New Size(buttonWidth, buttonHeight)
            btnGiftCard5.Location = New Point(startPoint + (4 * (buttonWidth + gap)), distFromTop)
            btnGiftCard5.Text = gGCI.GiftCardInfo(4).ButtonCaption
            btnGiftCard5.Tag = gGCI.GiftCardInfo(4).RProLookupALU
            btnGiftCard5.Appearance.FontData.Bold = DefaultableBoolean.True
            btnGiftCard5.Appearance.FontData.SizeInPoints = SizeFont(buttonWidth, btnGiftCard5.Text.Length)
            btnGiftCard5.Enabled = True
            btnGiftCard5.Visible = True
        End If

        'Button6
        If buttonCount > 5 Then
            btnGiftCard6.Size = New Size(buttonWidth, buttonHeight)
            btnGiftCard6.Location = New Point(startPoint + (5 * (buttonWidth + gap)), distFromTop)
            btnGiftCard6.Text = gGCI.GiftCardInfo(5).ButtonCaption
            btnGiftCard6.Tag = gGCI.GiftCardInfo(5).RProLookupALU
            btnGiftCard6.Appearance.FontData.Bold = DefaultableBoolean.True
            btnGiftCard6.Appearance.FontData.SizeInPoints = SizeFont(buttonWidth, btnGiftCard6.Text.Length)
            btnGiftCard6.Enabled = True
            btnGiftCard6.Visible = True
        End If

    End Sub  'SetUpGiftCardButtons

    '----------------------------------------------------------------------------------------------
    ' Make the button font bigger or smaller to fit the button 
    '----------------------------------------------------------------------------------------------
    Private Function SizeFont(ByVal btnWidth As Integer, ByVal txtLength As Integer) As Decimal
        If btnWidth \ txtLength < 7 Then
            Return 7.5D
        Else
            Return 8.5D
        End If
    End Function  'SizeFont

    '----------------------------------------------------------------------------------------------
    ' Setup related to grid 
    '----------------------------------------------------------------------------------------------
    Private Sub SetUpGridAndConnectToGiftCardsDataset()
        grdGiftCards.DrawFilter = New MyDrawFilter()
        mGiftCards = New DSGiftCard
        MakeGridEnterActLikeTab()
        AddHeaderAndTotalRecsToGiftCardsTable()
        grdGiftCards.DataSource = mGiftCards
        CalculateGiftCardTotal()
        grdGiftCards.Refresh()
        grdGiftCards.BeginInvoke(New MethodInvoker(AddressOf ActivateGridEditMode))
    End Sub  'SetUpGridAndConnectToTendersDataset

    '----------------------------------------------------------------------------------------------
    ' If grid is in focus, we want the Enter key to act like a Tab key
    '----------------------------------------------------------------------------------------------
    Private Sub MakeGridEnterActLikeTab()
        Dim newKam As Infragistics.Win.UltraWinGrid.GridKeyActionMapping
        For Each ugkam As Infragistics.Win.UltraWinGrid.GridKeyActionMapping In grdGiftCards.KeyActionMappings
            If ugkam.KeyCode = Keys.Tab Then
                newKam = New Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, ugkam.ActionCode, ugkam.StateDisallowed, ugkam.StateRequired, ugkam.SpecialKeysDisallowed, ugkam.SpecialKeysRequired)
                grdGiftCards.KeyActionMappings.Add(newKam)
            End If
        Next
    End Sub  'MakeGridEnterActLikeTab

    '----------------------------------------------------------------------------------------------
    ' Create our invisible anchor Header rec, one Tender rec, and our two Total recs
    '----------------------------------------------------------------------------------------------
    Private Sub AddHeaderAndTotalRecsToGiftCardsTable()
        Dim dr1 As DSGiftCard.HeaderRow = CType(mGiftCards.Header.NewRow(), DSGiftCard.HeaderRow)
        dr1.ID = 1
        mGiftCards.Header.Rows.Add(dr1)
        AddLineToGiftCardsGrid()
        Dim dr3 As DSGiftCard.TotalRow = CType(mGiftCards.Total.NewRow(), DSGiftCard.TotalRow)
        dr3.ID = 1
        dr3.Description = "Gift Card Totals  >>> "
        mGiftCards.Total.Rows.Add(dr3)
    End Sub  'AddHeaderAndTotalRecsToGiftCardsTable

    '----------------------------------------------------------------------------------------------
    ' Grid setup
    '----------------------------------------------------------------------------------------------
    Private Sub grdGiftCards_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdGiftCards.InitializeLayout

        With grdGiftCards

            .SuspendLayout()
            .DataSource = DSGiftCardBindingSource
            .UpdateMode = UpdateMode.OnCellChangeOrLostFocus

            With .DisplayLayout
                With .Appearance
                    .BackColor = Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
                    '.BorderColor = Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
                    .FontData.Name = "Arial"
                    .FontData.SizeInPoints = 14
                End With
                .AutoFitStyle = AutoFitStyle.ResizeAllColumns
                .BorderStyle = Infragistics.Win.UIElementBorderStyle.None
                .CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
                .ColumnChooserEnabled = DefaultableBoolean.False
                .InterBandSpacing = 0
                .MaxColScrollRegions = 1
                .MaxRowScrollRegions = 1
                With .Override
                    .AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
                    .AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None
                    .AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed
                    .AllowUpdate = Infragistics.Win.DefaultableBoolean.True
                    .BorderStyleCell = UIElementBorderStyle.Dotted
                    .BorderStyleRow = UIElementBorderStyle.Solid
                    .CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect
                    .CellPadding = 0
                    .ExpansionIndicator = ShowExpansionIndicator.Never
                    .HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
                    .HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
                    .RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
                    .RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed
                    .SelectTypeCell = SelectType.Single
                    .SelectTypeCol = SelectType.None
                    .SelectTypeRow = SelectType.None
                    .TipStyleScroll = Infragistics.Win.UltraWinGrid.TipStyle.Hide
                    With .ActiveCellAppearance
                        .BackColor = Drawing.Color.White
                        .ForeColor = Drawing.Color.Black
                    End With
                    With .ActiveRowAppearance
                        .BackColor = Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(235, Byte), Integer))
                        .ForeColor = Drawing.Color.Teal
                    End With
                    With .CellAppearance
                        .BackColor = Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(235, Byte), Integer))
                        '.BorderColor = Drawing.Color.DarkGray
                        With .FontData
                            .Bold = DefaultableBoolean.True
                            .Name = "Arial"
                            .SizeInPoints = 14
                        End With
                        .TextTrimming = TextTrimming.EllipsisCharacter
                        .TextVAlign = VAlign.Middle
                    End With
                    With .HeaderAppearance
                        With .FontData
                            .Bold = DefaultableBoolean.True
                            .Name = "Arial"
                            .SizeInPoints = 10
                        End With
                        .TextHAlign = HAlign.Center
                    End With
                    With .SelectedRowAppearance
                        .BackColor = Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(235, Byte), Integer))
                        .ForeColor = Drawing.Color.Teal
                    End With
                End With
                .ScrollStyle = ScrollStyle.Immediate
                .ScrollBounds = ScrollBounds.ScrollToFill

                'HEADER_HEADER_HEADER_HEADER_HEADER_HEADER_HEADER_HEADER_HEADER_HEADER_HEADER_HEADER_HEADER_HEADER
                With .Bands(0)

                    .ColHeadersVisible = False
                    .GroupHeadersVisible = False
                    .ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.[True]
                    .Header.Enabled = False
                    .Indentation = 0
                    .IndentationGroupByRow = 0
                    .IndentationGroupByRowExpansionIndicator = 0
                    .RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout

                    With .Override
                        .DefaultRowHeight = 1
                        .HeaderAppearance.FontData.SizeInPoints = 1
                        .MinRowHeight = 1
                        .RowAppearance.FontData.SizeInPoints = 1
                        .RowSizingArea = RowSizingArea.EntireRow
                        .RowSizingAutoMaxLines = 0
                        .RowSpacingAfter = 0
                        .RowSpacingBefore = 0
                    End With

                    .Columns("ID").Hidden = True
                    .Columns("HeaderText").Hidden = True

                End With

                'GiftCard_GiftCard_GiftCard_GiftCard_GiftCard_GiftCard_GiftCard_GiftCard_GiftCard_GiftCard_GiftCard_GiftCard_GiftCard
                With .Bands(1)

                    .ColHeaderLines = 2
                    .ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.[True]
                    .Indentation = 0
                    .IndentationGroupByRow = 0
                    .IndentationGroupByRowExpansionIndicator = 0
                    .RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout

                    With .Override
                        .AllowUpdate = Infragistics.Win.DefaultableBoolean.True
                        .BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid
                        .CellAppearance.BorderColor = Drawing.Color.Teal
                        .RowAppearance.BorderColor = Drawing.Color.Teal
                        .CellClickAction = CellClickAction.EditAndSelectText
                        With .HeaderAppearance
                            .BackColor = Drawing.Color.LightSeaGreen
                            .BackColor2 = Drawing.Color.Teal
                            .BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
                            .FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                            .FontData.SizeInPoints = 10
                            .ForeColor = Drawing.Color.White
                            .TextHAlign = Infragistics.Win.HAlign.Center
                        End With
                        '.RowAlternateAppearance.BackColor = Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(235, Byte), Integer))
                        .RowSelectors = DefaultableBoolean.False
                        '.RowSelectorHeaderStyle = RowSelectorHeaderStyle.SeparateElement
                        '.RowSelectorNumberStyle = RowSelectorNumberStyle.RowIndex
                    End With

                    Try
                        .Columns.Add("Del", " ")
                    Catch
                    End Try

                    .Columns("ID").Hidden = True
                    .Columns("CustomerID").Hidden = True
                    .Columns("IorA").Hidden = True
                    .Columns("StatusMessage").Hidden = True
                    .Columns("GCInfoIndex").Hidden = True

                    .Columns("Del").SortIndicator = SortIndicator.Disabled
                    .Columns("GiftCardID").SortIndicator = SortIndicator.Disabled
                    .Columns("GiftCardType").SortIndicator = SortIndicator.Disabled
                    .Columns("CustomerID").SortIndicator = SortIndicator.Disabled
                    .Columns("IorA").SortIndicator = SortIndicator.Disabled
                    .Columns("CardAmount").SortIndicator = SortIndicator.Disabled
                    .Columns("AddAmount").SortIndicator = SortIndicator.Disabled
                    .Columns("Amount").SortIndicator = SortIndicator.Disabled

                    With .Columns("Del")
                        .Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
                        .ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
                        .NullText = "Load"
                        .CellButtonAppearance.FontData.SizeInPoints = 24
                        .CellButtonAppearance.ForeColor = Drawing.Color.Red
                        .CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                        .CellAppearance.FontData.SizeInPoints = 24
                        .CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
                        .CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
                        .Header.Caption = ""
                        .Header.VisiblePosition = 0
                        .MaxWidth = 48
                        .MinWidth = 48
                        .TabStop = False
                        .Width = 48
                    End With
                    With .Columns("LineNumber")
                        .CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                        .CellAppearance.ForeColor = Drawing.Color.Teal
                        .CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                        .Header.Caption = "#"
                        .Header.VisiblePosition = 1
                        .MaxWidth = 28
                        .MinWidth = 28
                        .TabStop = False
                        .Width = 28
                    End With
                    With .Columns("GiftCardID")
                        .CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                        .CellAppearance.ForeColor = Drawing.Color.Black
                        .CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                        .Header.Caption = "Gift Card ID"
                        .Header.VisiblePosition = 2
                        .TabStop = True
                        .Width = 200
                    End With
                    With .Columns("GiftCardType")
                        .ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
                        .CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                        .CellAppearance.ForeColor = Drawing.Color.Teal
                        .CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
                        .EditorComponent = cbGiftCardType
                        .Header.Caption = "Gift Card"
                        .Header.VisiblePosition = 3
                        .TabStop = True
                        .Width = 172
                    End With
                    With .Columns("CardAmount")
                        .CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                        .CellAppearance.FontData.SizeInPoints = 16
                        .CellAppearance.ForeColor = Drawing.Color.Teal
                        .CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                        .Format = "C2"
                        .Header.Caption = "Amount" & vbCrLf & "On Card"
                        .Header.VisiblePosition = 5
                        .MaxWidth = 110
                        .MinWidth = 110
                        .TabStop = False
                        .Width = 110
                    End With
                    With .Columns("AddAmount")
                        .CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                        .CellAppearance.FontData.SizeInPoints = 16
                        .CellAppearance.ForeColor = Drawing.Color.Black
                        .CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                        .Format = "C2"
                        .Header.Caption = "Amount" & vbCrLf & "To Add"
                        .Header.VisiblePosition = 6
                        .MaxWidth = 110
                        .MinWidth = 110
                        .TabStop = True
                        .Width = 110
                    End With
                    With .Columns("Amount")
                        .CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                        .CellAppearance.FontData.SizeInPoints = 16
                        .CellAppearance.ForeColor = Drawing.Color.Teal
                        .CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                        .Format = "C2"
                        .Header.Caption = "Total" & vbCrLf & "Amount"
                        .Header.VisiblePosition = 7
                        .MaxWidth = 110
                        .MinWidth = 110
                        .TabStop = False
                        .Width = 110
                    End With

                End With

                'TOTAL_TOTAL_TOTAL_TOTAL_TOTAL_TOTAL_TOTAL_TOTAL_TOTAL_TOTAL_TOTAL_TOTAL_TOTAL_TOTAL_TOTAL
                With .Bands(2)

                    .ColHeadersVisible = False
                    .GroupHeadersVisible = False
                    .ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.[True]
                    .Indentation = 0
                    .IndentationGroupByRow = 0
                    .IndentationGroupByRowExpansionIndicator = 0
                    .RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout

                    With .Override
                        .ActiveRowAppearance.ForeColor = Drawing.Color.Teal
                        .BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid
                        .DefaultRowHeight = 40
                        .CellAppearance.BorderColor = Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
                        .CellAppearance.BorderColor2 = Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
                        .RowAppearance.BorderColor = Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
                        .RowAppearance.ForeColor = Drawing.Color.Teal
                        .RowSelectors = DefaultableBoolean.False
                        '.RowSelectorHeaderStyle = RowSelectorHeaderStyle.SeparateElement
                        '.RowSelectorNumberStyle = RowSelectorNumberStyle.None
                        .SelectedRowAppearance.ForeColor = Drawing.Color.Teal
                    End With

                    .Columns("ID").Hidden = True

                    With .Columns("Description")
                        .CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                        .CellAppearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
                        .CellAppearance.FontData.SizeInPoints = 12
                        .CellAppearance.BackColor = Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
                        .CellAppearance.ForeColor = Drawing.Color.Teal
                        .CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                        .Header.Caption = "Description"
                        .Header.VisiblePosition = 0
                        .Width = 466
                    End With
                    With .Columns("CardTotal")
                        .CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                        .CellAppearance.FontData.SizeInPoints = 16
                        .CellAppearance.ForeColor = Drawing.Color.Teal
                        .CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                        .Format = "C2"
                        .Header.Caption = "CardTotal"
                        .Header.VisiblePosition = 1
                        .MaxWidth = 110
                        .MinWidth = 110
                        .Width = 110
                    End With
                    With .Columns("AddTotal")
                        .CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                        .CellAppearance.FontData.SizeInPoints = 16
                        .CellAppearance.ForeColor = Drawing.Color.Teal
                        .CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                        .Format = "C2"
                        .Header.Caption = "AddTotal"
                        .Header.VisiblePosition = 2
                        .MaxWidth = 110
                        .MinWidth = 110
                        .Width = 110
                    End With
                    With .Columns("Total")
                        .CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                        .CellAppearance.FontData.SizeInPoints = 16
                        .CellAppearance.ForeColor = Drawing.Color.Teal
                        .CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                        .Format = "C2"
                        .Header.Caption = "Total"
                        .Header.VisiblePosition = 3
                        .MaxWidth = 110
                        .MinWidth = 110
                        .Width = 110
                    End With

                End With

            End With

            .ResumeLayout()

        End With

    End Sub  'grdGiftCards_InitializeLayout

    '----------------------------------------------------------------------------------------------
    ' Load our GiftCardInfo into the grid dropdown
    '----------------------------------------------------------------------------------------------
    Private Sub LoadGiftCardDropdown()
        For Each gc As DSGiftCardInfo.GiftCardInfoRow In gGCI.GiftCardInfo.Rows
            Dim vli As ValueListItem = New ValueListItem
            vli.DataValue = gc.ButtonPosition - 1
            vli.DisplayText = gc.DropdownCaption
            cbGiftCardType.Items.Add(vli)
        Next
        cbGiftCardType.SelectedIndex = 0
    End Sub  'LoadGiftCardDropdown

#End Region  'Form Load and Initialization

#Region " Gift Card Buttons "

    Private Sub btnGiftCard1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGiftCard1.Click
        ProcessGCButtonClick(0)
    End Sub  'btnGiftCard1_Click

    Private Sub btnGiftCard2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGiftCard2.Click
        ProcessGCButtonClick(1)
    End Sub  'btnGiftCard2_Click

    Private Sub btnGiftCard3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGiftCard3.Click
        ProcessGCButtonClick(2)
    End Sub  'btnGiftCard3_Click

    Private Sub btnGiftCard4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGiftCard4.Click
        ProcessGCButtonClick(3)
    End Sub  'btnGiftCard4_Click

    Private Sub btnGiftCard5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGiftCard5.Click
        ProcessGCButtonClick(4)
    End Sub  'btnGiftCard5_Click

    Private Sub btnGiftCard6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGiftCard6.Click
        ProcessGCButtonClick(5)
    End Sub  'btnGiftCard6_Click

    Private Sub ProcessGCButtonClick(ByVal indx As Integer)
        With grdGiftCards.ActiveRow
            Dim rowcomplete As Boolean = (.Cells("GiftCardID").Text <> "") And (.Cells("GiftCardType").Text <> "")
            If gGCI.GiftCardInfo(indx).FixedOrVariable = "V" Then
                If .Cells("CardAmount").Text = "$0.00" Then
                    rowcomplete = False
                End If
            End If
            If rowcomplete = True Then
                grdGiftCards.PerformAction(UltraGridAction.ExitEditMode, False, False)
                AddANewLine()
                grdGiftCards.PerformAction(UltraGridAction.LastRowInBand)
                grdGiftCards.PerformAction(UltraGridAction.ActivateCell)
            End If
        End With
        With grdGiftCards
            'MessageBox.Show(mGiftCards.GiftCard(0).GiftCardID & "#" & mGiftCards.GiftCard(0).CardAmount)
            .ActiveRow.Cells("GCInfoIndex").Value = indx
            .ActiveRow.Cells("GiftCardType").Value = gGCI.GiftCardInfo(indx).DropdownCaption
            .ActiveRow.Update()
            .ActiveCell = grdGiftCards.ActiveRow.Cells("GiftCardID")
            If .ActiveCell.Selected = False Then
                .PerformAction(UltraGridAction.ToggleCellSel, False, False)
            End If
            .PerformAction(UltraGridAction.EnterEditMode, False, False)
            'MessageBox.Show(mGiftCards.GiftCard(0).GiftCardID & "#" & mGiftCards.GiftCard(0).CardAmount)
        End With
    End Sub  'ProcessGCButtonClick

#End Region  'Gift Card Buttons

#Region " GiftCards Grid "

    '------------------------------------------------------------------------------
    ' Set ActiveRow and ActiveCell on form entry 
    '------------------------------------------------------------------------------
    Private Sub ActivateGridEditMode()
        grdGiftCards.Focus()
        grdGiftCards.ActiveRow = grdGiftCards.Rows(0)
        grdGiftCards.ActiveRow = grdGiftCards.ActiveRow.ChildBands(0).Rows(0)
        grdGiftCards.ActiveCell = grdGiftCards.ActiveRow.Cells("GiftCardID")
        grdGiftCards.PerformAction(UltraGridAction.ToggleCellSel, False, False)
        grdGiftCards.PerformAction(UltraGridAction.EnterEditMode, False, False)
    End Sub  'ActivateGridEditMode

    '------------------------------------------------------------------------------
    ' Set values and formatting when rows are updated
    '------------------------------------------------------------------------------
    Private Sub grdGiftCards_InitializeRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles grdGiftCards.InitializeRow
        Select Case e.Row.Band.Index
            Case 0 '=====================Header======================================
                e.Row.ExpandAll()
            Case 1 '=====================GiftCards=====================================
                e.Row.Cells("Del").Value = "X"
                e.Row.Cells("LineNumber").Value = e.Row.Index + 1
                e.Row.Cells("Amount").Value = CDec(e.Row.Cells("CardAmount").Value) + CDec(e.Row.Cells("AddAmount").Value)
                CalculateGiftCardTotal()
            Case 2 '=====================Total=======================================
                ' set column widths based on Band(1)
                With grdGiftCards.DisplayLayout.Bands(1)
                    e.Row.Cells("ID").Column.Width = .Columns("ID").Width
                    e.Row.Cells("Description").Column.Width = .Columns("Del").Width + .Columns("LineNumber").Width + .Columns("GiftCardID").Width + .Columns("GiftCardType").Width
                    e.Row.Cells("CardTotal").Column.Width = .Columns("CardAmount").Width
                    e.Row.Cells("AddTotal").Column.Width = .Columns("AddAmount").Width
                    e.Row.Cells("Total").Column.Width = .Columns("Amount").Width
                End With
        End Select
    End Sub  'grdGiftCards_InitializeRow

    '------------------------------------------------------------------------------
    ' Insert a new line
    '------------------------------------------------------------------------------
    Private Sub AddLineToGiftCardsGrid()
        Dim dr As DSGiftCard.GiftCardRow = CType(mGiftCards.GiftCard.NewRow(), DSGiftCard.GiftCardRow)
        dr.ID = 1
        dr.LineNumber = 0
        dr.GiftCardID = ""
        If gGCI.GiftCardInfo.Count = 1 Then
            dr.GiftCardType = gGCI.GiftCardInfo(0).DropdownCaption
        Else
            dr.GiftCardType = ""
        End If
        dr.GCInfoIndex = 0
        dr.StatusMessage = ""
        dr.CustomerID = mCustomerID
        dr.IorA = ""
        dr.CardAmount = 0D
        dr.AddAmount = 0D
        dr.Amount = 0D
        mGiftCards.GiftCard.Rows.Add(dr)
    End Sub  'AddLineToGiftCardsGrid

    '------------------------------------------------------------------------------
    ' Delete a line - need to display at least one line so headers will show
    '------------------------------------------------------------------------------
    Private Sub DeleteGiftCardFromGrid(ByRef thisRow As UltraWinGrid.UltraGridRow)
        mGiftCards.GiftCard(thisRow.Index).Delete()
        If mGiftCards.GiftCard.Count = 0 Then
            AddLineToGiftCardsGrid()
        End If
        CalculateGiftCardTotal()
        RenumberLines()
        grdGiftCards.Refresh()
    End Sub  'DeleteGiftCardFromGrid

    '------------------------------------------------------------------------------
    ' Need to renumber lines if we delete one
    '------------------------------------------------------------------------------
    Private Sub RenumberLines()
        Dim lineNbr As Short = 1
        For Each aRow As DSGiftCard.GiftCardRow In mGiftCards.GiftCard.Rows
            aRow.LineNumber = lineNbr
            lineNbr += 1S
        Next
    End Sub  'RenumberLines

    '------------------------------------------------------------------------------
    ' Iterate through GiftCards table and add up Amounts
    '------------------------------------------------------------------------------
    Private Sub CalculateGiftCardTotal()

        If grdGiftCards.Rows.Count > 0 Then
            grdGiftCards.DisplayLayout.RowScrollRegions(0).Scroll(RowScrollAction.Bottom)
        End If

        mCardTotal = 0D
        mAddTotal = 0D
        mGiftCardTotal = 0D
        For Each aRow As DSGiftCard.GiftCardRow In mGiftCards.GiftCard.Rows
            mCardTotal += aRow.CardAmount
            mAddTotal += aRow.AddAmount
            mGiftCardTotal += aRow.Amount
        Next
        With mGiftCards.Total(0)
            .CardTotal = mCardTotal
            .AddTotal = mAddTotal
            .Total = mGiftCardTotal
        End With

    End Sub  'CalculateGiftCardTotal

    '------------------------------------------------------------------------------
    ' Process grid row delete buttons ("X")
    '------------------------------------------------------------------------------
    Private Sub grdGiftCards_ClickCellButton(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdGiftCards.ClickCellButton
        If e.Cell.Column Is grdGiftCards.DisplayLayout.Bands(1).Columns("Del") Then
            Dim dr As DialogResult = MessageBox.Show( _
                    "Delete gift card?", _
                    "Confirm", _
                    MessageBoxButtons.YesNo, _
                    MessageBoxIcon.Question)
            Select Case dr
                Case Windows.Forms.DialogResult.Yes
                    DeleteGiftCardFromGrid(e.Cell.Row)
                    Exit Sub
                Case Windows.Forms.DialogResult.No
                    Exit Sub
            End Select
        End If
    End Sub  'grdGiftCards_ClickCellButton

    '------------------------------------------------------------------------------
    ' Make keys behave the way we want
    '------------------------------------------------------------------------------
    Private Sub grdGiftCards_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdGiftCards.KeyDown
        Select Case e.KeyCode
            Case Keys.Tab, Keys.Enter, Keys.Right
                ProcessGridKeyStrokes()
                e.Handled = True
            Case Keys.Left
                grdGiftCards.PerformAction(UltraGridAction.ExitEditMode, False, False)
                grdGiftCards.PerformAction(UltraGridAction.PrevCellByTab, False, False)
                e.Handled = True
                grdGiftCards.PerformAction(UltraGridAction.EnterEditMode, False, False)
            Case Keys.Down
                grdGiftCards.PerformAction(UltraGridAction.ExitEditMode, False, False)
                grdGiftCards.PerformAction(UltraGridAction.BelowCell, False, False)
                e.Handled = True
                grdGiftCards.PerformAction(UltraGridAction.EnterEditMode, False, False)
            Case Keys.Up
                grdGiftCards.PerformAction(UltraGridAction.ExitEditMode, False, False)
                grdGiftCards.PerformAction(UltraGridAction.AboveCell, False, False)
                e.Handled = True
                grdGiftCards.PerformAction(UltraGridAction.EnterEditMode, False, False)
        End Select
    End Sub  'grdGiftCards_KeyDown

    '------------------------------------------------------------------------------
    ' Controls which grid field focus goes to, and whether a new line is inserted.
    ' Processing for the grid is mainly in this routine and in grdGiftCards_AfterCellUpdate,
    ' plus a little bit in grdGiftCards_InitializeRow.
    ' We can't take the processing out of grdGiftCards_AfterCellUpdate and put it here,
    ' because this routine doesn't fire if the field is updated programmatically.
    '------------------------------------------------------------------------------
    Private Sub ProcessGridKeyStrokes()
        With grdGiftCards
            .UpdateData()
            Dim indx As Integer = CInt(.ActiveRow.Cells("GCInfoIndex").Value)
            If .ActiveCell IsNot Nothing Then
                Dim giftCardIDEntered As Boolean = False
                If Trim(CStr(.ActiveRow.Cells("GiftCardID").Text)) <> "" Then
                    giftCardIDEntered = True
                End If
                Dim giftCardTypeEntered As Boolean = False
                If Trim(CStr(.ActiveRow.Cells("GiftCardType").Text)) <> "" Then
                    giftCardTypeEntered = True
                End If
                Dim isActivate As Boolean = False
                If .ActiveRow.Cells("IorA").Text = "A" Then
                    isActivate = True
                End If
                Select Case .ActiveCell.Column.Key
                    Case "GiftCardID"
                        Select Case giftCardIDEntered
                            Case True
                                Select Case giftCardTypeEntered
                                    Case True   'Type entered
                                        Select Case isActivate
                                            Case True
                                                If LastRowOfGrid(grdGiftCards) Then
                                                    AddANewLine()
                                                End If
                                                TabToField("GiftCardID")
                                            Case False
                                                TabToField("AddAmount")
                                        End Select
                                    Case False  'Type not entered
                                        If gGCI.GiftCardInfo.Count = 1 Then
                                            .ActiveRow.Cells("GiftCardType").Value = gGCI.GiftCardInfo(0).DropdownCaption
                                            Select Case isActivate
                                                Case True
                                                    If LastRowOfGrid(grdGiftCards) Then
                                                        AddANewLine()
                                                    End If
                                                    TabToField("GiftCardID")
                                                Case False
                                                    TabToField("AddAmount")
                                            End Select
                                        Else
                                            Select Case isActivate
                                                Case True
                                                    If LastRowOfGrid(grdGiftCards) Then
                                                        AddANewLine()
                                                    End If
                                                    TabToField("GiftCardID")
                                                Case False
                                                    TabToField("GiftCardType")
                                            End Select
                                        End If
                                End Select
                            Case False  'ID not entered
                                ' Stay in GiftCardID field
                        End Select
                    Case "GiftCardType"
                        Select Case giftCardTypeEntered
                            Case True
                                Select Case giftCardIDEntered
                                    Case True
                                        Select Case isActivate
                                            Case True
                                                If LastRowOfGrid(grdGiftCards) Then
                                                    AddANewLine()
                                                End If
                                                TabToField("GiftCardID")
                                            Case False
                                                If gGCI.GiftCardInfo(indx).FixedOrVariable = "F" Then
                                                    If LastRowOfGrid(grdGiftCards) Then
                                                        AddANewLine()
                                                    End If
                                                    TabToField("GiftCardID")
                                                Else
                                                    TabToField("AddAmount")
                                                End If
                                        End Select
                                    Case False  'ID not entered
                                        BackUpToField("GiftCardID")
                                End Select
                            Case False  'Type not entered
                                ' Stay in GiftCardType field
                        End Select
                    Case "AddAmount"
                        Select Case giftCardIDEntered
                            Case True
                                Select Case giftCardTypeEntered
                                    Case True
                                        If LastRowOfGrid(grdGiftCards) Then
                                            AddANewLine()
                                        End If
                                        TabToField("GiftCardID")
                                    Case False
                                        BackUpToField("GiftCardType")
                                End Select
                            Case False  'ID not entered
                                If CDec(.ActiveCell.Text) = 0D Then
                                    JumpToOKButton()
                                Else
                                    BackUpToField("GiftCardID")
                                End If
                        End Select
                End Select
            End If
        End With
    End Sub  'ProcessGridKeyStrokes

    '------------------------------------------------------------------------------
    ' Process changes to grid fields.
    ' Main processing routine for the grid, along with ProcessGridKeyStrokes().
    ' See additional notes on grid processing in ProcessGridKeyStrokes(), above.
    '------------------------------------------------------------------------------
    Private Sub grdGiftCards_AfterCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdGiftCards.AfterCellUpdate
        Try
            Dim indx As Integer = CInt(e.Cell.Row.Cells("GCInfoIndex").Value)
            Select Case e.Cell.Column.Key
                Case "GiftCardID"

                    'Check for blank input
                    If CStr(e.Cell.Value) <> Trim(CStr(e.Cell.Value)) Then
                        e.Cell.Value = Trim(CStr(e.Cell.Value))
                    End If
                    If CStr(e.Cell.Value) = "" Then Exit Select

                    'Strip out extra characters from scanner
                    Dim extractedScan As String = CommonRoutines.ExtractScan(CStr(e.Cell.Value))
                    If extractedScan <> CStr(e.Cell.Value) Then
                        e.Cell.Value = extractedScan
                    End If

                    'Validate against our pattern for length / content
                    If CommonRoutines.ValidateScan(extractedScan) = False Then
                        MsgBox("Invalid scan content or length." & vbCrLf & "Scan: " & extractedScan, MsgBoxStyle.Exclamation, "GiftCard")
                        e.Cell.Value = ""
                        Exit Select
                    End If

                    'Check for dups
                    Dim aRow As UltraGridRow = grdGiftCards.Rows(0)
                    aRow = aRow.GetChild(Infragistics.Win.UltraWinGrid.ChildRow.First)
                    Do
                        If aRow.Index <> e.Cell.Row.Index AndAlso CStr(aRow.Cells("GiftCardID").Value) = CStr(e.Cell.Value) Then
                            MsgBox("Card/Ticket has already been entered.", MsgBoxStyle.Exclamation, "GiftCard")
                            e.Cell.Value = ""
                            Exit Select
                        End If
                        If aRow.HasNextSibling = True Then
                            aRow = aRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next)
                        Else
                            Exit Do
                        End If
                    Loop

                    'Check ticket status
                    Dim sr As New StadisRequest
                    With sr
                        .SiteID = gSiteID
                        .TenderTypeID = 1
                        .TenderID = CStr(e.Cell.Value)
                        .Amount = 0
                        .ReferenceNumber = ""
                        .VendorID = gVendorID
                        .LocationID = gLocationID
                        .RegisterID = CommonRoutines.BOGetStrAttributeValueByName(mAdapter, 0, "Invoice Workstion")
                        .ReceiptID = CommonRoutines.BOGetStrAttributeValueByName(mAdapter, 0, "Invoice Number")
                        .VendorCashier = CommonRoutines.BOGetStrAttributeValueByName(mAdapter, 0, "Cashier")
                    End With
                    Dim ts As TicketStatus = CommonRoutines.StadisAPI.GetTicketStatus(sr)
                    If ts.ReturnCode < 0 Then
                        If ts.ReturnCode <> -3 Then
                            MsgBox("Unable to validate card...", MsgBoxStyle.Exclamation, "GiftCard")
                            e.Cell.Value = ""
                            Exit Select
                        Else
                            If Trim(e.Cell.Row.Cells("GiftCardType").Text) <> "" And gGCI.GiftCardInfo(indx).FixedOrVariable = "F" Then
                                e.Cell.Row.Cells("IorA").Value = "I"
                            Else
                                e.Cell.Row.Cells("IorA").Value = "I"
                                e.Cell.Row.Cells("CardAmount").Value = 0D
                                e.Cell.Row.Cells("AddAmount").Value = 0D
                                e.Cell.Row.Cells("AddAmount").Activation = Activation.AllowEdit
                            End If
                            Exit Select
                        End If
                    End If

                    If ts.TicketExists = False Then
                        If ts.EventTicketExists = True Then
                            MsgBox("No matching Ticket for EventTicket...", MsgBoxStyle.Information, "GiftCard")
                            e.Cell.Value = ""
                            Exit Select
                        End If
                        If Trim(e.Cell.Row.Cells("GiftCardType").Text) <> "" And gGCI.GiftCardInfo(indx).FixedOrVariable = "F" Then
                            e.Cell.Row.Cells("IorA").Value = "I"
                        Else
                            e.Cell.Row.Cells("IorA").Value = "I"
                            e.Cell.Row.Cells("CardAmount").Value = 0D
                            e.Cell.Row.Cells("AddAmount").Value = 0D
                            e.Cell.Row.Cells("AddAmount").Activation = Activation.AllowEdit
                        End If
                        Exit Select
                    End If
                    If ts.TicketExists = True Then
                        Select Case ts.TicketEventTicketStatusID
                            Case ACTIVE
                                MsgBox("Gift Card is already in use...", MsgBoxStyle.Information, "GiftCard")
                                e.Cell.Value = ""
                                Exit Select
                            Case PENDING
                                e.Cell.Row.Cells("IorA").Value = "A"
                                e.Cell.Row.Cells("CardAmount").Value = ts.SVA1Balance
                                e.Cell.Row.Cells("AddAmount").Value = 0D
                                e.Cell.Row.Cells("AddAmount").Activation = Activation.NoEdit
                                If ts.TicketGCALU <> "" Then
                                    Dim ix As Integer = LookupGCInfoUsingALU(ts.CustomerStatus1)
                                    e.Cell.Row.Cells("GCInfoIndex").Value = ix
                                    e.Cell.Row.Cells("GiftCardType").Value = gGCI.GiftCardInfo(ix).DropdownCaption
                                End If
                            Case Else
                                MsgBox("Gift Card is not in a valid ts...", MsgBoxStyle.Information, "GiftCard")
                                e.Cell.Value = ""
                                Exit Select
                        End Select
                    End If

                Case "GiftCardType"
                    Dim ix As Integer = LookupGCInfoUsingDDCaption(e.Cell.Row.Cells("GiftCardType").Text)
                    e.Cell.Row.Cells("GCInfoIndex").Value = ix
                    If gGCI.GiftCardInfo(indx).FixedOrVariable = "F" Then
                        e.Cell.Row.Cells("CardAmount").Value = gGCI.GiftCardInfo(indx).IAMinAmount
                    Else
                        e.Cell.Row.Cells("CardAmount").Value = 0D
                    End If

                Case "IorA"
                    Select Case CStr(e.Cell.Value)
                        Case "I"
                            If gGCI.GiftCardInfo(indx).AllowIssue = False Then
                                e.Cell.Row.CancelUpdate()
                                e.Cell.Row.Cells("AddAmount").Value = 0D
                                MessageBox.Show("Cards must already exist in the system, in order to be activated.", "STADIS")
                                Exit Sub
                            End If
                        Case "A"
                            If gGCI.GiftCardInfo(indx).AllowActivate = False Then
                                e.Cell.Row.CancelUpdate()
                                e.Cell.Row.Cells("AddAmount").Value = 0D
                                MessageBox.Show("Activation of cards is not allowed.", "STADIS")
                                Exit Sub
                            End If
                        Case Else

                    End Select

                Case "AddAmount"
                    Select Case CStr(e.Cell.Row.Cells("IorA").Value)
                        Case "I"
                            If CDec(e.Cell.Value) < gGCI.GiftCardInfo(indx).IAMinAmount OrElse CDec(e.Cell.Value) > gGCI.GiftCardInfo(indx).IAMaxAmount Then
                                If CDec(e.Cell.Value) < gGCI.GiftCardInfo(indx).IAMinAmount Then
                                    e.Cell.Row.Cells("AddAmount").Value = gGCI.GiftCardInfo(indx).IAMinAmount
                                ElseIf CDec(e.Cell.Value) > gGCI.GiftCardInfo(indx).IAMaxAmount Then
                                    e.Cell.Row.Cells("AddAmount").Value = gGCI.GiftCardInfo(indx).IAMaxAmount
                                End If
                                If gGCI.GiftCardInfo(indx).IAMinAmount = gGCI.GiftCardInfo(indx).IAMaxAmount Then
                                    e.Cell.Row.Cells("AddAmount").Value = 0D
                                    MessageBox.Show("Issue amount is fixed at " & gGCI.GiftCardInfo(indx).IAMinAmount.ToString("""$""#,##0.00") & ".", "STADIS")
                                Else
                                    If CDec(e.Cell.Value) < gGCI.GiftCardInfo(indx).IAMinAmount Then
                                        e.Cell.Row.Cells("AddAmount").Value = gGCI.GiftCardInfo(indx).IAMinAmount
                                    Else
                                        e.Cell.Row.Cells("AddAmount").Value = gGCI.GiftCardInfo(indx).IAMaxAmount
                                    End If
                                    MessageBox.Show("Issue amount must be between " & gGCI.GiftCardInfo(indx).IAMinAmount.ToString("""$""#,##0.00") & " and " & gGCI.GiftCardInfo(indx).IAMaxAmount.ToString("""$""#,##0.00") & ".", "STADIS")
                                End If
                                Exit Sub
                            End If
                        Case "A"
                            e.Cell.Row.Cells("AddAmount").Value = 0D
                            MessageBox.Show("Additional funds may not be added on an activation.", "STADIS")
                            Exit Sub
                        Case Else
                    End Select

                Case Else

            End Select  'for column
        Catch ex As Exception
            MessageBox.Show("Error while updating STADIS gift card(s)." & vbCrLf & ex.Message, "STADIS")
        End Try
    End Sub  'grdGiftCards_AfterCellUpdate

    '------------------------------------------------------------------------------
    ' Are we on the last row of the grid?
    '------------------------------------------------------------------------------
    Private Function LastRowOfGrid(ByRef grid As UltraWinGrid.UltraGrid) As Boolean
        If grid.ActiveRow.Index = mGiftCards.GiftCard.Count - 1 Then
            Return True
        Else
            Return False
        End If
    End Function  'LastRowOfGrid

    '------------------------------------------------------------------------------
    ' Put cursor in named field
    '------------------------------------------------------------------------------
    Private Sub TabToField(ByVal fieldKey As String)
        With grdGiftCards
            Do
                .PerformAction(UltraGridAction.NextCellByTab)
            Loop Until .ActiveCell.Column.Key = fieldKey
            If .ActiveCell.Selected = False Then
                .PerformAction(UltraGridAction.ToggleCellSel, False, False)
            End If
            .PerformAction(UltraGridAction.EnterEditMode, False, False)
        End With
    End Sub  'TabToField

    Private Sub BackUpToField(ByVal fieldKey As String)
        With grdGiftCards
            Do
                .PerformAction(UltraGridAction.PrevCellByTab)
            Loop Until .ActiveCell.Column.Key = fieldKey
            If .ActiveCell.Selected = False Then
                .PerformAction(UltraGridAction.ToggleCellSel, False, False)
            End If
            .PerformAction(UltraGridAction.EnterEditMode, False, False)
        End With
    End Sub  'BackUpToField

    Private Sub AddANewLine()
        grdGiftCards.PerformAction(UltraGridAction.ExitEditMode, False, False)
        AddLineToGiftCardsGrid()
    End Sub  'AddANewLine

    '------------------------------------------------------------------------------
    ' Leave grid and jump to OK button
    '------------------------------------------------------------------------------
    Private Sub JumpToOKButton()
        grdGiftCards.PerformAction(UltraGridAction.ExitEditMode, False, False)
        btnOK.Focus()
    End Sub  'JumpToOKButton

    '------------------------------------------------------------------------------
    ' Gift Card Info table lookup routines
    '------------------------------------------------------------------------------
    Private Function LookupGCInfoUsingALU(ByVal alu As String) As Integer
        Dim ix As Integer = 0
        For Each gRow As DSGiftCardInfo.GiftCardInfoRow In gGCI.GiftCardInfo.Rows
            If gRow.RProLookupALU = alu Then
                ix = gGCI.GiftCardInfo.Rows.IndexOf(gRow)
                Exit For
            End If
        Next
        Return ix
    End Function  'LookupGCInfoUsingALU

    Private Function LookupGCInfoUsingDDCaption(ByVal ddCaption As String) As Integer
        Dim ix As Integer = 0
        For Each gRow As DSGiftCardInfo.GiftCardInfoRow In gGCI.GiftCardInfo.Rows
            If gRow.DropdownCaption = ddCaption Then
                ix = gGCI.GiftCardInfo.Rows.IndexOf(gRow)
                Exit For
            End If
        Next
        Return ix
    End Function  'LookupGCInfoUsingDDCaption

#End Region  'GiftCards Grid

#Region " Other Methods "

    '------------------------------------------------------------------------------
    ' Cancel button - pack up and get out
    '------------------------------------------------------------------------------
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub  'btnCancel_Click

    '------------------------------------------------------------------------------
    ' OK button - Add tenders we created, then get out
    '------------------------------------------------------------------------------
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        grdGiftCards.PerformAction(UltraGridAction.ExitEditMode, False, False)
        grdGiftCards.PerformAction(UltraGridAction.NextCellByTab)
        AddOurItemsAndTenderToRPro()
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub  'btnOK_Click

    '------------------------------------------------------------------------------
    ' Take entries in GiftCards grid and add them as items to Retail Pro
    '------------------------------------------------------------------------------
    Private Sub AddOurItemsAndTenderToRPro()
        Try
            'Create an item for each Gift Card
            Dim invoiceHandle As Integer = 0
            CommonRoutines.BORefreshRecord(mAdapter, invoiceHandle)
            Dim itemHandle As Integer = mAdapter.GetReferenceBOForAttribute(invoiceHandle, "Items")
            CommonRoutines.BOOpen(mAdapter, itemHandle)
            For Each aRow As DSGiftCard.GiftCardRow In mGiftCards.GiftCard.Rows
                If Trim(aRow.GiftCardID) <> "" Then
                    CommonRoutines.BOInsert(mAdapter, itemHandle)
                    CommonRoutines.BOSetAttributeValueByName(mAdapter, itemHandle, "Lookup ALU", gGCI.GiftCardInfo(aRow.GCInfoIndex).RProLookupALU)
                    CommonRoutines.BOSetAttributeValueByName(mAdapter, itemHandle, "Item Note1", "STADIS\" & aRow.GiftCardID & "\" & aRow.IorA & "\" & mCustomerID & "\" & aRow.Amount.ToString("""$""#,##0.00"))
                    Dim len As Integer = aRow.GiftCardID.Length
                    Dim lastfour As String = aRow.GiftCardID.Substring(len - 4, 4)
                    CommonRoutines.BOSetAttributeValueByName(mAdapter, itemHandle, "Item Note2", lastfour)
                    CommonRoutines.BOSetAttributeValueByName(mAdapter, itemHandle, "Item Note3", aRow.Amount.ToString("""$""#,##0.00"))
                    CommonRoutines.BOSetAttributeValueByName(mAdapter, itemHandle, "Quantity", 1)
                    CommonRoutines.BOSetAttributeValueByName(mAdapter, itemHandle, "Price", 0D)
                    CommonRoutines.BOSetAttributeValueByName(mAdapter, itemHandle, "Tax Amount", 0D)
                    CommonRoutines.BOPost(mAdapter, itemHandle)
                End If
            Next
            Select Case gFeeOrTenderForIssueOffset
                Case "Fee"
                    If mGiftCardTotal > 0D Then
                        CommonRoutines.BOOpen(mAdapter, invoiceHandle)
                        Dim fee As Decimal = CommonRoutines.BOGetDecAttributeValueByName(mAdapter, invoiceHandle, "Fee Amt")
                        fee += mGiftCardTotal
                        CommonRoutines.BOSetAttributeValueByName(mAdapter, invoiceHandle, "Fee Amt", fee)
                        'CommonRoutines.BOSetAttributeValueByName(mAdapter, invoiceHandle, "Fee Name", "STADIS")
                    End If
                Case "Tender"
                    Dim tenderHandle As Integer = mAdapter.GetReferenceBOForAttribute(0, "Tenders")
                    If mGiftCardTotal > 0D Then
                        CommonRoutines.BOOpen(mAdapter, tenderHandle)
                        CommonRoutines.BOInsert(mAdapter, tenderHandle)
                        CommonRoutines.BOSetAttributeValueByName(mAdapter, tenderHandle, "TENDER_TYPE", gStadisTenderType)
                        CommonRoutines.BOSetAttributeValueByName(mAdapter, tenderHandle, "AMT", 0 - mGiftCardTotal)
                        CommonRoutines.BOSetAttributeValueByName(mAdapter, tenderHandle, "TRANSACTION_ID", "")
                        CommonRoutines.BOSetAttributeValueByName(mAdapter, tenderHandle, "MANUAL_REMARK", "@OF # Offset for card issue/activate")
                        If gStadisTenderType = RetailPro.Plugins.TenderTypes.ttGiftCard Then
                            CommonRoutines.BOSetAttributeValueByName(mAdapter, tenderHandle, "CRD_EXP_MONTH", 1)
                            CommonRoutines.BOSetAttributeValueByName(mAdapter, tenderHandle, "CRD_EXP_YEAR", 1)
                            CommonRoutines.BOSetAttributeValueByName(mAdapter, tenderHandle, "CRD_TYPE", 1)
                            CommonRoutines.BOSetAttributeValueByName(mAdapter, tenderHandle, "CRD_PRESENT", 1)
                        End If
                        CommonRoutines.BOPost(mAdapter, tenderHandle)
                    End If
                    CommonRoutines.BORefreshRecord(mAdapter, invoiceHandle)
                Case Else
                    MessageBox.Show("Invalid offset option specified.", "STADIS")
            End Select
            mCustomerID = gDefaultCustomerID
        Catch ex As Exception
            MessageBox.Show("Error while adding STADIS gift card(s)." & vbCrLf & ex.Message, "STADIS")
            mCustomerID = ""
        End Try
    End Sub  'AddOurItemsAndTenderToRPro

    '------------------------------------------------------------------------------
    ' Invoked when form is closed for any reason - makes sure we release pointers 
    '------------------------------------------------------------------------------
    Private Sub FrmIssue_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        mAdapter = Nothing
        mGiftCards = Nothing
        mCardTotal = Nothing
        mAddTotal = Nothing
        mGiftCardTotal = Nothing
    End Sub  'FrmIssue_Closing

#End Region  'Other Methods

End Class  'FrmIssue