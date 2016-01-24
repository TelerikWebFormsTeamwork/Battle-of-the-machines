namespace BattleOfTheMachines.WebForms.Users
{
    using System;
    using System.Linq;

    using BattleOfTheMachines.Data;

    using Microsoft.AspNet.Identity;

    public partial class Machine : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var db = new BattleOfTheMachinesDbContext();

            var machine = db.Machines.ToList().First(x => x.OwnerId == this.User.Identity.GetUserId());
            this.processor.ImageUrl = this.GetComponentUrl(machine.Processor.Image);
            this.network.ImageUrl = this.GetComponentUrl(machine.Network.Image);
            this.ram.ImageUrl = this.GetComponentUrl(machine.Ram.Image);
            this.graphics.ImageUrl = this.GetComponentUrl(machine.GraphicsCard.Image);
        }

        private string GetComponentUrl(byte[] image)
        {
            return "data:image/jpeg;base64," + Convert.ToBase64String(image);
        }
    }
}