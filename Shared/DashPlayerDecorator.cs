using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public class DashPlayerDecorator : PlayerDecorator
    {
        public DashPlayerDecorator(IPlayer player) : base(player)
        {
        }
        public override void Move()
        {
            base.Move();
        }
    }
}
