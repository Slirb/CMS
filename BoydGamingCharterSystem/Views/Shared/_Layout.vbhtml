﻿<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title | Charter System</title>
    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/jqueryval")
    @Styles.Render("~/Content/themes/base/css")
    @Scripts.Render("~/bundles/modernizr")

    @Scripts.Render("~/bundles/bootstrap")
    @Scripts.Render("~/bundles/jqueryui")

    @Scripts.Render("~/bundles/site")
</head>
<body>
    

        <header class="mainHeader">
            <div class="container">
                        <div class="logo">
                            <img src="~/Content/Logo/Charter_Bus.png" />
                        </div>
    
                            <nav class="mainNav">
                    <ul>                    
                        <li>@Html.ActionLink("Trips", "Index", "CharterTrips", Nothing, New With {.class = "btn btn-link"})</li>
                        <li>@Html.ActionLink("Agreements", "Index", "CharterAgreements", Nothing, New With {.class = "btn btn-link"})</li>
                        <li>@Html.ActionLink("Operators", "Index", "CharterOperators", Nothing, New With {.class = "btn btn-link"})</li>
                        <li>@Html.ActionLink("Carriers", "Index", "CharterCarriers", Nothing, New With {.class = "btn btn-link"})</li>
                        <!--Hidden for presentation purposes-->
                        <!--<li>@Html.ActionLink("Reports", "Index", "CharterReports", Nothing, New With {.class = "btn btn-link"})</li>-->
                        <li>@Html.ActionLink("Administration", "Index", "Administration", Nothing, New With {.class = "btn btn-link"})</li>

                
                    </ul>
                </nav>
            </div>
        </header>
        <div class="container body-content">
            
            @RenderBody()
            


            
            
        </div>
        <footer>
            <div class="container">

                <!--Removed References to Client-->
                <p>&copy; @DateTime.Now.Year - Charter System</p>
            </div>
        </footer>

    

    
    @RenderSection("scripts", required:=False)
</body>
</html>
