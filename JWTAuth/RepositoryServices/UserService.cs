namespace JWTAuth.RepositoryServices
{
	public class UserService : IUserService
	{
		#region Declaration
		private static List<User> _oUsers = new List<User> {

			new User { Id = 1, UserName = "Shajid",   SurName = "Shajid Rahman", EmailAddress="shajid@gmail.com", Password = "0002",PhoneNumber="01455252425", Role="Student"},
			new User { Id = 2, UserName = "Abdullah", SurName = "Abdullah Al Mamun", EmailAddress="Abudulah@gmail.com",  Password = "0004",PhoneNumber="012753025", Role="Student"},
			new User {Id = 3, UserName = "Mahabub", SurName = "Mahabub alam", EmailAddress="mahabub@gmail.com", Password = "0005", PhoneNumber = "018751425", Role = "Programmer"}
		};

		#endregion

		#region Implementation
		//public string Delete(int id)
		//{
		//	throw new NotImplementedException();
		//}

		public User Get(UserLogin userLogin)
		{
			User oUser = _oUsers.FirstOrDefault(o=>o.UserName.Equals(userLogin.UserName,StringComparison.OrdinalIgnoreCase) && o.Password.Equals(userLogin.Password));
			return oUser;
		}	

		//public List<User> Gets()
		//{
		//	throw new NotImplementedException();
		//}

		//public User Registration(User oUser)
		//{
		//	throw new NotImplementedException();
		//}
		#endregion
	}
}
