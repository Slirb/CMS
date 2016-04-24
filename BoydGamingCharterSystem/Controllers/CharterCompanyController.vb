Imports System.Web.Mvc

Namespace Controllers
    Public Class CharterCompanyController
        Inherits Controller

        ' GET: CharterCompany
        Function Index() As ActionResult
            Return View()
        End Function

        <HttpPost()>
        Public Function BlankContactRow(<Bind(Include:="Id, Contacts")> ByVal charterCompany As CharterCompany, <Bind(Include:="Id")> ByVal contacts As IEnumerable(Of CharterContact))

            charterCompany.Contacts.Add(contacts)
            Return View("CharterCompanyCreate", charterCompany)
        End Function


    End Class

End Namespace