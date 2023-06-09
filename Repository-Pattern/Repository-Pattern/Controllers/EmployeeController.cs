using Repository_Pattern.RepositoryService;
using Microsoft.AspNetCore.Mvc;

namespace DonetCoreAPI.APICollection
{
	
	[ApiController]
	[Route("[controller]")]
	public class EmployeeController : ControllerBase
	{
		private readonly IEmployeeService _oEmployeeService ;
		public EmployeeController(IEmployeeService iEmployeeService) 
		{ 
			_oEmployeeService = iEmployeeService;
		}
	

		[HttpGet]
		public async Task<List<Employee>> Gets()
		{
			var oResult = _oEmployeeService.Gets();
			return oResult;
		}

		// GET api/<EmployeeController>/5
		[HttpGet("{id}")]
		public async Task<Employee> Get(int id)
		{
			var oResult = _oEmployeeService.Get(id);
			if(oResult==null)
				return null;
			return oResult;
		}

		[HttpPost]
		public async Task<Employee> AddEmployee(Employee value)
		{
			Employee employee = new Employee();
			try
			{
				employee = _oEmployeeService.Create(value);
			}catch(Exception ex)
			{
				employee.ErrorMessage = ex.Message;
				
			}
			return employee;
		}

		// PUT api/<EmployeeController>/5
		[HttpPut("{id}")]
		public async Task<Employee> Put(int id, Employee value)
		{
			var oResult =  _oEmployeeService.Update(id, value);

			return oResult;
		}


		[HttpDelete("{id}")]
		public async Task<string> Delete(int id)
		{
			var sresult = _oEmployeeService.Delete(id);			

			return sresult;
		}
	}
}
