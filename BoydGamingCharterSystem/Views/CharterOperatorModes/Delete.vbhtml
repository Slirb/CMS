@ModelType BoydGamingCharterSystem.CharterOperatorMode
@Code
    ViewData("Title") = "Delete"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>CharterOperatorMode</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Mode)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Mode)
        </dd>

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-danger btn-md" /> |
            @Html.ActionLink("Back to Administration", "Index", Nothing, New With {.class = "btn btn-default"})
        </div>
    End Using
</div>
