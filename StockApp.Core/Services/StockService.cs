using StockApp.Core.Dto;
using StockApp.Core.Domain.Entities;
using StockApp.Core.ServiceContracts;
using StockApp.Core.Domain.RepositoryContracts;
using System.Collections.Generic;
using StockApp.Core.Extensions;
using StockApp.Core.Helper;

namespace StockApp.Core.Services
{
	/// <summary>
	/// Service of Stock
	/// </summary>
	public class StockService : IStockService
	{
		#region Variables
		private readonly IStockRepository _stockRepository;
		#endregion

		#region Methods
		/// <summary>
		/// Contructor of StockService
		/// </summary>
		/// <param name="stockRepository">Stock Repository contracts</param>
		public StockService(IStockRepository stockRepository)
		{
			_stockRepository = stockRepository;
		}
		/// <summary>
		/// Create new Buy Order
		/// </summary>
		/// <param name="buyOrderRequest">BuyOrderRequest</param>
		/// <returns>BuyOrderResponse</returns>
		/// <exception cref="ArgumentNullException">Exception when BuyOrderRequest is null</exception>
		/// <exception cref="ArgumentException">Exception when validation is failed</exception>
		public async Task<BuyOrderResponse> CreateBuyOrder(BuyOrderRequest? buyOrderRequest)
		{
			// Inputs validation
			if (buyOrderRequest == null)
			{
				throw new ArgumentNullException($"{0} can NOT be null", nameof(buyOrderRequest));
			}
			ValidationHelper.ModelValidation(buyOrderRequest);

			// Convert to BuyOrder object
			BuyOrder buyOrder = buyOrderRequest.ToBuyOrder();
			buyOrder.BuyOrderId = Guid.NewGuid();

			// Add new buy order
			await _stockRepository.AddBuyOrder(buyOrder);
			return buyOrder.ToBuyOrderResponse();
		}
		/// <summary>
		/// Create new sell order
		/// </summary>
		/// <param name="sellOrderRequest">SellOrderRequest</param>
		/// <returns>SellOrderResponse</returns>
		/// <exception cref="ArgumentNullException">Exception when BuyOrderRequest is null</exception>
		/// <exception cref="ArgumentException">Exception when validation is failed</exception>
		public async Task<SellOrderResponse> CreateSellOrder(SellOrderRequest? sellOrderRequest)
		{
			// Inputs validation
			if (sellOrderRequest == null)
			{
				throw new ArgumentNullException($"{0} can NOT be null", nameof(sellOrderRequest));
			}
			ValidationHelper.ModelValidation(sellOrderRequest);

			// Convert to SellOrder object
			SellOrder sellOrder = sellOrderRequest.ToSellOrder();
			sellOrder.SellOrderId = Guid.NewGuid();

			// Add new sell order
			await _stockRepository.AddSellOrder(sellOrder);
			return sellOrder.ToSellOrderResponse();
		}
		/// <summary>
		/// Get all BuyOrders
		/// </summary>
		/// <returns>List of BuyOrderResponse</returns>
		public async Task<List<BuyOrderResponse>> GetBuyOrders()
		{
			// Get all buy orders
			List<BuyOrder> buyOrders = await _stockRepository.GetAllBuyOrders();
			
			// Return list of BuyOrderResponse order by DateTime
			return buyOrders.OrderByDescending(order => order.DateAndTimeOfOrder)
				.Select(order => order.ToBuyOrderResponse()).ToList();
		}
		/// <summary>
		/// Get all SellOrders
		/// </summary>
		/// <returns>List of SellOrderResponse</returns>
		public async Task<List<SellOrderResponse>> GetSellOrders()
		{
			// Get all sell orders
			List<SellOrder> sellOrders = await _stockRepository.GetAllSellOrders();

			// Return list of BuyOrderResponse order by DateTime
			return sellOrders.OrderByDescending(order => order.DateAndTimeOfOrder)
				.Select(order => order.ToSellOrderResponse()).ToList();
		}
		#endregion
	}
}
