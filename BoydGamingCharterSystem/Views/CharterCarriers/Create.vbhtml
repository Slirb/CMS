@ModelType BoydGamingCharterSystem.CharterCarrier
@Code
    ViewData("Title") = "Create"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Create</h2>

@Using (Html.BeginForm()) 
    @Html.AntiForgeryToken()
    
    @<div class="form-horizontal">
        <h4>Add New Charter Carrier</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With { .class = "text-danger" })
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Company.Name, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Company.Name, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Company.Name, "", New With {.class = "text-danger"})
            </div>
        </div>
        
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Company.AddressLineOne, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Company.AddressLineOne, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Company.AddressLineOne, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Company.AddressLineTwo, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Company.AddressLineTwo, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Company.AddressLineTwo, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Company.Country, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Company.Country, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Company.Country, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Company.PostalCode, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                <div class="form-inline">
                    @Html.EditorFor(Function(model) model.Company.PostalCode, New With {.htmlAttributes = New With {.class = "form-control"}}) - @Html.EditorFor(Function(model) model.Company.PostalCodeSuffix, New With {.htmlAttributes = New With {.class = "form-control"}})
                </div>
              
                @Html.ValidationMessageFor(Function(model) model.Company.PostalCode, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Company.City, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Company.City, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Company.City, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Company.State, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownList("States", "Select a state")
                @Html.ValidationMessageFor(Function(model) model.Company.State, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Company.CompanyPrimaryPhone, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                <div class="form-inline">
                    @Html.EditorFor(Function(model) model.Company.CompanyPrimaryPhone, New With {.htmlAttributes = New With {.class = "form-control"}}) Ext. @Html.EditorFor(Function(model) model.Company.CompanyPrimaryPhoneExtension, New With {.htmlAttributes = New With {.class = "form-control"}})
                </div>

                @Html.ValidationMessageFor(Function(model) model.Company.CompanyPrimaryPhone, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Company.CompanyAlternatePhone, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                <div class="form-inline">
                    @Html.EditorFor(Function(model) model.Company.CompanyAlternatePhone, New With {.htmlAttributes = New With {.class = "form-control"}}) Ext. @Html.EditorFor(Function(model) model.Company.CompanyAlternatePhoneExtension, New With {.htmlAttributes = New With {.class = "form-control"}})
                </div>

                @Html.ValidationMessageFor(Function(model) model.Company.CompanyAlternatePhone, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Company.CompanyEmergencyPhone, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                <div class="form-inline">
                    @Html.EditorFor(Function(model) model.Company.CompanyEmergencyPhone, New With {.htmlAttributes = New With {.class = "form-control"}}) Ext. @Html.EditorFor(Function(model) model.Company.CompanyEmergencyPhoneExtension, New With {.htmlAttributes = New With {.class = "form-control"}})
                </div>

                @Html.ValidationMessageFor(Function(model) model.Company.CompanyEmergencyPhone, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Company.CompanyFax, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                <div class="form-inline">
                    @Html.EditorFor(Function(model) model.Company.CompanyFax, New With {.htmlAttributes = New With {.class = "form-control"}}) Ext. @Html.EditorFor(Function(model) model.Company.CompanyFaxExtension, New With {.htmlAttributes = New With {.class = "form-control"}})
                </div>

                @Html.ValidationMessageFor(Function(model) model.Company.CompanyFax, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Company.CompanyEmail, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Company.CompanyEmail, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Company.CompanyEmail, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Company.Contacts, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Company.Contacts, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Company.Contacts, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Create" class="btn btn-default" />
            </div>
        </div>
    </div>  

End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>
