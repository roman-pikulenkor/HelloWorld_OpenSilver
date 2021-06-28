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

namespace HelloWorld
{
    public partial class WrapPanelTestPage : Page
    {
        public WrapPanelTestPage()
        {
            this.InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            //Window.Current.CalculateLayout();
        }

        private void HeightButton_Click(object sender, RoutedEventArgs e)
        {
            //wrapPanel.ItemHeight += 10;
        }
        
    }
}
