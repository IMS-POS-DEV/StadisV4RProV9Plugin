Imports CommonV4
Imports CommonV4.WebReference
Imports RetailPro.CustomPluginClasses
Imports RetailPro.Plugins
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
'----------------------------------------------------------------------------------------------
'   Class: PrintUpdateStadisProcessing
'    Type: EntityUpdate / BeforeUpdate on Invoice
' Purpose: Before invoice is saved, processes Stadis charges, issues/activates, and posts Stadis transactions
'----------------------------------------------------------------------------------------------
<GuidAttribute(Discover.CLASS_PrintUpdateStadisProcessing)> _
Public Class PrintUpdateStadisProcessing
    Inherits TCustomEntityUpdatePlugin

    Private mRProTenderCount As Integer = 0
    Private mTransactionShouldBeWritten As Boolean = False
    Private mCreditsToProcess As Boolean = False
    Private mHasInserts As Boolean = False
    Private mItemCount As Integer = 0
    Private mTenderCount As Integer = 0
    Private mGiftCardCount As Integer = 0

    '----------------------------------------------------------------------------------------------
    ' Called when plugin is loaded
    '----------------------------------------------------------------------------------------------
    Public Overrides Sub Initialize()
        MyBase.Initialize()
        fEnabled = True
        fGUID = New Guid(Discover.CLASS_PrintUpdateStadisProcessing)
        fBusinessObjectType = RetailPro.Plugins.BusinessObjectType.btInvoice
    End Sub  'Initialize

    '----------------------------------------------------------------------------------------------
    ' Called when Print/Update is pressed, but before save
    ' Look thru items for Issues, Activates and Reloads
    ' Look thru tenders for Redeems
    ' Do appropriate Stadis web service calls
    '----------------------------------------------------------------------------------------------
    Public Overrides Function BeforeUpdate() As Boolean
        Try

            ' Get pointers to receipt components
            Dim invoiceHandle As Integer = 0
            Dim itemHandle As Integer = fAdapter.GetReferenceBOForAttribute(invoiceHandle, "Items")
            Dim tenderHandle As Integer = fAdapter.GetReferenceBOForAttribute(invoiceHandle, "Tenders")

            ''Uncomment to get attribute lists
            'Dim attrlist As Object
            'attrlist = fAdapter.BOGetAttributeNameList(invoiceHandle)
            'Dim x As String = ""
            'attrlist = fAdapter.BOGetAttributeNameList(itemHandle)
            'Dim y As String = ""
            'attrlist = fAdapter.BOGetAttributeNameList(tenderHandle)
            'Dim z As String = ""

            If Adapter.BOIsAttributeInList(itemHandle, "Lookup ALU") = False Then
                Dim result As Integer = Adapter.BOIncludeAttrIntoList(itemHandle, "Lookup ALU", True, False)
                If result = RetailPro.Plugins.PluginError.peSuccess Then
                    Adapter.BOUpdateListDataSet(itemHandle, True, False)
                Else
                    MessageBox.Show("Unable to add 'Lookup ALU' to list")
                End If
            End If
            If Adapter.BOIsAttributeInInstance(itemHandle, "Lookup ALU") = False Then
                Dim result As Integer = Adapter.BOIncludeAttrIntoInstance(itemHandle, "Lookup ALU", True, False)
                If result = RetailPro.Plugins.PluginError.peSuccess Then
                    Adapter.BOUpdateInstanceDataSet(itemHandle, True, False)
                Else
                    MessageBox.Show("Unable to add 'Lookup ALU' to instance")
                End If
            End If

            mTransactionShouldBeWritten = False
            mCreditsToProcess = False
            mGiftCardCount = 0
            mHasInserts = False

            ' Loop thru items and tenders and count them
            ' Check if there are Issues, Activates or Reloads
            ' If there are gift cards, make sure that there is a negative, offsetting tender or tenders.
            Dim processedOK As Boolean = PrepItemsAndTenders(invoiceHandle, itemHandle, tenderHandle)
            If processedOK = False Then Return False

            ' Receipt or return?
            Dim retval As Boolean = False
            If gIsAReturn = False Then
                retval = ProcessReceipt(invoiceHandle, itemHandle, tenderHandle)
            Else
                retval = ProcessReturn(invoiceHandle, itemHandle, tenderHandle)
            End If
            Return retval

        Catch ex As Exception
            MessageBox.Show("005 Error while processing STADIS transaction." & vbCrLf & ex.Message, "STADIS")
            Return False
        End Try
        Return MyBase.BeforeUpdate()
    End Function  'BeforeUpdate

    '----------------------------------------------------------------------------------------------
    ' Make sure that negative tender offset(s) equal gift card total
    '----------------------------------------------------------------------------------------------
    Private Function PrepItemsAndTenders(ByVal invoiceHandle As Integer, ByVal itemHandle As Integer, ByVal tenderHandle As Integer) As Boolean
        mItemCount = 0
        mTenderCount = 0
        Dim giftCardTotal As Decimal = 0D
        Dim offsetTotal As Decimal = 0D
        Try

            ' Check items
            CommonRoutines.BOOpen(fAdapter, itemHandle)
            CommonRoutines.BOFirst(fAdapter, itemHandle)
            While Not fAdapter.EOF(itemHandle)
                mItemCount += 1
                Dim alu As String
                Try
                    alu = CommonRoutines.BOGetStrAttributeValueByName(fAdapter, itemHandle, "Lookup ALU")
                Catch ex As Exception
                    alu = "NoALU"
                End Try
                If IsAGiftCardALU(alu) Then
                    Dim Stadis() As String = CommonRoutines.BOGetStrAttributeValueByName(fAdapter, itemHandle, "Item Note1").Split("\"c)
                    If Stadis(0) = "STADIS" Then
                        Select Case Stadis(2)
                            Case "I"
                                mHasInserts = True
                                mGiftCardCount += 1
                                giftCardTotal += CDec(Stadis(4))
                            Case "A"
                                mGiftCardCount += 1
                                giftCardTotal += CDec(Stadis(4))
                            Case Else
                                ' Keep reload offsets from hitting error routine
                        End Select
                    Else
                        CommonRoutines.BOEdit(fAdapter, itemHandle)
                        CommonRoutines.BODelete(fAdapter, itemHandle)
                        mItemCount -= 1
                        CommonRoutines.BORefreshRecord(fAdapter, 0)
                        MessageBox.Show("Gift cards must be added by using the gift card button.", "STADIS")
                        Return False
                    End If
                End If
                fAdapter.BONext(itemHandle)
            End While

            ' Check tenders
            CommonRoutines.BOOpen(fAdapter, tenderHandle)
            mRProTenderCount = CommonRoutines.BOGetIntAttributeValueByName(fAdapter, tenderHandle, "TENDER_COUNT")
            If mRProTenderCount > 0 Then
                CommonRoutines.BOFirst(fAdapter, tenderHandle)
                While Not fAdapter.EOF(tenderHandle)
                    mTenderCount += 1
                    Dim tenderType As Integer = CommonRoutines.BOGetIntAttributeValueByName(fAdapter, tenderHandle, "TENDER_TYPE")
                    If tenderType = gStadisTenderType Then
                        Dim tender As New TenderInfo(fAdapter, tenderHandle)
                        If tender.IsAStadisTender Then
                            mTransactionShouldBeWritten = True
                            If tender.IsAnOffset Then
                                offsetTotal += CommonRoutines.BOGetDecAttributeValueByName(fAdapter, tenderHandle, "AMT")
                            End If
                            If tender.ShouldBeCharged AndAlso tender.IsAReturn Then
                                mCreditsToProcess = True
                            End If
                        End If
                    End If
                    fAdapter.BONext(tenderHandle)
                End While
            End If

            ' Check to make sure offset equals gift card total
            If gFeeOrTenderForIssueOffset = "Tender" Then
                Select Case giftCardTotal + offsetTotal
                    Case Is > 0
                        ' They inserted a gift card without going through our dialog - should have been caught above
                        MessageBox.Show("Gift card total does not agree with offsetting tender.", "STADIS")
                        Return False
                    Case Is < 0
                        ' They manually deleted a gift card
                        ReduceOffsetAmount(tenderHandle, -(giftCardTotal + offsetTotal))
                    Case Else
                        ' Everything OK - amounts offset
                End Select
            End If

            Return True

        Catch ex As Exception
            MessageBox.Show("020 Error while processing STADIS gift card(s)." & vbCrLf & ex.Message, "STADIS")
            Return False
        End Try
    End Function  'PrepItemsAndTenders

    Private Function IsAGiftCardALU(ByVal alu As String) As Boolean
        For Each gRow As DSGiftCardInfo.GiftCardInfoRow In gGCI.GiftCardInfo.Rows
            If gRow.RProLookupALU = alu Then
                Return True
            End If
        Next
        Return False
    End Function  'IsAGiftCardALU

    Private Function ReduceOffsetAmount(ByVal tenderHandle As Integer, ByVal difference As Decimal) As Boolean
        If mRProTenderCount > 0 Then
            CommonRoutines.BOOpen(fAdapter, tenderHandle)
            CommonRoutines.BOFirst(fAdapter, tenderHandle)
            While Not fAdapter.EOF(tenderHandle)
                Dim tenderType As Integer = CommonRoutines.BOGetIntAttributeValueByName(fAdapter, tenderHandle, "TENDER_TYPE")
                If tenderType = gStadisTenderType Then
                    Dim tender As New TenderInfo(fAdapter, tenderHandle)
                    If tender.IsAnOffset Then
                        Dim offsetAmount As Decimal = CommonRoutines.BOGetDecAttributeValueByName(fAdapter, tenderHandle, "AMT")
                        CommonRoutines.BOEdit(fAdapter, tenderHandle)
                        CommonRoutines.BOSetAttributeValueByName(fAdapter, tenderHandle, "AMT", offsetAmount + difference)
                        CommonRoutines.BOPost(fAdapter, tenderHandle)
                        Exit Function
                    End If
                End If
                fAdapter.BONext(tenderHandle)
            End While
        End If
    End Function  'ReduceOffsetAmount

#Region " Receipt Processing "

    '##############################################################################################
    '                                     RECEIPT PROCESSING
    '##############################################################################################
    ' Identify if we have any Issues, Activates or Reloads to be processed
    '----------------------------------------------------------------------------------------------
    Private Function ProcessReceipt(ByVal invoiceHandle As Integer, ByVal itemHandle As Integer, ByVal tenderHandle As Integer) As Boolean
        Try

            ' Post transaction
            Dim tranKey As Guid = GUID.Empty
            If mGiftCardCount > 0 Then
                tranKey = PostGCPurchase(invoiceHandle, itemHandle, tenderHandle)
                If tranKey = GUID.Empty Then Return False
                UpdateRProItemsAndTendersWithTranKey(tranKey, itemHandle, tenderHandle)
            ElseIf mTransactionShouldBeWritten = True OrElse gPostNonStadisTransactions = True Then
                tranKey = PostTransaction("Receipt", invoiceHandle, itemHandle, tenderHandle)
                If tranKey = GUID.Empty Then Return False
                UpdateRProItemsAndTendersWithTranKey(tranKey, itemHandle, tenderHandle)
            End If

            Return True

        Catch ex As Exception
            MessageBox.Show("015 Error while processing STADIS transaction." & vbCrLf & ex.Message, "STADIS")
            Return False
        End Try
    End Function  'ProcessReceipt

    '----------------------------------------------------------------------------------------------
    ' Construct and do a GCPurchase
    '----------------------------------------------------------------------------------------------
    Private Function PostGCPurchase(ByVal invoiceHandle As Integer, ByVal itemHandle As Integer, ByVal tenderHandle As Integer) As Guid
        Dim sr As New StadisRequest
        With sr
            .SiteID = gSiteID
            .TenderTypeID = 1
            .TenderID = ""
            .Amount = 0D
            .ReferenceNumber = CommonRoutines.BOGetStrAttributeValueByName(fAdapter, invoiceHandle, "Invoice Number")
            '.CustomerID =  
            .VendorID = gVendorID
            .LocationID = gLocationID
            .RegisterID = CommonRoutines.BOGetStrAttributeValueByName(fAdapter, invoiceHandle, "Invoice Workstion")
            .ReceiptID = CommonRoutines.BOGetStrAttributeValueByName(fAdapter, invoiceHandle, "Invoice Number")
            .VendorCashier = CommonRoutines.BOGetStrAttributeValueByName(fAdapter, invoiceHandle, "Cashier")
        End With
        Dim sy As StadisReply = CommonRoutines.StadisAPI.GCPurchase(sr, LoadGiftCardsForWSCall(invoiceHandle, itemHandle), CommonRoutines.LoadHeaderForWSCall(fAdapter, "Receipt", invoiceHandle), CommonRoutines.LoadItemsForWSCall(fAdapter, "Receipt", invoiceHandle, itemHandle), CommonRoutines.LoadTendersForWSCall(fAdapter, "Receipt", invoiceHandle, tenderHandle))
        If sy.ReturnCode < 0 Then
            MsgBox(sy.ReturnMessage, MsgBoxStyle.Critical, "Error in PurchaseGiftCards.")
            Return GUID.Empty
        Else
            Return sy.TransactionKey
        End If
    End Function  'PostGCPurchase

    Private Function LoadGiftCardsForWSCall(ByVal invoiceHandle As Integer, ByVal itemHandle As Integer) As StadisGiftCard()
        Dim mStadisGiftCards(mGiftCardCount - 1) As StadisGiftCard
        Dim indx As Integer = 0
        CommonRoutines.BOOpen(fAdapter, itemHandle)
        CommonRoutines.BOFirst(fAdapter, itemHandle)
        While Not fAdapter.EOF(itemHandle)
            ' Stadis() is used to parse the Stadis info we stored in Item Note1: STADIS\GiftCardID\IorA\CustomerID\Amount
            Dim Stadis() As String = CommonRoutines.BOGetStrAttributeValueByName(fAdapter, itemHandle, "Item Note1").Split("\"c)
            If Stadis(0) = "STADIS" Then
                Dim itemType As String = Stadis(2)
                'If itemType = "I" Then mHasInserts = True
                If itemType = "I" OrElse itemType = "A" Then
                    Dim mStadisGiftCard As New StadisGiftCard
                    With mStadisGiftCard
                        .GiftCardID = Stadis(1)
                        .CustomerID = Stadis(3)
                        .Amount = CDec(Stadis(4))
                        '.Price = 0D
                        .TransactionKey = " "
                    End With
                    mStadisGiftCards(indx) = mStadisGiftCard
                    indx += 1
                End If
            End If
            fAdapter.BONext(itemHandle)
        End While
        Return mStadisGiftCards
    End Function  'LoadGiftCardsForWSCall

    '----------------------------------------------------------------------------------------------
    ' Construct and post Stadis Transaction
    '----------------------------------------------------------------------------------------------
    Private Function PostTransaction(ByVal invoiceType As String, ByVal invoiceHandle As Integer, ByVal itemHandle As Integer, ByVal tenderHandle As Integer) As Guid
        Dim oRequest As New StadisRequest
        With oRequest
            .ReferenceNumber = CommonRoutines.BOGetStrAttributeValueByName(fAdapter, invoiceHandle, "Invoice Number")
            .RegisterID = CommonRoutines.BOGetStrAttributeValueByName(fAdapter, invoiceHandle, "Invoice Workstion")
            .ReceiptID = CommonRoutines.BOGetStrAttributeValueByName(fAdapter, invoiceHandle, "Invoice Number")
            .VendorCashier = CommonRoutines.BOGetStrAttributeValueByName(fAdapter, invoiceHandle, "Cashier")
            .TenderTypeID = 1
            .TenderID = CommonRoutines.BOGetStrAttributeValueByName(fAdapter, tenderHandle, "TRANSACTION_ID")
        End With
        Dim oReply As StadisReply = CommonRoutines.StadisAPI.SVPostTransaction(oRequest, CommonRoutines.LoadHeaderForWSCall(fAdapter, "Receipt", invoiceHandle), CommonRoutines.LoadItemsForWSCall(fAdapter, "Receipt", invoiceHandle, itemHandle), CommonRoutines.LoadTendersForWSCall(fAdapter, "Receipt", invoiceHandle, tenderHandle))
        If oReply.ReturnCode < 0 Then
            MsgBox(oReply.ReturnMessage, MsgBoxStyle.Critical, "Error in PostTransaction.")
            Return GUID.Empty
        Else
            Return oReply.TransactionKey
        End If
    End Function  'PostTransaction

    '----------------------------------------------------------------------------------------------
    ' Write Stadis TransactionKey to Stadis items and tenders
    '----------------------------------------------------------------------------------------------
    Private Sub UpdateRProItemsAndTendersWithTranKey(ByVal trankey As Guid, ByVal itemHandle As Integer, ByVal tenderHandle As Integer)

        'Update items
        CommonRoutines.BOOpen(fAdapter, itemHandle)
        CommonRoutines.BOFirst(fAdapter, itemHandle)
        While Not fAdapter.EOF(itemHandle)
            Dim stadisString As String = CommonRoutines.BOGetStrAttributeValueByName(fAdapter, itemHandle, "Item Note1")
            Dim Stadis() As String = stadisString.Split("\"c)
            If Stadis(0) = "STADIS" Then
                Dim newStadisString As String = stadisString & "\" & trankey.ToString
                CommonRoutines.BOEdit(fAdapter, itemHandle)
                CommonRoutines.BOSetAttributeValueByName(fAdapter, itemHandle, "Item Note1", newStadisString)
                CommonRoutines.BOPost(fAdapter, itemHandle)
            End If
            fAdapter.BONext(itemHandle)
        End While

        'Update tenders
        If mRProTenderCount > 0 Then
            CommonRoutines.BOOpen(fAdapter, tenderHandle)
            CommonRoutines.BOFirst(fAdapter, tenderHandle)
            While Not fAdapter.EOF(tenderHandle)
                Dim tenderType As Integer = CommonRoutines.BOGetIntAttributeValueByName(fAdapter, tenderHandle, "TENDER_TYPE")
                If tenderType = gStadisTenderType Then
                    Dim tender As New TenderInfo(fAdapter, tenderHandle)
                    If tender.IsAStadisTender Then
                        CommonRoutines.BOEdit(fAdapter, tenderHandle)
                        CommonRoutines.BOSetAttributeValueByName(fAdapter, tenderHandle, "MANUAL_REMARK", tender.StadisOpCode & "\" & trankey.ToString)
                        CommonRoutines.BOPost(fAdapter, tenderHandle)
                    End If
                End If
                fAdapter.BONext(tenderHandle)
            End While
        End If

    End Sub  'UpdateRProItemsAndTendersWithTranKey

#End Region  'Receipt Processing

#Region " Return Processing "

    '##############################################################################################
    '                                       RETURN PROCESSING
    '##############################################################################################
    ' If a return is being processed - positive in RPro, negative in Stadis
    '----------------------------------------------------------------------------------------------
    Private Function ProcessReturn(ByVal invoiceHandle As Integer, ByVal itemHandle As Integer, ByVal tenderHandle As Integer) As Boolean
        Try
            ' Post transaction
            Dim tranKey As Guid = GUID.Empty
            If mCreditsToProcess = True Then
                ' Post transaction
                tranKey = PostTransaction("Return", invoiceHandle, itemHandle, tenderHandle)
                If tranKey = GUID.Empty Then Return False
                UpdateRProItemsAndTendersWithTranKey(tranKey, itemHandle, tenderHandle)
            ElseIf gIssueGiftCardForReturn = True Then
                tranKey = PostGCPurchase(invoiceHandle, itemHandle, tenderHandle)
                If tranKey = GUID.Empty Then Return False
                UpdateRProItemsAndTendersWithTranKey(tranKey, itemHandle, tenderHandle)
            ElseIf gPostNonStadisTransactions = True Then
                tranKey = PostTransaction("Return", invoiceHandle, itemHandle, tenderHandle)
                If tranKey = GUID.Empty Then Return False
                UpdateRProItemsAndTendersWithTranKey(tranKey, itemHandle, tenderHandle)
            End If
            Return True
        Catch ex As Exception
            MessageBox.Show("010 Error while processing STADIS transaction." & vbCrLf & ex.Message, "STADIS")
            Return False
        End Try
    End Function  'ProcessReturn

#End Region  'Return Processing

End Class  'PrintUpdateStadisProcessing
