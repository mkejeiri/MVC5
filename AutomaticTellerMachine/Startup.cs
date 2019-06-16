using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AutomaticTellerMachine.Startup))]
namespace AutomaticTellerMachine
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
