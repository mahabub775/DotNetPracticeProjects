using Dapper;
using Microsoft.Data.SqlClient;

namespace ORM_Dapper.RepositoryServices
{
	public class EmployeeService : IEmployeeService
	{
		private readonly DotNetPracticeProjectContext _dbcontext;
		private readonly IConfiguration _iconfig;
		public EmployeeService(DotNetPracticeProjectContext dbcontext, IConfiguration iconfig) {
			_dbcontext = dbcontext;
			_iconfig = iconfig;
		}

		public Employee Add(Employee employee)
		{
			_dbcontext.Employees.Add(employee);
			_dbcontext.SaveChanges();
			return employee;
		}
		public string Delete(int id)
		{
			var oEmployee = _dbcontext.Employees.Where(x=>x.Id==id).FirstOrDefault();
			_dbcontext.Employees.Remove(oEmployee);
			_dbcontext.SaveChanges();

			return "Deleted";
		}
		public List<Employee> GetAll()
		{
			return _dbcontext.Employees.ToList();
		}

		//using dapper
		public Employee Get(int id)
		{
			using var Connection = new SqlConnection(_iconfig.GetConnectionString("DefaultConnection"));
			var oEmployee =  Connection.QueryFirst<Employee>("SELECT * FROM Employees Where Id = @empid ", new { empid = id });
			//Employee dd = new Employee();
			return oEmployee;
		}
	}
}
