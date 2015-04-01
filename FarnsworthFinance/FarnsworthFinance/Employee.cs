using System;
using System.Data.SQLite;

namespace FarnsworthFinance {
	class Employee {
		private int _id;
		private string _name;
		private Int64 _salary;
		private Role _role;
		private LocalCurrency _localCurrency;


		public int id {
			get { return _id; }
		}
		public string name {
			get { return _name; }
		}
		public Int64 Salary {
			get { return _salary; }
		}
		public string SalaryUnit {
			get { return _localCurrency.Unit; }
		}
		public double SalaryinGBP {
			get {
				return _localCurrency.ConvertToGBP(_salary);
			}
		}
		public string RoleTitle {
			get {
				return _role.Title;
			}
		}

		public Employee() { }

		public Employee(int id) {
			_id = id;

			DataConnection dataConnection = new DataConnection();
			SQLiteConnection dbConnection = new SQLiteConnection(dataConnection.datalocation());
			dbConnection.Open();


			string sql = "SELECT Employees.name, Salaries.annual_amount, currency, role_id, Roles.name AS RoleTitle FROM Employees JOIN Salaries ON Employees.id = Salaries.employee_id JOIN Roles ON Employees.role_id = Roles.id WHERE Employees.id = @id ";
			SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
			command.CommandType = System.Data.CommandType.Text;

			command.Parameters.Add(new SQLiteParameter("@id", id));
			SQLiteDataReader reader = command.ExecuteReader();
			while (reader.Read()) {
				this._name = Convert.ToString(reader["name"]);
				this._salary = Convert.ToInt64(reader["annual_amount"]);
				this._localCurrency = new LocalCurrency(Convert.ToInt32(reader["currency"]));
				this._role = new Role() { Id = Convert.ToInt32(reader["currency"]), Title = Convert.ToString(reader["RoleTitle"]) };
			}
			dbConnection.Close();
		}


	}
}
