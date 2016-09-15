Imports stdole
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Windows
Imports System.Windows.Forms
Imports System.Windows.Controls
Imports System.Security.Principal
Imports System.Management
Imports System.Reflection
Imports MSXML
Imports RetailPro.Plugins

' *** Disclaimer ***
'
' THIS SOFTWARE IS PROVIDED "AS IS" AND ANY EXPRESSED OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, 
' THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT 
' SHALL THE REGENTS OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR 
' CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; 
' LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, 
' WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT 
' OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
'

Public Class TCustomAbstractPlugin
    Inherits [Object]
    Implements IAbstractPlugin

    '        protected fAdapter as TCustomPluginAdapter
    Protected fAdapter As IPluginAdapter

    Protected fDescription As String
    Protected fEnabled As Boolean
    Protected fGUID As System.Guid
    Protected fPriority As PluginPriority
    Protected Shared fLogger As Logger
    Protected Shared fLogName As String
    Protected fBOHandle As Integer

    Public Sub New()
        'fAdapter = TCustomPluginAdapter.fAdapter;
        Initialize()
    End Sub

#Region "Overloaded Logging methods"

    '    These methods are set to overridable to give the Plugin developer the flexibility to turn
    '    off logging by overriding the Log methods and implement them as an empty method without 
    '    calling base. 
    '    (Example:) 
    'Public Overrides Sub Log(strLog As String, AValue As String, LogType As TLogType, LogLevel As TLogLevel)
    '    'base.Log...
    'End Sub  

    Public Overridable Sub Log(strLog As String, LogType As TLogType, LogLevel As TLogLevel)
        Dim sValue As String = String.Empty
        If (LogType = TLogType.ltBeginMethod) OrElse (LogType = TLogType.ltEndMethod) Then
            'This strips out the namespace.
            'strLog = strLog.Substring(1 + GetType().ToString().LastIndexOf("."));
            Select Case LogType
                Case TLogType.ltBeginMethod
                    sValue = strLog.PadRight(40, "-"c) + " = < *** BEGIN *** >"
                    Exit Select
                Case TLogType.ltEndMethod
                    sValue = strLog.PadRight(40, "-"c) + " = < ***  END  *** >"
                    Exit Select
            End Select
            LogType = TLogType.ltMethod
        End If
        fLogger.Log(sValue, LogType, LogLevel)
    End Sub

    Public Overridable Sub Log(strLog As String, AValue As String, LogType As TLogType, LogLevel As TLogLevel)
        fLogger.Log((Convert.ToString(strLog.PadRight(40, " "c) + " = < ") & AValue) + " >", LogType, LogLevel)
    End Sub

    Public Overridable Sub Log(strLog As String, AValue As Decimal, LogType As TLogType, LogLevel As TLogLevel)
        fLogger.Log(strLog.PadRight(40, " "c) + " = < " + AValue.ToString() + " >", LogType, LogLevel)
    End Sub

    Public Overridable Sub Log(strLog As String, AValue As Integer, LogType As TLogType, LogLevel As TLogLevel)
        fLogger.Log(strLog.PadRight(40, " "c) + " = < " + AValue.ToString() + " >", LogType, LogLevel)
    End Sub

    Public Overridable Sub Log(strLog As String, AValue As Boolean, LogType As TLogType, LogLevel As TLogLevel)
        fLogger.Log(strLog.PadRight(40, " "c) + " = < " + AValue.ToString() + " >", LogType, LogLevel)
    End Sub

    Public Overridable Sub Log(strLog As String, AValue As DateTime, LogType As TLogType, LogLevel As TLogLevel)
        fLogger.Log(strLog.PadRight(40, " "c) + " = < " + AValue.ToString() + " >", LogType, LogLevel)
    End Sub

    Public Overridable Sub Log(strLog As String, AValue As Double, LogType As TLogType, LogLevel As TLogLevel)
        fLogger.Log(strLog.PadRight(40, " "c) + " = < " + AValue.ToString() + " >", LogType, LogLevel)
    End Sub

