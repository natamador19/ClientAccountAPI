using ClientAccountAPI.Web.Interfaces;
using ClientAccountAPI.Web.Model.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClientAccountAPI.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;
        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerDto customerDto)
        {
            var customer = await customerService.CreateCustomer(customerDto);
            return CreatedAtAction(nameof(GetCustomerById), new { id = customer.id }, customer);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await customerService.GetCustomerByIdAsync(id);
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }
    }
}
