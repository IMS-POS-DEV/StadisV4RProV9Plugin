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

'Public Class TCustomSideButtonPlugin
'    Inherits TCustomBOPlugin
'    Implements ISideButtonPlugin
'    Protected fCaption As String
'    Protected fHint As String
'    Protected fPictureFilename As String
'    Protected fLayoutActionName As String
'    Protected fButtonEnabled As Boolean
'    Protected fChecked As Boolean
'    Protected fBOUIEventsSupported As Object

'    '*
'    '        ButtonEnabled controls whether the button is available
'    '        or grayed out.  This property is checked several times
'    '        a second, allowing the plugin to react to changes in
'    '        the application, so the logic within the Get_ButtonEnabled
'    '        getter must be succinct.
'    '        

'    Public Overridable ReadOnly Property ButtonEnabled() As Boolean
'        Get
'            Return fButtonEnabled
'        End Get
'    End Property
'    '*
'    '        Caption contains the text displayed on the button
'    '        face.
'    '        

'    Public Overridable ReadOnly Property Caption() As String
'        Get
'            Return fCaption
'        End Get
'    End Property
'    '*
'    '        This controls whether the button face includes a check
'    '        mark.
'    '        

'    Public Overridable ReadOnly Property Checked() As Boolean
'        Get
'            Return fChecked
'        End Get
'    End Property
'    '*
'    '        Hint contains the fly-over help text shown to the user
'    '        when the mouse idles over the button control.
'    '        

'    Public Overridable ReadOnly Property Hint() As String
'        Get
'            Return fHint
'        End Get
'    End Property
'    '*
'    '        LayoutActionName is the text used to name the action
'    '        Instance.
'    '        

'    Public Overridable ReadOnly Property LayoutActionName() As String
'        Get
'            Return fLayoutActionName
'        End Get
'    End Property
'    '*
'    '        PictureFilename is the name of a BMP file on disk that
'    '        is used as the glyph for the button face.
'    '        

'    Public Overridable ReadOnly Property PictureFilename() As String
'        Get
'            Return fPictureFilename
'        End Get
'    End Property
'    '*
'    '        This property controls whether the button can be added
'    '        to a side menu via the layout manager.  This should
'    '        always be set to TRUE.
'    '        

'    Public Overridable ReadOnly Property UseLayoutManager() As Boolean
'        Get
'            Return True
'        End Get
'    End Property
'    Public Overridable ReadOnly Property BOUIEventsSupported() As Object
'        Get
'            Return fBOUIEventsSupported
'        End Get
'    End Property
'    Public Overridable Function HandleBOUIEvent(ABOHandle As Integer, AEventType As String, AParameters As Object, ByRef AReturnValues As Object, ByRef AHandled As Boolean) As Boolean
'        Return False
'    End Function
'End Class

Public Class TCustomSideButtonPlugin
    Inherits TCustomBOPlugin
    Implements ISideButtonPlugin

    Protected fCaption As String
    Protected fHint As String
    Protected fPictureFilename As String
    Protected fLayoutActionName As String
    Protected fButtonEnabled As Boolean
    Protected fChecked As Boolean
    Protected fBOUIEventsSupported As Object

    ' ButtonEnabled controls whether the button is available or grayed out.  
    ' This property is checked several times a second, allowing the plugin to react to changes
    ' in the application, so the logic within the Get_ButtonEnabled getter must be succinct.
    Public Overridable ReadOnly Property ButtonEnabled() As Boolean
        Get
            Return fButtonEnabled
        End Get
    End Property

    ' Caption contains the text displayed on the button face.
    Public Overridable ReadOnly Property Caption() As String
        Get
            Return fCaption
        End Get
    End Property

    ' This controls whether the button face includes a check mark.
    Public Overridable ReadOnly Property Checked() As Boolean
        Get
            Return fChecked
        End Get
    End Property

    'Hint contains the fly-over help text shown to the user when the mouse idles over the button control.
    Public Overridable ReadOnly Property Hint() As String
        Get
            Return fHint
        End Get
    End Property

    ' LayoutActionName is the text used to name the action Instance.
    Public Overridable ReadOnly Property LayoutActionName() As String
        Get
            Return fLayoutActionName
        End Get
    End Property

    ' PictureFilename is the name of a BMP file on disk that is used as the glyph for the button face.
    Public Overridable ReadOnly Property PictureFilename() As String
        Get
            Return fPictureFilename
        End Get
    End Property

    ' This property controls whether the button can be added to a side menu via the layout manager.  
    ' This should always be set to TRUE.
    Public Overridable ReadOnly Property UseLayoutManager() As Boolean
        Get
            Return True
        End Get
    End Property

    Public Overridable ReadOnly Property BOUIEventsSupported() As Object
        Get
            Return fBOUIEventsSupported
        End Get
    End Property

    Public Overridable Function HandleBOUIEvent(ABOHandle As Integer, AEventType As String, AParameters As Object, ByRef AReturnValues As Object, ByRef AHandled As Boolean) As Boolean
        Return False
    End Function

    Public Property Adapter2 As IPluginAdapter Implements ISideButtonPlugin.Adapter

    Public ReadOnly Property BusinessObjectType2 As Integer Implements ISideButtonPlugin.BusinessObjectType
        Get

        End Get
    End Property

    Public ReadOnly Property ButtonEnabled1 As Boolean Implements ISideButtonPlugin.ButtonEnabled
        Get

        End Get
    End Property

    Public ReadOnly Property Caption1 As String Implements ISideButtonPlugin.Caption
        Get

        End Get
    End Property

    Public ReadOnly Property Checked1 As Boolean Implements ISideButtonPlugin.Checked
        Get

        End Get
    End Property

    Public Sub CleanUp2() Implements ISideButtonPlugin.CleanUp

    End Sub

    Public ReadOnly Property Description2 As String Implements ISideButtonPlugin.Description
        Get

        End Get
    End Property

    Public Property Enabled2 As Boolean Implements ISideButtonPlugin.Enabled

    Public ReadOnly Property GUID2 As System.Guid Implements ISideButtonPlugin.GUID
        Get

        End Get
    End Property

    Public Function HandleEvent2() As Boolean Implements ISideButtonPlugin.HandleEvent

    End Function

    Public ReadOnly Property Hint1 As String Implements ISideButtonPlugin.Hint
        Get

        End Get
    End Property

    Public ReadOnly Property LayoutActionName1 As String Implements ISideButtonPlugin.LayoutActionName
        Get

        End Get
    End Property

    Public ReadOnly Property PictureFilename1 As String Implements ISideButtonPlugin.PictureFilename
        Get

        End Get
    End Property

    Public Function PluginCapability1(ACapability As Integer) As Boolean Implements ISideButtonPlugin.PluginCapability

    End Function

    Public Function Prepare2() As Boolean Implements ISideButtonPlugin.Prepare

    End Function

    Public ReadOnly Property Priority2 As PluginPriority Implements ISideButtonPlugin.Priority
        Get

        End Get
    End Property

    Public ReadOnly Property UseLayoutManager1 As Boolean Implements ISideButtonPlugin.UseLayoutManager
        Get

        End Get
    End Property

End Class

