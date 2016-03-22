Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Public Class CharterComment


    Public Property Id() As Integer
    Public Property Content() As String
    Public Property CreateDateTime() As DateTime
    Public Property Commentable() As Commentable


    Public Sub New()
        Me.Id = Nothing
        Me.Content = Nothing
        Me.CreateDateTime = DateTime.Now()
    End Sub

    Public Sub New(content As String)
        Me.New()
        Me.Content = content
    End Sub



End Class


Public Class Commentable

    Public Property CommentableId() As Integer

    Public Overridable Property Comments() As List(Of CharterComment)

    Public Sub New()
        Me.Comments = New List(Of CharterComment)
    End Sub

End Class
