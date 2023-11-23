using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BomberGopnik.Server.Hubs;


namespace BomberGopnik.Shared
{
    public class ExplosionGraphicsLoaderProxy : IExplosionGraphicsLoader
    {
        private bool graphicsLoaded = false;
        private readonly Action lazyLoadExplosionGraphics;
        private readonly IArenaHub _arenaHub;

        public ExplosionGraphicsLoaderProxy(IArenaHub hubContext)
        {
            _arenaHub = hubContext;
        }

        public async void LoadExplosionGraphics()
        {
            if (!graphicsLoaded)
            {
                // Notify clients to load explosion graphics via SignalR
                await _arenaHub.LoadExplosionGraphics();
                graphicsLoaded = true;
            }
            // Otherwise, graphics are already loaded, so do nothing
        }
    }
}
