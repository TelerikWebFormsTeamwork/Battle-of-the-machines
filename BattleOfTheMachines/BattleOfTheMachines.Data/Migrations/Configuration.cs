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

            if (!context.Users.Where(u => u.UserName == "admin@admin.com").Any())
            {
                var admin = new User
                {
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com",
                    PasswordHash = "AJ6xY/N9kWRShbJYh8QE5fIt5Yg5IeyTFBnJ9RXAdIXUo9hiqxtVWRiYJ0XyUHVDbg==",
                    SecurityStamp = "59bcf0ca-0367-4397-b3c1-af413e479e0c",
                    LockoutEnabled = true,
                };

                context.Users.Add(admin);

                var role = context.Roles.Where(r => r.Name == "Admin").FirstOrDefault();
                var adminRole = new IdentityUserRole
                {
                    RoleId = role.Id
                };

                admin.Roles.Add(adminRole);            
                context.SaveChanges();
            }

            if (!context.GraphicsCards.Any())
            {
                var graphicsImageBytes = File.ReadAllBytes(this.MapPath("~/Images/graphics_default.png"));
                var card = new GraphicsCard()
                               {
                                   Cores = 1,
                                   CoreSpeed = 0,
                                   Image = graphicsImageBytes,
                                   Model = "6502",
                                   VideoMemory = 1
                               };
                context.GraphicsCards.Add(card);
                context.SaveChanges();
            }

            if (!context.Processors.Any())
            {
                var processorImageBytes = File.ReadAllBytes(this.MapPath("~/Images/processor_default.png"));
                context.Processors.Add(
                    new Cpu() { Cores = 1, CoreSpeed = 1, Image = processorImageBytes, Model = "6502" });
                context.SaveChanges();
            }

            if (!context.Networks.Any())
            {
                var networkImageBytes = File.ReadAllBytes(this.MapPath("~/Images/network_default.png"));
                context.Networks.Add(new Network() { Image = networkImageBytes, Speed = 1, Type = "Dial-up" });
                context.SaveChanges();
            }

            if (!context.Rams.Any())
            {
                var memoryImageBytes = File.ReadAllBytes(this.MapPath("~/Images/memory_default.png"));
                context.Rams.Add(new Ram() { Image = memoryImageBytes, Memory = 1, MemorySpeed = 1, Model = "Ancient" });
                context.SaveChanges();
            }
        }

        private string MapPath(string seedFile)
        {
            if (HttpContext.Current != null)
            {
                return HostingEnvironment.MapPath(seedFile);
            }

            var absolutePath = new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath;
            var directoryName = Path.GetDirectoryName(absolutePath);
            var path = Path.Combine(directoryName, ".." + seedFile.TrimStart('~').Replace('/', '\\'));

            return path;
        }
    }
}
