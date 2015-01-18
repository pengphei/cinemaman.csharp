using System;

namespace cinemaman
{
	public class CMMoviePlay
	{
		int _idx;
		int _hall_idx;
		int _movie_idx;
		DateTime _begin;
		DateTime _end;
		int _price;
		int _rest_time;
		public CMMoviePlay (int idx, int hall_idx, int movie_idx, DateTime begin, DateTime end, int price, int rest)
		{
			_idx = idx;
			_hall_idx = hall_idx;
			_movie_idx = movie_idx;
			_begin = begin;
			_end = end;
			_price = price;
			_rest_time = rest;
		}
		public int Index {get { return _idx; } }
		public int HallIndex { get{ return _hall_idx; } }
		public int MovieIndex { get{ return _movie_idx; } }
		public DateTime BeginTime { get{ return _begin; } }
		public DateTime EndTime { get{ return _end; } }
		public int Price { get{ return _price; } }
		public int RestTime { get { return _rest_time; }}

		override public string ToString()
		{
			return string.Format ("{0}/{1}/{2}/{3}/{4}/{5}/{6}", _idx, _hall_idx, _movie_idx,_begin.ToString(),_end.ToString(),_price,_rest_time);
		}
	}
}

