@ModelType IEnumerable(Of BoydGamingCharterSystem.CharterAgreement)
@Code
    ViewData("Title") = "Agreements"
End Code

<h1>@ViewBag.Title</h1>

<p>
    <a href="@Url.Action("Create", "CharterAgreements")" class="btn btn-success btn-sm"><span class="glyphicon glyphicon-plus"></span> Create New Agreement</a>
</p>
<table class="table table-striped table-hover table-condensed">
    <tr>
        <th>
            Agreement Name
        </th>
        <th>
            Carrier
        </th>
        <th>
          Operator
        </th>
        <th>
            Date Created
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
            <a href="@Url.Action("Edit", "CharterAgreements", New With {.id = item.Id})" class="btn btn-default btn-xs"><span class="glyphicon glyphicon-edit"></span> Edit</a>
            <a href="@Url.Action("Details", "CharterAgreements", New With {.id = item.Id})" class="btn btn-default btn-xs"><span class="glyphicon glyphicon-edit"></span> Details</a>
        </td>
    </tr>
Next

</table>
