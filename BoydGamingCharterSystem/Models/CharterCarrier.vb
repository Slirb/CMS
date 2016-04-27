Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports BoydGamingCharterSystem
<Table("Carrier")>
Public Class CharterCarrier
    Implements IValidatableObject

    <Key>
    Public Property Id() As Integer

    '<ForeignKey("CarrierId")>
    Public Property CharterAgreements As ICollection(Of CharterAgreement)

    Public Property Company As CharterCompany

    Public Property Commentable As Commentable
    <Display(Name:="License")>
    Public Property HasLicense As Boolean
    <Display(Name:="License Number")>
    Public Property LicenseNumber As String
    <Display(Name:="Insurance")>
    Public Property HasInsurance As Boolean
    <Display(Name:="Insurance Number")>
    Public Property InsuranceNumber As String
    <Display(Name:="Insurance Expiration Date")>
    <UIHint("DateTime")>
    Public Property InsuranceExpiration As Date?
    Public Property Created As Date?

    Public Property LastUpdated As Date?

    <NotMapped>
    Public Property Name As String
        Get
            Return Me.Company.Name
        End Get
        Set(value As String)
            Me.Company.Name = value
        End Set
    End property
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
    Public Property Comments() As List(Of CharterComment)
        Get
            Return Commentable.Comments
        End Get
        Set(value As List(Of CharterComment))
            Commentable.Comments = value
        End Set
    End Property

    Friend Sub CreateCharterComments(Optional count As Integer = 1)
        For i As Integer = 0 To count - 1
            Me.Comments.Add(New CharterComment)
        Next
    End Sub

    Public Sub New()

        Me.Id = Nothing
        Me.Company = New CharterCompany
        Me.Commentable = New Commentable

    End Sub

    Public Iterator Function Validate(validationContext As ValidationContext) As IEnumerable(Of ValidationResult) Implements IValidatableObject.Validate

        Dim licenseNum As List(Of String) = New List(Of String)
        licenseNum.Add("LicenseNumber")

        If Me.HasLicense And String.IsNullOrEmpty(Me.LicenseNumber) Then
            Yield New ValidationResult("License number is required", licenseNum)
        End If

        Dim insuranceNum As List(Of String) = New List(Of String)
        insuranceNum.Add("InsuranceNumber")

        If Me.HasInsurance And String.IsNullOrEmpty(Me.InsuranceNumber) Then
            Yield New ValidationResult("Insurance number is required", insuranceNum)
        End If

        Dim insuranceExp As List(Of String) = New List(Of String)
        insuranceExp.Add("InsuranceExpiration")

        If Me.HasInsurance And Me.InsuranceExpiration Is Nothing Then
            Yield New ValidationResult("Insurance expiration date is required", insuranceExp)
        End If

    End Function

End Class
