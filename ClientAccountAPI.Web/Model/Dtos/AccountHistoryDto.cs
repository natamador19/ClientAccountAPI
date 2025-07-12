using System;

namespace ClientAccountAPI.Web.Model.Dtos { 
    public class AccountHistoryDto
    {
        public int accountNumber { get; set; }
        public String transactionId { get; set; }
        public decimal transactionAmmount { get; set; }
        public decimal balance { get; set; }

        public DateTime createdAt { get; set; }
    }

}