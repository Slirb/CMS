@ModelType BoydGamingCharterSystem.CharterTrips
@Code
    Layout = Nothing
End Code


<div class="CharterTripRow">
    @Using (Html.BeginCollectionItem("CharterTrips"))
        @Html.HiddenFor(Function(model) model.Id)
        @:<div class="form-group">
            Html.LabelFor(Function(model) model.Arrival, htmlAttributes:=New With {.class = "control-label"})
            @:<div class="form-inline">
                    @Html.Label("Date:", htmlAttributes:=New With {.class = "control-label"})
        @Html.EditorFor(Function(model) model.ArrivalDate, New With {.htmlAttributes = New With {.class = "form-control"}})
        @Html.Label("Hour:", htmlAttributes:=New With {.class = "control-label"})
        @Html.EditorFor(Function(model) model.ArrivalHour, New With {.htmlAttributes = New With {.class = "form-control"}})
        @Html.Label("Minute:", htmlAttributes:=New With {.class = "control-label"})
        @Html.EditorFor(Function(model) model.ArrivalMinute, New With {.htmlAttributes = New With {.class = "form-control"}})


            @:</div>


        @Html.LabelFor(Function(model) model.Departure, htmlAttributes:=New With {.class = "control-label"})
            @:<div class="form-inline">

        @Html.EditorFor(Function(model) model.DepartureDate, New With {.htmlAttributes = New With {.class = "form-control"}})
        @Html.Label("Hour:", htmlAttributes:=New With {.class = "control-label"})
        @Html.EditorFor(Function(model) model.DepartureHour, New With {.htmlAttributes = New With {.class = "form-control"}})
        @Html.Label("Minute:", htmlAttributes:=New With {.class = "control-label"})
        @Html.EditorFor(Function(model) model.DepartureMinute, New With {.htmlAttributes = New With {.class = "form-control"}})
            @:</div>
            @:<a href="#" class="deleteRow btn btn-danger btn-md">Remove Trip</a>
        @:</div>

    End Using
</div>