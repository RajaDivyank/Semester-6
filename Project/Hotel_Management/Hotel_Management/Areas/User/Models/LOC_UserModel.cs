using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Hotel_Management.Areas.User.Models
{
    public class SEC_UserModel
    {
        public int? UserID { get; set; }
        public bool? IsAdmin { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsManager { get; set; }
        [Required(ErrorMessage ="Name is required")]
        public string? UserName { get; set; }
		[Required(ErrorMessage = "Password is required")]

        public string? Password { get; set; }
		[Required(ErrorMessage = "Number is required")]
		public string? UserNumber { get; set; }
		[Required(ErrorMessage = "Email is required")]
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
