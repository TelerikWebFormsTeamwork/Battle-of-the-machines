using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BattleOfTheMachines.WebForms.Admin
{
    public partial class DropdownMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public string UnitId { get; set; }

        public string UnitType { get; set; }
    }
}