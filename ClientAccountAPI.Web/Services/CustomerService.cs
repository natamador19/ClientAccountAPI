using System;
using ClientAccountAPI.Web.Data;
using ClientAccountAPI.Web.Interfaces;
using ClientAccountAPI.Web.Model;
using ClientAccountAPI.Web.Model.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ClientAccountAPI.Web.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly DatabaseContext _context;

        public CustomerService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Customer> CreateCustomer(CustomerDto dto)
        {
            var customer = new Customer
            {
                name = dto.name,
                Birthdate = dto.birthDate,
                CardIdentificacion=dto.cardId,
                Gender = dto.gender,
                Income = dto.income
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return customer;
        }


        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _context.Customers
                .Include(c => c.id)
                .FirstOrDefaultAsync(c => c.id == id);
        }
    }
}