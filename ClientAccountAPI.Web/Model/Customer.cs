using System; 
using System.Collections.Generic; 

namespace ClientAccountAPI.Web.Model{

    public class Customer{
        public int id {get; set;}
        public string CardIdentificacion { get; set; }
        public string name {get; set;}
        public string Birthdate {get; set;}
        public string Gender {get; set;}
        public decimal Income {get; set;}
    }
}