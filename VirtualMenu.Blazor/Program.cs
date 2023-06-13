using VirtualMenu.LingaAPI;
using VirtualMenu.LingaAPI.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using VirtualMenu.Abstractions;
using VirtualMenu.Core.Services;
using VirtualMenu.Data;
using VirtualMenu.Models;
using VirtualMenu.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

//Typed Client
builder.Services.AddHttpClient<IMenuApiService, MenuApiService>();

//inject api settings with singleton so it can be accessed from api
builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettings"));
builder.Services.AddSingleton(x => x.GetRequiredService<IOptions<ApiSettings>>().Value);

//inject api service
builder.Services.AddScoped<IMenuApiService, MenuApiService>();

//inject core service
builder.Services.AddScoped<IMenuCoreService, MenuCoreService>();

//inject dbcontext
builder.Services.AddDbContext<MenuContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("MenuDBConnection"))
                .EnableSensitiveDataLogging());

//inject menu repository
builder.Services.AddScoped<IMenuRepository, MenuRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
