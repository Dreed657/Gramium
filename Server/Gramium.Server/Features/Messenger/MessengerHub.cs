using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Gramium.Server.Features.Messenger
{
    public class MessengerHub : Hub
    {
        public MessengerHub()
        {
            
        }
        //public async Task JoinChannel(string groupName, string senderId)
        //{
        //    await this.Groups.AddToGroupAsync(this.Context.ConnectionId, groupName);
        //    await this.Clients.Group(groupName).SendAsync("MemberJoined", message, groupName);
        //}

        public async Task SendMessage(string message)
        {
            await this.Clients.All.SendAsync("SendAll", message);
        }
    }
}
