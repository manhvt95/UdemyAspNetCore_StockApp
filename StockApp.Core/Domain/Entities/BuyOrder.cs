using StockApp.Core.Dto;
using System.ComponentModel.DataAnnotations;

namespace StockApp.Core.Domain.Entities
{
	/// <summary>
	/// Class entity Buy Order
	/// </summary>
	public class BuyOrder
	{
		[Key]
		[Required(ErrorMessage = "The BuyOrderId can NOT be null or empty")]
		public Guid BuyOrderId { get; set; } //Buy order ID
		[Required(ErrorMessage = "The StockSymbol can NOT be null or empty")]
		public string StockSymbol { get; set; } //Stock symbol "MSFT"
		[Required(ErrorMessage = "The StockName can NOT be null or empty")]
		public string StockName { get; set; } // Stock name
		public DateTime DateAndTimeOfOrder { get; set; } // Datetime of buy order
		[Range(1, 100000, ErrorMessage = "The ordered quantity must be in rarnge from 1 to 100000")]
		public uint Quantity { get; set; } // Ordered quantity
		[Range(1, 10000, ErrorMessage = "The ordered price must be in range from 1 to 10000")]
		public double Price { get; set; } // Price
	}
}
