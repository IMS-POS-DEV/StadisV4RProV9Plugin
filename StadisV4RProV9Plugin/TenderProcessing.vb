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

    '----------------------------------------------------------------------------------------------
    ' Called when plugin is loaded
    '----------------------------------------------------------------------------------------------
    Public Overrides Sub Initialize()
        MessageBox.Show("Initialize EFT", "DEBUG")
        MyBase.Initialize()
        fEnabled = True
        fGUID = New Guid(Discover.CLASS_TenderProcessing)
        fBusinessObjectType = RetailPro.Plugins.BusinessObjectType.btTender
    End Sub  'Initialize

    '----------------------------------------------------------------------------------------------
    ' 
    '----------------------------------------------------------------------------------------------
    Public Overrides Function PluginCapability(ACapability As Integer) As Boolean
        MessageBox.Show("PluginCapability", "DEBUG")
        If ACapability = sbcHandleBOUIEvent Then
            Return True
        Else
            Return False
        End If
    End Function  'PluginCapability

    ''----------------------------------------------------------------------------------------------
    '' 
    ''----------------------------------------------------------------------------------------------
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
        MessageBox.Show("AddTender", "DEBUG")
        Return MyBase.AddTender(TenderType, Data)
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
        MessageBox.Show("RemoveTender", "DEBUG")
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
