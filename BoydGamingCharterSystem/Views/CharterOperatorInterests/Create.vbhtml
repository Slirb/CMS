@ModelType BoydGamingCharterSystem.CharterOperatorInterest
@Code
    ViewData("Title") = "ViewCreate"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>ViewCreate</h2>

@Using (Html.BeginForm()) 
    @Html.AntiForgeryToken()
    
    @<div class="form-horizontal">
        <h4>CharterOperatorInterest</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With { .class = "text-danger" })
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Interest, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Interest, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.Interest, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Create" class="btn btn-success" />&emsp;&emsp;&emsp;
                <a href="@Url.Action("Index", "CharterOperatorInterests")" Class="btn btn-danger btn-md"><span class="glyphicon glyphicon-minus"></span> Back to Administration</a>
            </div>
        </div>
    </div>
End Using