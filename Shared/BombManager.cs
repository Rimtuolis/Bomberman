using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public class BombManager
    {
        private static readonly Dictionary<String, List<Bomb>> bombs = new Dictionary<string, List<Bomb>>();
      
        private static readonly object locker = new object();

        public static Dictionary<String, List<Bomb>> Bombs => bombs;

        public static async Task Addbomb(Bomb bomb)
        {
            lock (locker)
            {
                bombs.TryGetValue(bomb.Id, out List<Bomb> list);
                if (list != null)
                {
                    bombs[bomb.Id].Add(bomb);
                }
                else
                {
                    bombs.Add(bomb.Id, new List<Bomb>() { bomb });
                }
                Task.Run(() =>
                {
                    Console.WriteLine("Setting timer");
                    Thread.Sleep(3000);
                    if (bombs[bomb.Id].Contains(bomb)) {
                        bombs[bomb.Id].FirstOrDefault(n => n.Equals(bomb)).Exploded = true;
					}
                    Console.WriteLine("Exploding");
					Task.Run(() =>
					{
						Console.WriteLine("Setting timer_2");
						Thread.Sleep(1500);
						bombs[bomb.Id].Remove(bomb);
						Console.WriteLine("Exploded");
					});
				});

			}
        }

        public static void setView(Bomb bomb) {
			lock (locker)
			{
				if (bombs[bomb.Id].Contains(bomb))
				{
                    bombs[bomb.Id].First(n => n.Equals(bomb)).viewed = true;
				}
			}
		}

        public static List<Bomb> GetBombs() {

            List<Bomb> list = new List<Bomb>(); 
            foreach (var bomb in bombs.Values) {
                list.AddRange(bomb);  
            }
            return list;    
        }
    }
}
