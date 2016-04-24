Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Public Class CharterOperatorInterest

    <Key>
    Public Property Id() As Integer
    Public Property Interest As String

    Public Sub New()
        Id = Nothing
        Interest = Nothing
    End Sub

    Public Sub New(id As Integer, interest As String)
        Me.Id = id
        Me.Interest = interest
    End Sub

End Class
