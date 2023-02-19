namespace StockApp.Core.Options
{
	/// <summary>
	/// Options class includes configurations of trading from appSettings.json
	/// </summary>
	public class TradeOptions
	{
		public const string TRADE_OPTIONS = "TradingOptions"; // Constant value of the configuration setction
		public string DefaultStockSymbol { get; set; } // DefaultStockSymbol
		public uint DefaultOrderQuatity { get; set; } //DefaultOrderQuatity
	}
}