using ClientAccountAPI.Web.Model.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientAccountAPI.Web.Interfaces
{
    public interface IBankAccountService
    {
        Task<BankAccountDto> CreateBankAccountAsync(BankAccountDto dto);
        Task<BankAccountDto> GetBankAccountByNumberAsync(decimal accountNumber);
       
    }
}
