using System; 


namespace ClientAccountAPI.Web.Model
{
    public class BankAccount{
        public Guid Id { get; set; } = Guid.NewGuid();
        public decimal accountNumber { get; set; }
        public int customerNumber {get; set;}
        public decimal accountBalance {get; set;}
        public int accountTypeId {get; set;}
        public string creationDate {get; set;}
    }
}