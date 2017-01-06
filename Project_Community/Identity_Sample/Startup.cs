using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Project_Main.Startup))]
namespace Project_Main
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
