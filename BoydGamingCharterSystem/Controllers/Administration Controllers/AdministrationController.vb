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
    Public Class AdministrationController
        Inherits System.Web.Mvc.Controller


        Private db As New CharterSystem


        ' GET: Administration
        Function Index() As ActionResult
            Dim interests = db.operatorInterests.ToList()
            Dim modes = db.operatorModes.ToList()
            Dim codes = db.operatorStopCodes.ToList()
            Dim types = db.operatorTypes.ToList()
            Dim properties = db.properties.ToList()
            Dim tieredCommissions = db.commissions.ToList()

            Dim viewMod As New AdministrationModel
            viewMod.operatorInterest = interests
            viewMod.operatorMode = modes
            viewMod.operatorStopCode = codes
            viewMod.operatorType = types
            viewMod.properties = properties
            viewMod.tieredCommissions = tieredCommissions

            Return View(viewMod)
        End Function

        ' GET: Administration/Details/5
        Function Details(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' GET: Administration/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Administration/Create
        <HttpPost()>
        Function Create(ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add insert logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Administration/Edit/5
        Function Edit(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' POST: Administration/Edit/5
        <HttpPost()>
        Function Edit(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add update logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Administration/Delete/5
        Function Delete(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' POST: Administration/Delete/5
        <HttpPost()>
        Function Delete(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add delete logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function


        'Enable Operator Interest to be edited
        Function EditInterest(ByVal id As Integer) As ActionResult
            Return RedirectToAction("Edit", "CharterOperatorInterests", New With {.id = id})
        End Function

        'Enable creation of an Operator Interest
        Function CreateInterest() As ActionResult
            Return RedirectToAction("Create", "CharterOperatorInterests")
        End Function


        'Enable Operator Mode to be edited
        Function EditMode(ByVal id As Integer) As ActionResult
            Return RedirectToAction("Edit", "CharterOperatorModes", New With {.id = id})
        End Function


        'Enable creation of an Operator Mode
        Function CreateMode() As ActionResult
            Return RedirectToAction("Create", "CharterOperatorModes")
        End Function


        'Enable Operator Stop Code to be edited
        Function EditStopCode(ByVal id As Integer) As ActionResult
            Return RedirectToAction("Edit", "CharterOperatorStopCodes", New With {.id = id})
        End Function


        'Enable creation of an Operator Stop Code
        Function CreateStopCode() As ActionResult
            Return RedirectToAction("Create", "CharterOperatorStopCodes")
        End Function


        'Enable Operator Type to be edited
        Function EditType(ByVal id As Integer) As ActionResult
            Return RedirectToAction("Edit", "CharterOperatorTypes", New With {.id = id})
        End Function


        'Enable creation of an Operator Type
        Function CreateType() As ActionResult
            Return RedirectToAction("Create", "CharterOperatorTypes")
        End Function


        'Enable Property to be edited
        Function EditProperty(ByVal id As Integer) As ActionResult
            Return RedirectToAction("Edit", "CharterProperties", New With {.id = id})
        End Function


        'Enable creation of a Property
        Function CreateProperty() As ActionResult
            Return RedirectToAction("Create", "CharterProperties")
        End Function

        'Enable Tiered Commissions to be edited
        Function EditCommission(ByVal id As Integer) As ActionResult
            Return RedirectToAction("Edit", "CharterTieredCommissions", New With {.id = id})
        End Function


        'Enable creation of a TieredCommission
        Function CreateCommission() As ActionResult
            Return RedirectToAction("Create", "CharterTieredCommissions")
        End Function

    End Class
End Namespace