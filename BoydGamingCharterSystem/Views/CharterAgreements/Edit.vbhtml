@ModelType BoydGamingCharterSystem.CharterAgreement
@Code
    ViewData("Title") = "Create"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Create</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
        <h4>Charter Agreement </h4>
        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        @Html.HiddenFor(Function(model) model.Id)
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Name, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Name, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Name, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Description, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.TextAreaFor(Function(model) model.Description, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Description, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.CharterProperty, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownListFor(Function(model) model.CharterPropertyId, DirectCast(ViewBag.Properties, SelectList), "---Select A Destination---", htmlAttributes:=New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.CharterProperty, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.CharterCarrier, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownListFor(Function(model) model.CharterCarrierId, DirectCast(ViewBag.CarrierId, SelectList), "---Select A Carrier---", htmlAttributes:=New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.CharterCarrier, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.CharterOperator, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownListFor(Function(model) model.CharterOperatorId, DirectCast(ViewBag.OperatorId, SelectList), "---Select An Operator---", htmlAttributes:=New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.CharterOperator, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.Label("Commission Strategy", htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-9">
                <div class="form-group form-inline">
                    @Html.EditorFor(Function(model) model.UseCommAmountPerCustomer, New With {.htmlAttributes = New With {.class = "form-control checkbox col-md-1"}})
                    @Html.LabelFor(Function(model) model.CommAmountPerCustomer, "$ Amount Per Customer", htmlAttributes:=New With {.class = "control-label col-md-4"})
                    @Html.EditorFor(Function(model) model.CommAmountPerCustomer, New With {.htmlAttributes = New With {.class = "form-control col-md-4"}})
                </div>
                <div class="form-group form-inline">
                    @Html.EditorFor(Function(model) model.UseCommPercentOfCustSpend, New With {.htmlAttributes = New With {.class = "form-control checkbox col-md-1"}})
                    @Html.LabelFor(Function(model) model.CommPercentOfCustSpend, "% of Customer Spend", htmlAttributes:=New With {.class = "control-label col-md-4"})
                    @Html.EditorFor(Function(model) model.CommPercentOfCustSpend, New With {.htmlAttributes = New With {.class = "form-control col-md-4"}})
                </div>
                <div class-="form-group form-inline">
                    @Html.EditorFor(Function(model) model.UseCommAmountPerBus, New With {.htmlAttributes = New With {.class = "form-control checkbox col-md-1"}})
                    @Html.LabelFor(Function(model) model.CommAmountPerBus, "$ Amount Per Bus", htmlAttributes:=New With {.class = "control-label col-md-4"})
                    @Html.EditorFor(Function(model) model.CommAmountPerBus, New With {.htmlAttributes = New With {.class = "form-control col-md-4"}})
                </div>

            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.TripCost, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.TripCost, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.TripCost, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.City, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.City, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.City, "", New With {.class = "text-danger"})
            </div>
        </div>


        <div class="form-group">
            @Html.LabelFor(Function(model) model.BenefitDescription, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.BenefitDescription, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.BenefitDescription, "", New With {.class = "text-danger"})

            </div>
        </div>
        <div class="form-group col-sm-12">
            @Html.Label("Schedule", htmlAttributes:=New With {.class = "control-label col-sm-2"})
            <div Class="col-md-10"></div>
                <div class="CharterTrips col-sm-11">
                    @For Each trip In Model.CharterTrips
                    Html.RenderPartial("CharterTrips/CharterTripCreateRow", trip)
                Next
                </div>
                @Html.ActionLink("Add Another Date", "BlankTripRow", "CharterTrips", Nothing, New With {.class = "addItem", .data_append = ".CharterTrips"})
            </div>
        <div Class="form-group">
            <div Class="col-md-10">
                <input type="submit" value="Edit" Class="btn btn-success btn-md"> 
                <a href="@Url.Action("Index", "CharterAgreements")" Class="btn btn-warning btn-md">Back to List</a>
            </div>
        </div>
    </div>  End Using
