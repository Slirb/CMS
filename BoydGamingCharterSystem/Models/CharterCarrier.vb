Imports System.ComponentModel.DataAnnotations


Public Class CharterCarrier
    <Key>
    Private carrierId As Integer


    Private carrierName As String

    Private carrierContactInfo As ContactInformation



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
    Public Property contactInfo() As ContactInformation
        Get
            Return carrierContactInfo
        End Get
        Set(value As ContactInformation)
            carrierContactInfo = value
        End Set
    End Property

    Public Sub New()
        Me.Id = Nothing
        Me.Name = Nothing
        Me.contactInfo = New ContactInformation


    End Sub



    Public Sub New(id As Integer, name As String)
        Me.New()

        Me.Id = id
        Me.Name = name

    End Sub




End Class
