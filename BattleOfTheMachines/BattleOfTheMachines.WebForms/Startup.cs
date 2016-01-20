using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BattleOfTheMachines.WebForms.Startup))]
namespace BattleOfTheMachines.WebForms
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
