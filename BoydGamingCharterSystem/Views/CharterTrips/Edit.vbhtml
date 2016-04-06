@ModelType BoydGamingCharterSystem.CharterTrips

@Code
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<!DOCTYPE html>
<!--Hookup for the tabs-->
<script type="text/javascript">
    $(function () {
        $("#tabs").tabs();
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
        If Model.Confirmation Is Nothing Then
            conf = "False"
        End If




        @<div class="form-horizontal">
            <h4>CharterTrips</h4>
            <hr />
            @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
            @Html.HiddenFor(Function(model) model.id)
            @Html.HiddenFor(Function(model) model.charterAgreementId)
            @Html.HiddenFor(Function(model) model.CarrierId)
            @Html.HiddenFor(Function(model) model.OperatorId)
            @Html.HiddenFor(Function(model) model.CarrierName)
            @Html.HiddenFor(Function(model) model.OperatorName)
            @Html.HiddenFor(Function(model) model.TripDestination)
            @Html.HiddenFor(Function(model) model.TripCity)
            @Html.HiddenFor(Function(model) model.TripStatus)
            @Html.HiddenFor(Function(model) model.Confirmation)
            @Html.HiddenFor(Function(model) model.CharterAgreements)

             <div>
                 <!--Need to add agreement name and pull from table-->
                 @Html.DisplayFor(Function(model) model.charterAgreementId)
             </div>

             <div class="form-group">
                 @Html.Label("Destination", htmlAttributes:=New With {.class = "control-label col-md-2"})
                 <div class="col-md-10">
                     @Html.DisplayFor(Function(model) model.TripDestination)
                 </div>
             </div>

             <div class="form-group">
                 @Html.Label("Carrier Name", htmlAttributes:=New With {.class = "control-label col-md-2"})
                 <div class="col-md-10">
                     @Html.DisplayFor(Function(model) model.CarrierName)
                 </div>
             </div>
            
             <div class="form-group">
                 @Html.Label("Operator Name", htmlAttributes:=New With {.class = "control-label col-md-2"})
                 <div class="col-md-10">
                     @Html.DisplayFor(Function(model) model.OperatorName)
                 </div>
             </div>
             
             <div class="form-group">
                 @Html.Label("Departure City", htmlAttributes:=New With {.class = "control-label col-md-2"})
                 <div class="col-md-10">
                     @Html.DisplayFor(Function(model) model.TripCity)
                 </div>
             </div>

             <div class="form-group">
                 @Html.LabelFor(Function(model) model.Arrival, htmlAttributes:=New With {.class = "control-label col-md-2"})
                 <div class="col-md-10">
                     @Html.EditorFor(Function(model) model.Arrival, New With {.htmlAttributes = New With {.class = "form-control"}})
                     @Html.ValidationMessageFor(Function(model) model.Arrival, "", New With {.class = "text-danger"})
                 </div>
             </div>

             <div class="form-group">
                 @Html.LabelFor(Function(model) model.Departure, htmlAttributes:=New With {.class = "control-label col-md-2"})
                 <div class="col-md-10">
                     @Html.EditorFor(Function(model) model.Departure, New With {.htmlAttributes = New With {.class = "form-control"}})
                     @Html.ValidationMessageFor(Function(model) model.Departure, "", New With {.class = "text-danger"})
                 </div>
             </div>

            <div class="form-group">
                @Html.Label("Status", htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.DisplayFor(Function(model) model.TripStatus)
                </div>
            </div>


             <div class="form-group">
                 @Html.LabelFor(Function(model) model.TripCity, htmlAttributes:=New With {.class = "control-label col-md-2"})
                 <div class="col-md-10">
                     @Html.EditorFor(Function(model) model.TripCity, New With {.htmlAttributes = New With {.class = "form-control"}})
                     @Html.ValidationMessageFor(Function(model) model.TripCity, "", New With {.class = "text-danger"})
                 </div>
             </div>
    
            <div class="form-group">
                @Html.LabelFor(Function(model) model.Confirmation, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">

                    
                        @Html.DisplayFor(Function(model) model.Confirmation)|
                    
                    <!--Displays a link if confirmation number exists-->
                    @if conf Is "True" Then
                        @Html.ActionLink("View Letter", "ConfirmationLetter", New With {.id = Model.id})
                    End If
                    
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <input type="submit" value="Save" class="btn btn-default" />
                    @Html.ActionLink("Close", "Index")
                    @Html.ActionLink("Cancel Trip", "CancelTrip", New With {.id = Model.id})                   
                </div>
            </div>
        </div>
    End Using
    
    
    <!--This is the tabbed section to be completed-->
    <div id="tabs">

    <ul>
        <li><a href="#tabs-1">Manifest Details</a></li>
        <li><a href="#tabs-2">Notes</a></li>
        <li><a href="#tabs-3">Comission</a></li>
    </ul>

    <div id="tabs-1">
        This will contain the passenger manifest
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
        </Table>
        
    </div>

    <div id="tabs-2">
        This will contain the notes for the trip
    </div>

    <div id="tabs-3">
        Here is where the reports will be generated
    </div>

    </div>
    
</body>
</html>
