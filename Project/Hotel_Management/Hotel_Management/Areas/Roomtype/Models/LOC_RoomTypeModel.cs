using System.ComponentModel.DataAnnotations;

namespace Hotel_Management.Areas.Roomtype.Models
{
    public class LOC_RoomTypeModel
    {
        public int? RoomTypeID { get; set; }
        public int? UserID { get; set; }

        [Required(ErrorMessage = "The TypeName field is required.")]
        [StringLength(50, ErrorMessage = "The TypeName must be between 1 and 50 characters.", MinimumLength = 1)]
        public string? TypeName { get; set; }
        [Required(ErrorMessage ="Description is required")]
        [StringLength(500, ErrorMessage = "The Description must be at most 500 characters.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "The PricePerDay field is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "The PricePerDay must be a positive number.")]
        public decimal? PricePerDay { get; set; }

        [Display(Name = "Created Date")]
        public DateTime? Created { get; set; }

        [Display(Name = "Modified Date")]
        public DateTime? Modified { get; set; }
    }
}

