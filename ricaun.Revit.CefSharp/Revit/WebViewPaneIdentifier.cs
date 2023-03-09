using Autodesk.Revit.UI;
using System;

namespace ricaun.Revit.CefSharps.Revit
{
    public static class WebViewPaneIdentifier
    {
        /// <summary>
        /// Guid of the PaneIdentifier
        /// </summary>
        /// <returns></returns>
        public static Guid GetGuid()
        {
            return new Guid("90FA55E9-AA4F-4F90-92FF-09761A098BF1");
        }

        /// <summary>
        /// Name of the PaneIdentifier
        /// </summary>
        /// <returns></returns>
        public static string GetName()
        {
            return "CefSharp";
        }

        /// <summary>
        /// RegisterDockablePane
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        public static bool RegisterDockablePane(UIControlledApplication application)
        {
            UIControlledApplication = application;

            // Get Console Id
            var dpid = new DockablePaneId(GetGuid());
            // Register pane.
            if (DockablePane.PaneIsRegistered(dpid) == false)
            {
                Page = new Views.WebViewPage();

                application.RegisterDockablePane(dpid, GetName(), Page);
            }

            return DockablePane.PaneIsRegistered(dpid);
        }

        public static Views.WebViewPage Page { get; private set; }
        private static UIControlledApplication UIControlledApplication;
        public static DockablePane DockablePane
        {
            get
            {
                try
                {
                    return UIControlledApplication.GetDockablePane(new DockablePaneId(GetGuid()));
                }
                catch { }
                return null;
            }
        }
    }
}
