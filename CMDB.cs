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

		public IList <CMHall> GetHallList()
		{
			return dbConn.Query<CMHall> ();
		}
		public IList <CMMovie> GetMovieList()
		{
			return dbConn.Query<CMMovie> ();
		}
		public IList <CMMoviePlay> GetPlayList()
		{
			return dbConn.Query<CMMoviePlay> ();
		}

		public IList<CMMoviePlay> GetPlayList(string hall, DateTime date)
		{
			return dbConn.Query<CMMoviePlay> (new CMMoviePlay () {HallName = hall});
		}

		public void TestWriteData()
		{
			// for CMHall
			CMHall hall0 = new CMHall () {Name="一号大厅" ,  Info = "第一号大厅"};
			CMHall hall1 = new CMHall() {Name="二号大厅" ,  Info = "第二号大厅"};
			CMHall hall2 = new CMHall() {Name="三号大厅" ,  Info = "第三号大厅"};
			dbConn.Store (hall0);
			Console.WriteLine("Stored {0}", hall0);
			dbConn.Store (hall1);
			Console.WriteLine("Stored {0}", hall1);
			dbConn.Store (hall2);
			Console.WriteLine("Stored {0}", hall2);
			dbConn.Commit ();

			// for CMMovie
			CMMovie movie0 = new CMMovie (){Name = "小鬼当家",  Duration = 120, Language = "英语", Type = "儿童", Price = 20};
			dbConn.Store (movie0);
			CMMovie movie1 = new CMMovie(){ Name = "七剑下天山",  Duration = 110, Language = "国语", Type = "武侠", Price = 20};
			dbConn.Store (movie1);
			CMMovie movie2 = new CMMovie (){ Name = "魔术师",  Duration = 120,  Language = "国语",  Type = "魔幻",  Price = 20};
			dbConn.Store (movie2);
			dbConn.Commit ();

			// for CMMoviePlay
			CMMoviePlay play0 = new CMMoviePlay () { HallName = "一号大厅", MovieName = "小鬼当家", BeginTime = Convert.ToDateTime("2007-8-1"), EndTime =  Convert.ToDateTime("2007-8-1"),  Language = "英语",  Type = "儿童",  Price =  20, Rest = 15};
			dbConn.Store (play0);
			CMMoviePlay play1 = new  CMMoviePlay () { HallName = "一号大厅", MovieName = "小鬼当家", BeginTime = Convert.ToDateTime("2008-8-1"), EndTime =  Convert.ToDateTime("2008-8-1"),  Language = "英语",  Type = "儿童",  Price =  20, Rest = 15};
			dbConn.Store (play1);
			CMMoviePlay play2 = new  CMMoviePlay () { HallName = "一号大厅", MovieName = "小鬼当家", BeginTime = Convert.ToDateTime("2009-8-1"), EndTime =  Convert.ToDateTime("2009-8-1"),  Language = "英语",  Type = "儿童",  Price =  20, Rest = 15};
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

