Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Public Class CharterOperatorMode

    <Key>
    Public Property Id() As Integer
    Public Property Mode As String

    Public Sub New()
        Id = Nothing
        Mode = Nothing
    End Sub

    Public Sub New(id As Integer, mode As String)
        Me.Id = id
        Me.Mode = mode
    End Sub

End Class
