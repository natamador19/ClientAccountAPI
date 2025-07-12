using ClientAccountAPI.Web.Model;
using ClientAccountAPI.Web.Model.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientAccountAPI.Web.Interfaces
{
    public interface ITransactionsService
    {
        Task<AccountHistory> CreateDeposit(AccountHistoryDto transaction);
        Task<AccountHistory> CreateWithdraw(AccountHistoryDto transaction);
        Task<List<AccountHistory>> GetTransactionsByAccountNumber(decimal accountNumber);
    }
}
