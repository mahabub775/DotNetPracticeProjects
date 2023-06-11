using JWTAuth.Models;

namespace JWTAuth.RepositoryServices
{
	public class EmployeeService : IEmployeeService
	{
		#region Declaration
		private static List<Employee> _oEmployees = new List<Employee> { 

		new Employee { Name = "abudllabn", Id = 15, Salary = 150 },
			new Employee { Name = "Shahin", Id = 112, Salary = 350 },
			new Employee { Name = "Nazrul", Id = 1585, Salary = 250 }
		};
		#endregion
		#region Interface implementation
		public Employee Create(Employee oEmployee)
		{
			_oEmployees.Add(oEmployee);
			return oEmployee;
		}

		public string Delete(int id)
		{
			var ofindOb = _oEmployees.Where(x => x.Id == id).FirstOrDefault();
			_oEmployees.Remove(ofindOb);
			return "Deleted";
		}

		public Employee Get(int id)
		{
			return _oEmployees.Where(x => x.Id==id).FirstOrDefault();
		}

		public List<Employee> Gets()
		{
			return _oEmployees;
		}

		public Employee Update(int id, Employee oEmployee)
		{
			var ofinEmployee= _oEmployees.Where(x => x.Id == id).FirstOrDefault();
			if (ofinEmployee != null)
			{
				ofinEmployee.Name = oEmployee.Name;
				ofinEmployee.Salary = oEmployee.Salary;
				ofinEmployee.Id = oEmployee.Id;
				ofinEmployee.JoinDate = oEmployee.JoinDate;
			}
			return ofinEmployee;
		}
	

		#endregion
	}
}
