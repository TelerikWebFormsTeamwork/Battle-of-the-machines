namespace BattleOfTheMachines.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System.Data.Entity;

    public class BattleOfTheMachinesDbContext : IdentityDbContext<User>
    {
        public BattleOfTheMachinesDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Quest> Quests { get; set; }

        public static BattleOfTheMachinesDbContext Create()
        {
            return new BattleOfTheMachinesDbContext();
        }
    }
}
