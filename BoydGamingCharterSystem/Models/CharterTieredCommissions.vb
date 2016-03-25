Imports System.ComponentModel.DataAnnotations

Public Class CharterTieredCommissions
    <Key>
    Private commissionID As Integer
    Private commissionName As String
    Private commissionDescription As String
    Private commissionMin As Double
    Private commissionMax As Double
    Private commissionValuePerCustomer As Double


    Public Property ID() As Integer
        Get
            Return commissionID
        End Get
        Private Set(ByVal value As Integer)
            commissionID = value
        End Set
    End Property


    Public Property Name() As String
        Get
            Return commissionName
        End Get
        Set(value As String)
            commissionName = value
        End Set

    End Property

    Public Property Description() As String
        Get
            Return commissionDescription
        End Get
        Set(value As String)
            commissionDescription = value
        End Set

    End Property


    Public Property Minimum() As Double
        Get
            Return commissionMin
        End Get
        Private Set(ByVal value As Double)
            commissionMin = value
        End Set
    End Property


    Public Property Maximum() As Double
        Get
            Return commissionMax
        End Get
        Private Set(ByVal value As Double)
            commissionMax = value
        End Set
    End Property


    Public Property Value() As Double
        Get
            Return commissionValuePerCustomer
        End Get
        Private Set(ByVal value As Double)
            commissionValuePerCustomer = value
        End Set
    End Property

    Public Sub New()
        Me.commissionID = Nothing
        Me.commissionName = Nothing
        Me.commissionDescription = Nothing
        Me.commissionMin = Nothing
        Me.commissionMax = Nothing
        Me.commissionValuePerCustomer = Nothing
    End Sub


    ''Need to finish this
    ''Public Sub New(id As Integer, name As String)
    ''Me.ID = id
    ''Me.Name = name
    '' End Sub

End Class
