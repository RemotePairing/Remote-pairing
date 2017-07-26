using CodeMate.WebApp;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace CodeMate.WebApp
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}