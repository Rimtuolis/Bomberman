using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
	public class PlayerInfo
	{
		public string? Color { get; set; }
		public string Skin { get; set; }


		public PlayerInfo(string color, string skin)
		{
			Skin = skin;
			Color = color;
		}

	}
}
