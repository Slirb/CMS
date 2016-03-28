Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports BoydGamingCharterSystem
<Table("Carrier")>
Public Class CharterCarrier

    <Key>
    Public Property Id() As Integer

    <ForeignKey("CarrierId")>
    Public Property CharterAgreements As ICollection(Of CharterAgreement)

    Public Property Company As CharterCompany

    Public Property Commentable As Commentable

    Public Property HasLicense As Boolean
    Public Property LicenseNumber As String

    Public Property HasInsurance As Boolean
    Public Property InsuranceNumber As String
    Public Property InsuranceExpiration As Date?
    Public Property Created As Date?

    Public Property LastUpdated As Date?


    <NotMapped>
    Public Property Contacts() As List(Of CharterContact)
        Get
            Return Company.Contacts()
        End Get
        Set(value As List(Of CharterContact))
            Company.Contacts = value
        End Set
    End Property


    <NotMapped>
    Public Property Comments() As ICollection(Of CharterComment)
        Get
            Return Commentable.Comments
        End Get
        Set(value As ICollection(Of CharterComment))
            Commentable.Comments = value
        End Set
    End Property

    Public Sub New()

        Me.Id = Nothing
        Me.Company = New CharterCompany
        Me.Commentable = New Commentable
        Me.Created = DateTime.Now()
    End Sub



End Class
