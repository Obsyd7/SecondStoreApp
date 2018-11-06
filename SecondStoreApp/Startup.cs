using Microsoft.Owin;
using Owin;
using SecondStoreApp;
using Hangfire;

[assembly: OwinStartup(typeof(Startup))]
namespace SecondStoreApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            GlobalConfiguration.Configuration.UseSqlServerStorage("StoreDbContext");

            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
}