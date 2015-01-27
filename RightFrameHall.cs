using System;
using System.Collections.Generic;
using Gtk;

namespace cinemaman
{
	public class RightFrameHall : Gtk.Frame
	{
		private TreeStore listStore;
		private TreeView listView;
		private ScrolledWindow listScroll;

		public RightFrameHall (int width, int height)
		{
			setupWidgets (width, height);
		}

		private void setupWidgets(int width, int height)
		{
			listStore = new TreeStore (typeof (int), typeof (string));

			listView = new TreeView ();
			listView.Model = listStore;
			listView.HeadersVisible = true;
			listView.AppendColumn ("索引", new CellRendererText (), "text", 0);
			listView.AppendColumn ("名称", new CellRendererText (), "text", 1);

			listScroll = new ScrolledWindow ();
			listScroll.SetSizeRequest (width, height);
			listScroll.Add (listView);
			this.Add (listScroll);
		}

		public void updateList(IList<CMHall> hallList)
		{
			listStore.Clear ();
			for (int ii =0;  ii < hallList.Count; ii++)
			{
					listStore.AppendValues (ii, hallList[ii].Name);
			}
		}
	}
}

