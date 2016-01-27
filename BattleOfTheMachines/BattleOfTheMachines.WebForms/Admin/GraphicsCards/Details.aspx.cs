namespace BattleOfTheMachines.WebForms.Admin.GraphicsCards
{
    using System;
    using System.Linq;
    using System.Web.UI.WebControls;
    using Microsoft.AspNet.FriendlyUrls.ModelBinding;
    using Helpers;
    public partial class Details : System.Web.UI.Page
    {
		protected BattleOfTheMachines.Data.BattleOfTheMachinesDbContext _db = new BattleOfTheMachines.Data.BattleOfTheMachinesDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // This is the Select methd to selects a single GraphicsCard item with the id
        // USAGE: <asp:FormView SelectMethod="GetItem">
        public BattleOfTheMachines.Data.Models.GraphicsCard GetItem([FriendlyUrlSegmentsAttribute(0)]string Id)
        {
            if (Id == null)
            {
                return null;
            }

            using (_db)
            {
                var model = _db.GraphicsCards.Where(m => m.Id == Id.ToString()).FirstOrDefault();
                this.image.ImageUrl = ImageHelper.GetComponentUrl(model.Image);
                return model;
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

