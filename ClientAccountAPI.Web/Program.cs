using ClientAccountAPI.Web.Data;
using ClientAccountAPI.Web.Interfaces;
using ClientAccountAPI.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// ---------------------
// Servicios
// ---------------------

// Agregar EF Core con SQLite
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlite("Data Source=banking.db"));

// Agregar controladores
builder.Services.AddControllers();



// Agregar Swagger para documentación de API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ---------------------
// Construcción de la App
// ---------------------
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IBankAccountService, BankAccountService>();
builder.Services.AddScoped<ITransactionsService, TransactionService>();

var app = builder.Build();

// ---------------------
// Middleware
// ---------------------

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
