Imports System.Web.Optimization

Public Module BundleConfig
    ' For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
    Public Sub RegisterBundles(ByVal bundles As BundleCollection)

        bundles.Add(New ScriptBundle("~/bundles/jquery").Include(
                    "~/Scripts/jquery-{version}.js"))



        bundles.Add(New ScriptBundle("~/bundles/jqueryval").Include(
                    "~/Scripts/jquery.validate*", "~/Scripts/jquery.unobtrusive*", "~/Scripts/jquery.ext*"))

        'Added jQueryUi
        bundles.Add(New ScriptBundle("~/bundles/jqueryui").Include(
            "~/Scripts/jquery-ui-{version}.js"))

        ' Use the development version of Modernizr to develop with and learn from. Then, when you're
        ' ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
        bundles.Add(New ScriptBundle("~/bundles/modernizr").Include(
                    "~/Scripts/modernizr-*"))
        bundles.Add(New ScriptBundle("~/bundles/site").Include("~/Scripts/site.js"))

        bundles.Add(New ScriptBundle("~/bundles/bootstrap").Include(
                  "~/Scripts/bootstrap.js",
                  "~/Scripts/respond.js"))

        bundles.Add(New StyleBundle("~/Content/css").Include(
                  "~/Content/bootstrap.css",
                  "~/Content/site.css"))

        'Added jQueryUi
        bundles.Add(New StyleBundle("~/Content/themes/base/css").Include(
              "~/Content/themes/base/accordion.css",
              "~/Content/themes/base/all.css",
              "~/Content/themes/base/autocomplete.css",
              "~/Content/themes/base/base.css",
              "~/Content/themes/base/button.css",
              "~/Content/themes/base/core.css",
              "~/Content/themes/base/datepicker.css",
              "~/Content/themes/base/dialog.css",
              "~/Content/themes/base/draggable.css",
              "~/Content/themes/base/menu.css",
              "~/Content/themes/base/progressbar.css",
              "~/Content/themes/base/resizable.css",
              "~/Content/themes/base/selectable.css",
              "~/Content/themes/base/selectmenu.css",
              "~/Content/themes/base/slider.css",
              "~/Content/themes/base/sortable.css",
              "~/Content/themes/base/spinner.css",
              "~/Content/themes/base/tabs.css",
              "~/Content/themes/base/theme.css",
              "~/Content/themes/base/tooltip.css"))

    End Sub
End Module

