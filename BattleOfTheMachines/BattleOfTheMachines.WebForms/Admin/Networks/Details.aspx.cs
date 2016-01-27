namespace BattleOfTheMachines.WebForms.Admin.Networks
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

        // This is the Select methd to selects a single Network item with the id
        // USAGE: <asp:FormView SelectMethod="GetItem">
        public BattleOfTheMachines.Data.Models.Network GetItem([FriendlyUrlSegmentsAttribute(0)]string Id)
        {
            if (Id == null)
            {
                return null;
            }

            using (_db)
            {
	            var model = _db.Networks.Where(m => m.Id == Id.ToString()).FirstOrDefault();
                this.cpu_image.ImageUrl = ImageHelper.GetComponentUrl(model.Image);
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

