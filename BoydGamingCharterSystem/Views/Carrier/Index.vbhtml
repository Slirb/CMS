@Code

    @ModelType  BoydGamingCharterSystem.Carrier

    Dim carObj As Carrier = New Carrier

    ViewData("Title") = "Operator Home"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Carrier Home</h2>

@Using Html.BeginForm("formAction", "Carrier", FormMethod.Post, New With {.id = "CarrierIDForm", .class = "carrierForm"})
    @<text>Enter a Carrier ID: </text> @Html.TextBox("CarrierID")
    @<text><input type="submit" value="Submit Data" /></text>

End Using


<p>Testing More Text</p>