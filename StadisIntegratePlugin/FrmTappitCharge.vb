Imports StadisIntegratePlugin.WebReference
Imports System.Drawing
Imports System.Text
Imports System.Text.RegularExpressions
Imports Infragistics.Win
Imports System.IO

'Imports TappitAPI

'----------------------------------------------------------------------------------------------
'   Class: FrmStadisCharge
'    Type: Windows Form
' Purpose: Collects Stadis tender information.  Invoked from TenderDialogue2.
'
' Item Note1 Before: STADIS\GiftCardID\IorA\CustomerID\Amount
' Item Note1 After: STADIS\GiftCardID\IorA\CustomerID\Amount\TranKey
'
' MANUAL_REMARK Before: StadisOpCode#CardID#AuthID
' MANUAL_REMARK After: StadisOpCode#TranKey
'----------------------------------------------------------------------------------------------
Public Class FrmTappitCharge

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
    Private mReturnComment As String = ""

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

    Private mParentDialog As TenderDialogue2 = Nothing
    Friend Property ParentDialog() As TenderDialogue2
        Get
            Return mParentDialog
        End Get
        Set(ByVal value As TenderDialogue2)
            mParentDialog = value
        End Set
    End Property

#End Region  'Properties

#Region " Form Load and Initialization "

    '----------------------------------------------------------------------------------------------
    ' Called when form is loaded
    '----------------------------------------------------------------------------------------------
    Private Sub FrmTappitCharge_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        Me.Text = gTappitTenderDialogFormText
        lblHeader.Text = gTappitTenderDialogHeader
        lblTenderID.Text = gTappitTenderDialogTenderIDLabel
        Dim strTemp As String
        strTemp = System.Reflection.Assembly.GetExecutingAssembly.Location()
        strTemp = Path.GetDirectoryName(strTemp)
        strTemp = strTemp & "\" & Trim(gFormTappitLogoImage)
        If File.Exists(strTemp) = True Then PictureBox1.ImageLocation = strTemp

    End Sub  'SetLabelsToCustomerPreference

    '----------------------------------------------------------------------------------------------
    ' Set on-screen fields to initial values
    '----------------------------------------------------------------------------------------------
    Private Sub InitializeFormFields()
        mAdapter = ParentDialog.Adapter
        mAmountDue = ParentDialog.Amount
        txtAmountDue.Value = mAmountDue
        txtTenderID.Text = ""
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
    'Private Sub FrmTappitCharge_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
    ' Dim strTemp As String = "c:\retailpro9\plugins\" & gFormTappitLogoImage
    ' If Trim(gFormLogoImage) <> "tappit.png" Then
    '         'pbLogo.Image = New Bitmap(gFormTappitLogoImage)
    '         pbLogo.Image = New Bitmap(strTemp)
    ' End If
    ' End Sub  'FrmStadisCharge_Paint

#End Region  'Form Load and Initialization

