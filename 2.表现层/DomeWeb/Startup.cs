using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DomeWeb.Startup))]
namespace DomeWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
