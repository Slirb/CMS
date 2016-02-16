Imports System.Data.Entity
Imports System.Data.Entity.ModelConfiguration.Conventions



Public Class CharterSystem
    Inherits DbContext

    Private CharterCarriers As DbSet(Of CharterCarrier)
    Private CharterOperators As DbSet(Of CharterOperator)
    Private CharterAgreements As DbSet(Of CharterAgreement)

    Public Property carriers As DbSet(Of CharterCarrier)
        Get
            Return CharterCarriers
        End Get
        Set(value As DbSet(Of CharterCarrier))
            CharterCarriers = value
        End Set

    End Property
    Public Property operators As DbSet(Of CharterOperator)
        Get
            Return CharterOperators
        End Get
        Set(value As DbSet(Of CharterOperator))
            CharterOperators = value
        End Set
    End Property
    Public Property agreements As DbSet(Of CharterAgreement)
        Get
            Return CharterAgreements

        End Get
        Set(value As DbSet(Of CharterAgreement))
            CharterAgreements = value
        End Set
    End Property

    Public Sub New()

        MyBase.New("CharterSystem")
        Database.SetInitializer(Of CharterSystem)(New CharterSystemInitializer())

    End Sub

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        modelBuilder.Conventions.Remove(Of PluralizingTableNameConvention)()

    End Sub




End Class

