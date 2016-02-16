<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title | Boyd Gaming Charter System</title>
    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")
</head>
<body>
    

        <header class="mainHeader">
            <div class="container">
                <div class="logo">
                    <img src="http://placehold.it/200x100" />
                </div>
                <nav class="mainNav">
                    <ul>
                    
                        <li>@Html.ActionLink("Trips", "Index", "Trip")</li>
                        <li>@Html.ActionLink("Charter Agreements", "Index", "CharterAgreement")</li>
                        <li>@Html.ActionLink("Operators", "Index", "Operator")</li>
                        <li>@Html.ActionLink("Carriers", "Index", "CharterCarriers")</li>
                        <li>@Html.ActionLink("Reports", "Index", "Report")</li>
                        <li>@Html.ActionLink("Administration", "Index", "Administration")</li>

                
                    </ul>
                </nav>
            </div>
        </header>
        <div class="container body-content">
            
            @RenderBody()
            


            
            
        </div>
        <footer>
            <div class="container">
                <p>&copy; @DateTime.Now.Year - Boyd Gaming Bus-Charter System</p>
            </div>
        </footer>

    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")
    @RenderSection("scripts", required:=False)
</body>
</html>
