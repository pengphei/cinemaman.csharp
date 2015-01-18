using System;

namespace cinemaman
{
	public class CMMovie
	{
		int _idx;
		string _name;
		int _duration;
		string _language;
		string _type;
		int _price;
		public CMMovie (int idx, string name, int duration, string lang, string type, int price)
		{
			_idx = idx;
			_name = name;
			_duration = duration;
			_language = lang;
			_type = type;
			_price = price;
		}

		public int Index {get { return _idx; } }
		public string Name { get{ return _name; } }
		public int Duration { get{ return _duration; } }
		public string Language { get{ return _language; } }
		public string Type { get{ return _type; } }
		public int Price { get{ return _price; } }

		override public string ToString()
		{
			return string.Format ("{0}/{1}/{2}/{3}/{4}/{5}", _idx, _name, _duration,_language,_type,_price);
		}
	}
}

