namespace BattleOfTheMachines.Data.Migrations
{
    using System;
    using System.Linq;
    using System.Data.Entity.Migrations;
    using System.Drawing;
    using System.IO;
    using System.Reflection;
    using System.Web;
    using System.Web.Hosting;

    using BattleOfTheMachines.Data.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public sealed class Configuration : DbMigrationsConfiguration<BattleOfTheMachines.Data.BattleOfTheMachinesDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BattleOfTheMachines.Data.BattleOfTheMachinesDbContext context)
        {
            if (!context.Roles.Any())
            {
                context.Roles.Add(new IdentityRole { Name = "Admin" });
                context.SaveChanges();
            }

            var b = Directory.GetCurrentDirectory();
            var absolutePath = new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath;
            var graphicsImage = File.ReadAllBytes(MapPath("~/Images/graphics_default.png"));
            var a = 5;
        }

        private string MapPath(string seedFile)
        {
            if (HttpContext.Current != null)
                return HostingEnvironment.MapPath(seedFile);

            var absolutePath = new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath;
            var directoryName = Path.GetDirectoryName(absolutePath);
            var path = Path.Combine(directoryName, ".." + seedFile.TrimStart('~').Replace('/', '\\'));

            return path;
        }
    }
}
