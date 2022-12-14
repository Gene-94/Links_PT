using Microsoft.AspNetCore.SignalR;

namespace Links_Cards.Helpers
{
    public class SignalR_Hub : Hub
    {
        private static IHubContext<SignalR_Hub> SignalHubContext { get; set; }

        public SignalR_Hub(IHubContext<SignalR_Hub> _signalHubContext)
        {
            SignalHubContext = _signalHubContext;
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            return base.OnDisconnectedAsync(exception);
        }

        public async Task<bool> Reload()
        {
            try
            {
                //await SignalHubContext.Cards.All.SendAsync("ReloadPage");
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
