'----------------------------------------------------------------------------------------------
' Site and WS configuration settings
'----------------------------------------------------------------------------------------------
Public Module GlobalValues

    'Public gStadisInitializeCount As Integer = 0
    '----------------------------------------------------------------------------------------------
    ' From Config File
    '----------------------------------------------------------------------------------------------
    Public gIsItemDiscount As Boolean = False
    Public gReturnItemizedPromotions As Boolean = False

    '----------------------------------------------------------------------------------------------
    ' Note: WS settings are NOT stored in the config file.  The config file only contains defaults
    ' used to create the settings if they don't exist.  Settings are stored in the user's app data.
    '----------------------------------------------------------------------------------------------
    Public gSiteID As String = ""
    Public gWSID As String = ""
    Public gLocationID As String = ""
    Public gStadisV4WebServiceURL As String = "http://192.168.100.13/StadisV4Web/StadisV4Transactions.asmx"
    Public gStandardSettingComponent As String = "RPro9WS"
    Public gOverrideSettingComponent As String = ""
    Public gStadisUserID As String = "Test1"
    Public gStadisPassword As String = "password"
    Public gUseShortCharge As Boolean = False

    'Public gOPOSPrinterName As String
    'Public gRasterPrinterName As String
    Public gWindowsPrinterName As String

    Public gReportServerURL As String
    Public gReportFolder As String
    Public gReportName As String
    Public gReportServerUID As String
    Public gReportServerPWD As String

    '----------------------------------------------------------------------------------------------
    ' These settings come from the InstallationSetting table.  "InstallationSettingComponent" in the 
    ' WS settings is used as the ComponentName in retrieving them.  This allows for different sets
    ' of installation settings for different vendors.
    '----------------------------------------------------------------------------------------------
    Public gSiteSVType As String = "Ticket"
    Public gStadisVersion As String = "4"
    Public gStadisRelease As String = "0"

    Public gAllowRedeemAmountChange As Boolean = True
    Public gArePromotionsActive As Boolean = False
    Public gAllowReturnCreditToCard As Boolean = False
    Public gAskForTicketOnIssue As Boolean = False
    Public gAskForTicketOnRedeem As Boolean = False
    Public gDefaultCustomerID As String = "99999"
    Public gFeeOrTenderForIssueOffset As String = "Tender"
    Public gFeeOrTenderForReloadOffset As String = "Tender"
    Public gFormLogoImage As String = "stadislogo.png"
    Public gGiftCardEvents As String = "9999;8888;7777;6666;5555"
    Public gImageTransparentColor As System.Drawing.Color = Drawing.Color.Magenta
    Public gIsMergeFunctionEnabled As Boolean = False
    Public gIsPrintingEnabled As Boolean = False
    Public gStadisTenderText As String = ""
    Public gReceiptTenderText As String = ""
    Public gIssueGiftCardForReturn As Boolean = False
    Public gIsReturnGCIssueOrActivate As String = ""
    Public gPostNonStadisTransactions As Boolean = False
    Public gReturnGiftCardALU As String = ""
    Public gExtractPattern As String = "(?<=[;\*]*)[0-9]+(?=([=\?]|$))"
    '        '(?<=[;\*]*)   = optionally preceded by a semicolon
    '        '[0-9]+        = One or more numbers  <-- Extract
    '        '(?=([=\?]|$)) = and followed by an equals, a question mark, or end of line
    Public gValidatePattern As String = "(1[47][0-9]{12}$*)|([01][0-9]{7}$*)"
    '        '(1[47][0-9]{12}$*)    = 1, followed by a 4 or 7, followed by 12 more numbers, followed by an optional end of line
    '        '|                     = Or
    '        '([01][0-9]{7}$*)      = 0 or 1, followed by 7 more numbers, followed by an optional end of line
    Public gShowSVActionGrid As Boolean = False
    'Public gTenderTypeForStadis As String = "GiftCard"
    Public gVendorID As String = ""

    Public gTenderDialogActive As Boolean = True
    Public gTenderDialogFormText As String = "Tender: Stadis"
    Public gTenderDialogHeader As String = "Redeem Gift Card / STADIS"
    Public gTenderDialogTenderIDLabel As String = "Gift Card ID / Ticket Barcode"
    Public gTenderDialogTender As String = "Traveler Check"

    Public gTappitTenderDialogFormText As String = "Tender: Tappit"
    Public gTappitTenderDialogHeader As String = "Tappit Charge"
    Public gTappitTenderDialogTenderIDLabel As String = "Tappit Barcode"
    Public gFormTappitLogoImage As String = "tappit.png"
    Public gTappitDonationSKU As String = ""
    Public gTappitDonationAmount As Decimal = 0
    Public gTappitSubtotal As Decimal = 0
    Public gTappitTaxTotal As Decimal = 0
    Public gTappitBaseAddress As String = ""
    Public gTappitAPIKey As String = ""
    Public gTappitCurrentDocumentUniqueID As String = ""
    Public gTappitInstallationSettingsFailed As Boolean = False
    'array(Col,row) zero based
    Public gTappitComplimentaryUsageArray(,) As String 'redim just before assignment
    Public gTappitComplimentaryUsageArrayRowCount As Integer = 0 'changed during redim as needed
    Public gTappitComplimentaryUsageArrayColCount As Integer = 3 'origin 0 4 columns description, used_amount, remaining_amount, expire_date

    Public gTappitTokenUsageArray(,) As String 'redim just before assignment
    Public gTappitTokenUsageArrayRowCount As Integer = 0 'changed during redim as needed
    Public gTappitTokenUsageArrayColCount As Integer = 4 'origin 0 in 5 columns description, used_amount, sku, product_name, expire_date

    Public gTappitSkiDataUsageArray(,) As String 'redim just before assignment
    Public gTappitSkiDataUsageArrayRowCount As Integer = 0 'changed during redim as needed
    Public gTappitSkiDataUsageArrayColCount As Integer = 10 'origin 0, 11 columns amount, discount, name, quantity, sku, tax_amount, tax_included, tax_percent, type, unit_price, applied

    Public gTappitApprovedTenderAmount As Decimal = 0
    Public gTappitComplimentaryUsageTotal As Decimal = 0
    Public gTappitTokenUsageTotal As Decimal = 0
    Public gTappitTokenDiscountTypeID As String = "0"
    Public gTappitSkiDataDiscountTypeID As String = "0"

    Public gTappitHTTPClientIsSetup As Boolean = False



    Public gDebugMode As Boolean = False


    Public gBalChkButtonActive As Boolean = False
    Public gBalChkButtonCaption As String = "Bal Check"
    Public gBalChkButtonEnabled As Boolean = False
    Public gBalChkButtonHint As String = "Check balance on gift card / ticket."
    Public gBalChkButtonImage As String = "stadis32.bmp"

    Public gIssueButtonActive As Boolean = False
    Public gIssueButtonCaption As String = "Issue"
    Public gIssueButtonEnabled As Boolean = False
    Public gIssueButtonHint As String = "Issue STADIS Gift Card(s)."
    Public gIssueButtonImage As String = "stadis32.bmp"

    'Public gRedeemButtonActive As Boolean = False
    'Public gRedeemButtonCaption As String = "Redeem"
    'Public gRedeemButtonEnabled As Boolean = False
    'Public gRedeemButtonHint As String = "Redeem a STADIS gift card or ticket."
    'Public gRedeemButtonImage As String = "stadis32.bmp"

    Public gReloadButtonActive As Boolean = False
    Public gReloadButtonCaption As String = "Reload"
    Public gReloadButtonEnabled As Boolean = False
    Public gReloadButtonHint As String = "Reload STADIS gift card or ticket."
    Public gReloadButtonImage As String = "stadis32.bmp"

    Public gReturnButtonActive As Boolean = False
    Public gReturnButtonCaption As String = "Return"
    Public gReturnButtonEnabled As Boolean = False
    Public gReturnButtonHint As String = "Issue STADIS gift card for item return."
    Public gReturnButtonImage As String = "stadis32.bmp"

    '----------------------------------------------------------------------------------------------
    ' Populated during initialization
    '----------------------------------------------------------------------------------------------
    Public gGiftCardEvent() As String
    Public gGCI As New DSGiftCardInfo
    'Public gStadisTenderType As Integer
    Public gTenderDialogTenderType As Integer = -99

    '----------------------------------------------------------------------------------------------
    ' Populated when referenced
    '----------------------------------------------------------------------------------------------
    Public gRegisterID As String = "Unknown"
    Public gVendorCashier As String = "Unknown"
    Public gLastInvcSID As String = ""
    Public gLastTenderID As String = ""
    Public gLastAmount As Decimal = 0D
    Public gLastAuthID As String = ""

    '----------------------------------------------------------------------------------------------
    ' Flags
    '----------------------------------------------------------------------------------------------
    Public gIsAReturn As Boolean = False
    Public gAlreadyLoaded As Boolean = False

    Public gRPROUID As String = ""
    Public gCompanyID As String = ""
    Public gTappitTenderDialogTenderType As Integer = 0
    Public gTappitTenderDialogTender As String = ""
    Public gLicensesLoaded As Boolean = False  'Used to only perform license check once per application run
    Public gTappitEnabled As Boolean = False
    Public gSKIdataEnabled As Boolean = False
    Public gStadisEnabled As Boolean = False

    'Public gDoStadis As Boolean = False                        'set by algorithm in tender dialogue, but public
    'Public gDoTappit As Boolean = False                        'set by algorithm in tender dialogue, but public

End Module  'GlobalValues
