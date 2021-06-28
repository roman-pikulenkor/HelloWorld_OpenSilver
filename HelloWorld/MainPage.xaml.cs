using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace HelloWorld
{
    public partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Window.Current.CalculateLayout();
        }

        private void Button_SizeChanged(object sender, SizeChangedEventArgs e)
        {
        }

    }
}
