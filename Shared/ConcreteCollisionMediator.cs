using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public class ConcreteCollisionMediator : CollisionMediator
    {
        public override void PlayerEnemyCollision(Player player, TemplateBot enemy)
        {
            player.Dead = true;
            Console.WriteLine("Avarija");
        }
    }
}
