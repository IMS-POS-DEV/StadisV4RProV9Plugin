Imports CommonV4
'Imports CommonV4.CommonRoutines
Imports CommonV4.WebReference
Imports RetailPro.CustomPluginClasses
Imports RetailPro.Plugins
Imports System.Drawing
Imports System.Text
Imports System.Text.RegularExpressions
Imports Infragistics.Win
'----------------------------------------------------------------------------------------------
'   Class: FrmStadisCharge
'    Type: Windows Form
' Purpose: Collects Stadis tender information.  Invoked from TenderDialogue.
'----------------------------------------------------------------------------------------------
Public Class FrmStadisCharge

#Region " Private Data "

    Private mInvoiceHandle As Integer = 0
    Private mItemHandle As Integer = -99
    Private mTenderHandle As Integer = -99

    Private mAmountDue As Decimal = 0D
    Private mAvailAmount As Decimal = 0D
    Private mAcctBalance As Decimal = 0D

    Private mReturnCode As Integer = 0
    Private mReturnMessage As String = ""

#End Region  'Private Data

#Region " Properties "

    Private mAdapter As RetailPro.Plugins.IPluginAdapter
    Friend Property Adapter() As RetailPro.Plugins.IPluginAdapter
        Get
            Return mAdapter
        End Get
        Set(ByVal value As RetailPro.Plugins.IPluginAdapter)
            mAdapter = value
        End Set
    End Property

    Private mParentDialog As TenderDialogue = Nothing
    Friend Property ParentDialog() As TenderDialogue
        Get
            Return mParentDialog
        End Get
        Set(ByVal value As TenderDialogue)
            mParentDialog = value
        End Set
    End Property

#End Region  'Properties

#Region " Form Load and Initialization "

    '----------------------------------------------------------------------------------------------
    ' Called when form is loaded
    '----------------------------------------------------------------------------------------------
    Private Sub FrmStadisCharge_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetUpRetailProConnections()
        SetLabelsToCustomerPreferences()
        InitializeFormFields()
    End Sub  'FrmStadisCharge_Load

    '----------------------------------------------------------------------------------------------
    ' Initialize pointers for RPro API access
    '----------------------------------------------------------------------------------------------
    Private Sub SetUpRetailProConnections()
        mInvoiceHandle = 0
        mItemHandle = mAdapter.GetReferenceBOForAttribute(mInvoiceHandle, "Items")
        mTenderHandle = mAdapter.GetReferenceBOForAttribute(mInvoiceHandle, "Tenders")
    End Sub  'SetUpRetailProConnections

    '----------------------------------------------------------------------------------------------
    ' Get and set customer captions loaded from InstallationSetting table during initialization
    '----------------------------------------------------------------------------------------------
    Private Sub SetLabelsToCustomerPreferences()
        Me.Text = gTenderDialogFormText
        lblHeader.Text = gTenderDialogHeader
        lblTenderID.Text = gTenderDialogTenderIDLabel
    End Sub  'SetLabelsToCustomerPreference

    '----------------------------------------------------------------------------------------------
    ' Set on-screen fields to initial values
    '----------------------------------------------------------------------------------------------
    Private Sub InitializeFormFields()
        mAdapter = ParentDialog.Adapter
        mAmountDue = ParentDialog.Amount
        txtAmountDue.Value = mAmountDue
        txtTenderID.Text = ""
        txtAvailAmount.Value = 0
        txtTenderAmount.Value = 0
        txtAcctBalance.Value = 0
        txtRemAmountDue.Value = mAmountDue
        txtRemAmountDue.Appearance.ForeColor = System.Drawing.Color.Firebrick
        txtMessage.Text = ""
    End Sub  'InitializeFields

    '----------------------------------------------------------------------------------------------
    ' Load customer's version of form logo
    '----------------------------------------------------------------------------------------------
    Private Sub FrmStadisCharge_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        If Trim(gFormLogoImage) <> "stadislogo.png" Then
            pbLogo.Image = New Bitmap(gFormLogoImage)
        End If
    End Sub  'FrmStadisCharge_Paint

#End Region  'Form Load and Initialization

