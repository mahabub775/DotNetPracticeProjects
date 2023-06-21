using Cashing.RepositoryServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
namespace Cashing.Controllers
{
	
	[ApiController]
	[Route("[controller]")]
	public class EmployeeController : ControllerBase
	{
		private readonly IEmployeeService _oEmployeeService ;
		private readonly IMemoryCache _Memorycash;
		private readonly MyMemoryCash _myMemorycash;
		public EmployeeController(IEmployeeService iEmployeeService, IMemoryCache memoryCache) 
		{ 
			_oEmployeeService = iEmployeeService;
			_Memorycash = memoryCache;
		}
	
		//using cashing
		[HttpGet]
		public async Task<List<Employee>> Gets()
		{
			if (_Memorycash.TryGetValue("myKey", out List<Employee> cachedData))
			{
				return cachedData;
			}
			else
			{
				var oResult =_oEmployeeService.Gets();
				_Memorycash.Set("myKey", oResult, TimeSpan.FromMinutes(2));
				return oResult;
			}
			//_myMemorycash.Cache.Remove(CacheKeys.Entry);


		}

		// GET api/<EmployeeController>/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Employee>> Get(int id)
		{
			var oResult = _oEmployeeService.Get(id);
			if (oResult == null)	
				return NotFound("Data Not Found");
			return Ok(oResult);
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
