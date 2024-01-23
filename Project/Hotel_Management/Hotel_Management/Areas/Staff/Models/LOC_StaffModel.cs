namespace Hotel_Management.Areas.Staff.Models
{
    public class LOC_StaffModel
    {
        public int? StaffID { get; set; }
        public int? RoleID { get; set; }
        public int? UserID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Role {  get; set; }
        public string? StaffImage { get; set; }
        public IFormFile? StaffImageFile { get; set; }
        public decimal? Salary { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? StaffNumber { get; set; }
        public string? StaffEmail { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public string? IDProof {  get; set; }
        public IFormFile? IDProofPhotoFile { get; set; }
        public string? IDProofPhotoPath { get; set; }
        public DateTime? Created {  get; set; }
        public DateTime? Modified { get; set; }
        public List<LOC_RoleModel> roles { get; set; }
        
    }
}
