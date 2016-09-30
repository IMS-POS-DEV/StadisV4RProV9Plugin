Imports CommonV4
Imports CommonV4.CommonRoutines
Imports CommonV4.WebReference
Imports RetailPro.CustomPluginClasses
Imports RetailPro.Plugins
Imports System.Drawing
Imports System.Text
Imports System.Text.RegularExpressions
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
'----------------------------------------------------------------------------------------------
'   Class: FrmRedeem
'    Type: Windows Form
' Purpose: Collects Stadis tender information.  Invoked by ButtonRedeem.
'----------------------------------------------------------------------------------------------
Friend Class FrmRedeem

    '#Region " Data Declarations "

    '    Private mInvoiceHandle As Integer = 0
    '    Private mItemHandle As Integer = -99
    '    Private mTenderHandle As Integer = -99

    '    Private mTenders As DSTender
    '    Private mTenderTotal As Decimal = 0D
    '    Private mAmountDue As Decimal = 0D
    '    Private mRemainingAmountDue As Decimal = 0D
    '    Private mIsInputComplete As Boolean = False
    '    Private mIsChargeGood As Boolean = False
    '    Private mBusy As Boolean = False

    '    Private mReferenceNumber As String = ""
    '    Private mVendorID As String = ""
    '    Private mLocationID As String = ""
    '    Private mRegisterID As String = ""
    '    Private mVendorCashier As String = ""
    '    Private mReceiptID As String = ""

    '    'Const ALLSTATUSESGOOD As Integer = 0
    '    'Const TICKETISINACTIVE As Integer = -1
    '    'Const CUSTOMERISINACTIVE As Integer = -2
    '    'Const TICKETNOTFOUND As Integer = -3
    '    'Const UNKNOWN As Integer = 0
    '    'Const ACTIVE As Integer = 1
    '    'Const PENDING As Integer = 3

    '    Private mAdapter As RetailPro.Plugins.IPluginAdapter
    '    Friend Property Adapter() As RetailPro.Plugins.IPluginAdapter
    '        Get
    '            Return mAdapter
    '        End Get
    '        Set(ByVal value As RetailPro.Plugins.IPluginAdapter)
    '            mAdapter = value
    '        End Set
    '    End Property

    '#End Region  'Data Declarations

    '#Region " Form Load and Initialization "

    '    '----------------------------------------------------------------------------------------------
    '    ' Called when form is loaded
    '    '----------------------------------------------------------------------------------------------
    '    Private Sub FrmRedeem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '        GetReceiptFields()
    '        SetUpGridAndConnectToTendersDataset()
    '    End Sub  'FrmRedeem_Load

    '    Private Sub FrmRedeem_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
    '        If Trim(gFormLogoImage) <> "stadislogo.png" Then
    '            pbLogo.Image = New Bitmap(gFormLogoImage)
    '        End If
    '    End Sub  'FrmRedeem_Paint

    '    '----------------------------------------------------------------------------------------------
    '    ' Get Amount Due from RPro and initialize fields used to ID transaction (RegisterID, etc.)
    '    '----------------------------------------------------------------------------------------------
    '    Private Sub GetReceiptFields()
    '        Try
    '            ' Get pointers to receipt components
    '            CommonRoutines.BORefreshRecord(mAdapter, 0)
    '            mItemHandle = mAdapter.GetReferenceBOForAttribute(mInvoiceHandle, "Items")
    '            mTenderHandle = mAdapter.GetReferenceBOForAttribute(mInvoiceHandle, "Tenders")
    '            mReferenceNumber = CommonRoutines.BOGetStrAttributeValueByName(mAdapter, mInvoiceHandle, "Invoice Number")
    '            mVendorID = gVendorID
    '            mLocationID = gLocationID
    '            mRegisterID = CommonRoutines.BOGetStrAttributeValueByName(mAdapter, mInvoiceHandle, "Invoice Workstion")
    '            mVendorCashier = CommonRoutines.BOGetStrAttributeValueByName(mAdapter, mInvoiceHandle, "Cashier")
    '            mReceiptID = CommonRoutines.BOGetStrAttributeValueByName(mAdapter, mInvoiceHandle, "Invoice Number")
    '            mAmountDue = CommonRoutines.BOGetDecAttributeValueByName(mAdapter, 0, "Amount Due")
    '        Catch ex As Exception
    '            MessageBox.Show(ex.Message)
    '        End Try
    '        mRemainingAmountDue = mAmountDue
    '        lblRemainingAmount.Text = mAmountDue.ToString("""$""#,##0.00")
    '    End Sub  'GetAmountDue

    '    '----------------------------------------------------------------------------------------------
    '    ' Setup related to grid 
    '    '----------------------------------------------------------------------------------------------
    '    Private Sub SetUpGridAndConnectToTendersDataset()
    '        grdTenders.DrawFilter = New MyDrawFilter()
    '        mTenders = New DSTender
    '        MakeGridEnterActLikeTab()
    '        AddHeaderAndTotalRecsToTendersTable()
    '        grdTenders.DataSource = mTenders
    '        CalculateTenderTotal()
    '        RenumberLines()
    '        grdTenders.Refresh()
    '        grdTenders.BeginInvoke(New MethodInvoker(AddressOf ActivateGridEditMode))
    '    End Sub  'SetUpGridAndConnectToTendersDataset

    '    '----------------------------------------------------------------------------------------------
    '    ' If grid is in focus, we want the Enter key to act like a Tab key
    '    '----------------------------------------------------------------------------------------------
    '    Private Sub MakeGridEnterActLikeTab()
    '        Dim newKam As Infragistics.Win.UltraWinGrid.GridKeyActionMapping
    '        For Each ugkam As Infragistics.Win.UltraWinGrid.GridKeyActionMapping In grdTenders.KeyActionMappings
    '            If ugkam.KeyCode = Keys.Tab Then
    '                newKam = New Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, ugkam.ActionCode, ugkam.StateDisallowed, ugkam.StateRequired, ugkam.SpecialKeysDisallowed, ugkam.SpecialKeysRequired)
    '                grdTenders.KeyActionMappings.Add(newKam)
    '            End If
    '        Next
    '    End Sub  'MakeGridEnterActLikeTab

    '    '----------------------------------------------------------------------------------------------
    '    ' Create our invisible anchor Header rec, one Tender rec, and our two Total recs
    '    '----------------------------------------------------------------------------------------------
    '    Private Sub AddHeaderAndTotalRecsToTendersTable()
    '        Dim dr1 As DSTender.HeaderRow = CType(mTenders.Header.NewRow(), DSTender.HeaderRow)
    '        dr1.ID = 1
    '        mTenders.Header.Rows.Add(dr1)
    '        LoadAnyPreviousStadisTenders()
    '        AddLineToTendersGrid()
    '        Dim dr3a As DSTender.TotalRow = CType(mTenders.Total.NewRow(), DSTender.TotalRow)
    '        dr3a.ID = 1
    '        dr3a.Description = "Tender Total  >>> "
    '        mTenders.Total.Rows.Add(dr3a)
    '        Dim dr3b As DSTender.TotalRow = CType(mTenders.Total.NewRow(), DSTender.TotalRow)
    '        dr3b.ID = 1
    '        dr3b.Description = "Remaining Amount Due  >>> "
    '        mTenders.Total.Rows.Add(dr3b)
    '    End Sub

    '    '----------------------------------------------------------------------------------------------
    '    ' If they go out of the tenders screen and come back, reload tenders to grid so they don't get
    '    ' entered twice.
    '    '----------------------------------------------------------------------------------------------
    '    Private Sub LoadAnyPreviousStadisTenders()
    '        Try
    '            If mTenderHandle < 0 Then  'no tenders
    '                Exit Sub
    '            End If
    '            CommonRoutines.BOOpen(mAdapter, mTenderHandle)
    '            Dim retcode As Integer = mAdapter.BOFirst(mTenderHandle)
    '            If retcode <> RetailPro.Plugins.PluginError.peSuccess Then
    '                If retcode = RetailPro.Plugins.PluginError.peUnableToReadFirstRow Then
    '                    Exit Sub
    '                Else
    '                    MessageBox.Show("Error while loading previous STADIS tender(s)." & vbCrLf & "RPro retcode = " & retcode.ToString, "STADIS")
    '                    Exit Sub
    '                End If
    '            End If
    '            While Not mAdapter.EOF(mTenderHandle)
    '                Dim tenderType As Integer = CommonRoutines.BOGetIntAttributeValueByName(mAdapter, mTenderHandle, "TENDER_TYPE")
    '                If tenderType = gStadisTenderType Then
    '                    Dim rmk As String = CommonRoutines.BOGetStrAttributeValueByName(mAdapter, mTenderHandle, "MANUAL_REMARK")
    '                    Dim tType As String = Regex.Match(rmk, ".+(?=#)").ToString
    '                    Dim dr As DSTender.TenderRow = CType(mTenders.Tender.NewRow(), DSTender.TenderRow)
    '                    With dr
    '                        .ID = 1
    '                        .IsValidated = False
    '                        .IsAddedToRPro = True
    '                        .IsCharged = True
    '                        .StadisAuthorizationID = ""
    '                        .TenderType = tType
    '                        .LineNumber = 0
    '                        .TenderID = CommonRoutines.BOGetStrAttributeValueByName(mAdapter, mTenderHandle, "TRANSACTION_ID")
    '                        .StatusMessage = ""
    '                        .TenderAmount = CommonRoutines.BOGetDecAttributeValueByName(mAdapter, mTenderHandle, "AMT")
    '                        .AvailableAmount = 0D
    '                        .BalanceAfter = 0D
    '                    End With
    '                    Dim alreadyEntered As Boolean = False
    '                    For Each dr1 As DSTender.TenderRow In DSTender.Tender
    '                        If dr.TenderID = dr1.TenderID Then
    '                            alreadyEntered = True
    '                        End If
    '                    Next
    '                    If alreadyEntered = False Then
    '                        mTenders.Tender.Rows.Add(dr)
    '                    End If
    '                End If
    '                mAdapter.BONext(mTenderHandle)
    '            End While
    '        Catch ex As Exception
    '            MessageBox.Show("Error while loading STADIS tender(s)." & vbCrLf & ex.Message, "STADIS")
    '        End Try
    '    End Sub  'LoadAnyPreviousStadisTenders

    '    '----------------------------------------------------------------------------------------------
    '    ' Grid setup
    '    '----------------------------------------------------------------------------------------------
    '    Private Sub grdTenders_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdTenders.InitializeLayout

    '        With grdTenders

    '            .SuspendLayout()
    '            .DataSource = dsTenderBindingSource
    '            .UpdateMode = UpdateMode.OnCellChangeOrLostFocus

    '            With .DisplayLayout
    '                With .Appearance
    '                    .BackColor = Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
    '                    '.BorderColor = Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
    '                    .FontData.Name = "Arial"
    '                    .FontData.SizeInPoints = 14
    '                End With
    '                .AutoFitStyle = AutoFitStyle.ResizeAllColumns
    '                .BorderStyle = Infragistics.Win.UIElementBorderStyle.None
    '                .CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
    '                .ColumnChooserEnabled = DefaultableBoolean.False
    '                .InterBandSpacing = 0
    '                .MaxColScrollRegions = 1
    '                .MaxRowScrollRegions = 1
    '                With .Override
    '                    .AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
    '                    .AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None
    '                    .AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed
    '                    .AllowUpdate = Infragistics.Win.DefaultableBoolean.True
    '                    .BorderStyleCell = UIElementBorderStyle.Dotted
    '                    .BorderStyleRow = UIElementBorderStyle.Solid
    '                    .CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect
    '                    .CellPadding = 0
    '                    .ExpansionIndicator = ShowExpansionIndicator.Never
    '                    .HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
    '                    .HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
    '                    .RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
    '                    .RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed
    '                    .SelectTypeCell = SelectType.Single
    '                    .SelectTypeCol = SelectType.None
    '                    .SelectTypeRow = SelectType.None
    '                    .TipStyleScroll = Infragistics.Win.UltraWinGrid.TipStyle.Hide
    '                    With .ActiveCellAppearance
    '                        .BackColor = Drawing.Color.White
    '                        .ForeColor = Drawing.Color.Black
    '                    End With
    '                    With .ActiveRowAppearance
    '                        .BackColor = Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(235, Byte), Integer))
    '                        .ForeColor = Drawing.Color.Teal
    '                    End With
    '                    With .CellAppearance
    '                        .BackColor = Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(235, Byte), Integer))
    '                        '.BorderColor = Drawing.Color.DarkGray
    '                        With .FontData
    '                            .Bold = DefaultableBoolean.True
    '                            .Name = "Arial"
    '                            .SizeInPoints = 14
    '                        End With
    '                        .TextTrimming = TextTrimming.EllipsisCharacter
    '                        .TextVAlign = VAlign.Middle
    '                    End With
    '                    With .HeaderAppearance
    '                        With .FontData
    '                            .Bold = DefaultableBoolean.True
    '                            .Name = "Arial"
    '                            .SizeInPoints = 10
    '                        End With
    '                        .TextHAlign = HAlign.Center
    '                    End With
    '                    With .SelectedRowAppearance
    '                        .BackColor = Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(235, Byte), Integer))
    '                        .ForeColor = Drawing.Color.Teal
    '                    End With
    '                End With
    '                .ScrollStyle = ScrollStyle.Immediate
    '                .ScrollBounds = ScrollBounds.ScrollToFill

    '                'HEADER_HEADER_HEADER_HEADER_HEADER_HEADER_HEADER_HEADER_HEADER_HEADER_HEADER_HEADER_HEADER_HEADER
    '                With .Bands(0)

    '                    .ColHeadersVisible = False
    '                    .GroupHeadersVisible = False
    '                    .ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.[True]
    '                    .Header.Enabled = False
    '                    .Indentation = 0
    '                    .IndentationGroupByRow = 0
    '                    .IndentationGroupByRowExpansionIndicator = 0
    '                    .RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout

    '                    With .Override
    '                        .DefaultRowHeight = 1
    '                        .HeaderAppearance.FontData.SizeInPoints = 1
    '                        .MinRowHeight = 1
    '                        .RowAppearance.FontData.SizeInPoints = 1
    '                        .RowSizingArea = RowSizingArea.EntireRow
    '                        .RowSizingAutoMaxLines = 0
    '                        .RowSpacingAfter = 0
    '                        .RowSpacingBefore = 0
    '                    End With

    '                    .Columns("ID").Hidden = True
    '                    .Columns("HeaderText").Hidden = True

    '                End With

    '                'TENDER_TENDER_TENDER_TENDER_TENDER_TENDER_TENDER_TENDER_TENDER_TENDER_TENDER_TENDER_TENDER
    '                With .Bands(1)

    '                    .ColHeaderLines = 2
    '                    .ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.[True]
    '                    .Indentation = 0
    '                    .IndentationGroupByRow = 0
    '                    .IndentationGroupByRowExpansionIndicator = 0
    '                    .RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout

    '                    With .Override
    '                        .AllowUpdate = Infragistics.Win.DefaultableBoolean.True
    '                        .BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid
    '                        .CellAppearance.BorderColor = Drawing.Color.Teal
    '                        .RowAppearance.BorderColor = Drawing.Color.Teal
    '                        .CellClickAction = CellClickAction.EditAndSelectText
    '                        With .HeaderAppearance
    '                            .BackColor = Drawing.Color.LightSeaGreen
    '                            .BackColor2 = Drawing.Color.Teal
    '                            .BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    '                            .FontData.Bold = Infragistics.Win.DefaultableBoolean.True
    '                            .FontData.SizeInPoints = 10
    '                            .ForeColor = Drawing.Color.White
    '                            .TextHAlign = Infragistics.Win.HAlign.Center
    '                        End With
    '                        '.RowAlternateAppearance.BackColor = Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(235, Byte), Integer))
    '                        .RowSelectors = DefaultableBoolean.False
    '                        '.RowSelectorHeaderStyle = RowSelectorHeaderStyle.SeparateElement
    '                        '.RowSelectorNumberStyle = RowSelectorNumberStyle.RowIndex
    '                    End With

    '                    .Columns("ID").Hidden = True
    '                    .Columns("IsValidated").Hidden = True
    '                    .Columns("IsCharged").Hidden = True
    '                    .Columns("IsAddedToRPro").Hidden = True
    '                    .Columns("StadisAuthorizationID").Hidden = True
    '                    .Columns("TenderType").Hidden = True

    '                    Try
    '                        .Columns.Add("Del", " ")
    '                    Catch
    '                    End Try

    '                    .Columns("Del").SortIndicator = SortIndicator.Disabled
    '                    .Columns("LineNumber").SortIndicator = SortIndicator.Disabled
    '                    .Columns("TenderID").SortIndicator = SortIndicator.Disabled
    '                    .Columns("StatusMessage").SortIndicator = SortIndicator.Disabled
    '                    .Columns("AvailableAmount").SortIndicator = SortIndicator.Disabled
    '                    .Columns("BalanceAfter").SortIndicator = SortIndicator.Disabled
    '                    .Columns("TenderAmount").SortIndicator = SortIndicator.Disabled

    '                    With .Columns("Del")
    '                        .Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
    '                        .ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
    '                        .NullText = "Load"
    '                        .CellButtonAppearance.FontData.SizeInPoints = 24
    '                        .CellButtonAppearance.ForeColor = Drawing.Color.Red
    '                        .CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
    '                        .CellAppearance.FontData.SizeInPoints = 24
    '                        .CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
    '                        .CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
    '                        .Header.Caption = ""
    '                        .Header.VisiblePosition = 0
    '                        .MaxWidth = 48
    '                        .MinWidth = 48
    '                        .TabStop = False
    '                        .Width = 48
    '                    End With
    '                    With .Columns("LineNumber")
    '                        .CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
    '                        .CellAppearance.ForeColor = Drawing.Color.Teal
    '                        .CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
    '                        .Header.Caption = "#"
    '                        .Header.VisiblePosition = 1
    '                        .MaxWidth = 32
    '                        .MinWidth = 32
    '                        .TabStop = False
    '                        .Width = 32
    '                    End With
    '                    With .Columns("TenderID")
    '                        .CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
    '                        .CellAppearance.ForeColor = Drawing.Color.Black
    '                        .CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
    '                        .Header.Caption = "Gift Card ID / Ticket Barcode"
    '                        .Header.VisiblePosition = 2
    '                        .Width = 212
    '                    End With
    '                    With .Columns("StatusMessage")
    '                        .CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
    '                        .CellAppearance.ForeColor = Drawing.Color.Teal
    '                        .CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
    '                        .Header.Caption = "Message"
    '                        .Header.VisiblePosition = 3
    '                        .MaxWidth = 100
    '                        .MinWidth = 100
    '                        .TabStop = False
    '                        .Width = 100
    '                    End With
    '                    With .Columns("AvailableAmount")
    '                        '.PerformAutoResize()
    '                        .CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
    '                        .CellAppearance.ForeColor = Drawing.Color.Teal
    '                        .CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
    '                        .Format = "C2"
    '                        .Header.Caption = "Available" & vbCrLf & "Amount"
    '                        .Header.VisiblePosition = 4
    '                        .InvalidValueBehavior = InvalidValueBehavior.RevertValueAndRetainFocus
    '                        .MaxWidth = 100
    '                        .MinWidth = 100
    '                        .TabStop = False
    '                        .Width = 100
    '                    End With
    '                    With .Columns("BalanceAfter")
    '                        '.PerformAutoResize()
    '                        .CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
    '                        .CellAppearance.ForeColor = Drawing.Color.Teal
    '                        .CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
    '                        .Format = "C2"
    '                        .Header.Caption = "Balance" & vbCrLf & "After Chg"
    '                        .Header.VisiblePosition = 5
    '                        .InvalidValueBehavior = InvalidValueBehavior.RevertValueAndRetainFocus
    '                        .MaxWidth = 100
    '                        .MinWidth = 100
    '                        .TabStop = False
    '                        .Width = 100
    '                    End With
    '                    With .Columns("TenderAmount")
    '                        '.PerformAutoResize()
    '                        .CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
    '                        .CellAppearance.FontData.SizeInPoints = 16
    '                        .CellAppearance.ForeColor = Drawing.Color.Black
    '                        .CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
    '                        .Format = "C2"
    '                        .Header.Caption = "Tender" & vbCrLf & "Amount"
    '                        .Header.VisiblePosition = 6
    '                        .InvalidValueBehavior = InvalidValueBehavior.RevertValueAndRetainFocus
    '                        .MaxWidth = 116
    '                        .MinWidth = 116
    '                        .Width = 116
    '                    End With

    '                End With

    '                'TOTAL_TOTAL_TOTAL_TOTAL_TOTAL_TOTAL_TOTAL_TOTAL_TOTAL_TOTAL_TOTAL_TOTAL_TOTAL_TOTAL_TOTAL
    '                With .Bands(2)

    '                    .ColHeadersVisible = False
    '                    .GroupHeadersVisible = False
    '                    .ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.[True]
    '                    .Indentation = 0
    '                    .IndentationGroupByRow = 0
    '                    .IndentationGroupByRowExpansionIndicator = 0
    '                    .RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout

    '                    With .Override
    '                        .ActiveRowAppearance.ForeColor = Drawing.Color.Teal
    '                        .BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid
    '                        .DefaultRowHeight = 40
    '                        .CellAppearance.BorderColor = Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
    '                        .RowAppearance.BorderColor = Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
    '                        .RowAppearance.ForeColor = Drawing.Color.Teal
    '                        .RowSelectors = DefaultableBoolean.False
    '                        '.RowSelectorHeaderStyle = RowSelectorHeaderStyle.SeparateElement
    '                        '.RowSelectorNumberStyle = RowSelectorNumberStyle.None
    '                        .SelectedRowAppearance.ForeColor = Drawing.Color.Teal
    '                    End With

    '                    .Columns("ID").Hidden = True

    '                    With .Columns("Description")
    '                        .CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
    '                        .CellAppearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
    '                        .CellAppearance.FontData.SizeInPoints = 12
    '                        .CellAppearance.BackColor = Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
    '                        .CellAppearance.ForeColor = Drawing.Color.Teal
    '                        .CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
    '                        .Header.Caption = "Description"
    '                        .Header.VisiblePosition = 0
    '                        .Width = 392
    '                    End With
    '                    With .Columns("Total")
    '                        .CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
    '                        .CellAppearance.FontData.SizeInPoints = 16
    '                        .CellAppearance.ForeColor = Drawing.Color.Teal
    '                        .CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
    '                        .Format = "C2"
    '                        .Header.Caption = "Total"
    '                        .Header.VisiblePosition = 1
    '                        .MaxWidth = 116
    '                        .MinWidth = 116
    '                        .Width = 116
    '                    End With

    '                End With

    '            End With

    '            .ResumeLayout()

    '        End With

    '    End Sub  'grdTenders_InitializeLayout

    '#End Region  'Form Load and Initialization

    '#Region " Tenders Grid "

    '    '------------------------------- Tenders Grid ---------------------------------
    '    ' The Infragistics grid can display a totals line, but it doesn't give you as 
    '    ' much flexibility as I wanted, so I created the hierarchical DSTenders dataset,
    '    ' which contains a Tenders table, a Totals table, and a Header table to tie the
    '    ' two together.  The Header table is grid band(0), which is hidden and doesn't
    '    ' display.  Its only purpose is to tie the other two tables together as 
    '    ' sub-records under the one Header record so they'll display in the same grid.  
    '    ' The Tenders are grid band(1) and the Totals are grid band(2).
    '    ' The Totals band doesn't display its column headers, just detail lines.
    '    ' Because they're separate bands, we can format each independently.  Also
    '    ' because they're separate sub-bands under the one Header record, the Totals 
    '    ' always display after the Tenders.
    '    '------------------------------------------------------------------------------

    '    '------------------------------------------------------------------------------
    '    ' Set ActiveRow and ActiveCell on form entry 
    '    '------------------------------------------------------------------------------
    '    Private Sub ActivateGridEditMode()
    '        With grdTenders
    '            .Focus()
    '            .ActiveRow = .Rows(0)
    '            .ActiveRow = .ActiveRow.ChildBands(0).Rows(0)
    '            .ActiveCell = .ActiveRow.Cells("TenderID")
    '            .PerformAction(UltraGridAction.ToggleCellSel, False, False)
    '            .PerformAction(UltraGridAction.EnterEditMode, False, False)
    '        End With
    '    End Sub  'ActivateGridEditMode

    '    '------------------------------------------------------------------------------
    '    ' Set values and formatting when rows are updated
    '    '------------------------------------------------------------------------------
    '    Private Sub grdTenders_InitializeRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles grdTenders.InitializeRow
    '        Select Case e.Row.Band.Index
    '            Case 0 '=============Header=(doesn't display)============================
    '                e.Row.ExpandAll()
    '            Case 1 '=====================Tenders=====================================
    '                If Not (e.Row.Cells("IsAddedToRPro").Value Is Nothing) AndAlso CBool(e.Row.Cells("IsAddedToRPro").Value) = True Then
    '                    If e.Row.DataChanged = True Then
    '                        e.Row.CancelUpdate()
    '                    End If
    '                End If
    '                e.Row.Cells("Del").Value = "X"
    '                e.Row.Cells("LineNumber").Value = e.Row.Index + 1
    '                CalculateTenderTotal()
    '            Case 2 '=====================Total=======================================
    '                ' set column widths based on Band(1)
    '                With grdTenders.DisplayLayout.Bands(1)
    '                    e.Row.Cells("ID").Column.Width = .Columns("ID").Width
    '                    e.Row.Cells("Description").Column.Width = .Columns("Del").Width + .Columns("LineNumber").Width + .Columns("TenderID").Width + .Columns("StatusMessage").Width + .Columns("AvailableAmount").Width + .Columns("BalanceAfter").Width
    '                    e.Row.Cells("Total").Column.Width = .Columns("TenderAmount").Width
    '                End With
    '        End Select
    '    End Sub  'grdTenders_InitializeRow

    '    '------------------------------------------------------------------------------
    '    ' Insert a new line
    '    '------------------------------------------------------------------------------
    '    Private Sub AddLineToTendersGrid()
    '        Dim dr As DSTender.TenderRow = CType(mTenders.Tender.NewRow(), DSTender.TenderRow)
    '        With dr
    '            .ID = 1
    '            .IsValidated = False
    '            .IsCharged = False
    '            .StadisAuthorizationID = ""
    '            .TenderType = "@TK"
    '            .LineNumber = 0
    '            .TenderID = ""
    '            .StatusMessage = ""
    '            .TenderAmount = 0D
    '            .AvailableAmount = 0D
    '            .BalanceAfter = 0D
    '        End With
    '        mTenders.Tender.Rows.Add(dr)
    '    End Sub  'AddLineToTendersGrid

    '    '------------------------------------------------------------------------------
    '    ' Delete a line - need to display at least one line so headers will show
    '    '------------------------------------------------------------------------------
    '    Private Sub DeleteTenderFromGrid(ByRef thisRow As UltraWinGrid.UltraGridRow)
    '        If CBool(thisRow.Cells("IsAddedToRPro").Value) = True Then
    '            DeleteTenderFromRPro(CStr(thisRow.Cells("TenderID").Value))
    '        End If
    '        mTenders.Tender(thisRow.Index).Delete()
    '        If mTenders.Tender.Count = 0 Then
    '            AddLineToTendersGrid()
    '        End If
    '        If CBool(thisRow.Cells("IsCharged").Value) = True Then
    '            Dim sr As New StadisRequest
    '            With sr
    '                .SiteID = gSiteID
    '                .StadisAuthorizationID = CStr(thisRow.Cells("StadisAuthorizationID").Value)
    '                .VendorID = gVendorID
    '                .LocationID = gLocationID
    '            End With
    '            Dim sys As StadisReply() = CommonRoutines.StadisAPI.SVAccountReverse(sr)
    '            If sys(0).ReturnCode < 0 Then
    '                MessageBox.Show("Unable to back out Stadis charge.", "STADIS")
    '            End If
    '        End If
    '        CalculateTenderTotal()
    '        RenumberLines()
    '        grdTenders.Refresh()
    '    End Sub  'DeleteTenderFromGrid

    '    '------------------------------------------------------------------------------
    '    ' Need to renumber lines if we delete one
    '    '------------------------------------------------------------------------------
    '    Private Sub RenumberLines()
    '        Dim lineNbr As Short = 1
    '        For Each aRow As DSTender.TenderRow In mTenders.Tender.Rows
    '            aRow.LineNumber = lineNbr
    '            lineNbr += 1S
    '        Next
    '    End Sub  'RenumberLines

    '    '------------------------------------------------------------------------------
    '    ' Iterate through Tenders table and add up TenderAmounts
    '    '------------------------------------------------------------------------------
    '    Private Sub CalculateTenderTotal()

    '        If grdTenders.Rows.Count > 0 Then
    '            grdTenders.DisplayLayout.RowScrollRegions(0).Scroll(RowScrollAction.Bottom)
    '        End If

    '        mTenderTotal = 0D
    '        For Each aRow As DSTender.TenderRow In mTenders.Tender.Rows
    '            If Not IsDBNull(aRow.TenderAmount) Then
    '                mTenderTotal += aRow.TenderAmount
    '            End If
    '        Next
    '        mTenders.Total(0).Total = mTenderTotal
    '        CalculateRemainingAmountDue()
    '        mTenders.Total(1).Total = mRemainingAmountDue

    '    End Sub  'CalculateTenderTotal

    '    '------------------------------------------------------------------------------
    '    ' Calculate unpaid balance, highlight if not zero
    '    '------------------------------------------------------------------------------
    '    Private Sub CalculateRemainingAmountDue()
    '        mRemainingAmountDue = mAmountDue - mTenderTotal
    '        Select Case mRemainingAmountDue
    '            Case Is = 0
    '                grdTenders.DisplayLayout.Bands(2).Columns("Total").CellAppearance.ForeColor = Drawing.Color.Teal
    '            Case Else
    '                grdTenders.DisplayLayout.Bands(2).Columns("Total").CellAppearance.ForeColor = Drawing.Color.Red
    '        End Select
    '    End Sub  'CalculateRemainingAmountDue

    '    '------------------------------------------------------------------------------
    '    ' Process grid row delete buttons ("X")
    '    '------------------------------------------------------------------------------
    '    Private Sub grdTenders_ClickCellButton(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdTenders.ClickCellButton
    '        If e.Cell.Column Is grdTenders.DisplayLayout.Bands(1).Columns("Del") Then
    '            Dim dr As DialogResult = MessageBox.Show( _
    '                    "Delete tender?", _
    '                    "Confirm", _
    '                    MessageBoxButtons.YesNo, _
    '                    MessageBoxIcon.Question)
    '            Select Case dr
    '                Case Windows.Forms.DialogResult.Yes
    '                    DeleteTenderFromGrid(e.Cell.Row)
    '                    Exit Sub
    '                Case Windows.Forms.DialogResult.No
    '                    Exit Sub
    '            End Select
    '        End If
    '    End Sub  'grdTenders_ClickCellButton

    '    '------------------------------------------------------------------------------
    '    ' Make keys behave the way we want
    '    '------------------------------------------------------------------------------
    '    Private Sub grdTenders_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdTenders.KeyDown
    '        Select Case e.KeyCode
    '            Case Keys.Tab, Keys.Enter, Keys.Right
    '                ProcessGridKeyStrokes()
    '                e.Handled = True
    '            Case Keys.Left
    '                grdTenders.PerformAction(UltraGridAction.ExitEditMode, False, False)
    '                grdTenders.PerformAction(UltraGridAction.PrevCellByTab, False, False)
    '                e.Handled = True
    '                grdTenders.PerformAction(UltraGridAction.EnterEditMode, False, False)
    '            Case Keys.Down
    '                grdTenders.PerformAction(UltraGridAction.ExitEditMode, False, False)
    '                grdTenders.PerformAction(UltraGridAction.BelowCell, False, False)
    '                e.Handled = True
    '                grdTenders.PerformAction(UltraGridAction.EnterEditMode, False, False)
    '            Case Keys.Up
    '                grdTenders.PerformAction(UltraGridAction.ExitEditMode, False, False)
    '                grdTenders.PerformAction(UltraGridAction.AboveCell, False, False)
    '                e.Handled = True
    '                grdTenders.PerformAction(UltraGridAction.EnterEditMode, False, False)
    '        End Select
    '    End Sub  'grdTenders_KeyDown

    '    '------------------------------------------------------------------------------
    '    ' Insert a new line if there was an Enter or Tab
    '    '------------------------------------------------------------------------------
    '    Private Sub ProcessGridKeyStrokes()
    '        With grdTenders
    '            If .ActiveCell IsNot Nothing Then

    '                'Set flags
    '                Dim isTenderIDEntered As Boolean = If(Trim(CStr(.ActiveRow.Cells("TenderID").Text)) = "", False, True)
    '                Dim isTenderAmountEntered As Boolean = If(CDec(.ActiveRow.Cells("TenderAmount").Value) = 0D, False, True)
    '                Dim isLastRow As Boolean = If(.ActiveRow.Index = mTenders.Tender.Count - 1, True, False)

    '                Select Case .ActiveCell.Column.Key
    '                    Case "TenderID"
    '                        Select Case isTenderAmountEntered
    '                            Case True
    '                                With .ActiveRow
    '                                    If CBool(.Cells("IsCharged").Value) = False Then
    '                                        AddTenderToRPro(grdTenders.ActiveRow)
    '                                        DoSVAccountCharge(grdTenders.ActiveRow)
    '                                    End If
    '                                End With
    '                                If isLastRow Then
    '                                    grdTenders.PerformAction(UltraGridAction.ExitEditMode, False, False)
    '                                    CalculateTenderTotal()
    '                                    If isTenderIDEntered = False AndAlso mRemainingAmountDue = 0D Then
    '                                        JumpToOKButton()
    '                                    Else
    '                                        AddLineToTendersGrid()
    '                                        TabToField("TenderID")
    '                                        grdTenders.PerformAction(UltraGridAction.EnterEditMode, False, False)
    '                                    End If
    '                                Else
    '                                    TabToField("TenderID")
    '                                End If
    '                            Case False
    '                                grdTenders.PerformAction(UltraGridAction.ExitEditMode, False, False)
    '                                TabToField("TenderAmount")
    '                                'RemoveHandler grdTenders.AfterCellUpdate, AddressOf grdTenders_AfterCellUpdate
    '                                .ActiveRow.Cells("TenderAmount").Value = mRemainingAmountDue
    '                                .ActiveRow.Update()
    '                                'AddHandler grdTenders.AfterCellUpdate, AddressOf grdTenders_AfterCellUpdate
    '                                '
    '                                CalculateTenderTotal()
    '                                If isLastRow Then
    '                                    grdTenders.PerformAction(UltraGridAction.ExitEditMode, False, False)
    '                                    If mRemainingAmountDue = 0D Then
    '                                        JumpToOKButton()
    '                                    Else
    '                                        AddLineToTendersGrid()
    '                                        TabToField("TenderID")
    '                                        grdTenders.PerformAction(UltraGridAction.EnterEditMode, False, False)
    '                                    End If
    '                                Else
    '                                    TabToField("TenderID")
    '                                    grdTenders.PerformAction(UltraGridAction.EnterEditMode, False, False)
    '                                End If
    '                                '
    '                                'grdTenders.PerformAction(UltraGridAction.EnterEditMode, False, False)
    '                        End Select
    '                    Case "TenderAmount"
    '                        If IsDBNull(.ActiveCell.Text) OrElse .ActiveCell.Text = "" Then
    '                            .ActiveCell.Value = 0D
    '                        End If
    '                        CalculateTenderTotal()
    '                        Select Case isTenderIDEntered
    '                            Case True
    '                                With .ActiveRow
    '                                    If CBool(.Cells("IsCharged").Value) = False Then
    '                                        AddTenderToRPro(grdTenders.ActiveRow)
    '                                        DoSVAccountCharge(grdTenders.ActiveRow)
    '                                    End If
    '                                End With
    '                                If isLastRow Then
    '                                    grdTenders.PerformAction(UltraGridAction.ExitEditMode, False, False)
    '                                    If mRemainingAmountDue = 0D Then
    '                                        JumpToOKButton()
    '                                    Else
    '                                        AddLineToTendersGrid()
    '                                        TabToField("TenderID")
    '                                        grdTenders.PerformAction(UltraGridAction.EnterEditMode, False, False)
    '                                    End If
    '                                Else
    '                                    TabToField("TenderID")
    '                                End If
    '                            Case False
    '                                If isTenderAmountEntered = False Then
    '                                    JumpToOKButton()
    '                                Else
    '                                    grdTenders.PerformAction(UltraGridAction.PrevCellByTab, False, False)
    '                                    grdTenders.PerformAction(UltraGridAction.EnterEditMode, False, False)
    '                                End If
    '                        End Select
    '                End Select
    '            End If
    '        End With
    '    End Sub  'ProcessGridKeyStrokes

    '    '------------------------------------------------------------------------------
    '    ' Put cursor in named field
    '    '------------------------------------------------------------------------------
    '    Private Sub TabToField(ByVal fieldKey As String)
    '        Do
    '            grdTenders.PerformAction(UltraGridAction.NextCellByTab)
    '        Loop Until grdTenders.ActiveCell.Column.Key = fieldKey
    '    End Sub  'TabToField

    '    '------------------------------------------------------------------------------
    '    ' Leave grid and jump to OK button
    '    '------------------------------------------------------------------------------
    '    Private Sub JumpToOKButton()
    '        grdTenders.PerformAction(UltraGridAction.ExitEditMode, False, False)
    '        btnOK.Focus()
    '    End Sub  'JumpToOKButton

    '    '------------------------------------------------------------------------------
    '    ' Catch changes to already charged tenders
    '    '------------------------------------------------------------------------------
    '    Private Sub grdTenders_BeforeCellUpdate(sender As Object, e As BeforeCellUpdateEventArgs) Handles grdTenders.BeforeCellUpdate
    '        If Not (e.Cell.Column.Key = "TenderID" OrElse e.Cell.Column.Key = "TenderAmount") Then
    '            Exit Sub
    '        End If
    '        SyncLock Me
    '            If mBusy Then
    '                Return
    '            End If
    '            mBusy = True
    '        End SyncLock
    '        'Debugging code
    '        'Dim itemCount As Integer = BOGetIntAttributeValueByName(Adapter, 0, "Item Count")
    '        'Dim tenderCount As Integer = BOGetIntAttributeValueByName(Adapter, 0, "Tender Count")
    '        'MsgBox("Items: " & itemCount.ToString & ", Tenders: " & tenderCount.ToString, MsgBoxStyle.Exclamation, "Before")
    '        Try
    '            If CBool(e.Cell.Row.Cells("IsCharged").Value) = True Then
    '                'Build StadisRequest and do reverse
    '                Dim sr As New StadisRequest
    '                With sr
    '                    .SiteID = gSiteID
    '                    .StadisAuthorizationID = CStr(e.Cell.Row.Cells("StadisAuthorizationID").Value)
    '                    .VendorID = mVendorID
    '                    .LocationID = mLocationID
    '                    .RegisterID = mRegisterID
    '                    .ReceiptID = mReceiptID
    '                    .VendorCashier = mVendorCashier
    '                End With
    '                Dim sys As StadisReply() = CommonRoutines.StadisAPI.SVAccountReverse(sr)
    '                If sys(0).ReturnCode < 0 Then
    '                    MsgBox("Unable to back out previously entered value.", MsgBoxStyle.Exclamation, "STADIS")
    '                End If
    '                'Adjust RPro
    '                Dim invoiceHandle As Integer = 0
    '                Dim tenderHandle As Integer = mAdapter.GetReferenceBOForAttribute(invoiceHandle, "Tenders")
    '                Dim tenderID As String = ""
    '                CommonRoutines.BORefreshRecord(mAdapter, 0)
    '                CommonRoutines.BOOpen(mAdapter, tenderHandle)
    '                CommonRoutines.BOFirst(mAdapter, tenderHandle, "Redeem - grdTenders_BeforeCellUpdate")
    '                While Not mAdapter.EOF(tenderHandle)
    '                    tenderID = CommonRoutines.BOGetStrAttributeValueByName(mAdapter, tenderHandle, "TRANSACTION_ID")
    '                    If tenderID = Trim(CStr(e.Cell.Row.Cells("TenderID").Value)) Then
    '                        CommonRoutines.BODelete(mAdapter, tenderHandle)
    '                        mBusy = False
    '                        Exit Sub
    '                    End If
    '                    mAdapter.BONext(tenderHandle)
    '                End While
    '            End If
    '        Catch ex As Exception
    '            MsgBox(ex.ToString)
    '        Finally
    '            mBusy = False
    '        End Try
    '    End Sub  'grdTenders_BeforeCellUpdate

    '    '------------------------------------------------------------------------------
    '    ' Process Tender scans and do STADIS validation
    '    '------------------------------------------------------------------------------
    '    Private Sub grdTenders_AfterCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdTenders.AfterCellUpdate
    '        If Not (e.Cell.Column.Key = "TenderID" OrElse e.Cell.Column.Key = "TenderAmount") Then
    '            Exit Sub
    '        End If
    '        SyncLock Me
    '            If mBusy Then
    '                Return
    '            End If
    '            mBusy = True
    '        End SyncLock
    '        Try
    '            Select Case e.Cell.Column.Key
    '                Case "TenderID"

    '                    'Check for blank input
    '                    If CStr(e.Cell.Value) <> Trim(CStr(e.Cell.Value)) Then
    '                        e.Cell.Value = Trim(CStr(e.Cell.Value))
    '                    End If
    '                    If CStr(e.Cell.Value) = "" Then
    '                        mBusy = False
    '                        Exit Sub
    '                    End If

    '                    'Strip out extra characters from scanner
    '                    Dim extractedScan As String = CommonRoutines.ExtractScan(CStr(e.Cell.Value))
    '                    If extractedScan <> CStr(e.Cell.Value) Then
    '                        e.Cell.Value = extractedScan
    '                    End If

    '                    'Validate TenderID against our regex pattern for length / content
    '                    If CommonRoutines.ValidateScan(extractedScan) = False Then
    '                        MsgBox("Invalid scan content or length." & vbCrLf & "Scan: " & extractedScan, MsgBoxStyle.Exclamation, "STADIS Tender")
    '                        e.Cell.Value = ""
    '                        mBusy = False
    '                        Exit Sub
    '                    End If

    '                    'Check for duplicate TenderIDs
    '                    Dim aRow As UltraGridRow = grdTenders.Rows(0)
    '                    aRow = aRow.GetChild(Infragistics.Win.UltraWinGrid.ChildRow.First)
    '                    Do
    '                        If aRow.Index <> e.Cell.Row.Index AndAlso CStr(aRow.Cells("TenderID").Value) = CStr(e.Cell.Value) Then
    '                            MsgBox("Card/Ticket has already been entered.", MsgBoxStyle.Exclamation, "STADIS Tender")
    '                            e.Cell.Value = ""
    '                            mBusy = False
    '                            Exit Sub
    '                        End If
    '                        If aRow.HasNextSibling = True Then
    '                            aRow = aRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next)
    '                        Else
    '                            Exit Do
    '                        End If
    '                    Loop

    '                    CalculateTenderTotal()

    '                    'Check ticket status
    '                    Dim sr As New StadisRequest
    '                    With sr
    '                        .SiteID = gSiteID
    '                        .TenderTypeID = 1
    '                        .TenderID = CStr(e.Cell.Value)
    '                        .Amount = 0
    '                        .ReferenceNumber = ""
    '                        .VendorID = gVendorID
    '                        .LocationID = gLocationID
    '                        .RegisterID = CommonRoutines.BOGetStrAttributeValueByName(mAdapter, 0, "Invoice Workstion")
    '                        .ReceiptID = CommonRoutines.BOGetStrAttributeValueByName(mAdapter, 0, "Invoice Number")
    '                        .VendorCashier = CommonRoutines.BOGetStrAttributeValueByName(mAdapter, 0, "Cashier")
    '                    End With
    '                    Dim ts As TicketStatus = CommonRoutines.StadisAPI.GetTicketStatus(sr)
    '                    If ts.ReturnCode < 0 Then
    '                        MsgBox("Unable to validate card...", MsgBoxStyle.Exclamation, "GiftCard")
    '                        e.Cell.Value = ""
    '                        Exit Select
    '                    End If
    '                    e.Cell.Row.Cells("AvailableAmount").Value = ts.SVATotalAvailable
    '                    If ts.SVATotalAvailable < CDec(e.Cell.Row.Cells("TenderAmount").Value) Then
    '                        e.Cell.Row.Cells("TenderAmount").Value = ts.SVATotalAvailable
    '                    End If
    '                    e.Cell.Row.Cells("BalanceAfter").Value = ts.SVA1Balance - CDec(e.Cell.Row.Cells("TenderAmount").Value)

    '                    'Exit if TenderAmount hasn't been entered
    '                    If CDec(e.Cell.Row.Cells("TenderAmount").Value) = 0D Then
    '                        mBusy = False
    '                        Exit Sub
    '                    End If

    '                Case "TenderAmount"

    '                    'Check for blank input
    '                    If IsDBNull(e.Cell.Value) Then
    '                        e.Cell.Value = 0D
    '                    End If

    '                    'Update total
    '                    CalculateTenderTotal()
    '                    If mTenderTotal > mAmountDue Then
    '                        e.Cell.Row.Cells("TenderAmount").Value = CDec(e.Cell.Row.Cells("TenderAmount").Value) - (mTenderTotal - mAmountDue)
    '                        grdTenders.Refresh()
    '                        CalculateTenderTotal()
    '                    End If

    '                    'Exit if TenderID hasn't been entered
    '                    If Trim(CStr(e.Cell.Row.Cells("TenderID").Value)) = "" Then
    '                        mBusy = False
    '                        Exit Sub
    '                    End If

    '                    'Check ticket status
    '                    Dim sr As New StadisRequest
    '                    With sr
    '                        .SiteID = gSiteID
    '                        .TenderTypeID = 1
    '                        .TenderID = CStr(e.Cell.Row.Cells("TenderID").Value)
    '                        .Amount = 0
    '                        .ReferenceNumber = ""
    '                        .VendorID = gVendorID
    '                        .LocationID = gLocationID
    '                        .RegisterID = CommonRoutines.BOGetStrAttributeValueByName(mAdapter, 0, "Invoice Workstion")
    '                        .ReceiptID = CommonRoutines.BOGetStrAttributeValueByName(mAdapter, 0, "Invoice Number")
    '                        .VendorCashier = CommonRoutines.BOGetStrAttributeValueByName(mAdapter, 0, "Cashier")
    '                    End With
    '                    Dim ts As TicketStatus = CommonRoutines.StadisAPI.GetTicketStatus(sr)
    '                    If ts.ReturnCode < 0 Then
    '                        MsgBox("Unable to validate card...", MsgBoxStyle.Exclamation, "GiftCard")
    '                        e.Cell.Value = ""
    '                        Exit Select
    '                    End If
    '                    e.Cell.Row.Cells("AvailableAmount").Value = ts.SVATotalAvailable
    '                    If ts.SVATotalAvailable < CDec(e.Cell.Row.Cells("TenderAmount").Value) Then
    '                        e.Cell.Row.Cells("TenderAmount").Value = ts.SVATotalAvailable
    '                    End If
    '                    e.Cell.Row.Cells("BalanceAfter").Value = ts.SVA1Balance - CDec(e.Cell.Row.Cells("TenderAmount").Value)

    '            End Select  'for column
    '            grdTenders.PerformAction(UltraGridAction.ExitEditMode, False, False)
    '            ''Debug code
    '            'Dim itemCount As Integer = BOGetIntAttributeValueByName(Adapter, 0, "Item Count")
    '            'Dim tenderCount As Integer = BOGetIntAttributeValueByName(Adapter, 0, "Tender Count")
    '            'MsgBox("Items: " & itemCount.ToString & ", Tenders: " & tenderCount.ToString, MsgBoxStyle.Exclamation, "After")

    '        Catch ex As Exception
    '            MsgBox(ex.ToString)
    '        Finally
    '            mBusy = False
    '        End Try
    '    End Sub  'grdTenders_AfterCellUpdate

    '    'Private Sub grdTenders_AfterExitEditMode(ByVal o As Object, e As System.EventArgs) Handles grdTenders.AfterExitEditMode
    '    '    If grdTenders.ActiveRow IsNot Nothing Then
    '    '        With grdTenders.ActiveRow
    '    '            If CBool(.Cells("IsCharged").Value) = False AndAlso Trim(CStr(.Cells("TenderID").Value)) <> "" AndAlso CDec(.Cells("TenderAmount").Value) <> 0D Then
    '    '                'ToDo Remove when debugged
    '    '                'Dim id As String = .Cells("TenderID").Text
    '    '                'Dim amt As Decimal = CDec(.Cells("TenderAmount").Value)
    '    '                'MsgBox("About to Charge " & id & " " & amt.ToString)

    '    '                AddTenderToRPro(grdTenders.ActiveRow)
    '    '                DoSVAccountCharge(grdTenders.ActiveRow)
    '    '            End If
    '    '        End With
    '    '    End If
    '    'End Sub

    '    Private Sub AddTenderToRPro(ByVal aRow As Infragistics.Win.UltraWinGrid.UltraGridRow)
    '        Try
    '            CommonRoutines.BORefreshRecord(mAdapter, 0)
    '            CommonRoutines.BOOpen(mAdapter, mTenderHandle)

    '            If Adapter.BOIsAttributeInList(mTenderHandle, "EFTDATA8") = False Then
    '                Dim result As Integer = Adapter.BOIncludeAttrIntoList(mTenderHandle, "EFTDATA8", True, False)
    '            End If
    '            If Adapter.BOIsAttributeInInstance(mTenderHandle, "EFTDATA8") = False Then
    '                Dim result As Integer = Adapter.BOIncludeAttrIntoInstance(mTenderHandle, "EFTDATA8", True, False)
    '            End If

    '            If Adapter.BOIsAttributeInList(mTenderHandle, "EFTDATA9") = False Then
    '                Dim result As Integer = Adapter.BOIncludeAttrIntoList(mTenderHandle, "EFTDATA9", True, False)
    '            End If
    '            If Adapter.BOIsAttributeInInstance(mTenderHandle, "EFTDATA9") = False Then
    '                Dim result As Integer = Adapter.BOIncludeAttrIntoInstance(mTenderHandle, "EFTDATA9", True, False)
    '            End If

    '            aRow.Cells("IsAddedToRPro").Value = True
    '            CommonRoutines.BOInsert(mAdapter, mTenderHandle)
    '            CommonRoutines.BOSetAttributeValueByName(mAdapter, mTenderHandle, "TENDER_TYPE", gStadisTenderType)
    '            CommonRoutines.BOSetAttributeValueByName(mAdapter, mTenderHandle, "AMT", CDec(aRow.Cells("TenderAmount").Value))
    '            CommonRoutines.BOSetAttributeValueByName(mAdapter, mTenderHandle, "TRANSACTION_ID", CStr(aRow.Cells("TenderID").Value))
    '            CommonRoutines.BOSetAttributeValueByName(mAdapter, mTenderHandle, "MANUAL_REMARK", CStr(aRow.Cells("TenderType").Value) & "#" & CStr(aRow.Cells("TenderID").Value))
    '            Dim id As String = CStr(aRow.Cells("TenderID").Value)
    '            Dim len As Integer = id.Length
    '            Dim lastfour As String = id.Substring(len - 4, 4)
    '            CommonRoutines.BOSetAttributeValueByName(mAdapter, mTenderHandle, "DOC_NO", lastfour)
    '            CommonRoutines.BOSetAttributeValueByName(mAdapter, mTenderHandle, "EFTDATA8", lastfour)
    '            If gStadisTenderType = RetailPro.Plugins.TenderTypes.ttGiftCard Then
    '                CommonRoutines.BOSetAttributeValueByName(mAdapter, mTenderHandle, "CRD_EXP_MONTH", 1)
    '                CommonRoutines.BOSetAttributeValueByName(mAdapter, mTenderHandle, "CRD_EXP_YEAR", 1)
    '                CommonRoutines.BOSetAttributeValueByName(mAdapter, mTenderHandle, "CRD_TYPE", 1)
    '                CommonRoutines.BOSetAttributeValueByName(mAdapter, mTenderHandle, "CRD_PRESENT", 1)
    '            End If
    '            CommonRoutines.BOPost(mAdapter, mTenderHandle)
    '            ''Debug code
    '            'CommonRoutines.BORefreshRecord(mAdapter, 0)
    '            'Dim itemCount As Integer = BOGetIntAttributeValueByName(mAdapter, 0, "Item Count")
    '            'Dim tenderCount1 As Integer = BOGetIntAttributeValueByName(mAdapter, 0, "Tender Count")
    '            'MsgBox("Items: " & itemCount.ToString & ", Tenders: " & tenderCount1.ToString, MsgBoxStyle.Exclamation, "After adding tender to RPro")
    '        Catch ex As Exception
    '            MessageBox.Show("Error while adding STADIS tender." & vbCrLf & ex.Message, "STADIS")
    '            Exit Sub
    '        End Try
    '    End Sub  'AddTenderToRPro

    '    Private Sub DoSVAccountCharge(ByVal aRow As Infragistics.Win.UltraWinGrid.UltraGridRow)
    '        aRow.Cells("IsCharged").Value = False
    '        Try
    '            'Build StadisRequest and do charge
    '            Dim sr As New StadisRequest
    '            With sr
    '                .SiteID = gSiteID
    '                .TenderTypeID = 1
    '                .TenderID = CStr(aRow.Cells("TenderID").Value)
    '                .Amount = CDec(aRow.Cells("TenderAmount").Value)
    '                .ReferenceNumber = mReferenceNumber
    '                '.CustomerID =  
    '                .VendorID = mVendorID
    '                .LocationID = mLocationID
    '                .RegisterID = mRegisterID
    '                .ReceiptID = mReceiptID
    '                .VendorCashier = mVendorCashier
    '                gRegisterID = .RegisterID
    '                gVendorCashier = .VendorCashier
    '            End With
    '            Dim sys As StadisReply() = CommonRoutines.StadisAPI.SVAccountCharge(sr, CommonRoutines.LoadHeader(mAdapter, "Receipt", mInvoiceHandle), CommonRoutines.LoadItems(mAdapter, "Receipt", mInvoiceHandle, mItemHandle), CommonRoutines.OldLoadTendersForCharge(mAdapter, "Receipt", mTenderHandle))
    '            For Each sy As StadisReply In sys
    '                If sy.TenderTypeID = 1 Then   'Ticket
    '                    'Update our own list of Stadis tenders, so we can check in PrintUpdate for deletes
    '                    'Dim sc As New StadisCharge(sy.TenderTypeID, sy.TenderID, sy.ChargedAmount, sy.StadisAuthorizationID)
    '                    'stadisChargeList.Add(sc)
    '                    If CommonRoutines.IsAGiftCard(sy.EventID) Then
    '                        aRow.Cells("TenderType").Value = "@GC"
    '                    Else
    '                        aRow.Cells("TenderType").Value = "@TK"
    '                    End If
    '                    Select Case sy.ReturnCode
    '                        Case 0, 1, -2   'Charge went through
    '                            'Update grid
    '                            aRow.Cells("StadisAuthorizationID").Value = sy.StadisAuthorizationID
    '                            aRow.Cells("AvailableAmount").Value = 0D
    '                            aRow.Cells("BalanceAfter").Value = sy.FromSVAccountBalance
    '                            aRow.Cells("TenderAmount").Value = sy.ChargedAmount
    '                            If sy.ReturnCode = 1 Then
    '                                aRow.Cells("StatusMessage").Value = "Depleted"
    '                            End If
    '                            aRow.Cells("IsCharged").Value = True
    '                            'Update RPro
    '                            Try
    '                                Dim tenderID As String = ""
    '                                CommonRoutines.BORefreshRecord(mAdapter, 0)
    '                                CommonRoutines.BOOpen(mAdapter, mTenderHandle)
    '                                CommonRoutines.BOFirst(mAdapter, mTenderHandle, "Redeem - DoSVAccountCharge")
    '                                While Not mAdapter.EOF(mTenderHandle)
    '                                    Dim tenderType As Integer = CommonRoutines.BOGetIntAttributeValueByName(mAdapter, mTenderHandle, "TENDER_TYPE")
    '                                    If tenderType = gStadisTenderType Then
    '                                        tenderID = CommonRoutines.BOGetStrAttributeValueByName(mAdapter, mTenderHandle, "TRANSACTION_ID")
    '                                        If tenderID = Trim(CStr(aRow.Cells("TenderID").Value)) Then
    '                                            CommonRoutines.BOSetAttributeValueByName(mAdapter, mTenderHandle, "AMT", sy.ChargedAmount)
    '                                            Dim paddedRemAmt As String = Space(8 - Len(sy.FromSVAccountBalance.ToString("#0.00"))) & sy.FromSVAccountBalance.ToString("#0.00")
    '                                            CommonRoutines.BOSetAttributeValueByName(mAdapter, mTenderHandle, "AUTH", sy.StadisAuthorizationID & "\" & paddedRemAmt)
    '                                            CommonRoutines.BOPost(mAdapter, mTenderHandle)
    '                                            Exit While
    '                                        End If
    '                                    End If
    '                                    mAdapter.BONext(mTenderHandle)
    '                                End While
    '                                CommonRoutines.BORefreshRecord(mAdapter, 0)
    '                            Catch ex As Exception
    '                                If sy.StadisAuthorizationID.Length = 6 Then
    '                                    DoSVAccountReverse(sy.StadisAuthorizationID)
    '                                End If
    '                                MessageBox.Show("Error while updating STADIS tender in RPro." & vbCrLf & ex.Message, "STADIS")
    '                                Exit Sub
    '                            End Try
    '                        Case -1, -3, -99
    '                            'Update grid
    '                            aRow.Cells("TenderID").Value = ""
    '                            aRow.Cells("TenderAmount").Value = 0D
    '                            aRow.Cells("AvailableAmount").Value = 0D
    '                            aRow.Cells("BalanceAfter").Value = 0D
    '                            CalculateTenderTotal()
    '                            aRow.Cells("TenderAmount").Value = mRemainingAmountDue
    '                            grdTenders.Focus()
    '                            grdTenders.ActiveCell = aRow.Cells("TenderID")
    '                            grdTenders.PerformAction(UltraGridAction.ToggleCellSel, False, False)
    '                            grdTenders.PerformAction(UltraGridAction.EnterEditMode, False, False)
    '                            If sy.ReturnCode = -1 Then
    '                                MsgBox("Ticket/Card is Inactive!" & vbCrLf & "Ticket/Card: " & CStr(aRow.Cells("TenderID").Value), MsgBoxStyle.Exclamation, "Ticket Tender")
    '                            ElseIf sy.ReturnCode = -3 Then
    '                                MsgBox("Ticket not found!" & vbCrLf & "Ticket/Card: " & CStr(aRow.Cells("TenderID").Value), MsgBoxStyle.Exclamation, "Ticket Tender")
    '                            Else
    '                                MsgBox("Charge failed for unknown reasons!" & vbCrLf & "Try again later.", MsgBoxStyle.Exclamation, "Ticket Tender")
    '                            End If
    '                            'Update RPro
    '                            DeleteTenderFromRPro(Trim(CStr(aRow.Cells("TenderID").Value)))
    '                            Exit Sub
    '                        Case Else
    '                            MsgBox("Charge failed for unknown reasons!" & vbCrLf & "Try again later.", MsgBoxStyle.Exclamation, "Ticket Tender")
    '                            Exit Sub
    '                    End Select
    '                ElseIf sy.TenderTypeID = 11 Then   'Promo
    '                    'MessageBox.Show("I", "DEBUG")
    '                    With sy
    '                        Dim dr As DSTender.TenderRow = CType(mTenders.Tender.NewRow(), DSTender.TenderRow)
    '                        dr.ID = 1
    '                        dr.StadisAuthorizationID = .StadisAuthorizationID
    '                        dr.TenderType = "@PR"
    '                        dr.LineNumber = 0
    '                        dr.TenderID = .TenderID
    '                        dr.StatusMessage = .Comment
    '                        dr.TenderAmount = .ChargedAmount
    '                        dr.AvailableAmount = 0D
    '                        dr.BalanceAfter = 0D
    '                        dr.IsCharged = True
    '                        mTenders.Tender.Rows.Add(dr)
    '                    End With
    '                    Try
    '                        CommonRoutines.BORefreshRecord(mAdapter, 0)
    '                        CommonRoutines.BOOpen(mAdapter, mTenderHandle)
    '                        CommonRoutines.BOInsert(mAdapter, mTenderHandle)
    '                        CommonRoutines.BOSetAttributeValueByName(mAdapter, mTenderHandle, "TENDER_TYPE", gStadisTenderType)
    '                        CommonRoutines.BOSetAttributeValueByName(mAdapter, mTenderHandle, "AMT", sy.ChargedAmount)
    '                        CommonRoutines.BOSetAttributeValueByName(mAdapter, mTenderHandle, "TRANSACTION_ID", sy.TenderID)
    '                        CommonRoutines.BOSetAttributeValueByName(mAdapter, mTenderHandle, "AUTH", sy.StadisAuthorizationID & "\   $0.00")
    '                        CommonRoutines.BOSetAttributeValueByName(mAdapter, mTenderHandle, "MANUAL_REMARK", "@PR#" & sy.TenderID)
    '                        If gStadisTenderType = RetailPro.Plugins.TenderTypes.ttGiftCard Then
    '                            CommonRoutines.BOSetAttributeValueByName(mAdapter, mTenderHandle, "CRD_EXP_MONTH", 1)
    '                            CommonRoutines.BOSetAttributeValueByName(mAdapter, mTenderHandle, "CRD_EXP_YEAR", 1)
    '                            CommonRoutines.BOSetAttributeValueByName(mAdapter, mTenderHandle, "CRD_TYPE", 1)
    '                            CommonRoutines.BOSetAttributeValueByName(mAdapter, mTenderHandle, "CRD_PRESENT", 1)
    '                        End If
    '                        CommonRoutines.BOPost(mAdapter, mTenderHandle)
    '                    Catch ex As Exception
    '                        MessageBox.Show("Error while adding STADIS tender(s)." & vbCrLf & ex.Message, "STADIS")
    '                    End Try
    '                End If
    '            Next
    '        Catch ex As Exception
    '            'MessageBox.Show("J", "DEBUG")
    '            MsgBox(ex.Message.ToString(), , "SVAccountCharge")
    '        End Try
    '    End Sub  'DoSVAccountCharge

    '    Private Sub grdTenders_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdTenders.BeforeRowsDeleted
    '        If CInt(e.Rows(0).Cells("TenderTypeID").Value) = 1 Then
    '            Dim authID As String = Trim(CStr(e.Rows(0).Cells("StadisAuthorizationID").Value))
    '            If authID <> "" OrElse CBool(e.Rows(0).Cells("IsCharged").Value) = True Then
    '                DoSVAccountReverse(authID)
    '            End If
    '        End If
    '    End Sub  'grdTenders_BeforeRowsDeleted

    '    Private Sub DoSVAccountReverse(ByVal AuthID As String)
    '        Dim invoiceHandle As Integer = 0
    '        Dim sr As New StadisRequest
    '        With sr
    '            .SiteID = gSiteID
    '            .StadisAuthorizationID = AuthID
    '            .VendorID = gVendorID
    '            .LocationID = gLocationID
    '            .RegisterID = CommonRoutines.BOGetStrAttributeValueByName(mAdapter, invoiceHandle, "Invoice Workstion")
    '            .ReceiptID = CommonRoutines.BOGetStrAttributeValueByName(mAdapter, invoiceHandle, "Invoice Number")
    '            .VendorCashier = CommonRoutines.BOGetStrAttributeValueByName(mAdapter, invoiceHandle, "Cashier")
    '        End With
    '        Dim sys As StadisReply() = CommonRoutines.StadisAPI.SVAccountReverse(sr)
    '        Dim hasBadReply As Boolean = False
    '        For Each sy As StadisReply In sys
    '            If sy.ReturnCode < 0 Then
    '                hasBadReply = True
    '                LogStadisEvent(Guid.Empty, "Reverse Charge", "DoReverse", "A", sy.ReturnCode, "Unable to reverse charge for StadisAuthorizationID", "", "", "StadisAuthorizationID = " & sy.StadisAuthorizationID)
    '            End If
    '        Next
    '        If hasBadReply = True Then
    '            MsgBox("Unable to reverse charge for StadisAuthorizationID " & AuthID, MsgBoxStyle.Exclamation, "Reverse Charge")
    '        Else
    '        End If
    '    End Sub  'DoSVAccountReverse

    '#End Region  'Tenders Grid

    '#Region " Other Methods "

    '    '------------------------------------------------------------------------------
    '    ' Cancel button - pack up and get out
    '    '------------------------------------------------------------------------------
    '    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
    '        For Each dr As DSTender.TenderRow In DSTender.Tender
    '            If dr.IsCharged = True Then
    '                Dim sr As New StadisRequest
    '                With sr
    '                    .SiteID = gSiteID
    '                    .StadisAuthorizationID = dr.StadisAuthorizationID
    '                    .VendorID = gVendorID
    '                    .LocationID = gLocationID
    '                End With
    '                Dim sys As StadisReply() = CommonRoutines.StadisAPI.SVAccountReverse(sr)
    '                If sys(0).ReturnCode < 0 Then
    '                    MessageBox.Show("Unable to back out Stadis charge for " & dr.TenderID & ".", "STADIS")
    '                End If
    '            End If
    '        Next
    '        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    '        Me.Close()
    '    End Sub  'btnCancel_Click

    '    '------------------------------------------------------------------------------
    '    ' OK button - Check tenders for completeness, then get out
    '    '------------------------------------------------------------------------------
    '    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
    '        grdTenders.PerformAction(UltraGridAction.ExitEditMode, False, False)
    '        grdTenders.PerformAction(UltraGridAction.NextCellByTab)
    '        'Check for incomplete rows
    '        For Each tr As DSTender.TenderRow In mTenders.Tender.Rows
    '            If tr.TenderType = "TKT" Then
    '                If Not (Trim(tr.TenderID) <> "" AndAlso tr.TenderAmount > 0D AndAlso tr.IsCharged AndAlso tr.IsAddedToRPro) Then
    '                    MessageBox.Show("Tender - No TenderID / No Amount / Not Charged.", "STADIS")
    '                    Exit Sub
    '                End If
    '            End If
    '        Next
    '        'Check for uncharged rows
    '        Dim aRow As UltraGridRow = grdTenders.Rows(0)
    '        aRow = aRow.GetChild(Infragistics.Win.UltraWinGrid.ChildRow.First)
    '        Do
    '            If CBool(aRow.Cells("IsCharged").Value) = False Then
    '                AddTenderToRPro(aRow)
    '                DoSVAccountCharge(aRow)
    '            End If
    '            If aRow.HasNextSibling = True Then
    '                aRow = aRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next)
    '            Else
    '                Exit Do
    '            End If
    '        Loop
    '        Me.DialogResult = Windows.Forms.DialogResult.OK
    '        Me.Close()
    '    End Sub  'btnOK_Click

    '    '------------------------------------------------------------------------------
    '    ' Delete a tender from Retail Pro
    '    '------------------------------------------------------------------------------
    '    Private Sub DeleteTenderFromRPro(ByVal ID As String)
    '        Try
    '            CommonRoutines.BORefreshRecord(mAdapter, 0)
    '            Dim tenderHandle As Integer = mAdapter.GetReferenceBOForAttribute(0, "Tenders")
    '            If mTenderHandle < 0 Then  'no tenders
    '                Exit Sub
    '            End If
    '            CommonRoutines.BOOpen(mAdapter, tenderHandle)
    '            CommonRoutines.BOFirst(mAdapter, tenderHandle, "Redeem - DeleteATenderFromRPro")
    '            While Not mAdapter.EOF(tenderHandle)
    '                Dim tenderType As Integer = CommonRoutines.BOGetIntAttributeValueByName(mAdapter, tenderHandle, "TENDER_TYPE")
    '                Dim tenderID As String = CommonRoutines.BOGetStrAttributeValueByName(mAdapter, tenderHandle, "TRANSACTION_ID")
    '                If tenderType = gStadisTenderType AndAlso tenderID = ID Then
    '                    CommonRoutines.BODelete(mAdapter, tenderHandle)
    '                End If
    '                mAdapter.BONext(tenderHandle)
    '            End While
    '            CommonRoutines.BOPost(mAdapter, tenderHandle)
    '        Catch ex As Exception
    '            MessageBox.Show("Error while deleting STADIS tender." & vbCrLf & ex.Message, "STADIS")
    '        End Try
    '    End Sub  'DeleteATenderFromRPro

    '    '------------------------------------------------------------------------------
    '    ' Invoked when form is closed for any reason - makes sure we release pointers 
    '    '------------------------------------------------------------------------------
    '    Private Sub FrmRedeem_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
    '        mAdapter = Nothing
    '        mTenders = Nothing
    '        mAmountDue = Nothing
    '        mTenderTotal = Nothing
    '        mRemainingAmountDue = Nothing
    '    End Sub  'FrmRedeem_Closing

    '#End Region  'Other Methods

    '#Region " Exception Handling "

    '    Private Sub LogStadisEvent(ByVal SVActionID As Guid, ByVal StadisEvent As String, ByVal Proc As String, ByVal SeqID As String, ByVal Ret As Integer, ByVal Msg As String, ByVal ExcType As String, ByVal ExcMsg As String, ByVal Comments As String)
    '        Dim invoiceHandle As Integer = 0
    '        Dim sr As New StadisRequest
    '        With sr
    '            .SiteID = gSiteID
    '            .ReferenceNumber = CommonRoutines.BOGetStrAttributeValueByName(mAdapter, invoiceHandle, "Invoice Number")
    '            '.CustomerID =  
    '            .VendorID = gVendorID
    '            .LocationID = gLocationID
    '            .RegisterID = CommonRoutines.BOGetStrAttributeValueByName(mAdapter, invoiceHandle, "Invoice Workstion")
    '            .ReceiptID = CommonRoutines.BOGetStrAttributeValueByName(mAdapter, invoiceHandle, "Invoice Number")
    '            .VendorCashier = CommonRoutines.BOGetStrAttributeValueByName(mAdapter, invoiceHandle, "Cashier")
    '        End With
    '        Dim ev As New EventLog
    '        With ev
    '            .StadisComponent = "RPro V9"
    '            .StadisEvent = StadisEvent
    '            .OrigAssembly = "StadisV4RProV9Plugin"
    '            .OrigClass = "FrmRedeem"
    '            .OrigProcedure = Proc
    '            .OrigSequenceID = SeqID
    '            .RetCode = Ret
    '            .RetMessage = Msg
    '            .ExceptionType = ExcType
    '            .ExceptionMessage = ExcMsg
    '            .Comments = Comments
    '        End With
    '        Dim sy As StadisReply = CommonRoutines.StadisAPI.SVEventLog(sr, ev)
    '        If sy.ReturnCode < 0 Then
    '            MessageBox.Show("Unable to log Stadis error.", "STADIS")
    '        End If
    '    End Sub  'LogStadisEvent

    '#End Region  'Exception Handling

End Class  'FrmRedeem

















































































































































































































