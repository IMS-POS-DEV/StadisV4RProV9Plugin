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

' The Workstaion class contains two(2) memebers:
'     Path() and Name() which provide the consumer with a Workstation Path and Workstation name 
' consistant with what RetailPro provides/expects.
Public NotInheritable Class WorkStation

    Private Sub New()
    End Sub

    Public Shared Function Path() As String
        '     Path() returns the "CurrentDirectory" of the plugin with "\Workstations\" concatenated to it. 
        '     If the "\Workstations\" directory does not exist, it will be created.
        ' Example:
        '     "C:\RetailPro9\Workstations\
        Try
            Dim WSPath As String = Environment.CurrentDirectory + "\Workstations\"
            If Not Directory.Exists(WSPath) Then
                Directory.CreateDirectory(WSPath)
            End If
            Return WSPath
        Catch Ex As Exception
            Throw Ex
        End Try
    End Function  'Path

    Public Shared Function Name() As String
        '   Name() returns the Full Computer Name and User name or workgroup name concatenated in the following format:
        '   Inside a Domain:
        '     with "Full Computer Name" = "tsmith-wks.retailpro.com" and "Domain" = "retailpro.com"
        '       Name() returns: retailpro_com_JSMITH_WKS
        '
        '   Inside a Workgroup:
        '     with "Full Computer Name" = "dotNet-Test" and "Workgroup" = "CUSTOM-VMS"
        '       Name() returns: CUSTOM_VMS_DOTNET_TEST
        ' 
        '   If an exception is thrown Name() returns SystemInformation.UserDomainName, and if this throws an exception
        '   Name() returns "unknown". Most importantly we catch ALL exception within this routine so as to not allow 
        '   the exception to propagate to RetailPro.

        Dim sb As New StringBuilder()

        Try
            Dim replaceChars As String = ".-/\ "
            Dim Domain As String = ""
            Dim NewName As String = ""

            Dim query As New SelectQuery("SELECT * FROM Win32_ComputerSystem")
            Dim searcher As New ManagementObjectSearcher(query)
            For Each mo As ManagementObject In searcher.[Get]()
                Domain = mo("domain").ToString()
                NewName = mo("name").ToString()
            Next
            sb.Append(Convert.ToString(Domain & Convert.ToString("_")) & NewName)
            For Each c As Char In replaceChars
                sb.Replace(c.ToString(), "_")
            Next
            Return sb.ToString()
        Catch
            Try
                Return SystemInformation.UserDomainName
            Catch
                Return "unknown"
            End Try
        End Try

    End Function  'Name

End Class  'WorkStation
