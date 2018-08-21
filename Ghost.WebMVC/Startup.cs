using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ghost.WebMVC.Startup))]
namespace Ghost.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
