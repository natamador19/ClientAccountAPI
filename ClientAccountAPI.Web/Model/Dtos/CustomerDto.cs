using System;
namespace ClientAccountAPI.Web.Model.Dtos
{
    public class CustomerDto { 
        public int Id { get; set; }
        public String cardId { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public string birthDate { get; set; }
        public string creationDate { get; set; }
        public decimal income {  get; set; }
    }
}