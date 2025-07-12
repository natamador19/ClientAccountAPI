using Microsoft.EntityFrameworkCore;
using ClientAccountAPI.Web.Model;


namespace  ClientAccountAPI.Web.Data{
    public class DatabaseContext : DbContext{

            public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

            public DbSet<Customer> Customers {get; set;}
            public DbSet<BankAccount> BankAccounts {get; set;}
             
            public DbSet<AccountHistory> AccountHistory {get; set;}

            
        
       

            protected override void OnModelCreating(ModelBuilder modelBuilder){
                base.OnModelCreating(modelBuilder);
                
            }
    }
}