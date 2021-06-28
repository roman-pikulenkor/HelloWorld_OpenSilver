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
    public partial class PopupTestPage : Page
    {
        public PopupTestPage()
        {
            this.InitializeComponent();
        }

        private void ButtonTestChildWindow_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWnd = new LoginWindow();
            loginWnd.Show();
        }
    }
}
