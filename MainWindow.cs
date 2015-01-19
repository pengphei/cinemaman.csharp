using System;
using Gtk;

namespace cinemaman
{
	public class MainWindow: Gtk.Window
	{	
		public MainWindow (): base (Gtk.WindowType.Toplevel)
		{
			setupWidgets ();
		}

		private void setupWidgets()
		{
			Fixed container = new Fixed();
			container.SetSizeRequest (800, 600);
			LeftFrame winLeft = new LeftFrame (80, 600);
			container.Put (winLeft, 0, 0);
			Add (container);
		}

		protected void OnDeleteEvent (object sender, DeleteEventArgs a)
		{
			Application.Quit ();
			a.RetVal = true;
		}
	}
}
