using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BattleOfTheMachines.WebForms
{
    using System.Collections;

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
                db.Machines.ToList()
                    .OrderByDescending(x => x.Processor.Power + x.GraphicsCard.Power + x.Network.Power + x.Ram.Power)
                    .Take(3);

            return machines.ToList();
        }
    }
}