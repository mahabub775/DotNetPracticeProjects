using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTAuth.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserService _iuserService;
		private readonly IConfiguration _config;
		public UserController(IUserService iuserService, IConfiguration config)
		{
			_iuserService = iuserService;
			_config = config;
		}

		[HttpPost]
	   public async Task<IActionResult> Login(UserLogin userLogin)
		{
			if (userLogin!=null && userLogin.UserName!= null && userLogin.Password != null)
			{
				var loggedInUser = _iuserService.Get(userLogin);
				if (loggedInUser is null)
					return NotFound("user Not Found");
				var claims = new[]
				{
					new Claim(ClaimTypes.NameIdentifier, loggedInUser.UserName),
					new Claim(ClaimTypes.Email, loggedInUser.EmailAddress),
					new Claim(ClaimTypes.Name, loggedInUser.SurName),
					new Claim(ClaimTypes.Role, loggedInUser.Role),
					new Claim(ClaimTypes.MobilePhone, loggedInUser.PhoneNumber)

				};
				var token = new JwtSecurityToken
					(
					issuer: _config["Jwt:Issuer"],
					audience: _config["Jwt:Audiance"],
					claims: claims,
					expires: DateTime.Now.AddMinutes(30),
					notBefore: DateTime.Now,
					signingCredentials: new SigningCredentials(
						new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"])),
					SecurityAlgorithms.HmacSha256)
					);
				var tokenstring = new JwtSecurityTokenHandler().WriteToken(token);

				return Ok(tokenstring);
			}
			else if (userLogin==null || string.IsNullOrEmpty(userLogin.UserName))
			{
				return BadRequest("Invalid User Name");
			}
			else 
			{
				return BadRequest("Invalid Password");
			}

		}
	}
}
