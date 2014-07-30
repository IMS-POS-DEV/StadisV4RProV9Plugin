<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmHistory
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
        Me.components = New System.ComponentModel.Container()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Header", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TransactionKey")
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CreateDate")
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("RegisterID")
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("VendorCashier")
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ReceiptID")
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Total")
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Status")
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UserID")
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SeasonID")
        Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EventID")
        Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LocationID")
        Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("VendorID")
        Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Header_Item")
        Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Header_Tender")
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Header_Item", 0)
        Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ItemKey")
        Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TransactionKey")
        Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ItemID")
        Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Description")
        Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Quantity")
        Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Price")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Extension")
        Dim UltraGridBand3 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Header_Tender", 0)
        Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TenderKey")
        Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TransactionKey")
        Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TenderType")
        Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IsStadisTender")
        Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Amount")
        Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PostedAmount")
        Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("StadisAuthorizationID")
        Dim UltraGridColumn40 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TenderID")
        Dim UltraGridColumn81 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Tender_Action")
        Dim UltraGridBand4 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Tender_Action", 2)
        Dim UltraGridColumn88 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CreateDate")
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Amount")
        Dim UltraGridColumn82 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TenderStatus")
        Dim UltraGridColumn83 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TenderKey")
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TransactionKey")
        Dim UltraGridColumn84 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ChargedAmount")
        Dim UltraGridColumn85 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("RemainingAmount")
        Dim UltraGridColumn86 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("RegisterID")
        Dim UltraGridColumn87 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TransactionType")
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("StadisAuthorizationID")
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance55 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand5 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Action", -1)
        Dim UltraGridColumn95 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CreateDate")
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Amount")
        Dim UltraGridColumn89 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TenderStatus")
        Dim UltraGridColumn90 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TenderKey")
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TransactionKey")
        Dim UltraGridColumn91 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ChargedAmount")
        Dim UltraGridColumn92 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("RemainingAmount")
        Dim UltraGridColumn93 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("RegisterID")
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn94 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TransactionType")
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("StadisAuthorizationID")
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmHistory))
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.grdTran = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.DSTranBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSTran = New BalanceCheckV4.DSTran()
        Me.lblTicketStatus = New Infragistics.Win.Misc.UltraLabel()
        Me.lblRemainingAmount = New Infragistics.Win.Misc.UltraLabel()
        Me.lblTicketStatusHdr = New Infragistics.Win.Misc.UltraLabel()
        Me.lblRemainingAmountHdr = New Infragistics.Win.Misc.UltraLabel()
        Me.lblTicketBarcode = New Infragistics.Win.Misc.UltraLabel()
        Me.lblTicketBarcodeHdr = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.grdAction = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.TransactionReport1 = New BalanceCheckV4.TransactionReport()
        Me.TransactionsReport1 = New BalanceCheckV4.TransactionsReport()
        Me.ActionBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.lblPrint = New System.Windows.Forms.Label()
        Me.UltraTabControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.StarC = New StarComm()
        Me.btnPrintAll = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnFinished = New System.Windows.Forms.Button()
        Me.lstReceipt = New System.Windows.Forms.ListBox()
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.grdTran, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSTranBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSTran, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl2.SuspendLayout()
        CType(Me.grdAction, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ActionBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.grdTran)
        Me.UltraTabPageControl1.Controls.Add(Me.lblTicketStatus)
        Me.UltraTabPageControl1.Controls.Add(Me.lblRemainingAmount)
        Me.UltraTabPageControl1.Controls.Add(Me.lblTicketStatusHdr)
        Me.UltraTabPageControl1.Controls.Add(Me.lblRemainingAmountHdr)
        Me.UltraTabPageControl1.Controls.Add(Me.lblTicketBarcode)
        Me.UltraTabPageControl1.Controls.Add(Me.lblTicketBarcodeHdr)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(1, 20)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(512, 479)
        '
        'grdTran
        '
        Me.grdTran.DataMember = "Header"
        Me.grdTran.DataSource = Me.DSTranBindingSource
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Me.grdTran.DisplayLayout.Appearance = Appearance2
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn13.Header.VisiblePosition = 1
        UltraGridColumn14.Header.VisiblePosition = 2
        UltraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn15.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn15.Header.Caption = "Register ID"
        UltraGridColumn15.Header.TextOrientation = New Infragistics.Win.TextOrientationInfo(0, Infragistics.Win.TextFlowDirection.Horizontal)
        UltraGridColumn15.Header.VisiblePosition = 3
        UltraGridColumn15.Width = 80
        UltraGridColumn16.Header.VisiblePosition = 4
        UltraGridColumn17.Header.VisiblePosition = 5
        UltraGridColumn18.Header.VisiblePosition = 6
        UltraGridColumn19.Header.VisiblePosition = 7
        UltraGridColumn20.Header.VisiblePosition = 8
        UltraGridColumn21.Header.VisiblePosition = 9
        UltraGridColumn22.Header.VisiblePosition = 10
        UltraGridColumn23.Header.VisiblePosition = 11
        UltraGridColumn24.Header.VisiblePosition = 12
        UltraGridColumn25.Header.VisiblePosition = 13
        UltraGridColumn26.Header.VisiblePosition = 14
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn22, UltraGridColumn23, UltraGridColumn24, UltraGridColumn25, UltraGridColumn26})
        UltraGridBand1.ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.[True]
        UltraGridBand1.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
        UltraGridBand1.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None
        UltraGridBand1.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed
        UltraGridBand1.Override.ExpansionIndicator = Infragistics.Win.UltraWinGrid.ShowExpansionIndicator.CheckOnDisplay
        Appearance1.BackColor = System.Drawing.Color.LightSeaGreen
        Appearance1.BackColor2 = System.Drawing.Color.Teal
        Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance1.FontData.BoldAsString = "True"
        Appearance1.ForeColor = System.Drawing.Color.White
        Appearance1.TextHAlignAsString = "Center"
        UltraGridBand1.Override.HeaderAppearance = Appearance1
        UltraGridBand1.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        UltraGridBand1.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        UltraGridColumn27.Header.VisiblePosition = 0
        UltraGridColumn28.Header.VisiblePosition = 1
        UltraGridColumn29.Header.VisiblePosition = 2
        UltraGridColumn30.Header.VisiblePosition = 3
        UltraGridColumn31.Header.VisiblePosition = 4
        UltraGridColumn32.Header.VisiblePosition = 5
        UltraGridColumn2.Header.VisiblePosition = 6
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn27, UltraGridColumn28, UltraGridColumn29, UltraGridColumn30, UltraGridColumn31, UltraGridColumn32, UltraGridColumn2})
        UltraGridColumn33.Header.VisiblePosition = 0
        UltraGridColumn34.Header.VisiblePosition = 1
        UltraGridColumn35.Header.VisiblePosition = 2
        UltraGridColumn36.Header.VisiblePosition = 3
        UltraGridColumn37.Header.VisiblePosition = 4
        UltraGridColumn38.Header.VisiblePosition = 5
        UltraGridColumn39.Header.VisiblePosition = 6
        UltraGridColumn40.Header.VisiblePosition = 7
        UltraGridColumn81.Header.VisiblePosition = 8
        UltraGridBand3.Columns.AddRange(New Object() {UltraGridColumn33, UltraGridColumn34, UltraGridColumn35, UltraGridColumn36, UltraGridColumn37, UltraGridColumn38, UltraGridColumn39, UltraGridColumn40, UltraGridColumn81})
        UltraGridColumn88.Header.VisiblePosition = 0
        UltraGridColumn3.Header.VisiblePosition = 1
        UltraGridColumn82.Header.VisiblePosition = 2
        UltraGridColumn83.Header.VisiblePosition = 3
        UltraGridColumn4.Header.VisiblePosition = 5
        UltraGridColumn84.Header.VisiblePosition = 4
        UltraGridColumn85.Header.VisiblePosition = 6
        UltraGridColumn86.Header.VisiblePosition = 7
        UltraGridColumn87.Header.VisiblePosition = 8
        UltraGridColumn5.Header.VisiblePosition = 9
        UltraGridBand4.Columns.AddRange(New Object() {UltraGridColumn88, UltraGridColumn3, UltraGridColumn82, UltraGridColumn83, UltraGridColumn4, UltraGridColumn84, UltraGridColumn85, UltraGridColumn86, UltraGridColumn87, UltraGridColumn5})
        Me.grdTran.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.grdTran.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.grdTran.DisplayLayout.BandsSerializer.Add(UltraGridBand3)
        Me.grdTran.DisplayLayout.BandsSerializer.Add(UltraGridBand4)
        Me.grdTran.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.grdTran.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdTran.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.grdTran.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdTran.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdTran.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grdTran.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect
        Appearance30.BackColor = System.Drawing.Color.White
        Appearance30.ForeColor = System.Drawing.Color.Black
        Me.grdTran.DisplayLayout.Override.EditCellAppearance = Appearance30
        Appearance31.ForeColor = System.Drawing.Color.Black
        Me.grdTran.DisplayLayout.Override.FilterCellAppearance = Appearance31
        Appearance32.ForeColor = System.Drawing.Color.Black
        Me.grdTran.DisplayLayout.Override.FilterCellAppearanceActive = Appearance32
        Appearance41.BackColor = System.Drawing.Color.AliceBlue
        Me.grdTran.DisplayLayout.Override.FilteredInCellAppearance = Appearance41
        Appearance42.BackColor = System.Drawing.Color.AliceBlue
        Me.grdTran.DisplayLayout.Override.FilteredInRowAppearance = Appearance42
        Appearance43.BackColor = System.Drawing.Color.AliceBlue
        Appearance43.ForeColor = System.Drawing.Color.Black
        Me.grdTran.DisplayLayout.Override.FilterOperatorAppearance = Appearance43
        Me.grdTran.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.AboveOperand
        Appearance44.ForeColor = System.Drawing.Color.Black
        Me.grdTran.DisplayLayout.Override.FilterRowAppearance = Appearance44
        Appearance45.ForeColor = System.Drawing.Color.Black
        Me.grdTran.DisplayLayout.Override.FilterRowAppearanceActive = Appearance45
        Appearance46.BackColor = System.Drawing.Color.AliceBlue
        Appearance46.ForeColor = System.Drawing.Color.Black
        Me.grdTran.DisplayLayout.Override.FilterRowPromptAppearance = Appearance46
        Appearance47.BackColor = System.Drawing.SystemColors.Control
        Appearance47.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance47.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance47.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance47.BorderColor = System.Drawing.SystemColors.Window
        Me.grdTran.DisplayLayout.Override.GroupByRowAppearance = Appearance47
        Appearance48.BackColor = System.Drawing.Color.PaleTurquoise
        Appearance48.BackColor2 = System.Drawing.Color.MediumTurquoise
        Appearance48.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance48.ForeColor = System.Drawing.Color.Black
        Me.grdTran.DisplayLayout.Override.HeaderAppearance = Appearance48
        Me.grdTran.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdTran.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance49.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.grdTran.DisplayLayout.Override.RowAlternateAppearance = Appearance49
        Appearance50.BackColor = System.Drawing.Color.White
        Appearance50.BorderColor = System.Drawing.Color.Silver
        Appearance50.FontData.SizeInPoints = 10.0!
        Appearance50.ForeColor = System.Drawing.Color.Black
        Me.grdTran.DisplayLayout.Override.RowAppearance = Appearance50
        Appearance51.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Appearance51.BorderAlpha = Infragistics.Win.Alpha.Opaque
        Appearance51.BorderColor = System.Drawing.Color.Black
        Appearance51.BorderColor3DBase = System.Drawing.Color.White
        Me.grdTran.DisplayLayout.Override.RowSelectorAppearance = Appearance51
        Appearance52.BorderAlpha = Infragistics.Win.Alpha.Opaque
        Appearance52.BorderColor = System.Drawing.Color.Black
        Appearance52.BorderColor3DBase = System.Drawing.Color.White
        Me.grdTran.DisplayLayout.Override.RowSelectorHeaderAppearance = Appearance52
        Me.grdTran.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.ColumnChooserButton
        Me.grdTran.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.None
        Me.grdTran.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdTran.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed
        Appearance53.BackColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(133, Byte), Integer), CType(CType(207, Byte), Integer))
        Appearance53.ForeColor = System.Drawing.Color.White
        Me.grdTran.DisplayLayout.Override.SelectedCellAppearance = Appearance53
        Appearance54.BackColor = System.Drawing.Color.LightCyan
        Appearance54.ForeColor = System.Drawing.Color.Blue
        Me.grdTran.DisplayLayout.Override.SelectedRowAppearance = Appearance54
        Me.grdTran.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.grdTran.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.grdTran.DisplayLayout.Override.SpecialRowSeparator = Infragistics.Win.UltraWinGrid.SpecialRowSeparator.FilterRow
        Appearance55.BackColor = System.Drawing.SystemColors.ControlDark
        Me.grdTran.DisplayLayout.Override.SpecialRowSeparatorAppearance = Appearance55
        Me.grdTran.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.grdTran.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.grdTran.Location = New System.Drawing.Point(5, 66)
        Me.grdTran.Name = "grdTran"
        Me.grdTran.Size = New System.Drawing.Size(502, 397)
        Me.grdTran.TabIndex = 63
        '
        'DSTranBindingSource
        '
        Me.DSTranBindingSource.DataSource = Me.DSTran
        Me.DSTranBindingSource.Position = 0
        '
        'DSTran
        '
        Me.DSTran.DataSetName = "DSTran"
        Me.DSTran.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'lblTicketStatus
        '
        Appearance26.BackColor = System.Drawing.Color.White
        Appearance26.BorderColor = System.Drawing.Color.SteelBlue
        Appearance26.FontData.BoldAsString = "True"
        Appearance26.FontData.SizeInPoints = 11.0!
        Appearance26.TextVAlignAsString = "Middle"
        Me.lblTicketStatus.Appearance = Appearance26
        Me.lblTicketStatus.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid
        Me.lblTicketStatus.Location = New System.Drawing.Point(250, 39)
        Me.lblTicketStatus.Name = "lblTicketStatus"
        Me.lblTicketStatus.Padding = New System.Drawing.Size(4, 0)
        Me.lblTicketStatus.Size = New System.Drawing.Size(105, 28)
        Me.lblTicketStatus.TabIndex = 62
        '
        'lblRemainingAmount
        '
        Appearance24.BackColor = System.Drawing.Color.White
        Appearance24.BorderColor = System.Drawing.Color.SteelBlue
        Appearance24.FontData.BoldAsString = "True"
        Appearance24.FontData.SizeInPoints = 11.0!
        Appearance24.TextHAlignAsString = "Right"
        Appearance24.TextVAlignAsString = "Middle"
        Me.lblRemainingAmount.Appearance = Appearance24
        Me.lblRemainingAmount.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid
        Me.lblRemainingAmount.Location = New System.Drawing.Point(354, 39)
        Me.lblRemainingAmount.Name = "lblRemainingAmount"
        Me.lblRemainingAmount.Padding = New System.Drawing.Size(6, 0)
        Me.lblRemainingAmount.Size = New System.Drawing.Size(135, 28)
        Me.lblRemainingAmount.TabIndex = 60
        '
        'lblTicketStatusHdr
        '
        Appearance27.BackColor = System.Drawing.Color.LightSeaGreen
        Appearance27.BackColor2 = System.Drawing.Color.Teal
        Appearance27.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance27.BorderAlpha = Infragistics.Win.Alpha.Opaque
        Appearance27.BorderColor = System.Drawing.SystemColors.InactiveBorder
        Appearance27.FontData.BoldAsString = "True"
        Appearance27.ForeColor = System.Drawing.Color.White
        Appearance27.TextHAlignAsString = "Center"
        Appearance27.TextVAlignAsString = "Middle"
        Me.lblTicketStatusHdr.Appearance = Appearance27
        Me.lblTicketStatusHdr.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid
        Me.lblTicketStatusHdr.Location = New System.Drawing.Point(250, 16)
        Me.lblTicketStatusHdr.Name = "lblTicketStatusHdr"
        Me.lblTicketStatusHdr.Size = New System.Drawing.Size(105, 24)
        Me.lblTicketStatusHdr.TabIndex = 61
        Me.lblTicketStatusHdr.Text = "Status"
        Me.lblTicketStatusHdr.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'lblRemainingAmountHdr
        '
        Appearance25.BackColor = System.Drawing.Color.LightSeaGreen
        Appearance25.BackColor2 = System.Drawing.Color.Teal
        Appearance25.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance25.BorderColor = System.Drawing.SystemColors.InactiveBorder
        Appearance25.FontData.BoldAsString = "True"
        Appearance25.ForeColor = System.Drawing.Color.White
        Appearance25.TextHAlignAsString = "Center"
        Appearance25.TextVAlignAsString = "Middle"
        Me.lblRemainingAmountHdr.Appearance = Appearance25
        Me.lblRemainingAmountHdr.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid
        Me.lblRemainingAmountHdr.Location = New System.Drawing.Point(354, 16)
        Me.lblRemainingAmountHdr.Name = "lblRemainingAmountHdr"
        Me.lblRemainingAmountHdr.Size = New System.Drawing.Size(136, 24)
        Me.lblRemainingAmountHdr.TabIndex = 59
        Me.lblRemainingAmountHdr.Text = "Remaining Amount"
        Me.lblRemainingAmountHdr.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'lblTicketBarcode
        '
        Appearance28.BackColor = System.Drawing.Color.White
        Appearance28.BorderColor = System.Drawing.Color.SteelBlue
        Appearance28.FontData.BoldAsString = "True"
        Appearance28.FontData.SizeInPoints = 11.0!
        Appearance28.TextVAlignAsString = "Middle"
        Me.lblTicketBarcode.Appearance = Appearance28
        Me.lblTicketBarcode.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid
        Me.lblTicketBarcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTicketBarcode.Location = New System.Drawing.Point(25, 39)
        Me.lblTicketBarcode.Name = "lblTicketBarcode"
        Me.lblTicketBarcode.Padding = New System.Drawing.Size(4, 0)
        Me.lblTicketBarcode.Size = New System.Drawing.Size(228, 28)
        Me.lblTicketBarcode.TabIndex = 58
        '
        'lblTicketBarcodeHdr
        '
        Appearance29.BackColor = System.Drawing.Color.LightSeaGreen
        Appearance29.BackColor2 = System.Drawing.Color.Teal
        Appearance29.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance29.BorderColor = System.Drawing.SystemColors.InactiveBorder
        Appearance29.FontData.BoldAsString = "True"
        Appearance29.ForeColor = System.Drawing.Color.White
        Appearance29.TextHAlignAsString = "Center"
        Appearance29.TextVAlignAsString = "Middle"
        Me.lblTicketBarcodeHdr.Appearance = Appearance29
        Me.lblTicketBarcodeHdr.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid
        Me.lblTicketBarcodeHdr.Location = New System.Drawing.Point(24, 16)
        Me.lblTicketBarcodeHdr.Name = "lblTicketBarcodeHdr"
        Me.lblTicketBarcodeHdr.Size = New System.Drawing.Size(230, 24)
        Me.lblTicketBarcodeHdr.TabIndex = 57
        Me.lblTicketBarcodeHdr.Text = "Ticket / Gift Card"
        Me.lblTicketBarcodeHdr.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.grdAction)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(512, 479)
        '
        'grdAction
        '
        Me.grdAction.DataMember = "Action"
        Me.grdAction.DataSource = Me.DSTranBindingSource
        Appearance33.BackColor = System.Drawing.Color.Transparent
        Appearance33.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Appearance33.FontData.SizeInPoints = 10.0!
        Me.grdAction.DisplayLayout.Appearance = Appearance33
        UltraGridColumn95.Header.VisiblePosition = 0
        UltraGridColumn6.Header.VisiblePosition = 1
        UltraGridColumn89.Header.VisiblePosition = 2
        UltraGridColumn90.Header.VisiblePosition = 3
        UltraGridColumn7.Header.VisiblePosition = 5
        UltraGridColumn91.Header.VisiblePosition = 6
        UltraGridColumn91.Width = 70
        UltraGridColumn92.Header.VisiblePosition = 7
        Appearance3.TextHAlignAsString = "Left"
        UltraGridColumn93.CellAppearance = Appearance3
        UltraGridColumn93.Header.Caption = "Register ID"
        UltraGridColumn93.Header.VisiblePosition = 4
        UltraGridColumn93.Width = 84
        UltraGridColumn94.Header.VisiblePosition = 8
        UltraGridColumn8.Header.VisiblePosition = 9
        UltraGridBand5.Columns.AddRange(New Object() {UltraGridColumn95, UltraGridColumn6, UltraGridColumn89, UltraGridColumn90, UltraGridColumn7, UltraGridColumn91, UltraGridColumn92, UltraGridColumn93, UltraGridColumn94, UltraGridColumn8})
        Me.grdAction.DisplayLayout.BandsSerializer.Add(UltraGridBand5)
        Me.grdAction.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.grdAction.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance38.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance38.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance38.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance38.BorderColor = System.Drawing.SystemColors.Window
        Me.grdAction.DisplayLayout.GroupByBox.Appearance = Appearance38
        Appearance7.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdAction.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance7
        Me.grdAction.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grdAction.DisplayLayout.GroupByBox.Hidden = True
        Appearance8.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance8.BackColor2 = System.Drawing.SystemColors.Control
        Appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance8.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdAction.DisplayLayout.GroupByBox.PromptAppearance = Appearance8
        Me.grdAction.DisplayLayout.MaxColScrollRegions = 1
        Me.grdAction.DisplayLayout.MaxRowScrollRegions = 1
        Appearance9.BackColor = System.Drawing.SystemColors.Window
        Appearance9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grdAction.DisplayLayout.Override.ActiveCellAppearance = Appearance9
        Appearance10.BackColor = System.Drawing.SystemColors.Highlight
        Appearance10.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdAction.DisplayLayout.Override.ActiveRowAppearance = Appearance10
        Me.grdAction.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
        Me.grdAction.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None
        Me.grdAction.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed
        Me.grdAction.DisplayLayout.Override.AllowRowLayoutCellSizing = Infragistics.Win.UltraWinGrid.RowLayoutSizing.None
        Me.grdAction.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.grdAction.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Me.grdAction.DisplayLayout.Override.CardAreaAppearance = Appearance11
        Appearance12.BorderColor = System.Drawing.Color.Silver
        Appearance12.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.grdAction.DisplayLayout.Override.CellAppearance = Appearance12
        Me.grdAction.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.grdAction.DisplayLayout.Override.CellPadding = 0
        Me.grdAction.DisplayLayout.Override.ExpansionIndicator = Infragistics.Win.UltraWinGrid.ShowExpansionIndicator.Never
        Appearance13.BackColor = System.Drawing.SystemColors.Control
        Appearance13.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance13.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance13.BorderColor = System.Drawing.SystemColors.Window
        Me.grdAction.DisplayLayout.Override.GroupByRowAppearance = Appearance13
        Appearance14.BackColor = System.Drawing.Color.LightSeaGreen
        Appearance14.BackColor2 = System.Drawing.Color.Teal
        Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance14.FontData.BoldAsString = "True"
        Appearance14.ForeColor = System.Drawing.Color.White
        Appearance14.TextHAlignAsString = "Center"
        Me.grdAction.DisplayLayout.Override.HeaderAppearance = Appearance14
        Me.grdAction.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdAction.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Me.grdAction.DisplayLayout.Override.MaxSelectedRows = 1
        Appearance19.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.grdAction.DisplayLayout.Override.RowAlternateAppearance = Appearance19
        Appearance15.BackColor = System.Drawing.Color.White
        Appearance15.BorderColor = System.Drawing.Color.Silver
        Me.grdAction.DisplayLayout.Override.RowAppearance = Appearance15
        Me.grdAction.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdAction.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed
        Me.grdAction.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Appearance16.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grdAction.DisplayLayout.Override.TemplateAddRowAppearance = Appearance16
        Me.grdAction.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.grdAction.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.grdAction.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.grdAction.Location = New System.Drawing.Point(15, 17)
        Me.grdAction.Name = "grdAction"
        Me.grdAction.Size = New System.Drawing.Size(488, 449)
        Me.grdAction.TabIndex = 46
        Me.grdAction.Text = "UltraGrid1"
        '
        'ActionBindingSource
        '
        Me.ActionBindingSource.DataMember = "Action"
        Me.ActionBindingSource.DataSource = Me.DSTran
        '
        'BindingSource1
        '
        Me.BindingSource1.DataSource = Me.DSTran
        Me.BindingSource1.Position = 0
        '
        'lblPrint
        '
        Me.lblPrint.BackColor = System.Drawing.Color.NavajoWhite
        Me.lblPrint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPrint.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrint.Location = New System.Drawing.Point(308, 225)
        Me.lblPrint.Name = "lblPrint"
        Me.lblPrint.Size = New System.Drawing.Size(264, 160)
        Me.lblPrint.TabIndex = 53
        Me.lblPrint.Text = "Printing Receipt..." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Please Wait!"
        Me.lblPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblPrint.Visible = False
        '
        'UltraTabControl1
        '
        Appearance22.BackColor = System.Drawing.Color.BlanchedAlmond
        Appearance22.BackGradientStyle = Infragistics.Win.GradientStyle.None
        Me.UltraTabControl1.ActiveTabAppearance = Appearance22
        Appearance39.BackColor = System.Drawing.Color.BlanchedAlmond
        Appearance39.BackColor2 = System.Drawing.Color.BurlyWood
        Appearance39.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance39.FontData.BoldAsString = "True"
        Appearance39.ForeColor = System.Drawing.Color.MidnightBlue
        Me.UltraTabControl1.Appearance = Appearance39
        Appearance23.BackColor = System.Drawing.Color.BlanchedAlmond
        Appearance23.BackGradientStyle = Infragistics.Win.GradientStyle.None
        Me.UltraTabControl1.ClientAreaAppearance = Appearance23
        Me.UltraTabControl1.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl1)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl2)
        Me.UltraTabControl1.InterTabSpacing = New Infragistics.Win.DefaultableInteger(-5)
        Me.UltraTabControl1.Location = New System.Drawing.Point(13, 16)
        Me.UltraTabControl1.Name = "UltraTabControl1"
        Me.UltraTabControl1.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.UltraTabControl1.Size = New System.Drawing.Size(514, 500)
        Me.UltraTabControl1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Excel
        Appearance20.BackColor = System.Drawing.Color.Transparent
        Me.UltraTabControl1.TabHeaderAreaAppearance = Appearance20
        Me.UltraTabControl1.TabIndex = 55
        Me.UltraTabControl1.TabLayoutStyle = Infragistics.Win.UltraWinTabs.TabLayoutStyle.SingleRowTabsPerRow
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "Transactions"
        UltraTab2.TabPage = Me.UltraTabPageControl2
        UltraTab2.Text = "Stored Value Acct Activity"
        Me.UltraTabControl1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1, UltraTab2})
        Me.UltraTabControl1.TabsPerRow = 2
        Me.UltraTabControl1.TabStop = False
        Me.UltraTabControl1.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Standard
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(512, 479)
        '
        'StarC
        '
        Me.StarC.BaudRate = StarComm.BaudRates.SC_9600
        Me.StarC.DataBits = StarComm.DataBitTypes.SC_DATABITS_8
        Me.StarC.Location = New System.Drawing.Point(898, 371)
        Me.StarC.Name = "StarC"
        Me.StarC.OutputFile = ""
        Me.StarC.ParallelPortNum = 1
        Me.StarC.Parity = StarComm.ParityTypes.SC_PARITY_NONE
        Me.StarC.PrinterIP = "192.168.1.1"
        Me.StarC.Protocol = StarComm.Protocols.SC_DirectParallel
        Me.StarC.SerialPortNum = 1
        Me.StarC.ShowDirectParallel = True
        Me.StarC.ShowDirectSerial = True
        Me.StarC.ShowFileOutput = False
        Me.StarC.ShowSpooler = True
        Me.StarC.ShowTCPIP = False
        Me.StarC.Size = New System.Drawing.Size(250, 120)
        Me.StarC.SpoolPrinter = "Lexmark C543"
        Me.StarC.TabIndex = 54
        Me.StarC.TCPPort = 9100
        Me.StarC.Visible = False
        '
        'btnPrintAll
        '
        Me.btnPrintAll.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintAll.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.btnPrintAll.Image = Global.BalanceCheckV4.My.Resources.Resources.printer31
        Me.btnPrintAll.Location = New System.Drawing.Point(401, 532)
        Me.btnPrintAll.Name = "btnPrintAll"
        Me.btnPrintAll.Size = New System.Drawing.Size(100, 60)
        Me.btnPrintAll.TabIndex = 51
        Me.btnPrintAll.Text = "Print All"
        Me.btnPrintAll.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrintAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnPrintAll.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.btnPrint.Image = Global.BalanceCheckV4.My.Resources.Resources.printer1
        Me.btnPrint.Location = New System.Drawing.Point(285, 532)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(100, 60)
        Me.btnPrint.TabIndex = 52
        Me.btnPrint.Text = "Print Single"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnFinished
        '
        Me.btnFinished.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFinished.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.btnFinished.Image = Global.BalanceCheckV4.My.Resources.Resources._exit
        Me.btnFinished.Location = New System.Drawing.Point(517, 532)
        Me.btnFinished.Name = "btnFinished"
        Me.btnFinished.Size = New System.Drawing.Size(100, 60)
        Me.btnFinished.TabIndex = 50
        Me.btnFinished.Text = "Finished"
        Me.btnFinished.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnFinished.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnFinished.UseVisualStyleBackColor = True
        '
        'lstReceipt
        '
        Me.lstReceipt.BackColor = System.Drawing.Color.FloralWhite
        Me.lstReceipt.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstReceipt.FormattingEnabled = True
        Me.lstReceipt.ItemHeight = 16
        Me.lstReceipt.Location = New System.Drawing.Point(543, 16)
        Me.lstReceipt.Name = "lstReceipt"
        Me.lstReceipt.Size = New System.Drawing.Size(344, 500)
        Me.lstReceipt.TabIndex = 49
        '
        'FrmHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(902, 610)
        Me.Controls.Add(Me.lblPrint)
        Me.Controls.Add(Me.UltraTabControl1)
        Me.Controls.Add(Me.StarC)
        Me.Controls.Add(Me.btnPrintAll)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnFinished)
        Me.Controls.Add(Me.lstReceipt)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmHistory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ticket History"
        Me.UltraTabPageControl1.ResumeLayout(False)
        CType(Me.grdTran, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSTranBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSTran, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl2.ResumeLayout(False)
        CType(Me.grdAction, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ActionBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TransactionReport1 As BalanceCheckV4.TransactionReport
    Friend WithEvents TransactionsReport1 As BalanceCheckV4.TransactionsReport
    Friend WithEvents DSTran As BalanceCheckV4.DSTran
    Friend WithEvents ActionBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DSTranBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents lblPrint As System.Windows.Forms.Label
    Friend WithEvents UltraTabControl1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents grdTran As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents lblTicketStatus As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblRemainingAmount As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblTicketStatusHdr As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblRemainingAmountHdr As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblTicketBarcode As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblTicketBarcodeHdr As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents grdAction As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents StarC As StarComm
    Friend WithEvents btnPrintAll As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnFinished As System.Windows.Forms.Button
    Friend WithEvents lstReceipt As System.Windows.Forms.ListBox
End Class
