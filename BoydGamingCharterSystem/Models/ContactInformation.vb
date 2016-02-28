Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<ComplexType>
Public Class ContactInformation
    Private _addressLineOne As String
    Private _addressLineTwo As String

    'TODO: Create country class that gets all countries from our database
    Private _country As String
    Private _zipCode As String
    Private _city As String

    'TODO: Create state class that gets all states from our database
    Private _state As String

    Private _primaryPhone As String

    Private _alternativePhone As String

    Private _emergencyPhone As String

    Private _fax As String

    Private _email As String

    Private _contacts As List(Of String)

    Public Property addressLineOne() As String
        Get
            Return _addressLineOne
        End Get
        Set(value As String)
            _addressLineOne = value
        End Set
    End Property
    Public Property addressLineTwo() As String
        Get
            Return _addressLineTwo
        End Get
        Set(value As String)
            _addressLineTwo = value
        End Set
    End Property

    Public Property Country As String
        Get
            Return _country
        End Get
        Set(value As String)
            _country = value
        End Set
    End Property

    Public Property Email As String
        Get
            Return _email
        End Get
        Set(value As String)
            _email = value
        End Set
    End Property

    Public Property Contacts As List(Of String)
        Get
            Return _contacts
        End Get
        Set(value As List(Of String))
            _contacts = value
        End Set
    End Property
End Class
