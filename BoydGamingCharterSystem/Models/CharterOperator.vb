Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Imports BoydGamingCharterSystem
<Table("Operator")>
Public Class CharterOperator


    <Key>
    Public Property Id As Integer

    Public Property Company As CharterCompany

    Public Property VendorNumber As String

    'In the current application, Type, Mode, Interest, and Stop Code
    'are all stored as strings. I don't know how we should handle these
    'as in the actual application, they need a dropdown menu 
    ' - probably to be administered, so they need tables at a minimum
    Public Property Type As String
    Public Property Mode As String
    Public Property Interest As String
    Public Property StopCode As String

    <ForeignKey("OperatorId")>
    Public Property CharterAgreements As List(Of CharterAgreement)

    Public Property Commentable As Commentable

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


    Public Sub New()
        Me.Commentable = New Commentable
    End Sub

End Class

