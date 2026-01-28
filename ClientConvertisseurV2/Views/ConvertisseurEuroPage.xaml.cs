using ClientConvertisseurV2.ViewModels;
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics;
using WinRT.Interop;
using Microsoft.Extensions.DependencyInjection;
using ClientConvertisseurV2.Views;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ClientConvertisseurV2.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ConvertisseurEuroPage : Page
    {
        public ConvertisseurEuroPage()
        {
            InitializeComponent();
            ConvertisseurEuroViewModel viewModel = new ConvertisseurEuroViewModel();
            DataContext = App.Current.Services.GetService<ConvertisseurEuroViewModel>();

            viewModel.MessageRequested += async (_, msg) =>
            {
                var dialog = new ContentDialog
                {
                    Title = "Erreur",
                    Content = msg,
                    CloseButtonText = "OK",
                    XamlRoot = this.XamlRoot
                };

                await dialog.ShowAsync();
            };

            this.Loaded += (_, __) => viewModel.Initialize();

            //this.Loaded += (s, e) =>
            //{
            //    var hwnd = WindowNative.GetWindowHandle(Window.Current);
            //    var windowId = Win32Interop.GetWindowIdFromWindow(hwnd);
            //    var appWindow = AppWindow.GetFromWindowId(windowId);
            //    appWindow.Resize(new SizeInt32(500, 600));
            //};
        }
    }
}
