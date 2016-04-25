﻿Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema


Public Class CharterTrips
    Implements IValidatableObject

    Private tripId As Integer
    Private tripsDestination As String
    Private tripsCity As String
    Private tripsStatus As String
    Private tripsConfirmationNumber As String

    'Public ReadOnly Property charterAgreementId() As Integer
    '    Get
    '        Return Me.CharterAgreements.Id()
    '    End Get
    'End Property



    Public Property CharterAgreements() As CharterAgreement


    Public Property CarrierId As Integer?
    'Public Property CharterCarrier As CharterCarrier
    Public Property CarrierName As String

    Public Property OperatorId As Integer?
    Public Property OperatorName As String



    Public Property Arrival As DateTime?
    Public Property Departure As DateTime?
    Public Property ManifestCount As Integer
    Public Property TripNotes As String

    <ForeignKey("tripId")>
    Public Property CharterManifests() As ICollection(Of CharterManifest)


    'Formats the arrival time for display
    Public ReadOnly Property DisplayArrival() As String
        Get
            Return Arrival.Value.ToString("MM/dd/yyyy hh:mm tt")
        End Get
    End Property


    'Formats the departure time for display
    Public ReadOnly Property DisplayDeparture() As String
        Get
            Return Departure.Value.ToString("MM/dd/yyyy hh:mm tt")
        End Get
    End Property


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

    <NotMapped>
    <UIHint("DateTime")>
    Public Property ArrivalDate As DateTime
        Get
            Return Me.Arrival
        End Get
        Set(value As DateTime)
            Me.Arrival = value
        End Set
    End Property
    <NotMapped>
    Public Property ArrivalHour As Integer
        Get
            Return Me.Arrival.Value.Hour
        End Get
        Set(value As Integer)
            Dim currentDateTime As DateTime
            currentDateTime = Me.Arrival
            currentDateTime = New DateTime(currentDateTime.Year, currentDateTime.Month, currentDateTime.Day, value, currentDateTime.Minute, currentDateTime.Second)
            Me.Arrival = currentDateTime
        End Set
    End Property
    <NotMapped>
    Public Property ArrivalMinute As Integer
        Get
            Return Me.Arrival.Value.Minute
        End Get
        Set(value As Integer)
            Dim currentDateTime As DateTime
            currentDateTime = Me.Arrival
            currentDateTime = New DateTime(currentDateTime.Year, currentDateTime.Month, currentDateTime.Day, currentDateTime.Hour, value, currentDateTime.Second)
            Me.Arrival = currentDateTime
        End Set
    End Property

    <NotMapped>
    <UIHint("DateTime")>
    Public Property DepartureDate As DateTime
        Get
            Return Me.Departure
        End Get
        Set(value As DateTime)
            Me.Departure = value
        End Set
    End Property
    <NotMapped>
    Public Property DepartureHour As Integer
        Get
            Return Me.Departure.Value.Hour
        End Get
        Set(value As Integer)
            Dim currentDateTime As DateTime
            currentDateTime = Me.Departure
            currentDateTime = New DateTime(currentDateTime.Year, currentDateTime.Month, currentDateTime.Day, value, currentDateTime.Minute, currentDateTime.Second)
            Me.Departure = currentDateTime
        End Set
    End Property
    <NotMapped>
    Public Property DepartureMinute As Integer
        Get
            Return Me.Departure.Value.Minute
        End Get
        Set(value As Integer)
            Dim currentDateTime As DateTime
            currentDateTime = Me.Departure
            currentDateTime = New DateTime(currentDateTime.Year, currentDateTime.Month, currentDateTime.Day, currentDateTime.Hour, value, currentDateTime.Second)
            Me.Departure = currentDateTime
        End Set
    End Property

    Public Sub New()
        Me.Id = Nothing
        Me.CarrierId = Nothing
        Me.TripDestination = Nothing
        Me.TripCity = Nothing
        Me.TripStatus = Nothing
        Me.Confirmation = Nothing

        Me.CharterAgreements = Nothing
        Me.OperatorId = Nothing
        Me.Arrival = DateTime.MinValue
        Me.Departure = DateTime.MinValue
        Me.OperatorName = Nothing
        Me.CarrierName = Nothing
        Me.ManifestCount = Nothing
        Me.CharterManifests = Nothing
        Me.TripNotes = Nothing


    End Sub


    ''Need to finish this
    Public Sub New(id As Integer, dest As String, city As String, status As String, confNumber As String, charterAgreement As CharterAgreement, arrivalDate As DateTime, departDate As DateTime)
        Me.New()
        Me.Id = id
        Me.CarrierId = charterAgreement.CharterCarrier.Id
        Me.TripDestination = dest
        Me.TripCity = city
        Me.TripStatus = status
        Confirmation = confNumber
        Me.CharterAgreements = charterAgreement

        Me.OperatorId = charterAgreement.CharterOperator.Id
        Me.Arrival = arrivalDate
        Me.Departure = departDate
        Me.CarrierName = charterAgreement.CharterCarrier.Company.Name
        Me.OperatorName = charterAgreement.CharterOperator.Company.Name


    End Sub

    Public Iterator Function Validate(validationContext As ValidationContext) As IEnumerable(Of ValidationResult) Implements IValidatableObject.Validate

        Dim properties As List(Of String) = New List(Of String)
        properties.Add("Departure")

        If Me.Departure < Me.Arrival Then
            Yield New ValidationResult("Test", properties)
        End If

    End Function
End Class
