'Imports CommonV4
'Imports StadisV4RProV9Plugin.WebReference
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
'Imports POS.Devices.OPOSPOSPrinterConstants
'Imports POS.Devices.OPOS_Constants
'----------------------------------------------------------------------------------------------
'   Class: FrmHistory
'    Type: Windows Form
' Purpose: Show transaction detail and print copies of receipts
'----------------------------------------------------------------------------------------------
Public Class FrmHistory

#Region " Data Declarations "

    Private ds As New DSTran

    'Private OPOSPrinter As New POS.Devices.OPOSPOSPrinter
    'Private mStarComm As New StarComm
    Private WithEvents sPrn As New System.Drawing.Printing.PrintDocument

    'Private Const LF As Char = Chr(10)

    'Private Const SC_EMPHASIZE_ON As StarComm.PrinterCommands = StarComm.PrinterCommands.SC_EMPHASIZE_ON
    'Private Const SC_EMPHASIZE_OFF As StarComm.PrinterCommands = StarComm.PrinterCommands.SC_EMPHASIZE_OFF
    'Private Const SC_FEED_FULL_CUT As StarComm.PrinterCommands = StarComm.PrinterCommands.SC_FEED_FULL_CUT
    'Private Const SC_HEIGHT_X1 As StarComm.PrinterCommands = StarComm.PrinterCommands.SC_HEIGHT_X1
    'Private Const SC_HEIGHT_X2 As StarComm.PrinterCommands = StarComm.PrinterCommands.SC_HEIGHT_X2
    'Private Const SC_INITIALISE As StarComm.PrinterCommands = StarComm.PrinterCommands.SC_INITIALISE
    'Private Const SC_WIDTH_X1 As StarComm.PrinterCommands = StarComm.PrinterCommands.SC_WIDTH_X1
    'Private Const SC_WIDTH_X2 As StarComm.PrinterCommands = StarComm.PrinterCommands.SC_WIDTH_X2
    'Private Const SC_INVERT_OFF As StarComm.PrinterCommands = StarComm.PrinterCommands.SC_INVERT_OFF
    'Private Const SC_UNDERLINE_OFF As StarComm.PrinterCommands = StarComm.PrinterCommands.SC_UNDERLINE_OFF
    'Private Const SC_UPPERLINE_OFF As StarComm.PrinterCommands = StarComm.PrinterCommands.SC_UPPERLINE_OFF

    Private mTicketID As String = ""
    Friend Property TicketID() As String
        Get
            Return mTicketID
        End Get
        Set(ByVal value As String)
            mTicketID = value
        End Set
    End Property

    Private mTicketStatus As String = ""
    Friend Property TicketStatus() As String
        Get
            Return mTicketStatus
        End Get
        Set(ByVal value As String)
            mTicketStatus = value
        End Set
    End Property

    Private mInitAmount As Decimal = 0D
    Friend Property InitAmount() As Decimal
        Get
            Return mInitAmount
        End Get
        Set(ByVal value As Decimal)
            mInitAmount = value
        End Set
    End Property

    Private mBalance As Decimal = 0D
    Friend Property Balance() As Decimal
        Get
            Return mBalance
        End Get
        Set(ByVal value As Decimal)
            mBalance = value
        End Set
    End Property

    Private mScanTimeStamp As String = ""
    Friend Property ScanTimeStamp() As String
        Get
            Return mScanTimeStamp
        End Get
        Set(ByVal value As String)
            mScanTimeStamp = value
        End Set
    End Property

#End Region  'Data Declarations

