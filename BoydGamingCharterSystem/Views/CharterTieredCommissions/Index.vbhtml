@ModelType IEnumerable(Of BoydGamingCharterSystem.CharterTieredCommissions)

@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Index</title>
</head>
<body>
    <p>
        @Html.ActionLink("Create New", "Create")
    </p>
    <table class="table">
        <tr>
            <th>
                @Html.DisplayNameFor(Function(model) model.Name)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Description)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Minimum)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Maximum)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Value)
            </th>
            <th></th>
        </tr>
    
    @For Each item In Model
        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Name)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Description)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Minimum)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Maximum)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Value)
            </td>
            <td>
                @Html.ActionLink("Edit", "Edit", New With {.id = item.keyID}) |
                @Html.ActionLink("Details", "Details", New With {.id = item.keyID}) |
                @Html.ActionLink("Delete", "Delete", New With {.id = item.keyID})
            </td>
        </tr>
    Next
    
    </table>
</body>
</html>
