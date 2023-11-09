using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
	public class ArrowKeyMovement : IMovement
	{
		public int Dx { get; private set; }
		public int Dy { get; private set; }

		public ArrowKeyMovement(KeyboardEventArgs e)
		{
			switch (e.Code)
			{
				case "37":
					Dx = -5;
					break;
				case "38":
					Dy = -5;
					break;
				case "39":
					Dx = 5;
					break;
				case "40":
					Dy = 5;
					break;
			}
		}
	}
}
