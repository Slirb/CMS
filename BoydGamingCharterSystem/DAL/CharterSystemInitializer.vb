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





        ''CHANGES---------------------------
        Dim trips As New List(Of CharterTrips)
        With trips
            .Add(New CharterTrips(18, "Greyhound", "Biloxi", "Biloxi", "Potential", "BI75298TG", agreements.Item(0), "Happy Holidays", "2016-05-07", "2016-05-10"))
            .Add(New CharterTrips(25, "Metra", "Biloxi", "Baton Rouge", "Cancelled", "BI68735TG", 456, "Tim's Travel Services", "2016-06-05", "2016-06-11"))
            .Add(New CharterTrips(25, "Spirit Tracks", "Biloxi", "Orlando", "Active", "BI94682TG", 456, "Vegas Travellers", "2016-07-10", "2016-07-11"))
            .Add(New CharterTrips(18, "Paradise Line", "Biloxi", "Mobile", "Applied", "BI68742TG", 3, "First Travel Center", "2016-05-07", "2016-05-10"))
            .Add(New CharterTrips(25, "Bob's Buses", "Biloxi", "Atlanta", "Completed", "BI98761TG", 3, "Rich Springs Travel Companion", "2016-08-09", "2016-08-11"))


        End With
        trips.ForEach(Sub(trip) context.trips.Add(trip))
        context.SaveChanges()



        ''END CHANGES-----------------------


    End Sub

End Class
