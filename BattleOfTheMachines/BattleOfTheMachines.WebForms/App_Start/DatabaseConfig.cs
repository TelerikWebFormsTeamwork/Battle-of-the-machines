namespace BattleOfTheMachines.WebForms.App_Start
{
    using System;

    using BattleOfTheMachines.Data;
    using System.Data.Entity;
    using BattleOfTheMachines.Data.Migrations;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BattleOfTheMachinesDbContext, Configuration>());
            try
            {
                BattleOfTheMachinesDbContext.Create().Database.Initialize(true);
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}