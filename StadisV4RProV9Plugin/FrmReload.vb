Imports CommonV4
Imports CommonV4.WebReference
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Drawing
Imports System.Windows.Forms
'----------------------------------------------------------------------------------------------
'   Class: FrmReload
'    Type: Windows Form
' Purpose: Reload gift cards.  Invoked by ButtonReload.
'----------------------------------------------------------------------------------------------
Friend Class FrmReload

#Region " Data Declarations "

    Private mAdapter As Plugins.IPluginAdapter
    Private mGiftCardALU As String = ""
    Private mEventID As String = ""
    Private mCustomerID As String = ""
    Private mAccountBalance As Decimal = 0D
    Private mTenderHasBeenCharged As Boolean = False
    Private mAuthID As String = ""
    Private mStatus As TicketStatus = Nothing

    Const Active As Integer = 1
    Const Pending As Integer = 3

    Friend Property Adapter() As Plugins.IPluginAdapter
        Get
            Return mAdapter
        End Get
        Set(ByVal value As Plugins.IPluginAdapter)
            mAdapter = value
        End Set
    End Property

#End Region  'Data Declarations

#Region " Form Load and Initialization "

    '----------------------------------------------------------------------------------------------
    ' Called when form is loaded
    '----------------------------------------------------------------------------------------------
    Private Sub FrmReload_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Trim(gFormLogoImage) <> "stadislogo.png" Then
            pbLogo.Image = New Bitmap(gFormLogoImage)
        End If
        mEventID = ""
        mCustomerID = ""
    End Sub  'FrmReload_Load

#End Region  'Form Load and Initialization

