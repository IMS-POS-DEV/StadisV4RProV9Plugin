Imports StadisIntegratePlugin.WebReference
Imports System.Drawing
Imports System.Text
Imports System.Text.RegularExpressions
Imports Infragistics.Win
'----------------------------------------------------------------------------------------------
'   Class: FrmStadisCharge
'    Type: Windows Form
' Purpose: Collects Stadis tender information.  Invoked from TenderDialogue.
'
' Item Note1 Before: STADIS\GiftCardID\IorA\CustomerID\Amount
' Item Note1 After: STADIS\GiftCardID\IorA\CustomerID\Amount\TranKey
'
' MANUAL_REMARK Before: StadisOpCode#CardID#AuthID
' MANUAL_REMARK After: StadisOpCode#TranKey
'----------------------------------------------------------------------------------------------
Public Class FrmStadisCharge

#Region " Private Data "

    Private mInvoiceHandle As Integer = 0
    Private mItemHandle As Integer = -99
    Private mTenderHandle As Integer = -99

    Private mAmountDue As Decimal = 0D
    Private mAvailAmount As Decimal = 0D
    Private mAcctBalance As Decimal = 0D
    'Private mTenderAmount As Decimal = 0D
    Private mStadisCharge As Decimal = 0D
    Private mPromoCharge As Decimal = 0D

    Private mIsDuplicate As Boolean = False

    Private mReturnCode As Integer = -99
    Private mReturnMessage As String = ""

#End Region  'Private Data

