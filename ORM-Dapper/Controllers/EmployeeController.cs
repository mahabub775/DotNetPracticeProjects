using Microsoft.AspNetCore.Mvc;
using ORM_Dapper.RepositoryServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ORM_Dapper.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{

		private readonly IEmployeeService _IempoyeeService;

		public EmployeeController(IEmployeeService IempoyeeService) { 
		_IempoyeeService= IempoyeeService;
		}
		
		// GET: api/<EmployeeController>
		[HttpGet]
		public async Task<List<Employee>> Get()
		{
			return _IempoyeeService.GetAll();
		}

		// GET api/<EmployeeController>/5
		[HttpGet("{id}")]
		public async Task<Employee> Get(int id)
		{
			return _IempoyeeService.Get(id);
		}

		// POST api/<EmployeeController>
		[HttpPost]
		public async Task<Employee> Post(Employee oEmployee)
		{
			return _IempoyeeService.Add(oEmployee);
		}

		// PUT api/<EmployeeController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<EmployeeController>/5
		[HttpDelete("{id}")]
		public string Delete(int id)
		{
			return _IempoyeeService.Delete(id);
		}
	}
}
