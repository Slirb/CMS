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
    Public Class CharterOperatorsController
        Inherits System.Web.Mvc.Controller

        Private db As New CharterSystem

        ' GET: CharterOperators
        Function Index() As ActionResult
            Return View(db.operators.ToList())
        End Function

        ' GET: CharterOperators/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim charterOperator As CharterOperator = db.operators.Find(id)
            If IsNothing(charterOperator) Then
                Return HttpNotFound()
            End If
            Return View(charterOperator)
        End Function

        ' GET: CharterOperators/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: CharterOperators/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,VendorNumber,Type,Mode,Interest,StopCode")> ByVal charterOperator As CharterOperator) As ActionResult
            If ModelState.IsValid Then
                db.operators.Add(charterOperator)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(charterOperator)
        End Function

        ' GET: CharterOperators/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim charterOperator As CharterOperator = db.operators.Find(id)
            If IsNothing(charterOperator) Then
                Return HttpNotFound()
            End If
            Return View(charterOperator)
        End Function

        ' POST: CharterOperators/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,VendorNumber,Type,Mode,Interest,StopCode")> ByVal charterOperator As CharterOperator) As ActionResult
            If ModelState.IsValid Then
                db.Entry(charterOperator).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(charterOperator)
        End Function

        ' GET: CharterOperators/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim charterOperator As CharterOperator = db.operators.Find(id)
            If IsNothing(charterOperator) Then
                Return HttpNotFound()
            End If
            Return View(charterOperator)
        End Function

        ' POST: CharterOperators/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim charterOperator As CharterOperator = db.operators.Find(id)
            db.operators.Remove(charterOperator)
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
