namespace CodHap.RemotePairing
{
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using Migrations;
    using Models;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            UpdateDatabaseMigrations();
        }

        private void UpdateDatabaseMigrations()
        {
            var config = new Configuration();
            var migrator = new DbMigrator(config);
            migrator.Update();
        }
    }
}