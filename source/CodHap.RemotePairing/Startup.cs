using CodHap.RemotePairing;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace CodHap.RemotePairing
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