using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ricaun.Revit.CefSharps.Revit.Views;
using System;

namespace ricaun.Revit.CefSharps.Revit.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        static WebViewDialog webViewDialog;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elementSet)
        {
            UIApplication uiapp = commandData.Application;

            if (webViewDialog is null)
            {
                webViewDialog = new WebViewDialog("https://ricaun.com/");
                webViewDialog.Closed += (s, e) => { webViewDialog = null; };
                webViewDialog.Show();
            }

            return Result.Succeeded;
        }
    }
}
