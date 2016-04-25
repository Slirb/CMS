Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Public Class TieredCommissionValues
    <Key>
    Public Property Id() As Integer

    Public Property commissionMin As Double
    Public Property commissionMax As Double
    Public Property commissionValuePerCustomer As Double

    Public Property CommissionID() As Integer
    <ForeignKey("CommissionID")>
    Public Property CharterTieredCommission() As CharterTieredCommissions



    Public Sub New()
        Me.Id = Nothing
        Me.CommissionID = Nothing
        Me.commissionMin = Nothing
        Me.commissionMax = Nothing
        Me.commissionValuePerCustomer = Nothing



    End Sub

    Public Sub New(id As Integer, comID As Integer, min As Double, max As Double, commission As Double)
        Me.Id = id
        Me.CommissionID = comID
        Me.commissionMin = min
        Me.commissionMax = max
        Me.commissionValuePerCustomer = commission
    End Sub

End Class
