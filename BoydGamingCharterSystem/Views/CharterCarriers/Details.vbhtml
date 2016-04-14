@ModelType BoydGamingCharterSystem.CharterCarrier
@Code
    ViewData("Title") = "Details"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Details</h2>

<div>
    <h4>CharterCarrier</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Name)
        </dd>
    </dl>
</div>

<div>
    @Code
        Html.RenderPartial("~/Views/CharterCompany/Details.vbhtml", Model.CharterCompany)
    End Code
</div>

<p>
    @Html.ActionLink("Edit", "Edit", New With {.id = Model.Id}) |
    @Html.ActionLink("Back to List", "Index")
</p>
