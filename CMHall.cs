using System;

namespace cinemaman
{
	//Hall Storage Info
	public class CMHall
	{
		public string Name { get;  set; }
		public string Info { get;  set; }

		override public string ToString()
		{
			return string.Format ("{0}/{1}",  Name,  Info);
		}
	}
}

