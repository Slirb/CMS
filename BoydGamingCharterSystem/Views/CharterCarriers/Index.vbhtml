@ModelType IEnumerable(Of BoydGamingCharterSystem.CharterCarrier)

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
            <th></th>
        </tr>
    
    @For Each item In Model
        @<tr>
            <td>
                @Html.ActionLink("Edit", "Edit", New With {.id = item.Id }) |
                @Html.ActionLink("Details", "Details", New With {.id = item.Id }) |
                @Html.ActionLink("Delete", "Delete", New With {.id = item.Id })
            </td>
        </tr>
    Next
    
    </table>
</body>
</html>
