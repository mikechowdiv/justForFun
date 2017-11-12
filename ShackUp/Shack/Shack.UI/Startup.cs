using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Shack.UI.Startup))]
namespace Shack.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
