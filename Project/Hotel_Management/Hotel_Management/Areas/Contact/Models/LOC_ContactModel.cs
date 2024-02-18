using Microsoft.Extensions.Primitives;

namespace Hotel_Management.Areas.Contact.Models
{
    public class LOC_ContactModel
    {
        public int? ContactID { get; set; }
        public int? UserID { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }

    }
}
