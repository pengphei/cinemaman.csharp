using System;

namespace cinemaman
{
	//Hall Storage Info
	public class CMHall
	{
		int _idx;
		string _name;
		string _info;
		public CMHall (int idx, string name, string info)
		{
			_idx = idx;
			_name = name;
			_info = info;
		}

		public int Index { get { return _idx; } }
		public string Name { get { return _name; } }
		public string Info { get { return _info; } }

		override public string ToString()
		{
			return string.Format ("{0}/{1}/{2}", _idx, _name, _info);
		}
	}
}

