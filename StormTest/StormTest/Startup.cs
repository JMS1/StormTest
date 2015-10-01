using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StormTest.Startup))]
namespace StormTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
