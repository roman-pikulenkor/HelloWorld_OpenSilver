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
    public partial class TestListBoxPage : Page
    {
        List<string> source = new List<string>();

        bool bUseItemsSource = false;

        public TestListBoxPage()
        {
            this.InitializeComponent();

            if (bUseItemsSource == false)
            {
                for (int i = 0; i < 1000; i++)
                {
                    //listBox.Items.Add(i.ToString() + ".ABC");
                }
            }
            else
            {
                for (int i = 0; i < 50; i++)
                {
                    int j = i / 3;
                    source.Add((j * 3).ToString() + ".AAAAABBBBBCCCCC");
                }
                //listBox.ItemsSource = source;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (bUseItemsSource == false)
            {
                listBox.Items.Insert(2, "new.AAAAABBBBBCCCCC11111111111!");
            }
            else
            {
                source.Insert(2, "new.AAAAABBBBBCCCCC11111111111!");
                listBox.ItemsSource = null;
                listBox.ItemsSource = source;
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (bUseItemsSource == false)
            {
                listBox.Items.RemoveAt(3);
            } 
            else
            {
                source.RemoveAt(3);
                listBox.ItemsSource = null;
                listBox.ItemsSource = source;
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (bUseItemsSource == false)
            {
                listBox.Items[4] = "Updated!";
            }
            else
            {
                source[4] = "Updated!";
                listBox.ItemsSource = null;
                listBox.ItemsSource = source;
            }
        }
    }
}
