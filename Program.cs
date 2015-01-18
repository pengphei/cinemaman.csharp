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
			//test ();
			Application.Run ();
		}

		public static void SetupLeftFrame()
		{
		}

		public static void SetupRightFrame()
		{

		}

		public static void SetupData()
		{

		}

		public static void test()
		{
			CMDB cmdb = new CMDB ("test.db4o");
			cmdb.Init ();
			cmdb.TestWriteData ();
			cmdb.TestReadData ();
			cmdb.Fini ();
		}
	}
}
