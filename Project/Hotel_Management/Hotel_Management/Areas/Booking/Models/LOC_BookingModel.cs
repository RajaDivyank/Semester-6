namespace Hotel_Management.Areas.Booking.Models
{
    public class LOC_BookingModel
    {
        public int? BookingID { get; set; }
        public int? RoomID { get; set; }
        public int? UserID { get; set; }
        public DateTime? CheckIn {  get; set; }
        public DateTime? CheckOut {  get; set; }
        public int? TotalDays { get; set; }
        public string? RegistrationName { get; set; }
        public string? MobileNumber { get; set; }
        public string? IdProofName { get; set; }
        public string? IdProofphoto { get; set; }
        public IFormFile? IdProofFile { get; set; }
        public DateTime? Created {  get; set; }
        public DateTime? Modified { get; set;}
    }
}
