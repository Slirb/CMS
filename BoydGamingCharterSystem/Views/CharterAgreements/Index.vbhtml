@ModelType IEnumerable(Of BoydGamingCharterSystem.CharterAgreement)
@Code
    ViewData("Title") = "Agreements"
End Code

<h1>@ViewBag.Title</h1>

<p>
    <a href="@Url.Action("Create", "CharterAgreements")" class="btn btn-success btn-md"><span class="glyphicon glyphicon-plus"></span> Create New Agreement</a>
</p>
<table class="table table-striped table-hover table-condensed">
    <tr>
        <th style="text-align:center">
            Agreement Name
        </th>
        <th style="text-align:center">
            Carrier
        </th>
        <th style="text-align:center">
          Operator
        </th>
        <th style="text-align:center">
            Date Created
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td style="text-align:center">
            @Html.DisplayFor(Function(modelItem) item.Name)
        </td>
        <td style="text-align:center">
            @Html.DisplayFor(Function(modelItem) item.CarrierName)
        </td>
        <td style="text-align:center">
            @Html.DisplayFor(Function(modelItem) item.OperatorName)
        </td>
        <td style="text-align:center">
            @Html.DisplayFor(Function(modelItem) item.CreatedDateTime)
        </td>
        <td style="text-align:center">
             <a href="@Url.Action("Edit", "CharterAgreements", New With {.id = item.Id})" class="btn btn-default btn-xs"><span class="glyphicon glyphicon-edit"></span> Edit</a>
            <a href="@Url.Action("Details", "CharterAgreements", New With {.id = item.Id})" class="btn btn-default btn-xs"><span class="glyphicon glyphicon-th-list"></span> Details</a>
        </td>
    </tr>
Next

</table>
