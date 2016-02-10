Imports System.Web.Mvc

Namespace Controllers
    Public Class AdministrationController
        Inherits Controller

        ' GET: Administration
        Function Index() As ActionResult
            Return View()
        End Function
    End Class
End Namespace