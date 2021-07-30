using CSHTML5;
using DotNetForHtml5.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace HelloWorld
{
    public partial class CheckBoxTestPage : Page
    {
        public CheckBoxTestPage()
        {
            this.InitializeComponent();

            /*
            var sw = System.Diagnostics.Stopwatch.StartNew();

            var test = System.Diagnostics.Stopwatch.StartNew();

            dynamic smt = "123";
            var res = smt + "Test" + test.ToString();
            sw.Stop();

            var elapsed = sw.Elapsed.TotalMilliseconds;
            //Console.WriteLine("First time - " + elapsed + " " + res);
            System.Diagnostics.Debug.WriteLine($"First time - {elapsed} {res}");
            */
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Test started.");

            /*Interop.ExecuteJavaScript("document.body.appendChild(document.createElement('div'))");
            Interop.ExecuteJavaScript("document.body.appendChild(document.createElement('div'))");
            Interop.ExecuteJavaScript("document.body.appendChild(document.createElement('div'))");
            */
            Stopwatch sw;
            sw = System.Diagnostics.Stopwatch.StartNew();

            for (int i = 0; i < 1; i++)
            {
                INTERNAL_Simulator.JavaScriptExecutionHandler.ExecuteCreateElement(100);
            }
            

            sw.Stop();
            Debug.WriteLine($"ExecuteCreateElement - {sw.ElapsedMilliseconds}");

            return;
            
            const int testCount = 2;
            // -- Sync
            sw = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < testCount; i++)
            {
                Interop.ExecuteJavaScript("document.boddy.appendChild(document.createElement('div'))");
            }
            sw.Stop();
            Debug.WriteLine($"Sync - {sw.ElapsedMilliseconds}");

            // Asynd with last sync
            sw = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < testCount - 1; i++)
            {
                Interop.ExecuteJavaScriptAsync("document.createElement('div')");
            }
            Interop.ExecuteJavaScript("document.createElement('div')");
            sw.Stop();
            Debug.WriteLine($"Async(last sync) - {sw.ElapsedMilliseconds}");

            // -- Async
            sw = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < testCount; i++)
            {
                Interop.ExecuteJavaScriptAsync("document.createElement('div')");
            }
            sw.Stop();
            Debug.WriteLine($"Async - {sw.ElapsedMilliseconds}");
        }
    }
}
