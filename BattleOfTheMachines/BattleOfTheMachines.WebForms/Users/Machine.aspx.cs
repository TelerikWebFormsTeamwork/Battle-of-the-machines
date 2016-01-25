namespace BattleOfTheMachines.WebForms.Users
{
    using System;
    using System.Linq;

    using BattleOfTheMachines.Data;

    using Microsoft.AspNet.Identity;
    using Helpers;

    public partial class Machine : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var db = new BattleOfTheMachinesDbContext();

            var machine = db.Machines.ToList().First(x => x.OwnerId == this.User.Identity.GetUserId());
            this.processor.ImageUrl = ImageHelper.GetComponentUrl(machine.Processor.Image);
            this.network.ImageUrl = ImageHelper.GetComponentUrl(machine.Network.Image);
            this.ram.ImageUrl = ImageHelper.GetComponentUrl(machine.Ram.Image);
            this.graphics.ImageUrl = ImageHelper.GetComponentUrl(machine.GraphicsCard.Image);
        }
    }
}