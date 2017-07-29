using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MusicService.Startup))]
namespace MusicService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
