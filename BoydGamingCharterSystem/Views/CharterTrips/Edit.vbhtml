@ModelType BoydGamingCharterSystem.CharterTrips

@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Edit</title>
</head>
<body>
    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/jqueryval")
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()
        
        @<div class="form-horizontal">
            <h4>CharterTrips</h4>
            <hr />
            @Html.ValidationSummary(True, "", New With { .class = "text-danger" })
            @Html.HiddenFor(Function(model) model.ID)
    
            <div class="form-group">
                @Html.LabelFor(Function(model) model.Carrier, htmlAttributes:= New With { .class = "control-label col-md-2" })
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Carrier, New With { .htmlAttributes = New With { .class = "form-control" } })
                    @Html.ValidationMessageFor(Function(model) model.Carrier, "", New With { .class = "text-danger" })
                </div>
            </div>
    
            <div class="form-group">
                @Html.LabelFor(Function(model) model.OpName, htmlAttributes:= New With { .class = "control-label col-md-2" })
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.OpName, New With { .htmlAttributes = New With { .class = "form-control" } })
                    @Html.ValidationMessageFor(Function(model) model.OpName, "", New With { .class = "text-danger" })
                </div>
            </div>
    
            <div class="form-group">
                @Html.LabelFor(Function(model) model.TripDestination, htmlAttributes:= New With { .class = "control-label col-md-2" })
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.TripDestination, New With { .htmlAttributes = New With { .class = "form-control" } })
                    @Html.ValidationMessageFor(Function(model) model.TripDestination, "", New With { .class = "text-danger" })
                </div>
            </div>
    
            <div class="form-group">
                @Html.LabelFor(Function(model) model.TripCity, htmlAttributes:= New With { .class = "control-label col-md-2" })
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.TripCity, New With { .htmlAttributes = New With { .class = "form-control" } })
                    @Html.ValidationMessageFor(Function(model) model.TripCity, "", New With { .class = "text-danger" })
                </div>
            </div>
    
            <div class="form-group">
                @Html.LabelFor(Function(model) model.TripStatus, htmlAttributes:= New With { .class = "control-label col-md-2" })
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.TripStatus, New With { .htmlAttributes = New With { .class = "form-control" } })
                    @Html.ValidationMessageFor(Function(model) model.TripStatus, "", New With { .class = "text-danger" })
                </div>
            </div>
    
            <div class="form-group">
                @Html.LabelFor(Function(model) model.Confirmation, htmlAttributes:= New With { .class = "control-label col-md-2" })
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Confirmation, New With { .htmlAttributes = New With { .class = "form-control" } })
                    @Html.ValidationMessageFor(Function(model) model.Confirmation, "", New With { .class = "text-danger" })
                </div>
            </div>
    
            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <input type="submit" value="Save" class="btn btn-default" />
                </div>
            </div>
        </div>
    End Using
    
    <div>
        @Html.ActionLink("Back to List", "Index")
    </div>
</body>
</html>
