using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public abstract class ISubject
    {
        public abstract void Subscribe(IGameObserver observer);
        public abstract void Unsubscribe(IGameObserver observer);
        public abstract void NotifyAll(bool isPaused);
    }
}
