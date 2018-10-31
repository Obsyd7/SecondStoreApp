using Microsoft.Owin;
using Owin;
using SecondStoreApp;

[assembly: OwinStartup(typeof(Startup))]
namespace SecondStoreApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}