namespace BattleOfTheMachines.WebForms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using BattleOfTheMachines.Data;
    using BattleOfTheMachines.Data.Models;

    using Microsoft.AspNet.Identity;

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

        protected void ProcessorsGrid_GetDataSource(object sender, CreatingModelDataSourceEventArgs e)
        {
            this.processorsGrid.DataSource = ProcessorsGrid_GetData(null, null);
            this.processorsGrid.DataBind();
        }

        protected string getid()
        {
            return User.Identity.GetUserId();
        }

        protected void BuyCommand(object sender, CommandEventArgs e)
        {
            var db = new BattleOfTheMachinesDbContext();
            var machine = db.Machines.ToList().First(x => x.OwnerId == Context.User.Identity.GetUserId());

            var args = e.CommandArgument.ToString().Split('%').ToArray();
            var type = args[0];
            var id = args[1];

            switch (type)
            {
                case "Processor":
                    machine.ProcessorId = id;
                    break;
                case "Ram":
                    machine.RamId = id;
                    break;
                case "Network":
                    machine.NetworkId = id;
                    break;
                case "Graphics":
                    machine.GraphicsCardId = id;
                    break;
                default:
                    throw new ArgumentException("Invalid type to buy");
            }

            db.SaveChanges();
        }
    }
}