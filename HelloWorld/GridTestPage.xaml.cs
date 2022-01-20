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
    public partial class GridTestPage : Page
    {
        public GridTestPage()
        {
            this.InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            //RowDefinition1.Height = new GridLength(RowDefinition1.Height.Value + 5);
            ////Window.Current.CalculateLayout();
            border1.Visibility = Visibility.Visible;
            //(VisualTreeHelper.GetParent(border1) as UIElement)?.InvalidateMeasure();
            //(VisualTreeHelper.GetParent(border1) as UIElement)?.InvalidateArrange();
        }

        private void ColumnWidthButton_Click(object sender, RoutedEventArgs e)
        {
            //ColumnDefinition1.Width = new GridLength(ColumnDefinition1.Width.Value + 5);
            grid1.InvalidateMeasure();
            grid1.InvalidateArrange();
        }
    }
}
