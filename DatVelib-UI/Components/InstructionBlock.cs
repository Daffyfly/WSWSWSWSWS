using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DatVelib_UI.Components
{
    class InstructionBlock :TextBlock
    {

        public InstructionBlock(string content)
        {
            this.Text = content;
            this.Foreground = Ut.GetColor(255, 255, 255);
            this.FontSize = 15;
            this.Padding = new Thickness(0, 5, 0, 0);
            this.TextWrapping = TextWrapping.Wrap;
        }
    }
}
