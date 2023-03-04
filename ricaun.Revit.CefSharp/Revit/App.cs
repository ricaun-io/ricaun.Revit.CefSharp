using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ricaun.Revit.CefSharps.Revit.Views;
using ricaun.Revit.UI;
using System;
using System.Linq;

namespace ricaun.Revit.CefSharps.Revit
{
    [AppLoader]
    public class App : IExternalApplication
    {
        private string AddressBase = "https://ricaun.com";
        private static RibbonPanel ribbonPanel;
        private static TextBox textBox;
        public Result OnStartup(UIControlledApplication application)
        {
            ribbonPanel = application.CreatePanel("ricaun.Revit.CefSharp");

            var textBoxData = ribbonPanel.NewTextBoxData("Address");
            var buttonData = ribbonPanel.NewPushButtonData<Commands.Command>("Open Web")
                .SetLargeImage("/UIFrameworkRes;component/ribbon/images/revit.ico");
            var items = ribbonPanel.AddStackedItems(textBoxData, buttonData);

            textBox = items.OfType<TextBox>().FirstOrDefault();
            textBox.Width = 100;
            textBox.ShowImageAsButton = true;

            textBox.PromptText = AddressBase;
            textBox.Value = AddressBase;
            textBox.EnterPressed += TextBox_EnterPressed;

            return Result.Succeeded;
        }

        private void TextBox_EnterPressed(object sender, Autodesk.Revit.UI.Events.TextBoxEnterPressedEventArgs e)
        {
            webViewDialog?.Close();
            OpenWebViewDialog();
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            ribbonPanel?.Remove();
            webViewDialog?.Close();
            return Result.Succeeded;
        }

        static WebViewDialog webViewDialog;
        internal static void OpenWebViewDialog()
        {
            if (webViewDialog is null)
            {
                webViewDialog = new WebViewDialog(textBox.Value.ToString());
                webViewDialog.Closed += (s, e) => { webViewDialog = null; };
                webViewDialog.Show();
            }
            webViewDialog.Activate();
        }
    }

}