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

'Public Class TCustomAttributeCalculationPlugin
'    Inherits TCustomAttributePlugin
'    Implements IAttributeCalculationPlugin
'End Class

Public Class TCustomAttributeCalculationPlugin
    Inherits TCustomAttributePlugin
    Implements IAttributeCalculationPlugin

    Public Property Adapter3 As IPluginAdapter Implements IAttributeCalculationPlugin.Adapter

    Public Property AttributeName2 As String Implements IAttributeCalculationPlugin.AttributeName

    Public Function AttrPermissionEnabled2(APermission As Integer, APermType As Integer) As Integer Implements IAttributeCalculationPlugin.AttrPermissionEnabled

    End Function

    Public ReadOnly Property BusinessObjectType2 As Integer Implements IAttributeCalculationPlugin.BusinessObjectType
        Get

        End Get
    End Property

    Public Sub CleanUp3() Implements IAttributeCalculationPlugin.CleanUp

    End Sub

    Public ReadOnly Property Description3 As String Implements IAttributeCalculationPlugin.Description
        Get

        End Get
    End Property

    Public Property Enabled3 As Boolean Implements IAttributeCalculationPlugin.Enabled

    Public ReadOnly Property GUID3 As System.Guid Implements IAttributeCalculationPlugin.GUID
        Get

        End Get
    End Property

    Public Function HandleEvent3() As Boolean Implements IAttributeCalculationPlugin.HandleEvent

    End Function

    Public Function PluginCapability1(ACapability As Integer) As Boolean Implements IAttributeCalculationPlugin.PluginCapability

    End Function

    Public Function Prepare3() As Boolean Implements IAttributeCalculationPlugin.Prepare

    End Function

    Public ReadOnly Property Priority3 As PluginPriority Implements IAttributeCalculationPlugin.Priority
        Get

        End Get
    End Property
End Class
