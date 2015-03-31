using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace FarnsworthFinance {
	class Program {
		static void Main(string[] args) {
			SampleData.Create();

			EmployeeCosts employeeCosts = new EmployeeCosts();
			employeeCosts.PrintInGBP();

			Console.ReadLine();
		}
	}
}
