﻿@ModelType BoydGamingCharterSystem.CharterTrips

@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Details</title>
</head>
<body>
    <div>
        <h4>CharterTrips</h4>
        <hr />
        <dl class="dl-horizontal">
            <dt>
                @Html.DisplayNameFor(Function(model) model.Carrier)
            </dt>
    
            <dd>
                @Html.DisplayFor(Function(model) model.Carrier)
            </dd>
    
            <dt>
                @Html.DisplayNameFor(Function(model) model.OpName)
            </dt>
    
            <dd>
                @Html.DisplayFor(Function(model) model.OpName)
            </dd>
    
            <dt>
                @Html.DisplayNameFor(Function(model) model.TripDestination)
            </dt>
    
            <dd>
                @Html.DisplayFor(Function(model) model.TripDestination)
            </dd>
    
            <dt>
                @Html.DisplayNameFor(Function(model) model.TripCity)
            </dt>
    
            <dd>
                @Html.DisplayFor(Function(model) model.TripCity)
            </dd>
    
            <dt>
                @Html.DisplayNameFor(Function(model) model.TripStatus)
            </dt>
    
            <dd>
                @Html.DisplayFor(Function(model) model.TripStatus)
            </dd>
    
            <dt>
                @Html.DisplayNameFor(Function(model) model.Confirmation)
            </dt>
    
            <dd>
                @Html.DisplayFor(Function(model) model.Confirmation)
            </dd>
    
            <dt>
                @Html.DisplayNameFor(Function(model) model.charterAgreementId)
            </dt>
    
            <dd>
                @Html.DisplayFor(Function(model) model.charterAgreementId)
            </dd>
    
            <dt>
                @Html.DisplayNameFor(Function(model) model.Arrival)
            </dt>
    
            <dd>
                @Html.DisplayFor(Function(model) model.Arrival)
            </dd>
    
            <dt>
                @Html.DisplayNameFor(Function(model) model.Departure)
            </dt>
    
            <dd>
                @Html.DisplayFor(Function(model) model.Departure)
            </dd>
    
        </dl>
    </div>
    <p>
        @Html.ActionLink("Edit", "Edit", New With { .id = Model.ID }) |
        @Html.ActionLink("Back to List", "Index")
    </p>
</body>
</html>
