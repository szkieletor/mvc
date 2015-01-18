using Microsoft.Owin;
using Owin;
using WebApplication4;

[assembly: OwinStartup(typeof(Startup))]
namespace WebApplication4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
