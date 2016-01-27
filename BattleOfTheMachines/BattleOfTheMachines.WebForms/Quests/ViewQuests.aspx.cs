namespace BattleOfTheMachines.WebForms.Quests
{
    using System;
    using System.Linq;
    using System.Web.UI.WebControls;
    using BattleOfTheMachines.Services.Data.Contracts;
    using Data.Models;
    using Data.Models.Enums;
    using Microsoft.AspNet.Identity;
    using Ninject;
    using Data;
    public partial class ViewQuests : System.Web.UI.Page
    {
        private const string TimerText = "You are busy.<br />Your quest will end on: ";
        private const string RewardText = "You have completed a task";

        [Inject]
        public IQuestsService Quests { get; set; }

        [Inject]
        public IMotherboardService Motherboards { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var db = new BattleOfTheMachinesDbContext();
            var machine = db.Machines.ToList().FirstOrDefault(x => x.OwnerId == Context.User.Identity.GetUserId());

            if (machine == null)
            {
                Response.Redirect("~/Users/Tutorial");
            }
            else
            {

                var userId = this.User.Identity.GetUserId();

                var timer = this.Motherboards.GetQuestTimerById(userId);// - DateTime.Now;

                // Get on quest view
                if (timer > DateTime.Now && !IsPostBack)
                {
                    this.TimerLabel.Text = TimerText + timer.ToString();
                    this.TimerImage.Visible = true;

                    DisableQuestButtons();
                }

                // Get reward view
                if (timer != null && timer < DateTime.Now)
                {
                    this.TimerLabel.Text = RewardText;
                    this.QuestRewardButton.Visible = true;

                    DisableQuestButtons();
                }

                if (timer == null)
                {
                    EnableQuestButtons();
                }

            }
        }

        public IQueryable<Quest> processorsQuestGrid_GetData()
        {
            return this.Quests.GetQuestsOfType(PartType.Cpu).OrderBy(x => x.PowerRequired);
        }

        public IQueryable<Quest> ramQuestGrid_GetData()
        {
            return this.Quests.GetQuestsOfType(PartType.Ram).OrderBy(x => x.PowerRequired);
        }

        public IQueryable<Quest> graphicsCardQuestGrid_GetData()
        {
            return this.Quests.GetQuestsOfType(PartType.GraphicsCard).OrderBy(x => x.PowerRequired);
        }

        public IQueryable<Quest> networkQuestGrid_GetData()
        {
            return this.Quests.GetQuestsOfType(PartType.Network).OrderBy(x => x.PowerRequired);
        }

        protected void TabCommand(object sender, CommandEventArgs e)
        {
            var tabIndex = int.Parse(e.CommandArgument.ToString());
            this.Multiview1.ActiveViewIndex = tabIndex;
        }

        void networkQuestGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "q")
            {
                var l = e;
            }
        }

        protected void processorsQuestGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var index = Convert.ToInt32(e.CommandArgument);

            var selectedRow = this.processorsQuestGrid.Rows[index];
            var questName = (selectedRow.Cells[0].Controls[0].Controls[0].Controls[0] as Literal).Text;

            this.Quests.StartQuest(questName, this.User.Identity.GetUserId());

            Response.Redirect(Request.RawUrl, false);
        }

        protected void ramQuestGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var index = Convert.ToInt32(e.CommandArgument);

            var selectedRow = this.ramQuestGrid.Rows[index];
            var questName = (selectedRow.Cells[0].Controls[0].Controls[0].Controls[0] as Literal).Text;

            this.Quests.StartQuest(questName, this.User.Identity.GetUserId());

            Response.Redirect(Request.RawUrl, false);
        }

        protected void graphicsCardQuestGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var index = Convert.ToInt32(e.CommandArgument);

            var selectedRow = this.graphicsCardQuestGrid.Rows[index];
            var questName = (selectedRow.Cells[0].Controls[0].Controls[0].Controls[0] as Literal).Text;

            this.Quests.StartQuest(questName, this.User.Identity.GetUserId());

            Response.Redirect(Request.RawUrl, false);
        }

        protected void networkQuestGrid_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            var index = Convert.ToInt32(e.CommandArgument);

            var selectedRow = this.networkQuestGrid.Rows[index];
            var questName = (selectedRow.Cells[0].Controls[0].Controls[0].Controls[0] as Literal).Text;

            this.Quests.StartQuest(questName, this.User.Identity.GetUserId());

            Response.Redirect(Request.RawUrl, false);
        }

        protected void QuestRewardButton_Click(object sender, EventArgs e)
        {
            this.Quests.FinishQuest(this.User.Identity.GetUserId());

            Response.Redirect(Request.RawUrl, false);
        }

        protected void QuestTimer_Tick(object sender, EventArgs e)
        {

            var userId = this.User.Identity.GetUserId();

            var timer = this.Motherboards.GetQuestTimerById(userId);

            if (timer > DateTime.Now && !IsPostBack)
            {
                this.TimerLabel.Text = TimerText + timer.ToString();
                this.TimerImage.Visible = true;

            }

            if (timer != null && timer < DateTime.Now)
            {
                this.TimerLabel.Text = RewardText;
                this.QuestRewardButton.Visible = true;
            }
        }

        private void EnableQuestButtons()
        {
            this.processorsQuestGrid.Columns[4].Visible = true;
            this.ramQuestGrid.Columns[4].Visible = true;
            this.networkQuestGrid.Columns[4].Visible = true;
            this.graphicsCardQuestGrid.Columns[4].Visible = true;
        }

        private void DisableQuestButtons()
        {
            this.processorsQuestGrid.Columns[4].Visible = false;
            this.ramQuestGrid.Columns[4].Visible = false;
            this.networkQuestGrid.Columns[4].Visible = false;
            this.graphicsCardQuestGrid.Columns[4].Visible = false;
        }
    }
}