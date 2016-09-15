Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.IO
Imports System.Windows.Forms
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

#Region "PUBLIC Enumerated Types DECLARATION"

Public Enum TLogLevel
    logNone
    logMinimal
    logNormal
    logVerbose
    logALL
    logDEBUG
End Enum

Public Enum TLogType
    ltStart
    ltInterface
    ltMethod
    ltBeginMethod
    ltEndMethod
    ltCheckpoint
    ltData
    ltList
    ltInformational
    ltError
    ltSystem
    ltInternal
    ltStop
    ltClose
End Enum

#End Region

Public NotInheritable Class Logger

#Region " Private Data "

    Private fFileName As String = "DefaultLogFile"
    Private fFileExt As String = ".LOG"
    Private fLogLevel As TLogLevel = TLogLevel.logNone

    ' Logger is defined as a Singleton pattern, each class instance should have only one instance of Logger.
    Private Shared ReadOnly m_instance As New Logger()

#End Region  'Private Data

#Region " Properties "

    Public Shared ReadOnly Property Instance() As Logger
        Get
            Return m_instance
        End Get
    End Property

    Public Property FileName() As String
        Get
            Return Convert.ToString(fFileName & GetDatePostfix()) & fFileExt
        End Get
        Set(value As String)
            fFileName = value
        End Set
    End Property

    Public ReadOnly Property FilePath() As String
        Get
            Try
                Dim LGPath As String = WorkStation.Path() + WorkStation.Name() + "\Logs\"
                If Not Directory.Exists(LGPath) Then
                    Directory.CreateDirectory(LGPath)
                End If
                Return LGPath
            Catch Ex As Exception
                Throw Ex
            End Try
        End Get
    End Property

    Public Property LogLevel() As TLogLevel
        Get
            Return fLogLevel
        End Get
        Set(value As TLogLevel)
            fLogLevel = value
        End Set
    End Property

    Public ReadOnly Property TimeStamp() As String
        Get
            Dim ts As DateTime = System.DateTime.Now
            Return ts.Year.ToString() + "." + ts.Month.ToString().PadLeft(2, "0"c) + "." + ts.Day.ToString().PadLeft(2, "0"c) + "." + ts.Hour.ToString().PadLeft(2, "0"c) + "." + ts.Minute.ToString().PadLeft(2, "0"c) + "." + ts.Second.ToString().PadLeft(2, "0"c) + "." + ts.Millisecond.ToString().PadLeft(3, "0"c)
        End Get
    End Property

#End Region  'Properties

#Region " Private Methods "

    Private Sub New()
    End Sub

    Private Function GetDatePostfix() As String
        Return "_" + System.DateTime.Now.Year.ToString().Substring(2, 2) + System.DateTime.Now.Month.ToString().PadLeft(2, "0"c) + System.DateTime.Now.Day.ToString().PadLeft(2, "0"c)
    End Function  'GetDatePostfix

#End Region  'Private Methods

#Region " Public Methods "

    Public Function FormatLogTypeString(ALogType As TLogType) As String
        Dim tmpLogType As String = String.Empty
        Try

            Select Case ALogType
                Case TLogType.ltStart
                    tmpLogType = "**  Start Logging | "
                    Exit Select
                Case TLogType.ltMethod
                    tmpLogType = "  <>  Method      | "
                    Exit Select
                Case TLogType.ltCheckpoint
                    tmpLogType = "  []  Checkpoint  | "
                    Exit Select
                Case TLogType.ltInterface
                    tmpLogType = "  ->  Interface   | "
                    Exit Select
                Case TLogType.ltData
                    tmpLogType = "      Data        |   "
                    Exit Select
                Case TLogType.ltList
                    tmpLogType = "      List Data   | "
                    Exit Select
                Case TLogType.ltInformational
                    tmpLogType = "      Info.       | "
                    Exit Select
                Case TLogType.ltError
                    tmpLogType = "  ER  ERROR       | "
                    Exit Select
                Case TLogType.ltSystem
                    tmpLogType = "      System      | "
                    Exit Select
                Case TLogType.ltInternal
                    tmpLogType = "      Internal    | "
                    Exit Select
                Case TLogType.ltStop
                    tmpLogType = "**  Stop Logging  | "
                    Exit Select
                Case TLogType.ltClose
                    tmpLogType = "**  File Closed   | "
                    Exit Select
            End Select
            Return tmpLogType
        Catch
            Return "***LOG TYPE ERROR***"
        End Try
    End Function  'FormatLogTypeString

    Public Sub Log(logStr As String, ALogType As TLogType, ALogLevel As TLogLevel)
        Dim tmpStr As String = String.Empty
        Dim PathAndName As String = ""

        If (ALogLevel = TLogLevel.logNone) AndAlso (ALogType <> TLogType.ltError) Then
            Return
        End If

        Try
            PathAndName = FilePath & FileName
        Catch ex As Exception
            MessageBox.Show("Logger exception: " + ex.Message)
            Throw ex
        End Try

        Dim SW As New StreamWriter(PathAndName, True, System.Text.Encoding.[Default])
        Try
            tmpStr = Convert.ToString(TimeStamp & FormatLogTypeString(ALogType)) & logStr

            ' ALWAYS LOG THESE....
            If (ALogType = TLogType.ltStart) OrElse (ALogType = TLogType.ltError) OrElse (ALogType > TLogType.ltInternal) Then
                SW.WriteLine(tmpStr)
            Else
                ' Log Only if less than or equal to LogLevel property
                If ALogLevel <= LogLevel Then
                    'StackTrace stackTrace = new StackTrace();           // get call stack
                    'StackFrame[] stackFrames = stackTrace.GetFrames();  // get method calls (frames)
                    'foreach (StackFrame stackFrame in stackFrames)
                    '{
                    '    SW.WriteLine("StackFrame", stackFrame.GetMethod().Name);
                    '}
                    SW.WriteLine(tmpStr)
                End If
            End If
            SW.Flush()
            SW.Close()
        Catch ex As Exception
            SW.WriteLine("LOG EXCEPTION: " + ex.Message)
            SW.Flush()
            SW.Close()
        End Try
    End Sub  'Log

    Public Function StrToLogLevelDef(Value As String, ALevel As TLogLevel) As TLogLevel
        Try
            Return DirectCast([Enum].Parse(GetType(TLogLevel), Value), TLogLevel)
        Catch
            Return ALevel
        End Try
    End Function  'StrToLogLevelDef

#End Region  'Public Methods

End Class  'Logger

