@ModelType CharterSystem.CharterCarrier
@Code
    ViewData("Title") = "Carrier Details"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Carrier Details</h2>

<div>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Company.Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Company.Name)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.Company.AddressLineOne)
        </dt>
        <dd>
            @Html.DisplayFor(Function(model) model.Company.AddressLineOne)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.Company.AddressLineTwo)
        </dt>
        <dd>
            @Html.DisplayFor(Function(model) model.Company.AddressLineTwo)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.Company.City)
        </dt>
        <dd>
            @Html.DisplayFor(Function(model) model.Company.City)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.Company.State.Name)
        </dt>
        <dd>
            @Html.DisplayFor(Function(model) model.Company.State.Name)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.Company.PostalCode)
        </dt>
        <dd>
            @If (String.IsNullOrEmpty(Model.Company.PostalCodeSuffix)) Then
                @Html.DisplayFor(Function(model) model.Company.PostalCode)
            Else
                @Html.DisplayFor(Function(model) model.Company.PostalCode & "-" & model.Company.PostalCodeSuffix)
            End If
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.Company.Country)
        </dt>
        <dd>
            @Html.DisplayFor(Function(model) model.Company.Country)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.Company.CompanyEmail)
        </dt>
        <dd>
            @Html.DisplayFor(Function(model) model.Company.CompanyEmail)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.Company.CompanyPrimaryPhone)
        </dt>
        <dd>
            @If (String.IsNullOrEmpty(Model.Company.CompanyPrimaryPhoneExtension)) Then
                Html.DisplayFor(Function(model) model.Company.CompanyPrimaryPhone)
            Else
                Html.DisplayFor(Function(model) model.Company.CompanyPrimaryPhone & " Ext. " & model.Company.CompanyPrimaryPhoneExtension)
            End If
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.Company.CompanyAlternatePhone)
        </dt>
        <dd>
            @If (String.IsNullOrEmpty(Model.Company.CompanyAlternatePhoneExtension)) Then
                Html.DisplayFor(Function(model) model.Company.CompanyAlternatePhone)
            Else
                Html.DisplayFor(Function(model) model.Company.CompanyAlternatePhone & " Ext. " & model.Company.CompanyAlternatePhoneExtension)
            End If
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.Company.CompanyEmergencyPhone)
        </dt>
        <dd>
            @If (String.IsNullOrEmpty(Model.Company.CompanyEmergencyPhoneExtension)) Then
                Html.DisplayFor(Function(model) model.Company.CompanyEmergencyPhone)
            Else
                Html.DisplayFor(Function(model) model.Company.CompanyEmergencyPhone & " Ext. " & model.Company.CompanyEmergencyPhoneExtension)
            End If
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.Company.CompanyFax)
        </dt>
        <dd>
            @If (String.IsNullOrEmpty(Model.Company.CompanyFaxExtension)) Then
                Html.DisplayFor(Function(model) model.Company.CompanyFax)
            Else
                Html.DisplayFor(Function(model) model.Company.CompanyFax & " Ext. " & model.Company.CompanyFax)
            End If
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.HasLicense)
        </dt>
        <dd>
            @Html.DisplayFor(Function(model) model.HasLicense)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.LicenseNumber)
        </dt>
        <dd>
            @Html.DisplayFor(Function(model) model.LicenseNumber)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.HasInsurance)
        </dt>
        <dd>
            @Html.DisplayFor(Function(model) model.HasInsurance)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.InsuranceNumber)
        </dt>
        <dd>
            @Html.DisplayFor(Function(model) model.InsuranceNumber)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.InsuranceExpiration)
        </dt>
        <dd>
            @Html.DisplayFor(Function(model) model.InsuranceExpiration)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.Company.Contacts)
        </dt>
        <dd>
            @For Each contact In Model.Contacts
                Html.RenderPartial("CharterContacts/CharterContactDetail", contact)
            Next
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.Comments)
        </dt>
        <dd>
            @For Each comment In Model.Comments
                Html.RenderPartial("CharterComments/CharterCommentDetail", comment)
            Next
        </dd>
    </dl>
</div>
    <div>
        <a href="@Url.Action("Edit", "CharterCarriers", New With {.id = Model.Id})" Class="btn btn-success btn-md"><span class="glyphicon glyphicon-plus"></span> Edit Carrier</a>&emsp;
        <a href="@Url.Action("Index", "CharterCarriers")" Class="btn btn-danger btn-md"><span class="glyphicon glyphicon-minus"></span> Back to List</a>
    </div>