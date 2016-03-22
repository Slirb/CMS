@ModelType BoydGamingCharterSystem.CharterComment

<div>
    <h4>CharterComment</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Content)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Content)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.CreateDateTime)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CreateDateTime)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.Id }) |
    @Html.ActionLink("Back to List", "Index")
</p>
