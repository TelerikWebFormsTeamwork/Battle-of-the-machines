namespace BattleOfTheMachines.WebForms.Users
{
    using System;
    using System.Globalization;
    using System.Linq;

    using BattleOfTheMachines.Data;

    using Microsoft.AspNet.Identity;
    using Helpers;

    public partial class Machine : System.Web.UI.Page
    {
        protected bool HasMachine;

        protected void Page_Load(object sender, EventArgs e)
        {
            var db = new BattleOfTheMachinesDbContext();
            var machine = db.Machines.ToList().FirstOrDefault(x => x.OwnerId == this.User.Identity.GetUserId());

            this.HasMachine = false;

            if (machine != null)
            {
                this.HasMachine = true;

                this.machineName.InnerText = machine.Name;
                
            	this.processor.ImageUrl = ImageHelper.GetComponentUrl(machine.Processor.Image);
            	this.network.ImageUrl = ImageHelper.GetComponentUrl(machine.Network.Image);
            	this.ram.ImageUrl = ImageHelper.GetComponentUrl(machine.Ram.Image);
            	this.graphics.ImageUrl = ImageHelper.GetComponentUrl(machine.GraphicsCard.Image);

                this.processorPh.InnerHtml = $"{machine.Processor.Model} <br /> {machine.Processor.Power}";
                this.ramPh.InnerHtml = $"{machine.Ram.Model} <br /> {machine.Ram.Power}"; ;
                this.networkPh.InnerHtml = $"{machine.Network.Type} <br /> {machine.Network.Power}";
                this.graphicsPh.InnerHtml = $"{machine.GraphicsCard.Model} <br /> {machine.GraphicsCard.Power}";
            }
        }
    }
}