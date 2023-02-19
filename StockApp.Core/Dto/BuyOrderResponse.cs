namespace StockApp.Core.Dto
{
	/// <summary>
	/// Dto class represents response data of SellOrderDto class represents response data of SellOrderDto
	/// </summary>
	public class BuyOrderResponse
	{
		public Guid BuyOrderId { get; set; }
		public string StockSymbol { get; set; }
		public string StockName { get; set; }
		public DateTime DateAndTimeOfOrder { get; set; }
		public uint Quantity { get; set; }
		public double Price { get; set; }
		public double TradeAmount
		{
			get
			{
				return this.Price * this.Quantity;
			}
			set
			{
				this.TradeAmount = value;
			}
		}
	}
}
