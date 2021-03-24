Imports StadisIntegratePlugin.WebReference
Imports System
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
'----------------------------------------------------------------------------------------------
'   Class: TenderDialogue2
'    Type: Tender 
' Purpose: Called when tender button is pressed on tender screen. 
' Tappit
'----------------------------------------------------------------------------------------------
<GuidAttribute(Discover.CLASS_TenderDialogue2)>
Public Class TenderDialogue2
    Inherits TCustomTenderDialoguePlugin

    Private Declare Function GetCurrentProcessId Lib "kernel32" () As Integer


    '----------------------------------------------------------------------------------------------
    ' Called during discovery
    ' Called when Sales/Receipts selected from menu (1)
    '----------------------------------------------------------------------------------------------


    Public Overrides Sub Initialize()
        'get licensing information after fadapter has been instantiated
        'it is not yet instantiated during discovery
        'but is instantiated when sales/receipts is selected
        MyBase.Initialize()

        fBusinessObjectType = Plugins.BusinessObjectType.btInvoice
        fDescription = "Tappit tender dialog"
        fGUID = New Guid(Discover.CLASS_TenderDialogue2)
        fTenderType = gTappitTenderDialogTenderType

        fUseDefaultDialog = True 'Overridden in prepare
        'fEFTForced = True


    End Sub  'Initialize
    Public Overrides Function PluginCapability(ACapability As Integer) As Boolean
        'F R E D All this does not seem to work to enable eftdata fields, which it should.... ????
        Select Case ACapability
            Case 0 'constant tdcUseDefaultDialog - conserves behavior of fUseDefaultDialog
                Return True
            Case 1 'constant tdcAcceptsDATAvalues - MUST include this capability for EFTdata to work
                Return True
            Case Else
                'Return MyBase.PluginCapability(ACapability)
                Return True
        End Select
    End Function

    '----------------------------------------------------------------------------------------------
    ' Called when Sales/Receipts selected from menu (2)
    '----------------------------------------------------------------------------------------------
    Public Overrides Function Prepare() As Boolean

        If gRPROUID = "" Then
            gRPROUID = fAdapter.GetPrimaryID
            'MsgBox("TenderDialog prepare calling common.LoadLicenses")
            Common.LoadLicenses()
            'MsgBox("common.LoadLicenses was called")

        End If

        'UseDefaultDialog = False
        UseDefaultDialog = Not (gTappitEnabled)

        Return MyBase.Prepare()
    End Function  'Prepare

    '----------------------------------------------------------------------------------------------
    ' Called when button is pressed (1)
    '----------------------------------------------------------------------------------------------
    Public Overrides Sub Clear()
        MyBase.Clear()
    End Sub  'Clear

    '----------------------------------------------------------------------------------------------
    ' Called when button is pressed (2)
    '----------------------------------------------------------------------------------------------
    Public Overrides Function HandleEvent() As Boolean

        Dim decAmount As Decimal = 0
        Dim decTotal As Decimal = 0
        Dim decAmtDue As Decimal = 0
        Dim intInvoiceType As Integer = 0

        If fAmount = 0 Then
            MsgBox("There is no amount to apply to Tappit!")
            Return False
            Exit Function
        End If

        'If fAmount < 0 Then
        ' MsgBox("Refund onto Tappit is not allowed!")
        ' Return False
        ' Exit Function
        ' End If

        Dim blnTestMode As Boolean = False

        If gTappitEnabled = False Then
            Return MyBase.HandleEvent()
            Exit Function
        End If

        Dim blnTenderPresent As Boolean = False
        Dim intTenderHandle As Integer = 0
        Dim intResult As Integer = 0
        Dim intItemsHandle As Integer = 0

        'Dim blnNonPositiveQty As Boolean = False

        Dim blnHasBothPositiveAndNegativeQty As Boolean = False
        Dim blnHasPositiveQty As Boolean = False
        Dim blnHasNegativeQty As Boolean = False

        Dim decQty As Decimal = 0

        Try

            '*** get a result -1 if bofirst hits a record (meaning there is at least 1 record)
            'get a result -1 if bolast hits a record (meaning there is at least 1 record)
            'get a result if -1 if bonext increments to a record
            intTenderHandle = fAdapter.GetReferenceBOForAttribute(0, "Tenders")
            intResult = fAdapter.BOFirst(intTenderHandle)
            If intResult = -1 Then blnTenderPresent = True

        Catch ex As Exception
            MsgBox("Exception determining tender count - contact support if needed")
        End Try

        If blnTenderPresent = True Then
            MsgBox("When using " & gTappitTenderDialogFormText & vbCrLf &
                   "it must be the one" & vbCrLf &
                   "and only tender.", MsgBoxStyle.Exclamation, gTappitTenderDialogFormText)
            Return False
            Exit Function
        End If

        Try

            intItemsHandle = fAdapter.GetReferenceBOForAttribute(0, "Items")
            fAdapter.BOFirst(intItemsHandle)

            blnHasPositiveQty = False
            blnHasNegativeQty = False

            While Not fAdapter.EOF(intItemsHandle)
                'minimize actual reading for speed
                If blnHasNegativeQty = False Then
                    decQty = CDec(fAdapter.BOGetAttributeValueByName(intItemsHandle, "Qty"))
                    If decQty < 0 Then
                        blnHasNegativeQty = True
                    End If
                    If decQty > 0 Then blnHasPositiveQty = True
                End If
                If blnHasPositiveQty = False Then
                    decQty = CDec(fAdapter.BOGetAttributeValueByName(intItemsHandle, "Qty"))
                    If decQty < 0 Then
                        blnHasNegativeQty = True
                    End If
                    If decQty > 0 Then blnHasPositiveQty = True
                End If
                fAdapter.BONext(intItemsHandle)
            End While

        Catch ex As Exception
            MsgBox("Exception determining if there are non positive item quantities- contact support if needed")
        End Try

        blnHasBothPositiveAndNegativeQty = False
        If blnHasPositiveQty = True Then
            If blnHasNegativeQty = True Then
                blnHasBothPositiveAndNegativeQty = True 'an exchange
            End If
        End If

        If blnHasBothPositiveAndNegativeQty = True Then
            MsgBox("When using " & gTappitTenderDialogFormText & vbCrLf &
                   "exchange is not allowed!", MsgBoxStyle.Exclamation, gTappitTenderDialogFormText)
            Return False
            Exit Function
        End If

        Dim mFrmTappitCharge As New FrmTappitCharge
        With mFrmTappitCharge
            .Adapter = fAdapter
            .ParentDialog = Me
        End With

        gTappitApprovedTenderAmount = 0

        If blnTestMode = True Then MsgBox("TenderDialog2.HandleEvent FrmTappitCharge ShowDialog")

        Select Case mFrmTappitCharge.ShowDialog()
            Case Windows.Forms.DialogResult.OK


                fAmount = Math.Round(gTappitApprovedTenderAmount, 2, MidpointRounding.AwayFromZero)

                intInvoiceType = CInt(fAdapter.BOGetAttributeValueByName(0, "Invoice Type"))

                decAmount = Math.Round(gTappitApprovedTenderAmount, 2, MidpointRounding.AwayFromZero)
                If intInvoiceType <> 0 Then
                    decAmount = decAmount * -1

                End If


                decTotal = CDec(fAdapter.BOGetAttributeValueByName(0, "Invc Total"))

                If decAmount = decTotal Then
                    Common.PressF12()
                    Return True
                End If

                decAmtDue = decTotal - decAmount

                If decAmount <> decTotal Then

                    If Math.Abs((decAmount + gTappitComplimentaryUsageTotal - decTotal)) > 0.02 Then
                        MsgBox("The Tappit charge had a large variance from the total.  Please report this to the system administrator.")
                    End If

                    'gTappitComplimentaryUsageTotal = gTappitComplimentaryUsageTotal + decAmtDue

                    fAdapter.BOSetAttributeValueByName(0, "Transaction Discount", decAmtDue)
                    Common.PressF12()
                    Return True
                End If

            Case Windows.Forms.DialogResult.Cancel
                Return False
        End Select
        mFrmTappitCharge = Nothing

        If blnTestMode = True Then MsgBox("TenderDialog2.HandleEvent returning HandleEvent")
        Return MyBase.HandleEvent()

    End Function  'HandleEvent

    '----------------------------------------------------------------------------------------------
    ' Called when deleting
    '----------------------------------------------------------------------------------------------
    Public Overrides Function DeleteTender() As Boolean

        If gTappitEnabled = False Then
            Return MyBase.DeleteTender()
            Exit Function
        End If

        If fTenderType = gTappitTenderDialogTenderType Then

            MsgBox("Deleting a recorded Tappit tender is not allowed")
            Return False
            Exit Function


            Dim strTappitQRCode As String
            Dim mReturnCode As Integer = -99
            Dim mReturnMessage As String = ""
            Dim mReturnComment As String = ""

            strTappitQRCode = Trim(InputBox("Scan QR Code"))
            If strTappitQRCode = "" Then
                Return False
                Exit Function
            End If

            Try

                Dim strUniqueID = Common.Unique16CharString()
                Dim sr As New StadisIntegratePlugin.WebReference.StadisRequest
                With sr
                    .ReferenceNumber = strUniqueID
                    .ReceiptID = gTappitCurrentDocumentUniqueID
                    .TenderID = strTappitQRCode
                    .RegisterID = Common.BOGetStrAttributeValueByName(fAdapter, 0, "Invoice Workstion")
                    .LocationID = Common.BOGetStrAttributeValueByName(fAdapter, 0, "Store Code")
                End With

                Dim sys As StadisIntegratePlugin.WebReference.StadisReply() = Nothing


                Try
                    sys = TappitAPI.Tappit_POS_Refund(sr)
                    mReturnComment = sys(0).Comment
                    mReturnCode = sys(0).ReturnCode
                    mReturnMessage = sys(0).ReturnMessage
                Catch ex As Exception
                    MsgBox("Unable to process deleting this tender!")
                    Return False
                    Exit Function
                End Try

                If mReturnCode <> 200 Then
                    MsgBox("Unable to process deleting this tender!")
                    Return False
                    Exit Function
                End If

                Select Case (sys(0).ReturnCode)
                    Case 200
                        Return True
                        Exit Function
                    Case Else
                        MsgBox("Unable to process deleting this tender!")
                        Return False
                        Exit Function
                End Select
            Catch ex As Exception
                MsgBox("Unable to process deleting this tender!")
                Return False
                Exit Function
            End Try


            'MsgBox(gTappitTenderDialogFormText & " cannot be deleted.  The card has already been charged.  You must process a refund on a different document to reverse this sale!")
            'Return False
        End If
    End Function  'DeleteTender

    '----------------------------------------------------------------------------------------------
    ' Called when RPro is shut down
    '----------------------------------------------------------------------------------------------
    Public Overrides Sub Cleanup()
        fBusinessObjectType = Nothing
        fDescription = Nothing
        fGUID = Nothing
        fTenderType = Nothing
        fUseDefaultDialog = Nothing
        MyBase.CleanUp()
    End Sub  'Cleanup

End Class  'TenderDialogue

