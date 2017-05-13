using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DatVelib_UI
{
    class Ut
    {

        public static SolidColorBrush GetColor(byte r, byte g, byte b)
        {
           return  new SolidColorBrush(Color.FromRgb(r, g, b));
        }
    }
}