#Region " Form Load and Initialization "

    Private Sub frmHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ConfigureScreenControls()
        GetHistory(TicketID)
    End Sub  'frmHistory_Load

    Private Sub ConfigureScreenControls()
        Me.Text = " Stadis - History for " & gStadisTenderText & " " & mTicketID
        btnPrint.Enabled = gIsPrintingEnabled
        btnPrintAll.Enabled = gIsPrintingEnabled
        lblTicketBarcode.Text = mTicketID
        lblTicketStatus.Text = mTicketStatus
        lblRemainingAmount.Text = mBalance.ToString("""$""#,##0.00")
    End Sub  'ConfigureScreenControls

    Private Sub GetHistory(ByVal TicketBarcode As String)
        Try
            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            ds.Clear()
            Dim mas As MessageAndActionSummary = Common.StadisAPI.GetActionSummaryForTicket(TicketBarcode)
            grdTran.DataSource = FillTransactionDS(mas.ActionHeader, mas.ActionItem, mas.ActionTender, mas.ActionSVAction)
            grdAction.DataSource = ds.Action
            Windows.Forms.Cursor.Current = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Error in GetActionSummary")
            Windows.Forms.Cursor.Current = Cursors.Default
        End Try
    End Sub  'GetHistory

    Private Function FillTransactionDS(ByRef headers As ActionHeader(), ByRef items As ActionItem(), ByRef tenders As ActionTender(), ByRef actions As ActionSVAction()) As DataSet
        If Not (headers Is Nothing) Then
            For Each header As ActionHeader In headers
                Dim dr As DSTran.HeaderRow = ds.Header.NewHeaderRow
                With dr
                    .TransactionKey = header.TransactionKey.ToString
                    .CreateDate = header.CreateDate.ToString
                    .Action = header.Action
                    .RegisterID = header.RegisterID
                    .VendorCashier = header.VendorCashier
                    .ReceiptID = header.ReceiptID
                    .Total = header.Total
                    .Status = header.Status
                    .UserID = header.UserID
                    .SeasonID = header.SeasonID
                    .EventID = header.EventID
                    .LocationID = header.LocationID
                    .VendorID = header.VendorID
                End With
                ds.Header.Rows.Add(dr)
            Next
            For Each itm As ActionItem In items
                Dim dr As DSTran.ItemRow = ds.Item.NewItemRow
                With dr
                    .ItemKey = itm.ItemKey.ToString
                    .TransactionKey = itm.TransactionKey.ToString
                    .ItemID = itm.ItemID
                    .Description = itm.Description
                    .Quantity = itm.Quantity
                    .Price = itm.Price
                    .Extension = itm.Quantity * itm.Price
                End With
                ds.Item.Rows.Add(dr)
            Next
            For Each tender As ActionTender In tenders
                Dim dr As DSTran.TenderRow = ds.Tender.NewTenderRow
                With dr
                    .TenderKey = tender.TenderKey.ToString
                    .TransactionKey = tender.TransactionKey.ToString
                    .IsStadisTender = tender.IsStadisTender
                    .StadisAuthorizationID = tender.StadisAuthorizationID
                    .TenderType = tender.TenderType
                    .TenderID = tender.TenderID
                    .Amount = tender.Amount
                    .PostedAmount = tender.PostedAmount
                End With
                ds.Tender.Rows.Add(dr)
            Next
        End If
        If Not (actions Is Nothing) Then
            For Each sa As ActionSVAction In actions
                Dim dr As DSTran.ActionRow = ds.Action.NewActionRow
                With dr
                    .CreateDate = sa.CreateDate.ToString
                    .Amount = sa.ChargedAmount
                    .TenderStatus = sa.TenderStatus
                    .TenderKey = sa.TenderKey.ToString
                    .ChargedAmount = sa.ChargedAmount
                    .RemainingAmount = sa.FromSVAccountBalance
                    .RegisterID = sa.RegisterID
                    .StadisAuthorizationID = sa.StadisAuthorizationID
                    .TransactionType = sa.TransactionType
                    .TransactionKey = ""
                    For Each tRow As DSTran.TenderRow In ds.Tender
                        If tRow.TenderKey = sa.TenderKey.ToString Then
                            .TransactionKey = tRow.TransactionKey
                        End If
                    Next
                End With
                ds.Action.Rows.Add(dr)
            Next
        End If
        Return ds
    End Function  'FillTransactionDS

    Private Sub grdTran_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdTran.InitializeLayout

        With grdTran

            .SuspendLayout()
            .TabStop = False

            With .DisplayLayout

                '.Appearance.BackColor = Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
                .BorderStyle = UIElementBorderStyle.None
                .CaptionVisible = DefaultableBoolean.[False]
                .DefaultSelectedBackColor = Color.DodgerBlue
                .DefaultSelectedForeColor = Color.White
                .MaxColScrollRegions = 1
                .MaxRowScrollRegions = 1
                .ScrollStyle = ScrollStyle.Immediate
                .ScrollBounds = ScrollBounds.ScrollToFill
                With .Override
                    .AllowColMoving = AllowColMoving.NotAllowed
                    .AllowColSizing = AllowColSizing.None
                    .AllowColSwapping = AllowColSwapping.NotAllowed
                    .CellClickAction = CellClickAction.RowSelect
                    .HeaderClickAction = HeaderClickAction.SortMulti
                    .HeaderStyle = HeaderStyle.WindowsXPCommand
                    .RowAppearance.BackColor = Color.White
                    .RowAppearance.FontData.SizeInPoints = 10
                    .RowAlternateAppearance.BackColor = Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(235, Byte), Integer))
                    .RowSelectors = DefaultableBoolean.[False]
                    .RowSizing = RowSizing.Fixed
                    .SelectTypeCell = SelectType.Single
                    .SelectTypeCol = SelectType.None
                    .SelectTypeRow = SelectType.Single
                    .TipStyleScroll = TipStyle.Hide
                End With

                'HEADER_HEADER_HEADER_HEADER_HEADER_HEADER_HEADER_HEADER_HEADER_HEADER_HEADER_HEADER_HEADER_HEADER
                With .Bands(0)

                    .ExcludeFromColumnChooser = ExcludeFromColumnChooser.[True]
                    .RowLayoutStyle = RowLayoutStyle.ColumnLayout
                    With .Override
                        With .HeaderAppearance
                            .BackColor = Color.LightSeaGreen
                            .BackColor2 = Color.Teal
                            .BackGradientStyle = GradientStyle.Vertical
                            .ForeColor = Color.White
                            .TextHAlign = HAlign.Center
                        End With
                    End With

                    .Columns("TransactionKey").Hidden = True
                    .Columns("VendorCashier").Hidden = True
                    .Columns("Status").Hidden = True
                    .Columns("UserID").Hidden = True
                    .Columns("SeasonID").Hidden = True
                    .Columns("EventID").Hidden = True
                    .Columns("LocationID").Hidden = True
                    .Columns("VendorID").Hidden = True

                    With .Columns("CreateDate")
                        .CellActivation = Activation.NoEdit
                        .CellAppearance.TextHAlign = HAlign.Left
                        .Format = "G"
                        .Header.Caption = "Date"
                        .Header.VisiblePosition = 0
                        .Width = 160
                    End With
                    With .Columns("Action")
                        .CellActivation = Activation.NoEdit
                        .CellAppearance.TextHAlign = HAlign.Left
                        .Header.Caption = "Action"
                        .Header.VisiblePosition = 1
                        .Width = 72
                    End With
                    With .Columns("RegisterID")
                        .CellActivation = Activation.NoEdit
                        .CellAppearance.TextHAlign = HAlign.Left
                        .Header.Caption = "RegisterID"
                        .Header.VisiblePosition = 2
                        .Width = 78
                    End With
                    With .Columns("ReceiptID")
                        .CellActivation = Activation.NoEdit
                        .CellAppearance.TextHAlign = HAlign.Left
                        .Header.Caption = "ReceiptID"
                        .Header.VisiblePosition = 3
                        .Width = 78
                    End With
                    With .Columns("Total")
                        .CellActivation = Activation.NoEdit
                        .CellAppearance.TextHAlign = HAlign.Right
                        .Format = "C2"
                        .Header.Caption = "Total"
                        .Header.VisiblePosition = 4
                        .Width = 78
                    End With

                End With

                'ITEM_ITEM_ITEM_ITEM_ITEM_ITEM_ITEM_ITEM_ITEM_ITEM_ITEM_ITEM_ITEM_ITEM_ITEM_ITEM_ITEM_ITEM_ITEM
                With .Bands(1)

                    .ExcludeFromColumnChooser = ExcludeFromColumnChooser.[True]
                    .RowLayoutStyle = RowLayoutStyle.ColumnLayout
                    With .Override
                        With .HeaderAppearance
                            .BackColor = Color.PaleTurquoise
                            .BackColor2 = Color.MediumTurquoise
                            .BackGradientStyle = GradientStyle.Vertical
                            .ForeColor = Color.Black
                            .TextHAlign = HAlign.Center
                        End With
                    End With

                    .Columns("ItemKey").Hidden = True
                    .Columns("TransactionKey").Hidden = True

                    With .Columns("ItemID")
                        .CellActivation = Activation.NoEdit
                        .CellAppearance.TextHAlign = HAlign.Left
                        .Header.Caption = "ItemID"
                        .Header.VisiblePosition = 0
                        .Width = 82
                    End With
                    With .Columns("Description")
                        .CellActivation = Activation.NoEdit
                        .CellAppearance.TextHAlign = HAlign.Left
                        .Header.Caption = "Description"
                        .Header.VisiblePosition = 1
                        .Width = 152
                    End With
                    With .Columns("Quantity")
                        .CellActivation = Activation.NoEdit
                        .CellAppearance.TextHAlign = HAlign.Right
                        .Header.Caption = "Quantity"
                        .Header.VisiblePosition = 2
                        .Width = 60
                    End With
                    With .Columns("Price")
                        .CellActivation = Activation.NoEdit
                        .CellAppearance.TextHAlign = HAlign.Right
                        .Format = "C2"
                        .Header.Caption = "Price"
                        .Header.VisiblePosition = 3
                        .Width = 76
                    End With
                    With .Columns("Extension")
                        .CellActivation = Activation.NoEdit
                        .CellAppearance.TextHAlign = HAlign.Right
                        .Format = "C2"
                        .Header.Caption = "Extension"
                        .Header.VisiblePosition = 4
                        .Width = 78
                    End With

                End With

                'TENDER_TENDER_TENDER_TENDER_TENDER_TENDER_TENDER_TENDER_TENDER_TENDER_TENDER_TENDER_TENDER
                With .Bands(2)

                    .ExcludeFromColumnChooser = ExcludeFromColumnChooser.[True]
                    .RowLayoutStyle = RowLayoutStyle.ColumnLayout
                    With .Override
                        With .HeaderAppearance
                            .BackColor = Color.PaleTurquoise
                            .BackColor2 = Color.MediumTurquoise
                            .BackGradientStyle = GradientStyle.Vertical
                            .ForeColor = Color.Black
                            .TextHAlign = HAlign.Center
                        End With
                    End With

                    .Columns("TenderKey").Hidden = True
                    .Columns("TransactionKey").Hidden = True
                    .Columns("IsStadisTender").Hidden = True
                    .Columns("StadisAuthorizationID").Hidden = True
                    .Columns("Amount").Hidden = True

                    With .Columns("TenderType")
                        .CellActivation = Activation.NoEdit
                        .CellAppearance.TextHAlign = HAlign.Left
                        .Header.Caption = "TenderType"
                        .Header.VisiblePosition = 0
                        .Width = 82
                    End With
                    With .Columns("TenderID")
                        .CellActivation = Activation.NoEdit
                        .CellAppearance.TextHAlign = HAlign.Left
                        .Header.Caption = "TenderID"
                        .Header.VisiblePosition = 1
                        .Width = 289
                    End With
                    With .Columns("PostedAmount")
                        .CellActivation = Activation.NoEdit
                        .CellAppearance.TextHAlign = HAlign.Right
                        .Format = "C2"
                        .Header.Caption = "Amount"
                        .Header.VisiblePosition = 2
                        .Width = 78
                    End With

                End With

                .Bands(3).Hidden = True

            End With

            .ResumeLayout()

        End With

    End Sub  'grdTran_InitializeLayout


    Private Sub grdAction_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdAction.InitializeLayout

        With grdAction

            .SuspendLayout()
            .TabStop = False

            With .DisplayLayout

                '.Appearance.BackColor = Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
                .BorderStyle = UIElementBorderStyle.None
                .CaptionVisible = DefaultableBoolean.[False]
                .DefaultSelectedBackColor = Color.DodgerBlue
                .DefaultSelectedForeColor = Color.White
                .MaxColScrollRegions = 1
                .MaxRowScrollRegions = 1
                .ScrollStyle = ScrollStyle.Immediate
                .ScrollBounds = ScrollBounds.ScrollToFill
                With .Override
                    .AllowColMoving = AllowColMoving.NotAllowed
                    .AllowColSizing = AllowColSizing.None
                    .AllowColSwapping = AllowColSwapping.NotAllowed
                    .CellClickAction = CellClickAction.RowSelect
                    .HeaderClickAction = HeaderClickAction.SortMulti
                    .HeaderStyle = HeaderStyle.WindowsXPCommand
                    .RowAppearance.BackColor = Color.White
                    .RowAppearance.FontData.SizeInPoints = 10
                    .RowAlternateAppearance.BackColor = Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(235, Byte), Integer))
                    .RowSelectors = DefaultableBoolean.[False]
                    .RowSizing = RowSizing.Fixed
                    .SelectTypeCell = SelectType.Single
                    .SelectTypeCol = SelectType.None
                    .SelectTypeRow = SelectType.Single
                    .TipStyleCell = TipStyle.Hide
                    .TipStyleScroll = TipStyle.Hide
                End With

                With .Bands(0)

                    .ExcludeFromColumnChooser = ExcludeFromColumnChooser.[True]
                    .RowLayoutStyle = RowLayoutStyle.ColumnLayout
                    With .Override
                        .RowAppearance.FontData.SizeInPoints = 10
                        With .HeaderAppearance
                            .BackColor = System.Drawing.Color.LightSeaGreen
                            .BackColor2 = System.Drawing.Color.Teal
                            .BackGradientStyle = GradientStyle.Vertical
                            .ForeColor = System.Drawing.Color.White
                            .TextHAlign = HAlign.Center
                        End With
                    End With

                    .Columns("StadisAuthorizationID").Hidden = True
                    .Columns("TenderKey").Hidden = True
                    .Columns("TransactionKey").Hidden = True
                    .Columns("TenderStatus").Hidden = True
                    .Columns("Amount").Hidden = True

                    Try
                        .Columns.Add("Rev", " ")
                    Catch
                    End Try

                    With .Columns("Rev")
                        .SortIndicator = SortIndicator.Disabled
                        .Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
                        .ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
                        .NullText = "Load"
                        .CellButtonAppearance.BackColor = Drawing.Color.PaleTurquoise
                        .CellButtonAppearance.BackColor2 = Drawing.Color.MediumTurquoise
                        .CellButtonAppearance.BackGradientStyle = GradientStyle.Vertical
                        .CellButtonAppearance.ForeColor = Drawing.Color.Red
                        .CellButtonAppearance.FontData.Bold = DefaultableBoolean.True
                        .CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                        .CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
                        .CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
                        .Header.Caption = "Rev"
                        .Header.VisiblePosition = 0
                        .MaxWidth = 36
                        .MinWidth = 36
                        .TabStop = False
                        .Width = 36
                    End With

                    With .Columns("CreateDate")
                        .CellActivation = Activation.NoEdit
                        .CellAppearance.TextHAlign = HAlign.Left
                        .Format = "G"
                        .Header.Caption = "Date"
                        .Header.VisiblePosition = 1
                        '.Width = 152
                        .Width = 158
                    End With
                    With .Columns("TransactionType")
                        .CellActivation = Activation.NoEdit
                        .CellAppearance.TextHAlign = HAlign.Left
                        .Header.Caption = "Action"
                        .Header.VisiblePosition = 2
                        '.Width = 58
                        .Width = 60
                    End With
                    With .Columns("RegisterID")
                        .CellActivation = Activation.NoEdit
                        .CellAppearance.TextHAlign = HAlign.Left
                        .Header.Caption = "RegisterID"
                        .Header.VisiblePosition = 3
                        '.Width = 78
                        .Width = 84
                    End With
                    With .Columns("ChargedAmount")
                        .CellActivation = Activation.NoEdit
                        .CellAppearance.TextHAlign = HAlign.Right
                        .Format = "C2"
                        .Header.Caption = "Charge"
                        .Header.VisiblePosition = 4
                        '.Width = 67
                        .Width = 80
                    End With
                    With .Columns("RemainingAmount")
                        .CellActivation = Activation.NoEdit
                        .CellAppearance.TextHAlign = HAlign.Right
                        .Format = "C2"
                        .Header.Caption = "Remaining"
                        .Header.VisiblePosition = 5
                        '.Width = 80
                        .Width = 90
                    End With

                End With

            End With

            .ResumeLayout()

        End With

    End Sub  'grdAction_InitializeLayout

#End Region  'Form Load and Initialization

#Region " Buttons "

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If gWindowsPrinterName <> "DISABLED" Then PrintToWindows()
        'If gOPOSPrinterName <> "DISABLED" Then PrintToOPOS()
        'If gRasterPrinterName <> "DISABLED" Then PrintToRaster()
    End Sub  'btnPrint_Click

    Private Sub btnPrintAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintAll.Click
        If gWindowsPrinterName <> "DISABLED" Then PrintAllToWindows()
        'If gOPOSPrinterName <> "DISABLED" Then PrintAllToOPOS()
        'If gRasterPrinterName <> "DISABLED" Then PrintAllToRaster()
    End Sub  'btnPrintAll_Click

    Private Sub btnFinished_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinished.Click
        lstReceipt.Items.Clear()
        Me.Close()
    End Sub  'btnFinished_Click

#End Region  'Buttons

#Region " Other Methods "

    Private Sub CreateReceipt(ByVal trRow As UltraGridRow)
        If CStr(trRow.Cells("Action").Value) = "Activate" Then
            Exit Sub
        End If
        Dim sQuantity As Integer
        Dim sDescription As String
        Dim sPrice As Double
        Dim sExtPrice As Double
        Dim mExtPrice As String
        Dim sGrandTotal As Double = CDbl(trRow.Cells("Total").Value)
        Dim mGrandTotal As String = sGrandTotal.ToString("""$""#,##0.00")
        Dim sTenderAmount As Double
        Dim mTenderAmount As String
        Dim sTenderType As String
        Dim transactionKey As String = CStr(trRow.Cells("TransactionKey").Value)
        With lstReceipt.Items
            .Clear()
            .Add("Date/Time : " & CDate(trRow.Cells("CreateDate").Value)).ToString()
            .Add("Location  : " & CStr(trRow.Cells("LocationID").Value))
            .Add("Register #: " & CStr(trRow.Cells("RegisterID").Value))
            .Add("Receipt # : " & CStr(trRow.Cells("ReceiptID").Value))
            .Add("Cashier   : " & CStr(trRow.Cells("VendorCashier").Value))
            .Add("----------------------------------------")
            If Len(mTicketID) < 4 Then
                .Add(gStadisTenderText & "#: " & "xxxxxxxxxxxxx")
            Else
                .Add(gStadisTenderText & "#: " & "xxxxxxxxx" & Mid(mTicketID, Len(mTicketID) - 3, 4))
            End If
            .Add("----------------------------------------")
            .Add("  Qty  Description               Price")
            .Add("----------------------------------------")
            For Each iRow As DSTran.ItemRow In ds.Item
                If iRow.TransactionKey = transactionKey Then
                    sQuantity = iRow.Quantity
                    sDescription = Trim(iRow.Description)
                    sPrice = CDbl(iRow.Price)
                    sExtPrice = sPrice * sQuantity
                    mExtPrice = sExtPrice.ToString("""$""#,##0.00")
                    If Len(iRow.Description) > 20 Then
                        .Add(Space(7 - Len(sQuantity)) & sQuantity & Space(3) & Mid(sDescription, 1, 20) & Space(1) & Space(10 - Len(mExtPrice)) & mExtPrice)
                    Else
                        .Add(Space(7 - Len(sQuantity)) & sQuantity & Space(3) & sDescription & Space(20 - Len(sDescription)) & Space(1) & Space(10 - Len(mExtPrice)) & mExtPrice)
                    End If
                End If
            Next
            .Add("----------------------------------------")
            .Add("                  TOTAL: " & Space(13 - Len(mGrandTotal)) & mGrandTotal)
            .Add("----------------------------------------")
            For Each tRow As DSTran.TenderRow In ds.Tender
                If tRow.TransactionKey = transactionKey Then
                    sTenderType = Trim(tRow.TenderType)
                    sTenderAmount = CDbl(tRow.PostedAmount)
                    mTenderAmount = sTenderAmount.ToString("""$""#,##0.00")
                    .Add(Space(23 - Len(sTenderType)) & sTenderType & ": " & Space(13 - Len(mTenderAmount)) & mTenderAmount)
                End If
            Next
        End With
    End Sub  'CreateReceipt

    Private Sub grdTran_ClickCell(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles grdTran.ClickCell
        lstReceipt.Items.Clear()
        grdAction.ActiveRow = Nothing
        Dim grdTranKey As String = CStr(e.Cell.Row.Cells("TransactionKey").Value)
        Dim enumerator As IEnumerable = grdAction.Rows.GetRowEnumerator(GridRowType.DataRow, Nothing, Nothing)
        For Each aRow As UltraWinGrid.UltraGridRow In enumerator
            If (CStr(aRow.Cells("TransactionKey").Value) = grdTranKey) AndAlso (Not aRow.IsFilteredOut) Then
                grdAction.ActiveRow = aRow
                grdAction.ActiveRow.Selected = True
                Exit For
            End If
        Next
        If e.Cell.Row.Band.Index = 0 Then
            CreateReceipt(e.Cell.Row)
        Else
            Dim saveRow As UltraGridRow = grdTran.ActiveRow
            Do While grdTran.ActiveRow.HasParent = True
                grdTran.ActiveRow = grdTran.ActiveRow.ParentRow
            Loop
            CreateReceipt(grdTran.ActiveRow)
            grdTran.ActiveRow = saveRow
        End If
    End Sub  'grdTran_ClickCell

    Private Sub grdAction_ClickCell(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles grdAction.ClickCell
        lstReceipt.Items.Clear()
        grdTran.ActiveRow = Nothing
        Dim grdTranKey As String = CStr(e.Cell.Row.Cells("TransactionKey").Value)
        Dim enumerator As IEnumerable = grdTran.Rows.GetRowEnumerator(GridRowType.DataRow, Nothing, Nothing)
        For Each trRow As UltraWinGrid.UltraGridRow In enumerator
            If (trRow.Band.Index = 0) AndAlso (Not trRow.IsFilteredOut) Then
                If CStr(trRow.Cells("TransactionKey").Value) = grdTranKey Then
                    grdTran.ActiveRow = trRow
                    grdTran.ActiveRow.Selected = True
                    CreateReceipt(trRow)
                    Exit For
                End If
            End If
        Next
    End Sub  'grdAction_ClickCell

    '------------------------------------------------------------------------------
    ' Process grid row reverse buttons ("X")
    '------------------------------------------------------------------------------
    Private Sub grdAction_ClickCellButton(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdAction.ClickCellButton
        If e.Cell.Column Is grdAction.DisplayLayout.Bands(0).Columns("Rev") Then
            Dim dr As DialogResult = MessageBox.Show( _
                    "Reverse SVAction?", _
                    "Confirm", _
                    MessageBoxButtons.YesNo, _
                    MessageBoxIcon.Question)
            Select Case dr
                Case Windows.Forms.DialogResult.Yes
                    ReverseSVAction(e.Cell.Row)
                    Exit Sub
                Case Windows.Forms.DialogResult.No
                    Exit Sub
            End Select
        End If
    End Sub  'grdAction_ClickCellButton

    '------------------------------------------------------------------------------
    ' Reverse SVAction
    '------------------------------------------------------------------------------
    Private Sub ReverseSVAction(ByRef thisRow As UltraWinGrid.UltraGridRow)
        Dim FrmLoginMerge As Form = New FrmLoginMerge
        If FrmLoginMerge.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Try
                Dim sr As New StadisRequest
                With sr
                    .SiteID = gSiteID
                    .TenderTypeID = 1
                    .TenderID = ""
                    .Amount = 0
                    .ReferenceNumber = CStr(thisRow.Cells("StadisAuthorizationID").Value)
                    .VendorID = gVendorID
                    .LocationID = gLocationID
                    .RegisterID = gWSID
                    .ReceiptID = ""
                    .VendorCashier = gVendorCashier
                End With
                Dim sy As StadisReply() = Common.StadisAPI.SVAccountReverse(sr)
                Select Case sy(0).ReturnCode
                    Case 0
                        MsgBox("Operation successful.", MsgBoxStyle.OkOnly, "Reverse")
                        GetHistory(mTicketID)
                        grdAction.Refresh()
                    Case -1
                        MsgBox("Reverse failed - Unable to read SVActions!", MsgBoxStyle.Exclamation, "Reverse")
                    Case -3
                        MsgBox("Reverse failed - Unable to read SVAccount!", MsgBoxStyle.Exclamation, "Reverse")
                    Case Else
                        MsgBox("Reverse failed for unknown reasons!", MsgBoxStyle.Exclamation, "Reverse")
                End Select
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information, "Error in Reverse")
            End Try
        End If
    End Sub  'ReverseSVAction

    Private Sub grdTran_InitializeRow(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles grdTran.InitializeRow
        If e.Row.Band.Index = 2 AndAlso Trim(CStr(e.Row.Cells("TenderType").Value)) <> "TKT" Then
            e.Row.Cells("TenderID").Value = ""
        End If
    End Sub  'grdTran_InitializeRow

    Private Sub grdAction_InitializeRow(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles grdAction.InitializeRow
        e.Row.Cells("Rev").Value = "X"
        If CStr(e.Row.Cells("TransactionKey").Value) = "" Then
            e.Row.CellAppearance.ForeColor = Color.DarkRed
        Else
            e.Row.CellAppearance.ForeColor = Color.Black
        End If
        If CStr(e.Row.Cells("TransactionType").Value) = "BalChk" Then
            e.Row.CellAppearance.ForeColor = Color.Gray
        End If
        If CStr(e.Row.Cells("TransactionType").Value) = "Pro" Then
            e.Row.Cells("RemainingAmount").Value = 0D
        End If
    End Sub  'grdAction_InitializeRow

#End Region  'Other Methods

#Region " Print to Windows "

    Private Sub PrintToWindows()
        With TransactionReport1
            .SetDataSource(ds)
            .SetParameterValue(0, Me.grdTran.ActiveRow.Cells("TransactionKey").Value)
            .SetParameterValue(1, mBalance)
            .SetParameterValue(2, gStadisTenderText)
            .SetParameterValue(3, "xxxxxxxxxx" & Mid(mTicketID, Len(mTicketID) - 3, 4))
            .SetParameterValue(4, "N/A")
            .PrintOptions.PrinterName = gWindowsPrinterName
            .PrintToPrinter(1, True, 1, 1)
        End With
    End Sub  'PrintToWindows

    Private Sub PrintAllToWindows()
        With TransactionsReport1
            .SetDataSource(ds)
            .SetParameterValue(0, Me.grdTran.ActiveRow.Cells("TransactionKey").Value)
            .PrintOptions.PrinterName = gWindowsPrinterName
            .PrintToPrinter(1, True, 1, 1)
        End With
    End Sub  'PrintAllToWindows

#End Region  'Print to Windows

#Region " Print to Raster "

    '    Private Sub PrintToRaster()
    '        lblPrint.Visible = True
    '        Application.DoEvents()
    '        lblPrint.Refresh()
    '        StarC.Visible = True
    '        Dim ESC As String = Mid(Chr(&H1B), 1, 1)
    '        Try
    '            With StarC
    '                .ShowSpooler = True
    '                .Protocol = StarComm.Protocols.SC_Spooler
    '                .SpoolPrinter = gRasterPrinterName
    '                .StarComm_Command(SC_INITIALISE)
    '                .StarComm_InitializePrintJob()
    '                .StarComm_Command(SC_EMPHASIZE_ON)
    '                .StarComm_Command(SC_HEIGHT_X1)
    '                .StarComm_Command(SC_INVERT_OFF)
    '                .StarComm_Command(SC_UNDERLINE_OFF)
    '                .StarComm_Command(SC_UPPERLINE_OFF)
    '                .StarComm_Command(SC_WIDTH_X2)
    '                .StarComm_Output(" ** NOT A RECEIPT **" & LF & LF)
    '                .StarComm_Command(SC_EMPHASIZE_OFF)
    '                .StarComm_Command(SC_WIDTH_X1)
    '                Dim i As Integer
    '                For i = 0 To lstReceipt.Items.Count - 1
    '                    If CBool(InStr(lstReceipt.Items(i).ToString, "TOTAL:", CompareMethod.Text)) Then
    '                        .StarComm_Command(SC_HEIGHT_X2)
    '                        .StarComm_Output(CStr(lstReceipt.Items(i)) & LF)
    '                        .StarComm_Command(SC_HEIGHT_X1)
    '                    Else
    '                        .StarComm_Output(CStr(lstReceipt.Items(i)) & LF)
    '                    End If
    '                Next
    '                .StarComm_Output(LF)
    '                .StarComm_Output("----------------------------------------" & LF)
    '                .StarComm_Command(SC_HEIGHT_X2)
    '                .StarComm_Command(SC_EMPHASIZE_ON)
    '                .StarComm_Output(Space(CInt((40 - Len("BALANCE AS OF " & mScanTimeStamp)) / 2)) & "BALANCE AS OF " & mScanTimeStamp & LF)
    '                .StarComm_Command(SC_WIDTH_X2)
    '                .StarComm_Output(Space(CInt((20 - Len(mBalance)) / 2)) & mBalance & LF)
    '                .StarComm_Command(SC_HEIGHT_X1)
    '                .StarComm_Command(SC_WIDTH_X1)
    '                .StarComm_Output("   * THIS IS NOT AN ACTUAL RECEIPT *" & LF)
    '                .StarComm_Output("* MAY NOT BE USED FOR REFUNDS/EXCHANGES *" & LF)
    '                .StarComm_Command(SC_FEED_FULL_CUT)
    '                .StarComm_Print()
    '            End With
    '        Catch ex As Exception
    '            MsgBox("Error Printing:" & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Print Receipt")
    '            lblPrint.Visible = False
    '        End Try
    '        StarC.Visible = False
    '        lblPrint.Visible = False
    '    End Sub  'PrintToStar

    '    Private Sub PrintAllToRaster()
    '        Dim sQuantity As Integer
    '        Dim sDescription As String
    '        Dim sPrice As Double
    '        Dim sExtPrice As Double
    '        Dim sGrandTotal As Double
    '        Dim sTenderAmount As Double
    '        Dim sTenderType As String
    '        lblPrint.Visible = True
    '        Application.DoEvents()
    '        lblPrint.Refresh()
    '        StarC.Visible = True
    '        Dim ESC As String = Mid(Chr(&H1B), 1, 1)
    '        Try
    '            With StarC
    '                .ShowSpooler = True
    '                .Protocol = StarComm.Protocols.SC_Spooler
    '                .SpoolPrinter = gRasterPrinterName
    '                .StarComm_Command(SC_INITIALISE)
    '                .StarComm_InitializePrintJob()
    '                .StarComm_Command(SC_WIDTH_X2)
    '                .StarComm_Command(SC_EMPHASIZE_ON)
    '                .StarComm_Output("** NOT A RECEIPT **" & LF)
    '                .StarComm_Command(SC_WIDTH_X1)
    '                .StarComm_Output(Space(CInt((40 - Len("History for " & gStadisTenderText & "#:")) / 2)) & "History for " & gStadisTenderText & "#:" & LF)
    '                .StarComm_Command(SC_WIDTH_X2)
    '                .StarComm_Command(SC_HEIGHT_X2)
    '                .StarComm_Output(Space(CInt((20 - Len("xxxxxxxxx" & Mid(mTicketID, Len(mTicketID) - 3, 4))) / 2)) & "xxxxxxxxx" & Mid(mTicketID, Len(mTicketID) - 3, 4) & LF & LF)
    '                .StarComm_Command(SC_EMPHASIZE_OFF)
    '                .StarComm_Command(SC_HEIGHT_X1)
    '                .StarComm_Command(SC_WIDTH_X1)
    '                Dim t As Integer
    '                For t = 0 To grdTran.Rows.Count - 1
    '                    .StarComm_Output("========================================" & LF)
    '                    .StarComm_Output("Date/Time : " & CDate(grdTran.Rows(t).Cells("CreateDate").Value).ToString & LF)
    '                    .StarComm_Output("Location  : " & CStr(grdTran.Rows(t).Cells("LocationID").Value) & LF)
    '                    .StarComm_Output("Register #: " & CStr(grdTran.Rows(t).Cells("RegisterID").Value) & LF)
    '                    .StarComm_Output("Receipt  #: " & CStr(grdTran.Rows(t).Cells("ReceiptID").Value) & LF)
    '                    .StarComm_Output("Cashier   : " & CStr(grdTran.Rows(t).Cells("VendorCashier").Value) & LF)
    '                    sGrandTotal = CDbl(grdTran.Rows(t).Cells("Total").Value)
    '                    .StarComm_Output("----------------------------------------" & LF)
    '                    .StarComm_Output("  Qty  Description               Price" & LF)
    '                    .StarComm_Output("----------------------------------------" & LF)
    '                    For Each iRow As DSTran.ItemRow In ds.Item
    '                        If iRow.TransactionKey = grdTran.Rows(t).Cells("TransactionKey").Value.ToString Then
    '                            sQuantity = iRow.Quantity
    '                            sDescription = Trim(iRow.Description)
    '                            sPrice = CDbl(iRow.Price)
    '                            sExtPrice = sPrice * sQuantity
    '                            If Len(iRow.Description) > 20 Then
    '                                .StarComm_Output(Space(7 - Len(sQuantity)) & sQuantity & Space(3) & Mid(sDescription, 1, 20) & Space(1) & Space(10 - Len("$" & sExtPrice.ToString("0.00"))) & "$" & sExtPrice.ToString("0.00") & LF)
    '                            Else
    '                                .StarComm_Output(Space(7 - Len(sQuantity)) & sQuantity & Space(3) & sDescription & Space(20 - Len(sDescription)) & Space(1) & Space(10 - Len("$" & sExtPrice.ToString("0.00"))) & "$" & sExtPrice.ToString("0.00") & LF)
    '                            End If
    '                        End If
    '                    Next
    '                    .StarComm_Output("----------------------------------------" & LF)
    '                    .StarComm_Output("                  TOTAL: " & Space(13 - Len("$" & sGrandTotal.ToString("0.00"))) & sGrandTotal.ToString("""$""#,##0.00") & LF)
    '                    .StarComm_Output("----------------------------------------" & LF)
    '                    For Each tRow As DSTran.TenderRow In ds.Tender
    '                        If tRow.TransactionKey = grdTran.Rows(t).Cells("TransactionKey").Value.ToString Then
    '                            sTenderType = Trim(tRow.TenderType)
    '                            sTenderAmount = CDbl(tRow.PostedAmount)
    '                            .StarComm_Output(Space(23 - Len(sTenderType)) & sTenderType & ": " & Space(13 - Len(sTenderAmount.ToString("""$""#,##0.00"))) & sTenderAmount.ToString("""$""#,##0.00") & LF)
    '                        End If
    '                    Next
    '                Next
    '                .StarComm_Output(LF)
    '                .StarComm_Output("----------------------------------------" & LF)
    '                .StarComm_Command(SC_HEIGHT_X2)
    '                .StarComm_Command(SC_EMPHASIZE_ON)
    '                .StarComm_Output(Space(CInt((40 - Len("BALANCE AS OF " & mScanTimeStamp)) / 2)) & "BALANCE AS OF " & mScanTimeStamp & LF)
    '                .StarComm_Command(SC_WIDTH_X2)
    '                .StarComm_Output(Space(CInt((20 - Len(mBalance)) / 2)) & mBalance & LF)
    '                .StarComm_Command(SC_HEIGHT_X1)
    '                .StarComm_Command(SC_WIDTH_X1)
    '                .StarComm_Output("   * THIS IS NOT AN ACTUAL RECEIPT *" & LF)
    '                .StarComm_Output("* MAY NOT BE USED FOR REFUNDS/EXCHANGES *" & LF)
    '                .StarComm_Command(SC_FEED_FULL_CUT)
    '                .StarComm_Print()
    '            End With
    '        Catch ex As Exception
    '            MsgBox("Error Printing:" & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Print Receipt")
    '            lblPrint.Visible = False
    '        End Try
    '        lblPrint.Visible = False
    '        StarC.Visible = False
    '    End Sub  'PrintAllToRaster

#End Region  'Print to Raster

#Region " Print to OPOS "

    '    Private Sub PrintToOPOS()
    '        lblPrint.Visible = True
    '        Application.DoEvents()
    '        lblPrint.Refresh()
    '        Dim ESC As String = Mid(Chr(&H1B), 1, 1)
    '        Try
    '            With OPOSPrinter
    '                .Open(gOPOSPrinterName)
    '                .ClaimDevice(10000)
    '                .DeviceEnabled = True
    '                .TransactionPrint(PTR_S_RECEIPT, PTR_TP_TRANSACTION)
    '                .PrintNormal(PTR_S_RECEIPT, ESC & "|cA" & ESC & "|2C" & ESC & "|bC" & "** NOT A RECEIPT **" & LF & LF)
    '                Dim i As Integer
    '                For i = 0 To lstReceipt.Items.Count - 1
    '                    If CBool(InStr(lstReceipt.Items(i).ToString, "TOTAL:", CompareMethod.Text)) Then
    '                        .PrintNormal(PTR_S_RECEIPT, ESC & "|3C" & ESC & "|bC" & lstReceipt.Items(i).ToString & LF)
    '                    Else
    '                        .PrintNormal(PTR_S_RECEIPT, lstReceipt.Items(i).ToString & LF)
    '                    End If
    '                Next
    '                .PrintNormal(PTR_S_RECEIPT, LF)
    '                .PrintNormal(PTR_S_RECEIPT, "----------------------------------------" & LF)
    '                .PrintNormal(PTR_S_RECEIPT, ESC & "|cA" & ESC & "|bC" & ESC & "|3C" & "BALANCE AS OF " & mScanTimeStamp & LF)
    '                .PrintNormal(PTR_S_RECEIPT, ESC & "|cA" & ESC & "|bC" & ESC & "|4C" & mBalance & LF)
    '                .PrintNormal(PTR_S_RECEIPT, LF)
    '                .PrintNormal(PTR_S_RECEIPT, ESC & "|cA" & ESC & "|bC" & "* THIS IS NOT AN ACTUAL RECEIPT *" & LF)
    '                .PrintNormal(PTR_S_RECEIPT, ESC & "|cA" & ESC & "|bC" & "* MAY NOT BE USED FOR REFUNDS/EXCHANGES *" & LF)
    '                .PrintNormal(PTR_S_RECEIPT, LF & LF)
    '                .PrintNormal(PTR_S_RECEIPT, Chr(&H1BS) + "|100fP")
    '                .TransactionPrint(PTR_S_RECEIPT, PTR_TP_NORMAL)
    '                .DeviceEnabled = False
    '                .ReleaseDevice()
    '                .Close()
    '            End With
    '        Catch ex As Exception
    '            MsgBox("Error Printing:" & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Print Receipt")
    '            lblPrint.Visible = False
    '        End Try
    '        lblPrint.Visible = False
    '    End Sub  'PrintToOPOS

    '    Private Sub PrintAllToOPOS()
    '        Dim sQuantity As Integer
    '        Dim sDescription As String
    '        Dim sPrice As Double
    '        Dim sExtPrice As Double
    '        Dim sGrandTotal As Double
    '        Dim sTenderAmount As Double
    '        Dim sTenderType As String
    '        lblPrint.Visible = True
    '        Application.DoEvents()
    '        lblPrint.Refresh()
    '        Dim ESC As String = Mid(Chr(&H1B), 1, 1)
    '        Try
    '            With OPOSPrinter
    '                .Open(gOPOSPrinterName)
    '                .ClaimDevice(10000)
    '                .DeviceEnabled = True
    '                .TransactionPrint(PTR_S_RECEIPT, PTR_TP_TRANSACTION)
    '                .PrintNormal(PTR_S_RECEIPT, ESC & "|cA" & ESC & "|2C" & ESC & "|bC" & "** NOT A RECEIPT **" & LF & LF)
    '                .PrintNormal(PTR_S_RECEIPT, ESC & "|cA" & ESC & "|bC" & "History for " & gSTADISTenderText & "#:" & LF)
    '                .PrintNormal(PTR_S_RECEIPT, ESC & "|cA" & ESC & "|4C" & ESC & "|bC" & "xxxxxxxxx" & Mid(mTicketID, Len(mTicketID) - 3, 4) & LF & LF)
    '                Dim t As Integer
    '                For t = 0 To grdTran.Rows.Count - 1
    '                    .PrintNormal(PTR_S_RECEIPT, "========================================" & LF)
    '                    .PrintNormal(PTR_S_RECEIPT, "Date/Time : " & CDate(grdTran.Rows(t).Cells("CreateDate").Value).ToString & LF)
    '                    .PrintNormal(PTR_S_RECEIPT, "Location  : " & grdTran.Rows(t).Cells("LocationID").Value.ToString & LF)
    '                    .PrintNormal(PTR_S_RECEIPT, "Register #: " & grdTran.Rows(t).Cells("RegisterID").Value.ToString & LF)
    '                    .PrintNormal(PTR_S_RECEIPT, "Receipt  #: " & grdTran.Rows(t).Cells("ReceiptID").Value.ToString & LF)
    '                    .PrintNormal(PTR_S_RECEIPT, "Cashier   : " & grdTran.Rows(t).Cells("VendorCashier").Value.ToString & LF)
    '                    sGrandTotal = CDbl(grdTran.Rows(t).Cells("Total").Value)
    '                    .PrintNormal(PTR_S_RECEIPT, "----------------------------------------" & LF)
    '                    .PrintNormal(PTR_S_RECEIPT, "  Qty  Description               Price" & LF)
    '                    .PrintNormal(PTR_S_RECEIPT, "----------------------------------------" & LF)
    '                    For Each iRow As DataRow In ds.Item
    '                        If iRow.Item("TransactionKey").ToString = grdTran.Rows(t).Cells("TransactionKey").Value.ToString Then
    '                            sQuantity = CInt(iRow.Item("Quantity"))
    '                            sDescription = Trim(iRow.Item("Description").ToString)
    '                            sPrice = CDbl(iRow.Item("Price"))
    '                            sExtPrice = sPrice * sQuantity
    '                            If Len(iRow.Item("Description")) > 20 Then
    '                                .PrintNormal(PTR_S_RECEIPT, Space(7 - Len(sQuantity)) & sQuantity & Space(3) & Mid(sDescription, 1, 20) & Space(1) & Space(10 - Len("$" & sExtPrice.ToString("0.00"))) & "$" & sExtPrice.ToString("0.00") & LF)
    '                            Else
    '                                .PrintNormal(PTR_S_RECEIPT, Space(7 - Len(sQuantity)) & sQuantity & Space(3) & sDescription & Space(20 - Len(sDescription)) & Space(1) & Space(10 - Len("$" & sExtPrice.ToString("0.00"))) & "$" & sExtPrice.ToString("0.00") & LF)
    '                            End If
    '                        End If
    '                    Next
    '                    .PrintNormal(PTR_S_RECEIPT, "----------------------------------------" & LF)
    '                    .PrintNormal(PTR_S_RECEIPT, "                  TOTAL: " & Space(13 - Len(sGrandTotal.ToString("""$""#,##0.00"))) & sGrandTotal.ToString("""$""#,##0.00") & LF)
    '                    .PrintNormal(PTR_S_RECEIPT, "----------------------------------------" & LF)
    '                    For Each tRow As DataRow In ds.Tender
    '                        If tRow.Item("TransactionKey").ToString = grdTran.Rows(t).Cells("TransactionKey").Value.ToString Then
    '                            sTenderType = Trim(CStr(tRow.Item("TenderType")))
    '                            sTenderAmount = CDbl(tRow.Item("PostedAmount"))
    '                            .PrintNormal(PTR_S_RECEIPT, Space(23 - Len(sTenderType)) & sTenderType & ": " & Space(13 - Len(sTenderAmount.ToString("""$""#,##0.00"))) & sTenderAmount.ToString("""$""#,##0.00") & LF)
    '                        End If
    '                    Next
    '                Next
    '                .PrintNormal(PTR_S_RECEIPT, LF)
    '                .PrintNormal(PTR_S_RECEIPT, "----------------------------------------" & LF)
    '                .PrintNormal(PTR_S_RECEIPT, ESC & "|cA" & ESC & "|bC" & ESC & "|3C" & "BALANCE AS OF " & mScanTimeStamp & LF)
    '                .PrintNormal(PTR_S_RECEIPT, ESC & "|cA" & ESC & "|bC" & ESC & "|4C" & mBalance & LF)
    '                .PrintNormal(PTR_S_RECEIPT, LF)
    '                .PrintNormal(PTR_S_RECEIPT, ESC & "|cA" & ESC & "|bC" & "* THIS IS NOT AN ACTUAL RECEIPT *" & LF)
    '                .PrintNormal(PTR_S_RECEIPT, ESC & "|cA" & ESC & "|bC" & "* MAY NOT BE USED FOR REFUNDS/EXCHANGES *")
    '                .PrintNormal(PTR_S_RECEIPT, LF & LF)
    '                .PrintNormal(PTR_S_RECEIPT, Chr(&H1BS) + "|100fP")
    '                .TransactionPrint(PTR_S_RECEIPT, PTR_TP_NORMAL)
    '                .DeviceEnabled = False
    '                .ReleaseDevice()
    '                .Close()
    '            End With
    '        Catch ex As Exception
    '            MsgBox("Error Printing:" & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Print Receipt")
    '            lblPrint.Visible = False
    '        End Try
    '        lblPrint.Visible = False
    '    End Sub  'PrintAllToOPOS

#End Region  'Print to OPOS

End Class  'FrmHistory