Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports System.Runtime.CompilerServices

Public Module HtmlHelpers
    <Extension()>
    Public Function RemoveLink(ByVal htmlHelper As Mvc.HtmlHelper, linkText As String, container As String, deleteElement As String) As IHtmlString

        Dim js As String = String.Format("removeNestedForm(this, '{0}', '{1}'); return false;", container, deleteElement)
        Dim tb As TagBuilder = New TagBuilder("a")
        tb.Attributes.Add("href", "#")
        tb.Attributes.Add("onclick", js)
        tb.InnerHtml = linkText
        Dim tag As String = tb.ToString(TagRenderMode.Normal)
        Return MvcHtmlString.Create(tag)

    End Function
End Module
