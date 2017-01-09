using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Identity_Sample.Startup))]
namespace Identity_Sample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }
    }
}
