using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(newmvc.Startup))]
namespace newmvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
