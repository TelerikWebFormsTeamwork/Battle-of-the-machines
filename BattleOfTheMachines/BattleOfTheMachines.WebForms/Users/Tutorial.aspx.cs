namespace BattleOfTheMachines.WebForms.Users
{
    using System;
    using System.Linq;

    using BattleOfTheMachines.Data;
    using BattleOfTheMachines.Data.Models;

    using Microsoft.AspNet.Identity;

    public partial class Tutorial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void OnClick(object sender, EventArgs e)
        {
            var db = new BattleOfTheMachinesDbContext();
            var machineName = this.MachineName.Text;
            var graphicsCard = db.GraphicsCards.ToList().OrderBy(x => x.Power).First();
            var network = db.Networks.ToList().OrderBy(x => x.Power).First();
            var processor = db.Processors.ToList().OrderBy(x => x.Power).First();
            var ram = db.Rams.ToList().OrderBy(x => x.Power).First();
            var owner = this.User.Identity.GetUserId();

            var machine = new Motherboard
                              {
                                  Name = machineName,
                                  GraphicsCard = graphicsCard,
                                  Network = network,
                                  Processor = processor,
                                  Ram = ram,
                                  OwnerId = owner
                              };

            db.Machines.Add(machine);
            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}