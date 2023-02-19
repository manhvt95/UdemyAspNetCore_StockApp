namespace StockApp.Core.ServiceContracts
{
	/// <summary>
	/// Contract interface for Finnhub Services
	/// </summary>
	public interface IFinnhubService
	{
		/// <summary>
		/// Get company profile by stock symbol
		/// </summary>
		/// <param name="stockSymbol">StockSymbol from appSettings.json</param>
		/// <returns>Company infomations dictionary</returns>
		Task<Dictionary<string, object>?> GetCompanyProfile(string stockSymbol);
		/// <summary>
		/// Get stock price details by stock symbol
		/// </summary>
		/// <param name="stockSymbol">StockSymbol from appSettings.json</param>
		/// <returns>Stock price details dictionary</returns>
		Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol);
	}
}
