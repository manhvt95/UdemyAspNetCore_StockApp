using StockApp.Core.Dto;
using System.ComponentModel.DataAnnotations;

namespace StockApp.Core.Domain.Entities
{
	/// <summary>
	/// Class entity of the Sell Order
	/// </summary>
	public class SellOrder
	{
		[Key]
		[Required(ErrorMessage = "The SellOrderId can NOT be null or empty")]
		public Guid SellOrderId { get; set; } // Sell Order ID
		[Required(ErrorMessage = "The StockSymbol can NOT be null or empty")]
		public string StockSymbol { get; set; } // Stock symbol "MSFT"
		[Required(ErrorMessage = "The StockName can NOT be null or empty")]
		public string StockName { get; set; } // Stock name
		public DateTime DateAndTimeOfOrder { get; set; } // Datetime of the order
		[Range(1, 100000, ErrorMessage = "The order quantity must be in range from 1 to 100000")]
		public uint Quantity { get; set; } // Ordered Quantity
		[Range(1, 10000, ErrorMessage = "The ordered price must be in range from 1 to 10000")]
		public double Price { get; set; } // Order price
	}
}
