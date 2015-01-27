using System;
using Gtk;

namespace cinemaman
{
	class LeftFrame : Gtk.Frame
	{
		private MainWindow root;

		public LeftFrame (MainWindow root,  int width, int height)
		{
			this.root = root;
			SetSizeRequest (width, height);
			SetupWidgets ();
		}

		private void SetupWidgets()
		{
			Fixed container = new Fixed();
			container.SetSizeRequest (this.WidthRequest, this.HeightRequest);

			Button movieButton = new Button ("电影管理");
			movieButton.SetSizeRequest (80, 80);
			movieButton.Released += onMoviePressed;

			Button hallButton = new Button ("影厅管理");
			hallButton.SetSizeRequest (80, 80);
			hallButton.Released += onHallPressed;

			Button dataButton = new Button ("排期管理");
			dataButton.SetSizeRequest (80, 80);
			dataButton.Released += onMiscPressed;

			container.Put (movieButton, 0, 0);
			container.Put (hallButton, 0, 80);
			container.Put (dataButton, 0, 160);
			this.Add (container);
		}

		private void onHallPressed(object obj, EventArgs args)
		{
			root.showHall ();
		}

		private void onMoviePressed(object obj, EventArgs args)
		{
			root.showMovie ();
		}

		private void onMiscPressed(object obj, EventArgs args)
		{
			root.showMisc ();
		}
	}
}

