using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
	public class WASDKeyMovement : IMovement
	{
		public int Dx { get; private set; }
		public int Dy { get; private set; }

		public WASDKeyMovement(KeyboardEventArgs e)
		{
			switch (e.Code)
			{
				case "65":
					Dx = -5;
					break;
				case "87":
					Dy = -5;
					break;
				case "68":
					Dx = 5;
					break;
				case "83":
					Dy = 5;
					break;
			}
		}
	}
}
