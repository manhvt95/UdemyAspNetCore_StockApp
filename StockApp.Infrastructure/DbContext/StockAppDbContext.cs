using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Options;
using StockApp.Core.Domain.Entities;

namespace StockApp.Infrastructure
{
	/// <summary>
	/// StockAppDbContext class
	/// </summary>
	public class StockAppDbContext : DbContext
	{
		/// <summary>
		/// Inheritance constructor
		/// </summary>
		/// <param name="options"></param>
		public StockAppDbContext(DbContextOptions options) : base(options)
		{
				
		}

		// DB Sets
		public DbSet<BuyOrder> BuyOrders { get; set; }
		public DbSet<SellOrder> SellOrders { get; set; }
	}
}
