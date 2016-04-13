Imports System.Web.Mvc

Namespace Controllers
    Public Class CharterContactsController
        Inherits Controller

        Private db As New CharterSystem

        ' GET: CharterContact
        Function Index() As ActionResult
            Return View()
        End Function

        <HttpPost()>
        Public Function BlankContactRow() As ViewResult
            Dim row As CharterContact = New CharterContact()

            Return View("CharterContacts/CharterContactRow", row)
        End Function

        <HttpPost()>
        Public Sub DeleteContact(ByVal id As Integer)
            If Not (IsNothing(id)) Then
                Dim contact As CharterContact = db.contacts.Find(id)
                If Not (IsNothing(contact)) Then
                    db.contacts.Remove(contact)
                    db.SaveChanges()
                End If
            End If

        End Sub
    End Class
End Namespace