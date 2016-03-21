﻿Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports BoydGamingCharterSystem
<Table("Carrier")>
Public Class CharterCarrier



    Private carrierId As Integer
    Private carrierCompany As CharterCompany

    Private carrierLicenseNumber As String
    Private carrierInsuranceNumber As String
    Private carrierInsuranceExpirationDate As DateTime

    'Possible TODO if necessary
    'Take this field and make it a list - a comments table will handle
    'the comments for carriers and operators together, and data about
    'those comments can be tracked




    Private carrierCreateDateTime As DateTime

    Private carrierLastUpdatedDateTime As DateTime

    Private carrierCommentable As Commentable

    'Private commentableId As Integer

    '<ForeignKey("commentableId")>
    Public Property Commentable As Commentable
        Get
            Return carrierCommentable
        End Get
        Set(value As Commentable)
            carrierCommentable = value
        End Set
    End Property

    <NotMapped>
    Public Property Comments() As ICollection(Of CharterComment)
        Get
            Return Commentable.Comments
        End Get
        Set(value As ICollection(Of CharterComment))
            Commentable.Comments = value
        End Set
    End Property


    <ForeignKey("CarrierId")>
    Public Property CharterAgreements As ICollection(Of CharterAgreement)


    <Key>
    Public Property Id() As Integer
        Get
            Return carrierId
        End Get
        Private Set(ByVal value As Integer)
            carrierId = value
        End Set
    End Property




    Public Property Company As CharterCompany
        Get
            Return carrierCompany
        End Get
        Set(value As CharterCompany)
            carrierCompany = value
        End Set
    End Property

    Public Sub New()

        Me.Id = Nothing

        Me.Commentable = New Commentable

    End Sub



End Class