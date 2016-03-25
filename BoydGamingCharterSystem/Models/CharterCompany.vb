Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Public Class CharterCompany

    Private companyId As Integer

    Private companyName As String
    Private companyAddressLineOne As String
    Private companyAddressLineTwo As String
    Private companyCity As String
    Private companyState As State
    Private companyPostalCode As String
    Private companyPostalCodeSuffix As String

    Private companyCountry As String
    Private companyEmail As String

    <Key>
    Public Property Id() As Integer
        Get
            Return companyId
        End Get
        Private Set(ByVal value As Integer)
            companyId = value
        End Set
    End Property


    Public Property Name() As String
        Get
            Return companyName
        End Get
        Set(value As String)
            companyName = value
        End Set

    End Property

    Public Property AddressLineOne() As String
        Get
            Return companyAddressLineOne
        End Get
        Set(value As String)
            companyAddressLineOne = value
        End Set

    End Property

    Public Property AddressLineTwo() As String
        Get
            Return companyAddressLineTwo
        End Get
        Set(value As String)
            companyAddressLineTwo = value
        End Set

    End Property

    Public Property City() As String
        Get
            Return companyCity
        End Get
        Set(value As String)
            companyCity = value
        End Set

    End Property

    Public Overridable Property State() As State
        Get
            Return companyState
        End Get
        Set(value As State)
            companyState = value
        End Set

    End Property

    Public Property PostalCode() As String
        Get
            Return companyPostalCode
        End Get
        Set(value As String)
            companyPostalCode = value
        End Set

    End Property

    Public Property PostalCodeSuffix() As String
        Get
            Return companyPostalCodeSuffix
        End Get
        Set(value As String)
            companyPostalCodeSuffix = value
        End Set

    End Property

    Public Property Country() As String
        Get
            Return companyCountry
        End Get
        Set(value As String)
            companyCountry = value
        End Set

    End Property

    Public Property Email() As String
        Get
            Return companyEmail
        End Get
        Set(value As String)
            companyEmail = value
        End Set

    End Property

    Public Property Contactable As Contactable
    Public Property Contacts As List(Of CharterContact)
        Get
            Return Me.Contactable.Contacts
        End Get
        Set(value As List(Of CharterContact))
            Me.Contactable.Contacts = value
        End Set
    End Property

    Public Property CompanyPrimaryPhone As String
    Public Property CompanyPrimaryPhoneExtension As String
    Public Property CompanyAlternatePhone As String
    Public Property CompanyAlternatePhoneExtension As String
    Public Property CompanyEmergencyPhone As String
    Public Property CompanyEmergencyPhoneExt As String
    Public Property CompanyFax As String
    Public Property CompanyFaxExtension As String



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
