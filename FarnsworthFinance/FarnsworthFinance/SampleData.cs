using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace FarnsworthFinance {
	class SampleData {
		public static void Create() {
			DataConnection dataConnection = new DataConnection();
			if (!dataConnection.dataExists()) {

				SQLiteConnection dbConnection = new SQLiteConnection(dataConnection.datalocation());
				dbConnection.Open();

				string sql = "create table Employees (id int, name varchar(255), role_id int)";
				SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
				command.ExecuteNonQuery();

				sql = "insert into Employees (id, name, role_id) values (1, 'Homer Simpson', 1)";
				command = new SQLiteCommand(sql, dbConnection);
				command.ExecuteNonQuery();

				sql = "insert into Employees (id, name, role_id) values (2, 'Sterling Archer', 1)";
				command = new SQLiteCommand(sql, dbConnection);
				command.ExecuteNonQuery();

				sql = "insert into Employees (id, name, role_id) values (3, 'Eric Cartman', 1)";
				command = new SQLiteCommand(sql, dbConnection);
				command.ExecuteNonQuery();

				sql = "insert into Employees (id, name, role_id) values (4, 'Fred Flintstone', 2)";
				command = new SQLiteCommand(sql, dbConnection);
				command.ExecuteNonQuery();

				sql = "insert into Employees (id, name, role_id) values (5, 'Professor Farnsworth', 3)";
				command = new SQLiteCommand(sql, dbConnection);
				command.ExecuteNonQuery();

				dbConnection.Close();
			}
		}
	}
}
