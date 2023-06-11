namespace JWTAuth.RepositoryServices
{
	public interface IUserService
	{

		//List<User> Gets();
		//User Login(UserLogin userlogin);
		User Get(UserLogin userLogin);
		//User Registration(User oUser);
		//string Delete(int id);
	}
}
