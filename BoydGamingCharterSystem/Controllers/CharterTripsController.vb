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
    Public Class CharterTripsController
        Inherits System.Web.Mvc.Controller

        Private db As New CharterSystem


        ' GET: CharterTrips
        Function Index(Optional ByVal potential As Boolean = True, Optional ByVal active As Boolean = True, Optional ByVal applied As Boolean = True,
                       Optional ByVal completed As Boolean = True, Optional ByVal Cancelled As Boolean = True) As ActionResult
            ''Dim trips
            Dim status As New List(Of String)

            ''trips = db.trips.ToList()
            Dim test() As String = {"Active", "Applied"}


            If (potential = True) Then
                status.Add("Potential")
                ''trips = db.trips.Where(Function(trip) trip.TripStatus.Contains("Potential"))
            End If

            If (active = True) Then
                status.Add("Active")
                ''trips = db.trips.Where(Function(trip) trip.TripStatus.Contains("Active"))
            End If

            If (applied = True) Then
                status.Add("Applied")
                ''trips = db.trips.Where(Function(trip) trip.TripStatus.Contains("Applied"))
            End If

            If (completed = True) Then
                status.Add("Completed")
                ''trips = db.trips.Where(Function(trip) trip.TripStatus.Contains("Completed"))
            End If

            If (Cancelled = True) Then
                status.Add("Cancelled")
                ''trips = db.trips.Where(Function(trip) trip.TripStatus.Contains("Cancelled"))
            End If


            Dim trips = From t In db.trips.ToList()
                        Join s In status On t.TripStatus Equals s
                        Select t

            Return View(trips)
        End Function

        ' GET: CharterTrips/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim charterTrip As CharterTrips = db.trips.Find(id)
            If IsNothing(charterTrip) Then
                Return HttpNotFound()
            End If
            Return View(charterTrip)
        End Function

        ' GET: CharterTrips/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: CharterTrips/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,Name")> ByVal charterTrip As CharterTrips) As ActionResult
            If ModelState.IsValid Then
                db.trips.Add(charterTrip)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(charterTrip)
        End Function

        ' GET: CharterTrips/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim charterTrip As CharterTrips = db.trips.Find(id)
            If IsNothing(charterTrip) Then
                Return HttpNotFound()
            End If
            Return View(charterTrip)
        End Function

        ' POST: CharterTrips/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,Name")> ByVal charterTrip As CharterTrips) As ActionResult
            If ModelState.IsValid Then
                db.Entry(charterTrip).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(charterTrip)
        End Function

        ' GET: CharterTrips/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim charterTrip As CharterTrips = db.trips.Find(id)
            If IsNothing(charterTrip) Then
                Return HttpNotFound()
            End If
            Return View(charterTrip)
        End Function

        ' POST: CharterTrips/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim charterTrip As CharterTrips = db.trips.Find(id)
            db.trips.Remove(charterTrip)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
