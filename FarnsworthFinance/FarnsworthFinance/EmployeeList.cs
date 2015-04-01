using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace FarnsworthFinance {
	class Staff {
		private List<Employee> _employees = new List<Employee>();

		public List<Employee> List { 
			get {
				return _employees;
			} 
		}

		public Staff() {

			DataConnection dataConnection = new DataConnection();
			SQLiteConnection dbConnection = new SQLiteConnection(dataConnection.datalocation());
			dbConnection.Open();


			string sql = "SELECT Employees.id FROM Employees ";
			SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
			command.CommandType = System.Data.CommandType.Text;

			SQLiteDataReader reader = command.ExecuteReader();
			while (reader.Read()) {
				Employee employee = new Employee((int)reader["id"]);
				this._employees.Add(employee);
			}
			dbConnection.Close();
		}
	}
}
