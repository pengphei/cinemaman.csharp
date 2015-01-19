using System;
using Gtk;

namespace cinemaman
{
	class LeftFrame : Gtk.Frame
	{
		public LeftFrame (int width, int height)
		{
			SetSizeRequest (width, height);
			SetupWidgets ();
		}

		private void SetupWidgets()
		{
			Fixed container = new Fixed();
			container.SetSizeRequest (this.WidthRequest, this.HeightRequest);
			Button movieButton = new Button ("电影管理");
			movieButton.SetSizeRequest (80, 80);
			Button hallButton = new Button ("影厅管理");
			hallButton.SetSizeRequest (80, 80);
			Button dataButton = new Button ("数据导出");
			dataButton.SetSizeRequest (80, 80);

			container.Put (movieButton, 0, 0);
			container.Put (hallButton, 0, 80);
			container.Put (dataButton, 0, 160);
			this.Add (container);
		}
	}
}

