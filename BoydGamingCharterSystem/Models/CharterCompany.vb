Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Public Class CharterCompany

    'Private companyId As Integer

    'Private companyName As String
    'Private companyAddressLineOne As String
    'Private companyAddressLineTwo As String
    'Private companyCity As String
    'Private companyState As State
    'Private companyPostalCode As String
    'Private companyPostalCodeSuffix As String

    'Private companyCountry As String
    'Private companyEmail As String

    <Key>
    Public Property Id() As Integer

    '<Required(ErrorMessage:="A name is required")>
    <Display(Name:="Name")>
    Public Property Name() As String

    '<Required(ErrorMessage:="An address is required")>
    <Display(Name:="Address Line One")>
    Public Property AddressLineOne() As String

    <Display(Name:="Address Line Two")>
    Public Property AddressLineTwo() As String

    '<Required(ErrorMessage:="A city is required")>
    <Display(Name:="City")>
    Public Property City() As String

    'How do we do this validation?
    Public Overridable Property State() As State

    '<Required(ErrorMessage:="A zip code is required")>
    <Display(Name:="Zip Code")>
    Public Property PostalCode() As String

    <Display(Name:="Zip Code Suffix")>
    Public Property PostalCodeSuffix() As String

    <Display(Name:="Country")>
    Public Property Country() As String

    <Display(Name:="Email")>
    Public Property CompanyEmail() As String

    <Display(Name:="Company Primary Phone")>
    Public Property CompanyPrimaryPhone As String
    <Display(Name:="Company Primary Phone Extension")>
    Public Property CompanyPrimaryPhoneExtension As String
    <Display(Name:="Company Alternate Phone")>
    Public Property CompanyAlternatePhone As String

    <Display(Name:="Company Alternate Phone Extension")>
    Public Property CompanyAlternatePhoneExtension As String


    <Display(Name:="Company Emergency Phone")>
    Public Property CompanyEmergencyPhone As String
    <Display(Name:="Company Emergency Phone Extension")>
    Public Property CompanyEmergencyPhoneExtension As String

    <Display(Name:="Company Fax")>
    Public Property CompanyFax As String
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

    End Sub

End Class
