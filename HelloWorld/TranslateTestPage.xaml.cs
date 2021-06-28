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
    public partial class TranslateTestPage : Page
    {
        public TranslateTestPage()
        {
            this.InitializeComponent();
        }

        void ButtonTranslate_Click(object sender, RoutedEventArgs e)
        {
            if (TestTransformBorder.RenderTransform == null || !(TestTransformBorder.RenderTransform is TranslateTransform))
            {
                TranslateTransform translateTransform = new TranslateTransform();
                TestTransformBorder.RenderTransform = translateTransform;
            }
            ((TranslateTransform)TestTransformBorder.RenderTransform).X += 10;
            ((TranslateTransform)TestTransformBorder.RenderTransform).Y += 10;
        }

        void ButtonRotate_Click(object sender, RoutedEventArgs e)
        {
            if (TestTransformBorder.RenderTransform == null || !(TestTransformBorder.RenderTransform is RotateTransform))
            {
                RotateTransform rotateTransform = new RotateTransform();
                TestTransformBorder.RenderTransform = rotateTransform;
            }
            ((RotateTransform)TestTransformBorder.RenderTransform).Angle += 10;
        }

        void TransformButton_Click(object sender, RoutedEventArgs e)
        {
            Random r = new Random();

            SolidColorBrush brush = new SolidColorBrush();

            brush.Color = Color.FromArgb((byte)r.Next(255), (byte)r.Next(255), (byte)r.Next(255), (byte)r.Next(255));
            TestTransformBorder.Background = brush;
        }
    }
}
