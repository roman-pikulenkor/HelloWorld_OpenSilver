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
    public partial class FrameTestPage : Page
    {
        public FrameTestPage()
        {
            this.InitializeComponent();
        }

        void NavigateToPage(string targetUri)
        {
            // Navigate to the target page:
            Uri uri = new Uri(targetUri, UriKind.Relative);
            PageContainer.Source = uri;

            // Scroll to top:
            //ScrollViewer1.ScrollToVerticalOffset(0d);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigateToPage("/XAML_Controls");
        }
    }
}
