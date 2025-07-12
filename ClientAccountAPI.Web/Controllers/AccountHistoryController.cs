using ClientAccountAPI.Web.Interfaces;
using ClientAccountAPI.Web.Model.Dtos;
using ClientAccountAPI.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ClientAccountAPI.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountHistoryController : ControllerBase
    {
        private readonly ITransactionsService transactionService;

        public AccountHistoryController(ITransactionsService transactionService)
        {
            this.transactionService = transactionService;
        }

        [HttpPost("deposito")]
        public async Task<IActionResult> createDeposit([FromBody] AccountHistoryDto dto)
        {
            var response = await transactionService.CreateDeposit(dto);

            return Ok(response);
        }

        [HttpPost("retiro")]
        public async Task<IActionResult> createWithDraw([FromBody] AccountHistoryDto dto)
        {
            var response = await transactionService.CreateWithdraw(dto);

            return Ok(response);
        }

        [HttpGet("history/{accountNumber}")]
        public async Task<IActionResult> GetTransactionHistory(decimal accountNumber)
        {
            var transactions = await transactionService.GetTransactionsByAccountNumber(accountNumber);
            if (transactions == null || !transactions.Any())
                return NotFound("No se encontraron transacciones para esta cuenta.");

            return Ok(transactions);
        }


    }
}
