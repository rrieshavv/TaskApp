using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
	public class LoginModel
	{
		[Required(ErrorMessage = "Email Address is a required field.")]
		[Display(Name ="Email Address")]
		[EmailAddress(ErrorMessage = "Invalid email address.")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Password is a required field.")]
		[MinLength(8, ErrorMessage ="Password must be atleast 8 characters long.")]
		public string Password { get; set; }
	}
}
