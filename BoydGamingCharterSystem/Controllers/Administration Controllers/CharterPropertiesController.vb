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
    Public Class CharterPropertiesController
        Inherits System.Web.Mvc.Controller

        Private db As New CharterSystem

        ' GET: CharterProperties
        Function Index() As ActionResult
            Return RedirectToAction("Index", "Administration")
        End Function

        ' GET: CharterProperties/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim charterProperties As CharterProperties = db.properties.Find(id)
            If IsNothing(charterProperties) Then
                Return HttpNotFound()
            End If
            Return View(charterProperties)
        End Function

        ' GET: CharterProperties/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: CharterProperties/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,DepartmentName,ContactNumber,FaxNumber,Name,ShortName,Code")> ByVal charterProperties As CharterProperties) As ActionResult
            charterProperties.CreatedDate = Date.Now
            charterProperties.UpdatedDate = Nothing
            If ModelState.IsValid Then
                db.properties.Add(charterProperties)
                db.SaveChanges()
                Return RedirectToAction("Index", "Administration")
            End If
            Return View(charterProperties)
        End Function

        ' GET: CharterProperties/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim charterProperties As CharterProperties = db.properties.Find(id)
            If IsNothing(charterProperties) Then
                Return HttpNotFound()
            End If
            Return View(charterProperties)
        End Function

        ' POST: CharterProperties/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,DepartmentName,ContactNumber,FaxNumber,Name,ShortName,Code,UpdatedBy,UpdatedDate,CreatedDate,CreatedBy")> ByVal charterProperties As CharterProperties) As ActionResult
            If ModelState.IsValid Then
                db.Entry(charterProperties).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index", "Administration")
            End If
            Return View(charterProperties)
        End Function

        ' GET: CharterProperties/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim charterProperties As CharterProperties = db.properties.Find(id)
            If IsNothing(charterProperties) Then
                Return HttpNotFound()
            End If
            Return View(charterProperties)
        End Function

        ' POST: CharterProperties/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim charterProperties As CharterProperties = db.properties.Find(id)
            db.properties.Remove(charterProperties)
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
