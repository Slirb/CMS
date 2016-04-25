Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Public Class CharterTieredCommissions


    Private CommissionID As Integer
    Private commissionName As String
    Private commissionDescription As String


    <ForeignKey("CommissionID")>
    Public Property TieredCommissionValues As List(Of TieredCommissionValues)


    <Key>
    Public Property Id() As Integer
        Get
            Return CommissionID
        End Get
        Set(ByVal value As Integer)
            CommissionID = value
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


    Public Sub New()
        Me.Id = Nothing
        Me.commissionID = Nothing
        Me.commissionName = Nothing
        Me.commissionDescription = Nothing

    End Sub



    Public Sub New(id As Integer, name As String, description As String)
        Me.Id = id
        Me.Name = name
        Me.Description = description

    End Sub

End Class
