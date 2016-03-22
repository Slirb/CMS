@ModelType BoydGamingCharterSystem.CharterCarrier
@Code
    ViewData("Title") = "Details"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Details</h2>

<div>
    <h4>CharterCarrier</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Company.Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Company.Name)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.Comments)
        </dt>
               
        
    </dl>
    
   
        
    @For Each item As CharterComment In Model.Comments()

        Html.RenderPartial("~/Views/Shared/_CommentsDetails.vbhtml", item)

    Next
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With {.id = Model.Id}) |
    @Html.ActionLink("Back to List", "Index")
</p>
