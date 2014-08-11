Imports CommonV4
Imports RetailPro.CustomPluginClasses
Imports RetailPro.Plugins
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports BalanceCheckV4
'----------------------------------------------------------------------------------------------
'   Class: ButtonBalChk
'    Type: SideButton - Invoice
' Purpose: Invokes Balance Check program
'----------------------------------------------------------------------------------------------
<GuidAttribute(Discover.CLASS_ButtonBalChk)> _
Public Class ButtonBalChk
    Inherits TCustomSideButtonPlugin

    '----------------------------------------------------------------------------------------------
    ' Called when plugin is loaded
    '----------------------------------------------------------------------------------------------
    Public Overrides Sub Initialize()
        MyBase.Initialize()
        fButtonEnabled = gBalChkButtonEnabled
        fHint = gBalChkButtonHint
        If gBalChkButtonEnabled = True Then
            fCaption = gBalChkButtonCaption
        Else
            fCaption = "Disabled"
        End If
        fPictureFilename = gBalChkButtonImage
        fLayoutActionName = "actStadisBalChkButton"
        fChecked = True
        fEnabled = gBalChkButtonEnabled
        fGUID = New Guid(Discover.CLASS_ButtonBalChk)
        fBusinessObjectType = RetailPro.Plugins.BusinessObjectType.btInvoice
    End Sub  'Initialize

    '----------------------------------------------------------------------------------------------
    ' Called when button is clicked
    '----------------------------------------------------------------------------------------------
    Public Overrides Function HandleEvent() As Boolean
        If gBalChkButtonActive = True Then
            Dim mFrmBalChk As New FrmBalChk
            'mFrmBalChk.Adapter = fAdapter
            mFrmBalChk.ShowDialog()
            mFrmBalChk = Nothing
        End If
        Return MyBase.HandleEvent()
    End Function  'HandleEvent

End Class  'ButtonBalChk
