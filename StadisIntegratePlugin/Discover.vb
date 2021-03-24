Imports System.Runtime.InteropServices
'----------------------------------------------------------------------------------------------
'   Class: Discover
'    Type: Plugin Discovery
' Purpose: Tells Retail Pro what plugin classes are contained in the plugin module.
'          Pointed to by mnf file.
'          Used during startup to load and intialize plugins
'----------------------------------------------------------------------------------------------
<GuidAttribute(Discover.CLASS_Discover)> _
Public Class Discover
    Inherits TCustomDiscoverPlugin
    Public Const CLASS_Discover As String = "E289ADE2-1050-4AA5-8EDC-2AFEF2020074"
    Public Const CLASS_Configure As String = "866E43B2-9963-4521-A9D7-57307062C188"
    Public Const CLASS_ButtonIssue As String = "C47476F5-C9DA-469A-B038-D6D144DEB5A8"
    Public Const CLASS_ButtonReturn As String = "BC9FA2A8-48B3-4703-B994-54268D22230C"
    Public Const CLASS_ButtonBalChk As String = "44D454B8-9A28-449D-AD11-8658EA3A829D"
    Public Const CLASS_ButtonReload As String = "510A1D0D-44C3-42ED-8283-B56752BB69CF"
    Public Const CLASS_TenderDialogue As String = "5B2B7574-5817-419B-A1C2-A46D7D371895"
    Public Const CLASS_TenderProcessing As String = "DDDFC9D1-4D2A-40FD-AE09-12C6B5F96F7C"
    Public Const CLASS_PrintUpdateStadisProcessing As String = "E547B6A9-6EDE-4861-AAFC-BC5EF6810A53"
    Public Const CLASS_RetCheck As String = "513160D1-5D31-4685-BA56-D716AB2E765E"
    Public Const CLASS_TenderDialogue2 As String = "C836027E-B95C-47FC-BD19-1A0D3AE2E221"

    Public Overrides Function PluginGUIDs() As Object
        Dim classIDs(9) As String
        classIDs(0) = CLASS_Configure
        classIDs(1) = CLASS_ButtonIssue
        classIDs(2) = CLASS_ButtonReturn
        classIDs(3) = CLASS_ButtonBalChk
        classIDs(4) = CLASS_ButtonReload
        classIDs(5) = CLASS_TenderDialogue
        classIDs(6) = CLASS_TenderProcessing
        classIDs(7) = CLASS_PrintUpdateStadisProcessing
        classIDs(8) = CLASS_RetCheck
        classIDs(9) = CLASS_TenderDialogue2
        Return classIDs
    End Function  'PluginGUIDs

    ' Retail Pro's Notes:
    '
    '   A Note on VB Namespaces:
    '   Do not create a namespace here, set your Namespace in "MyProject" -> "Application" tab
    '   "Root Namespace". While it is perfectly legal to create "Local" Namespace here, your 
    '   COM server will be Registered in Windows as "RootNamespace.LocalNamespace.Discover"
    '   RetailPro will complain because it is looking for the format of "ServerName.DiscoverClassName"
    '   
    '   This note pertains to step #4 below, having the IDE register your plugin for you. 
    '   Please see the Microsoft help files for guidance if you are going to register it 
    '   yourself with the Gacutil and RegAsm utilities. 
    '
    '***
    '
    ' Some key points in getting your plugin up and running:
    ' 
    ' In References: 
    ' 		1) Add:
    ' 			a) CustomPluginClasses
    ' 			b) MSXML
    ' 			c) Plugins
    ' 
    '    In Imports clause:
    '      2) Add
    ' 			a) CustomPluginClasses;
    ' 			b) System.Runtime.InteropServices;
    '  
    ' 	  In My Project:
    '      3) Application Tab:
    ' 			OutPut type = Class Library
    ' 			Click "Assembly Information" and check "Make assembly COM-Visible"
    '      
    '      4) Build Tab:
    ' 			In the Output section, check "Register for COM interop".
    ' 
    ' 		5) Signing Tab:
    ' 			Check "Sign the assembly"
    ' 			In the combobox titled "Choose a strong name key file:" 
    ' 			select <New...> (Add a name and password. !!!NOTE: Make sure to right it down!!!)
    '  
    '    Plugin Manifest file:
    '      6)  In VB the "ServerName" that you will place in the manifest file should be 
    '          the same as the "Root Namespace" Applications Tab. In this case it should 
    '          Look like this "StadisIntegratePlugin.Discover". This can be confusing when you 
    '          have a "Project name", "Assembly name", "Local Namespace". If you put the wrong
    '          server name in the manifet file, Retail Pro will complain. To be sure what 
    '          RetailPro is looking for, you can search the Registry for "YourServerName". 
    '          When you find the "YourServerName.DiscoveryClassName", that is the name to go 
    '          into the Manifest file. Also, Retail Pro does not support "AutoReg" flag with 
    '          .Net com servers, you have to register them manually or create a script.
    '
    '***
    '
    ' It is very important to decorate your plugin classes with the following Attributes:
    ' 
    '     <GuidAttribute(Discover.CLASS_DiscoverPlugin)>
    ' 
    ' The Guid MUST be generated for YOUR plugin! Do not copy these Guids as they will conflict
    ' with your next Plugin you create. Each plugin must have is own unique Guid.
    ' To generate a guid for your plugin, choose the "Tools" > "Create GUID" menu, GUID format #4, 
    ' copy and paste in two places: In your Public constant and in the Guid attribtue 
    ' as below. Make sure to do it for each and every plugin class you implement.

    '  To debug a .net plugin while Retail Pro is running follow these steps.
    '  On the "My Project"->"Debug" tab, click the "Start Action" radio button labeled 
    '  "Start external program" and enter the path of your Retail Pro exe ("C:\RetailPro9\RPRO9.exe").
    '
    '  In "Start Options" you can put in any Retail Pro comman line parameters you want.
    '  and you can leave the working directory empty. 
    '
    '  In "Enable Debuggers" check "Enable unmanaged code debugging"
    '
    '  Add any break points you wnat in your code, press (F5) to start debugging.

End Class  'Discover

