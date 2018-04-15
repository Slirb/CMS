@ModelType CharterSystem.CharterProperties
@Code
    ViewData("Title") = "Delete"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>CharterProperties</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.DepartmentName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DepartmentName)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.ContactNumber)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ContactNumber)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.FaxNumber)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.FaxNumber)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Name)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.ShortName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ShortName)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Code)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Code)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.CreatedDate)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CreatedDate)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.CreatedBy)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CreatedBy)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.UpdatedDate)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.UpdatedDate)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.UpdatedBy)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.UpdatedBy)
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
