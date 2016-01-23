using BattleOfTheMachines.Services.Data.Contracts;
using Ninject;
using System;

namespace BattleOfTheMachines.WebForms.Admin
{
    public partial class Test : System.Web.UI.Page
    {
        [Inject]
        public ITestsService TestsService { get; set; }

        protected void AddTest_Click(object sender, EventArgs e)
        {
            this.TestsService.Add("Hi");
        }
    }
}