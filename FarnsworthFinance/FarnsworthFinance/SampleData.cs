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

				AddEmloyees(dataConnection);
				AddERoles(dataConnection);
				AddESalaries(dataConnection);
				AddECurrencies(dataConnection);
			}
		}

		private static void AddEmloyees(DataConnection dataConnection) {
			SQLiteConnection dbConnection = new SQLiteConnection(dataConnection.datalocation());
			dbConnection.Open();

			string sql = "CREATE TABLE Employees (id INT, name VARCHAR(255), role_id INT)";
			SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
			command.ExecuteNonQuery();

			AddEmployee(dbConnection, 1, "Homer Simpson", 1);
			AddEmployee(dbConnection, 2, "Sterling Archer", 1);
			AddEmployee(dbConnection, 3, "Eric Cartman", 1);
			AddEmployee(dbConnection, 4, "Fred Flintstone", 2);
			AddEmployee(dbConnection, 5, "Professor Farnsworth", 3);

			dbConnection.Close();
		}

		private static void AddEmployee(SQLiteConnection dbConnection, int id, string name, int role_id) {
			string sql = string.Concat( "INSERT INTO Employees (id, name, role_id) VALUES ( @id, @name, @role_id );");
			SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
			command.CommandType = System.Data.CommandType.Text;

			command.Parameters.Add(new SQLiteParameter("@id", id));
			command.Parameters.Add(new SQLiteParameter("@name", name));
			command.Parameters.Add(new SQLiteParameter("@role_id", role_id));
			command.ExecuteNonQuery();
		}


		private static void AddERoles(DataConnection dataConnection) {
			SQLiteConnection dbConnection = new SQLiteConnection(dataConnection.datalocation());
			dbConnection.Open();

			string sql = "CREATE TABLE Roles (id INT, name VARCHAR(255))";
			SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
			command.ExecuteNonQuery();

			AddERole(dbConnection, 1, "Staff");
			AddERole(dbConnection, 2, "Manager");
			AddERole(dbConnection, 3, "Owner");

			dbConnection.Close();
		}

		private static void AddERole(SQLiteConnection dbConnection, int id, string name) {
			string sql = string.Concat("INSERT INTO Roles (id, name) VALUES ( @id, @name );");
			SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
			command.CommandType = System.Data.CommandType.Text;

			command.Parameters.Add(new SQLiteParameter("@id", id));
			command.Parameters.Add(new SQLiteParameter("@name", name));
			command.ExecuteNonQuery();
		}

		private static void AddESalaries(DataConnection dataConnection) {
			SQLiteConnection dbConnection = new SQLiteConnection(dataConnection.datalocation());
			dbConnection.Open();

			string sql = "CREATE TABLE Salaries (id INT, employee_id INT, currency INT, annual_amount INT)";
			SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
			command.ExecuteNonQuery();

			AddESalarie(dbConnection, 1, 1, 2, 22000);
			AddESalarie(dbConnection, 2, 2, 2, 150000);
			AddESalarie(dbConnection, 3, 3, 4, 60000);
			AddESalarie(dbConnection, 4, 4, 3, 900000);
			AddESalarie(dbConnection, 5, 5, 5, 5000000000);

			dbConnection.Close();
		}

		private static void AddESalarie(SQLiteConnection dbConnection, int id, int employee_id, int currency, Int64 annual_amount) {
			string sql = string.Concat("INSERT INTO Salaries (id, employee_id, currency, annual_amount) VALUES ( @id, @employee_id, @currency, @annual_amount  );");
			SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
			command.CommandType = System.Data.CommandType.Text;

			command.Parameters.Add(new SQLiteParameter("@id", id));
			command.Parameters.Add(new SQLiteParameter("@employee_id", employee_id));
			command.Parameters.Add(new SQLiteParameter("@currency", @currency));
			command.Parameters.Add(new SQLiteParameter("@annual_amount", annual_amount));
			command.ExecuteNonQuery();
		}

		private static void AddECurrencies(DataConnection dataConnection) {
			SQLiteConnection dbConnection = new SQLiteConnection(dataConnection.datalocation());
			dbConnection.Open();

			string sql = "CREATE TABLE Currencies (id INT, unit VARCHAR(255), conversion_factor DECIMAL)";
			SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
			command.ExecuteNonQuery();
			
			AddECurrency(dbConnection, 1, "GBP", 1);
			AddECurrency(dbConnection, 2, "USD", 1.54);
			AddECurrency(dbConnection, 3, "Rocks", 10);
			AddECurrency(dbConnection, 4, "Sweets", 12);
			AddECurrency(dbConnection, 5, "Credits", 8000);

			dbConnection.Close();
		}

		private static void AddECurrency(SQLiteConnection dbConnection, int id, string unit, double conversion_factor ) {
			string sql = string.Concat("INSERT INTO Currencies (id, unit, conversion_factor) VALUES ( @id, @unit, @conversion_factor);");
			SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
			command.CommandType = System.Data.CommandType.Text;

			command.Parameters.Add(new SQLiteParameter("@id", id));
			command.Parameters.Add(new SQLiteParameter("@unit", unit));
			command.Parameters.Add(new SQLiteParameter("@conversion_factor", conversion_factor));
			command.ExecuteNonQuery();
		}
	}
}
