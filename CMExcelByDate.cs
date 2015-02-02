using System;
using System.IO;
using NPOI;
using NPOI.HPSF;
using NPOI.HSSF;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.POIFS;
using NPOI.Util; 

namespace cinemaman
{
	public class CMExcelByDate
	{

		private HSSFWorkbook _workbook;
		private HSSFSheet _sheet;

		// file name for exporting
		public string FileName { get;  set; }

		public CMExcelByDate ()
		{
		}

		public void Init()
		{
			_workbook = new HSSFWorkbook();
			_sheet = _workbook.CreateSheet("Sheet1");
			_workbook.CreateSheet("Sheet2");
			_workbook.CreateSheet("Sheet3");
		}

		public void Fini()
		{
			System.IO.FileStream file = new FileStream(this.FileName, FileMode.Create);
			_workbook.Write(file);
			file.Close();
		}
	}
}

