using System;

namespace cinemaman
{
	public class CMMoviePlay
	{
		public string HallName { get;  set; }
		public string MovieName { get;  set; }
		public DateTime BeginTime { get;  set; }
		public DateTime EndTime { get;  set; }
		public string Language { get;  set; }
		public string Type { get;  set; }
		public int Price { get;  set; }
		public int Rest { get;  set; }

		override public string ToString()
		{
			return string.Format ("{0}/{1}/{2}/{3}/{4}/{5}/{6}/{7}", HallName,  MovieName, BeginTime.ToString(), EndTime.ToString(), Language,  Type,  Price, Rest );
		}
	}
}

