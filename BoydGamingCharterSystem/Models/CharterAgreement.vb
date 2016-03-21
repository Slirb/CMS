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

    Public Sub New(id As Integer, charterCarrier As CharterCarrier, charterOperator As CharterOperator)
        Me.Id = id
        Me.CharterCarrier = charterCarrier
        Me.CharterOperator = charterOperator
        Me.CreateDateTime = DateTime.Now
    End Sub

End Class
