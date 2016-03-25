﻿Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports BoydGamingCharterSystem


Namespace Controllers
    Public Class CharterTieredCommissionsController
        Inherits System.Web.Mvc.Controller

        Private db As New CharterSystem

        ' GET: CharterTieredCommissions
        Function Index() As ActionResult
            Return View(db.commissions.ToList())
        End Function

        ' GET: CharterTieredCommissions/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim charterCommission As CharterTieredCommissions = db.commissions.Find(id)
            If IsNothing(charterCommission) Then
                Return HttpNotFound()
            End If
            Return View(charterCommission)
        End Function

        ' GET: CharterTieredCommissions/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: CharterTieredCommissions/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,Name")> ByVal charterCommission As CharterTieredCommissions) As ActionResult
            If ModelState.IsValid Then
                db.commissions.Add(charterCommission)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(charterCommission)
        End Function

        ' GET: CharterTieredommissions/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim charterCommission As CharterTieredCommissions = db.commissions.Find(id)
            If IsNothing(charterCommission) Then
                Return HttpNotFound()
            End If
            Return View(charterCommission)
        End Function

        ' POST: CharterTieredCommissions/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,Name")> ByVal charterCommission As CharterTieredCommissions) As ActionResult
            If ModelState.IsValid Then
                db.Entry(charterCommission).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(charterCommission)
        End Function

        ' GET: CharterTieredCommissions/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim charterCommission As CharterTieredCommissions = db.commissions.Find(id)
            If IsNothing(charterCommission) Then
                Return HttpNotFound()
            End If
            Return View(charterCommission)
        End Function

        ' POST: CharterTieredCommissions/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim charterCommission As CharterTieredCommissions = db.commissions.Find(id)
            db.commissions.Remove(charterCommission)
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
