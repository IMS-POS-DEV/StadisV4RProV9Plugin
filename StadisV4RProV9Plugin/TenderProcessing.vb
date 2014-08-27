Imports CommonV4
Imports System
Imports RetailPro.CustomPluginClasses
Imports RetailPro.Plugins
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
'----------------------------------------------------------------------------------------------
'   Class: TenderProcessing
'    Type: 
' Purpose: 
'----------------------------------------------------------------------------------------------
<GuidAttribute(Discover.CLASS_TenderProcessing)> _
Public Class TenderProcessing
    Inherits TCustomTenderPlugin

    Private Shared Ctr As Integer = 0

    '----------------------------------------------------------------------------------------------
    ' Called when plugin is loaded
    '----------------------------------------------------------------------------------------------
    Public Overrides Sub Initialize()
        'MessageBox.Show("Initialize EFT", "DEBUG")
        MyBase.Initialize()
        fEnabled = True
        If fEnabled = False Then
            MessageBox.Show("TenderPlugin disabled", "DEBUG")
        End If
        fGUID = New Guid(Discover.CLASS_TenderProcessing)
        fBusinessObjectType = RetailPro.Plugins.BusinessObjectType.btTender
    End Sub  'Initialize

    '----------------------------------------------------------------------------------------------
    ' 
    '----------------------------------------------------------------------------------------------
    Public Overrides Function PluginCapability(ACapability As Integer) As Boolean
        MessageBox.Show("PluginCapability", "DEBUG")
        If ACapability = 0 Then
            Return True
        Else
            Return False
        End If
    End Function  'PluginCapability

    'Public Function HandleBOUIEvent(ByVal ABOHandle As Integer, ByVal AEventType As String, ByVal AParameters As String, ByRef AReturnValues As String, ByRef AHandled As Boolean) As Boolean
    '    MessageBox.Show("HandleBOUIEvent", "DEBUG")
    'End Function  'HandleBOUIEvent

    'Public Overrides Function Prepare() As Boolean
    '    MessageBox.Show("Prepare", "DEBUG")
    '    Return MyBase.Prepare()
    'End Function  'Prepare

    '----------------------------------------------------------------------------------------------
    ' 
    '----------------------------------------------------------------------------------------------
    Public Overrides Function HandleEvent() As Boolean
        MessageBox.Show("HandleEvent", "DEBUG")
        Return MyBase.HandleEvent()
    End Function  'HandleEvent

    '----------------------------------------------------------------------------------------------
    ' 
    '----------------------------------------------------------------------------------------------
    Public Overrides Function AddTender(TenderType As Integer, ByRef Data As String) As Integer
        MessageBox.Show("AddTender " & TenderType.ToString & " " & Data, "DEBUG")
        Dim ret As Integer = MyBase.AddTender(TenderType, Data)
        'Ctr += 1
        'Dim ret As Integer = Ctr
        MessageBox.Show("ret " & ret.ToString, "DEBUG")
        Return ret
    End Function  'AddTender

    ''----------------------------------------------------------------------------------------------
    '' 
    ''----------------------------------------------------------------------------------------------
    'Public Overrides Function Settle(TenderType As Integer, All As Boolean) As Boolean
    '    MessageBox.Show("Settle", "DEBUG")
    '    Return MyBase.Settle(TenderType, All)
    'End Function  'Settle

    ''----------------------------------------------------------------------------------------------
    '' 
    ''----------------------------------------------------------------------------------------------
    'Public Overrides Function IsTenderActiveInBatch(TenderID As String) As Boolean
    '    MessageBox.Show("IsTenderActiveInBatch", "DEBUG")
    '    Return MyBase.IsTenderActiveInBatch(TenderID)
    'End Function  'IsTenderActiveInBatch

    '----------------------------------------------------------------------------------------------
    ' 
    '----------------------------------------------------------------------------------------------
    Public Overrides Function CancelTransaction() As Boolean
        MessageBox.Show("CancelTransaction", "DEBUG")
        Return MyBase.CancelTransaction()
    End Function  'CancelTransaction

    '----------------------------------------------------------------------------------------------
    ' 
    '----------------------------------------------------------------------------------------------
    Public Overrides Function CommitTransaction() As Boolean
        MessageBox.Show("CommitTransaction", "DEBUG")
        Return MyBase.CommitTransaction()
    End Function  'CommitTransaction

    '----------------------------------------------------------------------------------------------
    ' 
    '----------------------------------------------------------------------------------------------
    Public Overrides Function RemoveTender(TenderIndex As Integer) As Boolean
        MessageBox.Show("RemoveTender " & TenderIndex.ToString, "DEBUG")
        Return MyBase.RemoveTender(TenderIndex)
    End Function  'RemoveTender

    '----------------------------------------------------------------------------------------------
    ' 
    '----------------------------------------------------------------------------------------------
    Public Overrides Function StartTransaction() As Boolean
        MessageBox.Show("StartTransaction", "DEBUG")
        Return MyBase.StartTransaction()
    End Function  'StartTransaction

End Class  'TenderProcessing
