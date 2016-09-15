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


'Public Class TCustomBOPlugin
'    Inherits TCustomAbstractPlugin
'    Implements IBOPlugin
'    Protected fBusinessObjectType As Integer
'    Public Overridable ReadOnly Property BusinessObjectType() As Integer
'        Get
'            Return fBusinessObjectType
'        End Get
'    End Property
'End Class

Public Class TCustomBOPlugin
    Inherits TCustomAbstractPlugin
    Implements IBOPlugin

    Protected fBusinessObjectType As Integer
    Public Overridable ReadOnly Property BusinessObjectType() As Integer
        Get
            Return fBusinessObjectType
        End Get
    End Property

    Public Property Adapter1 As IPluginAdapter Implements IBOPlugin.Adapter

    Public ReadOnly Property BusinessObjectType1 As Integer Implements IBOPlugin.BusinessObjectType
        Get

        End Get
    End Property

    Public Sub CleanUp1() Implements IBOPlugin.CleanUp

    End Sub

    Public ReadOnly Property Description1 As String Implements IBOPlugin.Description
        Get

        End Get
    End Property

    Public Property Enabled1 As Boolean Implements IBOPlugin.Enabled

    Public ReadOnly Property GUID1 As System.Guid Implements IBOPlugin.GUID
        Get

        End Get
    End Property

    Public Function HandleEvent1() As Boolean Implements IBOPlugin.HandleEvent

    End Function

    Public Function Prepare1() As Boolean Implements IBOPlugin.Prepare

    End Function

    Public ReadOnly Property Priority1 As PluginPriority Implements IBOPlugin.Priority
        Get

        End Get
    End Property
End Class
