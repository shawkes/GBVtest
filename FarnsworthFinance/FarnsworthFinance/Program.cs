using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarnsworthFinance {
	class Program {
		static void Main(string[] args) {
			SampleData.Create();


			ConsoleKeyInfo consoleKeyInfo;

			do {
				Menu.DisplayMain();
				consoleKeyInfo = Console.ReadKey(false); 
				switch (consoleKeyInfo.KeyChar.ToString()) {
					case "1":
						Console.Clear();
						EmployeeCosts employeeCosts = new EmployeeCosts();
						employeeCosts.PrintInGBP();
						break;

					case "2":
						EmployeeSearch();
						break;

					case "3":
						EmployeeList();
						break;
				}
			} while (consoleKeyInfo.Key != ConsoleKey.Escape);
		}

			
		private static void EmployeeSearch() {
			Console.WriteLine();
			Console.WriteLine("Enter name:");
			string employeeQuery = Console.ReadLine();
			var searchResult = Staff.FindEmployee( employeeQuery.ToLower());
			if (searchResult.Count() == 1) {
				Employee employee = searchResult.First();
				Console.WriteLine("Found employee.");
				Console.WriteLine("Name: {0}\tSallary: {1} {2}\tCost GBP: {3:C}", employee.name, employee.Salary, employee.SalaryUnit, employee.SalaryinGBP);
			} else if (searchResult.Count() > 1) {
				Console.WriteLine("More than one employee found! Please be more specific.");
			} else {
				Console.WriteLine("No employee found by that name!");
			}
			Console.ReadLine();
		}

		private static void EmployeeList() {
			Console.Clear();
			Staff staff = new Staff();
			var searchResult = from employee in staff.List where employee.RoleTitle.ToLower() == "staff".ToLower() orderby employee.SalaryinGBP descending select employee;
			foreach (Employee employee in searchResult) {
				Console.WriteLine("Name: {0}\tSallary: {1} {2}\tCost GBP: {3:C}", employee.name, employee.Salary, employee.SalaryUnit, employee.SalaryinGBP);
			}
			Console.ReadLine();
		}

		
	}
}
