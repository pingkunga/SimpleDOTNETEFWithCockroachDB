using bojpawnapi.DataAccess;
using bojpawnapi.DTO;
using Microsoft.EntityFrameworkCore;
using bojpawnapi.Service;
using HealthChecks.NpgSql;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connString = builder.Configuration.GetConnectionString("BojPawnDbConnection");
builder.Services.AddHealthChecks().AddNpgSql(connString, tags: new[] { "startup" });

// Add services to the container.
builder.Services.AddScoped<ICollateralTxService, CollateralTxService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddDbContext<PawnDBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("BojPawnDbConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/health/ready");
app.MapHealthChecks("/health/startup", new HealthCheckOptions { Predicate = x => x.Tags.Contains("startup") });        

app.Run();
