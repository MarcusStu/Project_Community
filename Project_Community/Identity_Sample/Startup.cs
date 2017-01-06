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
        }
    }
}
