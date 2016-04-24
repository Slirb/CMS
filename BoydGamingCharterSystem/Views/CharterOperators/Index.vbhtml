@ModelType IEnumerable(Of BoydGamingCharterSystem.CharterOperator)
@Code
ViewData("Title") = "Index"
Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Company.Name)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.VendorNumber)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Contacts.FirstOrDefault().FullName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Contacts.FirstOrDefault().Phone)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Company.City)
        </th>
        <th>
            Action
        </th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Company.Name)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.VendorNumber)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Contacts.FirstOrDefault().FullName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Contacts.FirstOrDefault().Phone)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Company.City)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.Id }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.Id }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.Id })
        </td>
    </tr>
Next

</table>