#Region " Events "

    '----------------------------------------------------------------------------------------------
    ' Check ticket balance, update on-screen fields
    '----------------------------------------------------------------------------------------------
    Private Sub txtTenderID_Leave(sender As Object, e As EventArgs) Handles txtTenderID.Leave

        'Check for blank input
        Trim(txtTenderID.Text)
        If txtTenderID.Text = "" Then
            Exit Sub
        End If

        'Strip out extra characters from scanner
        Dim extractedScan As String = CommonRoutines.ExtractScan(txtTenderID.Text)
        If extractedScan <> txtTenderID.Text Then
            txtTenderID.Text = extractedScan
        End If

        'Validate TenderID against our regex pattern for length / content
        If CommonRoutines.ValidateScan(extractedScan) = False Then
            MsgBox("Invalid scan content or length." & vbCrLf & "Scan: " & extractedScan, MsgBoxStyle.Exclamation, "STADIS Tender")
            txtTenderID.Text = ""
            Exit Sub
        End If

        'Check for duplicate TenderIDs
        CommonRoutines.BOOpen(mAdapter, mTenderHandle)
        Dim tenderCount As Integer = CommonRoutines.BOGetIntAttributeValueByName(mAdapter, mTenderHandle, "TENDER_COUNT")
        If tenderCount > 0 Then
            CommonRoutines.BOFirst(mAdapter, mTenderHandle, "TD - Check for dup TenderID")
            While Not mAdapter.EOF(mTenderHandle)
                Dim rproTenderType As Integer = CommonRoutines.BOGetIntAttributeValueByName(mAdapter, mTenderHandle, "TENDER_TYPE")
                If rproTenderType = gTenderDialogTenderType Then
                    Dim remark() As String = CommonRoutines.BOGetStrAttributeValueByName(mAdapter, mTenderHandle, "MANUAL_REMARK").Split("#"c)
                    If remark.Length > 0 Then
                        If txtTenderID.Text = remark(1) Then
                            MsgBox("Card/Ticket has already been entered.", MsgBoxStyle.Exclamation, "STADIS Tender")
                            txtTenderID.Text = ""
                            Exit Sub
                        End If
                    End If
                End If
                mAdapter.BONext(mTenderHandle)
            End While
        End If

        'Check ticket status
        Dim sr As New StadisRequest
        With sr
            .SiteID = gSiteID
            .TenderTypeID = 1
            .TenderID = txtTenderID.Text
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
            MsgBox("Unable to validate card...", MsgBoxStyle.Exclamation, "GiftCard")
            txtTenderID.Text = ""
            Exit Sub
        End If
        mAvailAmount = ts.SVATotalAvailable
        mAcctBalance = ts.SVA1Balance
        txtTenderAmount.Value = mAmountDue
        CalcRemAmountDue()
    End Sub  'txtTenderID_Leave

    '----------------------------------------------------------------------------------------------
    ' If amount to be tendered is changed, recalc and update other fields
    '----------------------------------------------------------------------------------------------
    Private Sub txtTenderAmount_ValueChanged(sender As Object, e As EventArgs) Handles txtTenderAmount.ValueChanged
        CalcRemAmountDue()
    End Sub  'txtTenderAmount_ValueChanged

    '----------------------------------------------------------------------------------------------
    ' Calculate and update remaining amount due
    '----------------------------------------------------------------------------------------------
    Private Sub CalcRemAmountDue()
        txtAvailAmount.Value = mAvailAmount
        txtAcctBalance.Value = mAcctBalance
        If mAvailAmount < txtTenderAmount.Value Then
            txtTenderAmount.Value = mAvailAmount
        End If
        txtRemAmountDue.Value = mAmountDue - txtTenderAmount.Value
        If txtRemAmountDue.Value = 0 Then
            txtRemAmountDue.Appearance.ForeColor = System.Drawing.Color.Black
        Else
            txtRemAmountDue.Appearance.ForeColor = System.Drawing.Color.Firebrick
        End If
    End Sub  'CalcRemAmountDue

#End Region  'Events

