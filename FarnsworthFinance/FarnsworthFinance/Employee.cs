using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace FarnsworthFinance {
	class Employee {
		private int _id;
		private string _name;
		private int _salary;
		private LocalCurrency _localCurrency;


		public int id {
			get { return _id; }
		}
		public string name {
			get { return _name; }
		}
		public int Salary {
			get { return _salary; }
		}
		public double SalaryinGBP {
			get { 
				return _localCurrency.ConvertToGBP(_salary); 
			}
		}

		public Employee() { }

		public Employee(int id) {
			_id = id;

			DataConnection dataConnection = new DataConnection();
			SQLiteConnection dbConnection = new SQLiteConnection(dataConnection.datalocation());
			dbConnection.Open();


			string sql = "SELECT Employees.name, Salaries.annual_amount, currency FROM Employees JOIN Salaries ON Employees.id = Salaries.employee_id WHERE Employees.id = @id ";
			SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
			command.CommandType = System.Data.CommandType.Text;

			command.Parameters.Add(new SQLiteParameter("@id", id));
			SQLiteDataReader reader = command.ExecuteReader();
			while (reader.Read()) {
				this._name = (string)reader["name"];
				this._salary = (int)reader["annual_amount"];
				this._localCurrency = new LocalCurrency((int)reader["currency"]);
			}
			dbConnection.Close();
		}

		
	}
}
