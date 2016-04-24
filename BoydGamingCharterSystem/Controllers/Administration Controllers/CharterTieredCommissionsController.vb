Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports BoydGamingCharterSystem

Namespace Controllers.Administration
    Public Class CharterTieredCommissionsController
        Inherits System.Web.Mvc.Controller

        Private db As New CharterSystem

        ' GET: CharterTieredCommissions
        Function Index() As ActionResult
            Return RedirectToAction("Index", "Administration")
        End Function

        ' GET: CharterTieredCommissions/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim charterTieredCommissions As CharterTieredCommissions = db.commissions.Find(id)
            If IsNothing(charterTieredCommissions) Then
                Return HttpNotFound()
            End If
            Return View(charterTieredCommissions)
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
        Function Create(<Bind(Include:="Id,comID,Name,Description,Minimum,Maximum,Value")> ByVal charterTieredCommissions As CharterTieredCommissions) As ActionResult
            If ModelState.IsValid Then
                db.commissions.Add(charterTieredCommissions)
                db.SaveChanges()
                Return RedirectToAction("Index", "Administration")
            End If
            Return View(charterTieredCommissions)
        End Function

        ' GET: CharterTieredCommissions/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim charterTieredCommissions As CharterTieredCommissions = db.commissions.Find(id)
            If IsNothing(charterTieredCommissions) Then
                Return HttpNotFound()
            End If

            'Manifest for the trip
            Dim values As List(Of TieredCommissionValues) = (From x In db.commissionValues
                                                             Order By x.commissionMax
                                                             Select x Where x.CommissionID = id Order By x.commissionMin).ToList()

            'Create view model to hold data
            Dim viewMod As New EditTieredCommissionsModel
            viewMod.TieredCommission = charterTieredCommissions
            viewMod.Values = values

            Return View(viewMod)

        End Function

        ' POST: CharterTieredCommissions/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,Name,Description", Prefix:="TieredCommission")> ByVal charterTieredCommissions As CharterTieredCommissions) As ActionResult
            If ModelState.IsValid Then
                db.Entry(charterTieredCommissions).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index", "Administration")
            End If
            Return View(charterTieredCommissions)
        End Function


        'Adds a new range to a tiered commission
        <HttpPost()>
        Function AddValue(ByVal comId As Integer, ByVal minRange As String, maxRange As String, commission As String) As ActionResult

            If minRange = "" Or maxRange = "" Or commission = "" Then
                Return RedirectToAction("Edit", New With {.id = comId})
            End If

            Dim tempValue = From t In db.commissionValues.Where(Function(value) value.CommissionID.Equals(comId)).ToList
                            Select t Where t.commissionMax = Double.Parse(maxRange) And t.commissionMin = Double.Parse(minRange) And t.commissionValuePerCustomer = Double.Parse(commission)

            If tempValue.Count < 1 Then

                Dim value As TieredCommissionValues =
                            New TieredCommissionValues(-1, comId, Double.Parse(minRange), Double.Parse(maxRange), Double.Parse(commission))

                db.commissionValues.Add(value)
                db.SaveChanges()
            End If

            Return RedirectToAction("Edit", New With {.id = comId})

        End Function



        ' Delete a value from a tiered commission
        Function DeleteValue(ByVal id As Integer?, ByVal comId As Integer?) As ActionResult

            Dim tieredCommission As CharterTieredCommissions = db.commissions.Find(comId)
            Dim commissionValues As TieredCommissionValues = db.commissionValues.Find(id)
            db.commissionValues.Remove(commissionValues)
            db.SaveChanges()


            Return RedirectToAction("Edit", New With {.id = tieredCommission.Id})
        End Function


        ' GET: CharterTieredCommissions/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim charterTieredCommissions As CharterTieredCommissions = db.commissions.Find(id)
            If IsNothing(charterTieredCommissions) Then
                Return HttpNotFound()
            End If
            Return View(charterTieredCommissions)
        End Function

        ' POST: CharterTieredCommissions/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim charterTieredCommissions As CharterTieredCommissions = db.commissions.Find(id)
            db.commissions.Remove(charterTieredCommissions)
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
