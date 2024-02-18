using System.ComponentModel.DataAnnotations;

namespace Hotel_Management.Areas.Role.Models
{
    public class LOC_RoleModel
    {
        public int? RoleID { get; set; }
        public int? UserID { get; set; }
        [Required(ErrorMessage = "Role name is required")]
        public string? Role {  get; set; }
        public DateTime? Created {  get; set; }
        public DateTime? Modified { get; set;}
    }
}
