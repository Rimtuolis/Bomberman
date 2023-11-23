using BomberGopnik.Shared;

namespace BomberGopnik.Server.Hubs
{
    public interface IArenaHub
    {
        public Task SendBombsAll();
        public Task LoadExplosionGraphics();

    }
}
