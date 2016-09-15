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

Public NotInheritable Class PluginUtils

    Private Sub New()
    End Sub

    Public Shared Function StrToStrDef(Value As String, [Default] As String) As String
        Return If(Value = "", [Default], Value)
    End Function  'StrToStrDef

    Public Shared Function StrToIntDef(Value As String, [Default] As Integer) As Integer
        Try
            Return Convert.ToInt32(Value)
        Catch
            Return [Default]
        End Try
    End Function  'StrToIntDef

    Public Shared Function StrToDecimalDef(Value As String, [Default] As Decimal) As Decimal
        Try
            Return Convert.ToDecimal(Value)
        Catch
            Return [Default]
        End Try
    End Function  'StrToDecimalDef

    Public Shared Function StrToBoolDef(Value As String, [Default] As Boolean) As Boolean
        Try
            Return Convert.ToBoolean(Value)
        Catch
            Return [Default]
        End Try
    End Function  'StrToBoolDef

End Class  'PluginUtils

