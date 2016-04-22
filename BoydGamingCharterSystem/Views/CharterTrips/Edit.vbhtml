@ModelType BoydGamingCharterSystem.EditTripsModel

@Code
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<!DOCTYPE html>
<!--Hookup for the tabs-->
<script type="text/javascript">
    $(function () {
        $("#tabs").tabs();
    });

    $(document).ready(function () {
        $('.date').datepicker({ dateFormat: "mm/dd/yy" });
    });
</script>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Edit</title>
</head>
<body>
    @Scripts.Render("~/bundles/jqueryval")
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        'Check for a confirmation number
        Dim conf As String = "True"
        If Model.trip.Confirmation Is Nothing Then
            conf = "False"
        End If




        @<div class="form-horizontal">
            <h4>CharterTrips</h4>
            <hr />
            @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
            @Html.HiddenFor(Function(model) model.trip.Id)            
            @Html.HiddenFor(Function(model) model.trip.charterAgreementId)
            @Html.HiddenFor(Function(model) model.trip.CarrierId)
            @Html.HiddenFor(Function(model) model.trip.OperatorId)
            @Html.HiddenFor(Function(model) model.trip.CarrierName)
            @Html.HiddenFor(Function(model) model.trip.OperatorName)
            @Html.HiddenFor(Function(model) model.trip.TripDestination)
            @Html.HiddenFor(Function(model) model.trip.TripStatus)
            @Html.HiddenFor(Function(model) model.trip.Confirmation)
            @Html.HiddenFor(Function(model) model.trip.ManifestCount)
            @Html.HiddenFor(Function(model) model.trip.TripNotes))
            
             <div>
                 <!--Need to add agreement name and pull from table-->
                 @Html.DisplayFor(Function(model) model.trip.charterAgreementId)
             </div>

             <div class="form-group">
                 @Html.Label("Destination", htmlAttributes:=New With {.class = "control-label col-md-2"})
                 <div class="col-md-10">
                     @Html.DisplayFor(Function(model) model.trip.TripDestination)
                 </div>
             </div>

             <div class="form-group">
                 @Html.Label("Carrier Name", htmlAttributes:=New With {.class = "control-label col-md-2"})
                 <div class="col-md-10">
                     @Html.DisplayFor(Function(model) model.trip.CarrierName)
                 </div>
             </div>
            
             <div class="form-group">
                 @Html.Label("Operator Name", htmlAttributes:=New With {.class = "control-label col-md-2"})
                 <div class="col-md-10">
                     @Html.DisplayFor(Function(model) model.trip.OperatorName)
                 </div>
             </div>
             
             <div class="form-group">
                 @Html.Label("Departure City", htmlAttributes:=New With {.class = "control-label col-md-2"})
                 <div class="col-md-10">
                     @Html.DisplayFor(Function(model) model.trip.TripCity)
                 </div>
             </div>

             <div class="form-group">
                 @Html.LabelFor(Function(model) model.trip.Arrival, htmlAttributes:=New With {.class = "control-label col-md-2"})
                 <div class="col-md-10">
                     @Html.TextBox("ArrivalDay", Model.trip.Arrival.Value.ToString("MM/dd/yyyy"), New With {.class = "date"})
                     @Html.Label("ArrivealHourLabel", "Hour: ")
                     @Html.DropDownList("ArrivalHour", DirectCast(ViewBag.ArriveHours, SelectList))
                     @Html.Label("ArrivalMinuteLabel", "Minute: ")
                     @Html.DropDownList("ArrivalMinute", DirectCast(ViewBag.ArriveMinutes, SelectList))
                     @Html.ValidationMessageFor(Function(model) model.trip.Arrival, "", New With {.class = "text-danger"})
                 </div>
             </div>

             <div Class="form-group">
                 @Html.LabelFor(Function(model) model.trip.Departure, htmlAttributes:=New With {.class = "control-label col-md-2"})
                 <div Class="col-md-10">
                     @Html.TextBox("DepartureDay", Model.trip.Arrival.Value.ToString("MM/dd/yyyy"), New With {.class = "date"})
                     @Html.Label("DepartureHourLabel", "Hour: ")
                     @Html.DropDownList("DepartureHour", DirectCast(ViewBag.DepartHours, SelectList))
                     @Html.Label("DepartureMinuteLabel", "Minute: ")
                     @Html.DropDownList("DepartureMinute", DirectCast(ViewBag.DepartMinutes, SelectList))
                     @Html.ValidationMessageFor(Function(model) model.trip.Departure, "", New With {.class = "text-danger"})
                 </div>
             </div>

            <div Class="form-group">
                @Html.Label("Status", htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div Class="col-md-10">
                    @Html.DisplayFor(Function(model) model.trip.TripStatus)
                </div>
            </div>


             <div Class="form-group">
                 @Html.LabelFor(Function(model) model.trip.TripCity, htmlAttributes:=New With {.class = "control-label col-md-2"})
                 <div Class="col-md-10">
                     @Html.EditorFor(Function(model) model.trip.TripCity, New With {.htmlAttributes = New With {.class = "form-control"}})
                     @Html.ValidationMessageFor(Function(model) model.trip.TripCity, "", New With {.class = "text-danger"})
                 </div>
             </div>

            <div Class="form-group">
                @Html.LabelFor(Function(model) model.trip.Confirmation, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div Class="col-md-10">
                        @Html.DisplayFor(Function(model) model.trip.Confirmation)
                    <!--Displays a link if confirmation number exists-->
                    @if conf Is "True" Then
                        @Html.ActionLink("View Letter", "ConfirmationLetter", New With {.id = Model.trip.Id})
                    End If
                </div>
            </div>

            <div Class="form-group">
                <div Class="col-md-offset-2 col-md-10">
                    <input type = "submit" value="Save" Class="btn btn-default" />
                    @Html.ActionLink("Close", "Index")
                    @Html.ActionLink("Cancel Trip", "CancelTrip", New With {.id = Model.trip.Id})
                </div>
            </div>
        </div>
    End Using


    <!--This Is the tabbed section to be completed-->
    <div id = "tabs" >


    <ul>
        <li> <a href = "#tabs-1" > Manifest Details</a></li>
        <li> <a href = "#tabs-2" > Notes</a></li>
        <li> <a href = "#tabs-3" > Comission</a></li>
    </ul>

    <div id = "tabs-1" >

        @Using Html.BeginForm("AddPerson", "CharterTrips")
            @Html.Hidden("tripId", Model.trip.Id)
            @Html.Label("searchLabel", "Card Number: ")
            @Html.TextBox("searchPerson", "")
            @<input id="subButton" type="submit" value="Add" title="" />
        End Using

        @Using Html.BeginForm("ImportManifest", "CharterTrips", FormMethod.Post, New With {.enctype = "multipart/form-data"})
            @Html.Hidden("id", Model.trip.Id)
            @<input type = "file" name="manifest" />
            @<input id = "subButton" type="submit" value="UploadFile" title="" />
        End Using

        @Html.ActionLink("Allocate Offers", "AllocateOffers", New With {.tripId = Model.trip.Id})


        <Table Class="table">
            <tr>
            <th>
            Card No
                </th>
                <th>
            Full Name
                </th>
                <th>
            DOB
                </th>
                <th>
            Addr1
                </th>
                <th>
            Addr2
                </th>
                <th>
            City
                </th>
                <th>
            State
                </th>
                <th>
            Zip
                </th>
                <th></th>
            </tr>


            @For Each item In Model.manifests

                @<tr>
                    <td>
                        @Html.DisplayFor(Function(modelItem) item.cardNumber)
                    </td>
                    <td>
                        @Html.DisplayFor(Function(modelItem) item.FullName)
                    </td>
                    <td>
                        @Html.DisplayFor(Function(modelItem) item.ShortDate)
                    </td>
                    <td>
                        @Html.DisplayFor(Function(modelItem) item.addressLineOne)
                    </td>
                    <td>
                        @Html.DisplayFor(Function(modelItem) item.addressLineTwo)
                    </td>
                    <td>
                        @Html.DisplayFor(Function(modelItem) item.city)
                    </td>
                    <td>
                        @Html.DisplayFor(Function(modelItem) item.state)
                    </td>
                    <td>
                        @Html.DisplayFor(Function(modelItem) item.postalCode)
                    </td>
                    <td>                                                                                                                         
                        @Html.ActionLink("X", "DeletePerson", New With {.id = item.Id, .tripId = Model.trip.Id})
                    </td>
                </tr>
            Next

        </Table>

    </div>

    <div id = "tabs-2" >
        @Using Html.BeginForm("SubmitNotes", "CharterTrips", FormMethod.Post)
            @Html.Hidden("id", Model.trip.Id)
            @Html.TextArea("tripNotes", Model.trip.TripNotes, New With {.class = "form-control", .name = "tripNotes"})
            @<input id="notesButton" type="submit" value="Save Notes" title="" />
        End Using

        
    </div>

    <div id = "tabs-3" >
        
        @Html.ActionLink("Player Stats", "PlayerStats", New With {.tripId = Model.trip.Id})<br />
        @Html.ActionLink("Analysis Report", "AnalysisReport", New With {.tripId = Model.trip.Id})<br/>
        @Html.ActionLink("Commission Report", "Commission Report", New With {.tripId = Model.trip.Id})<br />
    </div>

    </div>

</body>
</html>
