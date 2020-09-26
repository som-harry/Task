using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HarryStoreApp.Startup))]
namespace HarryStoreApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
