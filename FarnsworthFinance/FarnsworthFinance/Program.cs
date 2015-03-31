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


			ConsoleKeyInfo consoleKeyInfo;

			do {
				Menu.display();
				consoleKeyInfo = Console.ReadKey(false); 
				switch (consoleKeyInfo.KeyChar.ToString()) {
					case "1":
						Console.Clear();
						EmployeeCosts employeeCosts = new EmployeeCosts();
						employeeCosts.PrintInGBP();
						break;
					case "2":
						
						break;
					// etc..
				}
			} while (consoleKeyInfo.Key != ConsoleKey.Escape);
		}
	}
}
