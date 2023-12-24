namespace Hotel_Management.Areas.Hotel.Models
{
    public class LOC_HotelModel
    {
        public int? HotelID { get; set; }
        public string? HotelName { get; set;}
        public string? HotelAddress { get; set; }
        public string? HotelEmail { get; set; }
        public decimal? Rating { get; set; }
        public string? OwnerName { get; set; }
        public string? HotelPhoneNumber { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }

    }
}
