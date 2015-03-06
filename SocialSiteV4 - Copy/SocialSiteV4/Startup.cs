using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SocialSiteV4.Startup))]
namespace SocialSiteV4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
