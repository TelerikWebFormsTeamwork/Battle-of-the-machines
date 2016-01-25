using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace BattleOfTheMachines.WebForms
{
    using System.Configuration;
    using System.Data.Entity;

    using BattleOfTheMachines.Data;
    using BattleOfTheMachines.WebForms.App_Start;

    using Configuration = BattleOfTheMachines.Data.Migrations.Configuration;

    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            DatabaseConfig.Initialize();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}