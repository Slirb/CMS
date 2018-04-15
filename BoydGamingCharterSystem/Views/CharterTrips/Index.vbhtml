@ModelType IEnumerable(Of CharterSystem.CharterTrips)

@Code
    ViewData("Title") = "Trips"
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
    
    <!--<p>@Html.ActionLink("Create New", "Create")</p>-->

@Using Html.BeginForm("Index", "CharterTrips", FormMethod.Get)

    @<p>
    <div class="row">
    <div Class="col-sm-3">
        <dl>
            <dd>
                @Html.Label("startLabel", "Start: ", New With {.class = "label-trips"})<br />
        @Html.TextBox("StartDate", Date.Now.ToString("MM/dd/yyyy"), New With {.class = "date"})
            </dd>

            <dd>
                @Html.Label("endLabel", "End: ", New With {.class = "label-trips"})<br />
        @Html.TextBox("EndDate", "", New With {.class = "date"})
            </dd>
        </dl>

    </div>

         <div Class="col-sm-2">
             <div class="panel panel-info">
                 <div class="panel-body">
         <dl>
                        <dd>
                            <span class="label label-success col-md-9" style="text-align:left">@Html.CheckBox("Active", True) Active</span><br />
                            <span class="label label-warning col-md-9 text-align:left" style="text-align:left">@Html.CheckBox("Applied", True) Applied</span><br />
                            <span class="label label-danger col-md-9" style="text-align:left"> @Html.CheckBox("Cancelled", True) Canceled</span><br />
                            <span class="label label-default col-md-9" style="text-align:left">@Html.CheckBox("Completed", True) Completed</span><br />
                            <span class="label label-info col-md-9" style="text-align:left">@Html.CheckBox("Potential", True) Pending</span>
                        </dd>
                    </dl>
                </div>
             </div>
          </div>
                     <div Class="col-sm-4">
                         <dl>
             <dd>
                                 @Html.Label("searchLabel", "Confirmation Number: ", New With {.class = "label-trips"})<br />
                                 @Html.TextBox("searchString", "", New With {.class = "text-input-trips"})
             </dd>
             <dd>
                                 @Html.Label("operatorLabel", "Operator: ", New With {.class = "label-trips"})<br />
                                 @Html.DropDownList("SelectedOperator", New SelectList(DirectCast(ViewData("Operators"), IEnumerable), "Value", "Text", ViewData("SelectedOperator")), "All")
            </dd>
             <dd>
                                 @Html.Label("carrierLabel", "Carrier: ", New With {.class = "label-trips"})<br />
                 @Html.DropDownList("SelectedCarrier", New SelectList(DirectCast(ViewData("Carriers"), IEnumerable), "Value", "Text", ViewData("SelectedCarrier")), "All")                              
             </dd>
                         </dl>
             </div>

             <div Class="col-sm-3">
                 <dl>
             <dd>
                         <button type="submit" Class="btn btn-success btn-primary"> <span Class="glyphicon glyphicon-search"></span> Search Trips</button>
             </dd>           
</dl>
             </div>
             </div>


</p>

End Using

<Table Class="table table-condensed" style="background-color:lemonchiffon">
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
                City
            </th>
            <th style="text-align:center">
                Manifest
            </th>
            <th style="text-align:center">
                Confirmation Number
            </th>
            <th style="text-align:center">
                Arrival
            </th>
            <th style="text-align:center">
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
                        name = "sandybrown"

            Case "Active"
                        name = "mediumseagreen"

            Case "Cancelled"
                        name = "indianred"

            Case "Completed"
                        name = "grey"

            Case "Potential"
                        name = "lightskyblue"

            Case Else
                name = ""
        End Select


        @<tr style="background-color:@name">
            <td style="text-align:center">
                <!--Need to add agreement name And pull from table-->
                @Html.DisplayFor(Function(modelItem) item.CharterAgreements.Name)
            </td>
            <td style="text-align:center">
                @Html.DisplayFor(Function(modelItem) item.CarrierName)
            </td>
            <td style="text-align:center">
                @Html.DisplayFor(Function(modelItem) item.OperatorName)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.TripCity)
            </td>
            <td style="text-align:center">
                @Html.DisplayFor(Function(modelItem) item.ManifestCount)
            </td>
            <td style="text-align:center">
                @Html.DisplayFor(Function(modelItem) item.Confirmation)
            </td>
            
            <td style="text-align:center">
                @Html.DisplayFor(Function(modelItem) item.DisplayArrival)
            </td>
            <td style="text-align:center">
                @Html.DisplayFor(Function(modelItem) item.DisplayDeparture)
            </td>
            <td>
                <a href="@Url.Action("Edit", "CharterTrips", New With {.id = item.Id})" class="btn btn-default btn-xs"><span class="glyphicon glyphicon-edit"></span></a>                
            </td>
        </tr>
    Next

</Table>
</body>

</html>
<!--Hooks up the datepicker to date fields-->
<script type="text/javascript">
    $(document).ready(function () {
        $('.date').datepicker({ dateFormat: "mm/dd/yy" });
    });
</script>
