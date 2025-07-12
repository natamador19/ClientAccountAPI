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
    public class BankAccountService : IBankAccountService
    {
        private readonly DatabaseContext _context;

        public BankAccountService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<BankAccountDto> CreateBankAccountAsync(BankAccountDto dto)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.CardIdentificacion.Equals(dto.customerNumber));
            if (customer == null) {
                throw new Exception("No se encontro el cliente con ese número de identidad");
                    }
            var bankAccount = new BankAccount
            {
                accountNumber = await GetAccountNumber(),
                customerNumber = customer.id,
                accountBalance = dto.accountBalance,
                accountTypeId = dto.accountTypeId,
                creationDate = dto.creationDate ?? DateTime.UtcNow.ToString("yyyy-MM-dd")
            };

            _context.BankAccounts.Add(bankAccount);
            await _context.SaveChangesAsync();
            dto.accountNumber = bankAccount.accountNumber;

            return dto;
        }

        public async Task<BankAccountDto> GetBankAccountByNumberAsync(decimal accountNumber)
        {
            var acc = await _context.BankAccounts.FirstOrDefaultAsync(b => b.accountNumber == accountNumber);

            if (acc == null) return null;

            return new BankAccountDto
            {
                accountNumber = acc.accountNumber,
                customerNumber = acc.customerNumber.ToString(),
                accountBalance = acc.accountBalance,
                accountTypeId = acc.accountTypeId,
                creationDate = acc.creationDate
            };
        }

        private async Task<decimal> GetAccountNumber()
        {
            decimal accountNumber;
            bool exists;

            do
            {
                var random = new Random();
                accountNumber = random.Next(100000, 999999);
                exists = await _context.BankAccounts.AnyAsync(b => b.accountNumber == accountNumber);
            }
            while (exists);

            return accountNumber;
        }


    }
}
