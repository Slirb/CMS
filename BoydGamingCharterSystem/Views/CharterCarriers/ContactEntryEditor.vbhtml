@ModelType BoydGamingCharterSystem.CharterContact
@Imports (Html.BeginCollectionItem("CarrierContact"))
@Code
    @Html.LabelFor(Function(model) model.FirstName)
    @Html.EditorFor(Function(model) model.FirstName)
    @Html.ValidationMessageFor(Function(model) model.FirstName)
    @<a href="#" class="deleteRow">X</a>
End Code