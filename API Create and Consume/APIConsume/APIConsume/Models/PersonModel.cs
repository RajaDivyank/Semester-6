namespace APIConsume.Models
{
    public class PersonModel
    {
        public int PersonId { get; set; }
        public string PersonName { get; set; } = string.Empty;
        public string PersonContact { get; set; } = string.Empty;
        public string PersonEmail { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
        public string CreditCardNumber { get; set; }
        public decimal Amount { get; set; } 
        public bool CheckedTermsConditions { get; set; }
        public int NoOfFriends { get; set; }
    }
}
