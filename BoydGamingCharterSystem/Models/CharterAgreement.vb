Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Public Class CharterAgreement


    Private charterAgreementId As Integer




    Private charterAgreementCreatedDateTime As DateTime


    Public Property CarrierId() As Integer
    <ForeignKey("CarrierId")>
    Public Property CharterCarrier() As CharterCarrier

    Public Property OperatorId() As Integer
    <ForeignKey("OperatorId")>
    Public Property CharterOperator() As CharterOperator

    <ForeignKey("charterAgreementId")>
    Public Property CharterTrips As ICollection(Of CharterTrips)
    'Might just make a list of trips instead of going through the schedule to get to trips
    'Public Property Schedule() As List(Of CharterSchedule)

    <Key>
    Public Property Id() As Integer
        Get
            Return charterAgreementId
        End Get
        Private Set(value As Integer)
            charterAgreementId = value
        End Set
    End Property


    Public Property CreateDateTime() As DateTime
        Get
            Return charterAgreementCreatedDateTime
        End Get
        Set(value As DateTime)
            charterAgreementCreatedDateTime = value
        End Set
    End Property

    Public Sub New()
        Me.CreateDateTime = DateTime.Now
        'Me.Schedule = New List(Of CharterSchedule)

    End Sub

    Public Sub New(id As Integer, charterCarrier As CharterCarrier, charterOperator As CharterOperator)

        Me.New()
        Me.Id = id
        Me.CharterCarrier = charterCarrier
        Me.CharterOperator = charterOperator

    End Sub

End Class
