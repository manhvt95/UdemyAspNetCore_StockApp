using StockApp.Core.Dto;
using StockApp.Core.Domain.Entities;

namespace StockApp.Core.Extensions
{
	/// <summary>
	/// Class includes extension method for converting between order Dtoes
	/// </summary>
	public static class OrderDtoConvertorExtensions
	{
		/// <summary>
		/// Extension method: convert SellOrder to SellOrderResponse
		/// </summary>
		/// <param name="sellOrder">SellOrder</param>
		/// <returns>SellOrderResponse</returns>
		public static SellOrderResponse ToSellOrderResponse(this SellOrder sellOrder)
		{
			return new SellOrderResponse()
			{
				StockSymbol = sellOrder.StockSymbol,
				StockName = sellOrder.StockName,
				DateAndTimeOfOrder = sellOrder.DateAndTimeOfOrder,
				Quantity = sellOrder.Quantity,
				Price = sellOrder.Price
			};
		}
		/// <summary>
		/// Extension method: convert BuyOrder to BuyOrderResponse
		/// </summary>
		/// <param name="buyOrder">BuyOrder</param>
		/// <returns>BuyOrderResponse</returns>
		public static BuyOrderResponse ToBuyOrderResponse(this BuyOrder buyOrder)
		{
			return new BuyOrderResponse()
			{
				StockSymbol = buyOrder.StockSymbol,
				StockName = buyOrder.StockName,
				DateAndTimeOfOrder = buyOrder.DateAndTimeOfOrder,
				Quantity = buyOrder.Quantity,
				Price = buyOrder.Price
			};
		}
		/// <summary>
		/// Extension method: convert BuyOrderRequest to BuyOrder
		/// </summary>
		/// <returns>BuyOrder</returns>
		public static BuyOrder ToBuyOrder(this BuyOrderRequest buyOrderRequest)
		{
			return new BuyOrder()
			{
				StockSymbol = buyOrderRequest.StockSymbol,
				StockName = buyOrderRequest.StockName,
				DateAndTimeOfOrder = buyOrderRequest.DateAndTimeOfOrder,
				Quantity = buyOrderRequest.Quantity,
				Price = buyOrderRequest.Price
			};
		}
		/// <summary>
		/// Extension method: convert SellOrderRequest to SellOrder
		/// </summary>
		/// <returns>SellOrder</returns>
		public static SellOrder ToSellOrder(this SellOrderRequest sellOrderRequest)
		{
			return new SellOrder()
			{
				StockSymbol = sellOrderRequest.StockSymbol,
				StockName = sellOrderRequest.StockName,
				DateAndTimeOfOrder = sellOrderRequest.DateAndTimeOfOrder,
				Quantity = sellOrderRequest.Quantity,
				Price = sellOrderRequest.Price
			};
		}
	}
}
