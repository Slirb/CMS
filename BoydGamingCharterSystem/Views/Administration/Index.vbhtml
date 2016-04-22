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

    <!--Operator Interest List-->
    <Table Class="table">
        <tr>
            <th>
                Interest
            </th>            
            <th>@Html.ActionLink("Create", "CreateInterest")</th>
        </tr>

        @For Each item In Model.operatorInterest

            @<tr >                
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Interest)
                </td>
                <td>

                    @Html.ActionLink("Edit", "EditInterest", New With {.id = item.Id})
                </td>
            </tr>
        Next

    </Table>

    <!--Operator Mode List-->
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



    <!--Operator StopCode List-->
    <Table Class="table">
        <tr>
            <th>
                StopCode
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



    <!--Operator Type List-->
    <Table Class="table">
        <tr>
            <th>
                Operator Type
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


    <!--Properties List-->
    <Table Class="table">
        <tr>
            <th>
                Name
            </th>
            <th></th>
        </tr>

        @For Each item In Model.properties

            @<tr>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Name)
                </td>
                <td>

                    @Html.ActionLink("Edit", "Edit", New With {.id = item.ID})
                </td>
            </tr>
        Next

    </Table>


    <!--Tired Commission List-->
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



</body>

</html>