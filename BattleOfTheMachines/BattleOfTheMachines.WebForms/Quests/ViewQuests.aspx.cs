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

    public partial class ViewQuests: System.Web.UI.Page
    {
        [Inject]
        public IQuestsService Quests { get; set; }

        [Inject]
        public IMotherboardService Motherboards { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var userId = this.User.Identity.GetUserId();

            var timer = this.Motherboards.GetQuestTimerById(userId) - DateTime.Now;

            if (timer > TimeSpan.Zero && !IsPostBack)
            {
                this.TimerLabel.Text = timer.ToString();
            }

            if (timer <= TimeSpan.Zero)
            {

                this.QuestTimer.Dispose();
                this.TimerLabel.Text = string.Empty;
            }
        }

        protected void QuestTimer_Tick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.TimerLabel.Text))
            {
                this.QuestTimer.Dispose();
                return;
            }
            var timer = TimeSpan.Parse(this.TimerLabel.Text).Subtract(new TimeSpan(TimeSpan.TicksPerSecond));

            if (timer <= TimeSpan.Zero)
            {
                Server.Transfer(Request.RawUrl);
            }

            this.TimerLabel.Text = timer.ToString();
        }

        protected void TimerPanel_Load(object sender, EventArgs e)
        {
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
        }

        protected void ramQuestGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var index = Convert.ToInt32(e.CommandArgument);

            var selectedRow = this.ramQuestGrid.Rows[index];
            var questName = (selectedRow.Cells[0].Controls[0].Controls[0].Controls[0] as Literal).Text;

            this.Quests.StartQuest(questName, this.User.Identity.GetUserId());
        }

        protected void graphicsCardQuestGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var index = Convert.ToInt32(e.CommandArgument);

            var selectedRow = this.graphicsCardQuestGrid.Rows[index];
            var questName = (selectedRow.Cells[0].Controls[0].Controls[0].Controls[0] as Literal).Text;

            this.Quests.StartQuest(questName, this.User.Identity.GetUserId());
        }

        protected void networkQuestGrid_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            var index = Convert.ToInt32(e.CommandArgument);

            var selectedRow = this.networkQuestGrid.Rows[index];
            var questName = (selectedRow.Cells[0].Controls[0].Controls[0].Controls[0] as Literal).Text;

            this.Quests.StartQuest(questName, this.User.Identity.GetUserId());
        }
    }
}