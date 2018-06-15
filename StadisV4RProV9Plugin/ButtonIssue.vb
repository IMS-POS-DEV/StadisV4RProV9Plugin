Imports CommonV4
Imports System
Imports CustomPluginClasses
Imports Plugins
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
        MyBase.Initialize()
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
