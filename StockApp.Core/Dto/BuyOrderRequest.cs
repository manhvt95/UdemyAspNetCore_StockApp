using System.ComponentModel.DataAnnotations;

namespace StockApp.Core.Dto
{
	/// <summary>
	/// BuyOrderRequest is a Dto class that includes properties for transfering requested data
	/// </summary>
	public class BuyOrderRequest
	{
		#region Properties
		[Required(ErrorMessage = "The StockSymbol can NOT be null or empty")]
		public string StockSymbol { get; set; }
		[Required(ErrorMessage = "The StockName can NOT be null or empty")]
		public string StockName { get; set; }
		public DateTime DateAndTimeOfOrder { get; set; }
		[Range(1, 100000, ErrorMessage = "The ordered quantity must be in range from 1 to 100000")]
		public uint Quantity { get; set; }
		[Range(1, 10000, ErrorMessage = "The ordered price must be in range from 1 to 10000")]
		public double Price { get; set; }
		#endregion

		#region Validation Methods
		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			List<ValidationResult> result = new List<ValidationResult>();
			// Validate the DateAndTimeOfOrder
			if(DateAndTimeOfOrder < Convert.ToDateTime("2000-01-01"))
			{
				result.Add(new ValidationResult("The Datetime of Buy Order can NOT be older than 2000/01/01"));
			}

			return result;
		}
		#endregion
	}
}
