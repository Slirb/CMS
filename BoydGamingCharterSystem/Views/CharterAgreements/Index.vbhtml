@ModelType IEnumerable(Of BoydGamingCharterSystem.CharterAgreement)
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
            @Html.DisplayNameFor(Function(model) model.Name)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.CharterCarrier)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.CharterOperator)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.CreatedDateTime)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Name)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.CarrierName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.OperatorName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.CreatedDateTime)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.Id }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.Id }) 
        </td>
    </tr>
Next

</table>
