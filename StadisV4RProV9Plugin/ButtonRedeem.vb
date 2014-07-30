Imports CommonV4
Imports CommonV4.WebReference
Imports RetailPro.CustomPluginClasses
Imports RetailPro.Plugins
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
'----------------------------------------------------------------------------------------------
'   Class: ButtonRedeem
'    Type: SideButton - Tender
' Purpose: Invokes FrmRedeem to collect tender information
'          During initialization, loads installation settings and WS settings
'----------------------------------------------------------------------------------------------
<GuidAttribute(Discover.CLASS_ButtonRedeem)> _
Public Class ButtonRedeem
    Inherits TCustomSideButtonPlugin

    '----------------------------------------------------------------------------------------------
    ' Called when plugin is loaded
    '----------------------------------------------------------------------------------------------
    Public Overrides Sub Initialize()
        MyBase.Initialize()

        LoadSettings()
        'MessageBox.Show("Hey there.", "STADIS")

        fButtonEnabled = gRedeemButtonEnabled
        fHint = gRedeemButtonHint
        If gRedeemButtonEnabled = True Then
            fCaption = gRedeemButtonCaption
        Else
            fCaption = "Disabled"
        End If
        fPictureFilename = gRedeemButtonImage
        fLayoutActionName = "actStadisRedeemButton"
        fChecked = True
        fEnabled = gRedeemButtonEnabled
        fGUID = New Guid(Discover.CLASS_ButtonRedeem)
        fBusinessObjectType = RetailPro.Plugins.BusinessObjectType.btInvoice
    End Sub  'Initialize

    '----------------------------------------------------------------------------------------------
    ' Called when button is clicked
    '----------------------------------------------------------------------------------------------
    Public Overrides Function HandleEvent() As Boolean
        If gRedeemButtonActive = True Then
            Dim mFrmRedeem As New FrmRedeem
            mFrmRedeem.Adapter = fAdapter
            mFrmRedeem.ShowDialog()
            mFrmRedeem = Nothing
        End If
        Return MyBase.HandleEvent()
    End Function  'HandleEvent

    '----------------------------------------------------------------------------------------------
    ' Enables/disables button based on Receipt Type
    '----------------------------------------------------------------------------------------------
    Public Overrides ReadOnly Property ButtonEnabled() As Boolean
        Get
            Try
                If CInt(fAdapter.BOGetAttributeValueByName(0, "Invoice Type")) = 0 Then
                    fEnabled = True
                    gIsAReturn = False
                Else
                    fEnabled = False
                    gIsAReturn = True
                End If
            Catch ex As Exception

            End Try
            Return MyBase.Enabled
        End Get
    End Property

    '----------------------------------------------------------------------------------------------
    ' Get site and WS configuration settings
    '----------------------------------------------------------------------------------------------
    Friend Sub LoadSettings()

        If gFirstTimeThrough = False Then Exit Sub
        gFirstTimeThrough = False

        ' Get WS settings
        gStadisWebServiceURL = My.Settings.StadisWebServiceURL
        gOverrideSettingComponent = My.Settings.OverrideSettingID
        gStadisUserID = My.Settings.StadisUserID
        gStadisPassword = My.Settings.StadisPassword
        gLog = My.Settings.Log
        gNetworkChecking = My.Settings.NetworkChecking
        gOPOSPrinterName = My.Settings.OPOSPrinterName
        gRasterPrinterName = My.Settings.RasterPrinterName
        gWindowsPrinterName = My.Settings.WindowsPrinterName

        Try
            ' Get installation settings - standard first, then overrides, if any
            Dim mis As MessageAndInstallationSettings = CommonRoutines.StadisAPI.GetInstallationSettings("All")
            SetSettingsFor(mis, "RPro9WS")
            If gOverrideSettingComponent <> "" Then
                SetSettingsFor(mis, gOverrideSettingComponent)
            End If
        Catch ex As Exception
            gBalChkButtonActive = False
            gIssueButtonActive = False
            gRedeemButtonActive = False
            gReturnButtonActive = False
            gReloadButtonActive = False
            gBalChkButtonEnabled = False
            gIssueButtonEnabled = False
            gRedeemButtonEnabled = False
            gReturnButtonEnabled = False
            gReloadButtonEnabled = False
            MessageBox.Show("Unable to access InstallationSettings.", "STADIS")
            Exit Sub
        End Try

        Try
            ' Get Gift Card table
            Dim msis As MessageAndSaleItems = CommonRoutines.StadisAPI.GetSaleItemsForRPro(gVendorID)
            If msis.ReturnMessage.ReturnCode < 0 Then
                MessageBox.Show("Unable to load gift card specifications.", "STADIS")
                gIssueButtonActive = False
            End If
            Dim gcis As SaleItem() = msis.SaleItems
            For i As Integer = 0 To gcis.Length - 1
                Dim gci As DSGiftCardInfo.GiftCardInfoRow = CType(gGCI.GiftCardInfo.NewRow, DSGiftCardInfo.GiftCardInfoRow)
                gci.GiftCardInfoID = gcis(i).SaleItemID
                gci.GiftCardName = gcis(i).Description
                gci.RProLookupALU = gcis(i).RProLookupALU
                gci.EventID = gcis(i).EventID
                gci.ButtonPosition = gcis(i).ButtonOrderRPro
                gci.ButtonCaption = gcis(i).ButtonCaption
                gci.DropdownCaption = gcis(i).DropdownCaption
                gci.ReceiptCaption = gcis(i).ReceiptCaption
                gci.FixedOrVariable = gcis(i).FixedOrVariable
                gci.AllowIssue = gcis(i).IsIssueAllowed
                gci.AllowActivate = gcis(i).IsActivateAllowed
                gci.IAMinAmount = gcis(i).IAMinAmount
                gci.IAMaxAmount = gcis(i).IAMAxAmount
                gci.AllowReload = gcis(i).IsReloadAllowed
                gci.RMinAmount = gcis(i).RMinAmount
                gci.RMaxAmount = gcis(i).RMAxAmount
                gGCI.GiftCardInfo.Rows.Add(gci)
            Next

            ' Derived settings
            gGiftCardEvent = Split(gGiftCardEvents, ";")
            Select Case gTenderTypeForStadis
                Case "GiftCard"
                    gStadisTenderType = RetailPro.Plugins.TenderTypes.ttGiftCard
                Case "ForeignCheck"
                    gStadisTenderType = RetailPro.Plugins.TenderTypes.ttForeignCheck
                Case "Check"
                    gStadisTenderType = RetailPro.Plugins.TenderTypes.ttCheck
            End Select

        Catch ex As Exception
            gBalChkButtonActive = False
            gIssueButtonActive = False
            gRedeemButtonActive = False
            gReturnButtonActive = False
            gReloadButtonActive = False
            gBalChkButtonEnabled = False
            gIssueButtonEnabled = False
            gRedeemButtonEnabled = False
            gReturnButtonEnabled = False
            gReloadButtonEnabled = False
            MessageBox.Show("Error loading Gift Card table." & vbCrLf & ex.Message, "STADIS")
        End Try

    End Sub  'LoadSettings

    Private Sub SetSettingsFor(ByRef mis As MessageAndInstallationSettings, ByVal setComponentName As String)
        For Each setting As InstallationSetting In mis.InstallationSettings
            With setting
                Select Case .ComponentName
                    Case "Site"
                        Select Case .SettingName
                            Case "StadisVersion"
                                gStadisVersion = .SettingValue
                            Case "StadisRelease"
                                gStadisRelease = .SettingValue
                            Case "SiteSVType"
                                gSiteSVType = .SettingValue
                        End Select
                    Case setComponentName
                        Select Case .SettingName
                            Case "TenderTypeForStadis"
                                gTenderTypeForStadis = .SettingValue
                            Case "FeeOrTenderForIssueOffset"
                                gFeeOrTenderForIssueOffset = .SettingValue
                            Case "VendorID"
                                gVendorID = .SettingValue
                            Case "FormLogoImage"
                                gFormLogoImage = .SettingValue
                            Case "ImageTransparentColor"
                                Try
                                    Dim rgb() As String = .SettingValue.Split(","c)
                                    If rgb.Count = 3 Then
                                        gImageTransparentColor = Drawing.Color.FromArgb(CInt(rgb(0)), CInt(rgb(1)), CInt(rgb(2)))
                                    End If
                                Catch ex As Exception

                                End Try
                            Case "AskForTicketOnRedeem"
                                gAskForTicketOnRedeem = CBool(.SettingValue)
                            Case "AskForTicketOnIssue"
                                gAskForTicketOnIssue = CBool(.SettingValue)
                            Case "DefaultCustomerID"
                                gDefaultCustomerID = .SettingValue
                            Case "AllowReturnCreditToCard"
                                gAllowReturnCreditToCard = CBool(.SettingValue)
                            Case "PostNonStadisTransactions"
                                gPostNonStadisTransactions = CBool(.SettingValue)
                            Case "ScanPattern"
                                gScanPattern = .SettingValue
                            Case "GiftCardEvents"
                                gGiftCardEvents = .SettingValue
                            Case "IssueGiftCardForReturn"
                                gIssueGiftCardForReturn = CBool(.SettingValue)
                            Case "IsPrintingEnabled"
                                gIsPrintingEnabled = CBool(.SettingValue)
                            Case "StadisTenderText"
                                gSTADISTenderText = .SettingValue
                            Case "IsMergeFunctionEnabled"
                                gIsMergeFunctionEnabled = CBool(.SettingValue)
                            Case "ShowSVActionGrid"
                                gShowSVActionGrid = CBool(.SettingValue)

                            Case "BalChkButtonActive"
                                gBalChkButtonActive = CBool(.SettingValue)
                                If gBalChkButtonActive = True Then
                                    gBalChkButtonEnabled = True
                                Else
                                    gBalChkButtonEnabled = False
                                End If
                            Case "BalChkButtonCaption"
                                gBalChkButtonCaption = .SettingValue
                            Case "BalChkButtonImage"
                                gBalChkButtonImage = .SettingValue
                            Case "BalChkButtonHint"
                                gBalChkButtonHint = .SettingValue

                            Case "IssueButtonActive"
                                gIssueButtonActive = CBool(.SettingValue)
                                If gIssueButtonActive = True Then
                                    gIssueButtonEnabled = True
                                Else
                                    gIssueButtonEnabled = False
                                End If
                            Case "IssueButtonEnabled"
                                gIssueButtonEnabled = CBool(.SettingValue)
                            Case "IssueButtonCaption"
                                gIssueButtonCaption = .SettingValue
                            Case "IssueButtonImage"
                                gIssueButtonImage = .SettingValue
                            Case "IssueButtonHint"
                                gIssueButtonHint = .SettingValue

                            Case "RedeemButtonActive"
                                gRedeemButtonActive = CBool(.SettingValue)
                                If gRedeemButtonActive = True Then
                                    gRedeemButtonEnabled = True
                                Else
                                    gRedeemButtonEnabled = False
                                End If
                            Case "RedeemSideButtonEnabled"
                                gRedeemButtonEnabled = CBool(.SettingValue)
                            Case "RedeemButtonCaption"
                                gRedeemButtonCaption = .SettingValue
                            Case "RedeemButtonImage"
                                gRedeemButtonImage = .SettingValue
                            Case "RedeemButtonHint"
                                gRedeemButtonHint = .SettingValue

                            Case "ReturnButtonActive"
                                gReturnButtonActive = CBool(.SettingValue)
                                gReturnButtonEnabled = False
                            Case "ReturnButtonEnabled"
                                gReturnButtonEnabled = CBool(.SettingValue)
                            Case "ReturnButtonCaption"
                                gReturnButtonCaption = .SettingValue
                            Case "ReturnButtonImage"
                                gReturnButtonImage = .SettingValue
                            Case "ReturnButtonHint"
                                gReturnButtonHint = .SettingValue

                            Case "ReloadButtonActive"
                                gReloadButtonActive = CBool(.SettingValue)
                                If gReloadButtonActive = True Then
                                    gReloadButtonEnabled = True
                                Else
                                    gReloadButtonEnabled = False
                                End If
                            Case "ReloadButtonEnabled"
                                gReloadButtonEnabled = CBool(.SettingValue)
                            Case "ReloadButtonCaption"
                                gReloadButtonCaption = .SettingValue
                            Case "ReloadButtonImage"
                                gReloadButtonImage = .SettingValue
                            Case "ReloadButtonHint"
                                gReloadButtonHint = .SettingValue

                        End Select
                End Select
            End With
        Next
    End Sub  'SetSettingsFor

End Class  'ButtonRedeem
