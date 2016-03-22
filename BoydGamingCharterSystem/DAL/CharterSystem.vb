Imports System.Data.Entity
Imports System.Data.Entity.ModelConfiguration.Conventions



Public Class CharterSystem
    Inherits DbContext

    Private CharterCarriers As DbSet(Of CharterCarrier)
    Private CharterOperators As DbSet(Of CharterOperator)
    Private CharterAgreements As DbSet(Of CharterAgreement)


    ''CHANGES----------------------------------


    Private CharterTrips As DbSet(Of CharterTrips)
    Private CharterTieredCommissions As DbSet(Of CharterTieredCommissions)
    Private CharterProperties As DbSet(Of CharterProperties)


    ''Added Properties
    Public Property properties As DbSet(Of CharterProperties)
        Get
            Return CharterProperties
        End Get
        Set(value As DbSet(Of CharterProperties))
            CharterProperties = value
        End Set

    End Property


    ''Added Trips
    Public Property trips As DbSet(Of CharterTrips)
        Get
            Return CharterTrips
        End Get
        Set(value As DbSet(Of CharterTrips))
            CharterTrips = value
        End Set

    End Property

    ''Added Tiered Commissions
    Public Property commissions As DbSet(Of CharterTieredCommissions)
        Get
            Return CharterTieredCommissions
        End Get
        Set(value As DbSet(Of CharterTieredCommissions))
            CharterTieredCommissions = value
        End Set

    End Property


    ''END CHANGES-----------------------------------



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

