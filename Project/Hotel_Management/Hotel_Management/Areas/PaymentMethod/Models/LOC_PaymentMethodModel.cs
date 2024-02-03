namespace Hotel_Management.Areas.PaymentMethod.Models
{
    public class LOC_PaymentMethodModel
    { 
        public int? PaymentMethodID { get; set; }
        public int? UserID { get; set; }
        public string? Method { get; set; }
        public DateTime? Created {  get; set; }
        public DateTime? Modified { get; set; }
    }
}
