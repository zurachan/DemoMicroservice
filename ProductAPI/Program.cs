using Microsoft.EntityFrameworkCore;
using ProductAPI.Domains;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
//services cors
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));
//var dbhost = "localhost";
//var dbname = "dms_product";
//var dbpwd = "";
var dbhost = Environment.GetEnvironmentVariable("DB_HOST");
var dbname = Environment.GetEnvironmentVariable("DB_NAME");
var dbpwd = Environment.GetEnvironmentVariable("DB_ROOT_PASSWORD");
var connectionStr = $"server={dbhost};port=3306; database={dbname};user=root; password={dbpwd}";
builder.Services.AddDbContext<ProductDbContext>(op => op.UseMySQL(connectionStr));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app cors
app.UseCors("corsapp");

app.UseAuthorization();

app.MapControllers();

app.Run();
