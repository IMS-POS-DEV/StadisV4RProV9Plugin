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

'Public Class TCustomAttributePlugin
'    Inherits TCustomBOPlugin
'    Implements IAttributePlugin
'    Protected fAttributeName As String
'    Protected fPermission As Integer
'    Protected fPermType As Integer

'    Public Overridable Property AttributeName() As String
'        Get
'            Return fAttributeName
'        End Get
'        Set(value As String)
'            fAttributeName = value
'        End Set
'    End Property
'    Public Overridable Function AttrPermissionEnabled(APermission As Integer, APermType As Integer) As Integer
'        ' This method is called quite often (9 times per attribute, 5 for APermission ,4 for APermType 
'        ' it's best not to log here.
'        Return CInt(AttributePermissionsEnabled.apeIgnore)
'    End Function
'End Class

Public Class TCustomAttributePlugin
    Inherits TCustomBOPlugin
    Implements IAttributePlugin

    Protected fAttributeName As String
    Protected fPermission As Integer
    Protected fPermType As Integer

    Public Overridable Property AttributeName() As String
        Get
            Return fAttributeName
        End Get
        Set(value As String)
            fAttributeName = value
        End Set
    End Property
    Public Overridable Function AttrPermissionEnabled(APermission As Integer, APermType As Integer) As Integer
        ' This method is called quite often (9 times per attribute, 5 for APermission ,4 for APermType 
        ' it's best not to log here.
        Return CInt(AttributePermissionsEnabled.apeIgnore)
    End Function

    Public Property Adapter As IPluginAdapter Implements IAbstractPlugin.Adapter

    Public Sub CleanUp() Implements IAbstractPlugin.CleanUp

    End Sub

    Public ReadOnly Property Description As String Implements IAbstractPlugin.Description
        Get

        End Get
    End Property

    Public Property Enabled As Boolean Implements IAbstractPlugin.Enabled

    Public ReadOnly Property GUID As System.Guid Implements IAbstractPlugin.GUID
        Get

        End Get
    End Property

    Public Function HandleEvent() As Boolean Implements IAbstractPlugin.HandleEvent

    End Function

    Public Function Prepare() As Boolean Implements IAbstractPlugin.Prepare

    End Function

    Public ReadOnly Property Priority As PluginPriority Implements IAbstractPlugin.Priority
        Get

        End Get
    End Property

    Public Property Adapter1 As IPluginAdapter Implements IAttributePlugin.Adapter

    Public Property AttributeName1 As String Implements IAttributePlugin.AttributeName

    Public Function AttrPermissionEnabled1(APermission As Integer, APermType As Integer) As Integer Implements IAttributePlugin.AttrPermissionEnabled

    End Function

    Public ReadOnly Property BusinessObjectType As Integer Implements IAttributePlugin.BusinessObjectType
        Get

        End Get
    End Property

    Public Sub CleanUp1() Implements IAttributePlugin.CleanUp

    End Sub

    Public ReadOnly Property Description1 As String Implements IAttributePlugin.Description
        Get

        End Get
    End Property

    Public Property Enabled1 As Boolean Implements IAttributePlugin.Enabled

    Public ReadOnly Property GUID1 As System.Guid Implements IAttributePlugin.GUID
        Get

        End Get
    End Property

    Public Function HandleEvent1() As Boolean Implements IAttributePlugin.HandleEvent

    End Function

    Public Function Prepare1() As Boolean Implements IAttributePlugin.Prepare

    End Function

    Public ReadOnly Property Priority1 As PluginPriority Implements IAttributePlugin.Priority
        Get

        End Get
    End Property

    Public Property Adapter2 As IPluginAdapter Implements IBOPlugin.Adapter

    Public ReadOnly Property BusinessObjectType1 As Integer Implements IBOPlugin.BusinessObjectType
        Get

        End Get
    End Property

    Public Sub CleanUp2() Implements IBOPlugin.CleanUp

    End Sub

    Public ReadOnly Property Description2 As String Implements IBOPlugin.Description
        Get

        End Get
    End Property

    Public Property Enabled2 As Boolean Implements IBOPlugin.Enabled

    Public ReadOnly Property GUID2 As System.Guid Implements IBOPlugin.GUID
        Get

        End Get
    End Property

    Public Function HandleEvent2() As Boolean Implements IBOPlugin.HandleEvent

    End Function

    Public Function Prepare2() As Boolean Implements IBOPlugin.Prepare

    End Function

    Public ReadOnly Property Priority2 As PluginPriority Implements IBOPlugin.Priority
        Get

        End Get
    End Property
End Class
