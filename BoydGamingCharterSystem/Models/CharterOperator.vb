Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Imports CharterSystem
<Table("Operator")>
Public Class CharterOperator


    <Key>
    Public Property Id As Integer

    Public Property Company As CharterCompany

    '<Required(ErrorMessage:="A vendor number is required")>
    <Display(Name:="Vendor Number")>
    Public Property VendorNumber As String

    Public Property Type As String
    Public Property Mode As String
    Public Property Interest As String
    Public Property StopCode As String
    Public Property Created As Date?

    '<ForeignKey("OperatorId")>
    Public Property CharterAgreements As List(Of CharterAgreement)

    Public Property Commentable As Commentable
    <NotMapped>
    Public Property Name As String
        Get
            Return Me.Company.Name
        End Get
        Set(value As String)
            Me.Company.Name = value
        End Set
    End Property


    <NotMapped>
    Public Property Comments() As List(Of CharterComment)
        Get
            Return Commentable.Comments()
        End Get
        Set(value As List(Of CharterComment))
            Commentable.Comments = value
        End Set
    End Property



    <NotMapped>
    Public Property Contacts() As List(Of CharterContact)
        Get
            Return Company.Contactable.Contacts()
        End Get
        Set(value As List(Of CharterContact))
            Company.Contactable.Contacts = value
        End Set
    End Property

    Friend Sub CreateCharterComments(Optional count As Integer = 1)
        For i As Integer = 0 To count - 1
            Me.Comments.Add(New CharterComment)

        Next
    End Sub

    Public Sub New()

        Me.Company = New CharterCompany
        Me.Commentable = New Commentable
    End Sub

End Class



