﻿Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
<Table("CharterAgreement")>
Public Class CharterAgreement

    <Key>
    Public Property Id As Integer


    Public Property Name As String
    Public Property Description As String

    Public Property CreatedDateTime As Date?
    Public Property LastUpdatedDateTime As Date?



    Public Property City As String

    Public Property BenefitDescription As String
    Public Property UseCommAmountPerCustomer As Boolean
    Public Property CommAmountPerCustomer As Decimal
    Public Property UseCommPercentOfCustSpend As Boolean
    Public Property CommPercentOfCustSpend As Decimal
    Public Property UseCommAmountPerBus As Boolean
    Public Property CommAmountPerBus As Decimal


    Public Property TieredCommission As CharterTieredCommissions
    Public Property TripCost As Decimal
    Public Property Cancelled As Boolean

    Public Property InvoiceToOperator As Boolean
    Public Property InvoiceToCarrier As Boolean

    <Required>
    <Display(Name:="Carrier")>
    Public Property CharterCarrierId As Integer?

    Public Overridable Property CharterCarrier As CharterCarrier

    <Required>
    <Display(Name:="Operator")>
    Public Property CharterOperatorId As Integer?

    Public Overridable Property CharterOperator As CharterOperator

    <Display(Name:="Destination")>
    Public Property CharterPropertyId As Integer?

    Public Overridable Property CharterProperty As CharterProperties
    Public Property CharterTrips As List(Of CharterTrips)

    <NotMapped>
    Public ReadOnly Property CarrierName As String
        Get
            Return Me.CharterCarrier.Name
        End Get

    End Property

    <NotMapped>
    Public ReadOnly Property OperatorName As String
        Get
            Return Me.CharterOperator.Name
        End Get
    End Property

    Public Sub New()
        Me.CreatedDateTime = DateTime.Now
        'Me.CharterProperty = New CharterProperties()
        'Me.CharterOperator = New CharterOperator()
        'Me.CharterCarrier = New CharterCarrier()
        Me.CharterTrips = New List(Of CharterTrips)



    End Sub


    Public Sub New(id As Integer, charterCarrier As CharterCarrier, charterOperator As CharterOperator, charterproperty As CharterProperties, name As String, city As String)

        Me.New()
        Me.Id = id
        Me.CharterCarrier = charterCarrier
        Me.CharterOperator = charterOperator
        Me.CharterProperty = charterproperty
        Me.Name = name
        Me.City = city


    End Sub

End Class

