﻿namespace BattleOfTheMachines.WebForms
{
    using BattleOfTheMachines.WebForms.App_Start;
    using System;
    using System.Web;
    using System.Web.Optimization;
    using System.Web.Routing;

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