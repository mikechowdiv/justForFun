using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Shack1.UI.Startup))]
namespace Shack1.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
