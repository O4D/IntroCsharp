using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace LesConverters
{
    class DateToStringConverter : IValueConverter
    {
        /// <summary>
        /// Définit la méthode de conversion pour changer un DateTime en un string
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            DateTime thisdate = (DateTime)value;

            int monthnum = thisdate.Month;

            string month = GetMonthStringFromMonthNumber(monthnum);

            return month;
        }

        private string GetMonthStringFromMonthNumber(int monthNumber)
        {
            switch(monthNumber)
            {
                case 1:
                    return "January";
                    break;
                case 2:
                    return "February";
                    break;
                case 3:
                    return "March";
                    break;
                case 9:
                    return "September";
                    break;
                default:
                    return "Month";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
