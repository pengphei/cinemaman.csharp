using System;
using System.Collections.Generic;
using Gtk;

namespace cinemaman
{
	public class RightFrameMisc : Gtk.Frame
	{
		private MainWindow root;

		private VBox layout;
		private HButtonBox hallButtonBox;
		private Calendar calendar;

		private TreeStore listStore;
		private TreeView listView;
		private ScrolledWindow listScroll;

		public RightFrameMisc (MainWindow root, int width, int height)
		{
			this.root = root;
			setupWidgets (width, height);
		}

		private void setupWidgets(int width, int height)
		{
			// hall ButtonBox setup
			hallButtonBox = new HButtonBox ();

			//calendar setup
			calendar = new Calendar ();
			calendar.DisplayOptions = CalendarDisplayOptions.ShowHeading  | 
				CalendarDisplayOptions.ShowDayNames | 
					CalendarDisplayOptions.ShowWeekNumbers;
			calendar.DaySelected += new EventHandler(HandleDaySelected);

			//play list setup
			listStore = new TreeStore (typeof (int), typeof (string), typeof (string), typeof (string), typeof (string), typeof (int), typeof (string), typeof(string), typeof(int));

			listView = new TreeView ();
			listView.Model = listStore;
			listView.HeadersVisible = true;
			listView.AppendColumn ("索引", new CellRendererText (), "text", 0);
			listView.AppendColumn ("电影名称", new CellRendererText (), "text", 1);
			listView.AppendColumn ("影厅", new CellRendererText (), "text", 2);
			listView.AppendColumn ("开始时间", new CellRendererText (), "text", 3);
			listView.AppendColumn ("结束时间", new CellRendererText (), "text", 4);
			listView.AppendColumn ("中场休息", new CellRendererText (), "text", 5);
			listView.AppendColumn ("语言", new CellRendererText (), "text", 6);
			listView.AppendColumn ("类型", new CellRendererText (), "text", 7);
			listView.AppendColumn ("价格", new CellRendererText (), "text", 8);

			listScroll = new ScrolledWindow ();
			listScroll.Add (listView);

			layout = new VBox ();
			layout.SetSizeRequest (width, height);
			layout.Add (calendar);
			layout.Add (hallButtonBox);
			layout.Add (listScroll);
			this.Add (layout);
		}

		// Typical event handler for capturing the selected date
		void HandleDaySelected (object obj, EventArgs args)
		{
			Calendar activatedCalendar = (Calendar) obj;
			Console.WriteLine (activatedCalendar.GetDate ().ToString ("yyyy/MM/dd"));
		}

		public void initHallButtons(IList<CMHall> hallList)
		{
			for (int ii =0; ii < hallList.Count; ii++)
			{
				Button button = new Button (hallList[ii].Name);
				hallButtonBox.Add (button);
			}
		}

		public void updateList(IList<CMMoviePlay> playList)
		{
			listStore.Clear ();
			for (int ii =0;  ii < playList.Count; ii++)
			{
				CMMoviePlay play = playList [ii];
				listStore.AppendValues (ii, 
				                        play.MovieName, 
				                        play.HallName, 
				                        play.BeginTime.ToString("yyyy-MM-dd HH:MM"), 
				                        play.EndTime.ToString("yyyy-MM-dd HH:MM"), 
				                        play.Rest, 
				                        play.Language, 
				                        play.Type, 
				                        play.Price);
			}
		}

		private void onButton(object obj, EventArgs args)
		{
			Button bt = (Button)obj;
			root.updatePlayList (bt.Name, DateTime.Now);
		}
	}
}