#Region " Properties "

    Private mAdapter As Plugins.IPluginAdapter
    Friend Property Adapter() As Plugins.IPluginAdapter
        Get
            Return mAdapter
        End Get
        Set(ByVal value As Plugins.IPluginAdapter)
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
        Common.BORefreshRecord(mAdapter, 0)
        Common.BOOpen(mAdapter, mTenderHandle)

        'If mAdapter.BOIsAttributeInList(mTenderHandle, "EFTDATA5") = False Then
        '    Dim result As Integer = mAdapter.BOIncludeAttrIntoList(mTenderHandle, "EFTDATA5", True, False)
        'End If
        'If mAdapter.BOIsAttributeInInstance(mTenderHandle, "EFTDATA5") = False Then
        '    Dim result As Integer = mAdapter.BOIncludeAttrIntoInstance(mTenderHandle, "EFTDATA5", True, False)
        'End If

        'If mAdapter.BOIsAttributeInList(mTenderHandle, "EFTDATA6") = False Then
        '    Dim result As Integer = mAdapter.BOIncludeAttrIntoList(mTenderHandle, "EFTDATA6", True, False)
        'End If
        'If mAdapter.BOIsAttributeInInstance(mTenderHandle, "EFTDATA6") = False Then
        '    Dim result As Integer = mAdapter.BOIncludeAttrIntoInstance(mTenderHandle, "EFTDATA6", True, False)
        'End If

        'If mAdapter.BOIsAttributeInList(mTenderHandle, "EFTDATA7") = False Then
        '    Dim result As Integer = mAdapter.BOIncludeAttrIntoList(mTenderHandle, "EFTDATA7", True, False)
        'End If
        'If mAdapter.BOIsAttributeInInstance(mTenderHandle, "EFTDATA7") = False Then
        '    Dim result As Integer = mAdapter.BOIncludeAttrIntoInstance(mTenderHandle, "EFTDATA7", True, False)
        'End If

        If mAdapter.BOIsAttributeInList(mTenderHandle, "EFTDATA8") = False Then
            Dim result As Integer = mAdapter.BOIncludeAttrIntoList(mTenderHandle, "EFTDATA8", True, False)
        End If
        If mAdapter.BOIsAttributeInInstance(mTenderHandle, "EFTDATA8") = False Then
            Dim result As Integer = mAdapter.BOIncludeAttrIntoInstance(mTenderHandle, "EFTDATA8", True, False)
        End If

        If mAdapter.BOIsAttributeInList(mTenderHandle, "EFTDATA9") = False Then
            Dim result As Integer = mAdapter.BOIncludeAttrIntoList(mTenderHandle, "EFTDATA9", True, False)
        End If
        If mAdapter.BOIsAttributeInInstance(mTenderHandle, "EFTDATA9") = False Then
            Dim result As Integer = mAdapter.BOIncludeAttrIntoInstance(mTenderHandle, "EFTDATA9", True, False)
        End If
        mAdapter.BOUpdateListCollections(mTenderHandle)
        mAdapter.BOUpdateInstanceCollections(mTenderHandle)
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
        If gAllowRedeemAmountChange = True Then
            txtTenderAmount.ReadOnly = False
            txtTenderAmount.Appearance.BackColor = Color.White
        Else
            txtTenderAmount.ReadOnly = True
            txtTenderAmount.Appearance.BackColor = Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(203, Byte), Integer))
        End If
        mAdapter = ParentDialog.Adapter
        mAmountDue = ParentDialog.Amount
        txtAmountDue.Value = mAmountDue
        txtTenderID.Text = ""
        txtAvailAmount.Value = 0
        txtTenderAmount.Value = mAmountDue
        txtStadisCharge.Value = 0
        txtPromoCharge.Value = 0
        txtAcctBalance.Value = 0
        txtRemAmountDue.Value = mAmountDue
        txtRemAmountDue.Appearance.ForeColor = System.Drawing.Color.Firebrick
        txtMessage.Text = ""
        mAvailAmount = 0D
        mAcctBalance = 0D
        'mTenderAmount = mAmountDue
        mIsDuplicate = False
        btnOK.Text = "Process"
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
    ' Make Enter show up in KeyDown event
    '----------------------------------------------------------------------------------------------
    Private Sub txtTender_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtTenderID.PreviewKeyDown, txtTenderAmount.PreviewKeyDown
        If e.KeyCode = Keys.Enter Then
            e.IsInputKey = True
        End If
    End Sub  'txtTender_PreviewKeyDown

    '----------------------------------------------------------------------------------------------
    ' Make Enter act like Tab
    '----------------------------------------------------------------------------------------------
    Private Sub txtTenderID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTenderID.KeyDown
        If e.KeyCode = Keys.Enter Then
            If gAllowRedeemAmountChange = True Then
                txtTenderAmount.Focus()
                txtTenderAmount.PerformAction(UltraWinMaskedEdit.MaskedEditAction.SelectSection, False, False)
                e.Handled = True
            Else
                btnOK.Focus()
                OKProcessing()
                e.Handled = True
            End If
        End If
    End Sub  'txtTenderID_KeyDown

    Private Sub txtTenderAmount_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTenderAmount.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnOK.Focus()
            OKProcessing()
            e.Handled = True
        End If
    End Sub  'txtTenderAmount_KeyDown

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
        Dim extractedScan As String = Common.ExtractScan(txtTenderID.Text)
        If extractedScan <> txtTenderID.Text Then
            txtTenderID.Text = extractedScan
        End If

        'Validate TenderID against our regex pattern for length / content
        If Common.ValidateScan(extractedScan) = False Then
            MsgBox("Invalid scan content or length." & vbCrLf & "Scan: " & extractedScan, MsgBoxStyle.Exclamation, "STADIS Tender")
            txtTenderID.Text = ""
            Exit Sub
        End If

        'Check for duplicate TenderIDs
        Common.BOOpen(mAdapter, mTenderHandle)
        Dim tenderCount As Integer = Common.BOGetIntAttributeValueByName(mAdapter, mTenderHandle, "TENDER_COUNT")
        If tenderCount > 0 Then
            Common.BOFirst(mAdapter, mTenderHandle, "TD - Check for dup TenderID")
            While Not mAdapter.EOF(mTenderHandle)
                Dim rproTenderType As Integer = Common.BOGetIntAttributeValueByName(mAdapter, mTenderHandle, "TENDER_TYPE")
                If rproTenderType = gTenderDialogTenderType Then
                    Dim remark() As String = Common.BOGetStrAttributeValueByName(mAdapter, mTenderHandle, "MANUAL_REMARK").Split("#"c)
                    If remark.Length > 0 Then
                        If txtTenderID.Text = remark(1) Then
                            MsgBox("Card/Ticket has already been entered.", MsgBoxStyle.Exclamation, "STADIS Tender")
                            txtTenderID.Text = ""
                            mIsDuplicate = True
                            Exit Sub
                        End If
                    End If
                End If
                mAdapter.BONext(mTenderHandle)
            End While
        End If

        txtMessage.Text = ""
        'Check ticket status
        If mIsDuplicate = False Then
            Dim sr As New StadisIntegratePlugin.WebReference.StadisRequest
            With sr
                .SiteID = gSiteID
                .TenderTypeID = 1
                .TenderID = Trim(txtTenderID.Text)
                .Amount = 0
                .ReferenceNumber = ""
                .CustomerID = gStadisUserID
                .VendorID = gVendorID
                .LocationID = gLocationID
                .RegisterID = Common.BOGetStrAttributeValueByName(mAdapter, 0, "Invoice Workstion")
                .ReceiptID = Common.BOGetStrAttributeValueByName(mAdapter, 0, "Invoice Number")
                .VendorCashier = Common.BOGetStrAttributeValueByName(mAdapter, 0, "Cashier")
            End With
            Dim ts As StadisIntegratePlugin.WebReference.TicketStatus = Common.StadisAPI.GetTicketStatus(sr)
            If ts.ReturnCode < 0 Then
                MsgBox("Unable to validate card...", MsgBoxStyle.Exclamation, "GiftCard")
                txtTenderID.Text = ""
                Exit Sub
            End If
            mAvailAmount = ts.SVATotalAvailable
            mAcctBalance = ts.SVA1Balance - mAvailAmount
            txtTenderAmount.Value = mAmountDue
            CalcRemAmountDue()
            If ts.SVATotalAvailable = 0D Then
                txtMessage.Appearance.ForeColor = Drawing.Color.Firebrick
                txtMessage.Text = "Zero balance on card/ticket."
            End If
        End If
    End Sub  'txtTenderID_Leave

    '----------------------------------------------------------------------------------------------
    ' If amount to be tendered is changed, recalc and update other fields
    '----------------------------------------------------------------------------------------------
    Private Sub txtTenderAmount_ValueChanged(sender As Object, e As EventArgs) Handles txtTenderAmount.ValueChanged
        CalcRemAmountDue()
        txtMessage.Text = ""
    End Sub  'txtTenderAmount_ValueChanged

    '----------------------------------------------------------------------------------------------
    ' Calculate and update remaining amount due
    '----------------------------------------------------------------------------------------------
    Private Sub CalcRemAmountDue()
        txtAvailAmount.Value = mAvailAmount
        txtAcctBalance.Value = mAcctBalance
        'If mAvailAmount < mAmountDue Then
        '    txtTenderAmount.Value = mAvailAmount
        '    mTenderAmount = mAvailAmount
        'End If
        'txtRemAmountDue.Value = mAmountDue - mAvailAmount
        If txtRemAmountDue.Value = 0 Then
            txtRemAmountDue.Appearance.ForeColor = System.Drawing.Color.Black
        Else
            txtRemAmountDue.Appearance.ForeColor = System.Drawing.Color.Firebrick
        End If
    End Sub  'CalcRemAmountDue

