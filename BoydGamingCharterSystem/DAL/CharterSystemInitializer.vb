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
            .Add(New CharterCompany("Paradise Line", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing))
            .Add(New CharterCompany("Spirit Tracks", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing))
            .Add(New CharterCompany("Vegas Carriers", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing))
            .Add(New CharterCompany("Tim's Travel Services", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing))
            .Add(New CharterCompany("Rich Springs Travel Companion", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing))
            .Add(New CharterCompany("First Travel Center", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing))
            .Add(New CharterCompany("First Stop on the Journey Travel Agency", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing))
            .Add(New CharterCompany("Vegas Travellers", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing))
            .Add(New CharterCompany("Windy City Travel", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing))

        End With
        companies.ForEach(Sub(comp) context.companies.Add(comp))

        context.SaveChanges()

        Dim carriers As New List(Of CharterCarrier)
        With carriers
            .Add(New CharterCarrier())
            .Last().Company = companies.Item(0)
            .Last().HasInsurance = True
            .Last().InsuranceNumber = "15879631"
            .Add(New CharterCarrier())
            .Last().Company = companies.Item(1)
            .Add(New CharterCarrier())
            .Last().Company = companies.Item(2)
            .Add(New CharterCarrier())
            .Last().Company = companies.Item(3)
            .Add(New CharterCarrier())
            .Last().Company = companies.Item(4)
            .Add(New CharterCarrier())
            .Last().Company = companies.Item(5)
        End With

        carriers.Item(1).Comments.Add(New CharterComment("A comment for Metra"))
        carriers.Item(1).Comments.Add(New CharterComment("And another comment for Metra"))
        carriers.Item(3).Comments.Add(New CharterComment("A comment for Paradise Line"))
        carriers.ForEach(Sub(carr) context.carriers.Add(carr))


        context.SaveChanges()

        Dim operators As New List(Of CharterOperator)
        With operators
            .Add(New CharterOperator())
            .Last().Company = companies.Item(6)
            .Add(New CharterOperator())
            .Last().Company = companies.Item(7)
            .Add(New CharterOperator())
            .Last().Company = companies.Item(8)
            .Add(New CharterOperator())
            .Last().Company = companies.Item(9)
            .Add(New CharterOperator())
            .Last().Company = companies.Item(10)
            .Add(New CharterOperator())
            .Last().Company = companies.Item(11)

        End With

        operators.Item(2).Comments.Add(New CharterComment("A comment for Rich Springs Travel Companion"))

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






        Dim trips As New List(Of CharterTrips)
        With trips
            .Add(New CharterTrips(2, "Biloxi", "Biloxi", "Potential", "BI75298TG", agreements.Item(0), carriers.Item(0), operators.Item(0), "2016-05-07", "2016-05-10"))
            .Add(New CharterTrips(3, "Biloxi", "Baton Rouge", "Cancelled", "BI68735TG", agreements.Item(1), carriers.Item(1), operators.Item(1), "2016-06-05", "2016-06-11"))
            .Add(New CharterTrips(4, "Biloxi", "Orlando", "Active", "BI94682TG", agreements.Item(2), carriers.Item(2), operators.Item(2), "2016-07-10", "2016-07-11"))
            .Add(New CharterTrips(5, "Biloxi", "Mobile", "Applied", "BI68742TG", agreements.Item(1), carriers.Item(3), operators.Item(3), "2016-05-07", "2016-05-10"))
            .Add(New CharterTrips(7, "Biloxi", "Atlanta", "Completed", "BI98761TG", agreements.Item(0), carriers.Item(4), operators.Item(4), "2016-08-09", "2016-08-11"))


        End With
        trips.ForEach(Sub(trip) context.trips.Add(trip))
        context.SaveChanges()






    End Sub

End Class
