using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BootstrapStyleDropdown.Startup))]
namespace BootstrapStyleDropdown
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
