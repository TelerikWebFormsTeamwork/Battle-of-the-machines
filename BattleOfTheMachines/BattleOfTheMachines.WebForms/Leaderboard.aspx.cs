using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BattleOfTheMachines.WebForms
{
    using BattleOfTheMachines.Data;
    using BattleOfTheMachines.Data.Models;
    using BattleOfTheMachines.Data.Models.ViewModels;

    public partial class Leaderboard : System.Web.UI.Page
    {
        private BattleOfTheMachinesDbContext db = BattleOfTheMachinesDbContext.Create();

        public IQueryable<Leader> Leaderboard_GetData()
        {
            return this.db.Machines.ToList().Select(
                x =>
                new Leader()
                    {
                        Name = x.Name,
                        Power = x.Processor.Power + x.Network.Power + x.Ram.Power + x.GraphicsCard.Power
                    }).AsQueryable();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}