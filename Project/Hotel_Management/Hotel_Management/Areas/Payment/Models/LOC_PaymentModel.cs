using Hotel_Management.Areas.PaymentMethod.Models;

namespace Hotel_Management.Areas.Payment.Models
{
    public class LOC_PaymentModel
    {
        public int? PaymentID { get; set; }
        public int? BookingID { get; set; }
        public int? UserID { get; set; }
        public int? PaymentMethodID { get; set; }
        public string? Method {  get; set; }
        public decimal? Amount { get; set; }
        public string? RegistrationName { get; set; }
        public int? TotalDays { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public List<LOC_PaymentMethodModel> paymentmethods { get; set; }
    }
}
