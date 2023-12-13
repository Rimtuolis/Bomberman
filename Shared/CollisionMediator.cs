using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public abstract class CollisionMediator
    {
        public abstract void PlayerEnemyCollision(Player player, TemplateBot enemy);
    }
}
