Imports System
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
'----------------------------------------------------------------------------------------------
'   Class: RetCheck
'    Type: Attribute Assignment - Invoice
' Purpose: Catches and records change between Receipt and Return
'----------------------------------------------------------------------------------------------
<GuidAttribute(Discover.CLASS_RetCheck)> _
Public Class RetCheck
    Inherits TCustomAttributeAssignmentPlugin

    '----------------------------------------------------------------------------------------------
    ' Called when plugin is loaded
    '----------------------------------------------------------------------------------------------
    Public Overrides Sub Initialize()
        MyBase.Initialize()
        fEnabled = True
        fGUID = New Guid(Discover.CLASS_RetCheck)
        fBusinessObjectType = Plugins.BusinessObjectType.btInvoice
        AttributeName = "Invoice Type"
    End Sub  'Initialize

    '----------------------------------------------------------------------------------------------
    ' Called when "Invoice Type" is changed
    '----------------------------------------------------------------------------------------------
    Public Overrides Function HandleEvent() As Boolean
        If Common.BOGetStrAttributeValueByName(fAdapter, 0, "Invoice Type") = "2" Then
            gIsAReturn = True
        Else
            gIsAReturn = False
        End If
        Return MyBase.HandleEvent()
    End Function  'HandleEvent

End Class  'RetCheck
