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
    Public Class CharterOperatorTypesController
        Inherits System.Web.Mvc.Controller

        Private db As New CharterSystem

        ' GET: CharterOperatorTypes
        Function Index() As ActionResult
            Return RedirectToAction("Index", "Administration")
        End Function

        ' GET: CharterOperatorTypes/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim charterOperatorType As CharterOperatorType = db.operatorTypes.Find(id)
            If IsNothing(charterOperatorType) Then
                Return HttpNotFound()
            End If
            Return View(charterOperatorType)
        End Function

        ' GET: CharterOperatorTypes/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: CharterOperatorTypes/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,Type")> ByVal charterOperatorType As CharterOperatorType) As ActionResult
            If ModelState.IsValid Then
                db.operatorTypes.Add(charterOperatorType)
                db.SaveChanges()
                Return RedirectToAction("Index", "Administration")
            End If
            Return View(charterOperatorType)
        End Function

        ' GET: CharterOperatorTypes/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim charterOperatorType As CharterOperatorType = db.operatorTypes.Find(id)
            If IsNothing(charterOperatorType) Then
                Return HttpNotFound()
            End If
            Return View(charterOperatorType)
        End Function

        ' POST: CharterOperatorTypes/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,Type")> ByVal charterOperatorType As CharterOperatorType) As ActionResult
            If ModelState.IsValid Then
                db.Entry(charterOperatorType).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index", "Administration")
            End If
            Return View(charterOperatorType)
        End Function

        ' GET: CharterOperatorTypes/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim charterOperatorType As CharterOperatorType = db.operatorTypes.Find(id)
            If IsNothing(charterOperatorType) Then
                Return HttpNotFound()
            End If
            Return View(charterOperatorType)
        End Function

        ' POST: CharterOperatorTypes/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim charterOperatorType As CharterOperatorType = db.operatorTypes.Find(id)
            db.operatorTypes.Remove(charterOperatorType)
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
