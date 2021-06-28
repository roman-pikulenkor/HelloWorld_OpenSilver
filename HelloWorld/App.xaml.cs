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
            this.InitializeComponent();

            // Enter construction logic here...

            //var page = new SingleCellTestPage();

            var page = new StackPanelTestPage();

            //var page = new FrameTestPage();

            //var page = new PopupTestPage();

            //var page = new ChildWindowTestPage();

            //var page = new ShapeTestPage();

            //var page = new TranslateTestPage();

            //var page = new TextTestPage();

            //var page = new ScrollViewerTestPage();

            //var page = new CustomPanelPage();

            //Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss.fff")}");
            //var page = new GridTestPage();

            //var page = new GridTestPage2();

            //var page = new GridTestPage3();

            //var page = new CanvasTestPage();

            //var page = new DockPanelTestPage();

            //var page = new WrapPanelTestPage();

            //var page = new BorderTestPage();

            //var page = new TileViewTestPage();

            Window.Current.Content = page;

        }
    }
}
