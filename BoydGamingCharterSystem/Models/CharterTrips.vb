Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema


Public Class CharterTrips

    Private tripsTripID As Integer
    Private tripsDestination As String
    Private tripsCity As String
    Private tripsStatus As String
    Private tripsConfirmationNumber As String

    Public Property charterAgreementId() As Integer
    <ForeignKey("charterAgreementId")>
    Public Property CharterAgreements() As CharterAgreement


    Public Property CarrierId() As Integer
    Public Property CarrierName As String
    Public Property OperatorId() As Integer
    Public Property OperatorName As String



    Private tripsArrivalDateTime As Date
    Private tripsDepartureDateTime As Date

    <Key>
    Public Property ID() As Integer
        Get
            Return tripsTripID
        End Get
        Private Set(ByVal value As Integer)
            tripsTripID = value
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

    Public Property TripCarrierName() As String
        Get
            Return CarrierName
        End Get
        Set(value As String)
            CarrierName = value
        End Set

    End Property

    Public Property TripOperatorName() As String
        Get
            Return OperatorName
        End Get
        Set(value As String)
            OperatorName = value
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
        Me.CarrierId = Nothing
        Me.TripDestination = Nothing
        Me.TripCity = Nothing
        Me.TripStatus = Nothing
        Me.Confirmation = Nothing
        Me.charterAgreementId = Nothing
        Me.OperatorId = Nothing
        Me.Arrival = Nothing
        Me.Departure = Nothing
        Me.OperatorName = Nothing
        Me.CarrierName = Nothing


    End Sub


    ''Need to finish this
    Public Sub New(id As Integer, dest As String, city As String, status As String, confNumber As String, charterAgreement As CharterAgreement,
                   carrier As CharterCarrier, ops As CharterOperator, arrivalDate As Date, departDate As Date)
        Me.ID = id
        Me.CarrierId = carrier.Id
        Me.TripDestination = dest
        Me.TripCity = city
        Me.TripStatus = status
        Me.Confirmation = confNumber
        Me.CharterAgreements = charterAgreement
        Me.OperatorId = ops.Id
        Me.Arrival = arrivalDate
        Me.Departure = departDate
        Me.CarrierName = charterAgreement.CharterCarrier.Company.Name
        Me.OperatorName = charterAgreement.CharterOperator.Company.Name
    End Sub


End Class
