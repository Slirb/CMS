Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Serializable>
Public Class CharterCompany

    <Key>
    Public Property Id() As Integer

    <Required(ErrorMessage:="A name is required")>
    <Display(Name:="Name")>
    Public Property Name() As String

    <Required(ErrorMessage:="An address is required")>
    <Display(Name:="Address Line One")>
    Public Property AddressLineOne() As String

    <Display(Name:="Address Line Two")>
    Public Property AddressLineTwo() As String

    <Display(Name:="City")>
    Public Property City() As String

    <Display(Name:="State")>
    Public Property StateId As Integer?

    'How do we do this validation?
    Public Overridable Property State() As State

    <Required(ErrorMessage:="A zip code is required")>
    <Display(Name:="Zip Code")>
    Public Property PostalCode() As String

    <Display(Name:="Zip Code Suffix")>
    Public Property PostalCodeSuffix() As String

    <Required(ErrorMessage:="A country is required")>
    <Display(Name:="Country")>
    Public Property Country() As String

    '<Required(ErrorMessage:="An email address is required")>
    <DataType(DataType.EmailAddress, ErrorMessage:="Invalid email address")>
    <Display(Name:="Email")>
    Public Property CompanyEmail() As String

    <DataType(DataType.PhoneNumber)>
    <RegularExpression("^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage:="Invalid phone number")>
    <Display(Name:="Company Primary Phone")>
    Public Property CompanyPrimaryPhone As String

    <Range(0, Integer.MaxValue, ErrorMessage:="Extensions must be numeric")>
    <Display(Name:="Company Primary Phone Extension")>
    Public Property CompanyPrimaryPhoneExtension As String

    <DataType(DataType.PhoneNumber)>
    <RegularExpression("^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage:="Invalid phone number")>
    <Display(Name:="Company Alternate Phone")>
    Public Property CompanyAlternatePhone As String

    <Range(0, Integer.MaxValue, ErrorMessage:="Extensions must be numeric")>
    <Display(Name:="Company Alternate Phone Extension")>
    Public Property CompanyAlternatePhoneExtension As String

    <DataType(DataType.PhoneNumber)>
    <RegularExpression("^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage:="Invalid phone number")>
    <Display(Name:="Company Emergency Phone")>
    Public Property CompanyEmergencyPhone As String

    <Range(0, Integer.MaxValue, ErrorMessage:="Extensions must be numeric")>
    <Display(Name:="Company Emergency Phone Extension")>
    Public Property CompanyEmergencyPhoneExtension As String

    <RegularExpression("^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage:="Invalid fax number")>
    <Display(Name:="Company Fax")>
    Public Property CompanyFax As String

    <Range(0, Integer.MaxValue, ErrorMessage:="Extensions must be numeric")>
    <Display(Name:="Company Fax Extension")>
    Public Property CompanyFaxExtension As String

    Public Property Created As Date?
    Public Property LastUpdated As Date?


    Public Property Contactable As Contactable



    <NotMapped>
    Public Property Contacts As List(Of CharterContact)
        Get
            Return Me.Contactable.Contacts
        End Get
        Set(value As List(Of CharterContact))
            Me.Contactable.Contacts = value
        End Set
    End Property

    Friend Sub CreateCharterContacts(Optional count As Integer = 1)
        For i As Integer = 0 To count - 1
            Me.Contacts.Add(New CharterContact)
        Next
    End Sub



    Public Sub New(name As String, addressLineOne As String, addressLineTwo As String,
                   city As String, state As State, postalCode As String, postalCodeSuffix As String,
                   country As String, email As String)
        Me.New()
        Me.Name = name
        Me.AddressLineOne = addressLineOne
        Me.AddressLineTwo = addressLineTwo
        Me.City = city
        Me.State = state
        Me.PostalCode = postalCode
        Me.PostalCodeSuffix = postalCodeSuffix
        Me.Country = country
        Me.CompanyEmail = email
    End Sub

    Public Sub New()

        Me.Contactable = New Contactable
        Me.Contacts = New List(Of CharterContact)
    End Sub

End Class
