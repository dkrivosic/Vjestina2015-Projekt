using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vjestina2015_Projekt.Startup))]
namespace Vjestina2015_Projekt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
