﻿Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Data.Entity
Imports CharterSystem


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
            .Add(New CharterCompany("Greyhound", "1234 Sample Street", Nothing, "Michigan City", states.Item(13), "46361", Nothing, "USA", "greyhound@hotmail.com"))
            .Add(New CharterCompany("Metra", "536 Main Street", Nothing, "Michigan City", states.Item(13), "46361", Nothing, "USA", "metra@gmail.com"))
            .Add(New CharterCompany("Bob's Buses", "985 West Avenue", Nothing, "Michigan City", states.Item(13), "46361", Nothing, "USA", "bobsbusses@hotmail.com"))
            .Add(New CharterCompany("Paradise Line", "3214 South Street", Nothing, "Michigan City", states.Item(13), "46361", Nothing, "USA", "paradiselines@hotmail.com"))
            .Add(New CharterCompany("Spirit Tracks", "654 West Parkway", Nothing, "Michigan City", states.Item(13), "46361", Nothing, "USA", "spirittracks@gmail.com"))
            .Add(New CharterCompany("Vegas Carriers", "944 Michigan Street", Nothing, "Michigan City", states.Item(13), "46361", Nothing, "USA", "vegascarriers@gmail.com"))
            .Add(New CharterCompany("Tim's Travel Services", "198 Long Avenue", Nothing, "Michigan City", states.Item(13), "46361", Nothing, "USA", "timstravel@yahoo.com"))
            .Add(New CharterCompany("Rich Springs Travel Companion", "621 Hill Drive", Nothing, "Michigan City", states.Item(13), "46361", Nothing, "USA", "richsprings@yahoo.com"))
            .Add(New CharterCompany("First Travel Center", "20 Park Avenue", Nothing, "Michigan City", states.Item(13), "46361", Nothing, "USA", "1sttravel@gmail.com"))
            .Add(New CharterCompany("First Stop on the Journey Travel Agency", "67 Lakeshore Drive", Nothing, "Michigan City", states.Item(13), "46361", Nothing, "USA", "firststop@hotmail.com"))
            .Add(New CharterCompany("Vegas Travellers", "327 Fairview Lane", Nothing, "Michigan City", states.Item(13), "46361", Nothing, "USA", "vegastravellersd@hotmail.com"))
            .Add(New CharterCompany("Windy City Travel", "361 John Adams Drive", Nothing, "Michigan City", states.Item(13), "46361", Nothing, "USA", "wct@yahoo.com"))

        End With
        companies.ForEach(Sub(comp) context.companies.Add(comp))

        context.SaveChanges()

        Dim carriers As New List(Of CharterCarrier)
        With carriers
            .Add(New CharterCarrier())
            .Last().Company = companies.Item(0)
            .Last().HasInsurance = True
            .Last().InsuranceNumber = "15879631"
            .Last().InsuranceExpiration = Date.Now
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


        'Properties
        Dim properties As New List(Of CharterProperties)
        With properties
            .Add(New CharterProperties(1, "Property One", "P1", "5741234567", "5743689874"))
            .Add(New CharterProperties(1, "Property Two", "P2", "5746983214", "5743856492"))
        End With
        properties.ForEach(Sub(p) context.properties.Add(p))
        context.SaveChanges()


        Dim agreements As New List(Of CharterAgreement)
        With agreements
            .Add(New CharterAgreement(3, carriers.Item(0), operators.Item(2), properties.Item(0), "Jim's Agreement", "Chicago"))
            .Add(New CharterAgreement(456, carriers.Item(4), operators.Item(5), properties.Item(1), "Sample Agreement", "South Bend"))
            .Add(New CharterAgreement(638, carriers.Item(2), operators.Item(4), properties.Item(0), "Mary's Agreement", "Boston"))

        End With
        agreements.ForEach(Sub(agree) context.agreements.Add(agree))
        context.SaveChanges()





        ''CHANGES---------------------------

        'Trips 

        Dim trips As New List(Of CharterTrips)
        With trips
            .Add(New CharterTrips(1, "Potential", Nothing, agreements.Item(0), Date.Now, Date.Now.AddDays(3)))
            .Add(New CharterTrips(2, "Cancelled", "AB68735TG", agreements.Item(1), Date.Now.AddDays(20), Date.Now.AddDays(23)))
            .Add(New CharterTrips(3, "Active", "AB94682TG", agreements.Item(2), Date.Now.AddDays(40), Date.Now.AddDays(43)))
            .Add(New CharterTrips(4, "Applied", "AB68742TG", agreements.Item(1), Date.Now.AddDays(60), Date.Now.AddDays(63)))
            .Add(New CharterTrips(5, "Completed", "AB98761TG", agreements.Item(0), Date.Now.AddDays(80), Date.Now.AddDays(83)))


        End With
        trips.ForEach(Sub(trip) context.trips.Add(trip))
        context.SaveChanges()

        'Tiered Commissions
        Dim commissions As New List(Of CharterTieredCommissions)
        With commissions
            .Add(New CharterTieredCommissions(1, "Commission One", "This is an example commission"))
            .Add(New CharterTieredCommissions(2, "Commission Two", "Another Example"))
        End With
        commissions.ForEach(Sub(commission) context.commissions.Add(commission))
        context.SaveChanges()

        'Operator Interests
        Dim interests As New List(Of CharterOperatorInterest)
        With interests
            .Add(New CharterOperatorInterest(1, "Interest One"))
            .Add(New CharterOperatorInterest(1, "Interest Two"))
        End With
        interests.ForEach(Sub(interest) context.operatorInterests.Add(interest))
        context.SaveChanges()


        'Operator Modes
        Dim modes As New List(Of CharterOperatorMode)
        With modes
            .Add(New CharterOperatorMode(1, "Mode One"))
            .Add(New CharterOperatorMode(1, "Mode Two"))
        End With
        modes.ForEach(Sub(mode) context.operatorModes.Add(mode))
        context.SaveChanges()

        'Operator Stop Codes
        Dim codes As New List(Of CharterOperatorStopCode)
        With codes
            .Add(New CharterOperatorStopCode(1, "Stop Code One"))
            .Add(New CharterOperatorStopCode(1, "Stop Code Two"))
        End With
        codes.ForEach(Sub(code) context.operatorStopCodes.Add(code))
        context.SaveChanges()


        'Operator Types
        Dim types As New List(Of CharterOperatorType)
        With types
            .Add(New CharterOperatorType(1, "Type One"))
            .Add(New CharterOperatorType(1, "Type Two"))
        End With
        types.ForEach(Sub(type) context.operatorTypes.Add(type))
        context.SaveChanges()

        'Manifests
        Dim manifests As New List(Of CharterManifest)
        With manifests
            .Add(New CharterManifest(1, 300049, "Steve", "Harvey", "L", Date.Now, "Test Address", Nothing, "Michigan City", states.Item(13), "46361", trips.Item(2)))
            .Add(New CharterManifest(2, 302831, "Mary", "Poppins", "T", Date.Now, "Test Address 2", Nothing, "Michigan City", states.Item(13), "46361", trips.Item(2)))
            .Add(New CharterManifest(3, 300050, "Mark", "Finn", "A", Date.Now, "Test Address 3", Nothing, "Michigan City", states.Item(13), "46361", trips.Item(1)))
            .Add(New CharterManifest(4, 300831, "Amy", "Hope", "B", Date.Now, "Test Address 4", Nothing, "Michigan City", states.Item(13), "46361", trips.Item(1)))
            .Add(New CharterManifest(5, 300749, "John", "Jenkins", "C", Date.Now, "Test Address 5", Nothing, "Michigan City", states.Item(13), "46361", trips.Item(3)))
            .Add(New CharterManifest(6, 302031, "Katy", "Perry", "D", Date.Now, "Test Address 6", Nothing, "Michigan City", states.Item(13), "46361", trips.Item(3)))
            .Add(New CharterManifest(7, 310049, "Bob", "Villa", "E", Date.Now, "Test Address 7", Nothing, "Michigan City", states.Item(13), "46361", trips.Item(4)))
            .Add(New CharterManifest(8, 304631, "Ashley", "Higgins", "F", Date.Now, "Test Address 8", Nothing, "Michigan City", states.Item(13), "46361", trips.Item(4)))
            .Add(New CharterManifest(9, 560049, "Scott", "Speed", "G", Date.Now, "Test Address 9", Nothing, "Michigan City", states.Item(13), "46361", trips.Item(3)))
            .Add(New CharterManifest(10, 400049, "Sam", "Worthy", "H", Date.Now, "Test Address 10", Nothing, "Michigan City", states.Item(13), "46361", trips.Item(4)))
            .Add(New CharterManifest(11, 502831, "Nancy", "Monroe", "I", Date.Now, "Test Address 11", Nothing, "Michigan City", states.Item(13), "46361", trips.Item(2)))
            .Add(New CharterManifest(12, 313049, "Kevin", "Smith", "J", Date.Now, "Test Address 12", Nothing, "Michigan City", states.Item(13), "46361", trips.Item(3)))
            .Add(New CharterManifest(13, 302491, "Olivia", "Banks", "K", Date.Now, "Test Address 13", Nothing, "Michigan City", states.Item(13), "46361", trips.Item(2)))
            .Add(New CharterManifest(14, 307349, "Paul", "James", "L", Date.Now, "Test Address 14", Nothing, "Michigan City", states.Item(13), "46361", trips.Item(4)))
            .Add(New CharterManifest(15, 365831, "Terri", "Long", "M", Date.Now, "Test Address 15", Nothing, "Michigan City", states.Item(13), "46361", trips.Item(2)))
            .Add(New CharterManifest(2, 302001, "Elise", "Kelly", "N", Date.Now, "Test Address 16", Nothing, "Michigan City", states.Item(13), "46361", trips.Item(2)))
        End With
        manifests.ForEach(Sub(manifest) context.manifests.Add(manifest))
        context.SaveChanges()






        'Updates the count for each trip
        trips.ForEach(Sub(trip) trip.ManifestCount = (From t In context.manifests.ToList()
                                                      Select t Where t.tripId = trip.Id).Count)
        'END CHANGES-----------------------



    End Sub

End Class
