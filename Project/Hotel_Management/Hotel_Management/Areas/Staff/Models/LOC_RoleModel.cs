namespace Hotel_Management.Areas.Staff.Models
{
    public class LOC_RoleModel
    {
        public int? RoleID { get; set; }
        public string? Role { get; set; }
        public int SelectedRoleID { get; set; }
        public List<LOC_RoleModel> roles { get; set; }
    }
}
