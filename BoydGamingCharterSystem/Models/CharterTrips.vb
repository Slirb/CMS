Imports System.ComponentModel.DataAnnotations

Public Class CharterTrips

    Public Property CarrierId() As Integer
    <ForeignKey("AgreementID")>
    Public Property CharterAgreement() As CharterAgreement




    <Key>
    Private tripsTripID As Integer
    Private tripsCarrierName As String
    Private tripsDestination As String
    Private tripsCity As String
    Private tripsStatus As String
    Private tripsConfirmationNumber As String
    Private tripsAgreementID As Integer
    Private tripsOperatorName As String
    Private tripsArrivalDateTime As Date
    Private tripsDepartureDateTime As Date


    Public Property ID() As Integer
        Get
            Return tripsTripID
        End Get
        Private Set(ByVal value As Integer)
            tripsTripID = value
        End Set
    End Property


    Public Property Carrier() As String
        Get
            Return tripsCarrierName
        End Get
        Set(value As String)
            tripsCarrierName = value
        End Set

    End Property

    Public Property OpName() As String
        Get
            Return tripsOperatorName
        End Get
        Set(value As String)
            tripsOperatorName = value
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

    Public Property Agreement() As Integer
        Get
            Return tripsAgreementID
        End Get
        Private Set(ByVal value As Integer)
            tripsAgreementID = value
        End Set
    End Property

    Public Property Arrival() As Date
        Get
            Return tripsArrivalDateTime
        End Get
        Private Set(ByVal value As Date)
            tripsArrivalDateTime = value
        End Set
    End Property

    Public Property Departure() As Date
        Get
            Return tripsDepartureDateTime
        End Get
        Private Set(ByVal value As Date)
            tripsDepartureDateTime = value
        End Set
    End Property

    Public Sub New()
        Me.ID = Nothing
        Me.Carrier = Nothing
        Me.TripDestination = Nothing
        Me.TripCity = Nothing
        Me.TripStatus = Nothing
        Me.Confirmation = Nothing
        Me.Agreement = Nothing
        Me.OpName = Nothing
        Me.Arrival = Nothing
        Me.Departure = Nothing

    End Sub


    ''Need to finish this
    Public Sub New(id As Integer, name As String, dest As String, city As String, status As String, confNumber As String, agreeNumber As Integer, opName As String, arrivalDate As Date, departDate As Date)
        Me.ID = id
        Me.Carrier = name
        Me.TripDestination = dest
        Me.TripCity = city
        Me.TripStatus = status
        Me.Confirmation = confNumber
        Me.Agreement = agreeNumber
        Me.OpName = opName
        Me.Arrival = arrivalDate
        Me.Departure = departDate
    End Sub


End Class
