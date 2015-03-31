using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace FarnsworthFinance {
	class EmployeeCosts {
		public void PrintInGBP(){
			DataConnection dataConnection = new DataConnection();
			SQLiteConnection dbConnection = new SQLiteConnection(dataConnection.datalocation());
			dbConnection.Open();


			string sql = "SELECT Employees.name, Salaries.annual_amount / Currencies.conversion_factor AS annual_amount_in_GBP FROM Employees JOIN Salaries ON Employees.id = Salaries.employee_id JOIN Currencies ON Salaries.currency = Currencies.id ";
			SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
			SQLiteDataReader reader = command.ExecuteReader();
			while (reader.Read()) {
				Console.WriteLine("Name: {0} \tGBP: {1:C}", reader["name"], reader["annual_amount_in_GBP"]);
			}
			Console.ReadLine();
		}
	}
}
