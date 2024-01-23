namespace Hotel_Management.Areas.Room.Models
{
    public class LOC_RoomModel
    {
        public int? RoomID { get; set; }
        public int? HotelID { get; set; }
        public int? RoomTypeID { get; set; }
        public int? StatusID { get; set; }
        public int? UserID { get; set; }
        public int? ChildCapacity { get; set; }
        public int? AdultCapacity { get; set; }
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public string? RoomImage { get; set; }
        public string? TypeName { get; set; }
        public string? Status {  get; set; }
        public string? UserName { get; set; }
        public string? HotelName { get; set;}
        public List<LOC_RoomStatusModel> status { get; set; }
        public List<LOC_RoomTypeModel> Typenames { get; set; }

    }
}
