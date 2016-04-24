@ModelType BoydGamingCharterSystem.Administration

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
                <th>@Html.ActionLink("Create", "CreateInterest")</th>
            </tr>

            @For Each item In Model.operatorInterest

            @<tr>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Interest)
                </td>
                <td>

                    @Html.ActionLink("Edit", "EditInterest", New With {.id = item.Id})
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
                <th>@Html.ActionLink("Create", "CreateMode")</th>
            </tr>

            @For Each item In Model.operatorMode

        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Mode)
            </td>
            <td>

                @Html.ActionLink("Edit", "EditMode", New With {.id = item.Id})
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
                <th>@Html.ActionLink("Create", "CreateStopCode")</th>
            </tr>

            @For Each item In Model.operatorStopCode

            @<tr>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.StopCode)
                </td>
                <td>

                    @Html.ActionLink("Edit", "EditStopCode", New With {.id = item.Id})
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
                <th>@Html.ActionLink("Create", "CreateType")</th>
            </tr>

            @For Each item In Model.operatorType

            @<tr>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Type)
                </td>
                <td>

                    @Html.ActionLink("Edit", "EditType", New With {.id = item.Id})
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
                <th>@Html.ActionLink("Create", "CreateProperty")</th>
            </tr>

            @For Each item In Model.properties

            @<tr>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Name)
                </td>
                <td>

                    @Html.ActionLink("Edit", "EditProperty", New With {.id = item.ID})
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
                <th>
                    Description
                </th>
                <th>
                    Min
                </th>
                <th>
                    Max
                </th>
                <th>
                    Commission Per Customer
                </th>
                <th></th>
            </tr>

            @For Each item In Model.tieredCommissions

            @<tr>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Name)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Description)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Minimum)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Maximum)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Value)
                </td>
                <td>

                    @Html.ActionLink("Edit", "Edit", New With {.id = item.Id})
                </td>
            </tr>
            Next

        </Table>
        </div>



</body>

</html>