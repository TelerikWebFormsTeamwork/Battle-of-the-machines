namespace BattleOfTheMachines.WebForms.Controls
{
    using System;
    using System.Linq;

    using BattleOfTheMachines.Data;
    using BattleOfTheMachines.Data.Models;
    using BattleOfTheMachines.Data.Repositories;

    using Microsoft.AspNet.Identity;

    public partial class BuyItemHelper : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string ItemId { get; set; }

        public string ItemType { get; set; }

        protected void BuyItem(object sender, EventArgs e)
        {
            
        }
    }
}