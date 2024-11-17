using CustomerAPI.Domain;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));

//
//var dbhost = "babe\\SQLEXPRESS";
//var dbname = "dms_customer";
//var dbpwd = "Abcde12345";
var dbhost = Environment.GetEnvironmentVariable("DB_HOST");
var dbname = Environment.GetEnvironmentVariable("DB_NAME");
var dbpwd = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
var connectionStr = $"Server={dbhost}; Initial Catalog={dbname};User ID=sa; Password={dbpwd};TrustServerCertificate=True";
builder.Services.AddDbContext<CustomerDbContext>(op => op.UseSqlServer(connectionStr));

//
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
