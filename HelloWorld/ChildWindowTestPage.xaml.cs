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
    public partial class ChildWindowTestPage : Page
    {
        public ChildWindowTestPage()
        {
            this.InitializeComponent();
        }

        private void ButtonTestChildWindow_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWnd = new LoginWindow();
            loginWnd.Closed += new EventHandler(loginWnd_Closed);
            loginWnd.Show();
        }

        void loginWnd_Closed(object sender, EventArgs e)
        {
            LoginWindow lw = (LoginWindow)sender;
            if (lw.DialogResult.HasValue && lw.DialogResult.Value == true && lw.NameBox.Text != string.Empty)
            {
                this.TextBlockForTestingChildWindow.Text = "Hello " + lw.NameBox.Text;
            }
            else
            {
                this.TextBlockForTestingChildWindow.Text = "Login cancelled.";
            }
        }
    }
}
