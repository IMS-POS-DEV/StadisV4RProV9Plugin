Imports StadisIntegratePlugin.WebReference
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports System.Configuration.ConfigurationManager
Imports System.IO 'required for Unique16CharString


'----------------------------------------------------------------------------------------------
'   Class: Common
'    Type: Common subroutines
' Purpose: Subroutines called from more than one class
'----------------------------------------------------------------------------------------------
Public Class Common

#Region " Methods "

    Public Shared Sub PressF12()

        'Requires PressF12.exe in the plugins folder

        Try
            Dim intProcID As Integer = Process.GetCurrentProcess.Id
            Dim intMicrosecondsDelay As Integer = 1000

            Dim strTemp = System.Reflection.Assembly.GetExecutingAssembly.Location()
            strTemp = Path.GetDirectoryName(strTemp)
            If InStr(UCase(strTemp), "PLUGINS") = 0 Then strTemp = strTemp & "\plugins" 'compiler adjusted case
            strTemp = strTemp & "\PressF12.exe"

            Dim processinfoCommand As New ProcessStartInfo
            processinfoCommand.FileName = strTemp
            processinfoCommand.Arguments = CStr(intMicrosecondsDelay) & " " & CStr(intProcID)
            processinfoCommand.UseShellExecute = True
            processinfoCommand.WindowStyle = ProcessWindowStyle.Normal
            Dim objProc As Process = Process.Start(processinfoCommand)
        Catch ex As Exception
            MsgBox("Exception trying to initiate process to print/update - possibly missing PressF12 in the plugins folder")
        End Try

    End Sub

    '----------------------------------------------------------------------------------------------
    ' Provides access to web service; creates connection if it doesn't exist
    '----------------------------------------------------------------------------------------------
    Private Shared mService As StadisIntegratePlugin.WebReference.StadisV4TransactionsService
    Public Shared Function StadisAPI() As StadisIntegratePlugin.WebReference.StadisV4TransactionsService
        'MsgBox("calling stadisapi")
        'Note from F r e d regarding info from Stack Overflow that was found when researching possible timeout options.

        'From Stack Overflow "Increase timeout when consumed as web reference (not service reference)"
        'When consumed, the third-party web service client class GetData() Is forced to derive from SoapHttpClientProtocol. This class derives from HttpWebClientProtocol, derived from WebClientProtocol.
        'WebClientProtocol has a Public Property Timeout, expressed in milliseconds.
        'Indicates the time an XML Web service client waits for the reply to a synchronous XML Web service request to arrive (in milliseconds).
        'The time out, in milliseconds, for synchronous calls to the XML Web service. The default Is 100000 milliseconds.
        'Setting the Timeout Property To Timeout.Infinite indicates that the request does Not time out. Even though an XML Web service client can Set the Timeout Property To Not time out, the Web server can still cause the request to time out on the server side.
        'Therefore the Timeout Property Is available directly from code When instantiated As a web service client, which I believe Is due to the magic of VS
        'SomeComsumedWebService wsc = New SomeComsumedWebService();
        'SomeComsumedWebService.Timeout = 600000; // 10 minutes
        'var obj = SomeComsumedWebService.MethodToGetData();

        If mService Is Nothing Then
            ' Create the web service proxy
            mService = New StadisIntegratePlugin.WebReference.StadisV4TransactionsService
            ' Create the security credentials
            Dim cred As New StadisIntegratePlugin.WebReference.SecurityCredentials With {.UserID = gStadisUserID, .Password = gStadisPassword}
            ' Provide the credentials to the service proxy
            mService.SecurityCredentialsValue = cred
            mService.Url = gStadisV4WebServiceURL

        End If
        'Provide the service proxy for use

        Return mService
    End Function  'StadisAPI
    Private Function GetAppPath() As String


        Return AppDomain.CurrentDomain.BaseDirectory

        Dim l_intCharPos As Integer = 0, l_intReturnPos As Integer
        Dim l_strAppPath As String

        l_strAppPath = System.Reflection.Assembly.GetExecutingAssembly.Location()

        While (1 = 1)
            l_intCharPos = InStr(l_intCharPos + 1, l_strAppPath, "\", CompareMethod.Text)
            If l_intCharPos = 0 Then
                If Right(Mid(l_strAppPath, 1, l_intReturnPos), 1) <> "\" Then
                    Return Mid(l_strAppPath, 1, l_intReturnPos) & "\"
                Else
                    Return Mid(l_strAppPath, 1, l_intReturnPos)
                End If
                Exit Function
            End If
            l_intReturnPos = l_intCharPos
        End While
    End Function
    Public Shared Sub Reset()
        mService = Nothing
    End Sub  'Reset


    '------------------------------------------------------------------------------------
    ' Gets a 16 character unique string using getrandomfilename
    ' Requires system.io
    '------------------------------------------------------------------------------------

    Public Shared Function Unique16CharString() As String
        Dim strPath1 As String = "0"
        While InStr(strPath1, "0") <> 0 Or InStr(strPath1, "O") <> 0
            strPath1 = UCase(Path.GetRandomFileName().Substring(0, 8))
        End While
        Dim strPath2 As String = "0"
        While InStr(strPath2, "0") <> 0 Or InStr(strPath2, "O") <> 0
            strPath2 = UCase(Path.GetRandomFileName().Substring(0, 8))
        End While
        Dim strFull16 As String = strPath1 & strPath2
        Return strFull16
    End Function
    '------------------------------------------------------------------------------------
    ' Converts a V8/V9 Retail Pro 64 bit signed integer SID into a 16 character alpha SID
    '------------------------------------------------------------------------------------

    Public Shared Function GetStringSID(ByVal int64SID As Int64) As String
        'F r e d May 2020 07 23
        Dim strSID As String = ""
        Dim i As Integer
        Dim bytearrayTemp As Byte() = BitConverter.GetBytes(int64SID)
        For i = 0 To 7
            strSID = strSID & Chr(CInt(Int(bytearrayTemp(i) / 16)) + Asc("A")) & Chr(bytearrayTemp(i) Mod 16 + Asc("A"))
        Next
        Return strSID
    End Function

    '------------------------------------------------------------------------------
    ' Converts a V8/V9 string representation of a Retail Pro SID into an int64 SID
    '------------------------------------------------------------------------------
    Public Shared Function GetInt64SID(ByVal strSID As String) As Int64
        'F r e d May 2020 07 23
        Dim int64SID As Int64 = 0
        Dim bytearrayTemp As Byte() = BitConverter.GetBytes(int64SID)
        Dim intTempA As Integer
        Dim intTempB As Integer
        Dim i As Integer
        For i = 15 To 0 Step -2
            intTempA = Asc(strSID.Chars(i - 1)) - Asc("A")
            intTempB = Asc(strSID.Chars(i)) - Asc("A")
            int64SID += intTempA
            int64SID <<= 4
            int64SID += intTempB
            If i > 2 Then int64SID <<= 4
        Next
        Return int64SID
    End Function





    '------------------------------------------------------------------------------
    ' Returns ReceiptID: RegisterID followed by seconds since start of current year
    '------------------------------------------------------------------------------
    Public Shared Function GetReceiptID(ByVal RegisterID As String) As String
        Dim dateNow As DateTime = Date.Now
        Dim yyyy As Integer = dateNow.Year
        Dim addYears As Integer = yyyy - 2001
        Dim centuryBegin As DateTime = #1/1/2001#
        Dim yearBegin As Date = centuryBegin.AddYears(addYears)
        Dim elapsedTicks As Long = dateNow.Ticks - yearBegin.Ticks
        Dim elapsedSpan As New TimeSpan(elapsedTicks)
        Dim elapsedDec As Decimal = CDec(elapsedSpan.TotalSeconds)
        Return RegisterID & CStr(Decimal.Round(elapsedDec, 0))
    End Function  'GetReceiptID

    '------------------------------------------------------------------------------
    ' Checks tender EventID against list from configuration settings
    '------------------------------------------------------------------------------
    Public Shared Function IsAGiftCard(ByVal eventID As String) As Boolean
        Dim mIsGiftCard As Boolean = False
        For i As Integer = 0 To gGiftCardEvent.Length - 1
            If eventID = gGiftCardEvent(i) Then
                mIsGiftCard = True
            End If
        Next
        Return mIsGiftCard
    End Function  'IsAGiftCard

    '------------------------------------------------------------------------------
    ' Strip out barcode from scanner input 
    '------------------------------------------------------------------------------
    Public Shared Function ExtractScan(ByVal scanstring As String) As String
        Dim extract As String = Regex.Match(scanstring, gExtractPattern).ToString
        If extract Is Nothing OrElse extract = "" Then
            Return scanstring
        Else
            Return extract
        End If
    End Function  'ExtractScan

    '------------------------------------------------------------------------------
    ' Validate barcode length, number ranges etc., using regex pattern from config
    '------------------------------------------------------------------------------
    Public Shared Function ValidateScan(ByVal scanInput As String) As Boolean

        Return Regex.IsMatch(scanInput, gValidatePattern)
    End Function  'ValidateScan


    '------------------------------------------------------------------------------
    ' Reverse an SVAccountCharge
    '------------------------------------------------------------------------------
    Public Shared Function DoSVAccountReverse(ByRef fAdapter As Plugins.IPluginAdapter, ByVal AuthID As String) As Boolean
        If AuthID = gLastAuthID Then
            Return False
        End If
        Dim invoiceHandle As Integer = 0
        Dim sr As New StadisIntegratePlugin.WebReference.StadisRequest
        With sr
            .SiteID = gSiteID
            .StadisAuthorizationID = AuthID
            .VendorID = gVendorID
            .LocationID = gLocationID
            .RegisterID = Common.BOGetStrAttributeValueByName(fAdapter, invoiceHandle, "Invoice Workstion")
            .ReceiptID = Common.BOGetStrAttributeValueByName(fAdapter, invoiceHandle, "Invoice Number")
            .VendorCashier = Common.BOGetStrAttributeValueByName(fAdapter, invoiceHandle, "Cashier")
        End With
        Dim sys As StadisIntegratePlugin.WebReference.StadisReply() = Common.StadisAPI.SVAccountReverse(sr)
        Dim hasBadReply As Boolean = False
        For Each sy As StadisIntegratePlugin.WebReference.StadisReply In sys
            If sy.ReturnCode < 0 Then
                hasBadReply = True
                'LogStadisEvent(Guid.Empty, "Reverse Charge", "DoReverse", "A", sy.ReturnCode, "Unable to reverse charge for StadisAuthorizationID", "", "", "StadisAuthorizationID = " & sy.StadisAuthorizationID)
            End If
        Next
        If hasBadReply = True Then
            MsgBox("Unable to reverse charge for StadisAuthorizationID " & AuthID, MsgBoxStyle.Exclamation, "Reverse Charge")
            Return False
        Else
            gLastAuthID = AuthID
            Return True
        End If
    End Function  'DoSVAccountReverse

    '------------------------------------------------------------------------------
    ' Reverse an SVAccountCharge
    '------------------------------------------------------------------------------
    Public Shared Function DoSVReverseTransaction(ByRef fAdapter As Plugins.IPluginAdapter, ByVal TranKey As String) As Boolean
        Dim invoiceHandle As Integer = 0
        Dim sr As New StadisIntegratePlugin.WebReference.StadisRequest
        With sr
            .SiteID = gSiteID
            .VendorID = gVendorID
            .LocationID = gLocationID
            .RegisterID = Common.BOGetStrAttributeValueByName(fAdapter, invoiceHandle, "Invoice Workstion")
            .ReceiptID = Common.BOGetStrAttributeValueByName(fAdapter, invoiceHandle, "Invoice Number")
            .VendorCashier = Common.BOGetStrAttributeValueByName(fAdapter, invoiceHandle, "Cashier")
            .TransactionKey = New Guid(TranKey)
        End With
        Dim sy As StadisIntegratePlugin.WebReference.StadisReply = Common.StadisAPI.SVReverseTransaction(sr)
        If sy.ReturnCode < 0 Then
            MsgBox("Unable to reverse transaction " & TranKey, MsgBoxStyle.Exclamation, "Reverse Transaction")
            Return False
            'LogStadisEvent(Guid.Empty, "Reverse Charge", "DoReverse", "A", sy.ReturnCode, "Unable to reverse charge for StadisAuthorizationID", "", "", "StadisAuthorizationID = " & sy.StadisAuthorizationID)
        Else
            Return True
        End If
    End Function  'DoSVReverseTransaction

    '----------------------------------------------------------------------------------------------
    ' Get site and WS configuration settings
    '----------------------------------------------------------------------------------------------
    Public Shared Sub LoadLicenses()
        If gLicensesLoaded = False Then
            Dim blnOneEnabled = False
            Try
                Dim licenses As String() = StadisAPI.LicenseCheck(gRPROUID, gCompanyID)
                For i As Integer = 0 To licenses.Length - 1
                    If licenses(i) = "3316" Then
                        gStadisEnabled = True
                        blnOneEnabled = True
                    End If
                    If licenses(i) = "3317" Then
                        gTappitEnabled = True
                        blnOneEnabled = True
                    End If
                    If licenses(i) = "3318" Then
                        gSKIdataEnabled = True
                        blnOneEnabled = True
                    End If
                Next i
                gLicensesLoaded = True
                If blnOneEnabled = False Then
                    MsgBox("The StadisIntegratePlugin is installed and there are no licensed applications.  Please check StadisIntegratePlugin license(s) for Retail Pro user ID " & gRPROUID & " Company ID " & gCompanyID)
                End If
            Catch ex As Exception
                MsgBox("Plugin licensing check exception. Please check StadisIntegratePlugin license(s) for Retail Pro user ID " & gRPROUID & " Company ID " & gCompanyID)
                gLicensesLoaded = True 'Block further tries
            End Try

            'MsgBox("forced licensed tappit " & gTappitEnabled & vbCrLf & "forced licensed Stadis " & gStadisEnabled)
        End If

    End Sub  'LoadLicenses


    '----------------------------------------------------------------------------------------------
    ' Get site and WS configuration settings
    '----------------------------------------------------------------------------------------------
    Public Shared Sub LoadLocalSettings()
        'MsgBox("common loadlocalsettings")
        gStadisV4WebServiceURL = My.Settings.StadisV4WebServiceURL
        'MsgBox("common loadlocalsettings " & gStadisV4WebServiceURL)
        gOverrideSettingComponent = My.Settings.OverrideSettingID
        gStadisUserID = My.Settings.StadisUserID
        gStadisPassword = My.Settings.StadisPassword

        If My.Settings.UseShortCharge = "True" Then
            gUseShortCharge = True
        Else
            gUseShortCharge = False
        End If


        'gOPOSPrinterName = My.Settings.OPOSPrinterName
        'gRasterPrinterName = My.Settings.RasterPrinterName
        gWindowsPrinterName = My.Settings.WindowsPrinterName
    End Sub  'LoadLocalSettings

    Public Shared Sub LoadInstallationSettings()

        Dim blnTestMode As Boolean = False

        'blnTestMode = True

        If blnTestMode = True Then MsgBox("common.LoadInstallationSettings: blnTestMode = true")

        If gAlreadyLoaded = True Then Exit Sub
        gAlreadyLoaded = True

        If My.Settings.ReturnItemizedPromotions = "True" Then
            gReturnItemizedPromotions = True
        Else
            gReturnItemizedPromotions = False
        End If

        gTappitInstallationSettingsFailed = False
        Try
            ' Get installation settings - standard first, then overrides, if any
            If blnTestMode = True Then MsgBox("common.LoadInstallationSettings: calling web service")
            Dim mis As StadisIntegratePlugin.WebReference.MessageAndInstallationSettings = Common.StadisAPI.GetInstallationSettings("All")
            If blnTestMode = True Then MsgBox("common.LoadInstallationSettings: web service was called")
            If mis.ReturnMessage.ReturnCode < 0 Then
                MessageBox.Show("Unable to access InstallationSettings.", "STADIS")
                gTappitInstallationSettingsFailed = True
                If blnTestMode = True Then MsgBox("common.LoadInstallationSettings: url " & gStadisV4WebServiceURL)
                Exit Sub
            End If
            SetSettingsFor(mis, "Site")
            SetSettingsFor(mis, "CompanyID")

            SetSettingsFor(mis, gStandardSettingComponent)
            If gOverrideSettingComponent <> "" Then
                SetSettingsFor(mis, gOverrideSettingComponent)
            End If
        Catch ex As Exception
            If blnTestMode = True Then MsgBox("common.LoadInstallationSettings: Exception")
            gBalChkButtonActive = False
            gIssueButtonActive = False
            gReturnButtonActive = False
            gReloadButtonActive = False
            gBalChkButtonEnabled = False
            gIssueButtonEnabled = False
            gReturnButtonEnabled = False
            gReloadButtonEnabled = False
            MessageBox.Show("Unable to access InstallationSettings." & vbCrLf & ex.Message, "STADIS")
            gTappitInstallationSettingsFailed = True
            Exit Sub
        End Try

        Try
            ' Get Gift Card table
            If blnTestMode = True Then MsgBox("common.LoadInstallationSettings: calling GetSaleItemsForRPro")
            Dim msis As StadisIntegratePlugin.WebReference.MessageAndSaleItems = Common.StadisAPI.GetSaleItemsForRPro(gVendorID)
            If msis.ReturnMessage.ReturnCode < 0 Then
                MessageBox.Show("Unable to load gift card specifications.", "STADIS")
                gIssueButtonActive = False
            End If
            Dim gcis As StadisIntegratePlugin.WebReference.SaleItem() = msis.SaleItems
            For i As Integer = 0 To gcis.Length - 1
                If gcis(i).StadisPOSProcessingCode = "GCReload" Then
                    Dim gci As DSGiftCardInfo.ReloadInfoRow = CType(gGCI.ReloadInfo.NewRow, DSGiftCardInfo.ReloadInfoRow)
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
                    gci.IAMaxAmount = gcis(i).IAMaxAmount
                    gci.AllowReload = gcis(i).IsReloadAllowed
                    gci.RMinAmount = gcis(i).RMinAmount
                    gci.RMaxAmount = gcis(i).RMaxAmount
                    gGCI.ReloadInfo.Rows.Add(gci)
                Else
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
                    gci.IAMaxAmount = gcis(i).IAMaxAmount
                    gci.AllowReload = gcis(i).IsReloadAllowed
                    gci.RMinAmount = gcis(i).RMinAmount
                    gci.RMaxAmount = gcis(i).RMaxAmount
                    gGCI.GiftCardInfo.Rows.Add(gci)
                End If
            Next

            ' Derived settings
            gGiftCardEvent = Split(gGiftCardEvents, ";")

            Select Case gTenderDialogTender
                Case "Charge"
                    gTenderDialogTenderType = Plugins.TenderTypes.ttCharge
                Case "Check"
                    gTenderDialogTenderType = Plugins.TenderTypes.ttCheck
                Case "COD"
                    gTenderDialogTenderType = Plugins.TenderTypes.ttCOD
                Case "Credit Card"
                    gTenderDialogTenderType = Plugins.TenderTypes.ttCreditCard
                Case "Debit Card"
                    gTenderDialogTenderType = Plugins.TenderTypes.ttDebitCard
                Case "Check in F/C"
                    gTenderDialogTenderType = Plugins.TenderTypes.ttForeignCheck
                Case "Foreign Currency"
                    gTenderDialogTenderType = Plugins.TenderTypes.ttForeignCurrency
                Case "Gift Card"
                    gTenderDialogTenderType = Plugins.TenderTypes.ttGiftCard
                Case "Gift Certificate"
                    gTenderDialogTenderType = Plugins.TenderTypes.ttGiftCertificate
                Case "Store Credit"
                    gTenderDialogTenderType = Plugins.TenderTypes.ttStoreCredit
                Case "Traveler Check"
                    gTenderDialogTenderType = Plugins.TenderTypes.ttTravelerCheck
                Case Else
                    MessageBox.Show("Invalid Stadis TenderType specified - " & gTenderDialogTender, "STADIS")
            End Select

            'gTappitDialogTenderTyoe = "Gift Certificate"
            Select Case gTappitTenderDialogTender
                Case "Charge"
                    gTappitTenderDialogTenderType = Plugins.TenderTypes.ttCharge
                Case "Check"
                    gTappitTenderDialogTenderType = Plugins.TenderTypes.ttCheck
                Case "COD"
                    gTappitTenderDialogTenderType = Plugins.TenderTypes.ttCOD
                Case "Credit Card"
                    gTappitTenderDialogTenderType = Plugins.TenderTypes.ttCreditCard
                Case "Debit Card"
                    gTappitTenderDialogTenderType = Plugins.TenderTypes.ttDebitCard
                Case "Check in F/C"
                    gTappitTenderDialogTenderType = Plugins.TenderTypes.ttForeignCheck
                Case "Foreign Currency"
                    gTappitTenderDialogTenderType = Plugins.TenderTypes.ttForeignCurrency
                Case "Gift Card"
                    gTappitTenderDialogTenderType = Plugins.TenderTypes.ttGiftCard
                Case "Gift Certificate"
                    gTappitTenderDialogTenderType = Plugins.TenderTypes.ttGiftCertificate
                    'MsgBox("tappit tender was set using setting automatically line 383 in common")
                Case "Store Credit"
                    gTappitTenderDialogTenderType = Plugins.TenderTypes.ttStoreCredit
                Case "Traveler Check"
                    gTappitTenderDialogTenderType = Plugins.TenderTypes.ttTravelerCheck
                Case Else
                    MessageBox.Show("Invalid Tappit TenderType specified - " & gTappitTenderDialogTender, "Tappit")
            End Select

        Catch ex As Exception
            gBalChkButtonActive = False
            gIssueButtonActive = False
            gReturnButtonActive = False
            gReloadButtonActive = False
            gBalChkButtonEnabled = False
            gIssueButtonEnabled = False
            gReturnButtonEnabled = False
            gReloadButtonEnabled = False
            MessageBox.Show("Error loading Gift Card table." & vbCrLf & ex.Message, "STADIS")
        End Try
        If blnTestMode = True Then MsgBox("common.LoadInstallationSettings: finishing LoadInstallationSettings")
    End Sub  'LoadInstallationSettings

    Private Shared Sub SetSettingsFor(ByRef mis As StadisIntegratePlugin.WebReference.MessageAndInstallationSettings, ByVal loadComponentName As String)
        Dim blnTestMode As Boolean = False

        'blnTestMode = True
        If blnTestMode = True Then MsgBox("Common.SetSettingsFor blnTestMode = true")

        If blnTestMode = True Then MsgBox("Common.SetSettingsFor loadComponentName = " & loadComponentName)

        For Each setting As StadisIntegratePlugin.WebReference.InstallationSetting In mis.InstallationSettings
            With setting
                If .ComponentName = loadComponentName Then
                    Select Case .SettingName
                        Case "CompanyID"
                            gCompanyID = .SettingValue
                            'MsgBox(gCompanyID & vbCrLf & loadComponentName)

                        'Site settings
                        Case "StadisVersion"
                            gStadisVersion = .SettingValue
                        Case "StadisRelease"
                            gStadisRelease = .SettingValue
                        Case "SiteSVType"
                            gSiteSVType = .SettingValue
                        Case "AllowRedeemAmountChange"
                            gAllowRedeemAmountChange = CBool(.SettingValue)
                        Case "ArePromotionsActive"
                            gArePromotionsActive = CBool(.SettingValue)

                        Case "TappitDonationSKU"
                            gTappitDonationSKU = .SettingValue
                        Case "TappitBaseAddressV6"
                            '!Caution - placing TappitBaseAddressV6 into "gTappitBaseAddress" do not overrid this - see Case TappitBaseAddress
                            gTappitBaseAddress = .SettingValue
                            If blnTestMode = True Then MsgBox("Common.SetSettingsFor gTappitBaseAddress = " & gTappitBaseAddress)
                        Case "TappitBaseAddress"
                            '!Caution - placing TappitBaseAddressV6 into "gTappitBaseAddress" 
                            'leave assignment of gTappitBaseAddress here commented out!
                            ' see Case TappitBaseAddressV6
                            'gTappitBaseAddress = .SettingValue
                        Case "TappitAPIKey"
                            gTappitAPIKey = .SettingValue
                            If blnTestMode = True Then MsgBox("Common.SetSettingsFor gTappitAPIKey = " & gTappitAPIKey)
                            'MsgBox("Tappit api key: " & gTappitAPIKey)
                        Case "IsItemDiscount"
                            gIsItemDiscount = CBool(.SettingValue)
                        Case "FeeOrTenderForIssueOffset"
                            gFeeOrTenderForIssueOffset = .SettingValue
                        Case "FeeOrTenderForReloadOffset"
                            gFeeOrTenderForReloadOffset = .SettingValue
                        Case "VendorID"
                            gVendorID = .SettingValue
                        Case "TappitFormImage"
                            gFormTappitLogoImage = .SettingValue
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
                            gValidatePattern = .SettingValue
                        Case "ExtractPattern"
                            gExtractPattern = .SettingValue
                        Case "ValidatePattern"
                            gValidatePattern = .SettingValue
                        Case "GiftCardEvents"
                            gGiftCardEvents = .SettingValue
                        Case "IssueGiftCardForReturn"
                            gIssueGiftCardForReturn = CBool(.SettingValue)
                        Case "IsReturnGCIssueOrActivate"
                            gGiftCardEvents = .SettingValue.Substring(0, 1).ToUpper
                        Case "IsPrintingEnabled"
                            gIsPrintingEnabled = CBool(.SettingValue)
                        Case "StadisTenderText"
                            gStadisTenderText = .SettingValue
                        Case "ReceiptTenderText"
                            gReceiptTenderText = .SettingValue
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

                        Case "ReturnButtonActive"
                            gReturnButtonActive = CBool(.SettingValue)
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

                        Case "TenderDialogActive"
                            gTenderDialogActive = CBool(.SettingValue)
                        Case "TenderDialogFormText"
                            gTenderDialogFormText = .SettingValue
                        Case "TenderDialogHeader"
                            gTenderDialogHeader = .SettingValue
                        Case "TenderDialogTenderIDLabel"
                            gTenderDialogTenderIDLabel = .SettingValue
                        Case "TenderDialogTender"
                            gTenderDialogTender = .SettingValue

                        Case "TappitTenderDialogTender"
                            gTappitTenderDialogTender = .SettingValue
                        Case "TappitTenderDialogFormText"
                            gTappitTenderDialogFormText = .SettingValue
                        Case "TappitTenderDialogTenderIDLabel"
                            gTappitTenderDialogTenderIDLabel = .SettingValue
                        Case "TappitTenderDialogHeader"
                            gTappitTenderDialogHeader = .SettingValue
                        Case "TappitTokenDiscountTypeID"
                            gTappitTokenDiscountTypeID = .SettingValue
                        Case "TappitSkiDataDiscountTypeID"
                            gTappitSkiDataDiscountTypeID = .SettingValue


                    End Select
                End If
            End With
        Next
    End Sub  'SetSettingsFor
    Public Shared Function FormattedJson(ByVal jsontext As String) As String
        jsontext = Replace(jsontext, "," & Chr(34), vbCrLf & Chr(34))
        Return jsontext
    End Function
    Public Shared Function LoadHeader2(ByRef adapter As Plugins.IPluginAdapter, ByVal invoiceType As String, ByVal invoiceHandle As Integer) As StadisIntegratePlugin.WebReference.StadisTranHeader
        ''Debug code
        'Dim itemCount As Integer = BOGetIntAttributeValueByName(adapter, invoiceHandle, "Item Count")
        'Dim tenderCount As Integer = BOGetIntAttributeValueByName(adapter, invoiceHandle, "Tender Count")
        'MsgBox("Items: " & itemCount.ToString & ", Tenders: " & tenderCount.ToString, MsgBoxStyle.Exclamation, "Load")

        Dim mTransHeader As New StadisIntegratePlugin.WebReference.StadisTranHeader
        With mTransHeader
            .TransactionKey = Guid.NewGuid
            .LocationID = BOGetStrAttributeValueByName(adapter, invoiceHandle, "Store No")
            .RegisterID = BOGetStrAttributeValueByName(adapter, invoiceHandle, "Invoice Workstion")
            .ReceiptID = BOGetStrAttributeValueByName(adapter, invoiceHandle, "Invoice Number")
            .VendorID = GlobalValues.gVendorID
            .VendorCashier = BOGetStrAttributeValueByName(adapter, invoiceHandle, "Cashier")
            .VendorDiscountPct = BOGetStrAttributeValueByName(adapter, invoiceHandle, "Discount Percent")
            .VendorDiscount = BOGetDecAttributeValueByName(adapter, invoiceHandle, "Discount Amount")
            .VendorTax = BOGetDecAttributeValueByName(adapter, invoiceHandle, "Tax Total")
            .VendorTip = 0D
            Select Case invoiceType
                Case "Receipt"
                    .SubTotal = BOGetDecAttributeValueByName(adapter, invoiceHandle, "Subtotal")
                    .Total = BOGetDecAttributeValueByName(adapter, invoiceHandle, "Invc Total")
                Case "Return"
                    .SubTotal = -(BOGetDecAttributeValueByName(adapter, invoiceHandle, "Subtotal"))
                    .Total = -(BOGetDecAttributeValueByName(adapter, invoiceHandle, "Invc Total"))
            End Select
        End With
        Return mTransHeader
    End Function  'LoadHeader


    '------------------------------------------------------------------------------
    ' Repackage Header data in Stadis format
    '------------------------------------------------------------------------------
    Public Shared Function LoadHeader(ByRef adapter As Plugins.IPluginAdapter, ByVal invoiceType As String, ByVal invoiceHandle As Integer) As StadisIntegratePlugin.WebReference.StadisTranHeader
        ''Debug code
        'Dim itemCount As Integer = BOGetIntAttributeValueByName(adapter, invoiceHandle, "Item Count")
        'Dim tenderCount As Integer = BOGetIntAttributeValueByName(adapter, invoiceHandle, "Tender Count")
        'MsgBox("Items: " & itemCount.ToString & ", Tenders: " & tenderCount.ToString, MsgBoxStyle.Exclamation, "Load")

        Dim mTransHeader As New StadisIntegratePlugin.WebReference.StadisTranHeader
        With mTransHeader
            .TransactionKey = Guid.NewGuid
            .LocationID = BOGetStrAttributeValueByName(adapter, invoiceHandle, "Store No")
            .RegisterID = BOGetStrAttributeValueByName(adapter, invoiceHandle, "Invoice Workstion")
            .ReceiptID = BOGetStrAttributeValueByName(adapter, invoiceHandle, "Invoice Number")
            .VendorID = GlobalValues.gVendorID
            .VendorCashier = BOGetStrAttributeValueByName(adapter, invoiceHandle, "Cashier")
            .VendorDiscountPct = BOGetStrAttributeValueByName(adapter, invoiceHandle, "Discount Percent")
            .VendorDiscount = BOGetDecAttributeValueByName(adapter, invoiceHandle, "Discount Amount")
            .VendorTax = BOGetDecAttributeValueByName(adapter, invoiceHandle, "Tax Total")
            .VendorTip = 0D
            Select Case invoiceType
                Case "Receipt"
                    .SubTotal = BOGetDecAttributeValueByName(adapter, invoiceHandle, "Subtotal")
                    .Total = BOGetDecAttributeValueByName(adapter, invoiceHandle, "Invc Total")
                Case "Return"
                    .SubTotal = -(BOGetDecAttributeValueByName(adapter, invoiceHandle, "Subtotal"))
                    .Total = -(BOGetDecAttributeValueByName(adapter, invoiceHandle, "Invc Total"))
            End Select
        End With
        Return mTransHeader
    End Function  'LoadHeader
    Public Shared Function LoadHeaderTest() As StadisIntegratePlugin.WebReference.StadisTranHeader
        Dim mTransHeader As New StadisIntegratePlugin.WebReference.StadisTranHeader
        With mTransHeader
            .LocationID = "Imported Terminal 1"
            .RegisterID = "1112"
            .ReceiptID = "1234"
            .VendorID = "Test"
            .VendorCashier = "Flo"
            .VendorDiscountPct = "0"
            .VendorDiscount = 0D
            .VendorTax = 0D
            .VendorTip = 0D
            .SubTotal = 0D
            .Total = 3.5D
        End With
        Return mTransHeader
    End Function  'LoadHeader

    '------------------------------------------------------------------------------
    ' Repackage Item data in Stadis format
    '------------------------------------------------------------------------------
    Public Shared Function LoadTappitItemsTest() As StadisTranItem()
        Dim itemList As New List(Of StadisTranItem)
        Dim item As New StadisTranItem
        With item
            .ItemID = "6005"
            .Description = "Test"
            .Dept = "D1"
            .Class = "C1"
            .SubClass = "S1"
            .Quantity = 1
            .Price = 2.5D
            .Cost = 0D
            .Tax = 0D
            .AdditionalTax = 0D
            .Discount = 0D
            .Field1 = "FB"
        End With
        itemList.Add(item)
        Dim item2 As New StadisTranItem
        With item2
            .ItemID = "6100"
            .Description = "Test"
            .Dept = "D1"
            .Class = "C1"
            .SubClass = "S1"
            .Quantity = 1
            .Price = 1D
            .Cost = 0D
            .Tax = 0D
            .AdditionalTax = 0D
            .Discount = 0D
            .Field1 = "FB"
        End With
        itemList.Add(item2)
        'Dim item3 As New StadisTranItem
        'With item3
        '    .ItemID = "789"
        '    .Description = "Test"
        '    .Dept = "D1"
        '    .Class = "C1"
        '    .SubClass = "S1"
        '    .Quantity = 1
        '    .Price = 0.6D
        '    .Cost = 0D
        '    .Tax = 0D
        '    .AdditionalTax = 0D
        '    .Discount = 0D
        'End With
        'itemList.Add(item3)
        Dim mTransItems(itemList.Count - 1) As StadisTranItem
        itemList.CopyTo(mTransItems)
        Return mTransItems
    End Function  'LoadItemsTest

    Public Shared Function LoadItems(ByRef adapter As Plugins.IPluginAdapter, ByVal invoiceType As String, ByVal invoiceHandle As Integer, ByVal itemHandle As Integer) As StadisIntegratePlugin.WebReference.StadisTranItem()
        Dim itemList As New List(Of StadisIntegratePlugin.WebReference.StadisTranItem)
        BOOpen(adapter, itemHandle)
        BOFirst(adapter, itemHandle, "CR - LoadItems")
        While Not adapter.EOF(itemHandle)
            Dim item As New StadisIntegratePlugin.WebReference.StadisTranItem
            With item
                Try
                    .ItemID = BOGetStrAttributeValueByName(adapter, itemHandle, "Lookup ALU")
                Catch ex As Exception
                    .ItemID = "NoALU"
                End Try
                ' Stadis() is used to parse the Stadis info we stored in Item Note1: STADIS\GiftCardID\IorA\CustomerID\Amount
                Dim Stadis() As String = BOGetStrAttributeValueByName(adapter, itemHandle, "Item Note1").Split("\"c)
                If Stadis(0) = "STADIS" Then
                    .Description = BOGetStrAttributeValueByName(adapter, itemHandle, "Item Note1")
                Else
                    .Description = BOGetStrAttributeValueByName(adapter, itemHandle, "Desc1")
                End If
                .Dept = ""
                .Class = ""
                .SubClass = ""
                Dim DCS() As String = BOGetStrAttributeValueByName(adapter, itemHandle, "DCS Code").Split(" "c)
                If DCS.Length > 0 Then
                    .Dept = DCS(0)
                End If
                If DCS.Length > 2 Then
                    .Class = DCS(2)
                End If
                If DCS.Length > 4 Then
                    .SubClass = DCS(4)
                End If
                Select Case invoiceType
                    Case "Receipt"
                        .Quantity = BOGetIntAttributeValueByName(adapter, itemHandle, "Qty")
                        .Price = BOGetDecAttributeValueByName(adapter, itemHandle, "Price")
                        'MsgBox("LOAD ITEMS ATTR PRICE " & BOGetDecAttributeValueByName(adapter, itemHandle, "Price"))
                    Case "Return"
                        .Quantity = -(BOGetIntAttributeValueByName(adapter, itemHandle, "Qty"))
                        .Price = -(BOGetDecAttributeValueByName(adapter, itemHandle, "Price"))
                End Select
                .Cost = BOGetDecAttributeValueByName(adapter, itemHandle, "Cost")
                .Tax = 0D
                .AdditionalTax = 0D
                .Discount = 0D
            End With
            itemList.Add(item)
            adapter.BONext(itemHandle)
        End While
        Dim mTransItems(itemList.Count - 1) As StadisIntegratePlugin.WebReference.StadisTranItem
        itemList.CopyTo(mTransItems)
        Return mTransItems
    End Function  'LoadItems
    Public Shared Function LoadTappitItems(ByRef adapter As Plugins.IPluginAdapter, ByVal invoiceType As String, ByVal invoiceHandle As Integer, ByVal itemHandle As Integer) As StadisIntegratePlugin.WebReference.StadisTranItem()
        Dim strSku As String = ""
        Dim itemList As New List(Of StadisIntegratePlugin.WebReference.StadisTranItem)
        Dim decQtyTemp As Decimal = 0
        Dim decPriceTemp As Decimal = 0
        Dim decTax1Temp As Decimal = 0
        Dim decTax2Temp As Decimal = 0
        Dim decTax1Plus2Temp As Decimal = 0

        Dim decTax1PercentTemp As Decimal = 0
        Dim decTax2PercentTemp As Decimal = 0
        Dim decTax1Plus2PercentTemp As Decimal = 0

        Dim decExtPriceTemp As Decimal = 0

        gTappitDonationAmount = 0
        gTappitTaxTotal = 0
        gTappitSubtotal = 0

        BOOpen(adapter, itemHandle)
        BOFirst(adapter, itemHandle, "CR - LoadItems")
        While Not adapter.EOF(itemHandle)

            Try
                strSku = BOGetStrAttributeValueByName(adapter, itemHandle, "Lookup ALU")
            Catch ex As Exception
                strSku = " "
            End Try
            decQtyTemp = BOGetIntAttributeValueByName(adapter, itemHandle, "Qty")
            If strSku = gTappitDonationSKU Then
                decPriceTemp = BOGetDecAttributeValueByName(adapter, itemHandle, "Price")
                decExtPriceTemp = decQtyTemp * decPriceTemp
                gTappitDonationAmount = gTappitDonationAmount + decExtPriceTemp

            Else
                If decQtyTemp <> 0 Then


                    Dim item As New StadisIntegratePlugin.WebReference.StadisTranItem
                    With item
                        Try
                            .ItemID = strSku
                        Catch ex As Exception
                            .ItemID = " "
                        End Try

                        .Description = BOGetStrAttributeValueByName(adapter, itemHandle, "Desc1")

                        Dim DCS_code As String = BOGetStrAttributeValueByName(adapter, itemHandle, "DCS Code")
                        Dim Subclass As String = ""

                        Try
                            Subclass = Trim(DCS_code.Substring(6))
                        Catch ex As Exception
                            MsgBox("Retail Pro sub-class is missing!  Tappit requires sub-class!")
                            Subclass = ""
                        End Try

                        .Field1 = Subclass

                        decQtyTemp = BOGetIntAttributeValueByName(adapter, itemHandle, "Qty")
                        decPriceTemp = BOGetDecAttributeValueByName(adapter, itemHandle, "Price")
                        decExtPriceTemp = decQtyTemp * decPriceTemp
                        .Quantity = CInt(decQtyTemp)
                        .Price = decPriceTemp
                        decExtPriceTemp = decQtyTemp * decPriceTemp
                        gTappitSubtotal = gTappitSubtotal + decExtPriceTemp

                        'tax amount
                        Try
                            decTax1Temp = BOGetDecAttributeValueByName(adapter, itemHandle, "Tax Amount")
                        Catch ' ex As Exception
                            decTax1Temp = 0
                        End Try

                        Try
                            decTax2Temp = BOGetDecAttributeValueByName(adapter, itemHandle, "Tax Amount 2")
                        Catch ' ex As Exception
                            decTax2Temp = 0
                        End Try
                        decTax1Plus2Temp = decTax1Temp + decTax2Temp
                        .Tax = decTax1Plus2Temp
                        gTappitTaxTotal = (gTappitTaxTotal + decTax1Plus2Temp) * decQtyTemp

                        'tax percent
                        Try
                            decTax1PercentTemp = BOGetDecAttributeValueByName(adapter, itemHandle, "Tax Percent")
                        Catch ' ex As Exception
                            decTax1PercentTemp = 0
                        End Try

                        Try
                            decTax2PercentTemp = BOGetDecAttributeValueByName(adapter, itemHandle, "Tax Percent 2")
                        Catch 'ex As Exception
                            decTax2PercentTemp = 0
                        End Try
                        decTax1Plus2PercentTemp = decTax1PercentTemp + decTax2PercentTemp
                        .AdditionalTax = decTax1Plus2PercentTemp / 100

                        .Cost = BOGetDecAttributeValueByName(adapter, itemHandle, "Cost")
                    End With
                    itemList.Add(item)
                End If
            End If
            adapter.BONext(itemHandle)
        End While
        Dim mTransItems(itemList.Count - 1) As StadisIntegratePlugin.WebReference.StadisTranItem
        itemList.CopyTo(mTransItems)
        Return mTransItems
    End Function  'LoadItems


    '------------------------------------------------------------------------------
    ' Repackage Tender data in Stadis format
    '------------------------------------------------------------------------------
    Public Shared Function LoadTendersForCharge(ByRef adapter As Plugins.IPluginAdapter, ByVal invoiceType As String, ByVal tenderHandle As Integer, ByVal stt As StadisIntegratePlugin.WebReference.StadisTranTender) As StadisIntegratePlugin.WebReference.StadisTranTender()
        Dim tenderList As New List(Of StadisIntegratePlugin.WebReference.StadisTranTender)
        BOOpen(adapter, tenderHandle)
        Dim tenderCount As Integer = Common.BOGetIntAttributeValueByName(adapter, tenderHandle, "TENDER_COUNT")
        If tenderCount > 0 Then
            BOFirst(adapter, tenderHandle, "CR - LoadTendersForCharge")
            While Not adapter.EOF(tenderHandle)
                Dim tender As New StadisIntegratePlugin.WebReference.StadisTranTender
                With tender
                    .IsStadisTender = False
                    .StadisAuthorizationID = " "
                    Dim rproTenderType As Integer = BOGetIntAttributeValueByName(adapter, tenderHandle, "TENDER_TYPE")
                    If rproTenderType <> gTenderDialogTenderType Then
                        .TenderTypeID = 0
                        .IsStadisTender = False
                        .StadisAuthorizationID = ""
                        .TenderID = ""
                    Else
                        Dim tInfo As New TenderInfo(adapter, tenderHandle)
                        If tInfo.IsAStadisTender Then
                            If tInfo.ShouldBeCharged Then
                                If tInfo.IsAPromo Then
                                    .TenderTypeID = 11  'Promo
                                Else
                                    .TenderTypeID = 1  'Ticket
                                End If
                                Dim remark() As String = Common.BOGetStrAttributeValueByName(adapter, tenderHandle, "MANUAL_REMARK").Split("#"c)
                                If remark.Length > 0 Then
                                    .TenderID = remark(1)
                                    .StadisAuthorizationID = remark(2)
                                End If
                                .IsStadisTender = True
                            End If
                        Else
                            .TenderTypeID = 0
                        End If
                    End If
                    .Amount = BOGetDecAttributeValueByName(adapter, tenderHandle, "AMT")
                End With
                tenderList.Add(tender)
                adapter.BONext(tenderHandle)
            End While
        End If
        tenderList.Add(stt)
        Dim mTransTenders(tenderList.Count - 1) As StadisIntegratePlugin.WebReference.StadisTranTender
        tenderList.CopyTo(mTransTenders)
        Return mTransTenders
    End Function  'LoadTendersForCharge

    '------------------------------------------------------------------------------
    ' Repackage Tender data in Stadis format
    '------------------------------------------------------------------------------
    Public Shared Function LoadTenders(ByRef adapter As Plugins.IPluginAdapter, ByVal invoiceType As String, ByVal invoiceHandle As Integer, ByVal tenderHandle As Integer) As StadisIntegratePlugin.WebReference.StadisTranTender()
        Dim tenderList As New List(Of StadisIntegratePlugin.WebReference.StadisTranTender)
        Dim tenderCount As Integer = BOGetIntAttributeValueByName(adapter, 0, "Tender Count")
        BOOpen(adapter, tenderHandle)
        If tenderCount > 0 Then
            'Build array of tenders to pass to web service PostTransaction
            BOFirst(adapter, tenderHandle, "CR - LoadTenders")
            While Not adapter.EOF(tenderHandle)
                Dim tender As New StadisIntegratePlugin.WebReference.StadisTranTender
                With tender
                    .IsStadisTender = False
                    .StadisAuthorizationID = " "
                    Dim rproTenderType As Integer = BOGetIntAttributeValueByName(adapter, tenderHandle, "TENDER_TYPE")
                    If rproTenderType <> gTenderDialogTenderType Then
                        .TenderTypeID = 0
                        .IsStadisTender = False
                        .StadisAuthorizationID = ""
                        .TenderID = ""
                    Else
                        Dim ti As New TenderInfo(adapter, tenderHandle)
                        If ti.IsAStadisTender Then
                            If ti.ShouldBeCharged Then
                                If ti.IsAPromo Then
                                    .TenderTypeID = 11  'Promo
                                Else
                                    .TenderTypeID = 1  'Ticket
                                End If
                                Dim remark() As String = Common.BOGetStrAttributeValueByName(adapter, tenderHandle, "MANUAL_REMARK").Split("#"c)
                                If remark.Length > 0 Then
                                    .TenderID = remark(1)
                                    .StadisAuthorizationID = remark(2)
                                End If
                                .IsStadisTender = True
                            ElseIf ti.IsAnOffset Then
                                .IsStadisTender = False
                                .StadisAuthorizationID = ""
                                If ti.IsAReturn Then
                                    .TenderTypeID = 4  'Gift Card
                                    Dim remark() As String = Common.BOGetStrAttributeValueByName(adapter, tenderHandle, "MANUAL_REMARK").Split("#"c)
                                    If remark.Length > 0 Then
                                        .TenderID = remark(1)
                                    End If
                                Else
                                    .TenderTypeID = 0  'Other
                                    .TenderID = ""
                                End If
                            End If
                        Else
                            .TenderTypeID = 0
                        End If
                    End If
                    Select Case invoiceType
                        Case "Receipt"
                            .Amount = BOGetDecAttributeValueByName(adapter, tenderHandle, "AMT")
                        Case "Return"
                            .Amount = -(BOGetDecAttributeValueByName(adapter, tenderHandle, "AMT"))
                    End Select
                End With
                tenderList.Add(tender)
                adapter.BONext(tenderHandle)
            End While
            Dim mTransTenders(tenderList.Count - 1) As StadisIntegratePlugin.WebReference.StadisTranTender
            tenderList.CopyTo(mTransTenders)
            Return mTransTenders
        Else
            'Build dummy tender to satisfy web service PostTransaction
            Dim mTransTenders(0) As StadisIntegratePlugin.WebReference.StadisTranTender
            Dim mTransTender As New StadisIntegratePlugin.WebReference.StadisTranTender
            With mTransTender
                .IsStadisTender = False
                .StadisAuthorizationID = " "
                .TenderTypeID = 0
                .TenderID = ""
                .Amount = 0D
            End With
            mTransTenders(0) = mTransTender
            Return mTransTenders
        End If
    End Function  'LoadTenders
    'intended to place discounts and to add tappit tender if needed
    Public Shared Function ModifyTenders(ByRef adapter As Plugins.IPluginAdapter, ByVal invoiceType As String, ByVal invoiceHandle As Integer, ByVal tenderHandle As Integer) As Boolean
        'Public Shared Function ModifyTenders(ByRef adapter As Plugins.IPluginAdapter, ByVal invoiceType As String, ByVal invoiceHandle As Integer, ByVal tenderHandle As Integer) As StadisIntegratePlugin.WebReference.StadisTranTender()
        Dim tenderList As New List(Of StadisIntegratePlugin.WebReference.StadisTranTender)
        Dim tenderCount As Integer = BOGetIntAttributeValueByName(adapter, 0, "Tender Count")
        BOOpen(adapter, tenderHandle)
        If tenderCount > 0 Then
            'Build array of tenders to pass to web service PostTransaction
            BOFirst(adapter, tenderHandle, "CR - LoadTenders")
            While Not adapter.EOF(tenderHandle)
                Dim rproTenderType As Integer = BOGetIntAttributeValueByName(adapter, tenderHandle, "TENDER_TYPE")
                'If rproTenderType <> gTenderDialogTenderType Then
                MsgBox(CStr(rproTenderType))
                Select Case invoiceType
                    Case "Receipt"
                        '.Amount = BOGetDecAttributeValueByName(adapter, tenderHandle, "AMT")
                    Case "Return"
                        '.Amount = -(BOGetDecAttributeValueByName(adapter, tenderHandle, "AMT"))
                End Select
                adapter.BONext(tenderHandle)
            End While
            Dim mTransTenders(tenderList.Count - 1) As StadisIntegratePlugin.WebReference.StadisTranTender
            tenderList.CopyTo(mTransTenders)
            Return True
            'Return mTransTenders
        End If
    End Function  'ModifyTenders

    Public Shared Function LoadEmptyTenders() As StadisIntegratePlugin.WebReference.StadisTranTender()
        'Build dummy tender to satisfy web service PostTransaction
        Dim mTransTenders(0) As StadisIntegratePlugin.WebReference.StadisTranTender
        Dim mTransTender As New StadisIntegratePlugin.WebReference.StadisTranTender
        With mTransTender
            .IsStadisTender = False
            .StadisAuthorizationID = " "
            .TenderTypeID = 0
            .TenderID = ""
            .Amount = 0D
        End With
        mTransTenders(0) = mTransTender
        Return mTransTenders
        Return mTransTenders
    End Function  'LoadTenders

    '------------------------------------------------------------------------------
    ' Repackage Tender data in Stadis format
    '------------------------------------------------------------------------------
    Public Shared Function OldLoadTendersForCharge(ByRef adapter As Plugins.IPluginAdapter, ByVal invoiceType As String, ByVal tenderHandle As Integer) As StadisIntegratePlugin.WebReference.StadisTranTender()
        Dim tenderList As New List(Of StadisIntegratePlugin.WebReference.StadisTranTender)
        BOOpen(adapter, tenderHandle)
        Dim tenderCount As Integer = Common.BOGetIntAttributeValueByName(adapter, tenderHandle, "TENDER_COUNT")
        BOFirst(adapter, tenderHandle, "CR - LoadTendersForCharge")
        While Not adapter.EOF(tenderHandle)
            Dim tender As New StadisIntegratePlugin.WebReference.StadisTranTender
            With tender
                .IsStadisTender = False
                .StadisAuthorizationID = " "
                Dim rproTenderType As Integer = BOGetIntAttributeValueByName(adapter, tenderHandle, "TENDER_TYPE")
                Dim stadisTenderType As Integer = ConvertRProTenderTypeToStadis(rproTenderType)
                If rproTenderType <> gTenderDialogTenderType Then
                    .TenderTypeID = stadisTenderType
                    .IsStadisTender = False
                    .StadisAuthorizationID = ""
                    .TenderID = ""
                Else
                    Dim tInfo As New TenderInfo(adapter, tenderHandle)
                    If tInfo.IsAStadisTender Then
                        If tInfo.ShouldBeCharged Then
                            If tInfo.IsAPromo Then
                                .TenderTypeID = 11  'Promo
                            Else
                                .TenderTypeID = 1  'Ticket
                            End If
                            Dim remark() As String = Common.BOGetStrAttributeValueByName(adapter, tenderHandle, "MANUAL_REMARK").Split("#"c)
                            If remark.Length > 0 Then
                                .TenderID = remark(1)
                                .StadisAuthorizationID = remark(2)
                            End If
                            .IsStadisTender = True
                        End If
                    Else
                        .TenderTypeID = stadisTenderType
                    End If
                End If
                .Amount = BOGetDecAttributeValueByName(adapter, tenderHandle, "AMT")
            End With
            tenderList.Add(tender)
            adapter.BONext(tenderHandle)
        End While
        Dim mTransTenders(tenderList.Count - 1) As StadisIntegratePlugin.WebReference.StadisTranTender
        tenderList.CopyTo(mTransTenders)
        Return mTransTenders
    End Function  'OldLoadTendersForCharge

    '----------------------------------------------------------------------------------------------
    ' Return Stadis tender type corresponding to RPro tender type
    '----------------------------------------------------------------------------------------------
    Private Shared Function ConvertRProTenderTypeToStadis(ByVal rproTenderType As Integer) As Integer
        Dim ourTenderType As Integer

        Select Case rproTenderType
            Case Plugins.TenderTypes.ttCash
                ourTenderType = 2
            Case Plugins.TenderTypes.ttCharge
                ourTenderType = 3
            Case Plugins.TenderTypes.ttCheck
                ourTenderType = 6
            Case Plugins.TenderTypes.ttCOD
                ourTenderType = 0
            Case Plugins.TenderTypes.ttCreditCard
                ourTenderType = 3
            Case Plugins.TenderTypes.ttDebitCard
                ourTenderType = 8
            Case Plugins.TenderTypes.ttDeposit
                ourTenderType = 0
            Case Plugins.TenderTypes.ttForeignCheck
                ourTenderType = 0
            Case Plugins.TenderTypes.ttForeignCurrency
                ourTenderType = 0
            Case Plugins.TenderTypes.ttGiftCard
                ourTenderType = 4
            Case Plugins.TenderTypes.ttGiftCertificate
                ourTenderType = 5
            Case Plugins.TenderTypes.ttPayments
                ourTenderType = 0
            Case Plugins.TenderTypes.ttStoreCredit
                ourTenderType = 0
            Case Plugins.TenderTypes.ttTravelerCheck
                ourTenderType = 0
            Case Else
                ourTenderType = 0
        End Select
        Return ourTenderType
    End Function  'ConvertRProTenderTypeToStadis

    '------------------------------------------------------------------------------
    ' Calls to access Retail Pro
    '------------------------------------------------------------------------------
    Public Shared Sub BOOpen(ByRef adapter As Plugins.IPluginAdapter, ByRef objHandle As Integer)
        Dim retcode As Integer = adapter.BOOpen(objHandle)
        If retcode <> Plugins.PluginError.peSuccess Then DisplayError(retcode, "Opening Object")
    End Sub  'BOOpen

    Public Shared Sub BOClose(ByRef adapter As Plugins.IPluginAdapter, ByRef objHandle As Integer)
        Dim retcode As Integer = adapter.BOClose(objHandle)
        If retcode <> Plugins.PluginError.peSuccess Then DisplayError(retcode, "BOClose")
    End Sub  'BOClose

    Public Shared Sub BOEdit(ByRef adapter As Plugins.IPluginAdapter, ByRef objHandle As Integer)
        Dim retcode As Integer = adapter.BOEdit(objHandle)
        If retcode <> Plugins.PluginError.peSuccess Then DisplayError(retcode, "Editing Object")
    End Sub  'BOEdit

    Public Shared Sub BOInsert(ByRef adapter As Plugins.IPluginAdapter, ByRef objHandle As Integer)
        Dim retcode As Integer = adapter.BOInsert(objHandle)
        If retcode <> Plugins.PluginError.peSuccess Then DisplayError(retcode, "Inserting Object")
    End Sub  'BOInsert

    Public Shared Sub BODelete(ByRef adapter As Plugins.IPluginAdapter, ByRef objHandle As Integer)
        Dim retcode As Integer = adapter.BODelete(objHandle)
        If retcode <> Plugins.PluginError.peSuccess Then DisplayError(retcode, "Deleting Object")
    End Sub  'BODelete

    Public Shared Sub BOPost(ByRef adapter As Plugins.IPluginAdapter, ByRef objHandle As Integer)
        Dim retcode As Integer = adapter.BOPost(objHandle)
        If retcode <> Plugins.PluginError.peSuccess Then DisplayError(retcode, "Posting Object")
    End Sub  'BOPost

    Public Shared Sub BORefresh(ByRef adapter As Plugins.IPluginAdapter, ByRef objHandle As Integer)
        Dim retcode As Integer = adapter.BORefresh(objHandle)
        If retcode <> Plugins.PluginError.peSuccess Then DisplayError(retcode, "Posting Object")
    End Sub  'BORefresh

    Public Shared Sub BORefreshRecord(ByRef adapter As Plugins.IPluginAdapter, ByRef objHandle As Integer)
        Dim retcode As Integer = adapter.BORefreshRecord(objHandle, True, True)
        If retcode <> Plugins.PluginError.peSuccess Then DisplayError(retcode, "Refreshing Object")
    End Sub  'BORefreshRecord

    Public Shared Sub BOPrior(ByRef adapter As Plugins.IPluginAdapter, ByRef objHandle As Integer)
        Dim retcode As Integer = adapter.BOPrior(objHandle)
        If retcode <> Plugins.PluginError.peSuccess Then DisplayError(retcode, "BOPrior")
    End Sub  'BOPrior

    Public Shared Sub BONext(ByRef adapter As Plugins.IPluginAdapter, ByRef objHandle As Integer)
        Dim retcode As Integer = adapter.BONext(objHandle)
        If retcode <> Plugins.PluginError.peSuccess Then DisplayError(retcode, "BONext")
    End Sub  'BONext

    Public Shared Sub BOFirst(ByRef adapter As Plugins.IPluginAdapter, ByRef objHandle As Integer, ByVal errmsg As String)
        Dim retcode As Integer = adapter.BOFirst(objHandle)
        If retcode <> Plugins.PluginError.peSuccess Then DisplayError(retcode, "BOFirst - " & errmsg)
    End Sub  'BOFirst

    Public Shared Sub BOLast(ByRef adapter As Plugins.IPluginAdapter, ByRef objHandle As Integer)
        Dim retcode As Integer = adapter.BOLast(objHandle)
        If retcode <> Plugins.PluginError.peSuccess Then DisplayError(retcode, "BOLast")
    End Sub  'BOLast

    Public Shared Function BOGetStrAttributeValueByName(ByRef adapter As Plugins.IPluginAdapter, ByRef objHandle As Integer, ByVal attrName As String) As String
        Dim attr As Object = adapter.BOGetAttributeValueByName(objHandle, attrName)
        If attr.Equals(System.DBNull.Value) Then
            Return ""
        End If
        If attr Is Nothing Then
            MsgBox("Error retrieving attribute:  " & attrName)
        End If
        Return CStr(attr)
    End Function  'BOGetStrAttributeValueByName - String

    Public Shared Function BOGetIntAttributeValueByName(ByRef adapter As Plugins.IPluginAdapter, ByRef objHandle As Integer, ByVal attrName As String) As Integer
        Dim attr As Object = adapter.BOGetAttributeValueByName(objHandle, attrName)
        If attr.Equals(System.DBNull.Value) Then
            Return 0
        End If
        If attr Is Nothing Then
            MsgBox("Error retrieving attribute: " & attrName)
        End If
        Return CInt(attr)
    End Function  'BOGetIntAttributeValueByName - Int

    Public Shared Function BOGetDecAttributeValueByName(ByRef adapter As Plugins.IPluginAdapter, ByRef objHandle As Integer, ByVal attrName As String) As Decimal
        Dim attr As Object = adapter.BOGetAttributeValueByName(objHandle, attrName)
        If attr.Equals(System.DBNull.Value) Then
            Return 0D
        End If
        If attr Is Nothing Then
            MsgBox("Error retrieving attribute: " & attrName)
        End If
        Return CDec(attr)
    End Function  'BOGetDecAttributeValueByName - Dec

    Public Shared Function BOGetBoolAttributeValueByName(ByRef adapter As Plugins.IPluginAdapter, ByRef objHandle As Integer, ByVal attrName As String) As Boolean
        Dim attr As Object = adapter.BOGetAttributeValueByName(objHandle, attrName)
        If attr.Equals(System.DBNull.Value) Then
            Return False
        End If
        If attr Is Nothing Then
            MsgBox("Error retrieving attribute: " & attrName)
        End If
        Return CBool(attr)
    End Function  'BOGetBoolAttributeValueByName - Boolean

    Public Shared Sub BOSetAttributeValueByName(ByRef adapter As Plugins.IPluginAdapter, ByRef objHandle As Integer, ByVal attrName As String, ByVal attrValue As String)
        Dim retcode As Integer = adapter.BOSetAttributeValueByName(objHandle, attrName, attrValue)
        If retcode <> Plugins.PluginError.peSuccess Then DisplayError(retcode, "Setting attribute")
    End Sub  'BOSetAttributeValueByName - String

    Public Shared Sub BOSetAttributeValueByName(ByRef adapter As Plugins.IPluginAdapter, ByRef objHandle As Integer, ByVal attrName As String, ByVal attrValue As Integer)
        Dim retcode As Integer = adapter.BOSetAttributeValueByName(objHandle, attrName, attrValue)
        If retcode <> Plugins.PluginError.peSuccess Then DisplayError(retcode, "Setting attribute")
    End Sub  'BOSetAttributeValueByName - Integer

    Public Shared Sub BOSetAttributeValueByName(ByRef adapter As Plugins.IPluginAdapter, ByRef objHandle As Integer, ByVal attrName As String, ByVal attrValue As Decimal)
        Dim retcode As Integer = adapter.BOSetAttributeValueByName(objHandle, attrName, attrValue)
        If retcode <> Plugins.PluginError.peSuccess Then DisplayError(retcode, "Setting attribute")
    End Sub  'BOSetAttributeValueByName - Decimal

    Public Shared Sub BOSetCommitOnPost(ByRef adapter As Plugins.IPluginAdapter, ByRef objHandle As Integer, ByVal commit As Boolean)
        Dim retcode As Integer = adapter.BOSetCommitOnPost(objHandle, commit)
        If retcode <> Plugins.PluginError.peSuccess Then DisplayError(retcode, "Setting commit flag")
    End Sub  'BOSetCommitOnPost

    '------------------------------------------------------------------------------
    ' Displays error messages for calls to Retail Pro
    '------------------------------------------------------------------------------
    Public Shared Sub DisplayError(ByVal errNum As Integer, ByVal operation As String)
        'Dim errMsg As String = "Unknown error type"
        Dim errMsg As String
        Select Case errNum
            Case Plugins.PluginError.peGenericFailure
                errMsg = "Non-specific failure."
            Case Plugins.PluginError.peInvalidBOHandle
                errMsg = "The handle passed in was not valid for this plug-in."
            Case Plugins.PluginError.peSuccessNoResults
                errMsg = "The SQL statement processed without reporting error codes, but did not return a result set."
            Case Plugins.PluginError.peUnableToClose
                errMsg = "Call to BOClose failed. Either the business object wasn't open at that time " & vbCrLf & "or it could not be closed without first saving/canceling modifications."
            Case Plugins.PluginError.peUnableToCreateBO
                errMsg = "Unable to create business object."
            Case Plugins.PluginError.peUnableToDelete
                errMsg = "Call to BODelete failed. The business object may not have been open," & vbCrLf & "or the application may not allow deletions to the current record."
            Case Plugins.PluginError.peUnableToEdit
                errMsg = "Call to BOEdit failed."
            Case Plugins.PluginError.peUnableToInsert
                errMsg = "Call to BOInsert failed."
            Case Plugins.PluginError.peUnableToInsertIndex
                errMsg = "Unable to insert index"
            Case Plugins.PluginError.peUnableToInsertRecord
                errMsg = "Unable to insert record"
            Case Plugins.PluginError.peUnableToLocateByAttributes
                errMsg = "Call to BOLocateByAttributes failed."
            Case Plugins.PluginError.peUnableToOpen
                errMsg = "Call to BOOpen failed."
            Case Plugins.PluginError.peUnableToPost
                errMsg = "Call to BOPost failed." & vbCrLf & "The business object may have failed data validations," & vbCrLf & "or it may not have been in edit/insert mode."
            Case Plugins.PluginError.peUnableToReadFirstRow
                errMsg = "Unable to read first row."
            Case Plugins.PluginError.peUnableToReadLastRow
                errMsg = "Unable to read last row."
            Case Plugins.PluginError.peUnableToReadNextRow
                errMsg = "Unable to read next row."
            Case Plugins.PluginError.peUnableToRefresh
                errMsg = "Unable to refresh object."
            Case Plugins.PluginError.peUnableToSetAttributeValue
                errMsg = "Call to BOSetAttributeValue failed." & vbCrLf & "That attribute may not be intrinsically modifiable" & vbCrLf & "or you do not have write access to it."
            Case Plugins.PluginError.peUnsupportedBO
                errMsg = "The business object type specified is not supported."
            Case Else
                errMsg = "Unknown Return Code: " & errNum.ToString
        End Select
        MessageBox.Show(errMsg, operation)
    End Sub  'DisplayError

#End Region  'Methods

End Class  'CommonRoutines
