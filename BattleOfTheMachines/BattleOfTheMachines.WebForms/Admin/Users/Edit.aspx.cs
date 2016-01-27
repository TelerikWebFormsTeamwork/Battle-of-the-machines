namespace BattleOfTheMachines.WebForms.Admin.Users
{
    using System;
    using System.Web.UI.WebControls;
    using Microsoft.AspNet.FriendlyUrls.ModelBinding;
    using System.Linq;
    using Data.Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public partial class Edit : System.Web.UI.Page
    {
        protected BattleOfTheMachines.Data.BattleOfTheMachinesDbContext _db = new BattleOfTheMachines.Data.BattleOfTheMachinesDbContext();
        private string userId;
        private User user;

        protected void Page_Load(object sender, EventArgs e)
        {
            userId = Request.Url.Segments[4];
            user = _db.Users.Where(u => u.Id == userId).FirstOrDefault();

            if (user.Roles.Count > 0)
            {
                MakeAdminButton.CssClass = "hidden";
            }
            else
            {
                RemoveAdminButton.CssClass = "hidden";
            }
        }

        // This is the Update methd to update the selected User item
        // USAGE: <asp:FormView UpdateMethod="UpdateItem">
        public void UpdateItem(string Id)
        {
            using (_db)
            {
                var item = _db.Users.Find(Id);

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

        // This is the Select method to selects a single User item with the id
        // USAGE: <asp:FormView SelectMethod="GetItem">
        public BattleOfTheMachines.Data.Models.User GetItem([FriendlyUrlSegmentsAttribute(0)]string Id)
        {
            if (Id == null)
            {
                return null;
            }

            using (_db)
            {
                return _db.Users.Find(Id);
            }
        }

        protected void ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Cancel", StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("../Default");
            }
        }

        protected void MakeAdminButton_Click(object sender, EventArgs e)
        {
            var adminRole = _db.Roles.Where(r => r.Name == "Admin").FirstOrDefault();
            user.Roles.Add(new IdentityUserRole
            {
                RoleId = adminRole.Id
            });
            _db.SaveChanges();
            Response.Redirect("../Default");
        }

        protected void RemoveAdminButton_Click(object sender, EventArgs e)
        {
            user.Roles.Clear();
            _db.SaveChanges();
            Response.Redirect("../Default");
        }
    }
}
