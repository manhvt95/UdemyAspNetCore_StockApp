namespace StockApp.UI.ViewModels
{
	/// <summary>
	/// ViewModel of Index
	/// </summary>
	public class StockTradeViewModel
	{
		public string? StockSymbol { get; set; }
		public string? StockName { get; set; }
		public double Price { get; set; }
		public uint Quantity { get; set; }
	}
}
