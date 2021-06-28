using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Browser;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;

namespace HelloWorld
{
    public partial class StackPanelTestPage : Page
    {
        public StackPanelTestPage()
        {
            this.InitializeComponent();
        }


        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            CalculateButton.Content += "A";
            //CalculateButton.InvalidateMeasure();
            //CalculateButton.InvalidateArrange();
            Console.WriteLine("CalculateButton_Click");
            ////Window.Current.CalculateLayout();
        }

        private void NavigateButton_Click(object sender, RoutedEventArgs e)
        {
            CustomPanelPage mainPage = new CustomPanelPage();
            Window.Current.Content = mainPage;
        }

        private void CheckBoxButton_Click(object sender, RoutedEventArgs e)
        {
            UnoTestPage page = new UnoTestPage();
            Window.Current.Content = page;
        }
        private void GridButton_Click(object sender, RoutedEventArgs e)
        {
            GridTestPage page = new GridTestPage();
            Window.Current.Content = page;
        }
        private void Grid2Button_Click(object sender, RoutedEventArgs e)
        {
            GridTestPage2 page = new GridTestPage2();
            Window.Current.Content = page;
        }

        private void CanvasButton_Click(object sender, RoutedEventArgs e)
        {
            CanvasTestPage page = new CanvasTestPage();
            Window.Current.Content = page;
        }

        private void DockPanelButton_Click(object sender, RoutedEventArgs e)
        {
            DockPanelTestPage page = new DockPanelTestPage();
            Window.Current.Content = page;
        }

        private void WrapPanelButton_Click(object sender, RoutedEventArgs e)
        {
            WrapPanelTestPage page = new WrapPanelTestPage();
            Window.Current.Content = page;
        }

        private void TextBoxButton_Click(object sender, RoutedEventArgs e)
        {
            TextTestPage page = new TextTestPage();
            Window.Current.Content = page;
        }

        private void ShapeButton_Click(object sender, RoutedEventArgs e)
        {
            ShapeTestPage page = new ShapeTestPage();
            Window.Current.Content = page;
        }

        private void ExpanderButton_Click(object sender, RoutedEventArgs e)
        {
            ScrollViewerTestPage page = new ScrollViewerTestPage();
            Window.Current.Content = page;
        }

        private void ChildButton_Click(object sender, RoutedEventArgs e)
        {
            ChildWindowTestPage page = new ChildWindowTestPage();
            Window.Current.Content = page;
        }
        

        private void PopupButton_Click(object sender, RoutedEventArgs e)
        {
            PopupTestPage page = new PopupTestPage();
            Window.Current.Content = page;
        }
        
    }
}
