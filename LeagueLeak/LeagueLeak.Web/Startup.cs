using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LeagueLeak.Web.Startup))]
namespace LeagueLeak.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
