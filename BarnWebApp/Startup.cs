using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BarnWebApp.Startup))]
namespace BarnWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
