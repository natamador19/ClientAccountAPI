using ClientAccountAPI.Web.Data;
using ClientAccountAPI.Web.Interfaces;
using ClientAccountAPI.Web.Model;
using ClientAccountAPI.Web.Model.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientAccountAPI.Web.Services
{
    public class TransactionService : ITransactionsService
    {
        private readonly DatabaseContext context;

        public TransactionService(DatabaseContext context)
        {
            this.context = context;
        }

        public async Task<AccountHistory> CreateDeposit(AccountHistoryDto dto)
        {
            var account = await context.BankAccounts
                .FirstOrDefaultAsync(a => a.accountNumber == dto.accountNumber);

            if (account == null)
                throw new Exception("Cuenta no encontrada.");

            account.accountBalance += dto.transactionAmmount;

            var transaction = new AccountHistory
            {
                accountNumber = dto.accountNumber,
                transactionAmmount = dto.transactionAmmount,
                transactionId = "Deposit",
                balance = account.accountBalance,
                createdDate = DateTime.Now
            };

            context.AccountHistory.Add(transaction);
            context.BankAccounts.Update(account);
            await context.SaveChangesAsync();

            return transaction;
        }

        public async Task<AccountHistory> CreateWithdraw(AccountHistoryDto dto)
        {
            var account = await context.BankAccounts
                .FirstOrDefaultAsync(a => a.accountNumber == dto.accountNumber);

            if (account == null)
                throw new Exception("Cuenta no encontrada.");

            if (account.accountBalance < dto.transactionAmmount)
                throw new Exception("Fondos insuficientes.");

            account.accountBalance -= dto.transactionAmmount;

            var transaction = new AccountHistory
            {
                accountNumber = dto.accountNumber,
                transactionAmmount = dto.transactionAmmount,
                transactionId = "Withdraw",
                balance = account.accountBalance,
                createdDate = DateTime.Now
            };

            context.AccountHistory.Add(transaction);
            context.BankAccounts.Update(account);
            await context.SaveChangesAsync();

            return transaction;
        }
        public async Task<List<AccountHistory>> GetTransactionsByAccountNumber(decimal accountNumber)
        {
            var account = await context.BankAccounts
                .FirstOrDefaultAsync(a => a.accountNumber == accountNumber);

            if (account == null) return new List<AccountHistory>();

            return await context.AccountHistory
                .Where(t => t.accountNumber == account.accountNumber)
                .OrderByDescending(t => t.createdDate)
                .ToListAsync();
        }
    }
}
