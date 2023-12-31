namespace Hotel_Management.Areas.User.Models
{
    public class LOC_UserModel
    {
        public int? UserID { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? UserNumber { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsAdmin { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set;}

    }
}
