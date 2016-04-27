@ModelType BoydGamingCharterSystem.EditTieredCommissionsModel
@Code
    ViewData("Title") = "Edit"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Edit</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
        <h4>CharterTieredCommissions</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        @Html.HiddenFor(Function(model) model.TieredCommission.Id)
        <div class="form-group">
            @Html.LabelFor(Function(model) model.TieredCommission.Name, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.TieredCommission.Name, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.TieredCommission.Name, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.TieredCommission.Description, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.TieredCommission.Description, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.TieredCommission.Description, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Save" class="btn btn-default" />
            </div>
        </div>
    </div>
End Using


@Using Html.BeginForm("AddValue", "CharterTieredCommissions")
    @Html.Hidden("comId", Model.TieredCommission.Id)
    @Html.Label("minRangeLabel", "Min. Range (Avg) : ")
    @Html.TextBox("minRange", "")@:&nbsp;&nbsp;
    @Html.Label("maxRangeLabel", "Max. Range (Avg) : ")
    @Html.TextBox("maxRange", "")@:&nbsp;&nbsp;
    @Html.Label("commissionLabel", "Commission : ")
    @Html.TextBox("commission", "") @:&nbsp;&nbsp;<input id="subButton" type="submit" value="Add" title="" />
End Using


<Table Class="table">
    <tr>
        <th>
            Min. Average Range
        </th>
        <th>
           Max. Average Range
        </th>
        <th>
            Commission Value Per Customer
        </th>
        
        <th></th>
    </tr>


    @For Each item In Model.Values

        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) item.commissionMin)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.commissionMax)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.commissionValuePerCustomer)
            </td>            
            <td>
                @Html.ActionLink("X", "DeleteValue", New With {.id = item.Id, .comId = item.CommissionID})
            </td>
        </tr>
    Next

</Table>



<div>
    @Html.ActionLink("Back to Administration", "Index")               <!--@Html.ActionLink("Delete Record", "Delete", New With {.id = Model.TieredCommission.Id})-->
</div>
