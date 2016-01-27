namespace BattleOfTheMachines.WebForms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.UI;

    using BattleOfTheMachines.Data;
    using BattleOfTheMachines.Data.Models;

    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<Motherboard> GetTopMachines()
        {
            var db = new BattleOfTheMachinesDbContext();
            var machines =
                db.Machines.ToList();
                return machines.OrderByDescending(x => x.Processor.Power + x.GraphicsCard.Power + x.Network.Power + x.Ram.Power)
                    .Take(Math.Min(machines.Count, 3));
        }
    }
}