#End Region  'Events

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
    ' Clear fields and allow reentry of identical data
    '----------------------------------------------------------------------------------------------
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtTenderID.Text = ""
        txtAvailAmount.Value = 0
        txtTenderAmount.Value = 0
        txtStadisCharge.Value = 0
        txtPromoCharge.Value = 0
        txtAcctBalance.Value = 0
        txtMessage.Text = ""
        gLastTenderID = ""
        gLastAmount = 0D
        mIsDuplicate = False
        btnOK.Text = "Process"
    End Sub  'btnClear_Click

    '----------------------------------------------------------------------------------------------
    ' Process SVAccountCharge.  If successful, pause a sec to diaplay message, then exit
    '----------------------------------------------------------------------------------------------
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        OKProcessing()
    End Sub  'btnOK_Click

    Private Sub OKProcessing()
        If btnOK.Text = "Exit" Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
        If mIsDuplicate = False Then
            Dim chargeSucceeded As Boolean = DoSVAccountCharge()
            If chargeSucceeded Then
                btnOK.Text = "Exit"
                'Wait(1)
                'Me.DialogResult = Windows.Forms.DialogResult.OK
                'Me.Close()
            End If
        Else
            MsgBox("Card/Ticket has already been entered.", MsgBoxStyle.Exclamation, "STADIS Tender")
        End If
    End Sub  'OKProcessing

    '----------------------------------------------------------------------------------------------
    ' Exit without doing anything
    '----------------------------------------------------------------------------------------------
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub  'btnCancel_Click

