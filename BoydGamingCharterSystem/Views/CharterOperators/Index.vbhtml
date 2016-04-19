@ModelType IEnumerable(Of BoydGamingCharterSystem.CharterOperator)
@Code
ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.VendorNumber)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Type)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Mode)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Interest)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.StopCode)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.VendorNumber)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Type)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Mode)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Interest)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.StopCode)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.Id }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.Id }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.Id })
        </td>
    </tr>
Next

</table>
