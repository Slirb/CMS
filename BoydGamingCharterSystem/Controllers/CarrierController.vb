Imports System.Web.Mvc
Imports BoydGamingCharterSystem.Carrier


Namespace Controllers
    Public Class CarrierController
        Inherits Controller

        ' GET: Carrier
        Function Index() As ActionResult
            Return View()
        End Function

        <HttpPost>
        Function formAction() As ActionResult
            Dim inputId As String = Request.Form("CarrierId")


            Dim newCarrier As Carrier = New Carrier(inputId)

            ViewData("carrier") = newCarrier

            Return View("submittedForm")

        End Function

    End Class
End Namespace