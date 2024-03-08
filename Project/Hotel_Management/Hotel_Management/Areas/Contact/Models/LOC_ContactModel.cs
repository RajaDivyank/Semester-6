using Microsoft.Extensions.Primitives;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Management.Areas.Contact.Models
{
    public class LOC_ContactModel
    {
        public int? ContactID { get; set; }
        public int? UserID { get; set; }
        [Required(ErrorMessage ="Name is required")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Subject is required")]
        public string? Subject { get; set; }
        [Required(ErrorMessage = "Message is required")]
        public string? Message { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }

    }
}
