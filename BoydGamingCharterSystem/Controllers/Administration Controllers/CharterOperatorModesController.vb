Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports CharterSystem

Namespace Controllers
    Public Class CharterOperatorModesController
        Inherits System.Web.Mvc.Controller

        Private db As New CharterSystem

        ' GET: CharterOperatorModes
        Function Index() As ActionResult
            Return RedirectToAction("Index", "Administration")
        End Function

        ' GET: CharterOperatorModes/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim charterOperatorMode As CharterOperatorMode = db.operatorModes.Find(id)
            If IsNothing(charterOperatorMode) Then
                Return HttpNotFound()
            End If
            Return View(charterOperatorMode)
        End Function

        ' GET: CharterOperatorModes/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: CharterOperatorModes/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,Mode")> ByVal charterOperatorMode As CharterOperatorMode) As ActionResult
            If ModelState.IsValid Then
                db.operatorModes.Add(charterOperatorMode)
                db.SaveChanges()
                Return RedirectToAction("Index", "Administration")
            End If
            Return View(charterOperatorMode)
        End Function

        ' GET: CharterOperatorModes/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim charterOperatorMode As CharterOperatorMode = db.operatorModes.Find(id)
            If IsNothing(charterOperatorMode) Then
                Return HttpNotFound()
            End If
            Return View(charterOperatorMode)
        End Function

        ' POST: CharterOperatorModes/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,Mode")> ByVal charterOperatorMode As CharterOperatorMode) As ActionResult
            If ModelState.IsValid Then
                db.Entry(charterOperatorMode).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index", "Administration")
            End If
            Return View(charterOperatorMode)
        End Function

        ' GET: CharterOperatorModes/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim charterOperatorMode As CharterOperatorMode = db.operatorModes.Find(id)
            If IsNothing(charterOperatorMode) Then
                Return HttpNotFound()
            End If
            Return View(charterOperatorMode)
        End Function

        ' POST: CharterOperatorModes/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim charterOperatorMode As CharterOperatorMode = db.operatorModes.Find(id)
            db.operatorModes.Remove(charterOperatorMode)
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
