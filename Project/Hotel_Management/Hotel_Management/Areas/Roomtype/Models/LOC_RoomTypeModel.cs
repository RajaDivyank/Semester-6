namespace Hotel_Management.Areas.Roomtype.Models
{
    public class LOC_RoomTypeModel
    {
        public int? RoomTypeID { get; set; }
        public string? TypeName { get; set;}
        public string? Description { get; set;}
        public decimal? PricePerDay { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}
