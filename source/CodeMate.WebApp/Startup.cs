using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CodeMate.WebApp.Startup))]
namespace CodeMate.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
