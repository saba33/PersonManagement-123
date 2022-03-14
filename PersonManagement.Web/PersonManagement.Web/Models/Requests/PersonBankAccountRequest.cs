namespace PersonManagement.Web.Models.Requests
{
    public class PersonBankAccountRequest
    {
        public string IBAN { get; set; }
        public string CCY { get; set; }
        public int Amount { get; set; }
    }
}
