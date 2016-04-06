@ModelType DateTime?
@Html.TextBox("", (If(Model.HasValue, Model.Value.ToShortDateString(), String.Empty)), New With {.class = "form-control datepicker"})
