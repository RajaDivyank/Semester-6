using Hotel_Management.Areas.Room.Models;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Management.Areas.Booking.Models
{
    public class LOC_BookingModel
    {
        public int? BookingID { get; set; }
        public int? RoomID { get; set; }
        public int? UserID { get; set; }
        public string? TypeName { get; set; }
        public int? ChildCapacity { get; set; }
        public int? AdultCapacity { get; set; }
        public string? RoomImage { get; set; }
        public string? Description { get; set; }
        public double? PricePerDay { get; set; }
        public string? BookingStatus { get; set; }
        public string? SpecialRequest { get; set; }

        [Required(ErrorMessage = "Check-in date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Check-in")]
        public DateTime? CheckIn { get; set; }

        [Required(ErrorMessage = "Check-out date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Check-out")]
        public DateTime? CheckOut { get; set; }

        [Required(ErrorMessage = "TotalDays is required")]
        public int? TotalDays { get; set; }

        [Required(ErrorMessage = "Registration name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Registration name must be between 2 and 100 characters")]
        public string? RegistrationName { get; set; }

        [Required(ErrorMessage = "Mobile number is required")]
        [StringLength(10, ErrorMessage = "Number must be 10 digit", MinimumLength = 10)]
        public string? MobileNumber { get; set; }

        [Required(ErrorMessage = "ID proof name is required")]
        public string? IdProofName { get; set; }
        public string? IdProofphoto { get; set; }

        public IFormFile? IdProofFile { get; set; }

        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public List<LOC_RoomModel> rooms {  get; set; }
    }
}
