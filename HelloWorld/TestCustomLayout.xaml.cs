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
    public partial class TestCustomLayout : Page
    {
        public TestCustomLayout()
        {
            this.InitializeComponent();
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            Button5.Content = "A" + Button5.Content;
        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            Button5.Content = Button5.Content.ToString().Substring(1);
        }
    }
}
