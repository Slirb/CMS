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

        Dim states As New List(Of State)
        With states
            .Add(New State("Alabama", "AL"))
            .Add(New State("Alaska", "AK"))
            .Add(New State("Arizona", "AZ"))
            .Add(New State("Arkansas", "AR"))
            .Add(New State("California", "CA"))
            .Add(New State("Colorado", "CO"))
            .Add(New State("Connecticut", "CT"))
            .Add(New State("Delaware", "DE"))
            .Add(New State("Florida", "FL"))
            .Add(New State("Georgia", "GA"))
            .Add(New State("Hawaii", "HI"))
            .Add(New State("Idaho", "ID"))
            .Add(New State("Illinois", "IL"))
            .Add(New State("Indiana", "IN"))
            .Add(New State("Iowa", "IA"))
            .Add(New State("Kansas", "KS"))
            .Add(New State("Kentucky", "KY"))
            .Add(New State("Louisiana", "LA"))
            .Add(New State("Maine", "ME"))
            .Add(New State("Maryland", "MD"))
            .Add(New State("Massachusetts", "MA"))
            .Add(New State("Michigan", "MI"))
            .Add(New State("Minnesota", "MN"))
            .Add(New State("Mississippi", "MS"))
            .Add(New State("Missouri", "MO"))
            .Add(New State("Montana", "MT"))
            .Add(New State("Nebraska", "NE"))
            .Add(New State("Nevada", "NV"))
            .Add(New State("New Hampshire", "NH"))
            .Add(New State("New Jersey", "NJ"))
            .Add(New State("New Mexico", "NM"))
            .Add(New State("New York", "NY"))
            .Add(New State("North Carolina", "NC"))
            .Add(New State("North Dakota", "ND"))
            .Add(New State("Ohio", "OH"))
            .Add(New State("Oklahoma", "OK"))
            .Add(New State("Oregon", "OR"))
            .Add(New State("Pennsylvania", "PA"))
            .Add(New State("Rhode Island", "RI"))
            .Add(New State("South Carolina", "SC"))
            .Add(New State("South Dakota", "SD"))
            .Add(New State("Tennessee", "TN"))
            .Add(New State("Texas", "TX"))
            .Add(New State("Utah", "UT"))
            .Add(New State("Vermont", "VT"))
            .Add(New State("Virginia", "VA"))
            .Add(New State("Washington", "WA"))
            .Add(New State("West Virginia", "WV"))
            .Add(New State("Wisconsin", "WI"))
            .Add(New State("Wyoming", "WY"))
        End With
        states.ForEach(Sub(stat) context.states.Add(stat))


        context.SaveChanges()

        Dim companies As New List(Of CharterCompany)
        With companies
            .Add(New CharterCompany("Greyhound", "Test", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing))
            .Add(New CharterCompany("Metra", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing))
            .Add(New CharterCompany("Bob's Buses", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing))
        End With
        companies.ForEach(Sub(comp) context.companies.Add(comp))


        context.SaveChanges()

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
