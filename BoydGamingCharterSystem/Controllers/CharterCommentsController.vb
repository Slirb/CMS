Imports System.Web.Mvc

Namespace Controllers
    Public Class CharterCommentsController
        Inherits Controller

        ' GET: CharterComments
        Function Index() As ActionResult
            Return View()
        End Function



        <HttpPost()>
        Public Function BlankCommentRow() As ViewResult
            Dim row As CharterComment = New CharterComment()
            Return View("CharterComments/CharterCommentRow", row)
        End Function
    End Class

End Namespace