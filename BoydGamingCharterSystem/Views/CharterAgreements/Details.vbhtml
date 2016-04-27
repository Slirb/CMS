@ModelType BoydGamingCharterSystem.CharterAgreement
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
<p>
    @Html.ActionLink("Edit", "Edit", New With {.id = Model.Id}, New With {.class = "btn btn-success"}) &emsp;&emsp;&emsp;
    @Html.ActionLink("Back to List", "Index", Nothing, New With {.class = "btn btn-default"})
</p>