#Region " Buttons "

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

        'Check for blank input
        If txtGiftCardID.Text <> Trim(txtGiftCardID.Text) Then
            txtGiftCardID.Text = Trim(txtGiftCardID.Text)
        End If
        If txtGiftCardID.Text = "" OrElse Trim(txtReloadAmount.Text) = "" Then Exit Sub

        'Check against min and max
        Dim rMinAmount As Decimal = 0D
        Dim rMaxAmount As Decimal = 999D
        For Each gRow As DSGiftCardInfo.ReloadInfoRow In gGCI.ReloadInfo.Rows
            If gRow.RProLookupALU = mGiftCardALU Then
                rMinAmount = gRow.RMinAmount
                rMaxAmount = gRow.RMaxAmount
                Exit For
            End If
        Next
        If rMaxAmount = 0D Then
            rMaxAmount = 999D
        End If
        If mAccountBalance + CDec(txtReloadAmount.Text) > rMaxAmount Then
            txtReloadAmount.Text = (rMaxAmount - mAccountBalance).ToString
            MessageBox.Show("Card amount may not exceed " & rMaxAmount.ToString("""$""#,##0.00") & ".", "STADIS")
            Exit Sub
        End If
        If CDec(txtReloadAmount.Text) < rMinAmount OrElse CDec(txtReloadAmount.Text) > rMaxAmount Then
            If CDec(txtReloadAmount.Text) < rMinAmount Then
                txtReloadAmount.Text = rMinAmount.ToString
            ElseIf CDec(txtReloadAmount.Text) > rMaxAmount Then
                txtReloadAmount.Text = rMaxAmount.ToString
            End If
            If rMinAmount = rMaxAmount Then
                MessageBox.Show("Reload amount is fixed at " & rMinAmount.ToString("""$""#,##0.00") & ".", "STADIS")
            Else
                MessageBox.Show("Reload amount must be between " & rMinAmount.ToString("""$""#,##0.00") & " and " & rMaxAmount.ToString("""$""#,##0.00") & ".", "STADIS")
            End If
            Exit Sub
        End If

        AddMoneyToSVAccount()

        AddOurItemAndTenderToRPro()

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub  'btnOK_Click

#End Region  'Buttons

#Region " Other Methods "

    Private Sub txtGiftCardID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtGiftCardID.KeyDown
        If Not e Is Nothing Then
            If e.KeyData = Keys.Enter Then
                e.Handled = True
                txtReloadAmount.Focus()
            End If
        End If
    End Sub  'txtGiftCardID_KeyDown

    Private Sub txtGiftCardID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGiftCardID.Leave

        If btnCancel.ContainsFocus = True Then
            Exit Sub
        End If

        'Strip out extra characters from scanner
        Dim extractedScan As String = CommonRoutines.ExtractScan(txtGiftCardID.Text)
        If extractedScan <> txtGiftCardID.Text Then
            txtGiftCardID.Text = extractedScan
        End If

        'Validate against our pattern for length / content
        If CommonRoutines.ValidateScan(extractedScan) = False Then
            MsgBox("Invalid scan content or length." & vbCrLf & "Scan: " & extractedScan, MsgBoxStyle.Exclamation, "GiftCard")
            txtGiftCardID.Text = ""
            txtGiftCardID.Focus()
            Exit Sub
        End If

        'Get TicketStatus
        Dim invoiceHandle As Integer = 0
        Dim sr As New StadisRequest
        With sr
            .SiteID = gSiteID
            .TenderTypeID = 1
            .TenderID = txtGiftCardID.Text
            .Amount = 0
            .ReferenceNumber = ""
            .VendorID = gVendorID
            .LocationID = gLocationID
            .RegisterID = CommonRoutines.BOGetStrAttributeValueByName(mAdapter, invoiceHandle, "Invoice Workstion")
            .ReceiptID = ""
            .VendorCashier = CommonRoutines.BOGetStrAttributeValueByName(mAdapter, invoiceHandle, "Cashier")
        End With
        mStatus = CommonRoutines.StadisAPI.GetTicketStatus(sr)
        If mStatus.ReturnCode < 0 Then
            If mStatus.ReturnCode <> -3 Then
                MsgBox("Unable to validate card...", MsgBoxStyle.Exclamation, "GiftCard")
                txtGiftCardID.Text = ""
                txtGiftCardID.Focus()
                Exit Sub
            End If
        End If

        If mStatus.TicketExists = False AndAlso mStatus.EventTicketExists = True Then
            MsgBox("No matching Ticket for EventTicket...", MsgBoxStyle.Information, "GiftCard")
            txtGiftCardID.Text = ""
            txtGiftCardID.Focus()
            Exit Sub
        End If

        If mStatus.TicketExists = True Then
            If Trim(mStatus.TicketGCALU) <> "" Then
                mGiftCardALU = Trim(mStatus.TicketGCALU)
            Else
                mGiftCardALU = "GiftReload"
            End If
            mEventID = mStatus.CustomerStatus2
            mCustomerID = mStatus.TicketCustomerID
            mAccountBalance = mStatus.SVA1Balance
            Select Case mStatus.TicketEventTicketStatusID
                Case Active
                    txtCurrentBalance.Text = mStatus.SVA1Balance.ToString("""$""#,##0.00")
                    Exit Sub
                Case Pending
                    MsgBox("Gift Card has not been activated.", MsgBoxStyle.Information, "GiftCard")
                    txtGiftCardID.Text = ""
                    txtGiftCardID.Focus()
                    Exit Sub
                Case Else
                    MsgBox("Gift Card is not in a valid status...", MsgBoxStyle.Information, "GiftCard")
                    txtGiftCardID.Text = ""
                    txtGiftCardID.Focus()
                    Exit Sub
            End Select
        End If

    End Sub  'txtGiftCardID_Leave

    Private Sub txtAmount_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtReloadAmount.KeyDown
        If Not e Is Nothing AndAlso Trim(txtReloadAmount.Text) <> "" Then
            If e.KeyData = Keys.Enter Then
                e.Handled = True
                btnOK.Focus()
            End If
        End If
    End Sub  'txtAmount_KeyDown

    Private Sub txtAmount_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtReloadAmount.Leave
        If Trim(txtReloadAmount.Text) <> "" Then
            txtBalanceAfter.Text = (CDec(txtCurrentBalance.Text) + CDec(txtReloadAmount.Text)).ToString("""$""#,##0.00")
            Dim amt As Decimal = CDec(txtReloadAmount.Text)
            txtReloadAmount.Text = amt.ToString("""$""#,##0.00")
        End If
    End Sub  'txtAmount_Leave

    '------------------------------------------------------------------------------
    ' Deposit funds to account
    '------------------------------------------------------------------------------
    Private Sub AddMoneyToSVAccount()
        Try
            'Build StadisRequest and do reload
            Dim sr As New StadisRequest
            With sr
                .SiteID = gSiteID
                .TenderTypeID = 1
                .TenderID = Trim(txtGiftCardID.Text)
                .Amount = CDec(txtReloadAmount.Text)
                .ReferenceNumber = ""
                .ToSVAccountID = mStatus.EventTicketSVAccountID
                .VendorID = gVendorID
                .LocationID = gLocationID
                .RegisterID = gRegisterID
                .ReceiptID = CommonRoutines.BOGetStrAttributeValueByName(mAdapter, 0, "Invoice Number")
                .VendorCashier = gVendorCashier
            End With
            Dim sys As StadisReply = CommonRoutines.StadisAPI.GCReload(sr)
            If sys.ReturnCode < 0 Then
                MsgBox("Gift card reload failed." & vbCrLf & sys.ReturnMessage, MsgBoxStyle.Critical, "Reload")
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString(), , "Reload")
        End Try
    End Sub  'AddMoneyToSVAccount

    '------------------------------------------------------------------------------
    ' Take entries and add them as an item to Retail Pro
    '------------------------------------------------------------------------------
    Private Sub AddOurItemAndTenderToRPro()
        Try
            Dim giftCardID As String = txtGiftCardID.Text
            Dim amount As Decimal = CDec(txtReloadAmount.Text)
            Dim invoiceHandle As Integer = 0
            'Create an item
            Dim itemHandle As Integer = mAdapter.GetReferenceBOForAttribute(invoiceHandle, "Items")
            CommonRoutines.BOOpen(mAdapter, itemHandle)
            CommonRoutines.BOInsert(mAdapter, itemHandle)
            CommonRoutines.BOSetAttributeValueByName(mAdapter, itemHandle, "Lookup ALU", mGiftCardALU)
            CommonRoutines.BOSetAttributeValueByName(mAdapter, itemHandle, "Item Note1", "STADIS\" & giftCardID & "\R\" & mCustomerID & "\" & amount)
            CommonRoutines.BOSetAttributeValueByName(mAdapter, itemHandle, "Quantity", 1)
            CommonRoutines.BOSetAttributeValueByName(mAdapter, itemHandle, "Price", 0D)
            CommonRoutines.BOSetAttributeValueByName(mAdapter, itemHandle, "Tax Amount", 0D)
            CommonRoutines.BOPost(mAdapter, itemHandle)
            CommonRoutines.BORefreshRecord(mAdapter, invoiceHandle)
            'Create a fee or a tender with an offsetting negative balance
            If amount > 0D Then
                Select Case gFeeOrTenderForReloadOffset
                    Case "Fee"
                        CommonRoutines.BOOpen(mAdapter, invoiceHandle)
                        Dim fee As Decimal = CommonRoutines.BOGetDecAttributeValueByName(mAdapter, invoiceHandle, "Fee Amt")
                        fee += amount
                        CommonRoutines.BOSetAttributeValueByName(mAdapter, invoiceHandle, "Fee Amt", fee)
                    Case "Tender"
                        Dim tenderHandle As Integer = mAdapter.GetReferenceBOForAttribute(0, "Tenders")
                        CommonRoutines.BOOpen(mAdapter, tenderHandle)
                        CommonRoutines.BOInsert(mAdapter, tenderHandle)
                        CommonRoutines.BOSetAttributeValueByName(mAdapter, tenderHandle, "TENDER_TYPE", gTenderDialogTenderType)
                        CommonRoutines.BOSetAttributeValueByName(mAdapter, tenderHandle, "AMT", 0 - amount)
                        If CommonRoutines.IsAGiftCard(mEventID) Then
                            CommonRoutines.BOSetAttributeValueByName(mAdapter, tenderHandle, "MANUAL_REMARK", "@GL #" & txtGiftCardID.Text)
                        Else
                            CommonRoutines.BOSetAttributeValueByName(mAdapter, tenderHandle, "MANUAL_REMARK", "@TL #" & txtGiftCardID.Text)
                        End If
                        If gTenderDialogTenderType = Plugins.TenderTypes.ttGiftCard Then
                            CommonRoutines.BOSetAttributeValueByName(mAdapter, tenderHandle, "CRD_EXP_MONTH", 1)
                            CommonRoutines.BOSetAttributeValueByName(mAdapter, tenderHandle, "CRD_EXP_YEAR", 1)
                            CommonRoutines.BOSetAttributeValueByName(mAdapter, tenderHandle, "CRD_TYPE", 1)
                            CommonRoutines.BOSetAttributeValueByName(mAdapter, tenderHandle, "CRD_PRESENT", 1)
                        End If
                        CommonRoutines.BOPost(mAdapter, tenderHandle)
                        CommonRoutines.BORefreshRecord(mAdapter, invoiceHandle)
                    Case Else
                        MessageBox.Show("Invalid offset option specified.", "STADIS")
                End Select
            Else
                MessageBox.Show("No reload amount entered.", "STADIS")
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("Error while adding STADIS gift card(s)." & vbCrLf & ex.Message, "STADIS")
        End Try
    End Sub  'AddOurItemsAndTenderToRPro

    '------------------------------------------------------------------------------
    ' Invoked when form is closed for any reason - makes sure we release pointers 
    '------------------------------------------------------------------------------
    Private Sub FrmReload_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        mAdapter = Nothing
    End Sub  'FrmReload_Closing

#End Region  'Other Methods

End Class  'FrmReload