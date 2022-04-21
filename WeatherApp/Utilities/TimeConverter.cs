using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Xamarin.Forms;

namespace WeatherApp.Utilities
{
    /// <summary>
    /// Konverterar Unix tid till veckodag
    /// </summary>
    class TimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            long longValue = long.Parse(value.ToString());
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(longValue);
            //int dateTime = (int)value;
            return dateTimeOffset.ToString("dddd");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }

    /// <summary>
    /// Konverterar Unix tid till timmar formatterat till HH:mm
    /// </summary>
    class TimeHourConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            long longValue = long.Parse(value.ToString());
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(longValue);
            //int dateTime = (int)value;
            return dateTimeOffset.ToString("HH:mm");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }

    class TimeDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            long longValue = long.Parse(value.ToString());
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(longValue);
            //int dateTime = (int)value;
            return dateTimeOffset.ToString("MMMM dd, yyyy");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}

