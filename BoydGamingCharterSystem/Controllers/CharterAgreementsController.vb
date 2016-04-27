Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports BoydGamingCharterSystem

Namespace Controllers
    Public Class CharterAgreementsController
        Inherits System.Web.Mvc.Controller

        Private db As New CharterSystem

        ' GET: CharterAgreements
        Function Index() As ActionResult
            Dim agreements = db.agreements.Include(Function(c) c.CharterCarrier).Include(Function(c) c.CharterOperator).Include(Function(c) c.CharterCarrier.Company).Include(Function(c) c.CharterOperator.Company)
            Return View(agreements.ToList())
        End Function

        ' GET: CharterAgreements/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim charterAgreement As CharterAgreement = db.agreements.Find(id)
            If IsNothing(charterAgreement) Then
                Return HttpNotFound()
            End If
            Return View(charterAgreement)
        End Function

        ' GET: CharterAgreements/Create
        Function Create() As ActionResult

            Dim agreement As CharterAgreement = New CharterAgreement
            ViewBag.CarrierId = New SelectList(db.carriers.Include(Function(c) c.Company), "Id", "Name")
            ViewBag.OperatorId = New SelectList(db.operators.Include(Function(c) c.Company), "Id", "Name")
            ViewBag.Properties = New SelectList(db.properties, "Id", "ShortName")
            Return View(agreement)
        End Function

        ' POST: CharterAgreements/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(ByVal charterAgreement As CharterAgreement) As ActionResult
            If ModelState.IsValid Then

                For Each trip In charterAgreement.CharterTrips
                    trip.CharterAgreements = charterAgreement
                    trip.TripCity = charterAgreement.City
                    trip.TripStatus = "Potential"
                Next

                db.agreements.Add(charterAgreement)

                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.CarrierId = New SelectList(db.carriers.Include(Function(c) c.Company), "Id", "Name")
            ViewBag.OperatorId = New SelectList(db.operators.Include(Function(c) c.Company), "Id", "Name")
            ViewBag.Properties = New SelectList(db.properties, "Id", "ShortName")
            Return View(charterAgreement)
        End Function




        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim charterAgreement As CharterAgreement = (From agreement In db.agreements.Include(Function(c) c.CharterTrips)
                                                        Select agreement Where agreement.Id = id).FirstOrDefault()

            If IsNothing(charterAgreement) Then
                Return HttpNotFound()
            End If
            ViewBag.CarrierId = New SelectList(db.carriers.Include(Function(c) c.Company), "Id", "Name")
            ViewBag.OperatorId = New SelectList(db.operators.Include(Function(c) c.Company), "Id", "Name")
            ViewBag.Properties = New SelectList(db.properties, "Id", "ShortName")
            Return View(charterAgreement)
        End Function

        ' POST: CharterAgreements/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(ByVal charterAgreement As CharterAgreement) As ActionResult
            If ModelState.IsValid Then
                'Get existing agreement from database
                Dim existingAgreement As CharterAgreement = (From agreement In db.agreements.AsNoTracking().Include(Function(c) c.CharterOperator).AsNoTracking().Include(Function(c) c.CharterCarrier).AsNoTracking().Include(Function(c) c.CharterTrips).AsNoTracking()
                                                             Select agreement Where agreement.Id = charterAgreement.Id).FirstOrDefault()


                'Get existing agreement's trips
                Dim existingTrips As List(Of CharterTrips) = existingAgreement.CharterTrips
                Dim savedTrips As List(Of CharterTrips) = existingTrips.Where(Function(p) charterAgreement.CharterTrips.Any(Function(c) c.Id = p.Id)).ToList()

                '
                'Update and Edit new and existing trips
                For Each trip In charterAgreement.CharterTrips.Where(Function(c) c.Id = 0)
                    Static Dim tripCounter As Integer = -1
                    trip.Id = tripCounter
                    tripCounter -= 1
                    trip.TripStatus = "Potential"
                Next

                'Preserve uneditable data in existing trips
                For Each trip In savedTrips
                    Dim saveTrip As CharterTrips = charterAgreement.CharterTrips.Find(Function(c) c.Id = trip.Id)
                    saveTrip.CharterManifests = trip.CharterManifests
                    saveTrip.Confirmation = trip.Confirmation
                    saveTrip.ManifestCount = trip.ManifestCount
                    saveTrip.TripCity = trip.TripCity
                    saveTrip.TripNotes = trip.TripNotes
                    saveTrip.TripStatus = trip.TripStatus
                Next

                For Each trip In charterAgreement.CharterTrips
                    trip.CharterAgreements = charterAgreement
                    If trip.Id < 0 Then
                        db.Entry(trip).State = EntityState.Added
                    Else
                        db.Entry(trip).State = EntityState.Modified
                    End If
                Next

                db.Entry(charterAgreement).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.CarrierId = New SelectList(db.carriers.Include(Function(c) c.Company), "Id", "Name")
            ViewBag.OperatorId = New SelectList(db.operators.Include(Function(c) c.Company), "Id", "Name")
            ViewBag.Properties = New SelectList(db.properties, "Id", "ShortName")
            Return View(charterAgreement)
        End Function

        ''Get :   CharterAgreements/Delete/5
        'Function Delete(ByVal id As Integer?) As ActionResult
        '    If IsNothing(id) Then
        '        Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        '    End If
        '    Dim charterAgreement As CharterAgreement = db.agreements.Find(id)
        '    If IsNothing(charterAgreement) Then
        '        Return HttpNotFound()
        '    End If
        '    Return View(charterAgreement)
        'End Function

        '' POST: CharterAgreements/Delete/5
        '<HttpPost()>
        '<ActionName("Delete")>
        '<ValidateAntiForgeryToken()>
        'Function DeleteConfirmed(ByVal id As Integer) As ActionResult
        '    Dim charterAgreement As CharterAgreement = db.agreements.Find(id)
        '    db.agreements.Remove(charterAgreement)
        '    db.SaveChanges()
        '    Return RedirectToAction("Index")
        'End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
