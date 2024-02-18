using System.ComponentModel.DataAnnotations;
using Hotel_Management.Areas.Roomstatus.Models;
using Hotel_Management.Areas.Roomtype.Models;

namespace Hotel_Management.Areas.Room.Models
{
    public class LOC_RoomModel
    {
        public int? RoomID { get; set; }
        [Required(ErrorMessage = "Type is required")]
        public int? RoomTypeID { get; set; }
        [Required(ErrorMessage = "Status is required")]
        public int? StatusID { get; set; }
        public int? UserID { get; set; }

        [Required(ErrorMessage = "Child Number is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Child Number must be greater than 0")]
        public int? ChildCapacity { get; set; }

        [Required(ErrorMessage = "Adult Number is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Adult Number must be greater than 0")]
        public int? AdultCapacity { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Modified { get; set; }

        [Display(Name = "Room Image")]
        public string? RoomImage { get; set; }

        [Display(Name = "Room Image File")]
        public IFormFile? RoomImageFile { get; set; }

        public string? TypeName { get; set; }

        public string? Description { get; set; }

        public decimal? PricePerDay { get; set; }

        public string? Status { get; set; }

        public string? UserName { get; set; }

        public List<LOC_RoomStatusModel>? status { get; set; }

        public List<LOC_RoomTypeModel>? typenames { get; set; }
    }
}
