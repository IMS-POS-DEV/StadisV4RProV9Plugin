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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand5 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Action", -1)
        Dim UltraGridColumn95 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CreateDate")
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Amount")
        Dim UltraGridColumn89 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TenderStatus")
        Dim UltraGridColumn90 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TenderKey")
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TransactionKey")
        Dim UltraGridColumn91 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ChargedAmount")
        Dim UltraGridColumn92 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("RemainingAmount")
        Dim UltraGridColumn93 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("RegisterID")
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn94 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TransactionType")
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("StadisAuthorizationID")
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmHistory))
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.grdTran = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.DSTranBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSTran = New StadisV4RProV9Plugin.DSTran()
        Me.lblTicketStatus = New Infragistics.Win.Misc.UltraLabel()
        Me.lblRemainingAmount = New Infragistics.Win.Misc.UltraLabel()
        Me.lblTicketStatusHdr = New Infragistics.Win.Misc.UltraLabel()
        Me.lblRemainingAmountHdr = New Infragistics.Win.Misc.UltraLabel()
        Me.lblTicketBarcode = New Infragistics.Win.Misc.UltraLabel()
        Me.lblTicketBarcodeHdr = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.grdAction = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ActionBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.lblPrint = New System.Windows.Forms.Label()
        Me.UltraTabControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.lstReceipt = New System.Windows.Forms.ListBox()
        Me.btnPrint = New Infragistics.Win.Misc.UltraButton()
        Me.btnPrintAll = New Infragistics.Win.Misc.UltraButton()
        Me.btnFinished = New Infragistics.Win.Misc.UltraButton()
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
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Me.grdTran.DisplayLayout.Appearance = Appearance1
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
        Appearance2.BackColor = System.Drawing.Color.LightSeaGreen
        Appearance2.BackColor2 = System.Drawing.Color.Teal
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.FontData.BoldAsString = "True"
        Appearance2.ForeColor = System.Drawing.Color.White
        Appearance2.TextHAlignAsString = "Center"
        UltraGridBand1.Override.HeaderAppearance = Appearance2
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
        Appearance3.BackColor = System.Drawing.Color.White
        Appearance3.ForeColor = System.Drawing.Color.Black
        Me.grdTran.DisplayLayout.Override.EditCellAppearance = Appearance3
        Appearance4.ForeColor = System.Drawing.Color.Black
        Me.grdTran.DisplayLayout.Override.FilterCellAppearance = Appearance4
        Appearance5.ForeColor = System.Drawing.Color.Black
        Me.grdTran.DisplayLayout.Override.FilterCellAppearanceActive = Appearance5
        Appearance6.BackColor = System.Drawing.Color.AliceBlue
        Me.grdTran.DisplayLayout.Override.FilteredInCellAppearance = Appearance6
        Appearance7.BackColor = System.Drawing.Color.AliceBlue
        Me.grdTran.DisplayLayout.Override.FilteredInRowAppearance = Appearance7
        Appearance8.BackColor = System.Drawing.Color.AliceBlue
        Appearance8.ForeColor = System.Drawing.Color.Black
        Me.grdTran.DisplayLayout.Override.FilterOperatorAppearance = Appearance8
        Me.grdTran.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.AboveOperand
        Appearance9.ForeColor = System.Drawing.Color.Black
        Me.grdTran.DisplayLayout.Override.FilterRowAppearance = Appearance9
        Appearance10.ForeColor = System.Drawing.Color.Black
        Me.grdTran.DisplayLayout.Override.FilterRowAppearanceActive = Appearance10
        Appearance11.BackColor = System.Drawing.Color.AliceBlue
        Appearance11.ForeColor = System.Drawing.Color.Black
        Me.grdTran.DisplayLayout.Override.FilterRowPromptAppearance = Appearance11
        Appearance12.BackColor = System.Drawing.SystemColors.Control
        Appearance12.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance12.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance12.BorderColor = System.Drawing.SystemColors.Window
        Me.grdTran.DisplayLayout.Override.GroupByRowAppearance = Appearance12
        Appearance13.BackColor = System.Drawing.Color.PaleTurquoise
        Appearance13.BackColor2 = System.Drawing.Color.MediumTurquoise
        Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance13.ForeColor = System.Drawing.Color.Black
        Me.grdTran.DisplayLayout.Override.HeaderAppearance = Appearance13
        Me.grdTran.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdTran.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance14.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.grdTran.DisplayLayout.Override.RowAlternateAppearance = Appearance14
        Appearance15.BackColor = System.Drawing.Color.White
        Appearance15.BorderColor = System.Drawing.Color.Silver
        Appearance15.FontData.SizeInPoints = 10.0!
        Appearance15.ForeColor = System.Drawing.Color.Black
        Me.grdTran.DisplayLayout.Override.RowAppearance = Appearance15
        Appearance16.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Appearance16.BorderAlpha = Infragistics.Win.Alpha.Opaque
        Appearance16.BorderColor = System.Drawing.Color.Black
        Appearance16.BorderColor3DBase = System.Drawing.Color.White
        Me.grdTran.DisplayLayout.Override.RowSelectorAppearance = Appearance16
        Appearance17.BorderAlpha = Infragistics.Win.Alpha.Opaque
        Appearance17.BorderColor = System.Drawing.Color.Black
        Appearance17.BorderColor3DBase = System.Drawing.Color.White
        Me.grdTran.DisplayLayout.Override.RowSelectorHeaderAppearance = Appearance17
        Me.grdTran.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.ColumnChooserButton
        Me.grdTran.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.None
        Me.grdTran.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdTran.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed
        Appearance18.BackColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(133, Byte), Integer), CType(CType(207, Byte), Integer))
        Appearance18.ForeColor = System.Drawing.Color.White
        Me.grdTran.DisplayLayout.Override.SelectedCellAppearance = Appearance18
        Appearance19.BackColor = System.Drawing.Color.LightCyan
        Appearance19.ForeColor = System.Drawing.Color.Blue
        Me.grdTran.DisplayLayout.Override.SelectedRowAppearance = Appearance19
        Me.grdTran.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.grdTran.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.grdTran.DisplayLayout.Override.SpecialRowSeparator = Infragistics.Win.UltraWinGrid.SpecialRowSeparator.FilterRow
        Appearance20.BackColor = System.Drawing.SystemColors.ControlDark
        Me.grdTran.DisplayLayout.Override.SpecialRowSeparatorAppearance = Appearance20
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
        Appearance21.BackColor = System.Drawing.Color.White
        Appearance21.BorderColor = System.Drawing.Color.SteelBlue
        Appearance21.FontData.BoldAsString = "True"
        Appearance21.FontData.SizeInPoints = 11.0!
        Appearance21.TextVAlignAsString = "Middle"
        Me.lblTicketStatus.Appearance = Appearance21
        Me.lblTicketStatus.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid
        Me.lblTicketStatus.Location = New System.Drawing.Point(250, 39)
        Me.lblTicketStatus.Name = "lblTicketStatus"
        Me.lblTicketStatus.Padding = New System.Drawing.Size(4, 0)
        Me.lblTicketStatus.Size = New System.Drawing.Size(105, 28)
        Me.lblTicketStatus.TabIndex = 62
        '
        'lblRemainingAmount
        '
        Appearance22.BackColor = System.Drawing.Color.White
        Appearance22.BorderColor = System.Drawing.Color.SteelBlue
        Appearance22.FontData.BoldAsString = "True"
        Appearance22.FontData.SizeInPoints = 11.0!
        Appearance22.TextHAlignAsString = "Right"
        Appearance22.TextVAlignAsString = "Middle"
        Me.lblRemainingAmount.Appearance = Appearance22
        Me.lblRemainingAmount.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid
        Me.lblRemainingAmount.Location = New System.Drawing.Point(354, 39)
        Me.lblRemainingAmount.Name = "lblRemainingAmount"
        Me.lblRemainingAmount.Padding = New System.Drawing.Size(6, 0)
        Me.lblRemainingAmount.Size = New System.Drawing.Size(135, 28)
        Me.lblRemainingAmount.TabIndex = 60
        '
        'lblTicketStatusHdr
        '
        Appearance23.BackColor = System.Drawing.Color.LightSeaGreen
        Appearance23.BackColor2 = System.Drawing.Color.Teal
        Appearance23.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance23.BorderAlpha = Infragistics.Win.Alpha.Opaque
        Appearance23.BorderColor = System.Drawing.SystemColors.InactiveBorder
        Appearance23.FontData.BoldAsString = "True"
        Appearance23.ForeColor = System.Drawing.Color.White
        Appearance23.TextHAlignAsString = "Center"
        Appearance23.TextVAlignAsString = "Middle"
        Me.lblTicketStatusHdr.Appearance = Appearance23
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
        Appearance24.BackColor = System.Drawing.Color.LightSeaGreen
        Appearance24.BackColor2 = System.Drawing.Color.Teal
        Appearance24.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance24.BorderColor = System.Drawing.SystemColors.InactiveBorder
        Appearance24.FontData.BoldAsString = "True"
        Appearance24.ForeColor = System.Drawing.Color.White
        Appearance24.TextHAlignAsString = "Center"
        Appearance24.TextVAlignAsString = "Middle"
        Me.lblRemainingAmountHdr.Appearance = Appearance24
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
        Appearance25.BackColor = System.Drawing.Color.White
        Appearance25.BorderColor = System.Drawing.Color.SteelBlue
        Appearance25.FontData.BoldAsString = "True"
        Appearance25.FontData.SizeInPoints = 11.0!
        Appearance25.TextVAlignAsString = "Middle"
        Me.lblTicketBarcode.Appearance = Appearance25
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
        Appearance26.BackColor = System.Drawing.Color.LightSeaGreen
        Appearance26.BackColor2 = System.Drawing.Color.Teal
        Appearance26.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance26.BorderColor = System.Drawing.SystemColors.InactiveBorder
        Appearance26.FontData.BoldAsString = "True"
        Appearance26.ForeColor = System.Drawing.Color.White
        Appearance26.TextHAlignAsString = "Center"
        Appearance26.TextVAlignAsString = "Middle"
        Me.lblTicketBarcodeHdr.Appearance = Appearance26
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
        Appearance27.BackColor = System.Drawing.Color.Transparent
        Appearance27.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Appearance27.FontData.SizeInPoints = 10.0!
        Me.grdAction.DisplayLayout.Appearance = Appearance27
        UltraGridColumn95.Header.VisiblePosition = 0
        UltraGridColumn6.Header.VisiblePosition = 1
        UltraGridColumn89.Header.VisiblePosition = 2
        UltraGridColumn90.Header.VisiblePosition = 3
        UltraGridColumn7.Header.VisiblePosition = 5
        UltraGridColumn91.Header.VisiblePosition = 6
        UltraGridColumn91.Width = 70
        UltraGridColumn92.Header.VisiblePosition = 7
        Appearance28.TextHAlignAsString = "Left"
        UltraGridColumn93.CellAppearance = Appearance28
        UltraGridColumn93.Header.Caption = "Register ID"
        UltraGridColumn93.Header.VisiblePosition = 4
        UltraGridColumn93.Width = 84
        UltraGridColumn94.Header.VisiblePosition = 8
        UltraGridColumn8.Header.VisiblePosition = 9
        UltraGridBand5.Columns.AddRange(New Object() {UltraGridColumn95, UltraGridColumn6, UltraGridColumn89, UltraGridColumn90, UltraGridColumn7, UltraGridColumn91, UltraGridColumn92, UltraGridColumn93, UltraGridColumn94, UltraGridColumn8})
        Me.grdAction.DisplayLayout.BandsSerializer.Add(UltraGridBand5)
        Me.grdAction.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.grdAction.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance29.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance29.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance29.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance29.BorderColor = System.Drawing.SystemColors.Window
        Me.grdAction.DisplayLayout.GroupByBox.Appearance = Appearance29
        Appearance30.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdAction.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance30
        Me.grdAction.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grdAction.DisplayLayout.GroupByBox.Hidden = True
        Appearance31.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance31.BackColor2 = System.Drawing.SystemColors.Control
        Appearance31.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance31.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdAction.DisplayLayout.GroupByBox.PromptAppearance = Appearance31
        Me.grdAction.DisplayLayout.MaxColScrollRegions = 1
        Me.grdAction.DisplayLayout.MaxRowScrollRegions = 1
        Appearance32.BackColor = System.Drawing.SystemColors.Window
        Appearance32.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grdAction.DisplayLayout.Override.ActiveCellAppearance = Appearance32
        Appearance33.BackColor = System.Drawing.SystemColors.Highlight
        Appearance33.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdAction.DisplayLayout.Override.ActiveRowAppearance = Appearance33
        Me.grdAction.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
        Me.grdAction.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None
        Me.grdAction.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed
        Me.grdAction.DisplayLayout.Override.AllowRowLayoutCellSizing = Infragistics.Win.UltraWinGrid.RowLayoutSizing.None
        Me.grdAction.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.grdAction.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance34.BackColor = System.Drawing.SystemColors.Window
        Me.grdAction.DisplayLayout.Override.CardAreaAppearance = Appearance34
        Appearance35.BorderColor = System.Drawing.Color.Silver
        Appearance35.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.grdAction.DisplayLayout.Override.CellAppearance = Appearance35
        Me.grdAction.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.grdAction.DisplayLayout.Override.CellPadding = 0
        Me.grdAction.DisplayLayout.Override.ExpansionIndicator = Infragistics.Win.UltraWinGrid.ShowExpansionIndicator.Never
        Appearance36.BackColor = System.Drawing.SystemColors.Control
        Appearance36.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance36.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance36.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance36.BorderColor = System.Drawing.SystemColors.Window
        Me.grdAction.DisplayLayout.Override.GroupByRowAppearance = Appearance36
        Appearance37.BackColor = System.Drawing.Color.LightSeaGreen
        Appearance37.BackColor2 = System.Drawing.Color.Teal
        Appearance37.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance37.FontData.BoldAsString = "True"
        Appearance37.ForeColor = System.Drawing.Color.White
        Appearance37.TextHAlignAsString = "Center"
        Me.grdAction.DisplayLayout.Override.HeaderAppearance = Appearance37
        Me.grdAction.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdAction.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Me.grdAction.DisplayLayout.Override.MaxSelectedRows = 1
        Appearance38.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.grdAction.DisplayLayout.Override.RowAlternateAppearance = Appearance38
        Appearance39.BackColor = System.Drawing.Color.White
        Appearance39.BorderColor = System.Drawing.Color.Silver
        Me.grdAction.DisplayLayout.Override.RowAppearance = Appearance39
        Me.grdAction.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdAction.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed
        Me.grdAction.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Appearance40.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grdAction.DisplayLayout.Override.TemplateAddRowAppearance = Appearance40
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
        Appearance41.BackColor = System.Drawing.Color.BlanchedAlmond
        Appearance41.BackGradientStyle = Infragistics.Win.GradientStyle.None
        Me.UltraTabControl1.ActiveTabAppearance = Appearance41
        Appearance42.BackColor = System.Drawing.Color.BlanchedAlmond
        Appearance42.BackColor2 = System.Drawing.Color.BurlyWood
        Appearance42.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance42.FontData.BoldAsString = "True"
        Appearance42.ForeColor = System.Drawing.Color.MidnightBlue
        Me.UltraTabControl1.Appearance = Appearance42
        Appearance43.BackColor = System.Drawing.Color.BlanchedAlmond
        Appearance43.BackGradientStyle = Infragistics.Win.GradientStyle.None
        Me.UltraTabControl1.ClientAreaAppearance = Appearance43
        Me.UltraTabControl1.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl1)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl2)
        Me.UltraTabControl1.InterTabSpacing = New Infragistics.Win.DefaultableInteger(-5)
        Me.UltraTabControl1.Location = New System.Drawing.Point(13, 16)
        Me.UltraTabControl1.Name = "UltraTabControl1"
        Me.UltraTabControl1.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.UltraTabControl1.Size = New System.Drawing.Size(514, 500)
        Me.UltraTabControl1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Excel
        Appearance44.BackColor = System.Drawing.Color.Transparent
        Me.UltraTabControl1.TabHeaderAreaAppearance = Appearance44
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
        'btnPrint
        '
        Appearance45.Image = Global.StadisV4RProV9Plugin.My.Resources.Resources.printer24
        Appearance45.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance45.ImageVAlign = Infragistics.Win.VAlign.Top
        Appearance45.TextVAlignAsString = "Bottom"
        Me.btnPrint.Appearance = Appearance45
        Me.btnPrint.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnPrint.Location = New System.Drawing.Point(285, 532)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(100, 60)
        Me.btnPrint.TabIndex = 0
        Me.btnPrint.Text = "Print Single"
        '
        'btnPrintAll
        '
        Appearance46.Image = Global.StadisV4RProV9Plugin.My.Resources.Resources.printer_add24
        Appearance46.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance46.ImageVAlign = Infragistics.Win.VAlign.Top
        Appearance46.TextVAlignAsString = "Bottom"
        Me.btnPrintAll.Appearance = Appearance46
        Me.btnPrintAll.Enabled = False
        Me.btnPrintAll.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintAll.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnPrintAll.Location = New System.Drawing.Point(401, 532)
        Me.btnPrintAll.Name = "btnPrintAll"
        Me.btnPrintAll.Size = New System.Drawing.Size(100, 60)
        Me.btnPrintAll.TabIndex = 1
        Me.btnPrintAll.Text = "Print All"
        '
        'btnFinished
        '
        Appearance47.Image = Global.StadisV4RProV9Plugin.My.Resources.Resources.exit24
        Appearance47.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance47.ImageVAlign = Infragistics.Win.VAlign.Top
        Appearance47.TextVAlignAsString = "Bottom"
        Me.btnFinished.Appearance = Appearance47
        Me.btnFinished.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFinished.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnFinished.Location = New System.Drawing.Point(517, 532)
        Me.btnFinished.Name = "btnFinished"
        Me.btnFinished.Size = New System.Drawing.Size(100, 60)
        Me.btnFinished.TabIndex = 2
        Me.btnFinished.Text = "Finished"
        '
        'FrmHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(902, 610)
        Me.Controls.Add(Me.btnPrintAll)
        Me.Controls.Add(Me.btnFinished)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.lblPrint)
        Me.Controls.Add(Me.UltraTabControl1)
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
    Friend WithEvents DSTran As DSTran
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
    Friend WithEvents lstReceipt As System.Windows.Forms.ListBox
    Friend WithEvents btnPrint As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnPrintAll As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnFinished As Infragistics.Win.Misc.UltraButton
End Class
