@ModelType BoydGamingCharterSystem.CharterOperator
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>CharterOperator</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.VendorNumber)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.VendorNumber)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Type)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Type)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Mode)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Mode)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Interest)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Interest)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.StopCode)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.StopCode)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.Id }) |
    @Html.ActionLink("Back to List", "Index")
</p>
