using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Dojo3.Commands
{
    class IntTobrushConverter
    {

        Brush red = new SolidColorBrush(Colors.Red);
        Brush yellow = new SolidColorBrush(Colors.Yellow);
        Brush green = new SolidColorBrush(Colors.Green);

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //Add convertion code here!!
            int val = (int)value;
            if (val > 20) { return green; }
            else if (val < 10) { return red; }
            else { return yellow; }
        }

    }
}
