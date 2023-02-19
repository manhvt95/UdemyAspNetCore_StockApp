using StockApp.Core.Dto;

namespace StockApp.Core.ServiceContracts
{
	/// <summary>
	/// Contract interface for stock trading services
	/// </summary>
	public interface IStockService
	{
		/// <summary>
		/// Create new buy order
		/// </summary>
		/// <param name="buyOrderRequest">BuyOrderRequest from inputs</param>
		/// <returns>BuyOrderResponse from returning response</returns>
		Task<BuyOrderResponse> CreateBuyOrder(BuyOrderRequest? buyOrderRequest);
		/// <summary>
		/// Create new sell order
		/// </summary>
		/// <param name="buyOrderRequest">SellOrderRequest from inputs</param>
		/// <returns>SellOrderResponse from returning response</returns>
		Task<SellOrderResponse> CreateSellOrder(SellOrderRequest? sellOrderRequest);
		/// <summary>
		/// Get all buy orders
		/// </summary>
		/// <returns>List of BuyOrderResponse from returning</returns>
		Task<List<BuyOrderResponse>> GetBuyOrders();
		/// <summary>
		/// Get all sell orders
		/// </summary>
		/// <returns>List of SellOrderResponse from returning</returns>
		Task<List<SellOrderResponse>> GetSellOrders();
	}
}
