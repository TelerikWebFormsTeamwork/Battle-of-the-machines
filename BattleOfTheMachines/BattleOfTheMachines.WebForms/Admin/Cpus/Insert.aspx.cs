namespace BattleOfTheMachines.WebForms.Admin.Cpus
{
    using Ninject;
    using Services.Data.Contracts;
    using System;

    public partial class Insert : System.Web.UI.Page
    {
        [Inject]
        public ICpusService Cpus { get; set; }
        
        protected void AddCpu_Click(object sender, EventArgs e)
        {
            if (cpuImage.HasFile)
            {
                if (cpuImage.PostedFile.ContentType == "image/jpeg"
                    || cpuImage.PostedFile.ContentType == "image/png")
                {
                    if (cpuImage.PostedFile.ContentLength < 3 * 102400)
                    {
                        this.Cpus.Add(model.Text, float.Parse(coreSpeed.Value), ushort.Parse(cores.Value), cpuImage.FileBytes);
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
                this.Cpus.Add(model.Text, float.Parse(coreSpeed.Value), ushort.Parse(cores.Value), null);
                Server.Transfer("../Default.aspx", true);
            }
        }
    }
}