#Region " Methods "

    '----------------------------------------------------------------------------------------------
    ' Pause
    '----------------------------------------------------------------------------------------------
    Private Sub Wait(ByVal seconds As Integer)
        For i As Integer = 0 To seconds * 100
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
        Next
    End Sub  'Wait

    Private Function DoSVAccountCharge() As Boolean
        Try
            'Build StadisRequest and do charge
            Dim sr As New StadisRequest
            With sr
                .SiteID = gSiteID
                .TenderTypeID = 1
                .TenderID = Trim(txtTenderID.Text)
                .Amount = txtTenderAmount.Value
                .ReferenceNumber = ""
                '.CustomerID =  
                .VendorID = gVendorID
                .LocationID = gLocationID
                .RegisterID = CommonRoutines.BOGetStrAttributeValueByName(mAdapter, mInvoiceHandle, "Invoice Workstion")
                .ReceiptID = CommonRoutines.BOGetStrAttributeValueByName(mAdapter, mInvoiceHandle, "Invoice Number")
                .VendorCashier = CommonRoutines.BOGetStrAttributeValueByName(mAdapter, mInvoiceHandle, "Cashier")
                gRegisterID = .RegisterID
                gVendorCashier = .VendorCashier
            End With
            Dim stt As New StadisTranTender
            With stt
                .IsStadisTender = True
                .StadisAuthorizationID = " "
                .TenderTypeID = 1
                .TenderID = Trim(txtTenderID.Text)
                .Amount = txtTenderAmount.Value
            End With
            Dim sys As StadisReply() = CommonRoutines.StadisAPI.SVAccountCharge(sr, CommonRoutines.LoadHeader(mAdapter, "Receipt", mInvoiceHandle), CommonRoutines.LoadItems(mAdapter, "Receipt", mInvoiceHandle, mItemHandle), CommonRoutines.LoadTendersForCharge(mAdapter, "Receipt", mTenderHandle, stt))
            mReturnCode = sys(0).ReturnCode
            mReturnMessage = sys(0).ReturnMessage
            If mReturnCode < 0 Then
                MsgBox("Stadis Charge failed." & vbCrLf & mReturnMessage, MsgBoxStyle.Exclamation, "Stadis Charge")
                txtTenderID.Text = ""
                Return False
            End If
            For Each sy As StadisReply In sys
                If sy.TenderTypeID = 1 Then   'Ticket
                    Select Case sy.ReturnCode
                        Case 0, 1, -2   'Charge went through
                            'Update our own list of Stadis tenders, so we can add Promos later
                            Dim flag As String = ""
                            If CommonRoutines.IsAGiftCard(sy.EventID) Then
                                flag = "@GC"
                            Else
                                flag = "@TK"
                            End If
                            Dim sc As New CommonRoutines.StadisCharge(sy.TenderTypeID, flag, sy.TenderID, sy.ChargedAmount, sy.StadisAuthorizationID)
                            CommonRoutines.stadisChargeList.Add(sc)
                            'Update RPro
                            With ParentDialog
                                .Amount = sy.ChargedAmount
                                .Remark = flag & "#" & sy.TenderID & "#" & sy.StadisAuthorizationID
                            End With
                        Case -1, -3, -99   'Charge failed
                            txtMessage.Appearance.ForeColor = Color.Firebrick
                            txtMessage.Text = "Charge Failed."
                            mAvailAmount = 0D
                            mAcctBalance = sy.FromSVAccountBalance
                            CalcRemAmountDue()
                            If sy.ReturnCode = -1 Then
                                MsgBox("Ticket/Card is Inactive!" & vbCrLf & "Ticket/Card: " & txtTenderID.Text, MsgBoxStyle.Exclamation, "Ticket Tender")
                            ElseIf sy.ReturnCode = -3 Then
                                MsgBox("Ticket not found!" & vbCrLf & "Ticket/Card: " & txtTenderID.Text, MsgBoxStyle.Exclamation, "Ticket Tender")
                            Else
                                MsgBox("Charge failed for unknown reasons!" & vbCrLf & "Try again later.", MsgBoxStyle.Exclamation, "Ticket Tender")
                            End If
                            Return False
                        Case Else
                            MsgBox("Charge failed for unknown reasons!" & vbCrLf & "Try again later.", MsgBoxStyle.Exclamation, "Ticket Tender")
                            Return False
                    End Select
                ElseIf sy.TenderTypeID = 11 Then   'Promo
                    Dim sc As New CommonRoutines.StadisCharge(sy.TenderTypeID, "@PR", sy.TenderID, sy.ChargedAmount, sy.StadisAuthorizationID)
                    CommonRoutines.stadisChargeList.Add(sc)
                End If
            Next
            txtMessage.Appearance.ForeColor = Color.Teal
            txtMessage.Text = "Charge Successful."
            Return True
        Catch ex As Exception
            MsgBox(ex.Message.ToString(), , "SVAccountCharge")
            Return False
        End Try
    End Function  'DoSVAccountCharge

#End Region  'Methods

#Region " Buttons "

    '----------------------------------------------------------------------------------------------
    ' Display on-screen keyboard
    '----------------------------------------------------------------------------------------------
    Private Sub btnKeyboard_Click(sender As Object, e As EventArgs) Handles btnKeyboard.Click
        Dim windir As String = Environment.GetEnvironmentVariable("windir")
        Dim p As New Process()
        With p.StartInfo
            .FileName = windir & Convert.ToString("\System32\cmd.exe")
            .Arguments = (Convert.ToString("/C ") & windir) + "\System32\osk.exe"
            .CreateNoWindow = True
            .UseShellExecute = False
        End With
        p.Start()
        p.Dispose()
    End Sub  'btnKeyboard_Click

    '----------------------------------------------------------------------------------------------
    ' Process SVAccountCharge.  If successful, pause a sec to diaplay message, then exit
    '----------------------------------------------------------------------------------------------
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim chargeSucceeded As Boolean = DoSVAccountCharge()
        If chargeSucceeded Then
            Wait(1)
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub  'btnOK_Click

    '----------------------------------------------------------------------------------------------
    ' Exit without doing anything
    '----------------------------------------------------------------------------------------------
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub  'btnCancel_Click

#End Region  'Buttons

End Class  'FrmStadisCharge