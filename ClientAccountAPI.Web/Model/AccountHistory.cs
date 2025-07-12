using System; 

using System.Collections.Generic;

namespace ClientAccountAPI.Web.Model
{
    public class AccountHistory{
        public Guid id { get; set; } = Guid.NewGuid();
        public decimal accountNumber {get; set;}
        public String transactionId {get; set;}
        public decimal transactionAmmount {get;set;}
        public decimal balance {get; set;}

        public DateTime? createdDate {get; set;}
    }

}