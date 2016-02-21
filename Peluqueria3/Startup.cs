using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Peluqueria3.Startup))]
namespace Peluqueria3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
