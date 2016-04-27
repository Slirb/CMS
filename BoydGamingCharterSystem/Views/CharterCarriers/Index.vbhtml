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
        <a href="@Url.Action("Create", "CharterCarriers")" class="btn btn-success btn-sm"><span class="glyphicon glyphicon-plus"></span> Create New Carrier</a>
    </p>
    <table class="table table-striped table-hover table-condensed">
        <tr>
            <th style="text-align:center">
                @Html.DisplayNameFor(Function(model) model.Company.Name)
            </th>
            <th style="text-align:center">
                Contact Name
            </th>
            <th style="text-align:center">
                Contact Phone
            </th>
            <th style="text-align:center">
                City
            </th>
            <th style="text-align:center">
                Has Ins
            </th>
            <th style="text-align:center">
                Ins No
            </th>
            <th style="text-align:center">
                License
            </th>
            <th style="text-align:center">
                License No
            </th>
            <th style="text-align:center">
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
            <td style="text-align:center">
                @item.Contacts.Item(0).FirstName @item.Contacts.Item(0).LastName
            </td>
            <td style="text-align:center">
                @Html.DisplayFor(Function(modelItem) item.Contacts.Item(0).PrimaryPhone)
            </td>
            <td style="text-align:center">
                @Html.DisplayFor(Function(modelItem) item.Company.City)
            </td>
            <td  style="text-align:center">
                @Html.CheckBox("Carrier" & i & "HasInsurance", item.HasInsurance, New With {.disabled = True})
            </td>
            <td style="text-align:center">
                @Html.DisplayFor(Function(modelItem) item.InsuranceNumber)
            </td>
            <td style="text-align:center">
                @Html.CheckBox("Carrier" & i & "HasInsurance", item.HasLicense, New With {.disabled = True})
            </td>
             <td style="text-align:center">
                 @Html.DisplayFor(Function(modelItem) item.LicenseNumber)
             </td>
            <td  style="text-align:center">
                <a href="@Url.Action("Edit", "CharterCarriers", New With {.id = item.Id})" class="btn btn-default btn-xs"><span class="glyphicon glyphicon-edit"></span> Edit</a>
                <a href="@Url.Action("Details", "CharterCarriers", New With {.id = item.Id})" class="btn btn-default btn-xs"><span class="glyphicon glyphicon-th-list"></span> Details</a>
                <!--<a href="@Url.Action("Delete", "CharterCarriers", New With {.id = item.Id})" class="btn btn-default btn-xs"><span class="glyphicon glyphicon-minus"></span> Delete</a>-->
            </td>
        </tr>
    Next
    
    </table>
</body>
</html>
