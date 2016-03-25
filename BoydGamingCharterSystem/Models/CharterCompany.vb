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


    Public Property Name() As String


    Public Property AddressLineOne() As String


    Public Property AddressLineTwo() As String

    Public Property City() As String


    Public Overridable Property State() As State


    Public Property PostalCode() As String


    Public Property PostalCodeSuffix() As String


    Public Property Country() As String


    Public Property Email() As String

    Public Property CompanyPrimaryPhone As String
    Public Property CompanyPrimaryPhoneExtension As String
    Public Property CompanyAlternatePhone As String
    Public Property CompanyAlternatePhoneExtension As String
    Public Property CompanyEmergencyPhone As String
    Public Property CompanyEmergencyPhoneExt As String
    Public Property CompanyFax As String
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
        Me.Email = email
    End Sub

    Public Sub New()
        Me.Name = Nothing
        Me.AddressLineOne = Nothing
        Me.AddressLineTwo = Nothing
        Me.City = Nothing
        Me.State = Nothing
        Me.PostalCode = Nothing
        Me.PostalCodeSuffix = Nothing
        Me.Country = Nothing
        Me.Email = Nothing

        Me.Contactable = New Contactable

    End Sub

End Class
