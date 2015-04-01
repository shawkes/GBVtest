using System;
using System.IO;

namespace FarnsworthFinance {
	class DataConnection {
		private const string DATABASE_FILE_NAME = "FarnsworthFinance.mdf";
		private string _myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

		public string datalocation() {
			return string.Concat("Data Source=", _myDocumentsPath, "\\", DATABASE_FILE_NAME, ";");
		}

		public Boolean dataExists() {
			return File.Exists(string.Concat(_myDocumentsPath, "\\", DATABASE_FILE_NAME));
		}
	}
}
