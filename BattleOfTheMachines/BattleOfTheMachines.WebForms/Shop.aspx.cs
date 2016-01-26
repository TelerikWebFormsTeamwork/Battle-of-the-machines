namespace BattleOfTheMachines.WebForms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using BattleOfTheMachines.Data;
    using BattleOfTheMachines.Data.Models;

    public partial class Shop : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<Cpu> ProcessorsGrid_GetData(object sender, EventArgs e)
        {
            var db = new BattleOfTheMachinesDbContext();

            return db.Processors.AsQueryable();
        }

        public IQueryable<Ram> RamsGrid_GetData()
        {
            var db = new BattleOfTheMachinesDbContext();

            return db.Rams.AsQueryable();
        }

        public IQueryable<Network> NetworksGrid_GetData()
        {
            var db = new BattleOfTheMachinesDbContext();

            return db.Networks.AsQueryable();
        }

        public IQueryable<GraphicsCard> GraphicsGrid_GetData()
        {
            var db = new BattleOfTheMachinesDbContext();

            return db.GraphicsCards.AsQueryable();
        }

        protected void TabCommand(object sender, CommandEventArgs e)
        {
            var tabIndex = int.Parse(e.CommandArgument.ToString());
            this.Multiview1.ActiveViewIndex = tabIndex;
        }
    }
}