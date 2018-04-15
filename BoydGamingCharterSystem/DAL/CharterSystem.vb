Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Data.Entity.ModelConfiguration.Conventions
Imports CharterSystem

Public Class CharterSystem
    Inherits DbContext

    Private CharterCarriers As DbSet(Of CharterCarrier)
    Private CharterOperators As DbSet(Of CharterOperator)
    Private CharterAgreements As DbSet(Of CharterAgreement)
    Private CharterStates As DbSet(Of State)
    Private CharterCompany As DbSet(Of CharterCompany)
    Private CharterCommentable As DbSet(Of Commentable)
    Private CharterComments As DbSet(Of CharterComment)
    Private CharterContactable As DbSet(Of Contactable)
    Private CharterContacts As DbSet(Of CharterContact)

    'Changes
    Private CharterTrips As DbSet(Of CharterTrips)
    Private CharterTieredCommissions As DbSet(Of CharterTieredCommissions)
    Private CharterProperties As DbSet(Of CharterProperties)
    Private CharterManifests As DbSet(Of CharterManifest)
    Private CharterOperatorInterests As DbSet(Of CharterOperatorInterest)
    Private CharterOperatorModes As DbSet(Of CharterOperatorMode)
    Private CharterOperatorStopCodes As DbSet(Of CharterOperatorStopCode)
    Private CharterOperatorTypes As DbSet(Of CharterOperatorType)
    Private TieredCommissionValues As DbSet(Of TieredCommissionValues)

    ''Added Operator Interest
    Public Property operatorInterests As DbSet(Of CharterOperatorInterest)
        Get
            Return CharterOperatorInterests
        End Get
        Set(value As DbSet(Of CharterOperatorInterest))
            CharterOperatorInterests = value
        End Set

    End Property

    ''Added Operator Mode
    Public Property operatorModes As DbSet(Of CharterOperatorMode)
        Get
            Return CharterOperatorModes
        End Get
        Set(value As DbSet(Of CharterOperatorMode))
            CharterOperatorModes = value
        End Set

    End Property

    ''Added Operator Stop Codes
    Public Property operatorStopCodes As DbSet(Of CharterOperatorStopCode)
        Get
            Return CharterOperatorStopCodes
        End Get
        Set(value As DbSet(Of CharterOperatorStopCode))
            CharterOperatorStopCodes = value
        End Set

    End Property

    ''Added Operator Types
    Public Property operatorTypes As DbSet(Of CharterOperatorType)
        Get
            Return CharterOperatorTypes
        End Get
        Set(value As DbSet(Of CharterOperatorType))
            CharterOperatorTypes = value
        End Set

    End Property


    ''Added Manifest
    Public Property manifests As DbSet(Of CharterManifest)
        Get
            Return CharterManifests
        End Get
        Set(value As DbSet(Of CharterManifest))
            CharterManifests = value
        End Set

    End Property



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

    ''Added Tiered Commission values
    Public Property commissionValues As DbSet(Of TieredCommissionValues)
        Get
            Return TieredCommissionValues
        End Get
        Set(value As DbSet(Of TieredCommissionValues))
            TieredCommissionValues = value
        End Set

    End Property
    ''END CHANGES-----------------------------------


    Public Property contactable As DbSet(Of Contactable)
        Get
            Return CharterContactable
        End Get
        Set(value As DbSet(Of Contactable))
            CharterContactable = value
        End Set
    End Property

    Public Property contacts As DbSet(Of CharterContact)
        Get
            Return CharterContacts
        End Get
        Set(value As DbSet(Of CharterContact))
            CharterContacts = value
        End Set
    End Property

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

    Public Property comments As DbSet(Of CharterComment)
        Get
            Return Me.CharterComments
        End Get
        Set(value As DbSet(Of CharterComment))
            Me.CharterComments = value
        End Set

    End Property

    Public Property commentable As DbSet(Of Commentable)
        Get
            Return Me.CharterCommentable
        End Get
        Set(value As DbSet(Of Commentable))
            Me.CharterCommentable = value
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

    Public Overrides Function SaveChanges() As Integer
        For Each entry As DbEntityEntry In ChangeTracker.Entries() _
            .Where(Function(p) p.State = EntityState.Deleted)
            'Archive each entry to be deleted before doing the delete
            Me.archive(entry)
        Next

        Return MyBase.SaveChanges()
    End Function

    Private Sub archive(entry As DbEntityEntry)
        'Code that moves entry from 
    End Sub



End Class

