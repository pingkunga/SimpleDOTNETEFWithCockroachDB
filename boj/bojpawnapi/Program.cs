using bojpawnapi.DataAccess;
using bojpawnapi.DTO;
using Microsoft.EntityFrameworkCore;
using bojpawnapi.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddScoped<ICollateralService, CollateralService>();
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

app.Run();