#End Region  'Buttons

#Region " Private Methods "

    ''----------------------------------------------------------------------------------------------
    '' Pause
    ''----------------------------------------------------------------------------------------------
    'Private Sub Wait(ByVal seconds As Integer)
    '    For i As Integer = 0 To seconds * 100
    '        System.Threading.Thread.Sleep(10)
    '        Application.DoEvents()
    '    Next
    'End Sub  'Wait

    Private Function DoSVAccountCharge() As Boolean
        Try
            'Build StadisRequest and do charge
            Dim sr As New StadisIntegratePlugin.WebReference.StadisRequest
            With sr
                .SiteID = gSiteID
                .TenderTypeID = 1
                .TenderID = Trim(txtTenderID.Text)
                .Amount = txtTenderAmount.Value
                .ReferenceNumber = ""
                .CustomerID = gStadisUserID
                .VendorID = gVendorID
                .LocationID = gLocationID
                .RegisterID = Common.BOGetStrAttributeValueByName(mAdapter, mInvoiceHandle, "Invoice Workstion")
                .ReceiptID = Common.BOGetStrAttributeValueByName(mAdapter, mInvoiceHandle, "Invoice Number")
                .VendorCashier = Common.BOGetStrAttributeValueByName(mAdapter, mInvoiceHandle, "Cashier")
                gRegisterID = .RegisterID
                gVendorCashier = .VendorCashier
                If gReturnItemizedPromotions = True Then
                    .StadisAuthorizationID = "*Items"
                End If
            End With
            Dim invcSID = Common.BOGetStrAttributeValueByName(mAdapter, mInvoiceHandle, "Invoice SID")
            'Check if already processed
            If invcSID = gLastInvcSID AndAlso sr.TenderID = gLastTenderID AndAlso sr.Amount = gLastAmount Then
                Return False
            End If
            Dim stt As New StadisIntegratePlugin.WebReference.StadisTranTender
            With stt
                .IsStadisTender = True
                .StadisAuthorizationID = " "
                .TenderTypeID = 1
                .TenderID = Trim(txtTenderID.Text)
                .Amount = txtTenderAmount.Value
            End With
            Dim sys As StadisIntegratePlugin.WebReference.StadisReply() = Nothing
            Try
                If gUseShortCharge = True Then
                    'MsgBox("Stadis short charge")
                    sys = Common.StadisAPI.SVAcctChg(sr)
                Else
                    'MsgBox("Stadis long charge")
                    sys = Common.StadisAPI.SVAccountCharge(sr, Common.LoadHeader(mAdapter, "Receipt", mInvoiceHandle), Common.LoadItems(mAdapter, "Receipt", mInvoiceHandle, mItemHandle), Common.LoadTendersForCharge(mAdapter, "Receipt", mTenderHandle, stt))
                End If
                mReturnCode = sys(0).ReturnCode
                mReturnMessage = sys(0).ReturnMessage
            Catch ex As Exception
                MsgBox("Stadis Charge failed." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "SVAccountCharge Exception")
                txtTenderID.Text = ""
                With ParentDialog
                    .Amount = 0D
                    .Remark = "Error"
                    .DATA8 = " "
                End With
                Return False
            End Try
            If mReturnCode < 0 Then
                MsgBox("Stadis Charge failed." & vbCrLf & mReturnMessage, MsgBoxStyle.Critical, "SVAccountCharge")
                txtTenderID.Text = ""
                With ParentDialog
                    .Amount = 0D
                    .Remark = "Error"
                    .DATA8 = " "
                End With
                Return False
            End If
            gLastInvcSID = invcSID
            gLastTenderID = sr.TenderID
            gLastAmount = sr.Amount
            For Each sy As StadisIntegratePlugin.WebReference.StadisReply In sys
                If sy.TenderTypeID = 11 Then   'Promo
                    Select Case sy.ReturnCode
                        Case 0, 1, -2   'Charge went through
                            Try
                                Common.BORefreshRecord(mAdapter, 0)
                                Common.BOOpen(mAdapter, mTenderHandle)
                                Common.BOInsert(mAdapter, mTenderHandle)
                                Common.BOSetAttributeValueByName(mAdapter, mTenderHandle, "TENDER_TYPE", gTenderDialogTenderType)
                                Common.BOSetAttributeValueByName(mAdapter, mTenderHandle, "AMT", sy.ChargedAmount)
                                Common.BOSetAttributeValueByName(mAdapter, mTenderHandle, "MANUAL_REMARK", "@PR" & "#" & sy.TenderID & "#" & sy.StadisAuthorizationID)
                                Common.BOSetAttributeValueByName(mAdapter, mTenderHandle, "PMT_REMARK", "Promo")
                                Dim len As Integer = sy.TenderID.Length
                                Dim lastfour As String = sy.TenderID.Substring(len - 4, 4)
                                Common.BOSetAttributeValueByName(mAdapter, mTenderHandle, "EFTDATA8", lastfour)
                                If gTenderDialogTenderType = Plugins.TenderTypes.ttGiftCard Then
                                    Common.BOSetAttributeValueByName(mAdapter, mTenderHandle, "CRD_EXP_MONTH", 1)
                                    Common.BOSetAttributeValueByName(mAdapter, mTenderHandle, "CRD_EXP_YEAR", 1)
                                    Common.BOSetAttributeValueByName(mAdapter, mTenderHandle, "CRD_TYPE", 1)
                                    Common.BOSetAttributeValueByName(mAdapter, mTenderHandle, "CRD_PRESENT", 1)
                                End If
                                Common.BOPost(mAdapter, mTenderHandle)
                                txtPromoCharge.Value += sy.ChargedAmount
                                'Common.BOSetAttributeValueByName(mAdapter, mTenderHandle, "EFTDATA6", sy.ChargedAmount)
                                'Common.BOSetAttributeValueByName(mAdapter, mTenderHandle, "EFTDATA7", sy.Comment)
                            Catch ex As Exception
                                MessageBox.Show("Error while adding promo tender." & vbCrLf & ex.Message, "STADIS")
                                Exit Function
                            End Try
                        Case -1, -3, -99   'Charge failed
                            txtMessage.Appearance.ForeColor = Drawing.Color.Firebrick
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
                End If
            Next
            For Each sy As StadisIntegratePlugin.WebReference.StadisReply In sys
                If sy.TenderTypeID = 1 Then   'Ticket
                    Select Case sy.ReturnCode
                        Case 0, 1, -2   'Charge went through
                            Dim flag As String = ""
                            If Common.IsAGiftCard(sy.EventID) Then
                                flag = "@GC"
                            Else
                                flag = "@TK"
                            End If
                            Dim len As Integer = sy.TenderID.Length
                            Dim lastfour As String = sy.TenderID.Substring(len - 4, 4)
                            With ParentDialog
                                .Amount = sy.ChargedAmount
                                .Remark = flag & "#" & sy.TenderID & "#" & sy.StadisAuthorizationID
                                .DATA8 = lastfour
                            End With
                            txtStadisCharge.Value = sy.ChargedAmount
                            'Common.BORefreshRecord(mAdapter, 0)
                            'Common.BOOpen(mAdapter, mTenderHandle)
                            'Common.BOSetAttributeValueByName(mAdapter, mTenderHandle, "EFTDATA5", sy.ChargedAmount)
                            'Common.BOPost(mAdapter, mTenderHandle)
                        Case -1, -3, -99   'Charge failed
                            txtMessage.Appearance.ForeColor = Drawing.Color.Firebrick
                            txtMessage.Text = "Charge Failed"
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
                    Exit For
                End If
            Next
            txtRemAmountDue.Value = mAmountDue - (txtStadisCharge.Value + txtPromoCharge.Value)
            If txtRemAmountDue.Value = 0 Then
                txtRemAmountDue.Appearance.ForeColor = System.Drawing.Color.Black
            Else
                txtRemAmountDue.Appearance.ForeColor = System.Drawing.Color.Firebrick
            End If
            txtMessage.Appearance.ForeColor = Drawing.Color.Teal
            txtMessage.Text = "Charge Successful"
            Return True
        Catch ex As Exception
            MsgBox(ex.Message.ToString(), , "SVAccountCharge")
            Return False
        End Try
    End Function  'DoSVAccountCharge

    Private Sub txtTenderID_ValueChanged(sender As Object, e As EventArgs) Handles txtTenderID.ValueChanged

    End Sub

#End Region  'Private Methods

End Class  'FrmStadisCharge