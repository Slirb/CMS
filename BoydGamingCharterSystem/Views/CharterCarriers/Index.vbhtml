@ModelType IEnumerable(Of BoydGamingCharterSystem.CharterCarrier)

@Code
    ViewData("Title") = "Carriers"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Index</title>
</head>

<body>

    <h1>@ViewBag.Title</h1>

    <p>
        @Html.ActionLink("Create New Carrier", "Create")
    </p>
    <table class="table">
        <tr>
            <th>
                @Html.DisplayNameFor(Function(model) model.Company.Name)
            </th>
            <th>
                Contact Name
            </th>
            <th>
                Contact Phone
            </th>
            <th>
                City
            </th>
            <th>
                Has Ins
            </th>
            <th>
                Ins No
            </th>
            <th>
                License
            </th>
            <th>
                License No
            </th>
            <th>
                Action
            </th>
        </tr>
    
    @For i As Int32 = 0 To Model.Count - 1
        'Using for loop instead of foreach in order to have a access to iteration counter
        Dim item = Model(i)
        'Prevent an exception when a carrier has no contacts
        If Not (item.Contacts.Count > 0) Then
            item.Contacts.Add(New CharterContact())
        End If

        @<tr>
        <!--There is probably a better way to access our data, but I don't know what it is-->
            <td>
                @Html.DisplayFor(Function(modelItem) item.Company.Name)
            </td>
            <td>
                @item.Contacts.Item(0).FirstName @item.Contacts.Item(0).LastName
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Contacts.Item(0).PrimaryPhone)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Company.City)
            </td>
            <td>
                @Html.CheckBox("Carrier" & i & "HasInsurance", item.HasInsurance, New With {.disabled = True})
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.InsuranceNumber)
            </td>
            <td>
                @Html.CheckBox("Carrier" & i & "HasInsurance", item.HasLicense, New With {.disabled = True})
            </td>
             <td>
                 @Html.DisplayFor(Function(modelItem) item.LicenseNumber)
             </td>
            <td>
                @Html.ActionLink("Edit", "Edit", New With {.id = item.Id}) |
                @Html.ActionLink("Details", "Details", New With {.id = item.Id}) |
                @Html.ActionLink("Delete", "Delete", New With {.id = item.Id})
            </td>
        </tr>
    Next
    
    </table>
</body>
</html>
