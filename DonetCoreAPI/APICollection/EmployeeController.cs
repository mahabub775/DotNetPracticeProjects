using DonetCoreAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace DonetCoreAPI.APICollection
{
	
	[ApiController]
	[Route("[controller]")]
	public class EmployeeController : ControllerBase
	{

		#region Declaration
		List<Employee> _oEmployees = new List<Employee>();
		public EmployeeController() 
		{
			_oEmployees.Add(new Employee() {Name="abudllabn", Id = 15,Salary = 150});
			_oEmployees.Add(new Employee() { Name = "Shahin", Id = 112, Salary = 350 });
			_oEmployees.Add(new Employee() { Name = "Nazrul", Id = 1585, Salary = 250 });
		}
		#endregion

		[HttpGet]
		public ActionResult<Employee> Gets()
		{	

			return Ok(_oEmployees);
		}

		// GET api/<EmployeeController>/5
		[HttpGet("{id}")]
		public async Task<Employee> Get(int id)
		{
			return _oEmployees.Where(x => x.Id == id).FirstOrDefault();
		}

		// POST api/<EmployeeController>
		[HttpPost]
		public async Task<Employee> AddEmployee(Employee value)
		{
			//_oEmployees.Add(new Employee("Mahaub", 5, 3500, DateTime.Today));
	
			_oEmployees.Add(value);

			return value;
		}

		// PUT api/<EmployeeController>/5
		[HttpPut("{id}")]
		public async Task<Employee> Put(int id, Employee value)
		{
			var ofindOb =  _oEmployees.Where(x=>x.Id==id).FirstOrDefault();	
			if (ofindOb != null)
			{
				ofindOb.Name = value.Name;
				ofindOb.Salary = value.Salary;
				ofindOb.Id = value.Id;
				ofindOb.JoinDate = value.JoinDate;
			}

			return ofindOb;
		}


		[HttpDelete("{id}")]
		public async Task<List<Employee>> Delete(int id)
		{
			var ofindOb = _oEmployees.Where(x => x.Id == id).FirstOrDefault();
			_oEmployees.Remove(ofindOb);

			return  _oEmployees;
		}
	}
}
