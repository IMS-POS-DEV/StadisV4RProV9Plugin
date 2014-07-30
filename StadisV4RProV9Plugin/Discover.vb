Imports RetailPro.CustomPluginClasses
Imports RetailPro.Plugins
Imports System.Runtime.InteropServices
'----------------------------------------------------------------------------------------------
'   Class: Discover
'    Type: Plugin Discovery
' Purpose: Tells Retail Pro what plugin classes are contained in the plugin module.
'          Pointed to by Stadis.mnf file.
'          Used during startup to load and intialize Stadis plugins
'----------------------------------------------------------------------------------------------
<GuidAttribute(Discover.CLASS_Discover)> _
Public Class Discover
    Inherits TCustomDiscoverPlugin

    Public Const CLASS_Discover As String = "4503F830-6A80-4d07-A76A-B1096A89675E"
    Public Const CLASS_ButtonRedeem As String = "8870F2ED-4D7B-400e-BCF3-A9F31EF6862A"
    Public Const CLASS_ButtonIssue As String = "6A78660B-4F9C-4930-A26B-20E34B8CF0FA"
    Public Const CLASS_ButtonReturn As String = "DDF40097-F0A7-4482-AAE2-5063F053717F"
    Public Const CLASS_ButtonBalChk As String = "20E62D4C-A4F6-4e3c-8012-B2450C9980B8"
    Public Const CLASS_ButtonReload As String = "286028C9-64CA-4743-A845-4EF380882079"
    Public Const CLASS_TenderProcessing As String = "DDF465F6-400e-4c4e-8EB1-E18B3A9465A8"
    Public Const CLASS_PrintUpdateStadisProcessing As String = "1AE665F6-3DDB-4c4e-8EB1-E18B3A9465A8"
    Public Const CLASS_Configure As String = "2C6467F5-5011-43ce-8361-7F9E9044D293"

    Public Overrides Function PluginGUIDs() As Object
        Dim classIDs(8) As String
        classIDs(0) = CLASS_ButtonRedeem
        classIDs(1) = CLASS_ButtonIssue
        classIDs(2) = CLASS_ButtonReturn
        classIDs(3) = CLASS_ButtonBalChk
        classIDs(4) = CLASS_ButtonReload
        classIDs(5) = CLASS_TenderProcessing
        classIDs(6) = CLASS_PrintUpdateStadisProcessing
        classIDs(7) = CLASS_Configure
        Return classIDs
    End Function  'PluginGUIDs

    '   A Note on VB Namespaces:
    '   Do not create a namespace here, set your Namespace in "MyProject" -> "Application" tab
    '   "Root Namespace". While it is perfectly legal to create "Local" Namespace here, your 
    '   COM server will be Registered in Windows as "RootNamespace.LocalNamespace.Discover"
    '   RetailPro will complain because it is looking for the format of "ServerName.DiscoverClassName"
    '   
    '   This is note pertains to step #4 below, having the IDE register your plugin for you. 
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
    ' 			a) RetailPro.CustomPluginClasses;
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
    '          Look like this "VBInvoiceSideButton.Discover". This can be confusing when you 
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

