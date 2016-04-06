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
    
    <!--<p>@Html.ActionLink("Create New", "Create")</p>-->

@Using Html.BeginForm("Index", "CharterTrips", FormMethod.Post)

    @<p>
        @Html.Label("startLabel", "Start: ")
        @Html.TextBox("StartDate", Date.Now.ToString("MM/dd/yyyy"), New With {.class = "date"})
    </p>
    @<p>
        @Html.Label("endLabel", "End: ")
        @Html.TextBox("EndDate", "", New With {.class = "date"})
    </p>

    @<p>
    @Html.Label("searchLabel", "Confirmation Number: ")
    @Html.TextBox("searchString")
    </p>

    @<p>
         <dl>
             
             <dd>
                 @Html.Label("activeLabel", "Active: ", New With {.style = "background-color:darkseagreen"})
                 @Html.CheckBox("Active", True)
             </dd>
             <dd>
                 @Html.Label("appliedLabel", "Applied: ", New With {.style = "background-color:yellow"})
                 @Html.CheckBox("Applied", True)
             </dd>
             <dd>
                 @Html.Label("cancelledLabel", "Canceled: ", New With {.style = "background-color:grey"})
                 @Html.CheckBox("Cancelled", True)
            </dd>
             <dd>
                @Html.Label("completedLabel", "Completed: ", New With {.style = "background-color:lightblue"})
                @Html.CheckBox("Completed", True)
             </dd>
             <dd>
                @Html.Label("potentialLabel", "Potential: ", New With {.style = "background-color:mediumpurple"})
                @Html.CheckBox("Potential", True)
            </dd>
             
             <dd>
                 @Html.Label("carrierLabel", "Carrier: ")                  
                 @Html.DropDownList("SelectedCarrier", New SelectList(DirectCast(ViewData("Carriers"), IEnumerable), "Value", "Text", ViewData("SelectedCarrier")), "All")                              
             </dd>
             <dd>
                 @Html.Label("operatorLabel", "Operator: ")
                 @Html.DropDownList("SelectedOperator", New SelectList(DirectCast(ViewData("Operators"), IEnumerable), "Value", "Text", ViewData("SelectedOperator")), "All")                                        
             </dd>           
</dl>
    <input type = "submit" value="Search"  /></p>

End Using

   <Table Class="table">
        <tr>
            <th>
                Agreement ID
            </th>
            <th>
                Carrier
            </th>
            <th>
                Operator
            </th>
            <th>
                City
            </th>
            <th>
                Manifest
            </th>
            <th>
                Confirmation Number
            </th>
            <th>
                Arrival
            </th>
            <th>
                Departure
            </th>
            <th></th>
        </tr>

    @For Each item In Model

        Dim stat = item.TripStatus
        Dim name

        'Select proper background color for each row
        Select Case stat
            Case "Applied"
                name = "yellow"

            Case "Active"
                name = "darkseagreen"

            Case "Cancelled"
                name = "grey"

            Case "Completed"
                name = "lightblue"

            Case "Potential"
                name = "mediumpurple"

            Case Else
                name = ""
        End Select


        @<tr style="background-color:@name">
        @Html.HiddenFor(Function(model) item.id)
            <td>
                <!--Need to add agreement name And pull from table-->
                @Html.DisplayFor(Function(modelItem) item.charterAgreementId)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.CarrierName)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.OperatorName)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.TripDestination)
            </td>
            <td>
                <!--Need to add manifest # And pull from table-->
                @Html.DisplayFor(Function(modelItem) item.TripStatus)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Confirmation)
            </td>
            
            <td>
                @Html.DisplayFor(Function(modelItem) item.Arrival)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Departure)
            </td>
            <td>
                <!--Change button to this style-->
                <a href"">

                </a>                
                @Html.ActionLink("Edit", "Edit", New With {.id = item.id}) |
                @Html.ActionLink("Details", "Details", New With {.id = item.id})
            </td>
        </tr>
    Next

    </table>
</body>

</html>
<!--Hooks up the datepicker to date fields-->
<script type="text/javascript">
    $(document).ready(function () {
        $('.date').datepicker({ dateFormat: "mm/dd/yy" });
    });
</script>
