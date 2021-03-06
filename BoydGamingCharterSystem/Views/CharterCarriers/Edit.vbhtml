﻿@ModelType CharterSystem.CharterCarrier
@Code
    ViewData("Title") = "Edit Carrier"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()
    
    @<div class="form-horizontal">
        <h2>Edit Charter Carrier</h2>
         <button type="submit" class="btn btn-success btn-md"> <span class="glyphicon glyphicon-plus"></span> Save Changes</button>&emsp;
         <a href="@Url.Action("Index", "CharterCarriers")" Class="btn btn-danger btn-md"><span class="glyphicon glyphicon-minus"></span> Back to List</a>
        <hr />
        @Html.ValidationSummary(True, "", New With { .class = "text-danger" })
        @Html.HiddenFor(Function(model) model.Id)

         <div id="CharterCompany" class="form-group">
             @Html.EditorFor(Function(model) model.Company, "CharterCompanyCreate")

         </div>
         <div class="form-group">
             @Html.LabelFor(Function(model) model.HasLicense, htmlAttributes:=New With {.class = "control-label col-md-2"})
             <div class="col-md-3">
                 @Html.EditorFor(Function(model) model.HasLicense, New With {.htmlAttributes = New With {.class = "form-control"}})
                 @Html.ValidationMessageFor(Function(model) model.HasLicense, "", New With {.htmlAttributes = New With {.class = "text-danger"}})
             </div>

         </div>
         <div class="form-group">
             @Html.LabelFor(Function(model) model.LicenseNumber, htmlAttributes:=New With {.class = "control-label col-md-2"})
             <div class="col-md-10">
                 @Html.EditorFor(Function(Model) Model.LicenseNumber, New With {.htmlAttributes = New With {.class = "form-control"}})
                 @Html.ValidationMessageFor(Function(model) model.LicenseNumber, "", New With {.htmlAttributes = New With {.class = "text-danger"}})
             </div>
         </div>
         <div class="form-group">
             @Html.LabelFor(Function(model) model.HasInsurance, htmlAttributes:=New With {.class = "control-label col-md-2"})
             <div class="col-md-3">
                 @Html.EditorFor(Function(model) model.HasInsurance, New With {.htmlAttributes = New With {.class = "form-control"}})
                 @Html.ValidationMessageFor(Function(model) model.HasInsurance, "", New With {.htmlAttributes = New With {.class = "text-danger"}})
             </div>

         </div>
         <div class="form-group">
             @Html.LabelFor(Function(model) model.InsuranceNumber, htmlAttributes:=New With {.class = "control-label col-md-2"})
             <div class="col-md-10">
                 @Html.EditorFor(Function(Model) Model.InsuranceNumber, New With {.htmlAttributes = New With {.class = "form-control"}})
                 @Html.ValidationMessageFor(Function(model) model.InsuranceNumber, "", New With {.htmlAttributes = New With {.class = "text-danger"}})
             </div>
         </div>
         <div class="form-group">
             @Html.LabelFor(Function(model) model.InsuranceExpiration, htmlAttributes:=New With {.class = "control-label col-md-2"})
             <div class="col-md-10">
                 @Html.EditorFor(Function(model) model.InsuranceExpiration, New With {.htmlAttributes = New With {.class = "form-control"}})
                 @Html.ValidationMessageFor(Function(model) model.InsuranceExpiration, "", New With {.htmlAttributes = New With {.class = "text-danager"}})
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

         <div>
             <button type="submit" class="btn btn-success btn-md"> <span class="glyphicon glyphicon-plus"></span> Save Changes</button>&emsp;
             <a href="@Url.Action("Index", "CharterCarriers")" Class="btn btn-danger btn-md"><span class="glyphicon glyphicon-minus"></span> Back to List</a>
         </div>
    </div>
End Using
