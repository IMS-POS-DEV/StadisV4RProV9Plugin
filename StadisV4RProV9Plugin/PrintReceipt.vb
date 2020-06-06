Imports System
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Windows.Forms

Public Class PrintReceipt
    Inherits System.Drawing.Printing.PrintDocument

#Region " Private Data "

    Private _currentPage As Integer = 0
    Private _currentRecord As Integer = 0

    Private _titleFont As Font
    Private _detailFont As Font

    Private pfc As System.Drawing.Text.PrivateFontCollection
    Private ifc As System.Drawing.Text.InstalledFontCollection

#End Region  'Private Data

#Region " Public Properties "

    Private _StrRdr As StreamReader
    Friend Property StrRdr() As StreamReader
        Get
            Return _StrRdr
        End Get
        Set(ByVal value As StreamReader)
            _StrRdr = value
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

    Private Sub Receipt_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeginPrint
        _titleFont = New Font(FontFamily.GenericMonospace, 16, FontStyle.Bold, GraphicsUnit.Point)
        _detailFont = New Font(GetFontFamily("Lucida Console"), 10, FontStyle.Regular, GraphicsUnit.Point)
    End Sub  'Receipt_BeginPrint

    Private Sub Receipt_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles Me.PrintPage
        Dim linesPerPage As Single = 0
        Dim yPos As Single = 0
        Dim count As Integer = 0
        Dim leftMargin As Single = e.MarginBounds.Left
        Dim topMargin As Single = e.MarginBounds.Top
        Dim line As String = Nothing

        ' Calculate the number of lines per page.
        linesPerPage = e.MarginBounds.Height / _detailFont.GetHeight(e.Graphics)

        ' Print each line of the file.
        While count < linesPerPage
            line = StrRdr.ReadLine()
            If line Is Nothing Then
                Exit While
            End If
            yPos = topMargin + count * _detailFont.GetHeight(e.Graphics)
            e.Graphics.DrawString(line, _detailFont, Brushes.Black, leftMargin, yPos, New StringFormat())
            count += 1
        End While

        ' If more lines exist, print another page.
        If (line IsNot Nothing) Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
            StrRdr.Close()
        End If
    End Sub  'Receipt_PrintPage

    'Private Sub FormatReceipt(ByRef hRow As DSTran.HeaderRow, ByVal e As System.Drawing.Printing.PrintPageEventArgs)

    '    Dim yPos As Single = 0
    '    Dim ySpace As Single = e.Graphics.MeasureString("ABCDE", _detailFont).Height
    '    'Dim yDblSpace As Single = 2 * ySpace
    '    Dim prtLine As String = ""

    '    Dim sQuantity As Integer
    '    Dim sQuantityStr As String
    '    Dim sDescription As String
    '    Dim sPrice As Double
    '    Dim sExtPrice As Double
    '    Dim mExtPrice As String
    '    Dim sGrandTotal As Double = CDbl(hRow.Total)
    '    Dim mGrandTotal As String = sGrandTotal.ToString("""$""#,##0.00")
    '    Dim sTenderAmount As Double
    '    Dim mTenderAmount As String
    '    Dim sTenderType As String
    '    Dim transactionKey As String = CStr(hRow.TransactionKey)

    '    'prtLine = "----------------------------------------"
    '    'e.Graphics.DrawString(prtLine, _detailFont, Brushes.Black, 20, yPos)
    '    'yPos += ySpace
    '    prtLine = "Date/Time : " & CDate(hRow.CreateDate).ToString()
    '    e.Graphics.DrawString(prtLine, _detailFont, Brushes.Black, 20, yPos)
    '    yPos += ySpace
    '    prtLine = "Location  : " & hRow.LocationID
    '    e.Graphics.DrawString(prtLine, _detailFont, Brushes.Black, 20, yPos)
    '    yPos += ySpace
    '    prtLine = "Register #: " & hRow.RegisterID
    '    e.Graphics.DrawString(prtLine, _detailFont, Brushes.Black, 20, yPos)
    '    yPos += ySpace
    '    prtLine = "Receipt # : " & hRow.ReceiptID
    '    e.Graphics.DrawString(prtLine, _detailFont, Brushes.Black, 20, yPos)
    '    yPos += ySpace
    '    prtLine = "Cashier   : " & hRow.VendorCashier
    '    e.Graphics.DrawString(prtLine, _detailFont, Brushes.Black, 20, yPos)
    '    yPos += ySpace
    '    prtLine = "----------------------------------------"
    '    e.Graphics.DrawString(prtLine, _detailFont, Brushes.Black, 20, yPos)
    '    yPos += ySpace
    '    If TenderID.Length < 4 Then
    '        prtLine = gStadisTenderText & "#: " & "xxxxxxxxxxxxx"
    '    Else
    '        prtLine = gStadisTenderText & "#: " & "xxxxxxxxx" & Mid(TenderID, TenderID.Length - 3, 4)
    '    End If
    '    e.Graphics.DrawString(prtLine, _detailFont, Brushes.Black, 20, yPos)
    '    yPos += ySpace
    '    prtLine = "----------------------------------------"
    '    e.Graphics.DrawString(prtLine, _detailFont, Brushes.Black, 20, yPos)
    '    yPos += ySpace
    '    prtLine = "  Qty  Description               Price"
    '    e.Graphics.DrawString(prtLine, _detailFont, Brushes.Black, 20, yPos)
    '    yPos += ySpace
    '    prtLine = "----------------------------------------"
    '    e.Graphics.DrawString(prtLine, _detailFont, Brushes.Black, 20, yPos)
    '    yPos += ySpace
    '    For Each iRow As DSTran.ItemRow In _Trans.Item
    '        If iRow.TransactionKey = transactionKey Then
    '            sQuantity = iRow.Quantity
    '            sDescription = Trim(iRow.Description)
    '            sPrice = CDbl(iRow.Price)
    '            sExtPrice = sPrice * sQuantity
    '            mExtPrice = sExtPrice.ToString("""$""#,##0.00")
    '            sQuantityStr = CStr(sQuantity)
    '            If iRow.Description.Length > 20 Then
    '                prtLine = Space(4 - sQuantityStr.Length) & sQuantityStr & Space(3) & Mid(sDescription, 1, 20) & Space(1) & Space(10 - mExtPrice.Length) & mExtPrice
    '            Else
    '                prtLine = Space(4 - sQuantityStr.Length) & sQuantityStr & Space(3) & sDescription & Space(20 - sDescription.Length) & Space(1) & Space(10 - mExtPrice.Length) & mExtPrice
    '            End If
    '            e.Graphics.DrawString(prtLine, _detailFont, Brushes.Black, 20, yPos)
    '            yPos += ySpace
    '        End If
    '    Next
    '    prtLine = "----------------------------------------"
    '    e.Graphics.DrawString(prtLine, _detailFont, Brushes.Black, 20, yPos)
    '    yPos += ySpace
    '    prtLine = "                  TOTAL: " & Space(13 - mGrandTotal.Length) & mGrandTotal
    '    e.Graphics.DrawString(prtLine, _detailFont, Brushes.Black, 20, yPos)
    '    yPos += ySpace
    '    prtLine = "----------------------------------------"
    '    e.Graphics.DrawString(prtLine, _detailFont, Brushes.Black, 20, yPos)
    '    yPos += ySpace
    '    For Each tRow As DSTran.TenderRow In _Trans.Tender
    '        If tRow.TransactionKey = transactionKey Then
    '            sTenderType = Trim(tRow.TenderType)
    '            sTenderAmount = CDbl(tRow.PostedAmount)
    '            mTenderAmount = sTenderAmount.ToString("""$""#,##0.00")
    '            prtLine = Space(23 - sTenderType.Length) & sTenderType & ": " & Space(13 - mTenderAmount.Length) & mTenderAmount
    '            e.Graphics.DrawString(prtLine, _detailFont, Brushes.Black, 20, yPos)
    '            yPos += ySpace
    '        End If
    '    Next
    '    prtLine = "----------------------------------------"
    '    e.Graphics.DrawString(prtLine, _detailFont, Brushes.Black, 20, yPos)
    '    yPos += ySpace
    '    prtLine = " "
    '    e.Graphics.DrawString(prtLine, _detailFont, Brushes.Black, 20, yPos)
    '    yPos += ySpace
    'End Sub  'FormatReceipt

    Private Sub Prt_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        pfc.Dispose()
        ifc.Dispose()
    End Sub  'Prt_Disposed

#End Region  'Methods

End Class  'PrintReceipt

