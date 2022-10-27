using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;

namespace Watchlist.ModelBinders
{
    public class DecimalModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            ValueProviderResult valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (valueResult != ValueProviderResult.None && !String.IsNullOrEmpty(valueResult.FirstValue))
            {
                decimal actualResult = 0m;
                bool success = false;

                try
                {
                    string decValue = valueResult.FirstValue;

                    decValue = decValue.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

                    decValue = decValue.Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

                    actualResult = Convert.ToDecimal(decValue, CultureInfo.CurrentCulture);

                    success = true;
                }
                catch (FormatException fe)
                {
                    bindingContext.ModelState.AddModelError(bindingContext.ModelName, fe, bindingContext.ModelMetadata);

                }

                if (success)
                {
                    bindingContext.Result = ModelBindingResult.Success(actualResult);
                }
            }

            return Task.CompletedTask;
        }
    }
}
