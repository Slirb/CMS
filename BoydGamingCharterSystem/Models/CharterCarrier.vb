Imports System.ComponentModel.DataAnnotations
Imports BoydGamingCharterSystem

Public Class CharterCarrier
    <Key>
    Private carrierId As Integer
    Private carrierName As String
    Private company As CharterCompany



    Public Property Id() As Integer
        Get
            Return carrierId
        End Get
        Private Set(ByVal value As Integer)
            carrierId = value
        End Set
    End Property


    Public Property Name() As String
        Get
            Return carrierName
        End Get
        Set(value As String)
            carrierName = value
        End Set

    End Property

    Public Property CharterCompany As CharterCompany
        Get
            Return company
        End Get
        Set(value As CharterCompany)
            company = value
        End Set
    End Property

    Public Sub New()
        Me.Id = Nothing
        Me.Name = Nothing
        Me.CharterCompany = New CharterCompany
    End Sub

    Public Sub New(id As Integer, name As String)
        Me.Id = id
        Me.Name = name
    End Sub


End Class
