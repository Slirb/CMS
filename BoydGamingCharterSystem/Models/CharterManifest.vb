Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Public Class CharterManifest

    Private manifestId As Integer


    Public Property cardNumber As Integer
    Public Property firstName As String
    Public Property lastName As String
    Public Property middleInitial As String
    Public Property dob As DateTime?
    Public Property addressLineOne As String
    Public Property addressLineTwo As String
    Public Property city As String
    Public Property state As String
    Public Property postalCode As String

    Public Property tripId() As Integer
    <ForeignKey("tripId")>
    Public Property CharterTrips() As CharterTrips

    <Key>
    Public Property Id() As Integer
        Get
            Return manifestId
        End Get
        Private Set(ByVal value As Integer)
            manifestId = value
        End Set
    End Property

    'Returns a users name
    Public ReadOnly Property FullName() As String
        Get
            Return firstName + " " + middleInitial + ". " + lastName
        End Get
    End Property


    Public Sub New()
        Me.Id = Nothing
        Me.cardNumber = Nothing
        Me.firstName = Nothing
        Me.lastName = Nothing
        Me.middleInitial = Nothing
        Me.dob = Nothing
        Me.addressLineOne = Nothing
        Me.addressLineTwo = Nothing
        Me.city = Nothing
        Me.state = Nothing
        Me.postalCode = Nothing
        Me.tripId = Nothing
    End Sub

    Public Sub New(id As Integer, card As Integer, first As String, last As String, mid As String, dob As Date, add1 As String, add2 As String, city As String, state As State, code As String, chartertrip As CharterTrips)
        Me.Id = id
        Me.cardNumber = card
        Me.firstName = first
        Me.lastName = last
        Me.middleInitial = mid
        Me.dob = dob
        Me.addressLineOne = add1
        Me.addressLineTwo = add2
        Me.city = city
        Me.state = state.Abrv
        Me.postalCode = code
        Me.tripId = chartertrip.Id
    End Sub


End Class
