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
    Public Class CharterCarriersController
        Inherits System.Web.Mvc.Controller

        Private db As New CharterSystem


        ' GET: CharterCarriers
        Function Index() As ActionResult
            Dim carriers As List(Of CharterCarrier)
            'This fetches all related data
            'We may not want to do this as we don't need EVERY contact
            'of each carrier - only a specific one
            'This is something we could figure out a better solution if
            'it turns out it's really slow
            carriers = (From carrier In db.carriers.Include(Function(c) c.Commentable).Include(Function(c) c.Company).Include(Function(c) c.Company.Contactable)
                        Select carrier).ToList()

            Return View(carriers)
        End Function

        ' GET: CharterCarriers/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim charterCarrier As CharterCarrier = db.carriers.Include(Function(c) c.Company).Include(Function(c) c.Commentable).Where(Function(c) c.Id = id).First()


            If IsNothing(charterCarrier) Then
                Return HttpNotFound()
            End If
            Return View(charterCarrier)
        End Function

        ' GET: CharterCarriers/Create
        Function Create() As ActionResult
            Dim carrier As CharterCarrier = New CharterCarrier()
            carrier.Company.CreateCharterContacts(2)

            'I suspect there is a better way to do this
            ViewBag.States = New SelectList(db.states, "Id", "Name")
            Return View(carrier)
        End Function

        ' POST: CharterCarriers/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,Name")> ByVal charterCarrier As CharterCarrier) As ActionResult
            If ModelState.IsValid Then
                db.carriers.Add(charterCarrier)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(charterCarrier)
        End Function

        ' GET: CharterCarriers/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim charterCarrier As CharterCarrier = db.carriers.Find(id)
            If IsNothing(charterCarrier) Then
                Return HttpNotFound()
            End If
            Return View(charterCarrier)
        End Function

        ' POST: CharterCarriers/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,Name")> ByVal charterCarrier As CharterCarrier) As ActionResult
            If ModelState.IsValid Then
                db.Entry(charterCarrier).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(charterCarrier)
        End Function

        ' GET: CharterCarriers/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim charterCarrier As CharterCarrier = db.carriers.Find(id)
            If IsNothing(charterCarrier) Then
                Return HttpNotFound()
            End If
            Return View(charterCarrier)
        End Function

        ' POST: CharterCarriers/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim charterCarrier As CharterCarrier = db.carriers.Find(id)
            db.carriers.Remove(charterCarrier)
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
