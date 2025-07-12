namespace ClientAccountAPI.Web.Model.Dtos
{
    public class BankAccountDto
    {
        public decimal accountNumber { get; set; }
        public string customerNumber { get; set; }
        public decimal accountBalance { get; set; }
        public int accountTypeId { get; set; }
        public string creationDate { get; set; }
    }
}
