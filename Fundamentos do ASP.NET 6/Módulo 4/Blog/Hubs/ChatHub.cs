using Microsoft.AspNetCore.SignalR;

namespace Blog.Hubs
{
    public class ChatHub : Hub
    {
        public async IAsyncEnumerable<DateTime> SendMessage(CancellationToken cancellationToken)
        {
            while (true)
            {
                yield return DateTime.Now;
                await Task.Delay(1000, cancellationToken);
            }
        }
    }
}
