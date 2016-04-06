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
            .Add(New State("Indiana", "IN"))
            .Add(New State("Kansas", "KS"))
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

        'Trips 
        Dim trips As New List(Of CharterTrips)
        With trips
            .Add(New CharterTrips(2, "Biloxi", "Biloxi", "Potential", Nothing, agreements.Item(0), Date.Now, Date.Now.AddDays(3)))
            .Add(New CharterTrips(3, "Biloxi", "Baton Rouge", "Cancelled", "BI68735TG", agreements.Item(1), Date.Now.AddDays(20), Date.Now.AddDays(23)))
            .Add(New CharterTrips(4, "Biloxi", "Orlando", "Active", "BI94682TG", agreements.Item(2), Date.Now.AddDays(40), Date.Now.AddDays(43)))
            .Add(New CharterTrips(5, "Biloxi", "Mobile", "Applied", "BI68742TG", agreements.Item(1), Date.Now.AddDays(60), Date.Now.AddDays(63)))
            .Add(New CharterTrips(7, "Biloxi", "Atlanta", "Completed", "BI98761TG", agreements.Item(0), Date.Now.AddDays(80), Date.Now.AddDays(83)))


        End With
        trips.ForEach(Sub(trip) context.trips.Add(trip))
        context.SaveChanges()

        'Tiered Commissions
        Dim commissions As New List(Of CharterTieredCommissions)
        With commissions
            .Add(New CharterTieredCommissions(1, 2, "test 1", "example", 200, 250, 100))
            .Add(New CharterTieredCommissions(2, 2, "test 1", "example", 250, 450, 200))
        End With
        commissions.ForEach(Sub(commission) context.commissions.Add(commission))
        context.SaveChanges()

        'Manifests
        Dim manifests As New List(Of CharterManifest)
        With manifests
            .Add(New CharterManifest(1, 300049, "Steve", "Harvey", "L", Date.Now, "Test Address", Nothing, "Houston", states.Item(1), "46511", trips.Item(2)))
            .Add(New CharterManifest(2, 3028, "Mary", "Poppins", "T", Date.Now, "Test Address 2", Nothing, "Orlando", states.Item(2), "56533", trips.Item(2)))
        End With
        manifests.ForEach(Sub(manifest) context.manifests.Add(manifest))
        context.SaveChanges()
        ''END CHANGES-----------------------


    End Sub

End Class
