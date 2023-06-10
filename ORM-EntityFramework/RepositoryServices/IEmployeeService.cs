namespace ORM_EntityFramework.RepositoryServices
{
	public interface IEmployeeService
	{
		List<Employee> Gets();
		Employee Get(int id);
		Employee Create(Employee oEmployee);
		Employee Update(int id, Employee oEmployee);
		string Delete(int id);
	}
}
