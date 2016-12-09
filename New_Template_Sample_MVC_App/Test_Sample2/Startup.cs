using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Test_Sample2.Startup))]
namespace Test_Sample2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
