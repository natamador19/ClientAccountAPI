using ClientAccountAPI.Web.Interfaces;
using ClientAccountAPI.Web.Model.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClientAccountAPI.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankAccountController : ControllerBase
    {
        private readonly IBankAccountService service;

        public BankAccountController(IBankAccountService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] BankAccountDto dto)
        {
            var created = await service.CreateBankAccountAsync(dto);
            return CreatedAtAction(nameof(GetByNumber), new { accountNumber = created.accountNumber }, created);
        }

        [HttpGet("{accountNumber}")]
        public async Task<IActionResult> GetByNumber(decimal accountNumber)
        {
            var account = await service.GetBankAccountByNumberAsync(accountNumber);
            if (account == null)
                return NotFound();

            return Ok(account);
        }

       
    }
}
