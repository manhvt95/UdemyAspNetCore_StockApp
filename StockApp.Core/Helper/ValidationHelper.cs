using System.ComponentModel.DataAnnotations;

namespace StockApp.Core.Helper
{
	/// <summary>
	/// Validation helper for validate the object and try to return exception
	/// </summary>
	public class ValidationHelper
	{
		/// <summary>
		/// Validation object method
		/// </summary>
		/// <param name="obj">Object that need to be validated</param>
		/// <exception cref="ArgumentException">Throw exception when get errors</exception>
		public static void ModelValidation(object obj)
		{
			ValidationContext validationContext = new ValidationContext(obj);
			List<ValidationResult> result = new List<ValidationResult>();

			// Validate the object
			bool isValid = Validator.TryValidateObject(obj, validationContext, result, true);
			if (!isValid)
			{
				throw new ArgumentException(result.FirstOrDefault()?.ErrorMessage);
			}
		}
	}
}
