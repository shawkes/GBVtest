using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace FarnsworthFinance {
	class DataConnection {
		private string _databaseFileName = "FarnsworthFinance.mdf";
		private string _myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

		public string datalocation() {
			return string.Concat("Data Source=" , _myDocumentsPath , "\\" ,_databaseFileName ,";");
		}

		public Boolean dataExists() {
			return File.Exists(string.Concat( _myDocumentsPath, "\\", _databaseFileName));
		}
	}
}
