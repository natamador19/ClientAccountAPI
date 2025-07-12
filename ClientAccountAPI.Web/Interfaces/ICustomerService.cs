using ClientAccountAPI.Web.Model;
using ClientAccountAPI.Web.Model.Dtos;
using System.Threading.Tasks;


namespace ClientAccountAPI.Web.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> CreateCustomer(CustomerDto dto);
        Task<Customer> GetCustomerByIdAsync(int id);
    }
}