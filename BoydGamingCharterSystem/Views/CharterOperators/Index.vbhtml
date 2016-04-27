@ModelType IEnumerable(Of BoydGamingCharterSystem.CharterOperator)
@Code
    ViewData("Title") = "Operators"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h1>@ViewBag.Title</h1>

<p>
    <a href="@Url.Action("Create", "CharterOperators", New CharterCarrier())" class="btn btn-success btn-sm"><span class="glyphicon glyphicon-plus"></span> Create New Operator</a>
</p>
<table class="table table-striped table-hover table-condensed">
    <tr>
        <th style="text-align:center">
            @Html.DisplayNameFor(Function(model) model.Company.Name)
        </th>
        <th style="text-align:center">
            @Html.DisplayNameFor(Function(model) model.VendorNumber)
        </th>
        <th style="text-align:center">
            @Html.DisplayNameFor(Function(model) model.Contacts.FirstOrDefault().FullName)
        </th>
        <th style="text-align:center">
            @Html.DisplayNameFor(Function(model) model.Contacts.FirstOrDefault().Phone)
        </th>
        <th style="text-align:center">
            @Html.DisplayNameFor(Function(model) model.Company.City)
        </th>
        <th style="text-align:center">
            Action
        </th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Company.Name)
        </td>
        <td style="text-align:center">
            @Html.DisplayFor(Function(modelItem) item.VendorNumber)
        </td>
        <td style="text-align:center">
            @Html.DisplayFor(Function(modelItem) item.Contacts.FirstOrDefault().FullName)
        </td>
        <td style="text-align:center">
            @Html.DisplayFor(Function(modelItem) item.Contacts.FirstOrDefault().Phone)
        </td>
        <td style="text-align:center">
            @Html.DisplayFor(Function(modelItem) item.Company.City)
        </td>
         <td style="text-align:center">
             <a href="@Url.Action("Edit", "CharterOperators", New With {.id = item.Id})" class="btn btn-default btn-xs"><span class="glyphicon glyphicon-edit"></span> Edit</a>
             <a href="@Url.Action("Details", "CharterOperators", New With {.id = item.Id})" class="btn btn-default btn-xs"><span class="glyphicon glyphicon-th-list"></span> Details</a>
             <!--<a href="@Url.Action("Delete", "CharterOperators", New With {.id = item.Id})" class="btn btn-default btn-xs"><span class="glyphicon glyphicon-minus"></span> Delete</a>-->
        </td>
    </tr>
Next

</table>
