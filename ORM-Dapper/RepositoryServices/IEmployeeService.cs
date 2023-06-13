namespace ORM_Dapper.RepositoryServices
{
	public interface IEmployeeService
	{
		Employee Add(Employee employee);
		string Delete(int id);
		List<Employee> GetAll();
		Employee Get(int id);
			
	}
}
