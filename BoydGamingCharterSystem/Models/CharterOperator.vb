Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Imports BoydGamingCharterSystem
<Table("Operator")>
Public Class CharterOperator


    Private operatorId As Integer

    Private operatorName As String



    Public Property Commentable As Commentable

    <ForeignKey("OperatorId")>
    Public Property CharterAgreements As List(Of CharterAgreement)

    <NotMapped>
    Public Property Comments() As List(Of CharterComment)
        Get
            Return Commentable.Comments()
        End Get
        Set(value As List(Of CharterComment))
            Commentable.Comments = value

        End Set

    End Property

    <Key>
    Public Property Id() As Integer
        Get
            Return operatorId
        End Get
        Private Set(ByVal value As Integer)
            operatorId = value
        End Set
    End Property


    Public Property Name() As String
        Get
            Return operatorName
        End Get
        Set(value As String)
            operatorName = value
        End Set

    End Property


    Public Sub New(name As String)
        Me.New()
        Me.Name = name

    End Sub

    Public Sub New()
        Me.Commentable = New Commentable
    End Sub

End Class
