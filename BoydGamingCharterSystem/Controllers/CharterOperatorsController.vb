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
        Inherits Controller

        Private db As New CharterSystem
        ' GET: CharterOperators
        Function Index() As ActionResult
            Dim operators As List(Of CharterOperator)
            operators = (From charterOperator In db.operators.Include(Function(o) o.Commentable).Include(Function(o) o.Company).Include(Function(o) o.Company.Contactable)
                         Select charterOperator).ToList()

            Return View(operators)
        End Function
    End Class
End Namespace