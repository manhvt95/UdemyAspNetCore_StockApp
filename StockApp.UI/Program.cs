using Microsoft.EntityFrameworkCore;
using StockApp.Core.Domain.RepositoryContracts;
using StockApp.Core.Options;
using StockApp.Core.ServiceContracts;
using StockApp.Core.Services;
using StockApp.Infrastructure;
using StockApp.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<StockAppDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.Configure<TradeOptions>(
	builder.Configuration.GetSection(TradeOptions.TRADE_OPTIONS));
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<IFinnhubService, FinnhubService>();
builder.Services.AddScoped<IStockService, StockService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
