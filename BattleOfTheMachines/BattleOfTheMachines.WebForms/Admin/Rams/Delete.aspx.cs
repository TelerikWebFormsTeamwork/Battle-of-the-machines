﻿using System;
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

namespace BattleOfTheMachines.WebForms.Admin.Rams
{
    public partial class Delete : System.Web.UI.Page
    {
		protected BattleOfTheMachines.Data.BattleOfTheMachinesDbContext _db = new BattleOfTheMachines.Data.BattleOfTheMachinesDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // This is the Delete methd to delete the selected Ram item
        // USAGE: <asp:FormView DeleteMethod="DeleteItem">
        public void DeleteItem(Guid Id)
        {
            using (_db)
            {
                var item = _db.Rams.Find(Id);

                if (item != null)
                {
                    _db.Rams.Remove(item);
                    _db.SaveChanges();
                }
            }
            Response.Redirect("../Default");
        }

        // This is the Select methd to selects a single Ram item with the id
        // USAGE: <asp:FormView SelectMethod="GetItem">
        public BattleOfTheMachines.Data.Models.Ram GetItem([FriendlyUrlSegmentsAttribute(0)]Guid? Id)
        {
            if (Id == null)
            {
                return null;
            }

            using (_db)
            {
	            return _db.Rams.Where(m => m.Id == Id.ToString()).FirstOrDefault();
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

