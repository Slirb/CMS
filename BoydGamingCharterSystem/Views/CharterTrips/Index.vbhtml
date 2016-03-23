@ModelType IEnumerable(Of BoydGamingCharterSystem.CharterTrips)

@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout.vbhtml"

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


@Using Html.BeginForm("Index", "CharterTrips", FormMethod.Get)

    @<p>
    @Html.Label("searchLabel", "Confirmation Number: ")
    @Html.TextBox("SearchString")
    </p>

    @<p>
         <dl>
             <dd>
                 @Html.Label("potentialLabel", "Potential: ")
                 @Html.CheckBox("Potential", True)
             </dd>
             <dd>
                 @Html.Label("activeLabel", "Active: ")
                 @Html.CheckBox("Active", True)
             </dd>
             <dd>
                 @Html.Label("appliedLabel", "Applied: ")
                 @Html.CheckBox("Applied", True)
             </dd>
             <dd>
                 @Html.Label("completedLabel", "Completed: ")
                 @Html.CheckBox("Completed", True)
             </dd>
             <dd>
                 @Html.Label("cancelledLabel", "Canceled: ")
                 @Html.CheckBox("Cancelled", True)
             </dd>
             <dd>
                 @Html.Label("carrierLabel", "Carrier: ")
                 @Html.DropDownList("Carrier", "")
             </dd>
         </dl>


    <input type = "submit" value="Search"  /></p>

End Using

   <Table Class="table">
        <tr>
                 <th>
                 Carrier
            </th>
            <th>
                 Operator Name
            </th>
            <th>
                Destination
            </th>
            <th>
                Departure City
            </th>
            <th>
                Status
            </th>
            <th>
               Confirmation Number
            </th>
            <th>
                Agreement ID
            </th>
            <th>
                Arrival Date
            </th>
            <th>
                Departure Date
            </th>
            <th></th>
        </tr>

    @For Each item In Model
        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Carrier)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.OpName)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.TripDestination)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.TripCity)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.TripStatus)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Confirmation)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.charterAgreementId)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Arrival)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Departure)
            </td>
            <td>
                @Html.ActionLink("Edit", "Edit", New With {.id = item.ID}) |
                @Html.ActionLink("Details", "Details", New With {.id = item.ID}) |
                @Html.ActionLink("Delete", "Delete", New With {.id = item.ID})
            </td>
        </tr>
    Next

    </table>
</body>
</html>
