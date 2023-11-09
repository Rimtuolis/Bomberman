using BomberGopnik.Server.Hubs;
using BomberGopnik.Shared;
using Microsoft.AspNetCore.SignalR;

namespace BomberGopnik.Server
{
    public class LiveMonitoring : IHostedService
    {
        private readonly IArenaHub _arenaHub;
        public LiveMonitoring(IArenaHub hubContext) {
            _arenaHub = hubContext;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Run(async() => { 
            while (!cancellationToken.IsCancellationRequested)
                {
                    
                    await _arenaHub.SendBombsAll();
                    Thread.Sleep(100);
                }
            }, cancellationToken);
            
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
