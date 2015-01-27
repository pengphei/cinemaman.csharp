using System;

namespace cinemaman
{
	public class CMMovie
	{
		public string Name { get;  set; }
		public int Duration { get;  set; }
		public string Language { get;  set; }
		public string Type { get;  set; }
		public int Price { get;  set; }

		override public string ToString()
		{
			return string.Format ("{0}/{1}/{2}/{3}/{4}",  Name, Duration, Language, Type, Price);
		}
	}
}

