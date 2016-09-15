Imports System.IO
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Runtime.InteropServices
'Imports RetailPro.CustomPluginClasses

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

Public Class IniFile

    Private fPath As String

    Protected path As String
    Protected name As String

    <DllImport("kernel32")> _
    Private Shared Function WritePrivateProfileString(section As String, key As String, val As String, filePath As String) As Long
    End Function  'WritePrivateProfileString

    <DllImport("kernel32")> _
    Private Shared Function GetPrivateProfileString(section As String, key As String, def As String, retVal As StringBuilder, size As Integer, filePath As String) As Integer
    End Function  'GetPrivateProfileString

    Public Sub New(iniPath As String)
        Try
            fPath = System.IO.Path.GetDirectoryName(iniPath)
            If Not Directory.Exists(fPath) Then
                Directory.CreateDirectory(fPath)
            End If
            If Not File.Exists(iniPath) Then
                File.Create(iniPath)
            End If
            path = iniPath
        Catch
        End Try
    End Sub  'New

    Public Sub IniWriteValue(Section As String, Key As String, Value As String)
        WritePrivateProfileString(Section, Key, Value, Me.path)
    End Sub  'IniWriteValue

    Public Function IniReadValue(Section As String, Key As String) As String
        Dim temp As New StringBuilder(255)
        Dim i As Integer = GetPrivateProfileString(Section, Key, "", temp, 255, Me.path)
        Return temp.ToString()
    End Function  'IniReadValue

End Class  'IniFile