@ModelType BoydGamingCharterSystem.CharterAgreement
@Code
    ViewData("Title") = "CharterDetails2"
End Code

<h2>CharterDetails2</h2>

<div>
    <h4>CharterAgreement</h4>
    <hr />
    <dl class="dl-horizontal">
    </dl>
</div>
<p>
    @*@Html.ActionLink("Edit", "Edit", New With {.id = Model.PrimaryKey}) |*@
    @Html.ActionLink("Back to List", "Index")
</p>
