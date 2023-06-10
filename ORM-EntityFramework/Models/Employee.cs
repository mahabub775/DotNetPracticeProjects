using System.ComponentModel.DataAnnotations.Schema;

namespace ORM_EntityFramework.Models
{
	public class Employee
	{
		public Employee()
		{
			Id = 0;
			Name = "";
			Salary = 0;
			JoinDate = DateTime.Today;
			ErrorMessage = string.Empty;
		}
		public string Name { get; set; }
		public int Id { get; set; }
		public decimal Salary { get; set; }
		public DateTime JoinDate { get; set; }

		[NotMapped]
		public string ErrorMessage { get; set; }
	}
}
