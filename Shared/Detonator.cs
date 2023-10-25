using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace BomberGopnik.Shared
{
    public class Detonator
    {
        private readonly static Dictionary<String, SpecialBomb> specialBombs = new Dictionary<string, SpecialBomb>();
        public static Dictionary<String, SpecialBomb> SpecialBombs => specialBombs;
        private static readonly object locker = new object();

        public static void AddBomb(SpecialBomb bomb)
        {
            lock (locker)
            {
                specialBombs[bomb.Id] = bomb;
            }
        }

        public static void Remove(SpecialBomb bomb)
        {
            lock (locker)
            {
                specialBombs.Remove(bomb.Id);
            }
        }
    }
}
