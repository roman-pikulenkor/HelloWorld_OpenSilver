using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;

namespace HelloWorld.Samples
{
    public partial class Grid_Demo : UserControl
    {
        public Grid_Demo()
        {
            this.InitializeComponent();

            //Console.WriteLine($"{grid1.VerticalAlignment}");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //grid1.Arrange(new Rect(new Size(200, 200)));
        }
    }
}
