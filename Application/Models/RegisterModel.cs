using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
	public class RegisterModel
	{
		[Required(ErrorMessage = "First name is a required field.")]
		public string Firstname { get; set; }

		[Required(ErrorMessage = "Last name is a required field.")]
		public string Lastname { get; set; }

		public string? Middlename { get; set; }

		[Required(ErrorMessage = "Email address is a required field.")]
		[EmailAddress(ErrorMessage = "Invalid email address.")]
		[Display(Name ="Email Address")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Country is a required field.")]
		public string Country { get; set; }

		[Required(ErrorMessage = "Address is a required field.")]
		public string Address { get; set; }

		[Required(ErrorMessage = "Mobile number is a required field.")]
		[StringLength(10, MinimumLength = 10, ErrorMessage = "Mobile number must be exactly 10 digits.")]
		[Phone(ErrorMessage = "Invalid mobile number.")]
		[Display(Name = "Mobile Number")]
		public string MobileNumber { get; set; }


		[Required(ErrorMessage = "Password is a required field.")]
		[MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
		[Display(Name = "Password")]
		public string Password1 { get; set; }

		[Required(ErrorMessage = "Confirm password is a required field.")]
		[Compare("Password1", ErrorMessage = "Passwords do not match.")]
		[Display(Name = "Confirm Password")]
		public string Password2 { get; set; }
	}
}
