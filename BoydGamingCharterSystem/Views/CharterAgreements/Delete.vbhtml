@ModelType BoydGamingCharterSystem.CharterAgreement
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>CharterAgreement</h4>
    <hr />
    <dl class="dl-horizontal">
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
            @Html.DisplayNameFor(Function(model) model.CreateDateTime)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CreateDateTime)
        </dd>

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
