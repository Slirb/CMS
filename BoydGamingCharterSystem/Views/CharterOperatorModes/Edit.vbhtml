@ModelType CharterSystem.CharterOperatorMode
@Code
    ViewData("Title") = "Edit"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Edit</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()
    
    @<div class="form-horizontal">
        <h4>CharterOperatorMode</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With { .class = "text-danger" })
        @Html.HiddenFor(Function(model) model.Id)

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Mode, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Mode, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.Mode, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Save" class="btn btn-success" />&emsp;&emsp;&emsp;
                <a href="@Url.Action("Index", "CharterOperatorModes")" Class="btn btn-default btn-md"><span class="glyphicon glyphicon-minus"></span> Back to Administration</a>
               @Html.ActionLink("Delete Record", "Delete", New With {.id = Model.Id}, New With {.class = "btn btn-danger"})
            </div>
        </div>
    </div>
End Using