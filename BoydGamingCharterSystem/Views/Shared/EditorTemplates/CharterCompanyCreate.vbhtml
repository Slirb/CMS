@ModelType CharterSystem.CharterCompany
@Code
    Layout = Nothing
End Code


@Html.HiddenFor(Function(model) model.Id)
<div class="CharterCompany">

    <div class="form-group">
        @Html.LabelFor(Function(model) model.Name, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.Name, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.Name, "", New With {.class = "text-danger"})
        </div>
    </div>

    <div class="form-group">
        @Html.LabelFor(Function(model) model.AddressLineOne, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.AddressLineOne, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.AddressLineOne, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(model) model.AddressLineTwo, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.AddressLineTwo, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.AddressLineTwo, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(model) model.Country, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.Country, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.Country, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(model) model.PostalCode, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            <div class="form-inline">
                @Html.EditorFor(Function(model) model.PostalCode, New With {.htmlAttributes = New With {.class = "form-control"}}) - @Html.EditorFor(Function(model) model.PostalCodeSuffix, New With {.htmlAttributes = New With {.class = "form-control"}})
            </div>

            @Html.ValidationMessageFor(Function(model) model.PostalCode, "", New With {.class = "text-danger"})
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
        @Html.LabelFor(Function(model) model.State, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.DropDownListFor(Function(model) model.StateId, DirectCast(ViewBag.States, SelectList), "---Select A State---")
            @Html.ValidationMessageFor(Function(model) model.StateId, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(model) model.CompanyPrimaryPhone, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            <div class="form-inline">
                @Html.EditorFor(Function(model) model.CompanyPrimaryPhone, New With {.htmlAttributes = New With {.class = "form-control"}}) Ext. @Html.EditorFor(Function(model) model.CompanyPrimaryPhoneExtension, New With {.htmlAttributes = New With {.class = "form-control"}})
            </div>

            @Html.ValidationMessageFor(Function(model) model.CompanyPrimaryPhone, "", New With {.class = "text-danger"})
            @Html.ValidationMessageFor(Function(model) model.CompanyPrimaryPhoneExtension, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(model) model.CompanyAlternatePhone, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            <div class="form-inline">
                @Html.EditorFor(Function(model) model.CompanyAlternatePhone, New With {.htmlAttributes = New With {.class = "form-control"}}) Ext. @Html.EditorFor(Function(model) model.CompanyAlternatePhoneExtension, New With {.htmlAttributes = New With {.class = "form-control"}})
            </div>

            @Html.ValidationMessageFor(Function(model) model.CompanyAlternatePhone, "", New With {.class = "text-danger"})
            @Html.ValidationMessageFor(Function(model) model.CompanyAlternatePhoneExtension, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(model) model.CompanyEmergencyPhone, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            <div class="form-inline">
                @Html.EditorFor(Function(model) model.CompanyEmergencyPhone, New With {.htmlAttributes = New With {.class = "form-control"}}) Ext. @Html.EditorFor(Function(model) model.CompanyEmergencyPhoneExtension, New With {.htmlAttributes = New With {.class = "form-control"}})
            </div>

            @Html.ValidationMessageFor(Function(model) model.CompanyEmergencyPhone, "", New With {.class = "text-danger"})
            @Html.ValidationMessageFor(Function(model) model.CompanyEmergencyPhoneExtension, "", New With {.class = "text-danger"})
        </div>
    </div>



    <div class="form-group">
        @Html.LabelFor(Function(model) model.CompanyFax, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            <div class="form-inline">
                @Html.EditorFor(Function(model) model.CompanyFax, New With {.htmlAttributes = New With {.class = "form-control"}}) Ext. @Html.EditorFor(Function(model) model.CompanyFaxExtension, New With {.htmlAttributes = New With {.class = "form-control"}})
            </div>

            @Html.ValidationMessageFor(Function(model) model.CompanyFax, "", New With {.class = "text-danger"})
            @Html.ValidationMessageFor(Function(model) model.CompanyFaxExtension, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(model) model.CompanyEmail, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.CompanyEmail, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.CompanyEmail, "", New With {.class = "text-danger"})
        </div>
    </div>
    
</div>



