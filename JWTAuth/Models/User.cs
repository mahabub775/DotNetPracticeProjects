namespace JWTAuth.Models
{
	public class User
	{
		public int Id { get; set; }
		public string SurName { get; set; }
		public string UserName { get; set; }
		public string EmailAddress { get; set; }
		public string Password { get; set; }
		public string PhoneNumber { get; set; }
		public string Role { get; set; }
		
	}
}
