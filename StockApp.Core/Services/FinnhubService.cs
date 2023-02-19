using Microsoft.Extensions.Configuration;
using StockApp.Core.ServiceContracts;
using System.Text.Json;

namespace StockApp.Core.Services
{
	/// <summary>
	/// Services for Finnhub
	/// </summary>
	public class FinnhubService : IFinnhubService
	{
		#region Variables
		private const string getCompanyProfileUrl = @"https://finnhub.io/api/v1/stock/profile2?symbol="; //Company profile fixed URL
		private const string getStockPriceQuoteUrl = @"https://finnhub.io/api/v1/quote?symbol="; //Stock detail price fixed URL
		private readonly IConfiguration _configuration;
		private string token;
		#endregion

		#region Methods
		/// <summary>
		/// Constuctor of FinnhubService
		/// </summary>
		/// <param name="configuration">SecretKey configuration</param>
		public FinnhubService(IConfiguration configuration)
		{
			_configuration = configuration;
			token = _configuration["finnhub"];
		}
		/// <summary>
		/// Get company profile service
		/// </summary>
		/// <param name="stockSymbol">StockSymbol ("MSFT")</param>
		/// <returns>Data collection of Company information</returns>
		public async Task<Dictionary<string, object>?> GetCompanyProfile(string stockSymbol)
		{
			// Get secret key of finnhub
			if (string.IsNullOrEmpty(token))
			{
				token = _configuration["finnhub"];
			}

			// Send request
			HttpClient client = new HttpClient();
			Task<HttpResponseMessage> response = client.GetAsync($"{getCompanyProfileUrl}{stockSymbol}&token={token}");
			var content = await response.Result.Content.ReadAsStringAsync();

			// Return outputs
			Dictionary<string, object>? dict = JsonSerializer.Deserialize<Dictionary<string, object>>(content);

			// Check the response
			if(dict == null)
			{
				throw new InvalidOperationException("No response from the server");
			}
			if (dict.ContainsKey("error"))
			{
				throw new InvalidOperationException(Convert.ToString(dict["error"]));
			}

			return dict;
		}
		/// <summary>
		/// Get stock price quote service
		/// </summary>
		/// <param name="stockSymbol">StockSymbol ("MSFT")</param>
		/// <returns>Data collection of Stock price details</returns>
		public async Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol)
		{
			// Get secret key of finnhub
			if (string.IsNullOrEmpty(token))
			{
				token = _configuration["finnhub"];
			}

			//Send request
			HttpClient client = new HttpClient();
			Task<HttpResponseMessage> response = client.GetAsync($"{getStockPriceQuoteUrl}{stockSymbol}&token={token}");
			var content = await response.Result.Content.ReadAsStringAsync();

			// Return outputs
			Dictionary<string, object>? dict = JsonSerializer.Deserialize<Dictionary<string, object>>(content);

			// Check the response
			if (dict == null)
			{
				throw new InvalidOperationException("No response from the server");
			}
			if (dict.ContainsKey("error"))
			{
				throw new InvalidOperationException(Convert.ToString(dict["error"]));
			}

			return dict;
		}
		#endregion
	}
}
