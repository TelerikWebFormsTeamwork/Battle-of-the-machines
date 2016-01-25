namespace BattleOfTheMachines.WebForms.Admin.Rams
{
    using Ninject;
    using Services.Data.Contracts;
    using System;

    public partial class Insert : System.Web.UI.Page
    {
        [Inject]
        public IRamsService Rams { get; set; }

        protected void AddRam_Click(object sender, EventArgs e)
        {
            if (ramImage.HasFile)
            {
                if (ramImage.PostedFile.ContentType == "image/jpeg"
                    || ramImage.PostedFile.ContentType == "image/png")
                {
                    if (ramImage.PostedFile.ContentLength < 3 * 102400)
                    {
                        this.Rams.Add(model.Text, float.Parse(memorySpeed.Value), ramImage.FileBytes, int.Parse(memory.Value));
                        Server.Transfer("../Default.aspx", true);
                    }
                    else
                    {
                        ErrorMessage.Text = "Image must be less than 3 MB.";
                    }
                }
                else
                {
                    ErrorMessage.Text = "Invalid image type.";
                }
            }
            else
            {
                this.Rams.Add(model.Text, float.Parse(memorySpeed.Value), null, int.Parse(memory.Value));
                Server.Transfer("../Default.aspx", true);
            }
        }
    }
}