using DonetCoreAPI.Model;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DonetCoreAPI.APICollection
{
	
	[ApiController]
	[Route("[controller]")]
	public class EmployeeController : ControllerBase
	{
		

		List<Employee> _oEmployees = new List<Employee>();

		public EmployeeController() {
			_oEmployees.Add(new Employee() {Name="abudllabn", SalryId = 15,Salary = 150});
			_oEmployees.Add(new Employee() { Name = "Shahin", SalryId = 112, Salary = 350 });
			_oEmployees.Add(new Employee() { Name = "Nazrul", SalryId = 1585, Salary = 250 });
		}

		[HttpGet]
		public ActionResult<Employee> Gets()
		{	

			return Ok(_oEmployees);
		}

		// GET api/<EmployeeController>/5
		[HttpGet("{id}")]
		public async Task<Employee> Get(int id)
		{
			return _oEmployees.Where(x => x.SalryId == id).FirstOrDefault();
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
			var ofindOb =  _oEmployees.Where(x=>x.SalryId==id).FirstOrDefault();	
			if (ofindOb != null)
			{
				ofindOb.Name = value.Name;
				ofindOb.Salary = value.Salary;
				ofindOb.SalryId = value.SalryId;
				ofindOb.JoinDate = value.JoinDate;
			}

			return ofindOb;
		}

		// DELETE api/<EmployeeController>/5
		[HttpDelete("{id}")]
		public async Task<List<Employee>> Delete(int id)
		{
			var ofindOb = _oEmployees.Where(x => x.SalryId == id).FirstOrDefault();
			_oEmployees.Remove(ofindOb);

			return  _oEmployees;
		}
	}
}
