Imports System.Web.Optimization
Imports System.Data.Entity


Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Sub Application_Start()
        Dim charterSystem As New CharterSystem


        Database.SetInitializer(Of CharterSystem)(New CharterSystemInitializer())

        charterSystem.Database.Initialize(True)



        AreaRegistration.RegisterAllAreas()
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)




    End Sub
End Class
