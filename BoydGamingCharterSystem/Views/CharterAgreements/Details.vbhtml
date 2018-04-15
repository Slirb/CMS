@ModelType CharterSystem.CharterAgreement
@Code
    ViewData("Title") = "Agreement Details"
End Code

<h2>Agreement Details</h2>

<div>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Name)
        </dt>
        <dd>
            @Html.DisplayFor(Function(model) model.Name)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.Description)
        </dt>
        <dd>
            @Html.DisplayFor(Function(model) model.Description)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.CharterProperty.Name)
        </dt>
        <dd>
            @Html.DisplayFor(Function(model) model.CharterProperty.Name)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.CharterCarrier.LicenseNumber)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CharterCarrier.LicenseNumber)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.CharterOperator.VendorNumber)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CharterOperator.VendorNumber)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.CreatedDateTime)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CreatedDateTime)
        </dd>

    </dl>
</div>
<div>
    <a href="@Url.Action("Edit", "CharterAgreements", New With {.id = Model.Id})" Class="btn btn-success btn-md"><span class="glyphicon glyphicon-plus"></span> Edit Agreement</a>&emsp;
    <a href="@Url.Action("Index", "CharterAgreements")" Class="btn btn-danger btn-md"><span class="glyphicon glyphicon-minus"></span> Back to List</a>
</div>
