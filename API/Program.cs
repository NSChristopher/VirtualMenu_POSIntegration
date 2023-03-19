using Microsoft.EntityFrameworkCore;
using VirtualMenu.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MenuContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("MenuDBConnection")));

builder.Services.AddHttpClient("meta", c =>
{
    c.BaseAddress = new Uri(builder.Configuration.GetValue<string>("APISettings:APIUrl"));
    c.DefaultRequestHeaders.Add("apikey", builder.Configuration.GetValue<string>("APISettings:APIKey"));
    c.DefaultRequestHeaders.Add("accept", "application/json");
});


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
