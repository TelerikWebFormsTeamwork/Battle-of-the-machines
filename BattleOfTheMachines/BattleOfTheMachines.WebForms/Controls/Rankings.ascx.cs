namespace BattleOfTheMachines.WebForms.Controls
{
    using BattleOfTheMachines.Data;
    using BattleOfTheMachines.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.UI.WebControls;

    public partial class Rankings : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<Motherboard> GetTopMachines()
        {
            var db = new BattleOfTheMachinesDbContext();
            var machines =
                db.Machines.ToList()
                    .OrderByDescending(x => x.Processor.Power + x.GraphicsCard.Power + x.Network.Power + x.Ram.Power)
                    .Take(3);

            return machines.ToList();
        }
    }
}