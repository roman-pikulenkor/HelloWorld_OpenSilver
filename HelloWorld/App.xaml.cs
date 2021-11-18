using CSHTML5;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace HelloWorld
{
    public sealed partial class App : Application
    {
        public App()
        {
            global::System.Diagnostics.Debug.WriteLine($",{DateTime.Now.ToString("HH:mm:ss.fff")}, App started");
            this.InitializeComponent();

            //Application.Current.Host.Settings.EnableInteropLogging = true;

            //Console.WriteLine($",{DateTime.Now.ToString("HH:mm:ss.fff")}, Loading started");
            global::System.Diagnostics.Debug.WriteLine($",{DateTime.Now.ToString("HH:mm:ss.fff")}, Loading started");

            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            // Enter construction logic here...

            //var page = new SingleCellTestPage();

            //var page = new StackPanelTestPage();

            //var page = new FrameTestPage();

            //var page = new PopupTestPage();

            //var page = new ChildWindowTestPage();

            //var page = new ShapeTestPage();

            //var page = new TranslateTestPage();

            //var page = new TextTestPage();

            //var page = new ScrollViewerTestPage();

            //var page = new CustomPanelPage();

            //var page = new TestTabcontrol();

            //Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss.fff")}");
            //var page = new GridTestPage();

            //var page = new GridTestPage2();

            //var page = new GridTestPage3();

            //var page = new CanvasTestPage();

            //var page = new DockPanelTestPage();

            //var page = new WrapPanelTestPage();

            //var page = new BorderTestPage();

            //var page = new TileViewTestPage();

            //var page = new CheckBoxTestPage();

            //var page = new TestCustomLayout();

            var page = new TestListBoxPage();

            Window.Current.Content = page;

            stopwatch.Stop();

            Console.WriteLine($",{DateTime.Now.ToString("HH:mm:ss.fff")}, Loading done in: " + stopwatch.ElapsedMilliseconds);
            global::System.Diagnostics.Debug.WriteLine($",{DateTime.Now.ToString("HH:mm:ss.fff")}, Loading done in: " + stopwatch.ElapsedMilliseconds);

        }
    }
}
