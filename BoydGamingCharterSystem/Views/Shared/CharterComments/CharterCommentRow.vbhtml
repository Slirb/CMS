﻿@ModelType CharterSystem.CharterComment
@Code
    Layout = Nothing
End Code

<div class="commentRow">

    @Using (Html.BeginCollectionItem("comments"))

        @:<div class="form-group col-md-12">
            @Html.HiddenFor(Function(model) model.Id)

            @Html.LabelFor(Function(model) model.Content, htmlAttributes:=New With {.class = "control-label"})
            @Html.TextAreaFor(Function(model) model.Content, htmlAttributes:=New With {.class = "form-control col-md-12"})
            @Html.ValidationMessageFor(Function(model) model.Content, "", New With {.class = "text-danger"})

            @Html.LabelFor(Function(model) model.Highlight, htmlAttributes:=New With {.class = "control-label"})
            @Html.CheckBoxFor(Function(model) model.Highlight, htmlAttributes:=New With {.class = "form-control col-md-12"})
            @Html.ValidationMessageFor(Function(model) model.Highlight, "", New With {.class = "text-danger"})
            @:<a href="#" class="deleteRow btn btn-danger btn-md">Remove Comment</a>
        @:<hr />
        @:</div>
    End Using
</div>
