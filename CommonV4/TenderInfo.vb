Imports CommonV4
Imports CommonV4.WebReference
Imports RetailPro.CustomPluginClasses
Imports RetailPro.Plugins
'-----------------------------------------------------------------------------------------------
'   Class: TenderInfo
'    Type: Class to hold multiple return values
' Purpose: Takes the Stadis code passed in MANUAL_REMARK and decomposes it back into useful info
'-----------------------------------------------------------------------------------------------
Public Class TenderInfo

#Region " Data Declarations "

    Private mStadisOpCode As String = ""
    Private mIsAStadisTender As Boolean = False
    Private mIsAStadisRedeem As Boolean = False
    Private mIsAReturn As Boolean = False
    Private mIsAReturnCredToNewGiftCard As Boolean = False
    Private mIsAReload As Boolean = False
    Private mIsAnOffset As Boolean = False
    Private mShouldBeCharged As Boolean = False
    Private mIsAGiftCard As Boolean = False
    Private mIsATicket As Boolean = False

    Public Property StadisOpCode() As String
        Get
            Return mStadisOpCode
        End Get
        Set(ByVal value As String)
            mStadisOpCode = value
        End Set
    End Property

    Public Property IsAStadisTender() As Boolean
        Get
            Return mIsAStadisTender
        End Get
        Set(ByVal value As Boolean)
            mIsAStadisTender = value
        End Set
    End Property

    Public Property IsAStadisRedeem() As Boolean
        Get
            Return mIsAStadisRedeem
        End Get
        Set(ByVal value As Boolean)
            mIsAStadisRedeem = value
        End Set
    End Property

    Public Property IsAReturn() As Boolean
        Get
            Return mIsAReturn
        End Get
        Set(ByVal value As Boolean)
            mIsAReturn = value
        End Set
    End Property

    Public Property IsAReturnCredToNewGiftCard() As Boolean
        Get
            Return mIsAReturnCredToNewGiftCard
        End Get
        Set(ByVal value As Boolean)
            mIsAReturnCredToNewGiftCard = value
        End Set
    End Property

    Public Property IsAReload() As Boolean
        Get
            Return mIsAReload
        End Get
        Set(ByVal value As Boolean)
            mIsAReload = value
        End Set
    End Property

    Public Property IsAnOffset() As Boolean
        Get
            Return mIsAnOffset
        End Get
        Set(ByVal value As Boolean)
            mIsAnOffset = value
        End Set
    End Property

    Public Property ShouldBeCharged() As Boolean
        Get
            Return mShouldBeCharged
        End Get
        Set(ByVal value As Boolean)
            mShouldBeCharged = value
        End Set
    End Property

    Public Property IsAGiftCard() As Boolean
        Get
            Return mIsAGiftCard
        End Get
        Set(ByVal value As Boolean)
            mIsAGiftCard = value
        End Set
    End Property

    Public Property IsATicket() As Boolean
        Get
            Return mIsATicket
        End Get
        Set(ByVal value As Boolean)
            mIsATicket = value
        End Set
    End Property

#End Region  'Data Declarations

#Region " Methods "

    Public Sub New(ByRef adapter As RetailPro.Plugins.IPluginAdapter, ByRef tenderHandle As Integer)
        Dim m_r As String = CommonRoutines.BOGetStrAttributeValueByName(adapter, tenderHandle, "MANUAL_REMARK")
        If m_r.Length > 2 Then
            mStadisOpCode = m_r.Substring(0, 3)
            Select Case mStadisOpCode
                Case "@GC"
                    IsAStadisTender = True
                    IsAStadisRedeem = True
                    'IsAReturn = False
                    'IsAReturnCredToNewGiftCard = False
                    'IsAReload = False
                    'IsAnOffset = False
                    ShouldBeCharged = True
                    IsAGiftCard = True
                    'IsATicket = False
                Case "@TK"
                    IsAStadisTender = True
                    IsAStadisRedeem = True
                    'IsAReturn = False
                    'IsAReturnCredToNewGiftCard = False
                    'IsAReload = False
                    'IsAnOffset = False
                    ShouldBeCharged = True
                    'IsAGiftCard = False
                    IsATicket = True
                Case "@OF"
                    IsAStadisTender = True
                    'IsAStadisRedeem = False
                    'IsAReturn = False
                    'IsAReturnCredToNewGiftCard = False
                    'IsAReload = False
                    IsAnOffset = True
                    'ShouldBeCharged = False
                    'IsAGiftCard = False
                    'IsATicket = False
                Case "@GL"
                    IsAStadisTender = True
                    'IsAStadisRedeem = False
                    'IsAReturn = False
                    'IsAReturnCredToNewGiftCard = False
                    IsAReload = True
                    'IsAnOffset = False
                    ShouldBeCharged = True
                    IsAGiftCard = True
                    'IsATicket = False
                Case "@TL"
                    IsAStadisTender = True
                    'IsAStadisRedeem = False
                    'IsAReturn = False
                    'IsAReturnCredToNewGiftCard = False
                    IsAReload = True
                    'IsAnOffset = False
                    ShouldBeCharged = True
                    'IsAGiftCard = False
                    IsATicket = True
                Case "@GR"
                    IsAStadisTender = True
                    'IsAStadisRedeem = False
                    IsAReturn = True
                    'IsAReturnCredToNewGiftCard = False
                    'IsAReload = False
                    'IsAnOffset = False
                    ShouldBeCharged = True
                    IsAGiftCard = True
                    'IsATicket = False
                Case "@TR"
                    IsAStadisTender = True
                    'IsAStadisRedeem = False
                    IsAReturn = True
                    'IsAReturnCredToNewGiftCard = False
                    'IsAReload = False
                    'IsAnOffset = False
                    ShouldBeCharged = True
                    'IsAGiftCard = False
                    IsATicket = True
                Case "@RI"
                    IsAStadisTender = True
                    'IsAStadisRedeem = False
                    IsAReturn = True
                    IsAReturnCredToNewGiftCard = True
                    'IsAReload = False
                    IsAnOffset = True
                    'ShouldBeCharged = False
                    'IsAGiftCard = False
                    'IsATicket = False
                Case "@RA"
                    IsAStadisTender = True
                    'IsAStadisRedeem = False
                    IsAReturn = True
                    IsAReturnCredToNewGiftCard = True
                    'IsAReload = False
                    IsAnOffset = True
                    'ShouldBeCharged = False
                    'IsAGiftCard = False
                    'IsATicket = False
            End Select
        End If
    End Sub

#End Region  'Methods

End Class  'TenderInfo
