using System.ComponentModel.DataAnnotations;

namespace WPAssign.Controllers
{
	
	public partial class UsersController
	{
		public class LoginRequestModel
		{
			[Required]
			public string Password { get;  set; }
			[Required]
			public string Username { get;  set; }
		}
		public class RegisterRequestModel
		{
			[Required]
			public string Username { get; set; }
			[Required]
			public string Password { get; set; }
			[Required]
			public string Name { get; set; }
			public string EmailId { get; set; }
			public string PhoneNumber { get; set; }
		}
	}
}