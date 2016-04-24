Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Public Class CharterOperatorStopCode

    <Key>
    Public Property Id() As Integer
    Public Property StopCode As String

    Public Sub New()
        Id = Nothing
        StopCode = Nothing
    End Sub

    Public Sub New(id As Integer, stopCode As String)
        Me.Id = id
        Me.StopCode = stopCode
    End Sub

End Class
