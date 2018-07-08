using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using WebApplSignalR.SignalR;

namespace WebApplSignalR
{
    public class TrajetHub : Hub
    {
        [HubMethodName("NotifyClients")]
        public static void NotifyAllClients(TrajetMessageModel data)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<TrajetHub>();

            context.Clients.All.updatedClients(data);
        }
    }
}