@Code
    @ModelType BoydGamingCharterSystem.Carrier

    ViewData("Title") = "Carrier Form Submission"
    Dim carObj As Carrier = New Carrier
    carObj = ViewBag.carrier
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Form Submission Complete!</h2>
<p>
    Here is the object we submitted <br/>
    @carObj <br/>
    Here is the Carrier's ID <br/>
    @carObj.id



</p>

