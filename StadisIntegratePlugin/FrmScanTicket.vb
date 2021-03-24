'Imports StadisIntegratePlugin.WebReference
Imports System.Windows.Forms
'----------------------------------------------------------------------------------------------
'   Class: FrmScanTicket
'    Type: Windows Form - Dialog Box
' Purpose: Collects and validates barcode scan if CustomerTicketOption is turned on.
'----------------------------------------------------------------------------------------------
Friend Class FrmScanTicket

    Private mCaption As String = ""
    Private mTicketID As String = ""
    Private mCustomerID As String = ""
    Private mEventID As String = ""
    Private mGiftCardExists As Boolean = False
    Private mGiftCardIsActive As Boolean = False
    Private mBalance As Decimal = 0D

    Private mAdapter As Plugins.IPluginAdapter

    Friend Property Caption() As String
        Get
            Return mCaption
        End Get
        Set(ByVal value As String)
            mCaption = value
        End Set
    End Property

    Friend Property TicketID() As String
        Get
            Return mTicketID
        End Get
        Set(ByVal value As String)
            mTicketID = value
        End Set
    End Property

    Friend Property CustomerID() As String
        Get
            Return mCustomerID
        End Get
        Set(ByVal value As String)
            mCustomerID = value
        End Set
    End Property

    Friend Property EventID() As String
        Get
            Return mEventID
        End Get
        Set(ByVal value As String)
            mEventID = value
        End Set
    End Property

    Friend Property GiftCardExists() As Boolean
        Get
            Return mGiftCardExists
        End Get
        Set(ByVal value As Boolean)
            mGiftCardExists = value
        End Set
    End Property

    Friend Property GiftCardIsActive() As Boolean
        Get
            Return mGiftCardIsActive
        End Get
        Set(ByVal value As Boolean)
            mGiftCardIsActive = value
        End Set
    End Property

    Friend Property Balance() As Decimal
        Get
            Return mBalance
        End Get
        Set(ByVal value As Decimal)
            mBalance = value
        End Set
    End Property

    Private Sub FrmScanTicket_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblCaption.Text = mCaption
    End Sub  'FrmScanTicket_Load

    Private Sub txtCustomerID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCustomerID.KeyDown
        Select Case e.KeyCode
            Case Keys.Tab, Keys.Enter, Keys.Right
                'btnOK.Focus()
                e.Handled = True
                btnOK.PerformClick()
        End Select
    End Sub  'txtCustomerID_KeyDown

    Private Function ValidateScan(ByVal scanText As String) As Boolean
        If Common.ValidateScan(scanText) = False Then
            MsgBox("Invalid scan content or length." & vbCrLf & "Scan: " & scanText, MsgBoxStyle.Exclamation, "GiftCard")
            Return False
        Else
            Return True
        End If
    End Function  'ValidateScan

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If ValidateScan(txtCustomerID.Text) = False Then Exit Sub
        mTicketID = txtCustomerID.Text

        Dim invoiceHandle As Integer = 0
        Dim sr As New StadisIntegratePlugin.WebReference.StadisRequest
        With sr
            .SiteID = gSiteID
            .TenderTypeID = 1
            .TenderID = txtCustomerID.Text
            .Amount = 0
            .ReferenceNumber = ""
            .VendorID = gVendorID
            .LocationID = gLocationID
            .RegisterID = Common.BOGetStrAttributeValueByName(mAdapter, invoiceHandle, "Invoice Workstion")
            .ReceiptID = ""
            .VendorCashier = Common.BOGetStrAttributeValueByName(mAdapter, invoiceHandle, "Cashier")
        End With

        Dim status As StadisIntegratePlugin.WebReference.TicketStatus = Common.StadisAPI.GetTicketStatus(sr)
        If status.TicketExists = True Then
            mGiftCardExists = True
            mBalance = status.SVA1Balance
            mEventID = status.TicketEventID
            If status.EventTicketEventTicketStatusID = 1 Then
                mGiftCardIsActive = True
            End If
        End If
        If status.CustomerExists = True Then
            mCustomerID = status.TicketCustomerID
        Else
            mCustomerID = gDefaultCustomerID
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub  'btnOK_Click

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        mCustomerID = gDefaultCustomerID
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub  'btnCancel_Click

End Class  'FrmScanTicket