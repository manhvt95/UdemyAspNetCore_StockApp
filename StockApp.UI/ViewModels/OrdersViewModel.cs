using StockApp.Core.Dto;

namespace StockApp.UI.ViewModels
{
    /// <summary>
    /// ViewModel for Orders Page
    /// </summary>
    public class OrdersViewModel
    {
        public List<BuyOrderResponse>? BuyOrders { get; set; } // List of BuyOrder

        public List<SellOrderResponse>? SellOrders { get; set; } // List of SellOrders
    }
}
