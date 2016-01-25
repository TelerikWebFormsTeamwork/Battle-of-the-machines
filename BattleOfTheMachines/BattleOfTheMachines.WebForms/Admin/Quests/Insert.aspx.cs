namespace BattleOfTheMachines.WebForms.Admin.Quests
{
    using Data.Models.Enums;
    using Ninject;
    using Services.Data.Contracts;
    using System;

    public partial class Insert : System.Web.UI.Page
    {
        [Inject]
        public IQuestsService Quests { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                partType.DataSource = Enum.GetNames(typeof(PartType));
                partType.DataBind();
            }
        }

        protected void AddQuest_Click(object sender, System.EventArgs e)
        {
            PartType selectedPartType = (PartType)Enum.Parse(typeof(PartType), partType.SelectedValue);
            if (questImage.HasFile)
            {
                if (questImage.PostedFile.ContentType == "image/jpeg" 
                    || questImage.PostedFile.ContentType == "image/png")
                {
                    if (questImage.PostedFile.ContentLength < 3 * 102400)
                    {
                        this.Quests.Add(name.Text, description.InnerText, float.Parse(duration.Value), questImage.FileBytes, selectedPartType);
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
                this.Quests.Add(name.Text, description.InnerText, float.Parse(duration.Value), null, selectedPartType);
                Server.Transfer("../Default.aspx", true);
            }
        }
    }
}