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
            Return View(db.agreements.ToList())
        End Function

        Function Search() As ActionResult
            Return View(db.carriers.ToList(), db.operators.ToList())
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
            Return View()
        End Function

        ' POST: CharterAgreements/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,CreateDate")> ByVal charterAgreement As CharterAgreement) As ActionResult
            If ModelState.IsValid Then
                db.agreements.Add(charterAgreement)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(charterAgreement)
        End Function

        ' GET: CharterAgreements/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim charterAgreement As CharterAgreement = db.agreements.Find(id)
            If IsNothing(charterAgreement) Then
                Return HttpNotFound()
            End If
            Return View(charterAgreement)
        End Function

        ' POST: CharterAgreements/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,CreateDate")> ByVal charterAgreement As CharterAgreement) As ActionResult
            If ModelState.IsValid Then
                db.Entry(charterAgreement).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(charterAgreement)
        End Function

        ' GET: CharterAgreements/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim charterAgreement As CharterAgreement = db.agreements.Find(id)
            If IsNothing(charterAgreement) Then
                Return HttpNotFound()
            End If
            Return View(charterAgreement)
        End Function

        ' POST: CharterAgreements/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim charterAgreement As CharterAgreement = db.agreements.Find(id)
            db.agreements.Remove(charterAgreement)
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
