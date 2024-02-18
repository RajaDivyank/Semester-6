using System.ComponentModel.DataAnnotations;

namespace Hotel_Management.Areas.Roomstatus.Models
{
    public class LOC_RoomStatusModel
    {
        public int? StatusID { get; set; }
        public int? UserID { get; set; }
        [Required(ErrorMessage = "Status is required")]
        public string? Status {  get; set; }
        public DateTime? Created {  get; set; }
        public DateTime? Modified { get; set; }
    }
}
