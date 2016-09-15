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

Public Class TCustomDiscoverPlugin
    Implements IDiscover

    Public Overridable Sub APIVersion(ByRef MajorVersion As Integer, ByRef MinorVersion As Integer, ByRef Revision As Integer) Implements IDiscover.APIVersion
        MajorVersion = 1
        MinorVersion = 2
        Revision = 0
    End Sub  'APIVersion

    Public Overridable Function PluginGUIDs() As Object Implements IDiscover.PluginGUIDs
        Dim ClassIDs As String() = New String(0) {}
        ' Example:
        '             * ClassIDs[0] = TCSharpPluginConstants.SideButtonPluginClSID; 
        '             
        Return ClassIDs
    End Function  'PluginGUIDs

    Public Overridable Function PluginModuleVersion() As String Implements IDiscover.PluginModuleVersion
        Return "1.0"
    End Function  'PluginModuleVersion

End Class  'TCustomDiscoverPlugin
