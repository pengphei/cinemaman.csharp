using System;
using System.Collections.Generic;
using Db4objects.Db4o;

namespace cinemaman
{
	public class CMDB
	{
		private IObjectContainer dbConn = null;
		private String dbPath;
		public CMDB (String path)
		{
			dbPath = path;
		}
		public void Init()
		{
			dbConn = Db4oFactory.OpenFile(dbPath);
		}

		public void Fini()
		{
			dbConn.Close();
		}

		public void TestWriteData()
		{
			// for CMHall
			CMHall hall0 = new CMHall (0, "一号大厅",  "第一号大厅");
			CMHall hall1 = new CMHall (1, "一号大厅",  "第一号大厅");
			CMHall hall2 = new CMHall (2, "一号大厅",  "第一号大厅");
			dbConn.Store (hall0);
			Console.WriteLine("Stored {0}", hall0);
			dbConn.Store (hall1);
			Console.WriteLine("Stored {0}", hall1);
			dbConn.Store (hall2);
			Console.WriteLine("Stored {0}", hall2);
			dbConn.Commit ();

			// for CMMovie
			CMMovie movie0 = new CMMovie (0, "小鬼当家",  120, "英语", "儿童", 20);
			dbConn.Store (movie0);
			CMMovie movie1 = new CMMovie (1, "七剑下天山",  110, "国语", "武侠", 20);
			dbConn.Store (movie1);
			CMMovie movie2 = new CMMovie (2, "魔术师",  120, "国语", "魔幻", 20);
			dbConn.Store (movie2);
			dbConn.Commit ();

			// for CMMoviePlay
			CMMoviePlay play0 = new CMMoviePlay (0, 1,1,  Convert.ToDateTime("2007-8-1"), Convert.ToDateTime("2007-8-1"), 20, 15);
			dbConn.Store (play0);
			CMMoviePlay play1 = new  CMMoviePlay (0, 1,1,  Convert.ToDateTime("2008-8-1"), Convert.ToDateTime("2008-8-1"), 20, 15);
			dbConn.Store (play1);
			CMMoviePlay play2 = new  CMMoviePlay (0, 1,1,  Convert.ToDateTime("2009-8-1"), Convert.ToDateTime("2009-8-1"), 20, 15);
			dbConn.Store (play2);
			dbConn.Commit ();
		}

		public void TestReadData()
		{
			IList <CMHall> hallList = dbConn.Query<CMHall> ();
			foreach (CMHall hall in hallList) {
				Console.WriteLine (hall);
			}

			IList<CMMovie> movieList = dbConn.Query<CMMovie> ();
			foreach (CMMovie movie in movieList) {
				Console.WriteLine (movie);
			}

			IList<CMMoviePlay> playList = dbConn.Query<CMMoviePlay> ();

			foreach (CMMoviePlay play in playList) {
				Console.WriteLine (play);
			}
		}
	}
}

