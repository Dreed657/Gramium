using System.Threading.Tasks;
using Gramium.Server.Infrastructure.Services;
using Microsoft.AspNetCore.SignalR;

namespace Gramium.Server.Features.Messenger
{
    public class MessengerHub : Hub
    {
        private readonly ICurrentUserService currentUser;

        public MessengerHub(ICurrentUserService currentUser)
        {
            this.currentUser = currentUser;
        }

        public async Task JoinChannel()
        {
            var username = this.currentUser.GetUserName();
            await this.Clients.All.SendAsync("MemberJoined", this.Context.ConnectionId, username);
        }

        public async Task SendMessage(string message)
        {
            await this.Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
