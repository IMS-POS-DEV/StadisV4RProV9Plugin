Imports System
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.IO

Public Class PrintBalChk
    Inherits System.Drawing.Printing.PrintDocument

#Region " Private Data "

    Private _currentPage As Integer = 0
    Private _currentRecord As Integer = 0

    Private _titleFont As Font
    Private _detailFont As Font

    Dim pfc As System.Drawing.Text.PrivateFontCollection
    Dim ifc As System.Drawing.Text.InstalledFontCollection

#End Region  'Private Data

#Region " Public Properties "

    Private mCardID As String = Nothing
    Friend Property CardID() As String
        Get
            Return mCardID
        End Get
        Set(ByVal value As String)
            mCardID = value
        End Set
    End Property

    Private mBalance As String = Nothing
    Friend Property Balance() As String
        Get
            Return mBalance
        End Get
        Set(ByVal value As String)
            mBalance = value
        End Set
    End Property

    Private mAvailable As String = Nothing
    Friend Property Available() As String
        Get
            Return mAvailable
        End Get
        Set(ByVal value As String)
            mAvailable = value
        End Set
    End Property

#End Region  'Public Properties

#Region " Initialization "

    Public Sub New()
        pfc = New System.Drawing.Text.PrivateFontCollection()
        ifc = New System.Drawing.Text.InstalledFontCollection()
        LoadPrivateFonts({My.Resources.lucon})
    End Sub  'New

#End Region  'Initialization

#Region " Methods "

    Private Sub LoadPrivateFonts(ByVal fonts As IEnumerable(Of Byte()))
        For Each resFont In fonts
            pfc.AddMemoryFont(Runtime.InteropServices.Marshal.UnsafeAddrOfPinnedArrayElement(resFont, 0), resFont.Length)
        Next
    End Sub  'LoadPrivateFonts

    Private Function GetFontFamily(ByVal fontName As String, Optional ByVal defaultFamily As FontFamily = Nothing) As FontFamily
        If String.IsNullOrEmpty(fontName) Then
            Throw New ArgumentNullException("fontName", "The name of the font cannont be null.")
        End If
        Dim foundFonts = From font In ifc.Families.Union(pfc.Families) Where font.Name.ToLower() = fontName.ToLower()
        If foundFonts.Any() Then
            Return foundFonts.First()
        Else
            Return If(defaultFamily, FontFamily.GenericSansSerif)
        End If
    End Function  'GetFontFamily

    Private Sub BalChk_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeginPrint
        _titleFont = New Font(FontFamily.GenericMonospace, 16, FontStyle.Bold, GraphicsUnit.Point)
        _detailFont = New Font(GetFontFamily("Lucida Console"), 10, FontStyle.Regular, GraphicsUnit.Point)
    End Sub  'BalChk_BeginPrint

    Private Sub BalChk_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles Me.PrintPage

        Dim yPos As Single = 100
        Dim ySpace As Single = e.Graphics.MeasureString("ABCDE", _detailFont).Height
        Dim yDblSpace As Single = 2 * ySpace
        Dim prtLine As String = ""

        Dim sideSpace As Integer = CInt((27 - gReceiptTenderText.Length) / 2)
        If sideSpace < 0 Then
            sideSpace = 0
        End If

        e.Graphics.DrawString("***************************", _detailFont, Brushes.Black, 20, yPos)
        yPos += yDblSpace
        prtLine = Space(sideSpace) & gReceiptTenderText & Space(sideSpace)
        e.Graphics.DrawString(prtLine, _detailFont, Brushes.Black, 20, yPos)
        yPos += yDblSpace
        prtLine = Date.Now.ToShortDateString & Space(27 - (Date.Now.ToShortDateString.Length + Date.Now.ToShortTimeString.Length)) & Date.Now.ToShortTimeString
        e.Graphics.DrawString(prtLine, _detailFont, Brushes.Black, 20, yPos)
        yPos += ySpace
        Dim len As Integer = mCardID.Length
        Dim lastfour As String = "***" & mCardID.Substring(len - 4, 4)
        prtLine = "Card Number:" & Space(15 - lastfour.Length) & lastfour
        e.Graphics.DrawString(prtLine, _detailFont, Brushes.Black, 20, yPos)
        yPos += ySpace
        prtLine = "Balance:" & Space(19 - mBalance.Length) & mBalance
        e.Graphics.DrawString(prtLine, _detailFont, Brushes.Black, 20, yPos)
        yPos += ySpace
        prtLine = "Available:" & Space(17 - mAvailable.Length) & mAvailable
        e.Graphics.DrawString(prtLine, _detailFont, Brushes.Black, 20, yPos)
        yPos += yDblSpace
        e.Graphics.DrawString("***************************", _detailFont, Brushes.Black, 20, yPos)
        yPos += ySpace

    End Sub  'BalChk_PrintPage

    Private Sub Prt_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        pfc.Dispose()
        ifc.Dispose()
    End Sub  'Prt_Disposed

#End Region  'Methods

End Class  'PrintBalChk

