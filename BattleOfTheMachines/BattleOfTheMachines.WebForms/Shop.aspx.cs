namespace BattleOfTheMachines.WebForms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using BattleOfTheMachines.Data;
    using BattleOfTheMachines.Data.Models;
    using BattleOfTheMachines.WebForms.Models;

    using Microsoft.AspNet.Identity;

    public partial class Shop : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var db = new BattleOfTheMachinesDbContext();
            var machine = db.Machines.ToList().FirstOrDefault(x => x.OwnerId == Context.User.Identity.GetUserId());           

            if (machine == null)
            {
                Response.Redirect("~/Users/Tutorial");
            }

            money.InnerText = machine.Currency.ToString();
        }

        public IQueryable<CpuViewModel> ProcessorsGrid_GetData(object sender, EventArgs e)
        {
            var db = new BattleOfTheMachinesDbContext();

            var userId = this.User.Identity.GetUserId();
            var machine = db.Machines.ToList().FirstOrDefault(x => x.OwnerId == userId);
            var machineCapital = machine.Currency;
            var currentPower = machine.Processor.Power;
            return
                db.Processors.ToList().Select(
                    x =>
                    new CpuViewModel()
                    {
                        Model = x.Model,
                        Id = x.Id,
                        CoreSpeed = x.CoreSpeed,
                        Cores = x.Cores,
                        Price = x.Power - currentPower,
                        CanBuy = (machineCapital - (x.Power - currentPower)) >= 0
                    }).AsQueryable();
        }

        public IQueryable<RamViewModel> RamsGrid_GetData()
        {
            var db = new BattleOfTheMachinesDbContext();

            var userId = this.User.Identity.GetUserId();
            var machine = db.Machines.ToList().FirstOrDefault(x => x.OwnerId == userId);
            var machineCapital = machine.Currency;
            var currentPower = machine.Ram.Power;
            
            return db.Rams.ToList().Select(
                    x =>
                    new RamViewModel()
                    {
                        Model = x.Model,
                        Id = x.Id,
                        Price = x.Power - currentPower,
                        CanBuy = (machineCapital - (x.Power - currentPower)) >= 0,
                        Memory = x.Memory,
                        MemorySpeed = x.MemorySpeed
                    }).AsQueryable();
        }

        public IQueryable<NetworkViewModel> NetworksGrid_GetData()
        {
            var db = new BattleOfTheMachinesDbContext();

            var userId = this.User.Identity.GetUserId();
            var machine = db.Machines.ToList().FirstOrDefault(x => x.OwnerId == userId);
            var machineCapital = machine.Currency;
            var currentPower = machine.Network.Power;

            return db.Networks.ToList().Select(
                    x =>
                    new NetworkViewModel()
                    {
                        Id = x.Id,
                        Type = x.Type,
                        Speed = x.Speed,
                        Price = x.Power - currentPower,
                        CanBuy = (machineCapital - (x.Power - currentPower)) >= 0
                    }).AsQueryable();
        }

        public IQueryable<GraphicsViewModel> GraphicsGrid_GetData()
        {
            var db = new BattleOfTheMachinesDbContext();

            var userId = this.User.Identity.GetUserId();
            var machine = db.Machines.ToList().FirstOrDefault(x => x.OwnerId == userId);
            var machineCapital = machine.Currency;
            var currentPower = machine.GraphicsCard.Power;
                var graphicsDb = db.GraphicsCards.ToList();
            var result = graphicsDb.Select(
                    x =>
                    new GraphicsViewModel()
                    {
                        Model = x.Model,
                        Id = x.Id,
                        CoreSpeed = x.CoreSpeed,
                        Cores = x.Cores,
                        Price = x.Power - currentPower,
                        CanBuy = (machineCapital - (x.Power - currentPower)) >= 0,
                        VideoMemory = x.VideoMemory
                    });

            return result.AsQueryable();
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
            var price = float.Parse(args[2]);

            if ((int)price > machine.Currency)
            {
                ErrorMessage.Text = "Nah... too pricey for ya'!";
            }
            else
            {

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
                
                try
                {
                    machine.Currency -= (int)price;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {

                }

                
                this.Response.Redirect("~/Users/Machine");
            }
        }
    }
}