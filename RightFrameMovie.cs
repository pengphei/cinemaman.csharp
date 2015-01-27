using System;
using System.Collections.Generic;
using Gtk;

namespace cinemaman
{
	public class RightFrameMovie : Gtk.Frame
	{
		private TreeStore listStore;
		private TreeView listView;
		private ScrolledWindow listScroll;

		public RightFrameMovie (int width, int height)
		{
			setupWidgets (width, height);
		}

		private void setupWidgets(int width, int height)
		{
			listStore = new TreeStore (typeof (int), typeof (string), typeof (int), typeof (string), typeof (string), typeof (int));

			listView = new TreeView ();
			listView.Model = listStore;
			listView.HeadersVisible = true;
			listView.AppendColumn ("索引", new CellRendererText (), "text", 0);
			listView.AppendColumn ("名称", new CellRendererText (), "text", 1);
			listView.AppendColumn ("播放时长", new CellRendererText (), "text", 2);
			listView.AppendColumn ("语言", new CellRendererText (), "text", 3);
			listView.AppendColumn ("类型", new CellRendererText (), "text", 4);
			listView.AppendColumn ("价格", new CellRendererText (), "text", 5);

			listScroll = new ScrolledWindow ();
			listScroll.SetSizeRequest (width, height);
			listScroll.Add (listView);
			this.Add (listScroll);
		}

		public void updateList(IList<CMMovie> movieList)
		{
			listStore.Clear ();
			for (int ii = 0;  ii < movieList.Count; ii++)
			{
				CMMovie movie = movieList [ii];
				listStore.AppendValues (ii, movie.Name, movie.Duration, movie.Language, movie.Type, movie.Price);
			}
		}
	}
}

