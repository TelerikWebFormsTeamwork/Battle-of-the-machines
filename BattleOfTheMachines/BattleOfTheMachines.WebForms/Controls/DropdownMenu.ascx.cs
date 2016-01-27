namespace BattleOfTheMachines.WebForms.Controls
{
    using System;

    public partial class DropdownMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public string UnitId { get; set; }

        public string UnitType { get; set; }
    }
}