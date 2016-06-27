using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestIdentitySystem.Startup))]
namespace TestIdentitySystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
