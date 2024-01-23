using System.ComponentModel.DataAnnotations;

namespace Hotel_Management.Models
{
	public class SEC_UserModel
	{
		public int? UserID { get; set; }
		public string? UserName { get; set; }
		public string? Password { get; set; }
		public string? UserNumber { get; set; }
		public string? Email { get; set; }
		public DateTime Created { get; set; }
		public DateTime Modified { get; set; }
	}
	public class UserLoginModel
	{
		[Required]
		public string? UserName { get; set; }
		[Required]
		public string? Password { get; set; }

	}
}
