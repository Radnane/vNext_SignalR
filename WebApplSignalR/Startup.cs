using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WebApplSignalR.Startup))]

namespace WebApplSignalR
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}