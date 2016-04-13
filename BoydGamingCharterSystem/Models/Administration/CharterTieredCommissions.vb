Imports System.ComponentModel.DataAnnotations

Public Class CharterTieredCommissions


    Private commissionID As Integer
    Private commissionName As String
    Private commissionDescription As String
    Private commissionMin As Double
    Private commissionMax As Double
    Private commissionValuePerCustomer As Double


    <Key>
    Public Property Id() As Integer



    Public Property comID() As Integer
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
        Me.Id = Nothing
        Me.commissionID = Nothing
        Me.commissionName = Nothing
        Me.commissionDescription = Nothing
        Me.commissionMin = Nothing
        Me.commissionMax = Nothing
        Me.commissionValuePerCustomer = Nothing
    End Sub



    Public Sub New(id As Integer, comId As Integer, name As String, description As String, min As Double, max As Double, valuePer As Double)
        Me.Id = id
        Me.comID = comId
        Me.Name = name
        Me.Description = description
        Me.Minimum = min
        Me.Maximum = max
        Me.Value = valuePer
    End Sub

End Class
