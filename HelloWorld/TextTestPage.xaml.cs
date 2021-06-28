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
