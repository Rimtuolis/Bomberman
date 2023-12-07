using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public class SaveFile
    {
        List<Save> saves { get; set; }

        public SaveFile()
        {
            saves = new List<Save>();
        }

        public void AddSaves(Save save) { 
            saves.Add(save);
        }

        public int GetLength() {
            return saves.Count;
        }
		public void RestoreGame(int i)
		{
			saves[i].Restore();
		}
	}
}
