using System;
using Gtk;

namespace cinemaman
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.ShowAll();
			Application.Run ();
		}
	}
}
