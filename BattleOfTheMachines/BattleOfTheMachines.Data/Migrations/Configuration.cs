namespace BattleOfTheMachines.Data.Migrations
{
    using System.Linq;
    using System.Data.Entity.Migrations;

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
        }
    }
}
