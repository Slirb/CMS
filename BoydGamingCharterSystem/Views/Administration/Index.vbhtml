@ModelType BoydGamingCharterSystem.AdministrationModel

@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code


<!DOCTYPE html>

<html>


<head>
    <meta name="viewport" content="width=device-width" />
    <title>Index</title>
</head>
<body>
    
    
    <div style="float:left; width:30%">
        <!--Operator Interest List-->
        <h3>Operator Interests</h3>
        <Table Class="table">
            <tr>
                <th>
                    Interest
                </th>
                <th><a href="@Url.Action("CreateInterest", "Administration")" class="btn btn-success btn-xs"><span class="glyphicon glyphicon-plus"></span> Create</a></th>
            </tr>

            @For Each item In Model.operatorInterest

            @<tr>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Interest)
                </td>
                <td>
                    <a href="@Url.Action("EditInterest", "Administration", New With {.id = item.Id})" class="btn btn-default btn-xs"><span class="glyphicon glyphicon-edit"></span> Edit</a>                   
                </td>
            </tr>
            Next

        </Table>
    </div>

    <div style="float:right; width:30%">
        <!--Operator Mode List-->
        <h3>Operator Modes</h3>        
        <Table Class="table">
            <tr>
                <th>
                    Mode
                </th>
                <th><a href="@Url.Action("CreateMode", "Administration")" class="btn btn-success btn-xs"><span class="glyphicon glyphicon-plus"></span> Create</a></th>
            </tr>

            @For Each item In Model.operatorMode

        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Mode)
            </td>
            <td>
                <a href="@Url.Action("EditMode", "Administration", New With {.id = item.Id})" class="btn btn-default btn-xs"><span class="glyphicon glyphicon-edit"></span> Edit</a>
            </td>
        </tr>
            Next

        </Table>

        </div>
    <div style="clear:both"></div>
    <br />
    <br />
    <br />

    <div style="float:left; width:30%; position:relative">
        <!--Operator StopCode List-->
        <h3>Operator Stop Codes</h3>        
        <Table Class="table">
            <tr>
                <th>
                    Stop Code
                </th>
                <th><a href="@Url.Action("CreateStopCode", "Administration")" class="btn btn-success btn-xs"><span class="glyphicon glyphicon-plus"></span> Create</a></th>
            </tr>

            @For Each item In Model.operatorStopCode

            @<tr>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.StopCode)
                </td>
                <td>
                    <a href="@Url.Action("EditStopCode", "Administration", New With {.id = item.Id})" class="btn btn-default btn-xs"><span class="glyphicon glyphicon-edit"></span> Edit</a>
                </td>
            </tr>
            Next

        </Table>
        </div>


    <div style="float:right; width:30%">
        <h3>Operator Types</h3>
        <!--Operator Type List-->
        <Table Class="table">
            <tr>
                <th>
                    Type
                </th>
                <th><a href="@Url.Action("CreateType", "Administration")" class="btn btn-success btn-xs"><span class="glyphicon glyphicon-plus"></span> Create</a></th>
            </tr>

            @For Each item In Model.operatorType

            @<tr>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Type)
                </td>
                <td>
                    <a href="@Url.Action("EditType", "Administration", New With {.id = item.Id})" class="btn btn-default btn-xs"><span class="glyphicon glyphicon-edit"></span> Edit</a>                   
                </td>
            </tr>
            Next

        </Table>
        </div>

    <div style="clear:both"></div>
    <br />
    <br />
    <br />

    <div style="float:left; width:30%; position:relative">
        <!--Properties List-->
        <h3>Properties</h3>
        <Table Class="table">
            <tr>
                <th>
                    Name
                </th>
                <th><a href="@Url.Action("CreateProperty", "Administration")" class="btn btn-success btn-xs"><span class="glyphicon glyphicon-plus"></span> Create</a></th>
            </tr>

            @For Each item In Model.properties

            @<tr>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Name)
                </td>
                <td>
                    <a href="@Url.Action("EditProperty", "Administration", New With {.id = item.ID})" class="btn btn-default btn-xs"><span class="glyphicon glyphicon-edit"></span> Edit</a>                   
                </td>
            </tr>
            Next

        </Table>

        </div>


    <div style="float:right; width:30%">
        <!--Tired Commission List-->
        <h3>Tiered Commissions</h3>
        <Table Class="table">
            <tr>
                <th>
                    Name
                </th>               
                <th><a href="@Url.Action("CreateCommission", "Administration")" class="btn btn-success btn-xs"><span class="glyphicon glyphicon-plus"></span> Create</a></th>
            </tr>

            @For Each item In Model.tieredCommissions

            @<tr>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Name)
                </td>                
                <td>
                    <a href="@Url.Action("EditCommission", "Administration", New With {.id = item.Id})" class="btn btn-default btn-xs"><span class="glyphicon glyphicon-edit"></span> Edit</a>                    
                </td>
            </tr>
            Next

        </Table>
        </div>



</body>

</html>