namespace BattleOfTheMachines.WebForms.Controls
{
    using Data;
    using Helpers;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Linq;

    public partial class MachineView : System.Web.UI.UserControl
    {
        public bool HasMachine { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var db = new BattleOfTheMachinesDbContext();
            var machine = db.Machines.ToList().FirstOrDefault(x => x.OwnerId == Context.User.Identity.GetUserId());

            this.HasMachine = false;

            if (machine != null)
            {
                this.HasMachine = true;

                this.machineName.InnerText = machine.Name;

                this.processorModel.InnerHtml = $"{machine.Processor.Model}";
                this.ramModel.InnerHtml = $"{machine.Ram.Model}";
                this.networkModel.InnerHtml = $"{machine.Network.Type}";
                this.graphicsModel.InnerHtml = $"{machine.GraphicsCard.Model}";

                this.processorPh.InnerHtml = $"{machine.Processor.Power}";
                this.ramPh.InnerHtml = $"{machine.Ram.Power}"; ;
                this.networkPh.InnerHtml = $"{machine.Network.Power}";
                this.graphicsPh.InnerHtml = $"{machine.GraphicsCard.Power}";

                this.processor.ImageUrl = ImageHelper.GetComponentUrl(machine.Processor.Image);
                this.network.ImageUrl = ImageHelper.GetComponentUrl(machine.Network.Image);
                this.ram.ImageUrl = ImageHelper.GetComponentUrl(machine.Ram.Image);
                this.graphics.ImageUrl = ImageHelper.GetComponentUrl(machine.GraphicsCard.Image);
            }
        }
    }
}