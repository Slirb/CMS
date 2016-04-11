Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema


Public Class CharterTrips

    Private tripId As Integer
    Private tripsDestination As String
    Private tripsCity As String
    Private tripsStatus As String
    Private tripsConfirmationNumber As String

    Public Property charterAgreementId() As Integer
    <ForeignKey("charterAgreementId")>
    Public Property CharterAgreements() As CharterAgreement


    Public Property CarrierId As Integer
    Public Property CarrierName As String
    Public Property OperatorId As Integer
    Public Property OperatorName As String



    Public Property Arrival As DateTime?
    Public Property Departure As DateTime?


    <ForeignKey("tripId")>
    Public Property CharterManifests() As ICollection(Of CharterManifest)

    <Key>
    Public Property Id() As Integer
        Get
            Return tripId
        End Get
        Set(ByVal value As Integer)
            tripId = value
        End Set
    End Property


    Public Property TripDestination() As String
        Get
            Return tripsDestination
        End Get
        Set(value As String)
            tripsDestination = value
        End Set

    End Property


    Public Property TripCity() As String
        Get
            Return tripsCity
        End Get
        Set(value As String)
            tripsCity = value
        End Set

    End Property

    Public Property TripStatus() As String
        Get
            Return tripsStatus
        End Get
        Set(value As String)
            tripsStatus = value
        End Set

    End Property


    Public Property Confirmation() As String
        Get
            Return tripsConfirmationNumber
        End Get
        Set(value As String)
            tripsConfirmationNumber = value
        End Set

    End Property


    Public Sub New()
        Me.Id = Nothing
        Me.CarrierId = Nothing
        Me.TripDestination = Nothing
        Me.TripCity = Nothing
        Me.TripStatus = Nothing
        Me.Confirmation = Nothing
        Me.charterAgreementId = Nothing
        Me.CharterAgreements = Nothing
        Me.OperatorId = Nothing
        Me.Arrival = Nothing
        Me.Departure = Nothing
        Me.OperatorName = Nothing
        Me.CarrierName = Nothing
        'Me.CharterManifests = Nothing


    End Sub


    ''Need to finish this
    Public Sub New(id As Integer, dest As String, city As String, status As String, confNumber As String, charterAgreement As CharterAgreement, arrivalDate As DateTime, departDate As DateTime)
        Me.Id = id
        Me.CarrierId = charterAgreement.CarrierId
        Me.TripDestination = dest
        Me.TripCity = city
        Me.TripStatus = status
        Confirmation = confNumber
        Me.CharterAgreements = charterAgreement
        Me.charterAgreementId = CharterAgreements.Id
        Me.OperatorId = charterAgreement.OperatorId
        Me.Arrival = arrivalDate
        Me.Departure = departDate
        Me.CarrierName = charterAgreement.CharterCarrier.Company.Name
        Me.OperatorName = charterAgreement.CharterOperator.Company.Name
    End Sub


End Class
