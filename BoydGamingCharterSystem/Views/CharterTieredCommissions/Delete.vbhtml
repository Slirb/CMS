﻿@ModelType BoydGamingCharterSystem.CharterTieredCommissions

@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Delete</title>
</head>
<body>
    <h3>Are you sure you want to delete this?</h3>
    <div>
        <h4>CharterTieredCommissions</h4>
        <hr />
        <dl class="dl-horizontal">
            <dt>
                @Html.DisplayNameFor(Function(model) model.Name)
            </dt>
    
            <dd>
                @Html.DisplayFor(Function(model) model.Name)
            </dd>
    
            <dt>
                @Html.DisplayNameFor(Function(model) model.Description)
            </dt>
    
            <dd>
                @Html.DisplayFor(Function(model) model.Description)
            </dd>
    
            <dt>
                @Html.DisplayNameFor(Function(model) model.Minimum)
            </dt>
    
            <dd>
                @Html.DisplayFor(Function(model) model.Minimum)
            </dd>
    
            <dt>
                @Html.DisplayNameFor(Function(model) model.Maximum)
            </dt>
    
            <dd>
                @Html.DisplayFor(Function(model) model.Maximum)
            </dd>
    
            <dt>
                @Html.DisplayNameFor(Function(model) model.Value)
            </dt>
    
            <dd>
                @Html.DisplayFor(Function(model) model.Value)
            </dd>
    
        </dl>
        @Using (Html.BeginForm())
            @Html.AntiForgeryToken()
    
            @<div class="form-actions no-color">
                <input type="submit" value="Delete" class="btn btn-default" /> |
                @Html.ActionLink("Back to List", "Index")
            </div>
        End Using
    </div>
</body>
</html>