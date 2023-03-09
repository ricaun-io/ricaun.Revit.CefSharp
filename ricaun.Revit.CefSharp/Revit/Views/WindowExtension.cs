using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;

namespace ricaun.Revit.CefSharps.Revit.Views
{
    public static class WindowExtension
    {
        /// <summary>
        /// InitializeCloseEvents 
        /// </summary>
        /// <param name="window"></param>
        public static void InitializeCloseEvents(this Window window)
        {
            var commandBinding = new CommandBinding(ApplicationCommands.Close, (s, e) => { if (s is Window w) w.Close(); });
            window.CommandBindings.Add(commandBinding);
            var inputBinding = new InputBinding(ApplicationCommands.Close, new KeyGesture(Key.Escape));
            window.InputBindings.Add(inputBinding);
        }

        /// <summary>
        /// InitializeResizeWithoutMinimizeMaximize 
        /// </summary>
        /// <param name="window"></param>
        public static void InitializeResizeWithoutMinimizeMaximize(this Window window)
        {
            window.Loaded += (s, e) =>
            {
                window.ResizeMode = ResizeMode.CanResizeWithGrip;
                HideMinimizeMaximizeButton(window);
            };
        }

        #region Windows HideMinimizeMaximizeButton
        /// <summary>
        /// Hides both Maximize and Minimize button from this WPF Window. This should be placed on Loaded event OR Rendered event, NOT ON THE CONSTRUCTOR
        /// </summary>
        public static void HideMinimizeMaximizeButton(Window window)
        {
            IntPtr hwnd = new System.Windows.Interop.WindowInteropHelper(window).Handle;
            var currentStyle = GetWindowLong(hwnd, GWL_STYLE);
            SetWindowLong(hwnd, GWL_STYLE, (currentStyle & ~WS_MAXIMIZEBOX & ~WS_MINIMIZEBOX));
        }

        /// <summary>
        /// Hides both Minimize button from this WPF Window. This should be placed on Loaded event OR Rendered event, NOT ON THE CONSTRUCTOR
        /// </summary>
        public static void HideMinimizeButton(Window window)
        {
            IntPtr hwnd = new System.Windows.Interop.WindowInteropHelper(window).Handle;
            var currentStyle = GetWindowLong(hwnd, GWL_STYLE);
            SetWindowLong(hwnd, GWL_STYLE, (currentStyle & ~WS_MINIMIZEBOX));
        }

        #region user32.dll
        private const int GWL_STYLE = -16,
                  WS_MAXIMIZEBOX = 0x10000,
                  WS_MINIMIZEBOX = 0x20000;

        [DllImport("user32.dll")]
        extern private static int GetWindowLong(IntPtr hwnd, int index);

        [DllImport("user32.dll")]
        extern private static int SetWindowLong(IntPtr hwnd, int index, int value);
        #endregion
        #endregion
    }
}
