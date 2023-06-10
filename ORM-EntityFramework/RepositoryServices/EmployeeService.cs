using ORM_EntityFramework.Models;

namespace ORM_EntityFramework.RepositoryServices
{
	public class EmployeeService : IEmployeeService
	{
		#region Declaration

		private readonly DotNetPracticeProjectContext _DNPPContext; //dotNetPracticeProjectContext

		#endregion
		public EmployeeService(DotNetPracticeProjectContext dotNetPracticeProjectContext)
		{
			_DNPPContext = dotNetPracticeProjectContext;
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
