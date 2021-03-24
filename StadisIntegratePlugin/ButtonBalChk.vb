Imports System.Runtime.InteropServices
Imports System.Windows.Forms
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
        fBusinessObjectType = Plugins.BusinessObjectType.btInvoice
    End Sub  'Initialize

    '----------------------------------------------------------------------------------------------
    ' Called when button is clicked
    '----------------------------------------------------------------------------------------------
    Public Overrides Function HandleEvent() As Boolean

        'delete the below
        'MsgBox("buttonBalChk")
        'Dim intProcessID = 0
        'intProcessID = Process.GetCurrentProcess().Id
        'MsgBox("process id " & CStr(intProcessID))
        'Exit Function
        'delete the above




        If gBalChkButtonActive = True Then
            Dim mFrmBalChk As New FrmBalChk
            'mFrmBalChk.Adapter = fAdapter
            mFrmBalChk.ShowDialog()
            mFrmBalChk = Nothing
        End If
        Return MyBase.HandleEvent()
    End Function  'HandleEvent

End Class  'ButtonBalChk
