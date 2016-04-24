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
    Public Class CharterOperatorStopCodesController
        Inherits System.Web.Mvc.Controller

        Private db As New CharterSystem

        ' GET: CharterOperatorStopCodes
        Function Index() As ActionResult
            Return RedirectToAction("Index", "Administration")
        End Function

        ' GET: CharterOperatorStopCodes/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim charterOperatorStopCode As CharterOperatorStopCode = db.operatorStopCodes.Find(id)
            If IsNothing(charterOperatorStopCode) Then
                Return HttpNotFound()
            End If
            Return View(charterOperatorStopCode)
        End Function

        ' GET: CharterOperatorStopCodes/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: CharterOperatorStopCodes/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,StopCode")> ByVal charterOperatorStopCode As CharterOperatorStopCode) As ActionResult
            If ModelState.IsValid Then
                db.operatorStopCodes.Add(charterOperatorStopCode)
                db.SaveChanges()
                Return RedirectToAction("Index", "Administration")
            End If
            Return View(charterOperatorStopCode)
        End Function

        ' GET: CharterOperatorStopCodes/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim charterOperatorStopCode As CharterOperatorStopCode = db.operatorStopCodes.Find(id)
            If IsNothing(charterOperatorStopCode) Then
                Return HttpNotFound()
            End If
            Return View(charterOperatorStopCode)
        End Function

        ' POST: CharterOperatorStopCodes/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,StopCode")> ByVal charterOperatorStopCode As CharterOperatorStopCode) As ActionResult
            If ModelState.IsValid Then
                db.Entry(charterOperatorStopCode).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index", "Administration")
            End If
            Return View(charterOperatorStopCode)
        End Function

        ' GET: CharterOperatorStopCodes/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim charterOperatorStopCode As CharterOperatorStopCode = db.operatorStopCodes.Find(id)
            If IsNothing(charterOperatorStopCode) Then
                Return HttpNotFound()
            End If
            Return View(charterOperatorStopCode)
        End Function

        ' POST: CharterOperatorStopCodes/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim charterOperatorStopCode As CharterOperatorStopCode = db.operatorStopCodes.Find(id)
            db.operatorStopCodes.Remove(charterOperatorStopCode)
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
