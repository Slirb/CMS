﻿@ModelType CharterSystem.CharterOperator
@Code
    ViewData("Title") = "Create Operator"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Create Operator</h2>

@Using (Html.BeginForm()) 
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
        <hr />
        @Html.HiddenFor(Function(model) model.Id)
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        <div class="form-group">
            @Html.HiddenFor(Function(model) model.Company.Id)
            @Html.EditorFor(Function(model) model.Company, "CharterCompanyCreate")
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.VendorNumber, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.VendorNumber, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.VendorNumber, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Type, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.DropDownListFor(Function(model) model.Type, DirectCast(ViewBag.OpTypes, SelectList), "---Select A Type---")
                @Html.ValidationMessageFor(Function(model) model.Type, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Mode, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.DropDownListFor(Function(model) model.Mode, DirectCast(ViewBag.OpModes, SelectList), "---Select A Mode---")
                @Html.ValidationMessageFor(Function(model) model.Mode, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Interest, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.DropDownListFor(Function(model) model.Interest, DirectCast(ViewBag.OpInterests, SelectList), "---Select An Interest---")
                @Html.ValidationMessageFor(Function(model) model.Interest, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.StopCode, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.DropDownListFor(Function(model) model.StopCode, DirectCast(ViewBag.OpStopCodes, SelectList), "---Select A Stop Code---")
                @Html.ValidationMessageFor(Function(model) model.StopCode, "", New With { .class = "text-danger" })
            </div>
        </div>
        <div class="form-group">
            @Html.Label("Company Contacts", htmlAttributes:=New With {.class = "control-label col-md-2"})
            @Html.HiddenFor(Function(model) model.Company.Contactable.ContactableId)
            <div class="CharterCompanyContacts col-md-10">
                @For Each contact As CharterContact In Model.Contacts
                    Html.RenderPartial("CharterContacts/CharterContactRow", contact)
                Next
            </div>
            @Html.ActionLink("Add Another Contact", "BlankContactRow", "CharterContacts", Nothing, New With {.class = "btn btn-default active addItem", .data_append = ".CharterCompanyContacts"})
        </div>
         <div class="form-group">
             @Html.LabelFor(Function(model) model.Comments, htmlAttributes:=New With {.class = "control-label col-md-2"})
             @Html.HiddenFor(Function(model) model.Commentable.CommentableId)
             <div class="CharterCompanyComments col-md-10">
                 @For Each comment As CharterComment In Model.Comments

                    Html.RenderPartial("CharterComments/CharterCommentRow", comment)
                Next
             </div>
             @Html.ActionLink("Add Another Comment", "BlankCommentRow", "CharterComments", Nothing, New With {.class = "btn btn-default active addItem", .data_append = ".CharterCompanyComments"})
         </div>

        <div Class="form-group">
            <div>
                <button type="submit" class="btn btn-success btn-md"> <span class="glyphicon glyphicon-plus"></span> Create Operator</button>&emsp;
                <a href="@Url.Action("Index", "CharterOperators")" Class="btn btn-danger btn-md"><span class="glyphicon glyphicon-minus"></span> Back to List</a>
            </div>
        </div>
    </div>
End Using