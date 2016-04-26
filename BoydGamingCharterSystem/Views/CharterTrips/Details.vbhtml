@ModelType BoydGamingCharterSystem.CharterTrips

@Code
    ViewData("Title") = "Trip Details"
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
        <h3>Charter Trip Details</h3>
        <hr />
        <dl class="dl-horizontal">
            <dt>
                @Html.DisplayNameFor(Function(model) model.CharterAgreements.CharterCarrier.Company.Name)
            </dt>
    
            <dd>
                @Html.DisplayFor(Function(model) model.CharterAgreements.CharterCarrier.Company.Name)
            </dd>
    
            <dt>
                @Html.DisplayNameFor(Function(model) model.CharterAgreements.CharterOperator.Company.Name)
            </dt>
    
            <dd>
                @Html.DisplayFor(Function(model) model.CharterAgreements.CharterOperator.Company.Name)
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