#Region " Events "

    '----------------------------------------------------------------------------------------------
    ' Make Enter show up in KeyDown event
    '----------------------------------------------------------------------------------------------
    Private Sub txtTender_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtTenderID.PreviewKeyDown
        If e.KeyCode = Keys.Enter Then
            e.IsInputKey = True
        End If
    End Sub  'txtTender_PreviewKeyDown

    '----------------------------------------------------------------------------------------------
    ' Make Enter act like Tab
    '----------------------------------------------------------------------------------------------
    Private Sub txtTenderID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTenderID.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnOK.Focus()
            If ValidateBeforeProcessing() = False Then Exit Sub
            OKProcessing()
            e.Handled = True
        End If
    End Sub  'txtTenderID_KeyDown

    '----------------------------------------------------------------------------------------------
    ' Check ticket balance, update on-screen fields
    '----------------------------------------------------------------------------------------------
    Private Sub txtTenderID_Leave(sender As Object, e As EventArgs) Handles txtTenderID.Leave

        'Validate TenderID against our regex pattern or something like that for length / content
        'Refer to the StadisCharge similar functions

        'Trim
        txtTenderID.Text = Trim(txtTenderID.Text)

    End Sub  'txtTenderID_Leave


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
        txtMessage.Text = ""
        gLastTenderID = ""
        gLastAmount = 0D
        mIsDuplicate = False
        btnOK.Text = "Process"
        chkCertify.Checked = False
        txtOriginalDocAmt.Value = Math.Abs(txtAmountDue.Value)

    End Sub  'btnClear_Click

    '----------------------------------------------------------------------------------------------
    ' Process SVAccountCharge.  If successful, pause a sec to diaplay message, then exit
    '----------------------------------------------------------------------------------------------
    Private Function ValidateBeforeProcessing() As Boolean

        txtOriginalDocID.Text = UCase(txtOriginalDocID.Text)

        If txtAmountDue.Value = 0 Then
            MsgBox("There is no tender amount!")
            Return False
            Exit Function
        End If

        If Trim(txtTenderID.Text) = "" Then
            MsgBox("The barcode field is blank!")
            Return False
            Exit Function
        End If

        If CDec(txtAmountDue.Text) < 0 Then
            If Trim(txtOriginalDocID.Text) = "" Then
                MsgBox("The original document ID is required to perform a return!")
                Return False
                Exit Function
            End If
        End If

        'If CDec(txtAmountDue.Text) < 0 Then
        ' txtOriginalDocAmt.Text = Trim(txtOriginalDocAmt.Text)
        'End If

        If CDec(txtAmountDue.Text) < 0 Then
            If Math.Abs(txtOriginalDocAmt.Value) <> Math.Abs(txtAmountDue.Value) Then
                MsgBox("The items being returned on this receipt need to exactly add up to the original document total!")
                Return False
                Exit Function
            End If
        End If

        If txtAmountDue.Value < 0 Then
            If chkCertify.Checked = False Then
                MsgBox("Please certify the full original receipt amount!")
                Return False
                Exit Function
            End If
        End If

        Return True

    End Function

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        If ValidateBeforeProcessing() = False Then Exit Sub

        OKProcessing()
    End Sub  'btnOK_Click

    Private Sub OKProcessing()
        Dim i As Integer = 0
        Dim strALU As String = ""
        Dim intResult As Integer = 0
        Dim intQty As Integer = 0
        Dim decPrice As Decimal = 0
        Dim blnTokenApplied As Boolean = False
        Dim blnTestMode As Boolean = False
        Dim decTaxAmount As Decimal = 0

        Dim decAmount As Decimal = 0
        Dim decTaxRate As Decimal = 0
        Dim decRawPrice As Decimal = 0
        Dim decRoundedPrice As Decimal = 0
        Dim decRemainingTax As Decimal = 0
        Dim decQty As Decimal = 0
        Dim decDivisor As Decimal = 0
        Dim decRawPriceExt As Decimal = 0
        Dim decExtPrice As Decimal = 0
        Dim decExtTax As Decimal = 0
        Dim decRawTax As Decimal = 0
        Dim decTax As Decimal = 0
        Dim decAccumDiscount As Decimal = 0
        Dim decDiscount As Decimal = 0

        If btnOK.Text = "Exit" Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If

        If mIsDuplicate = False Then

            gTappitTokenUsageArrayRowCount = 0
            gTappitComplimentaryUsageArrayRowCount = 0

            Dim chargeSucceeded As Boolean = DoSVAccountCharge()
            'frmTappitCharge.DoSVAccountCharge() calls TappitAPI.Tappit_POS_Spend that calls TappitAPI.TappitSpendPostsets 
            ' gTappit Token And Complimentary rowcounts and arrays from recvSpend (Tappit response)
            ' and 
            ' gTappitApprovedTenderAmount from CDec(recvSpend.charged_amount)
            ' gTappitComplimentaryUsageTotal from CDec(recvSpend.complimentary_amount)
            ' gTappitTokenUsageTotal from CDec(recvSpend.token_amount)


            'blnTestMode = True
            If blnTestMode = True Then MsgBox("Test mode frmTappitCharge.OKprocessing")

            If chargeSucceeded Then

                'apply skidata items first
                decAccumDiscount = 0
                For i = 0 To gTappitSkiDataUsageArrayRowCount - 1
                    decDiscount = CDec(gTappitSkiDataUsageArray(1, i))
                    decAccumDiscount = decAccumDiscount + decDiscount
                Next i

                Dim itemHandle As Integer = mAdapter.GetReferenceBOForAttribute(0, "Items")

                If decAccumDiscount > 0 Then
                    mAdapter.BOFirst(itemHandle)
                    While Not mAdapter.EOF(itemHandle)
                        strALU = CStr(mAdapter.BOGetAttributeValueByName(itemHandle, "Lookup ALU"))
                        decPrice = CDec(mAdapter.BOGetAttributeValueByName(itemHandle, "Price"))
                        intQty = CInt(mAdapter.BOGetAttributeValueByName(itemHandle, "Qty"))
                        For i = 0 To gTappitSkiDataUsageArrayRowCount - 1
                            '                          0         1     2         3    4           5            6             7     8           9       10
                            'origin 0, 11 columns amount, discount, name, quantity, sku, tax_amount, tax_included, tax_percent, type, unit_price, applied
                            If gTappitSkiDataUsageArray(10, i) <> "Y" Then
                                If strALU = gTappitSkiDataUsageArray(4, i) Then
                                    If decPrice = CDec(gTappitSkiDataUsageArray(9, i)) Then
                                        If intQty = CInt(gTappitSkiDataUsageArray(3, i)) Then
                                            'ok same sku, same price, same qty
                                            'discount the item
                                            'decAmount is the extended amount including extended tax
                                            'line items with quantity = 0 are excluded because they are set to "Y" (applied) during build of array
                                            decQty = CDec(gTappitSkiDataUsageArray(3, i))
                                            decAmount = CDec(gTappitSkiDataUsageArray(0, i))       'ext with ext tax
                                            decTax = CDec(gTappitSkiDataUsageArray(5, i))
                                            decExtTax = decTax * decQty
                                            decRawPriceExt = decAmount - decExtTax
                                            decRawPrice = decRawPriceExt / decQty                   'item individual price not rounded
                                            decPrice = Math.Round(decRawPrice, 2, MidpointRounding.AwayFromZero)
                                            decExtPrice = decPrice * decQty
                                            decExtTax = decAmount - decExtPrice
                                            decRawTax = decExtTax / decQty
                                            decTax = Math.Round(decRawTax, 5, MidpointRounding.AwayFromZero)
                                            mAdapter.BOSetAttributeValueByName(itemHandle, "Price", decPrice)
                                            mAdapter.BOSetAttributeValueByName(itemHandle, "Tax Amount", decTax)
                                            mAdapter.BOSetAttributeValueByName(itemHandle, "Discount Reason Id", gTappitSkiDataDiscountTypeID)

                                            mAdapter.BOPost(itemHandle)
                                            'mAdapter.BORefreshRecord(itemHandle, True, True)
                                            mAdapter.BORecalculateAttribute(0, "SubTotX")
                                            gTappitSkiDataUsageArray(10, i) = "Y"
                                        End If
                                    End If
                                End If
                            End If
                        Next i

                        mAdapter.BONext(itemHandle)
                    End While
                End If



                If gTappitTokenUsageArrayRowCount > 0 Then
                    'Dim itemHandle As Integer = mAdapter.GetReferenceBOForAttribute(0, "Items")

                    For i = 0 To gTappitTokenUsageArrayRowCount - 1
                        'description, used_amount, sku, product_name, expire_date
                        'MsgBox("sku " & gTappitTokenUsageArray(2, i))
                        mAdapter.BOFirst(itemHandle)
                        blnTokenApplied = False
                        While Not mAdapter.EOF(itemHandle)
                            If blnTokenApplied = False Then
                                decPrice = CDec(mAdapter.BOGetAttributeValueByName(itemHandle, "Price"))
                                If decPrice <> 0 Then
                                    strALU = CStr(mAdapter.BOGetAttributeValueByName(itemHandle, "Lookup ALU"))
                                    If strALU = gTappitTokenUsageArray(2, i) Then
                                        If blnTestMode = True Then MsgBox("token ALU " & strALU)
                                        intQty = CInt(mAdapter.BOGetAttributeValueByName(itemHandle, "Qty"))
                                        If intQty = 1 Then
                                            mAdapter.BOSetAttributeValueByName(itemHandle, "Price", 0)
                                            mAdapter.BOSetAttributeValueByName(itemHandle, "Tax Amount", 0)
                                            mAdapter.BOSetAttributeValueByName(itemHandle, "Tax Amount 2", 0)
                                            mAdapter.BOSetAttributeValueByName(itemHandle, "Discount Reason Id", gTappitTokenDiscountTypeID)

                                            blnTokenApplied = True
                                            mAdapter.BOLast(itemHandle)
                                            If blnTestMode = True Then MsgBox("case qty 1 token applied " & strALU)
                                        End If
                                        If intQty > 1 Then
                                            mAdapter.BOSetAttributeValueByName(itemHandle, "Qty", intQty - 1)
                                            mAdapter.BOPost(itemHandle)
                                            'mAdapter.BORefresh(itemHandle)

                                            mAdapter.BOLast(itemHandle)
                                            mAdapter.BOInsert(itemHandle)
                                            mAdapter.BOSetAttributeValueByName(itemHandle, "Lookup ALU", strALU)
                                            mAdapter.BOSetAttributeValueByName(itemHandle, "Qty", 1)
                                            mAdapter.BOSetAttributeValueByName(itemHandle, "Price", 0)
                                            mAdapter.BOSetAttributeValueByName(itemHandle, "Tax Amount", 0)
                                            mAdapter.BOSetAttributeValueByName(itemHandle, "Tax Amount 2", 0)
                                            mAdapter.BOSetAttributeValueByName(itemHandle, "Discount Reason Id", gTappitTokenDiscountTypeID)

                                            mAdapter.BOPost(itemHandle)
                                            mAdapter.BORefreshRecord(itemHandle, True, True)
                                            blnTokenApplied = True
                                            If blnTestMode = True Then MsgBox("case qty > 1 token applied " & strALU)
                                        End If
                                    End If
                                End If
                            End If
                            mAdapter.BONext(itemHandle)
                        End While
                    Next i
                End If

                If gTappitComplimentaryUsageArrayRowCount > 0 Then
                    'Dim tenderHandle As Integer = mAdapter.GetReferenceBOForAttribute(0, "Tenders")
                    'mAdapter.BOOpen(tenderHandle)
                    'intResult = mAdapter.BOInsert(tenderHandle)

                    'cash works
                    'mAdapter.BOSetAttributeValueByName(tenderHandle, "TENDER_TYPE", 0)
                    'mAdapter.BOSetAttributeValueByName(tenderHandle, "AMT", CDec(gTappitComplimentaryUsageTotal))
                    'mAdapter.BOSetAttributeValueByName(tenderHandle, "TAKEN", CDec(gTappitComplimentaryUsageTotal))
                    'mAdapter.BOPost(tenderHandle)
                    'Transaction Discount
                    mAdapter.BOSetAttributeValueByName(0, "Transaction Discount", CDec(gTappitComplimentaryUsageTotal))
                End If

                btnOK.Text = "Exit"
                'Wait(1)
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        Else
            'test below
            'MsgBox("charge failed!")
            'test abofe
            MsgBox("Cannot add a Tappit tender.", MsgBoxStyle.Exclamation, "TAPPIT Tender")
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


    Private Function DoSVAccountCharge() As Boolean
        Try
            'Original unique ID
            'Dim invcSID = Common.BOGetStrAttributeValueByName(mAdapter, mInvoiceHandle, "Invoice SID")
            'Dim strInvsSID = Common.GetStringSID(CLng(invcSID))

            gTappitCurrentDocumentUniqueID = Common.Unique16CharString()

            Common.BOSetAttributeValueByName(mAdapter, mInvoiceHandle, "Custom Field", gTappitCurrentDocumentUniqueID)

            Dim sr As New StadisIntegratePlugin.WebReference.StadisRequest
            With sr
                '.ReferenceNumber = strInvsSID
                .ReferenceNumber = gTappitCurrentDocumentUniqueID
                .ReceiptID = UCase(Trim(txtOriginalDocID.Text))
                .TenderID = Trim(txtTenderID.Text)
                '.RegisterID = "1112" 'used in successful test
                .RegisterID = Common.BOGetStrAttributeValueByName(mAdapter, mInvoiceHandle, "Invoice Workstion")
                .LocationID = Common.BOGetStrAttributeValueByName(mAdapter, mInvoiceHandle, "Store Code")
                .Amount = txtAmountDue.Value
            End With

            Dim sys As StadisIntegratePlugin.WebReference.StadisReply() = Nothing

            If txtAmountDue.Value >= 0 Then
                Try
                    sys = TappitAPI.Tappit_POS_Spend(sr, Common.LoadTappitItems(mAdapter, "Receipt", mInvoiceHandle, mItemHandle))
                    mReturnComment = sys(0).Comment
                    mReturnCode = sys(0).ReturnCode

                    mReturnMessage = sys(0).ReturnMessage
                    txtMessage.Text = mReturnMessage
                Catch ex As Exception
                    MsgBox("Tappit transaction failed" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Account Transaction Exception")
                    txtMessage.Text = "Tappit transaction failed"
                    txtTenderID.Text = ""
                    With ParentDialog
                        .Amount = 0D
                        .Remark = "Error"
                        .DATA8 = " "
                    End With
                    Return False
                End Try
            End If

            If txtAmountDue.Value < 0 Then
                Try
                    sys = TappitAPI.Tappit_POS_Refund(sr)
                    mReturnComment = sys(0).Comment
                    mReturnCode = sys(0).ReturnCode
                    mReturnMessage = sys(0).ReturnMessage
                    txtMessage.Text = mReturnMessage
                Catch ex As Exception
                    MsgBox("Tappit transaction failed" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Account Transaction Exception")
                    txtMessage.Text = "Tappit transaction failed"
                    txtTenderID.Text = ""
                    With ParentDialog
                        .Amount = 0D
                        .Remark = "Error"
                        .DATA8 = " "
                    End With
                    Return False
                End Try
            End If

            If mReturnCode <> 200 Then
                'MsgBox("Tappit Charge failed." & vbCrLf & mReturnMessage, MsgBoxStyle.Critical, "SVAccountCharge")
                'txtMessage.Text = "Tappit transaction failed"
                txtTenderID.Text = ""
                With ParentDialog
                    .Amount = 0D
                    .Remark = "Error"
                End With
                Return False
            End If

            Select Case (sys(0).ReturnCode)
                Case 200
                    With ParentDialog
                        '.Amount = sys(0).ChargedAmount
                        If txtAmountDue.Value < 0 Then
                            '.Amount = (txtAmountDue.Value * (-1))
                            'gTappitApprovedTenderAmount = (txtAmountDue.Value * (-1))
                            .Amount = txtAmountDue.Value
                            gTappitApprovedTenderAmount = txtAmountDue.Value
                        End If
                        If txtAmountDue.Value >= 0 Then

                            .Amount = sys(0).ChargedAmount
                            gTappitApprovedTenderAmount = sys(0).ChargedAmount

                        End If

                        .Remark = gTappitCurrentDocumentUniqueID  'works - going in as manual_remark - varchar(40), displays as comment in tender
                        '.DATA0 = "test0"
                        '.DATA1 = "test1"
                        '.CurrencyType = 3
                        '.DATA11 = "test11"


                        .AccountNumber = gTappitCurrentDocumentUniqueID 'works - going in as doc_no - varchar(30)
                        '.CheckType = 0   'actual invc_tender field looks like chk_type, default zero
                        '.Given = 0
                        '.Taken = sys(0).ChargedAmount
                    End With
                Case Else
                    'MsgBox("Transaction failed!" & vbCrLf & mReturnMessage, MsgBoxStyle.Exclamation, "Tappit Tender")
                    'txtMessage.Text = "Tappit transaction failed"
                    txtTenderID.Text = ""
                    With ParentDialog
                        .Amount = 0D
                        .Remark = "Error"
                    End With
                    Return False
            End Select

            txtMessage.Appearance.ForeColor = Drawing.Color.Teal
            txtMessage.Text = "Charge Successful"
            'Common.PressF12()


            Return True

            Catch ex As Exception
                MsgBox(ex.Message.ToString(), , "SVAccountCharge")
            Return False
        End Try

    End Function  'DoSVAccountCharge

    Private Sub txtTenderID_ValueChanged(sender As Object, e As EventArgs) Handles txtTenderID.ValueChanged

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub FrmTappitCharge_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated

        If CDec(txtAmountDue.Text) >= 0 Then
            lblOriginalDocID.Visible = False
            txtOriginalDocID.Visible = False
            txtOriginalDocID.Text = ""
            lblOriginalDocAmt.Visible = False
            txtOriginalDocAmt.Visible = False
            txtOriginalDocAmt.Value = 0
            chkCertify.Visible = False
            chkCertify.Checked = False
        End If

        If CDec(txtAmountDue.Text) < 0 Then
            lblOriginalDocID.Visible = True
            txtOriginalDocID.Visible = True
            txtOriginalDocID.Text = ""
            lblOriginalDocAmt.Visible = True
            txtOriginalDocAmt.Visible = True
            txtOriginalDocAmt.Value = Math.Abs(txtAmountDue.Value)
            chkCertify.Visible = True
            chkCertify.Checked = False
        End If

    End Sub

    Private Sub lblTenderID_Click(sender As Object, e As EventArgs) Handles lblTenderID.Click

    End Sub

    Private Sub txtOriginalDocID_ValueChanged(sender As Object, e As EventArgs) Handles txtOriginalDocID.ValueChanged

    End Sub

    Private Sub txtMessage_ValueChanged(sender As Object, e As EventArgs) Handles txtMessage.ValueChanged

    End Sub

#End Region  'Private Methods

End Class  'FrmStadisCharge