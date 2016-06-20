using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ISOWebApps.Startup))]
namespace ISOWebApps
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
