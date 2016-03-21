Imports System.Data.Entity
Imports System.Data.Entity.ModelConfiguration.Conventions
Imports BoydGamingCharterSystem

Public Class CharterSystem
    Inherits DbContext

    Private CharterCarriers As DbSet(Of CharterCarrier)
    Private CharterOperators As DbSet(Of CharterOperator)
    Private CharterAgreements As DbSet(Of CharterAgreement)
    Private CharterStates As DbSet(Of State)
    Private CharterCompany As DbSet(Of CharterCompany)


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

    Public Property states As DbSet(Of State)
        Get
            Return CharterStates
        End Get
        Set(value As DbSet(Of State))
            CharterStates = value
        End Set
    End Property

    Public Property companies As DbSet(Of CharterCompany)
        Get
            Return CharterCompany
        End Get
        Set(value As DbSet(Of CharterCompany))
            CharterCompany = value
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

