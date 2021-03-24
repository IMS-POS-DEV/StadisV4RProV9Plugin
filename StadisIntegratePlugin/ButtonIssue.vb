Imports System
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
'----------------------------------------------------------------------------------------------
'   Class: ButtonIssue
'    Type: SideButton - Invoice
' Purpose: Invokes FrmIssue to issue gift cards
'----------------------------------------------------------------------------------------------
<GuidAttribute(Discover.CLASS_ButtonIssue)> _
Public Class ButtonIssue
    Inherits TCustomSideButtonPlugin

    '----------------------------------------------------------------------------------------------
    ' Called when plugin is loaded
    '----------------------------------------------------------------------------------------------
    Public Overrides Sub Initialize()
        Dim blnTestMode As Boolean = False
        'blnTestMode = True
        If blnTestMode = True Then MsgBox("ButtonIssue.initialize test mode = true")
        If blnTestMode = True Then MsgBox("ButtonIssue.initialize ")
        If blnTestMode = True Then MsgBox("ButtonIssue.initialize calling mybase.initialize")
        MyBase.Initialize()

        If blnTestMode = True Then MsgBox("ButtonIssue.initialize calling loadlocalsettings")

        Common.LoadLocalSettings()
        If blnTestMode = True Then MsgBox("ButtonIssue.initialize calling loadinstallationsettings")

        Common.LoadInstallationSettings()
        If blnTestMode = True Then MsgBox("ButtonIssue.initialize loadinstallationsettings succeeded")

        If blnTestMode = True Then
            MsgBox("ButtonIssue.initialize gTappitInstallationSettingsFailed: " & CStr(gTappitInstallationSettingsFailed))
        End If

        If gTappitInstallationSettingsFailed = False Then
            If Trim(gTappitAPIKey) = "" Then
                gTappitInstallationSettingsFailed = True
                MsgBox("Setting TappitAPIKey is missing!")
            End If
            If Trim(gTappitBaseAddress) = "" Then
                gTappitInstallationSettingsFailed = True
                MsgBox("Setting TappitBaseAddressV6 is missing!")
            End If
        End If

        If gTappitInstallationSettingsFailed = False Then
            If blnTestMode = True Then MsgBox("ButtonIssue.initialize calling setuphttpclient")

            Try
                TappitAPI.SetUpHttpClient()
            Catch ex As Exception
                MsgBox("Failure setting up Tappit client" & vbCrLf & "api key: ' " & gTappitAPIKey & "'" & vbCrLf & "endpoint: " & gTappitBaseAddress)
                gTappitInstallationSettingsFailed = True
            End Try

            If blnTestMode = True Then MsgBox("ButtonIssue.initialize passed setuphttpclient")
        End If

        fButtonEnabled = gIssueButtonEnabled
        fHint = gIssueButtonHint
        If gIssueButtonEnabled = True Then
            fCaption = gIssueButtonCaption
        Else
            fCaption = "Disabled"
        End If
        fPictureFilename = gIssueButtonImage
        fLayoutActionName = "actStadisIssueButton"
        fChecked = True
        fEnabled = gIssueButtonEnabled
        fGUID = New Guid(Discover.CLASS_ButtonIssue)
        fBusinessObjectType = Plugins.BusinessObjectType.btInvoice
        If blnTestMode = True Then MsgBox("ButtonIssue.initialize finished")

    End Sub  'Initialize

    '----------------------------------------------------------------------------------------------
    ' Called when button is clicked
    '----------------------------------------------------------------------------------------------
    Public Overrides Function HandleEvent() As Boolean
        If gIssueButtonActive = True Then
            Dim mFrmIssue As New FrmIssue
            mFrmIssue.Adapter = fAdapter
            mFrmIssue.ShowDialog()
            mFrmIssue = Nothing
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

End Class  'ButtonIssue
