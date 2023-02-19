using Microsoft.EntityFrameworkCore;
using StockApp.Core.Domain.Entities;
using StockApp.Core.Domain.RepositoryContracts;

namespace StockApp.Infrastructure.Repositories
{
	/// <summary>
	/// Repository class of StockService
	/// </summary>
	public class StockRepository : IStockRepository
	{
		private readonly StockAppDbContext _dbContext; //DbContext object
		/// <summary>
		/// StockRepository Contructor
		/// </summary>
		/// <param name="dbContext">DbContext object</param>
		public StockRepository(StockAppDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		/// <summary>
		/// Add new BuyOrder record
		/// </summary>
		/// <param name="buyOrder">BuyOrder from request</param>
		/// <returns>BuyOrder</returns>
		public async Task<BuyOrder> AddBuyOrder(BuyOrder buyOrder)
		{
			// Add new BuyOrder record
			_dbContext.BuyOrders.Add(buyOrder);
			await _dbContext.SaveChangesAsync();

			return buyOrder;
		}
		/// <summary>
		/// Add new SellOrder record
		/// </summary>
		/// <param name="sellOrder">SellOrder from request</param>
		/// <returns>SellOrder to response</returns>
		public async Task<SellOrder> AddSellOrder(SellOrder sellOrder)
		{
			// Add new SellOrder record
			_dbContext.SellOrders.Add(sellOrder);
			await _dbContext.SaveChangesAsync();

			return sellOrder;
		}
		/// <summary>
		/// Get all BuyOrder records
		/// </summary>
		/// <returns>List of all BuyOrder</returns>
		public async Task<List<BuyOrder>> GetAllBuyOrders()
		{
			return await _dbContext.BuyOrders.ToListAsync();
		}
		/// <summary>
		/// Get all SellOrder records
		/// </summary>
		/// <returns>List of all SellOrder</returns>
		public async Task<List<SellOrder>> GetAllSellOrders()
		{
			return await _dbContext.SellOrders.ToListAsync();
		}
	}
}