#End Region

    Public Property Adapter() As IPluginAdapter Implements IAbstractPlugin.Adapter
        'get { return ( fAdapter as IPluginAdapter ); }
        'set { fAdapter = ( value as TCustomPluginAdapter ); }
        Get
            ' MessageBox.Show("Get_Adapter");
            Return fAdapter
        End Get
        Set(value As IPluginAdapter)
            ' MessageBox.Show("Set_Adapter");
            fAdapter = value
        End Set
    End Property

    Public Overridable ReadOnly Property Description() As String Implements IAbstractPlugin.Description
        Get
            Return fDescription
        End Get
    End Property

    Public Overridable Property Enabled() As Boolean Implements IAbstractPlugin.Enabled
        Get
            Return fEnabled
        End Get
        Set(value As Boolean)
            fEnabled = value
        End Set
    End Property

    Public Overridable ReadOnly Property GUID() As System.Guid Implements IAbstractPlugin.GUID
        Get
            Return fGUID
        End Get
    End Property

    Public Overridable ReadOnly Property Priority() As PluginPriority Implements IAbstractPlugin.Priority
        Get
            Return fPriority
        End Get
    End Property

    Public Overridable Property LogName() As String
        Get
            Return fLogger.FileName
        End Get
        Set(value As String)
            fLogger.FileName = value
        End Set
    End Property

    Public Property LogLevel() As TLogLevel
        Get
            Return fLogger.LogLevel
        End Get
        Set(value As TLogLevel)
            fLogger.LogLevel = value
        End Set
    End Property

    Public Overridable Function HandleEvent() As Boolean Implements IAbstractPlugin.HandleEvent
        ' add your Event handling code in your decendant class.
        'Log([GetType]() + "." + MethodBase.GetCurrentMethod().Name, TLogType.ltBeginMethod, TLogLevel.logDEBUG)
        'Log([GetType]() + "." + MethodBase.GetCurrentMethod().Name, TLogType.ltEndMethod, TLogLevel.logDEBUG)
        'TDF Verified 03-23-2010
        ' Processing 
        ' Continue = False
        ' Abort    = True
        Return False
    End Function  'HandleEvent

    Public Overridable Sub Initialize()
        '***************************************************************
        '           In your overridden descendent method set these values:
        '           fDescription        := 'This is the description of my Plugin';
        '           fGUID               := CLASS_WayCoolPlugin;
        '        ***************************************************************
        fDescription = "CustomAbstractPlugin"
        fLogName = "CustomPlugin"
        fAdapter = Nothing
        fBOHandle = 0
        fEnabled = True
        fPriority = PluginPriority.ppNormal
        fLogger = Logger.Instance
    End Sub  'Initialize

    Public Overridable Function Prepare() As Boolean Implements IAbstractPlugin.Prepare
        'Log([GetType]() + "." + MethodBase.GetCurrentMethod().Name, TLogType.ltBeginMethod, TLogLevel.logDEBUG)
        '            Log("Adapter.Enabled", Adapter.Enabled, TLogType.ltData, TLogLevel.logDEBUG);
        'Log([GetType]() + "." + MethodBase.GetCurrentMethod().Name, TLogType.ltEndMethod, TLogLevel.logDEBUG)
        ' TDF Verified 03-23-2010
        ' Continue = true
        ' Abort    = False
        Return True
    End Function  'Prepare

    Public Overridable Sub CleanUp() Implements IAbstractPlugin.CleanUp
        'Log([GetType]() + "." + MethodBase.GetCurrentMethod().Name, TLogType.ltBeginMethod, TLogLevel.logDEBUG)
        fAdapter = Nothing
        'Log("fAdapter", "null", TLogType.ltData, TLogLevel.logDEBUG)
        'Log([GetType]() + "." + MethodBase.GetCurrentMethod().Name, TLogType.ltEndMethod, TLogLevel.logDEBUG)
    End Sub  'CleanUp

    Public Overridable Function Capability(ACapability As Integer) As Boolean
        'Log([GetType]() + "." + MethodBase.GetCurrentMethod().Name, TLogType.ltBeginMethod, TLogLevel.logDEBUG)
        'Log("ACapability", ACapability, TLogType.ltData, TLogLevel.logDEBUG)
        'Log("If capability not supported, return", False, TLogType.ltData, TLogLevel.logDEBUG)
        'Log([GetType]() + "." + MethodBase.GetCurrentMethod().Name, TLogType.ltEndMethod, TLogLevel.logDEBUG)
        ' TDF Verified 03-23-2010
        ' Plugin implements Capability(x)
        ' True or False
        Return False
    End Function  'Capability

    Public Overridable Function PluginCapability(ACapability As Integer) As Boolean
        'Log([GetType]() + "." + MethodBase.GetCurrentMethod().Name, TLogType.ltBeginMethod, TLogLevel.logDEBUG)
        'Log("ACapability", ACapability, TLogType.ltData, TLogLevel.logDEBUG)
        'Log("If PluginCapability not supported, return", False, TLogType.ltData, TLogLevel.logDEBUG)
        'Log([GetType]() + "." + MethodBase.GetCurrentMethod().Name, TLogType.ltEndMethod, TLogLevel.logDEBUG)
        '' TDF Verified 03-23-2010
        ' Plugin implements PluginCapability(x)
        ' True or False
        Return False
    End Function  'PluginCapability

End Class  'TCustomAbstractPlugin

