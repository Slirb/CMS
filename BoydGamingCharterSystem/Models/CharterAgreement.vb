Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Public Class CharterAgreement

    <Key>
    Private charterAgreementId As Integer

    <ForeignKey("CharterCarrier")>
    Private charterAgreementCarrier As CharterCarrier

    <ForeignKey("CharterOperator")>
    Private charterAgreementOperator As CharterOperator
    Private charterAgreementCreateDate As Date


    Public Property Id() As Integer
        Get
            Return charterAgreementId
        End Get
        Private Set(value As Integer)
            charterAgreementId = value
        End Set
    End Property

    Public Overridable Property CharterCarrier() As CharterCarrier
        Get
            Return charterAgreementCarrier
        End Get
        Set(value As CharterCarrier)
            charterAgreementCarrier = value
        End Set

    End Property

    Public Overridable Property CharterOperator() As CharterOperator
        Get
            Return charterAgreementOperator
        End Get
        Set(value As CharterOperator)
            charterAgreementOperator = value
        End Set
    End Property


    Public Property CreateDate() As Date
        Get
            Return charterAgreementCreateDate
        End Get
        Set(value As Date)
            charterAgreementCreateDate = value
        End Set
    End Property

    Public Sub New(id As Integer, charterCarrier As CharterCarrier, charterOperator As CharterOperator)
        Me.Id = id
        Me.CharterCarrier = charterCarrier
        Me.CharterOperator = charterOperator
        Me.CreateDate = Date.Now

    End Sub

End Class
