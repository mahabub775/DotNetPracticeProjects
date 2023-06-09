namespace DonetCoreAPI.Model
{
	public class Employee
	{
		public Employee()
		{
			Id = 0;
			Name = "";
			Salary = 0;
			JoinDate = DateTime.Today;
		}
		public string Name { get; set; }
		public int Id { get; set; }
		public double Salary { get; set; }
		public DateTime JoinDate { get; set; }
	}
}
