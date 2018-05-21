using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MarketPlace.Client.Validation
{
    public class ProductCodeValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (!string.IsNullOrEmpty(value.ToString()))
                return new ValidationResult(true, null);

            return new ValidationResult(false, "Please enter a valid value.");
        }
    }
}
