Imports System.Web.Mvc

Namespace Controllers
    Public Class CharterContactsController
        Inherits Controller

        ' GET: CharterContact
        Function Index() As ActionResult
            Return View()
        End Function

        <HttpPost()>
        Public Function BlankContactRow() As ViewResult
            Dim row As CharterContact = New CharterContact()
            Return View("CharterContacts/CharterContactRow", row)
        End Function


    End Class
End Namespace