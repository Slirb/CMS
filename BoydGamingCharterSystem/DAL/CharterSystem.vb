Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Data.Entity.ModelConfiguration.Conventions
Imports BoydGamingCharterSystem

Public Class CharterSystem
    Inherits DbContext

    Private CharterCarriers As DbSet(Of CharterCarrier)
    Private CharterOperators As DbSet(Of CharterOperator)
    Private CharterAgreements As DbSet(Of CharterAgreement)
    Private CharterStates As DbSet(Of State)
    Private CharterCompany As DbSet(Of CharterCompany)
    Private CharterCommentable As DbSet(Of Commentable)
    Private CharterComments As DbSet(Of CharterComment)


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

