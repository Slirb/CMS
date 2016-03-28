
@ModelType BoydGamingCharterSystem.CharterContact


<div class="form-group charterContact">
    @Html.LabelFor(Function(model) model.FirstName, htmlAttributes:=New With {.class = "control-label col-md-2"})
    <div class="col-md-10">
        @Html.EditorFor(Function(model) model.FirstName, New With {.htmlAttributes = New With {.class = "form-control"}})
    </div>
    @Html.HiddenFor(Function(model) model.DeleteContact, New With {.class = "mark-for-delete"})
    @Html.RemoveLink("Remove", "div.charterContact", "input.mark-for-delete")
</div>
