@ModelType CharterSystem.CharterContact
@Code
    Layout = Nothing
End Code



<div class="contactRow">
    @Using (Html.BeginCollectionItem("contacts"))


        @:<div class="form-group col-md-12">
            @Html.HiddenFor(Function(model) model.Id)

            @Html.LabelFor(Function(model) model.FirstName, htmlAttributes:=New With {.class = "control-label"})



            @Html.EditorFor(Function(model) model.FirstName, New With {.htmlAttributes = New With {.class = "form-control col-md-12"}})
            @Html.ValidationMessageFor(Function(model) model.FirstName, "", New With {.class = "text-danger"})


            @Html.LabelFor(Function(model) model.LastName, htmlAttributes:=New With {.class = "control-label"})
            @Html.EditorFor(Function(model) model.LastName, New With {.htmlAttributes = New With {.class = "form-control col-md-12"}})
            @Html.ValidationMessageFor(Function(model) model.LastName, "", New With {.class = "text-danger"})

            @Html.LabelFor(Function(model) model.PrimaryPhone, htmlAttributes:=New With {.class = "control-label"})
            @:<div class="form-inline">
                @Html.EditorFor(Function(model) model.PrimaryPhone, New With {.htmlAttributes = New With {.class = "form-control"}}) @:Ext. @Html.EditorFor(Function(model) model.PrimaryPhoneExtension, New With {.htmlAttributes = New With {.class = "form-control"}})
            @:</div>
            @Html.ValidationMessageFor(Function(model) model.PrimaryPhone, "", New With {.class = "text-danger"})
            @Html.ValidationMessageFor(Function(model) model.PrimaryPhoneExtension, "", New With {.class = "text-danger"})

            @Html.LabelFor(Function(model) model.AlternatePhone, htmlAttributes:=New With {.class = "control-label"})
            @:<div class="form-inline">
                @Html.EditorFor(Function(model) model.AlternatePhone, New With {.htmlAttributes = New With {.class = "form-control"}}) @:Ext. @Html.EditorFor(Function(model) model.AlternatePhoneExtension, New With {.htmlAttributes = New With {.class = "form-control"}})
            @:</div>
            @Html.ValidationMessageFor(Function(model) model.AlternatePhone, "", New With {.class = "text-danger"})
            @Html.ValidationMessageFor(Function(model) model.AlternatePhoneExtension, "", New With {.class = "text-danger"})

            @Html.LabelFor(Function(model) model.EmergencyPhone, htmlAttributes:=New With {.class = "control-label"})
            @:<div class="form-inline">
                @Html.EditorFor(Function(model) model.EmergencyPhone, New With {.htmlAttributes = New With {.class = "form-control"}}) @:Ext. @Html.EditorFor(Function(model) model.EmergencyPhoneExtension, New With {.htmlAttributes = New With {.class = "form-control"}})
            @:</div>
            @Html.ValidationMessageFor(Function(model) model.EmergencyPhone, "", New With {.class = "text-danger"})
            @Html.ValidationMessageFor(Function(model) model.EmergencyPhoneExtension, "", New With {.class = "text-danger"})

            @Html.LabelFor(Function(model) model.FaxNumber, htmlAttributes:=New With {.class = "control-label"})
            @:<div class="form-inline">
                @Html.EditorFor(Function(model) model.FaxNumber, New With {.htmlAttributes = New With {.class = "form-control"}}) @:Ext. @Html.EditorFor(Function(model) model.FaxNumberExtension, New With {.htmlAttributes = New With {.class = "form-control"}})
            @:</div>
            @Html.ValidationMessageFor(Function(model) model.FaxNumber, "", New With {.class = "text-danger"})
            @Html.ValidationMessageFor(Function(model) model.FaxNumberExtension, "", New With {.class = "text-danger"})

            @Html.LabelFor(Function(model) model.Email, htmlAttributes:=New With {.class = "control-label"})
            @Html.EditorFor(Function(model) model.Email, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.Email, "", New With {.class = "text-danger"})
            @:<a href="#" Class="deleteRow btn btn-danger btn-md">Remove Contact</a>
            


            @:<hr />
        @:</div>

    End Using

</div>