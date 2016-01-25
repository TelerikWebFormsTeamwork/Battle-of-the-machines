using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using BattleOfTheMachines.Data.Models;
using BattleOfTheMachines.Data;

namespace BattleOfTheMachines.WebForms.Admin.Quests
{
    public partial class Default : System.Web.UI.Page
    {
		protected BattleOfTheMachines.Data.BattleOfTheMachinesDbContext _db = new BattleOfTheMachines.Data.BattleOfTheMachinesDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // Model binding method to get List of Quest entries
        // USAGE: <asp:ListView SelectMethod="GetData">
        public IQueryable<BattleOfTheMachines.Data.Models.Quest> GetData()
        {
            return _db.Quests;
        }
    }
}

