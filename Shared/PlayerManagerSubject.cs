using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public class PlayerManagerSubject : ISubject
    {
        public List<IGameObserver> gameObservers =  new List<IGameObserver>();
        public bool Paused { get; set; }

        public PlayerManagerSubject(List<IGameObserver> gameObservers, bool paused)
        {
            this.gameObservers = gameObservers;
            this.Paused = paused;
        }

        public PlayerManagerSubject(List<IGameObserver> gameObservers)
        {
            this.gameObservers = gameObservers;
        }
        public PlayerManagerSubject() 
        {
        }

        public override void Subscribe(IGameObserver observer)
        {
            gameObservers.Add(observer);
        }

        public override void Unsubscribe(IGameObserver observer)
        {
            gameObservers.Remove(observer);
        }

        public override void NotifyAll(bool isPaused)
        {
            Paused = isPaused;
            foreach (var observer in gameObservers)
            {
                observer.UpdateGameStatus(isPaused);
            }
        }
    }
}
