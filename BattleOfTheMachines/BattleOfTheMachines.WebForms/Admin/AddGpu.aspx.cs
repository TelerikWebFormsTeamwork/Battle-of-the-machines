namespace BattleOfTheMachines.WebForms.Admin
{
    using BattleOfTheMachines.Services.Data.Contracts;
    using Ninject;
    using System;

    public partial class AddGpu : System.Web.UI.Page
    {
        [Inject]
        public IGpusService Gpus { get; set; }

        protected void AddGpu_Click(object sender, EventArgs e)
        {
            if (gpuImage.HasFile)
            {
                if (gpuImage.PostedFile.ContentType == "image/jpeg"
                    || gpuImage.PostedFile.ContentType == "image/png")
                {
                    if (gpuImage.PostedFile.ContentLength < 3 * 102400)
                    {
                        this.Gpus.Add(model.Text, float.Parse(coreSpeed.Value), ushort.Parse(cores.Value), gpuImage.FileBytes, int.Parse(vRAM.Value));
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
                this.Gpus.Add(model.Text, float.Parse(coreSpeed.Value), ushort.Parse(cores.Value), null, int.Parse(vRAM.Value));
                Server.Transfer("../Default.aspx", true);
            }
        }
    }
}