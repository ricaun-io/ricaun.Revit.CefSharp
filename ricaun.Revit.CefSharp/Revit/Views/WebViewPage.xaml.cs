using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ricaun.Revit.CefSharps.Revit.Views
{
    /// <summary>
    /// Interaction logic for WebViewPage.xaml
    /// </summary>
    public partial class WebViewPage : Page, IDockablePaneProvider
    {
        public WebViewPage()
        {
            InitializeComponent();
            InitializeAddress();
        }
        public void SetAddress(string address)
        {
            Browser.Address = address;
        }

        private void InitializeAddress()
        {
            Browser.ConsoleMessage += (s, e) =>
            {
                Console.WriteLine($"Web: {e.Message}");
            };
            Browser.TitleChanged += (s, e) =>
            {
                this.Title = $"{Browser.Title} - CefSharp: {CefSharp.Cef.CefSharpVersion}";
                if (this.Parent is Window window)
                {
                    window.Title = this.Title;
                }
            };
            Browser.MenuHandler = new NoMenuContextHandler();
        }

        /// <summary>
        /// Setups the dockable pane.
        /// </summary>
        /// <param name="data"></param>
        public void SetupDockablePane(DockablePaneProviderData data)
        {
            data.FrameworkElement = this;

            // Define initial pane position in Revit ui.
            data.InitialState = new DockablePaneState
            {
                DockPosition = DockPosition.Right,
            };
            //data.InitialState.SetFloatingRectangle(new Rectangle(0, 0, 480, 480));
            data.VisibleByDefault = false;
        }
    }
}
