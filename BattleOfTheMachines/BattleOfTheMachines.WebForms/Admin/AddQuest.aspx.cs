namespace BattleOfTheMachines.WebForms.Admin
{
    using Data.Models.Enums;
    using Ninject;
    using Services.Data.Contracts;
    using System;
    using System.Web.UI.WebControls;

    public partial class AddQuest : System.Web.UI.Page
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
            this.Quests.Add(name.Text, description.InnerText, float.Parse(duration.Value), null, selectedPartType);
        }
    }
}