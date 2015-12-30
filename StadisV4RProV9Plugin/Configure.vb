Imports RetailPro.CustomPluginClasses
Imports RetailPro.Plugins
Imports System.Runtime.InteropServices
'----------------------------------------------------------------------------------------------
'   Class: Configure
'    Type: Configure
' Purpose: Manages setting of Stadis workstation preferences
'----------------------------------------------------------------------------------------------
<GuidAttribute(Discover.CLASS_Configure)> _
Public Class Configure
    Inherits TCustomConfigurePlugin

    '----------------------------------------------------------------------------------------------
    ' Called when plugin is loaded
    '----------------------------------------------------------------------------------------------
    Public Overrides Sub Initialize()
        MyBase.Initialize()
        fDescription = "STADIS V4 Workstation Preferences"
        fEnabled = True
        fGUID = New Guid(Discover.CLASS_Configure)
    End Sub  'Initialize

    '----------------------------------------------------------------------------------------------
    ' Called when "STADIS Workstation Preferences" is clicked in Preferences
    '----------------------------------------------------------------------------------------------
    Public Overrides Sub ConfigureAll()
        Dim mFrmConfigure As New FrmConfigure
        mFrmConfigure.ShowDialog()
        mFrmConfigure = Nothing
    End Sub  'HandleEvent

End Class  'Configure
