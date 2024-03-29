﻿using System;
using System.Windows;

namespace ricaun.Revit.CefSharps.Revit.Views
{
    public partial class WebViewDialog : Window
    {
        public WebViewDialog(string address)
        {
            InitializeComponent();
            InitializeWindow();
            this.InitializeCloseEvents();
            this.InitializeResizeWithoutMinimizeMaximize();
            this.WebViewPage.SetAddress(address);
        }

        #region InitializeWindow
        private void InitializeWindow()
        {
            this.MinHeight = 560;
            this.MinWidth = 420;
            this.SizeToContent = SizeToContent.WidthAndHeight;
            this.ShowInTaskbar = false;
            this.ResizeMode = ResizeMode.NoResize;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            new System.Windows.Interop.WindowInteropHelper(this) { Owner = Autodesk.Windows.ComponentManager.ApplicationWindow };
        }
        #endregion
    }
}