﻿using System;
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
        public void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            DatabaseConfig.Initialize();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            Exception lastError = application.Server.GetLastError();
            HttpException ex = lastError as HttpException;
            string fourOhFourPage = "~/Errors/Oops.aspx";
            // Only response to 404 errors
            if (ex != null && ex.GetHttpCode() == 404)
            {
                // Clear the error in order to avoid standard handling of the error.
                application.Server.ClearError();
                application.Context.Handler =
                      System.Web.UI.PageParser.GetCompiledPageInstance(fourOhFourPage,
                      application.Server.MapPath(fourOhFourPage), application.Context);
            }
        }
    }
}