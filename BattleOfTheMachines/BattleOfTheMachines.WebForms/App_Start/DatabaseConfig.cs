namespace BattleOfTheMachines.WebForms.App_Start
{
    using BattleOfTheMachines.Data;
    using System.Data.Entity;
    using BattleOfTheMachines.Data.Migrations;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BattleOfTheMachinesDbContext, Configuration>());
            BattleOfTheMachinesDbContext.Create().Database.Initialize(true);
        }
    }
}