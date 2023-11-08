using BomberGopnik.Shared;
using Microsoft.Extensions.Hosting;

namespace BomberGopnik.Server
{
    public class BombMonitor : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Task.Run(() =>
            {
                PlayerManager.bombMonitor();
            }, stoppingToken);
            return Task.CompletedTask;
        }
    }
}
