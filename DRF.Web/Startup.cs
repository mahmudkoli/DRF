using System;
using System.Threading.Tasks;
using DRF.Web.Hubs;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(DRF.Web.Startup))]

namespace DRF.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalHost.HubPipeline.AddModule(new NotificationHubPipelineModule());
            var hubConfiguration = new HubConfiguration { EnableDetailedErrors = true };
            app.MapSignalR(hubConfiguration);
        }
    }
}
