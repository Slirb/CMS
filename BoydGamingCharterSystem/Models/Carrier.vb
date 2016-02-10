Public Class Carrier
    Private carrierId As String

    Property id() As String
        Get
            Return Me.carrierId

        End Get
        Set(value As String)
            Me.carrierId = value
        End Set
    End Property
    Sub New()
        Me.carrierId = Nothing

    End Sub
    Sub New(ByVal id As String)
        Me.carrierId = id
    End Sub


End Class
