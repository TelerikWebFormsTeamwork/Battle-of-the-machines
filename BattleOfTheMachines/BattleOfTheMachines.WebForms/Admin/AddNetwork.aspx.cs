namespace BattleOfTheMachines.WebForms.Admin
{
    using BattleOfTheMachines.Services.Data.Contracts;
    using Ninject;
    using System;

    public partial class AddNetwork : System.Web.UI.Page
    {

        [Inject]
        public INetworksService Networks { get; set; }

        protected void AddNetwork_Click(object sender, EventArgs e)
        {
            if (networkImage.HasFile)
            {
                if (networkImage.PostedFile.ContentType == "image/jpeg"
                    || networkImage.PostedFile.ContentType == "image/png")
                {
                    if (networkImage.PostedFile.ContentLength < 3 * 102400)
                    {
                        this.Networks.Add(type.Text, int.Parse(speed.Value), networkImage.FileBytes);
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
                this.Networks.Add(type.Text, int.Parse(speed.Value), networkImage.FileBytes);
                Server.Transfer("../Default.aspx", true);
            }
        }
    }
}