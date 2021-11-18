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
    public partial class TextTestPage : Page
    {
        public TextTestPage()
        {
            this.InitializeComponent();
            Application.Current.Host.Settings.EnableInteropLogging = true;

            // TestReplace();
        }

        private void TestReplace()
        {
            string toExecute = "var element = document.getElementByIdSafe(id1840);{0}, if (element)";
            string uid = "id100";

            DateTime dtStart = DateTime.Now;
            for (int i = 0; i < 10000; i++)
            {
                string formatted = $@"var element = document.getElementByIdSafe(id1840);{uid}, if (element)";
            }
            Console.WriteLine($"format {(DateTime.Now - dtStart).TotalMilliseconds}");

            dtStart = DateTime.Now;
            for (int i = 0; i < 10000; i++)
            {
                string formatted = toExecute.Replace("{0}", uid);
            }
            Console.WriteLine($"replace {(DateTime.Now - dtStart).TotalMilliseconds}");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextBoxName2.FontSize += 2;
        }

        private void ChangeText_Click(object sender, RoutedEventArgs e)
        {
            TextBlockName2.Text += "AAA ";
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //TextBoxName.InvalidateMeasure();
        }

        private void TextBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            //TextBoxName2.InvalidateMeasure();
        }

        private void ChangeSpanButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
