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

        public virtual IDbSet<Test> Tests { get; set; }

        public virtual IDbSet<GraphicsCard> GraphicsCards { get; set; }

        public virtual IDbSet<Ram> Rams { get; set; }

        public virtual IDbSet<Network> Networks { get; set; }

        public virtual IDbSet<Cpu> Processors { get; set; }

        public virtual IDbSet<Motherboard> Machines { get; set; }

        public static BattleOfTheMachinesDbContext Create()
        {
            return new BattleOfTheMachinesDbContext();
        }
    }
}
