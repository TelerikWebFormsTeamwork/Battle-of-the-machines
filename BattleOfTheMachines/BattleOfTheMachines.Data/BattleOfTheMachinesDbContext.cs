namespace BattleOfTheMachines.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class BattleOfTheMachinesDbContext : IdentityDbContext<User>
    {
        public BattleOfTheMachinesDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static BattleOfTheMachinesDbContext Create()
        {
            return new BattleOfTheMachinesDbContext();
        }
    }
}
