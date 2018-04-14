using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Windows.Data;

namespace MarketPlace.Client.Converter
{
    public class DecimalToBoolConverter : IValueConverter
    {
        public const decimal ITEM_RED_CONDITION = 20;

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            decimal price;
            if (!Decimal.TryParse(value as string, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out price))
                return false;

            return price >= ITEM_RED_CONDITION;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            decimal price;
            if (!Decimal.TryParse(value as string, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out price))
                return false;

            return price >= ITEM_RED_CONDITION;
        }
    }
}
