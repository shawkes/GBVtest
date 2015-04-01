using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace FarnsworthFinance {
	class LocalCurrency {
		private int _id;
		private string _unit;
		private double _conversion_factor;

		public string Unit {
			get {
				return _unit;
			}
		}

		public double ConvertToGBP(Int64 localValue) {
			return localValue / _conversion_factor;
		}

		public LocalCurrency(int id) {
			_id = id;

			DataConnection dataConnection = new DataConnection();
			SQLiteConnection dbConnection = new SQLiteConnection(dataConnection.datalocation());
			dbConnection.Open();


			string sql = "SELECT unit, conversion_factor FROM Currencies WHERE id = @id ";
			SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
			command.CommandType = System.Data.CommandType.Text;

			command.Parameters.Add(new SQLiteParameter("@id", id));
			SQLiteDataReader reader = command.ExecuteReader();
			while (reader.Read()) {
				this._unit = Convert.ToString(reader["unit"]);
				this._conversion_factor = Convert.ToDouble(reader["conversion_factor"]);
			}
			dbConnection.Close();

		}
	}
}
