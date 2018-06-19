Imports CustomPluginClasses
Imports Plugins
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
'----------------------------------------------------------------------------------------------
'   Class: ButtonReload
'    Type: SideButton - Invoice
' Purpose: Invokes FrmReload to reload a gift card
'----------------------------------------------------------------------------------------------
<GuidAttribute(Discover.CLASS_ButtonReload)> _
Public Class ButtonReload
    Inherits TCustomSideButtonPlugin

    'Public mCommon As New Common

    '----------------------------------------------------------------------------------------------
    ' Called when plugin is loaded
    '----------------------------------------------------------------------------------------------
    Public Overrides Sub Initialize()
        MyBase.Initialize()
        fButtonEnabled = gReloadButtonEnabled
        fHint = gReloadButtonHint
        If gReloadButtonEnabled = True Then
            fCaption = gReloadButtonCaption
        Else
            fCaption = "Disabled"
        End If
        fPictureFilename = gReloadButtonImage
        fLayoutActionName = "actStadisReloadButton"
        fChecked = True
        fEnabled = gReloadButtonEnabled
        fGUID = New Guid(Discover.CLASS_ButtonReload)
        fBusinessObjectType = Plugins.BusinessObjectType.btInvoice
    End Sub  'Initialize

    '----------------------------------------------------------------------------------------------
    ' Called when button is clicked
    '----------------------------------------------------------------------------------------------
    Public Overrides Function HandleEvent() As Boolean
        If gReloadButtonActive = True Then
            Dim mFrmReload As New FrmReload
            mFrmReload.Adapter = fAdapter
            mFrmReload.ShowDialog()
            mFrmReload = Nothing
        End If
        Return MyBase.HandleEvent()
    End Function  'HandleEvent

    '----------------------------------------------------------------------------------------------
    ' Enables/disables button based on Receipt Type
    '----------------------------------------------------------------------------------------------
    Public Overrides ReadOnly Property ButtonEnabled() As Boolean
        Get
            If gIsAReturn = False Then
                fEnabled = True
            Else
                fEnabled = False
            End If
            Return MyBase.Enabled
        End Get
    End Property

End Class  'ButtonReload
