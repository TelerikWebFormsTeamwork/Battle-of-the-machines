using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using Microsoft.AspNet.FriendlyUrls.ModelBinding;
using BattleOfTheMachines.Data.Models;
using BattleOfTheMachines.Data;
namespace BattleOfTheMachines.WebForms.Admin.GraphicsCards
{
    public partial class Edit : System.Web.UI.Page
    {
		protected BattleOfTheMachines.Data.BattleOfTheMachinesDbContext _db = new BattleOfTheMachines.Data.BattleOfTheMachinesDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // This is the Update methd to update the selected GraphicsCard item
        // USAGE: <asp:FormView UpdateMethod="UpdateItem">
        public void UpdateItem(string Id)
        {
            using (_db)
            {
                var item = _db.GraphicsCards.Find(Id);

                if (item == null)
                {
                    // The item wasn't found
                    ModelState.AddModelError("", String.Format("Item with id {0} was not found", Id));
                    return;
                }

                TryUpdateModel(item);

                if (ModelState.IsValid)
                {
                    // Save changes here
                    _db.SaveChanges();
                    Response.Redirect("../Default");
                }
            }
        }

        // This is the Select method to selects a single GraphicsCard item with the id
        // USAGE: <asp:FormView SelectMethod="GetItem">
        public BattleOfTheMachines.Data.Models.GraphicsCard GetItem([FriendlyUrlSegmentsAttribute(0)]string Id)
        {
            if (Id == null)
            {
                return null;
            }

            using (_db)
            {
                return _db.GraphicsCards.Find(Id);
            }
        }

        protected void ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Cancel", StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("../Default");
            }
        }
    }
}
