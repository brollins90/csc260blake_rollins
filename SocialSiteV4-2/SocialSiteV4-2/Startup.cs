using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SocialSiteV4_2.Startup))]
namespace SocialSiteV4_2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
