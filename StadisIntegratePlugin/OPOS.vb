Module OPOS

    ' /////////////////////////////////////////////////////////////////////
    ' //
    ' // Opos.h
    ' //
    ' //   General header file for OPOS Applications.
    ' //
    ' // Modification history
    ' // ------------------------------------------------------------------
    ' // 1995-12-08 OPOS Release 1.0                                   CRM
    ' // 1997-06-04 OPOS Release 1.2                                   CRM
    ' //   Add OPOS_FOREVER.
    ' //   Add BinaryConversion constants.
    ' // 1998-03-06 OPOS Release 1.3                                   CRM
    ' //   Add CapPowerReporting, PowerState, and PowerNotify constants.
    ' //   Add power reporting constants for StatusUpdateEvent.
    ' // 2000-09-24 OPOS Release 1.5                                   CRM
    ' //   Add OpenResult status constants.
    ' // 2004-10-26 OPOS Release 1.8                                   CRM
    ' //   Add "ResultCodeExtended" statistics constant.
    ' // 2005-04-29 OPOS Release 1.9                                   CRM
    ' //   Add CompareFirmwareVersion's Result constants.
    ' //   Add StatusUpdateEvent and ResultCodeExtended constants
    ' //     for firmware update.
    ' // 2006-03-15 OPOS Release 1.10                                  CRM
    ' //   Add another constant for firmware update.
    ' // 2007-01-30 OPOS Release 1.11                                  CRM
    ' //   Add ResultCode constant for deprecation.
    ' //
    ' /////////////////////////////////////////////////////////////////////

    ' /////////////////////////////////////////////////////////////////////
    ' // OPOS "State" Property Constants
    ' /////////////////////////////////////////////////////////////////////

    Public Const OPOS_S_CLOSED As Long = 1&
    Public Const OPOS_S_IDLE As Long = 2&
    Public Const OPOS_S_BUSY As Long = 3&
    Public Const OPOS_S_ERROR As Long = 4&

    ' /////////////////////////////////////////////////////////////////////
    ' // OPOS "ResultCode" Property Constants
    ' /////////////////////////////////////////////////////////////////////

    Public Const OPOS_SUCCESS As Long = 0&
    Public Const OPOS_E_CLOSED As Long = 101&
    Public Const OPOS_E_CLAIMED As Long = 102&
    Public Const OPOS_E_NOTCLAIMED As Long = 103&
    Public Const OPOS_E_NOSERVICE As Long = 104&
    Public Const OPOS_E_DISABLED As Long = 105&
    Public Const OPOS_E_ILLEGAL As Long = 106&
    Public Const OPOS_E_NOHARDWARE As Long = 107&
    Public Const OPOS_E_OFFLINE As Long = 108&
    Public Const OPOS_E_NOEXIST As Long = 109&
    Public Const OPOS_E_EXISTS As Long = 110&
    Public Const OPOS_E_FAILURE As Long = 111&
    Public Const OPOS_E_TIMEOUT As Long = 112&
    Public Const OPOS_E_BUSY As Long = 113&
    Public Const OPOS_E_EXTENDED As Long = 114&
    Public Const OPOS_E_DEPRECATED As Long = 115&   ' // (added in 1.11)

    Public Const OPOSERR As Long = 100&   ' // Base for ResultCode errors.
    Public Const OPOSERREXT As Long = 200&      ' // Base for ResultCodeExtendedErrors.

    ' /////////////////////////////////////////////////////////////////////
    ' // OPOS "ResultCodeExtended" Property Constants
    ' /////////////////////////////////////////////////////////////////////

    ' // The following applies to ResetStatistics and UpdateStatistics.
    Public Const OPOS_ESTATS_ERROR As Long = 280&       ' // (added in 1.8)
    Public Const OPOS_ESTATS_DEPENDENCY As Long = 282&      ' // (added in 1.10)
    ' // The following applies to CompareFirmwareVersion and UpdateFirmware.
    Public Const OPOS_EFIRMWARE_BAD_FILE As Long = 281&     ' // (added in 1.9)

    ' /////////////////////////////////////////////////////////////////////
    ' // OPOS "OpenResult" Property Constants (added in 1.5)
    ' /////////////////////////////////////////////////////////////////////

    ' // The following can be set by the control object.
    Public Const OPOS_OR_ALREADYOPEN As Long = 301&
    ' // Control Object already open.
    Public Const OPOS_OR_REGBADNAME As Long = 302&
    ' // The registry does not contain a key for the specified
    ' // device name.
    Public Const OPOS_OR_REGPROGID As Long = 303&
    ' // Could not read the device name key's default value, or
    ' // could not convert this Prog ID to a valid Class ID.
    Public Const OPOS_OR_CREATE As Long = 304&
    ' // Could not create a service object instance, or
    ' // could not get its IDispatch interface.
    Public Const OPOS_OR_BADIF As Long = 305&
    ' // The service object does not support one or more of the
    ' // method required by its release.
    Public Const OPOS_OR_FAILEDOPEN As Long = 306&
    ' // The service object returned a failure status from its
    ' // open call, but doesn't have a more specific failure code.
    Public Const OPOS_OR_BADVERSION As Long = 307&
    ' // The service object major version number is not 1.

    ' // The following can be returned by the service object if it
    ' // returns a failure status from its open call.
    Public Const OPOS_ORS_NOPORT As Long = 401&
    ' // Port access required at open, but configured port
    ' // is invalid or inaccessible.
    Public Const OPOS_ORS_NOTSUPPORTED As Long = 402&
    ' // Service Object does not support the specified device.
    Public Const OPOS_ORS_CONFIG As Long = 403&
    ' // Configuration information error.
    Public Const OPOS_ORS_SPECIFIC As Long = 450&
    ' // Errors greater than this value are SO-specific.

    ' /////////////////////////////////////////////////////////////////////
    ' // OPOS "BinaryConversion" Property Constants (added in 1.2)
    ' /////////////////////////////////////////////////////////////////////

    Public Const OPOS_BC_NONE As Long = 0&
    Public Const OPOS_BC_NIBBLE As Long = 1&
    Public Const OPOS_BC_DECIMAL As Long = 2&

    ' /////////////////////////////////////////////////////////////////////
    ' // "CheckHealth" Method: "Level" Parameter Constants
    ' /////////////////////////////////////////////////////////////////////

    Public Const OPOS_CH_INTERNAL As Long = 1&
    Public Const OPOS_CH_EXTERNAL As Long = 2&
    Public Const OPOS_CH_INTERACTIVE As Long = 3&

    ' /////////////////////////////////////////////////////////////////////
    ' // OPOS "CapPowerReporting", "PowerState", "PowerNotify" Property
    ' //   Constants (added in 1.3)
    ' /////////////////////////////////////////////////////////////////////

    Public Const OPOS_PR_NONE As Long = 0&
    Public Const OPOS_PR_STANDARD As Long = 1&
    Public Const OPOS_PR_ADVANCED As Long = 2&

    Public Const OPOS_PN_DISABLED As Long = 0&
    Public Const OPOS_PN_ENABLED As Long = 1&

    Public Const OPOS_PS_UNKNOWN As Long = 2000&
    Public Const OPOS_PS_ONLINE As Long = 2001&
    Public Const OPOS_PS_OFF As Long = 2002&
    Public Const OPOS_PS_OFFLINE As Long = 2003&
    Public Const OPOS_PS_OFF_OFFLINE As Long = 2004&

    ' /////////////////////////////////////////////////////////////////////
    ' // "CompareFirmwareVersion" Method: "Result" Parameter Constants
    ' //   (added in 1.9)
    ' /////////////////////////////////////////////////////////////////////

    Public Const OPOS_CFV_FIRMWARE_OLDER As Long = 1&
    Public Const OPOS_CFV_FIRMWARE_SAME As Long = 2&
    Public Const OPOS_CFV_FIRMWARE_NEWER As Long = 3&
    Public Const OPOS_CFV_FIRMWARE_DIFFERENT As Long = 4&
    Public Const OPOS_CFV_FIRMWARE_UNKNOWN As Long = 5&

    ' /////////////////////////////////////////////////////////////////////
    ' // "ErrorEvent" Event: "ErrorLocus" Parameter Constants
    ' /////////////////////////////////////////////////////////////////////

    Public Const OPOS_EL_OUTPUT As Long = 1&
    Public Const OPOS_EL_INPUT As Long = 2&
    Public Const OPOS_EL_INPUT_DATA As Long = 3&

    ' /////////////////////////////////////////////////////////////////////
    ' // "ErrorEvent" Event: "ErrorResponse" Constants
    ' /////////////////////////////////////////////////////////////////////

    Public Const OPOS_ER_RETRY As Long = 11&
    Public Const OPOS_ER_CLEAR As Long = 12&
    Public Const OPOS_ER_CONTINUEINPUT As Long = 13&

    ' /////////////////////////////////////////////////////////////////////
    ' // "StatusUpdateEvent" Event: Common "Status" Constants
    ' /////////////////////////////////////////////////////////////////////

    Public Const OPOS_SUE_POWER_ONLINE As Long = 2001&                   ' // (added in 1.3)
    Public Const OPOS_SUE_POWER_OFF As Long = 2002&                      ' // (added in 1.3)
    Public Const OPOS_SUE_POWER_OFFLINE As Long = 2003&                  ' // (added in 1.3)
    Public Const OPOS_SUE_POWER_OFF_OFFLINE As Long = 2004&              ' // (added in 1.3)

    Public Const OPOS_SUE_UF_PROGRESS As Long = 2100&                   ' // (added in 1.9)
    Public Const OPOS_SUE_UF_COMPLETE As Long = 2200&                   ' // (added in 1.9)
    Public Const OPOS_SUE_UF_COMPLETE_DEV_NOT_RESTORED As Long = 2205&      ' // (added in 1.9)
    Public Const OPOS_SUE_UF_FAILED_DEV_OK As Long = 2201&                  ' // (added in 1.9)
    Public Const OPOS_SUE_UF_FAILED_DEV_UNRECOVERABLE As Long = 2202&       ' // (added in 1.9)
    Public Const OPOS_SUE_UF_FAILED_DEV_NEEDS_FIRMWARE As Long = 2203&      ' // (added in 1.9)
    Public Const OPOS_SUE_UF_FAILED_DEV_UNKNOWN As Long = 2204&             ' // (added in 1.9)

    ' /////////////////////////////////////////////////////////////////////
    ' // General Constants
    ' /////////////////////////////////////////////////////////////////////

    Public Const OPOS_FOREVER As Long = -1&           ' // (added in 1.2)

    ' /////////////////////////////////////////////////////////////////////
    ' //
    ' // OposCash.h
    ' //
    ' //   Cash Drawer header file for OPOS Applications.
    ' //
    ' // Modification history
    ' // ------------------------------------------------------------------
    ' // 1995-12-08 OPOS Release 1.0                                   CRM
    ' // 1998-03-06 OPOS Release 1.3                                   CRM
    ' //
    ' /////////////////////////////////////////////////////////////////////

    ' /////////////////////////////////////////////////////////////////////
    ' // "StatusUpdateEvent" Event Constants
    ' /////////////////////////////////////////////////////////////////////

    Public Const CASH_SUE_DRAWERCLOSED As Long = 0&
    Public Const CASH_SUE_DRAWEROPEN As Long = 1&

    ' /////////////////////////////////////////////////////////////////////
    ' //
    ' // OposTot.h
    ' //
    ' //   Hard Totals header file for OPOS Applications.
    ' //
    ' // Modification history
    ' // ------------------------------------------------------------------
    ' // 1995-12-08 OPOS Release 1.0                                   CRM
    ' //
    ' /////////////////////////////////////////////////////////////////////

    ' /////////////////////////////////////////////////////////////////////
    ' // "ResultCodeExtended" Property Constants
    ' /////////////////////////////////////////////////////////////////////

    Public Const OPOS_ETOT_NOROOM As Long = 201&       ' // Create, Write
    Public Const OPOS_ETOT_VALIDATION As Long = 202&    ' // Read, Write

    ' /////////////////////////////////////////////////////////////////////
    ' //
    ' // OposLock.h
    ' //
    ' //   Keylock header file for OPOS Applications.
    ' //
    ' // Modification history
    ' // ------------------------------------------------------------------
    ' // 1995-12-08 OPOS Release 1.0                                   CRM
    ' // 2007-01-30 OPOS Release 1.11                                  CRM
    ' //
    ' /////////////////////////////////////////////////////////////////////

    ' /////////////////////////////////////////////////////////////////////
    ' // "KeyPosition" Property Constants
    ' // "WaitForKeylockChange" Method: "KeyPosition" Parameter
    ' // "StatusUpdateEvent" Event: "Data" Parameter
    ' /////////////////////////////////////////////////////////////////////

    Public Const LOCK_KP_ANY As Long = 0&              ' // WaitForKeylockChange Only
    Public Const LOCK_KP_ELECTRONIC As Long = 0&       ' // StatusUpdateEvent Only (added in 1.11)
    Public Const LOCK_KP_LOCK As Long = 1&
    Public Const LOCK_KP_NORM As Long = 2&
    Public Const LOCK_KP_SUPR As Long = 3&

    ' /////////////////////////////////////////////////////////////////////
    ' // "CapKeylockType" Property Constants
    ' //   Added in 1.11.
    ' /////////////////////////////////////////////////////////////////////

    Public Const LOCK_KT_STANDARD As Long = 1&
    Public Const LOCK_KT_ELECTRONIC As Long = 2&

    ' /////////////////////////////////////////////////////////////////////
    ' //
    ' // OposDisp.h
    ' //
    ' //   Line Display header file for OPOS Applications.
    ' //
    ' // Modification history
    ' // ------------------------------------------------------------------
    ' // 1995-12-08 OPOS Release 1.0                                   CRM
    ' // 1996-03-18 OPOS Release 1.01                                  CRM
    ' //   Add DISP_MT_INIT constant and MarqueeFormat constants.
    ' // 1996-04-22 OPOS Release 1.1                                   CRM
    ' //   Add CapCharacterSet constants for Kana and Kanji.
    ' // 2000-09-24 OPOS Release 1.5                                   BKS
    ' //   Add CapCharacterSet and CharacterSet constants for Unicode
    ' // 2001-07-15 OPOS Release 1.6                                   BKS
    ' //   Add CapCursorType, CapReadBack, CapReverse, CursorType
    ' //     property constants.
    ' //   Add DefineGlyph, DisplayText and DisplayTextAt parameter
    ' //     constants.
    ' // 2002-08-17 OPOS Release 1.7                                   CRM
    ' //   Add DisplayBitmap and SetBitmap parameter constants.
    ' // 2004-03-22 OPOS Release 1.8                                   CRM
    ' //   Add more constants for CapCursorType and CursorType.
    ' // 2004-10-26 Add "CharacterSet" ANSI constant (from 1.5).       CRM
    ' //   Add ResultCodeExtended constants (from 1.7).
    ' //
    ' /////////////////////////////////////////////////////////////////////

    ' /////////////////////////////////////////////////////////////////////
    ' // "CapBlink" Property Constants
    ' /////////////////////////////////////////////////////////////////////

    Public Const DISP_CB_NOBLINK As Long = 0&
    Public Const DISP_CB_BLINKALL As Long = 1&
    Public Const DISP_CB_BLINKEACH As Long = 2&

    ' /////////////////////////////////////////////////////////////////////
    ' // "CapCharacterSet" Property Constants
    ' /////////////////////////////////////////////////////////////////////

    Public Const DISP_CCS_NUMERIC As Long = 0&
    Public Const DISP_CCS_ALPHA As Long = 1&
    Public Const DISP_CCS_ASCII As Long = 998&
    Public Const DISP_CCS_KANA As Long = 10&       ' // (added in 1.1)
    Public Const DISP_CCS_KANJI As Long = 11&      ' // (added in 1.1)
    Public Const DISP_CCS_UNICODE As Long = 997&    ' // (added in 1.5)

    ' /////////////////////////////////////////////////////////////////////
    ' // "CapCursorType" Property Constants (added in 1.6)
    ' /////////////////////////////////////////////////////////////////////

    Public Const DISP_CCT_NONE As Long = &H0&
    Public Const DISP_CCT_FIXED As Long = &H1&
    Public Const DISP_CCT_BLOCK As Long = &H2&
    Public Const DISP_CCT_HALFBLOCK As Long = &H4&
    Public Const DISP_CCT_UNDERLINE As Long = &H8&
    Public Const DISP_CCT_REVERSE As Long = &H10&
    Public Const DISP_CCT_OTHER As Long = &H20&
    Public Const DISP_CCT_BLINK As Long = &H40&        ' // (added in 1.8)

    ' /////////////////////////////////////////////////////////////////////
    ' // "CapReadBack" Property Constants (added in 1.6)
    ' /////////////////////////////////////////////////////////////////////

    Public Const DISP_CRB_NONE As Long = &H0&
    Public Const DISP_CRB_SINGLE As Long = &H1&

    ' /////////////////////////////////////////////////////////////////////
    ' // "CapReverse" Property Constants (added in 1.6)
    ' /////////////////////////////////////////////////////////////////////

    Public Const DISP_CR_NONE As Long = &H0&
    Public Const DISP_CR_REVERSEALL As Long = &H1&
    Public Const DISP_CR_REVERSEEACH As Long = &H2&

    ' /////////////////////////////////////////////////////////////////////
    ' // "CharacterSet" Property Constants
    ' /////////////////////////////////////////////////////////////////////

    Public Const DISP_CS_UNICODE As Long = 997&       ' // (added in 1.5)
    Public Const DISP_CS_ASCII As Long = 998&
    Public Const DISP_CS_WINDOWS As Long = 999&
    Public Const DISP_CS_ANSI As Long = 999&           ' // (added in 1.5)

    ' /////////////////////////////////////////////////////////////////////
    ' // "CursorType" Property Constants (added in 1.6)
    ' /////////////////////////////////////////////////////////////////////

    Public Const DISP_CT_NONE As Long = 0&
    Public Const DISP_CT_FIXED As Long = 1&
    Public Const DISP_CT_BLOCK As Long = 2&
    Public Const DISP_CT_HALFBLOCK As Long = 3&
    Public Const DISP_CT_UNDERLINE As Long = 4&
    Public Const DISP_CT_REVERSE As Long = 5&
    Public Const DISP_CT_OTHER As Long = 6&
    Public Const DISP_CT_BLINK As Long = &H10000000         ' // (added in 1.8)

    ' /////////////////////////////////////////////////////////////////////
    ' // "MarqueeType" Property Constants
    ' /////////////////////////////////////////////////////////////////////

    Public Const DISP_MT_NONE As Long = 0&
    Public Const DISP_MT_UP As Long = 1&
    Public Const DISP_MT_DOWN As Long = 2&
    Public Const DISP_MT_LEFT As Long = 3&
    Public Const DISP_MT_RIGHT As Long = 4&
    Public Const DISP_MT_INIT As Long = 5&           ' // (added in 1.01)

    ' /////////////////////////////////////////////////////////////////////
    ' // "MarqueeFormat" Property Constants (added in 1.01)
    ' /////////////////////////////////////////////////////////////////////

    Public Const DISP_MF_WALK As Long = 0&
    Public Const DISP_MF_PLACE As Long = 1&

    ' /////////////////////////////////////////////////////////////////////
    ' // "DefineGlyph" Method: "GlyphType" Parameter Constants (added in 1.6)
    ' /////////////////////////////////////////////////////////////////////

    Public Const DISP_GT_SINGLE As Long = 1&

    ' /////////////////////////////////////////////////////////////////////
    ' // "DisplayText" Method: "Attribute" Property Constants (added in 1.6)
    ' // "DisplayTextAt" Method: "Attribute" Property Constants (added in 1.6)
    ' /////////////////////////////////////////////////////////////////////

    Public Const DISP_DT_NORMAL As Long = 0&
    Public Const DISP_DT_BLINK As Long = 1&
    Public Const DISP_DT_REVERSE As Long = 2&
    Public Const DISP_DT_BLINK_REVERSE As Long = 3&

    ' /////////////////////////////////////////////////////////////////////
    ' // "ScrollText" Method: "Direction" Parameter Constants
    ' /////////////////////////////////////////////////////////////////////

    Public Const DISP_ST_UP As Long = 1&
    Public Const DISP_ST_DOWN As Long = 2&
    Public Const DISP_ST_LEFT As Long = 3&
    Public Const DISP_ST_RIGHT As Long = 4&

    ' /////////////////////////////////////////////////////////////////////
    ' // "SetDescriptor" Method: "Attribute" Parameter Constants
    ' /////////////////////////////////////////////////////////////////////

    Public Const DISP_SD_OFF As Long = 0&
    Public Const DISP_SD_ON As Long = 1&
    Public Const DISP_SD_BLINK As Long = 2&

    ' /////////////////////////////////////////////////////////////////////
    ' // "DisplayBitmap" and "SetBitmap" Method Constants (added in 1.7)
    ' /////////////////////////////////////////////////////////////////////

    ' //   "Width" Parameter

    Public Const DISP_BM_ASIS As Long = -11&

    ' //   "AlignmentX" Parameter

    Public Const DISP_BM_LEFT As Long = -1&
    Public Const DISP_BM_CENTER As Long = -2&
    Public Const DISP_BM_RIGHT As Long = -3&

    ' //   "AlignmentY" Parameter

    Public Const DISP_BM_TOP As Long = -1&
    ' //const LONG DISP_BM_CENTER     = -2;
    Public Const DISP_BM_BOTTOM As Long = -3&

    ' /////////////////////////////////////////////////////////////////////
    ' // "ResultCodeExtended" Property Constants
    ' /////////////////////////////////////////////////////////////////////

    Public Const OPOS_EDISP_TOOBIG As Long = 201&   ' // DisplayBitmap (added in 1.7)
    Public Const OPOS_EDISP_BADFORMAT As Long = 202&    ' // DisplayBitmap (added in 1.7)

    ' /////////////////////////////////////////////////////////////////////
    ' //
    ' // OposMicr.h
    ' //
    ' //   MICR header file for OPOS Applications.
    ' //
    ' // Modification history
    ' // ------------------------------------------------------------------
    ' // 1995-12-08 OPOS Release 1.0                                   CRM
    ' // 2002-08-17 OPOS Release 1.7                                   CRM
    ' //   Add new ResultCodeExtended constants.
    ' //
    ' /////////////////////////////////////////////////////////////////////

    ' /////////////////////////////////////////////////////////////////////
    ' // "CheckType" Property Constants
    ' /////////////////////////////////////////////////////////////////////

    Public Const MICR_CT_PERSONAL As Long = 1&
    Public Const MICR_CT_BUSINESS As Long = 2&
    Public Const MICR_CT_UNKNOWN As Long = 99&

    ' /////////////////////////////////////////////////////////////////////
    ' // "CountryCode" Property Constants
    ' /////////////////////////////////////////////////////////////////////

    Public Const MICR_CC_USA As Long = 1&
    Public Const MICR_CC_CANADA As Long = 2&
    Public Const MICR_CC_MEXICO As Long = 3&
    Public Const MICR_CC_UNKNOWN As Long = 99&

    ' //////////////////////////////////////////////////////////////////////
    ' // "ResultCodeExtended" Property Constants
    ' /////////////////////////////////////////////////////////////////////

    Public Const OPOS_EMICR_NOCHECK As Long = 201&       ' // EndInsertion
    Public Const OPOS_EMICR_CHECK As Long = 202&         ' // EndRemoval

    ' // The following were added in 1.7
    Public Const OPOS_EMICR_BADDATA As Long = 203&
    Public Const OPOS_EMICR_NODATA As Long = 204&
    Public Const OPOS_EMICR_BADSIZE As Long = 205&
    Public Const OPOS_EMICR_JAM As Long = 206&
    Public Const OPOS_EMICR_CHECKDIGIT As Long = 207&
    Public Const OPOS_EMICR_COVEROPEN As Long = 208&

    ' /////////////////////////////////////////////////////////////////////
    ' //
    ' // OposMsr.h
    ' //
    ' //   Magnetic Stripe Reader header file for OPOS Applications.
    ' //
    ' // Modification history
    ' // ------------------------------------------------------------------
    ' // 1995-12-08 OPOS Release 1.0                                   CRM
    ' // 1997-06-04 OPOS Release 1.2                                   CRM
    ' //   Add ErrorReportingType constants.
    ' // 2000-09-24 OPOS Release 1.5                                   BKS
    ' //   Add constants relating to Track 4 Data.
    ' //   (01-07-15 Added omitted MSR_TR_1_3_4 property)
    ' // 2006-03-15 OPOS Release 1.10                                  CRM
    ' //   Add the following properties:
    ' //     CapWritableTracks, EncodingMaxLength, TracksToWrite
    ' //
    ' /////////////////////////////////////////////////////////////////////

    ' /////////////////////////////////////////////////////////////////////
    ' // "TracksToRead", "CapWritableTracks", "TracksToWrite" Property Constants
    ' /////////////////////////////////////////////////////////////////////

    Public Const MSR_TR_NONE As Long = 0&           ' // (added in 1.10)
    ' // "CapWritableTracks", "TracksToWrite"

    Public Const MSR_TR_1 As Long = 1&
    Public Const MSR_TR_2 As Long = 2&
    Public Const MSR_TR_3 As Long = 4&
    Public Const MSR_TR_4 As Long = 8&                  ' // (added in 1.5)

    Public Const MSR_TR_1_2 As Long = &H3&
    Public Const MSR_TR_1_3 As Long = &H5&
    Public Const MSR_TR_1_4 As Long = &H9&           ' // (added in 1.5)
    Public Const MSR_TR_2_3 As Long = &H6&
    Public Const MSR_TR_2_4 As Long = &HA&           ' // (added in 1.5)
    Public Const MSR_TR_3_4 As Long = &HC&           ' // (added in 1.5)

    Public Const MSR_TR_1_2_3 As Long = &H7&
    Public Const MSR_TR_1_2_4 As Long = &HB&           ' // (added in 1.5)
    Public Const MSR_TR_1_3_4 As Long = &HD&           ' // (added in 1.5)
    Public Const MSR_TR_2_3_4 As Long = &HE&           ' // (added in 1.5)

    Public Const MSR_TR_1_2_3_4 As Long = &HF&       ' // (added in 1.5)

    ' /////////////////////////////////////////////////////////////////////
    ' // "ErrorReportingType" Property Constants (added in 1.2)
    ' /////////////////////////////////////////////////////////////////////

    Public Const MSR_ERT_CARD As Long = 0&
    Public Const MSR_ERT_TRACK As Long = 1&

    ' /////////////////////////////////////////////////////////////////////
    ' // "ErrorEvent" Event: "ResultCodeExtended" Parameter Constants
    ' /////////////////////////////////////////////////////////////////////

    Public Const OPOS_EMSR_START As Long = 201&
    Public Const OPOS_EMSR_END As Long = 202&
    Public Const OPOS_EMSR_PARITY As Long = 203&
    Public Const OPOS_EMSR_LRC As Long = 204&

    ' /////////////////////////////////////////////////////////////////////
    ' //
    ' // OposPtr.h
    ' //
    ' //   POS Printer header file for OPOS Applications.
    ' //
    ' // Modification history
    ' // ------------------------------------------------------------------
    ' // 1995-12-08 OPOS Release 1.0                                   CRM
    ' // 1996-04-22 OPOS Release 1.1                                   CRM
    ' //   Add CapCharacterSet constants.
    ' //   Add ErrorLevel constants.
    ' //   Add TransactionPrint's Control constants.
    ' // 1997-06-04 OPOS Release 1.2                                   CRM
    ' //   Remove PTR_RP_NORMAL_ASYNC.
    ' //   Add more barcode symbologies.
    ' // 1998-03-06 OPOS Release 1.3                                   CRM
    ' //   Add more PrintTwoNormal constants.
    ' // 2000-09-24 OPOS Release 1.5                             EPSON/BKS
    ' //   Add CapRecMarkFeed and MarkFeed's Type constants.
    ' //   Add ChangePrintSide constants.
    ' //   Add StatusUpdateEvent constants.
    ' //   Add ResultCodeExtended constants.
    ' //   Add CapXxxCartridgeSensor and XxxCartridgeState constants.
    ' //   Add CartridgeNotify constants.
    ' //   Add CapCharacterset and CharacterSet constants for UNICODE.
    ' // 2003-05-29 OPOS Release 1.7                                   CRM
    ' //   Add more RotatePrint's Rotation PTR_RP_* constants.
    ' // 2004-03-22 OPOS Release 1.8                                   CRM
    ' //   Add more constants for PrintBarCode method and StatusUpdateEvent.
    ' // 2004-10-26 Add "CharacterSet" ANSI constant (from 1.5).       CRM
    ' // 2005-04-29 OPOS Release 1.9                                   CRM
    ' //   Add PageModeDescriptor and PageModePrintDirection constants.
    ' //   Add PageModePrint's Control constants.
    ' // 2006-03-15 OPOS Release 1.10                                  CRM
    ' //   Add PrintMemoryBitmap constants.
    ' //
    ' /////////////////////////////////////////////////////////////////////

    ' /////////////////////////////////////////////////////////////////////
    ' // Printer Station Constants
    ' /////////////////////////////////////////////////////////////////////

    Public Const PTR_S_JOURNAL As Long = 1&
    Public Const PTR_S_RECEIPT As Long = 2&
    Public Const PTR_S_SLIP As Long = 4&

    Public Const PTR_S_JOURNAL_RECEIPT As Long = &H3&
    Public Const PTR_S_JOURNAL_SLIP As Long = &H5&
    Public Const PTR_S_RECEIPT_SLIP As Long = &H6&

    Public Const PTR_TWO_RECEIPT_JOURNAL As Long = &H8003&   ' // (added in 1.3)
    Public Const PTR_TWO_SLIP_JOURNAL As Long = &H8005&      ' // (added in 1.3)
    Public Const PTR_TWO_SLIP_RECEIPT As Long = &H8006&      ' // (added in 1.3)

    ' /////////////////////////////////////////////////////////////////////
    ' // "CapCharacterSet" Property Constants (added in 1.1)
    ' /////////////////////////////////////////////////////////////////////

    Public Const PTR_CCS_ALPHA As Long = 1&
    Public Const PTR_CCS_ASCII As Long = 998&
    Public Const PTR_CCS_KANA As Long = 10&
    Public Const PTR_CCS_KANJI As Long = 11&
    Public Const PTR_CCS_UNICODE As Long = 997&       ' // (added in 1.5)

    ' /////////////////////////////////////////////////////////////////////
    ' // "CharacterSet" Property Constants
    ' /////////////////////////////////////////////////////////////////////

    Public Const PTR_CS_UNICODE As Long = 997&       ' // (added in 1.5)
    Public Const PTR_CS_ASCII As Long = 998&
    Public Const PTR_CS_WINDOWS As Long = 999&
    Public Const PTR_CS_ANSI As Long = 999&

    ' /////////////////////////////////////////////////////////////////////
    ' // "ErrorLevel" Property Constants (added in 1.1)
    ' /////////////////////////////////////////////////////////////////////

    Public Const PTR_EL_NONE As Long = 1&
    Public Const PTR_EL_RECOVERABLE As Long = 2&
    Public Const PTR_EL_FATAL As Long = 3&

    ' /////////////////////////////////////////////////////////////////////
    ' // "MapMode" Property Constants
    ' /////////////////////////////////////////////////////////////////////

    Public Const PTR_MM_DOTS As Long = 1&
    Public Const PTR_MM_TWIPS As Long = 2&
    Public Const PTR_MM_ENGLISH As Long = 3&
    Public Const PTR_MM_METRIC As Long = 4&

    ' /////////////////////////////////////////////////////////////////////
    ' // "CapXxxColor" Property Constants
    ' /////////////////////////////////////////////////////////////////////

    Public Const PTR_COLOR_PRIMARY As Long = &H1&
    Public Const PTR_COLOR_CUSTOM1 As Long = &H2&
    Public Const PTR_COLOR_CUSTOM2 As Long = &H4&
    Public Const PTR_COLOR_CUSTOM3 As Long = &H8&
    Public Const PTR_COLOR_CUSTOM4 As Long = &H10&
    Public Const PTR_COLOR_CUSTOM5 As Long = &H20&
    Public Const PTR_COLOR_CUSTOM6 As Long = &H40&
    Public Const PTR_COLOR_CYAN As Long = &H100&
    Public Const PTR_COLOR_MAGENTA As Long = &H200&
    Public Const PTR_COLOR_YELLOW As Long = &H400&
    Public Const PTR_COLOR_FULL As Long = &H80000000

    ' /////////////////////////////////////////////////////////////////////
    ' // "CapXxxCartridgeSensor" and  "XxxCartridgeState" Property Constants
    ' //   (added in 1.5)
    ' /////////////////////////////////////////////////////////////////////

    Public Const PTR_CART_UNKNOWN As Long = &H10000000
    Public Const PTR_CART_OK As Long = &H0&
    Public Const PTR_CART_REMOVED As Long = &H1&
    Public Const PTR_CART_EMPTY As Long = &H2&
    Public Const PTR_CART_NEAREND As Long = &H4&
    Public Const PTR_CART_CLEANING As Long = &H8&

    ' /////////////////////////////////////////////////////////////////////
    ' // "CartridgeNotify" Property Constants (added in 1.5)
    ' /////////////////////////////////////////////////////////////////////

    Public Const PTR_CN_DISABLED As Long = &H0&
    Public Const PTR_CN_ENABLED As Long = &H1&

    ' /////////////////////////////////////////////////////////////////////
    ' // "PageModeDescriptor" Property Constants (added in 1.9)
    ' /////////////////////////////////////////////////////////////////////

    Public Const PTR_PM_BITMAP As Long = &H1&
    Public Const PTR_PM_BARCODE As Long = &H2&
    Public Const PTR_PM_BM_ROTATE As Long = &H4&
    Public Const PTR_PM_BC_ROTATE As Long = &H8&
    Public Const PTR_PM_OPAQUE As Long = &H10&

    ' /////////////////////////////////////////////////////////////////////
    ' // "PageModePrintDirection" Property Constants (added in 1.9)
    ' /////////////////////////////////////////////////////////////////////

    Public Const PTR_PD_LEFT_TO_RIGHT As Long = 1&
    Public Const PTR_PD_BOTTOM_TO_TOP As Long = 2&
    Public Const PTR_PD_RIGHT_TO_LEFT As Long = 3&
    Public Const PTR_PD_TOP_TO_BOTTOM As Long = 4&

    ' /////////////////////////////////////////////////////////////////////
    ' // "CutPaper" Method Constant
    ' /////////////////////////////////////////////////////////////////////

    Public Const PTR_CP_FULLCUT As Long = 100&

    ' /////////////////////////////////////////////////////////////////////
    ' // "PageModePrint" Method: "Control" Parameter Constants (added in 1.9)
    ' /////////////////////////////////////////////////////////////////////

    Public Const PTR_PM_PAGE_MODE As Long = 1&
    Public Const PTR_PM_PRINT_SAVE As Long = 2&
    Public Const PTR_PM_NORMAL As Long = 3&
    Public Const PTR_PM_CANCEL As Long = 4&

    ' /////////////////////////////////////////////////////////////////////
    ' // "PrintBarCode" Method Constants:
    ' /////////////////////////////////////////////////////////////////////

    ' //   "Alignment" Parameter
    ' //     Either the distance from the left-most print column to the start
    ' //     of the bar code, or one of the following:

    Public Const PTR_BC_LEFT As Long = -1&
    Public Const PTR_BC_CENTER As Long = -2&
    Public Const PTR_BC_RIGHT As Long = -3&

    ' //   "TextPosition" Parameter

    Public Const PTR_BC_TEXT_NONE As Long = -11&
    Public Const PTR_BC_TEXT_ABOVE As Long = -12&
    Public Const PTR_BC_TEXT_BELOW As Long = -13&

    ' //   "Symbology" Parameter:

    ' //     One dimensional symbologies
    Public Const PTR_BCS_UPCA As Long = 101&            ' // Digits
    Public Const PTR_BCS_UPCE As Long = 102&            ' // Digits
    Public Const PTR_BCS_JAN8 As Long = 103&            ' // = EAN 8
    Public Const PTR_BCS_EAN8 As Long = 103&            ' // = JAN 8 (added in 1.2)
    Public Const PTR_BCS_JAN13 As Long = 104&           ' // = EAN 13
    Public Const PTR_BCS_EAN13 As Long = 104&           ' // = JAN 13 (added in 1.2)
    Public Const PTR_BCS_TF As Long = 105&              ' // (Discrete 2 of 5) Digits
    Public Const PTR_BCS_ITF As Long = 106&             ' // (Interleaved 2 of 5) Digits
    Public Const PTR_BCS_Codabar As Long = 107&         ' // Digits, -, $, :, /, ., +;
    ' //   4 start/stop characters
    ' //   (a, b, c, d)
    Public Const PTR_BCS_Code39 As Long = 108&          ' // Alpha, Digits, Space, -, .,
    ' //   $, /, +, %; start/stop (*)
    ' // Also has Full ASCII feature
    Public Const PTR_BCS_Code93 As Long = 109&          ' // Same characters as Code 39
    Public Const PTR_BCS_Code128 As Long = 110&         ' // 128 data characters
    ' //        (Begin additions for 1.2)
    Public Const PTR_BCS_UPCA_S As Long = 111&          ' // UPC-A with supplemental
    ' //   barcode
    Public Const PTR_BCS_UPCE_S As Long = 112&          ' // UPC-E with supplemental
    ' //   barcode
    Public Const PTR_BCS_UPCD1 As Long = 113&           ' // UPC-D1
    Public Const PTR_BCS_UPCD2 As Long = 114&           ' // UPC-D2
    Public Const PTR_BCS_UPCD3 As Long = 115&           ' // UPC-D3
    Public Const PTR_BCS_UPCD4 As Long = 116&           ' // UPC-D4
    Public Const PTR_BCS_UPCD5 As Long = 117&           ' // UPC-D5
    Public Const PTR_BCS_EAN8_S As Long = 118&          ' // EAN 8 with supplemental
    ' //   barcode
    Public Const PTR_BCS_EAN13_S As Long = 119&         ' // EAN 13 with supplemental
    ' //   barcode
    Public Const PTR_BCS_EAN128 As Long = 120&          ' // EAN 128
    Public Const PTR_BCS_OCRA As Long = 121&            ' // OCR "A"
    Public Const PTR_BCS_OCRB As Long = 122&            ' // OCR "B"
    ' //        (End additions for 1.2)
    ' //        (Begin additions for 1.8)
    Public Const PTR_BCS_Code128_Parsed As Long = 123&      ' // Code 128 with parsing
    Public Const PTR_BCS_RSS14 As Long = 131&               ' // Reduced Space Symbology - 14 digit GTIN
    Public Const PTR_BCS_RSS_EXPANDED As Long = 132&        ' // RSS - 14 digit GTIN plus additional fields
    ' //        (End additions for 1.8)

    ' //     Two dimensional symbologies
    Public Const PTR_BCS_PDF417 As Long = 201&
    Public Const PTR_BCS_MAXICODE As Long = 202&

    ' //     Start of Printer-Specific bar code symbologies
    Public Const PTR_BCS_OTHER As Long = 501&

    ' /////////////////////////////////////////////////////////////////////
    ' // "PrintBitmap" and "PrintMemoryBitmap" Method Constants:
    ' /////////////////////////////////////////////////////////////////////

    ' //   "Width" Parameter
    ' //     Either bitmap width or:

    Public Const PTR_BM_ASIS As Long = -11&            ' // One pixel per printer dot

    ' //   "Alignment" Parameter
    ' //     Either the distance from the left-most print column to the start
    ' //     of the bitmap, or one of the following:

    Public Const PTR_BM_LEFT As Long = -1&
    Public Const PTR_BM_CENTER As Long = -2&
    Public Const PTR_BM_RIGHT As Long = -3&

    ' //   "Type" Parameter ("PrintMemoryBitmap" only)
    Public Const PTR_BMT_BMP As Long = 1&
    Public Const PTR_BMT_JPEG As Long = 2&
    Public Const PTR_BMT_GIF As Long = 3&

    ' /////////////////////////////////////////////////////////////////////
    ' // "RotatePrint" Method: "Rotation" Parameter Constants
    ' // "RotateSpecial" Property Constants
    ' /////////////////////////////////////////////////////////////////////

    Public Const PTR_RP_NORMAL As Long = &H1&
    Public Const PTR_RP_RIGHT90 As Long = &H101&
    Public Const PTR_RP_LEFT90 As Long = &H102&
    Public Const PTR_RP_ROTATE180 As Long = &H103&

    ' // For "RotatePrint", one or both of the following values may be
    ' // ORed with one of the above values.
    Public Const PTR_RP_BARCODE As Long = &H1000&       ' // (added in 1.7)
    Public Const PTR_RP_BITMAP As Long = &H2000&        ' // (added in 1.7)

    ' /////////////////////////////////////////////////////////////////////
    ' // "SetLogo" Method: "Location" Parameter Constants
    ' /////////////////////////////////////////////////////////////////////

    Public Const PTR_L_TOP As Long = 1&
    Public Const PTR_L_BOTTOM As Long = 2&

    ' /////////////////////////////////////////////////////////////////////
    ' // "TransactionPrint" Method: "Control" Parameter Constants (added in 1.1)
    ' /////////////////////////////////////////////////////////////////////

    Public Const PTR_TP_TRANSACTION As Long = 11&
    Public Const PTR_TP_NORMAL As Long = 12&

    ' /////////////////////////////////////////////////////////////////////
    ' // "MarkFeed" Method: "Type" Parameter Constants (added in 1.5)
    ' // "CapRecMarkFeed" Property Constants (added in 1.5)
    ' /////////////////////////////////////////////////////////////////////

    Public Const PTR_MF_TO_TAKEUP As Long = 1&
    Public Const PTR_MF_TO_CUTTER As Long = 2&
    Public Const PTR_MF_TO_CURRENT_TOF As Long = 4&
    Public Const PTR_MF_TO_NEXT_TOF As Long = 8&

    ' /////////////////////////////////////////////////////////////////////
    ' // "ChangePrintSide" Method: "Side" Parameter Constants (added in 1.5)
    ' /////////////////////////////////////////////////////////////////////

    Public Const PTR_PS_UNKNOWN As Long = 0&
    Public Const PTR_PS_SIDE1 As Long = 1&
    Public Const PTR_PS_SIDE2 As Long = 2&
    Public Const PTR_PS_OPPOSITE As Long = 3&

    ' /////////////////////////////////////////////////////////////////////
    ' // "StatusUpdateEvent" Event: "Data" Parameter Constants
    ' /////////////////////////////////////////////////////////////////////

    Public Const PTR_SUE_COVER_OPEN As Long = 11&
    Public Const PTR_SUE_COVER_OK As Long = 12&
    Public Const PTR_SUE_JRN_COVER_OPEN As Long = 60&            ' // (added in 1.8)
    Public Const PTR_SUE_JRN_COVER_OK As Long = 61&              ' // (added in 1.8)
    Public Const PTR_SUE_REC_COVER_OPEN As Long = 62&            ' // (added in 1.8)
    Public Const PTR_SUE_REC_COVER_OK As Long = 63&              ' // (added in 1.8)
    Public Const PTR_SUE_SLP_COVER_OPEN As Long = 64&            ' // (added in 1.8)
    Public Const PTR_SUE_SLP_COVER_OK As Long = 65&              ' // (added in 1.8)

    Public Const PTR_SUE_JRN_EMPTY As Long = 21&
    Public Const PTR_SUE_JRN_NEAREMPTY As Long = 22&
    Public Const PTR_SUE_JRN_PAPEROK As Long = 23&

    Public Const PTR_SUE_REC_EMPTY As Long = 24&
    Public Const PTR_SUE_REC_NEAREMPTY As Long = 25&
    Public Const PTR_SUE_REC_PAPEROK As Long = 26&

    Public Const PTR_SUE_SLP_EMPTY As Long = 27&
    Public Const PTR_SUE_SLP_NEAREMPTY As Long = 28&
    Public Const PTR_SUE_SLP_PAPEROK As Long = 29&

    Public Const PTR_SUE_JRN_CARTRIDGE_EMPTY As Long = 41&       ' // (added in 1.5)
    Public Const PTR_SUE_JRN_CARTRIDGE_NEAREMPTY As Long = 42&      ' // (added in 1.5)
    Public Const PTR_SUE_JRN_HEAD_CLEANING As Long = 43&            ' // (added in 1.5)
    Public Const PTR_SUE_JRN_CARTRIDGE_OK As Long = 44&             ' // (added in 1.5)

    Public Const PTR_SUE_REC_CARTRIDGE_EMPTY As Long = 45&       ' // (added in 1.5)
    Public Const PTR_SUE_REC_CARTRIDGE_NEAREMPTY As Long = 46&      ' // (added in 1.5)
    Public Const PTR_SUE_REC_HEAD_CLEANING As Long = 47&            ' // (added in 1.5)
    Public Const PTR_SUE_REC_CARTRIDGE_OK As Long = 48&             ' // (added in 1.5)

    Public Const PTR_SUE_SLP_CARTRIDGE_EMPTY As Long = 49&       ' // (added in 1.5)
    Public Const PTR_SUE_SLP_CARTRIDGE_NEAREMPTY As Long = 50&      ' // (added in 1.5)
    Public Const PTR_SUE_SLP_HEAD_CLEANING As Long = 51&            ' // (added in 1.5)
    Public Const PTR_SUE_SLP_CARTRIDGE_OK As Long = 52&             ' // (added in 1.5)

    Public Const PTR_SUE_IDLE As Long = 1001&

    ' /////////////////////////////////////////////////////////////////////
    ' // "ResultCodeExtended" Property Constants
    ' /////////////////////////////////////////////////////////////////////

    Public Const OPOS_EPTR_COVER_OPEN As Long = 201&           ' // (Several)
    Public Const OPOS_EPTR_JRN_EMPTY As Long = 202&            ' // (Several)
    Public Const OPOS_EPTR_REC_EMPTY As Long = 203&            ' // (Several)
    Public Const OPOS_EPTR_SLP_EMPTY As Long = 204&            ' // (Several)
    Public Const OPOS_EPTR_SLP_FORM As Long = 205&             ' // EndRemoval
    Public Const OPOS_EPTR_TOOBIG As Long = 206&               ' // PrintBitmap
    Public Const OPOS_EPTR_BADFORMAT As Long = 207&            ' // PrintBitmap
    Public Const OPOS_EPTR_JRN_CARTRIDGE_REMOVED As Long = 208&     ' // (Several) (added in 1.5)
    Public Const OPOS_EPTR_JRN_CARTRIDGE_EMPTY As Long = 209&       ' // (Several) (added in 1.5)
    Public Const OPOS_EPTR_JRN_HEAD_CLEANING As Long = 210&         ' // (Several) (added in 1.5)
    Public Const OPOS_EPTR_REC_CARTRIDGE_REMOVED As Long = 211&     ' // (Several) (added in 1.5)
    Public Const OPOS_EPTR_REC_CARTRIDGE_EMPTY As Long = 212&       ' // (Several) (added in 1.5)
    Public Const OPOS_EPTR_REC_HEAD_CLEANING As Long = 213&         ' // (Several) (added in 1.5)
    Public Const OPOS_EPTR_SLP_CARTRIDGE_REMOVED As Long = 214&     ' // (Several) (added in 1.5)
    Public Const OPOS_EPTR_SLP_CARTRIDGE_EMPTY As Long = 215&       ' // (Several) (added in 1.5)
    Public Const OPOS_EPTR_SLP_HEAD_CLEANING As Long = 216&         ' // (Several) (added in 1.5)

    ' /////////////////////////////////////////////////////////////////////
    ' //
    ' // OposScan.h
    ' //
    ' //   Scanner header file for OPOS Applications.
    ' //
    ' // Modification history
    ' // ------------------------------------------------------------------
    ' // 1995-12-08 OPOS Release 1.0                                   CRM
    ' // 1997-06-04 OPOS Release 1.2                                   CRM
    ' // 2004-03-22 OPOS Release 1.8                                   CRM
    ' // 2007-01-30 OPOS Release 1.11                                  CRM
    ' //
    ' /////////////////////////////////////////////////////////////////////

    ' /////////////////////////////////////////////////////////////////////
    ' // "ScanDataType" Property Constants (added in 1.2)
    ' /////////////////////////////////////////////////////////////////////

    ' // One dimensional symbologies
    Public Const SCAN_SDT_UPCA As Long = 101&        ' // Digits
    Public Const SCAN_SDT_UPCE As Long = 102&        ' // Digits
    Public Const SCAN_SDT_JAN8 As Long = 103&        ' // = EAN 8
    Public Const SCAN_SDT_EAN8 As Long = 103&        ' // = JAN 8 (added in 1.2)
    Public Const SCAN_SDT_JAN13 As Long = 104&       ' // = EAN 13
    Public Const SCAN_SDT_EAN13 As Long = 104&       ' // = JAN 13 (added in 1.2)
    Public Const SCAN_SDT_TF As Long = 105&          ' // (Discrete 2 of 5) Digits
    Public Const SCAN_SDT_ITF As Long = 106&         ' // (Interleaved 2 of 5) Digits
    Public Const SCAN_SDT_Codabar As Long = 107&     ' // Digits, -, $, :, /, ., +;
    ' //   4 start/stop characters
    ' //   (a, b, c, d)
    Public Const SCAN_SDT_Code39 As Long = 108&      ' // Alpha, Digits, Space, -, .,
    ' //   $, /, +, %; start/stop (*)
    ' // Also has Full ASCII feature
    Public Const SCAN_SDT_Code93 As Long = 109&      ' // Same characters as Code 39
    Public Const SCAN_SDT_Code128 As Long = 110&     ' // 128 data characters

    Public Const SCAN_SDT_UPCA_S As Long = 111&        ' // UPC-A with supplemental
    ' //   barcode
    Public Const SCAN_SDT_UPCE_S As Long = 112&        ' // UPC-E with supplemental
    ' //   barcode
    Public Const SCAN_SDT_UPCD1 As Long = 113&         ' // UPC-D1
    Public Const SCAN_SDT_UPCD2 As Long = 114&         ' // UPC-D2
    Public Const SCAN_SDT_UPCD3 As Long = 115&         ' // UPC-D3
    Public Const SCAN_SDT_UPCD4 As Long = 116&         ' // UPC-D4
    Public Const SCAN_SDT_UPCD5 As Long = 117&         ' // UPC-D5
    Public Const SCAN_SDT_EAN8_S As Long = 118&        ' // EAN 8 with supplemental
    ' //   barcode
    Public Const SCAN_SDT_EAN13_S As Long = 119&       ' // EAN 13 with supplemental
    ' //   barcode
    Public Const SCAN_SDT_EAN128 As Long = 120&        ' // EAN 128
    Public Const SCAN_SDT_OCRA As Long = 121&          ' // OCR "A"
    Public Const SCAN_SDT_OCRB As Long = 122&          ' // OCR "B"

    ' //  - One dimensional symbologies (added in 1.8)
    Public Const SCAN_SDT_RSS14 As Long = 131&        ' // Reduced Space Symbology - 14 digit GTIN
    Public Const SCAN_SDT_RSS_EXPANDED As Long = 132&   ' // RSS - 14 digit GTIN plus additional fields

    ' //  - Composite Symbologies (added in 1.8)
    Public Const SCAN_SDT_CCA As Long = 151&            ' // Composite Component A.
    Public Const SCAN_SDT_CCB As Long = 152&            ' // Composite Component B.
    Public Const SCAN_SDT_CCC As Long = 153&            ' // Composite Component C.

    ' // Two dimensional symbologies
    Public Const SCAN_SDT_PDF417 As Long = 201&
    Public Const SCAN_SDT_MAXICODE As Long = 202&

    ' //  - One dimensional symbologies (added in 1.11)
    Public Const SCAN_SDT_DATAMATRIX As Long = 203&    ' // Data Matrix
    Public Const SCAN_SDT_QRCODE As Long = 204&        ' // QR Code
    Public Const SCAN_SDT_UQRCODE As Long = 205&       ' // Micro QR Code
    Public Const SCAN_SDT_AZTEC As Long = 206&         ' // Aztec
    Public Const SCAN_SDT_UPDF417 As Long = 207&       ' // Micro PDF 417

    ' // Special cases
    Public Const SCAN_SDT_OTHER As Long = 501&        ' // Start of Scanner-Specific bar
    ' //   code symbologies
    Public Const SCAN_SDT_UNKNOWN As Long = 0&        ' // Cannot determine the barcode
    ' //   symbology.

    ' /////////////////////////////////////////////////////////////////////
    ' //
    ' // OposChk.h
    ' //
    ' //   Check Scanner header file for OPOS Applications.
    ' //
    ' // Modification history
    ' // ------------------------------------------------------------------
    ' // 2002-08-17 OPOS Release 1.7                                   CRM
    ' // 2005-04-29 OPOS Release 1.9                                   CRM
    ' //   Added Constrast constants.
    ' //
    ' /////////////////////////////////////////////////////////////////////

    ' /////////////////////////////////////////////////////////////////////
    ' // "CapColor" Capability Constants
    ' /////////////////////////////////////////////////////////////////////

    Public Const CHK_CCL_MONO As Long = &H1&
    Public Const CHK_CCL_GRAYSCALE As Long = &H2&
    Public Const CHK_CCL_16 As Long = &H4&
    Public Const CHK_CCL_256 As Long = &H8&
    Public Const CHK_CCL_FULL As Long = &H10&

    ' /////////////////////////////////////////////////////////////////////
    ' // "CapImageFormat" Capability Constants
    ' /////////////////////////////////////////////////////////////////////

    Public Const CHK_CIF_NATIVE As Long = &H1&
    Public Const CHK_CIF_TIFF As Long = &H2&
    Public Const CHK_CIF_BMP As Long = &H4&
    Public Const CHK_CIF_JPEG As Long = &H8&
    Public Const CHK_CIF_GIF As Long = &H10&

    ' /////////////////////////////////////////////////////////////////////
    ' // "Color" Property Constants
    ' /////////////////////////////////////////////////////////////////////

    Public Const CHK_CL_MONO As Long = 1&
    Public Const CHK_CL_GRAYSCALE As Long = 2&
    Public Const CHK_CL_16 As Long = 3&
    Public Const CHK_CL_256 As Long = 4&
    Public Const CHK_CL_FULL As Long = 5&

    ' /////////////////////////////////////////////////////////////////////
    ' // "Constrast" Property Constants (added in 1.9)
    ' /////////////////////////////////////////////////////////////////////

    Public Const CHK_AUTOMATIC_CONTRAST As Long = -1&

    ' /////////////////////////////////////////////////////////////////////
    ' // "ImageFormat" Property Constants
    ' /////////////////////////////////////////////////////////////////////

    Public Const CHK_IF_NATIVE As Long = 1&
    Public Const CHK_IF_TIFF As Long = 2&
    Public Const CHK_IF_BMP As Long = 3&
    Public Const CHK_IF_JPEG As Long = 4&
    Public Const CHK_IF_GIF As Long = 5&

    ' /////////////////////////////////////////////////////////////////////
    ' // "ImageMemoryStatus" Property Constants
    ' /////////////////////////////////////////////////////////////////////

    Public Const CHK_IMS_EMPTY As Long = 1&
    Public Const CHK_IMS_OK As Long = 2&
    Public Const CHK_IMS_FULL As Long = 3&

    ' /////////////////////////////////////////////////////////////////////
    ' // "MapMode" Property Constants
    ' /////////////////////////////////////////////////////////////////////

    Public Const CHK_MM_DOTS As Long = 1&
    Public Const CHK_MM_TWIPS As Long = 2&
    Public Const CHK_MM_ENGLISH As Long = 3&
    Public Const CHK_MM_METRIC As Long = 4&

    ' /////////////////////////////////////////////////////////////////////
    ' // "ClearImage" Method Constants:
    ' /////////////////////////////////////////////////////////////////////

    ' //   "By" Parameter
    Public Const CHK_CLR_ALL As Long = 1&
    Public Const CHK_CLR_BY_FILEID As Long = 2&
    Public Const CHK_CLR_BY_FILEINDEX As Long = 3&
    Public Const CHK_CLR_BY_IMAGETAGDATA As Long = 4&

    ' /////////////////////////////////////////////////////////////////////
    ' // "DefineCropArea" Method Constants:
    ' /////////////////////////////////////////////////////////////////////

    ' // "CropAreaID" Parameter or index number
    Public Const CHK_CROP_AREA_ENTIRE_IMAGE As Long = -1&
    Public Const CHK_CROP_AREA_RESET_ALL As Long = -2&

    ' // "CX" Parameter or integer width
    Public Const CHK_CROP_AREA_RIGHT As Long = -1&

    ' // "CY" Parameter or integer height
    Public Const CHK_CROP_AREA_BOTTOM As Long = -1&

    ' /////////////////////////////////////////////////////////////////////
    ' // "RetrieveMemory" Method Constants:
    ' /////////////////////////////////////////////////////////////////////

    ' // "By" Parameter
    Public Const CHK_LOCATE_BY_FILEID As Long = 1&
    Public Const CHK_LOCATE_BY_FILEINDEX As Long = 2&
    Public Const CHK_LOCATE_BY_IMAGETAGDATA As Long = 3&

    ' /////////////////////////////////////////////////////////////////////
    ' // "RetrieveImage" and "StoreImage" Method Constant:
    ' /////////////////////////////////////////////////////////////////////

    ' // "CropAreaID" Parameter or index number
    ' //const LONG CHK_CROP_AREA_ENTIRE_IMAGE   = -1; //(Defined above)

    ' /////////////////////////////////////////////////////////////////////
    ' // "StatusUpdateEvent" Event: "Data" Parameter Constant
    ' /////////////////////////////////////////////////////////////////////

    Public Const CHK_SUE_SCANCOMPLETE As Long = 11&

    ' /////////////////////////////////////////////////////////////////////
    ' // "ResultCodeExtended" Property Constants
    ' /////////////////////////////////////////////////////////////////////

    Public Const OPOS_ECHK_NOCHECK As Long = 201&           ' // endInsertion
    Public Const OPOS_ECHK_CHECK As Long = 202&             ' // endRemoval
    Public Const OPOS_ECHK_NOROOM As Long = 203&            ' // storeImage

    ' /////////////////////////////////////////////////////////////////////
    ' //
    ' // OposEj.h
    ' //
    ' //   Electronic Journal header file for OPOS Applications.
    ' //
    ' // Modification history
    ' // ------------------------------------------------------------------
    ' // 2006-03-15 OPOS Release 1.10                                  CRM
    ' //
    ' /////////////////////////////////////////////////////////////////////

    ' /////////////////////////////////////////////////////////////////////
    ' // "CapStation", "Station" Property Constants
    ' /////////////////////////////////////////////////////////////////////

    Public Const EJ_S_RECEIPT As Long = &H1&
    Public Const EJ_S_SLIP As Long = &H2&
    Public Const EJ_S_JOURNAL As Long = &H4&

    ' /////////////////////////////////////////////////////////////////////
    ' // "retrieveCurrentMarker" Method, "markerType" Parameter Constants
    ' // "retrieveMarker" Method, "markerType" Parameter Constants
    ' // "retrieveMarkerByDateTime" Method, "markerType" Parameter Constants
    ' /////////////////////////////////////////////////////////////////////

    Public Const EJ_MT_SESSION_BEG As Long = 1&
    Public Const EJ_MT_SESSION_END As Long = 2&
    Public Const EJ_MT_DOCUMENT As Long = 3&
    Public Const EJ_MT_HEAD As Long = 4&
    Public Const EJ_MT_TAIL As Long = 5&

    ' /////////////////////////////////////////////////////////////////////
    ' // "ResultCodeExtended" Property and "ErrorEvent" Parameter Constants
    ' /////////////////////////////////////////////////////////////////////

    Public Const OPOS_EEJ_EXISTING As Long = 201&
    Public Const OPOS_EEJ_MEDIUM_FULL As Long = 202&
    Public Const OPOS_EEJ_MULTIPLE_MARKER As Long = 203&
    Public Const OPOS_EEJ_UNINITIALIZED_MEDIUM As Long = 204&
    Public Const OPOS_EEJ_CORRUPTED_MEDIUM As Long = 205&
    Public Const OPOS_EEJ_UNKNOWN_DATAFORMAT As Long = 206&
    Public Const OPOS_EEJ_NOT_ENOUGH_SPACE As Long = 207&
    Public Const OPOS_EEJ_MULTIPLE_MARKERS As Long = 208&

    ' /////////////////////////////////////////////////////////////////////
    ' // "StatusUpdateEvent" "Status" Property Constants
    ' /////////////////////////////////////////////////////////////////////

    Public Const EJ_SUE_MEDIUM_NEAR_FULL As Long = 1&
    Public Const EJ_SUE_MEDIUM_FULL As Long = 2&
    Public Const EJ_SUE_MEDIUM_REMOVED As Long = 3&
    Public Const EJ_SUE_MEDIUM_INSERTED As Long = 4&
    Public Const EJ_SUE_SUSPENDED As Long = 5&

    Public Const EJ_SUE_IDLE As Long = 1001&


End Module

