@ModelType CharterSystem.CharterCarrier
@Code
    ViewData("Title") = "Delete Carrier"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Delete Carrier</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Company.Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Company.Name)
        </dd>

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-danger" />&emsp;&emsp;&emsp;
            @Html.ActionLink("Back to List", "Index", Nothing, New With {.class = "btn btn-default"})
        </div>
    End Using
</div>
