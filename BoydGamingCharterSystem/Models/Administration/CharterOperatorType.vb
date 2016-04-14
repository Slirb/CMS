Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Public Class CharterOperatorType

    <Key>
    Public Property Id() As Integer
    Public Property Type As String

    Public Sub New()
        Id = Nothing
        Type = Nothing
    End Sub

    Public Sub New(id As Integer, type As String)
        Me.Id = id
        Me.Type = type
    End Sub

End Class
