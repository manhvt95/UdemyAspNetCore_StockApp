using StockApp.Core.Domain.Entities;

namespace StockApp.Core.Domain.RepositoryContracts
{
	/// <summary>
	/// StockRepository contract interface
	/// </summary>
	public interface IStockRepository
	{
		/// <summary>
		/// Add BuyOrder into Database
		/// </summary>
		/// <param name="buyOrder">BuyOrder</param>
		/// <returns>Insert new record to [dbo].[BuyOrder]</returns>
		Task<BuyOrder> AddBuyOrder(BuyOrder buyOrder);
		/// <summary>
		/// Add SellOrder into Database
		/// </summary>
		/// <param name="sellOrder">SellOrder</param>
		/// <returns>Insert new record to [dbo].[SellOrder]</returns>
		Task<SellOrder> AddSellOrder(SellOrder sellOrder);
		/// <summary>
		/// Get all records of BuyOrder from Database
		/// </summary>
		/// <returns>List of all BuyOrder(s)</returns>
		Task<List<BuyOrder>> GetAllBuyOrders();
		/// <summary>
		/// Get all records of SellOrder from Database
		/// </summary>
		/// <returns>List of all SellOrder(s)</returns>
		Task<List<SellOrder>> GetAllSellOrders();
	}
}
