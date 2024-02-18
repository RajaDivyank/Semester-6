using Hotel_Management.Areas.Role.Models;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Management.Areas.Staff.Models
{
    public class LOC_StaffModel
    {
        public int? StaffID { get; set; }
        [Required(ErrorMessage ="Role is required")]
        public int? RoleID { get; set; }
        public int? UserID { get; set; }
        [Required(ErrorMessage = "First name is required")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        public string? LastName { get; set; }
        public string? Role {  get; set; }
       /* [Required(ErrorMessage ="Image is required")]*/
        public string? StaffImage { get; set; }
        public IFormFile? StaffImageFile { get; set; }
        [Required(ErrorMessage = "Salary is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive value")]
        public decimal? Salary { get; set; }
        [Required(ErrorMessage = "Date of birth is required")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }
        [Required(ErrorMessage = "Staff number is required")]
        [StringLength(10,ErrorMessage ="Number must be 10 digit", MinimumLength = 10)]
        public string? StaffNumber { get; set; }
        [Required(ErrorMessage = "Staff email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? StaffEmail { get; set; }
        [Required(ErrorMessage = "Date of joining is required")]
        [DataType(DataType.Date)]
        public DateTime? DateOfJoining { get; set; }
        [Required(ErrorMessage = "ID name is required")]
        public string? IDProof {  get; set; }
        public IFormFile? IDProofPhotoFile { get; set; }
       /* [Required(ErrorMessage = "Image is required")]*/
        public string? IDProofPhotoPath { get; set; }
        public DateTime? Created {  get; set; }
        public DateTime? Modified { get; set; }
        public List<LOC_RoleModel> roles { get; set; }
        
    }
}
