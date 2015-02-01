using System;
using Gtk;

namespace cinemaman
{
	public class MainWindow: Gtk.Window
	{	
		public enum WinState {
			WIN_STATE_UNKNOWN,
			WIN_STATE_HALL,
			WIN_STATE_MOVIE,
			WIN_STATE_MISC,
		} ;

		private WinState winState = WinState.WIN_STATE_UNKNOWN;
		private LeftFrame winLeft;
		private RightFrameHall winRightHall;
		private RightFrameMovie winRightMovie;
		private RightFrameMisc winRightMisc;
		private Fixed mainLayout;

		private CMDB cmdb;
		public MainWindow (): base (Gtk.WindowType.Toplevel)
		{
			//test ();
			setupWidgets ();
			setupData ();
		}

		private void setupWidgets()
		{
			mainLayout = new Fixed();
			mainLayout.SetSizeRequest (800, 600);
			//left frame
			winLeft = new LeftFrame (this, 80, 600);
			//right frame
			winRightHall = new RightFrameHall (710, 600);
			winRightMovie = new RightFrameMovie (710, 600);
			winRightMisc = new RightFrameMisc (this, 710, 600);

			mainLayout.Put (winLeft, 0, 0);
			showMovie ();
			Add (mainLayout);
		}

		private void setupData()
		{
			cmdb = new CMDB ("test.db4o");
			cmdb.Init ();
			winRightHall.updateList (cmdb.GetHallList());
			winRightMovie.updateList (cmdb.GetMovieList());

			winRightMisc.initHallButtons (cmdb.GetHallList());
			winRightMisc.updateList (cmdb.GetPlayList ());
		}

		protected void OnDeleteEvent (object sender, DeleteEventArgs a)
		{
			Application.Quit ();
			a.RetVal = true;
		}

		public void test()
		{
			cmdb = new CMDB ("test.db4o");
			cmdb.Init ();
			cmdb.TestWriteData ();
			cmdb.TestReadData ();
			cmdb.Fini ();
		}

		private void HideRightFrame(WinState state)
		{
			switch (state) 
			{
			case WinState.WIN_STATE_HALL:
				mainLayout.Remove (winRightHall);
				break;
			case WinState.WIN_STATE_MOVIE:
				mainLayout.Remove (winRightMovie);
				break;
			case WinState.WIN_STATE_MISC:
				mainLayout.Remove (winRightMisc);
				break;
			default:
				break;
			}
		}

		public  void showHall()
		{
			HideRightFrame (winState);
			winState = WinState.WIN_STATE_HALL;
			mainLayout.Put (winRightHall, 90, 0);
			ShowAll ();
		}

		public  void showMovie()
		{
			HideRightFrame (winState);
			winState = WinState.WIN_STATE_MOVIE;
			mainLayout.Put (winRightMovie, 90, 0);
			ShowAll ();
		}

		public  void showMisc()
		{
			HideRightFrame (winState);
			winState = WinState.WIN_STATE_MISC;
			mainLayout.Put (winRightMisc, 90, 0);
			ShowAll ();
		}

		public void updatePlayList(string hall, DateTime day)
		{
			DateTime beginTime = new DateTime (day.Year, day.Month, day.Day, 0, 0, 0);
			DateTime endTime = new DateTime (day.Year, day.Month, day.Day, 0, 0, 0).AddDays(1);

			winRightMisc.updateList (cmdb.GetPlayList (hall, beginTime, endTime));
		}
	}
}
