using Cashing.Models;

namespace Cashing.RepositoryServices
{
	public class EmployeeService : IEmployeeService
	{
		#region Declaration

		private readonly CashingProjectContext _DNPPContext; //dotNetPracticeProjectContext

		#endregion
		public EmployeeService(CashingProjectContext cashingProjectContext)
		{
			_DNPPContext = cashingProjectContext;
		}
		#region Interface implementation
		public Employee Create(Employee oEmployee)
		{
			_DNPPContext.Employees.Add(oEmployee);
			_DNPPContext.SaveChanges();
			return oEmployee;
		}

		public string Delete(int id)
		{
			var ofindOb = _DNPPContext.Employees.Where(x => x.Id == id).FirstOrDefault();
			_DNPPContext.Employees.Remove(ofindOb);
			_DNPPContext.SaveChanges();
			return "Deleted";
		}

		public Employee Get(int id)
		{
			return _DNPPContext.Employees.Where(x => x.Id==id).FirstOrDefault();
		}

		public List<Employee> Gets()
		{
			//return _oEmployees;
			return _DNPPContext.Employees.ToList();
		}

		public Employee Update(int id, Employee oEmployee)
		{
			var ofinEmployee= _DNPPContext.Employees.Where(x => x.Id == id).FirstOrDefault();
			if (ofinEmployee != null)
			{
				ofinEmployee.Name = oEmployee.Name;
				ofinEmployee.Salary = oEmployee.Salary;
				
				ofinEmployee.JoinDate = oEmployee.JoinDate;
			}
			_DNPPContext.SaveChanges();
			return ofinEmployee;
		}
	

		#endregion
	}
}
