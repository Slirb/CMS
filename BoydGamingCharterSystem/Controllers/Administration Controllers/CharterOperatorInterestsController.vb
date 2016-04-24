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
    Public Class CharterOperatorInterestsController
        Inherits System.Web.Mvc.Controller

        Private db As New CharterSystem

        ' GET: CharterOperatorInterests
        Function Index() As ActionResult
            Return RedirectToAction("Index", "Administration")
        End Function

        ' GET: CharterOperatorInterests/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim charterOperatorInterest As CharterOperatorInterest = db.operatorInterests.Find(id)
            If IsNothing(charterOperatorInterest) Then
                Return HttpNotFound()
            End If
            Return View(charterOperatorInterest)
        End Function

        ' GET: CharterOperatorInterests/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: CharterOperatorInterests/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,Interest")> ByVal charterOperatorInterest As CharterOperatorInterest) As ActionResult
            If ModelState.IsValid Then
                db.operatorInterests.Add(charterOperatorInterest)
                db.SaveChanges()
                Return RedirectToAction("Index", "Administration")
            End If
            Return View(charterOperatorInterest)
        End Function

        ' GET: CharterOperatorInterests/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim charterOperatorInterest As CharterOperatorInterest = db.operatorInterests.Find(id)
            If IsNothing(charterOperatorInterest) Then
                Return HttpNotFound()
            End If
            Return View(charterOperatorInterest)
        End Function

        ' POST: CharterOperatorInterests/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,Interest")> ByVal charterOperatorInterest As CharterOperatorInterest) As ActionResult
            If ModelState.IsValid Then
                db.Entry(charterOperatorInterest).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index", "Administration")
            End If
            Return View(charterOperatorInterest)
        End Function

        ' GET: CharterOperatorInterests/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim charterOperatorInterest As CharterOperatorInterest = db.operatorInterests.Find(id)
            If IsNothing(charterOperatorInterest) Then
                Return HttpNotFound()
            End If
            Return View(charterOperatorInterest)
        End Function

        ' POST: CharterOperatorInterests/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim charterOperatorInterest As CharterOperatorInterest = db.operatorInterests.Find(id)
            db.operatorInterests.Remove(charterOperatorInterest)
            db.SaveChanges()
            Return RedirectToAction("Index", "Administration")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
