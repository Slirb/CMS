Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Data.Entity
Imports BoydGamingCharterSystem

Public Class CharterSystemInitializer
    Inherits System.Data.Entity.DropCreateDatabaseAlways(Of CharterSystem)

    Public Overrides Sub InitializeDatabase(context As CharterSystem)
        context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, String.Format("ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE", context.Database.Connection.Database))
        MyBase.InitializeDatabase(context)
    End Sub


    Protected Overrides Sub Seed(context As CharterSystem)

        Dim carriers As New List(Of CharterCarrier)
        With carriers
            .Add(New CharterCarrier(15, "Greyhound"))
            .Add(New CharterCarrier(1893, "Metra"))
            .Add(New CharterCarrier(7899, "Bob's Buses"))
            .Add(New CharterCarrier(36, "Paradise Line"))
            .Add(New CharterCarrier(489, "Spirit Tracks"))
            .Add(New CharterCarrier(63, "Vegas Carriers"))
        End With
        carriers.ForEach(Sub(carr) context.carriers.Add(carr))


        context.SaveChanges()

        Dim operators As New List(Of CharterOperator)
        With operators
            .Add(New CharterOperator(48, "Happy Holidays"))
            .Add(New CharterOperator(6498, "Tim's Travel Services"))
            .Add(New CharterOperator(8873, "Rich Springs Travel Companion"))
            .Add(New CharterOperator(3368, "First Travel Center"))
            .Add(New CharterOperator(783, "First Stop on the Journey Travel Agency"))
            .Add(New CharterOperator(2, "Vegas Travellers"))

        End With
        operators.ForEach(Sub(oper) context.operators.Add(oper))
        context.SaveChanges()

        Dim agreements As New List(Of CharterAgreement)
        With agreements
            .Add(New CharterAgreement(3, carriers.Item(0), operators.Item(2)))
            .Add(New CharterAgreement(456, carriers.Item(4), operators.Item(5)))
            .Add(New CharterAgreement(638, carriers.Item(2), operators.Item(4)))

        End With
        agreements.ForEach(Sub(agree) context.agreements.Add(agree))
        context.SaveChanges()



    End Sub

End Class
