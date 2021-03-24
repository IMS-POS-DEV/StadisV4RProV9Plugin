Imports System.Collections.Generic



Public Class TappitSpendPost_deprecated

    Public Property client_tran_id As String
    Public Property qr_code As String
    Public Property terminal_id As String
    Public Property terminal_location As String
    Public Property items As List(Of TappitItem)

    Public Sub New()
        items = New List(Of TappitItem)
    End Sub



End Class  'TappitSpendPost_deprecated

Public Class TappitSpendPost

    Public Property client_tran_id As String
    Public Property qr_code As String
    Public Property terminal_id As String
    Public Property terminal_location As String
    Public Property items As List(Of TappitItem)
    Public Sub New()
        items = New List(Of TappitItem)
    End Sub
    Public Property sub_total As Decimal
    Public Property tax_amount As Decimal
    Public Property donation_amount As Decimal
    Public Property discount_amount As Decimal
    Public Property total_sales_amount As Decimal

End Class

Public Class TappitSpendSubtotal

    Public Property total_sales_amount As Decimal
    Public Property sub_total As Decimal
    Public Property tax_amount As Decimal
    Public Property donation_amount As Decimal
    Public Property discount_amount As Decimal


End Class  'TappitSpendPost


Public Class TappitItem_deprecated

    Public Property sku As String
    Public Property name As String
    Public Property quantity As Integer
    Public Property unit_price As Decimal
    Public Property amount As Decimal
    Public Property type As String

End Class

Public Class TappitComplimentaryItem

    Public Property description As String
    Public Property used_amount As Decimal
    Public Property remaining_amount As Decimal
    Public Property expire_date As String

End Class
Public Class TappitTokenItem

    Public Property description As String
    Public Property used_amount As Decimal
    Public Property sku As String
    Public Property product_name As String
    Public Property expire_date As String

End Class

Public Class TappitItem

    Public Property unit_price As Decimal
    Public Property sku As String
    Public Property tax_amount As Decimal
    Public Property tax_percent As Decimal
    Public Property tax_included As Boolean
    Public Property discount As Decimal
    Public Property name As String
    Public Property quantity As Integer
    Public Property type As String
    Public Property amount As Decimal



End Class

Public Class TappitSpendReply


    Public Property client_tran_id As String
    Public Property tappit_tran_id As String
    Public Property items As List(Of TappitItem)
    Public Sub New()
        items = New List(Of TappitItem)
    End Sub
    Public Property complimentary_usage As List(Of TappitComplimentaryItem)
    Public Sub NewComplimentaryArray()
        complimentary_usage = New List(Of TappitComplimentaryItem)
    End Sub
    Public Property token_usage As List(Of TappitTokenItem)
    Public Sub NewTokenArray()
        token_usage = New List(Of TappitTokenItem)
    End Sub
    Public Property total_sales_amount As Decimal
    Public Property token_amount As Decimal
    Public Property complimentary_amount As Decimal
    Public Property charged_amount As Decimal
    Public Property qr_code As String
    Public Property tip_amount As Decimal
    Public Property donation_amount As Decimal
    'the below 2 are not in the syntax, but should return null, unless overriden in TappitAPI.vb TappitSpendPost
    Public Property rc As Integer
    Public Property message As String

End Class  'TappitSpendReply

Public Class TappitSpendReply_deprecated


    Public Property client_tran_id As String
    Public Property tappit_tran_id As String
    Public Property qr_code As String
    Public Property total_sales_amount As Decimal
    Public Property rc As Integer
    Public Property message As String

End Class  'TappitSpendReply_deprecated



Public Class TappitRefundPost_v1


    Public Property client_tran_id As String
    Public Property original_client_tran_id As String
    Public Property qr_code As String
    Public Property terminal_id As String
    Public Property terminal_location As String
    'Public Property total_refund_amount As Decimal
    'Public Property items As List(Of TappitItem)
    'Public Sub New()
    '   items = New List(Of TappitItem)
    'End Sub


End Class  'TappitRefundPost_v1

Public Class TappitRefundPost


    Public Property client_tran_id As String
    Public Property spend_tran_id As String
    Public Property local_time As String
    Public Property qr_code As String
    Public Property terminal_id As String
    Public Property terminal_location As String
    'Public Property total_refund_amount As Decimal
    'Public Property items As List(Of TappitItem)
    'Public Sub New()
    '   items = New List(Of TappitItem)
    'End Sub


End Class  'TappitRefundPost



Public Class TappitRefundReply


    Public Property client_tran_id As String
    Public Property tappit_tran_id As String
    Public Property qr_code As String
    Public Property total_sales_amount As Decimal
    Public Property rc As Integer
    Public Property message As String


End Class  'TappitRefundReply



Public Class TappitBalChkPost

    Public Property qr_code As String

End Class  'TappitBalChkPost



Public Class TappitBalChkReply

    Public Property client_customer_id As String
    Public Property balance As Decimal
    Public Property rc As Integer
    Public Property message As String

End Class  'TappitBalChkReply



