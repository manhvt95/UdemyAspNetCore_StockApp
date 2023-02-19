using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StockApp.Core.Domain.Entities;
using StockApp.Core.Dto;
using StockApp.Core.Options;
using StockApp.Core.ServiceContracts;
using StockApp.UI.ViewModels;

namespace StockApp.UI.Controllers
{
	/// <summary>
	/// Controller class for Trading service
	/// </summary>
	[Route("[controller]")]
	public class TradeController : Controller
	{
		#region Variables
		private readonly IFinnhubService _finnhubService;
		private readonly IStockService _stockService;
		private readonly IOptions<TradeOptions> _options;
		private readonly IConfiguration _configuration;
		#endregion

		#region Methods
		/// <summary>
		/// TradeController constructor
		/// </summary>
		/// <param name="finnhubService">FinnhubService object</param>
		/// <param name="stockService">StockService object</param>
		/// <param name="options">IOptions configuration object</param>
		public TradeController(IFinnhubService finnhubService, IStockService stockService, IOptions<TradeOptions> options, IConfiguration configuration)
		{
			_options = options;
			_finnhubService = finnhubService;
			_stockService = stockService;
			_configuration = configuration;
		}
		/// <summary>
		/// Index method action for Get request
		/// </summary>
		/// <returns>View of GET Index</returns>
		[Route("[action]")]
		[Route("/")]
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			// Get input data from Settings
			string stockSymbol = _options.Value.DefaultStockSymbol;
			uint stockQuantity = _options.Value.DefaultOrderQuatity;

			// Hardcode when failed to get StockSymbol value from Settings
			if (string.IsNullOrEmpty(stockSymbol))
			{
				stockSymbol = "MSFT";
			}

			// Create default ViewModel
			StockTradeViewModel stockTradeViewModel = new StockTradeViewModel()
			{
				StockSymbol = stockSymbol
			};

			// Get Company profile and Stock price details
			Dictionary<string, object>? companyProfile = await _finnhubService.GetCompanyProfile(stockSymbol);
			Dictionary<string, object>? stockPriceQuote = await _finnhubService.GetStockPriceQuote(stockSymbol);

			// Create ViewModel from responses
			if (companyProfile != null && stockPriceQuote != null)
			{
				stockTradeViewModel = new StockTradeViewModel()
				{
					StockSymbol = stockSymbol,
					StockName = companyProfile["name"].ToString(),
					Price = Convert.ToDouble(stockPriceQuote["c"].ToString()),
					Quantity = stockQuantity
				};
			}

			// Set Finnhub secret key to client
			ViewBag.FinnhubKey = _configuration["finnhub"];

			return View(stockTradeViewModel);
		}
		/// <summary>
		/// Create new BuyOrder
		/// </summary>
		/// <param name="buyOrderRequest">BuyOrderRequest from model bindings</param>
		/// <returns>Order View when sucess or Current View when validation is failed</returns>
		[Route("[action]")]
		[HttpPost]
		public async Task<IActionResult> BuyOrder(BuyOrderRequest buyOrderRequest)
		{
			// Update the date and time of the buy order
			buyOrderRequest.DateAndTimeOfOrder = DateTime.Now;

			// Re-validate the model
			ModelState.Clear();
			TryValidateModel(buyOrderRequest);

			if (ModelState.IsValid)
			{
				// Create new BuyOrder
				BuyOrderResponse buyOrderResponse = await _stockService.CreateBuyOrder(buyOrderRequest);
				return RedirectToAction(nameof(Orders)); // Redirect to Orders page
			}
			else
			{
				// Get errors and return the view model
				ViewBag.Errors = ModelState.Values.SelectMany(value => value.Errors).Select(error => error.ErrorMessage);
				StockTradeViewModel viewModel = new StockTradeViewModel()
				{
					StockName = buyOrderRequest.StockName,
					StockSymbol = buyOrderRequest.StockSymbol,
					Quantity = buyOrderRequest.Quantity,
					Price = buyOrderRequest.Price
				};
				return View(nameof(Index), viewModel); // Represent the current page when get errors
			}
		}
		/// <summary>
		/// Create new SellOrder
		/// </summary>
		/// <param name="sellOrderRequest">ViewModel bindings</param>
		/// <returns>Order View when sucess or Current View when validation is failed</returns>
		[Route("[action]")]
		[HttpPost]
		public async Task<IActionResult> SellOrder(SellOrderRequest sellOrderRequest)
		{
			// Update the date and time of the sell order
			sellOrderRequest.DateAndTimeOfOrder = DateTime.Now;

			//Re-validate the model
			ModelState.Clear();
			TryValidateModel(sellOrderRequest);

			if (ModelState.IsValid)
			{
				// Create new SellOrder
				SellOrderResponse sellOrderResponse = await _stockService.CreateSellOrder(sellOrderRequest);
				return RedirectToAction(nameof(Orders)); // Redirect to Orders page
			}
			else
			{
				ViewBag.Errors = ModelState.Values.SelectMany(value => value.Errors).Select(error => error.ErrorMessage);
				StockTradeViewModel viewModel = new StockTradeViewModel()
				{
					StockName = sellOrderRequest.StockName,
					StockSymbol = sellOrderRequest.StockSymbol,
					Quantity = sellOrderRequest.Quantity,
					Price = sellOrderRequest.Price
				};
				return View(nameof(Index), viewModel); // Represent the current page when get errors
			}
		}
		/// <summary>
		/// Open Orders page
		/// </summary>
		/// <returns>View of Order page</returns>
		[Route("[action]")]
		[HttpGet]
		public async Task<IActionResult> Orders()
		{
			// Get list BuyOrder and SellOrder
			List<BuyOrderResponse> buyOrders = await _stockService.GetBuyOrders();
			List<SellOrderResponse> sellOrders = await _stockService.GetSellOrders();

			// Create ViewModel for Orders Page
			OrdersViewModel ordersViewModel = new OrdersViewModel()
			{
				BuyOrders = buyOrders,
				SellOrders = sellOrders
			};
			return View(ordersViewModel); //Return the Order page with the ViewModel
		}
		#endregion
	}
}
