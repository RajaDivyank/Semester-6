using Hotel_Management.Areas.Roomstatus.Models;
using Hotel_Management.Areas.Roomtype.Models;

namespace Hotel_Management.Areas.Room.Models
{
    public class LOC_RoomModel
    {
        public int? RoomID { get; set; }
        public int? RoomTypeID { get; set; }
        public int? StatusID { get; set; }
        public int? UserID { get; set; }
        public int? ChildCapacity { get; set; }
        public int? AdultCapacity { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public string? RoomImage { get; set; }
        public IFormFile? RoomImageFile { get; set; }
        public string? TypeName { get; set; }
        public string? Description { get; set; }
        public Decimal? PricePerDay { get; set; }
        public string? Status {  get; set; }
        public string? UserName { get; set; }
        public List<LOC_RoomStatusModel>? status { get; set; }
        public List<LOC_RoomTypeModel>? typenames { get; set; }

    }
}
