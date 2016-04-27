@ModelType BoydGamingCharterSystem.CharterOperator
@Code
    ViewData("Title") = "Delete Operator"
End Code

<h2>Delete Operator</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
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
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
             <input type="submit" value="Delete" class="btn btn-danger" />&emsp;&emsp;&emsp;
             @Html.ActionLink("Back to List", "Index", Nothing, New With {.class = "btn btn-default"})
        </div>
    End Using
</div>
