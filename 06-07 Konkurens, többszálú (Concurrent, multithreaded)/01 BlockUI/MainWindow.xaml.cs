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
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace BlockUI
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            //this.AppWindow.Resize(new Windows.Graphics.SizeInt32(500, 300));
        }

        private void RunFromMainThreadButton_Click(object sender, RoutedEventArgs e)
        {
            // Call from main thread, UI freezes
            LongRunningAlg.Run();
            ShowDone();
        }

        private void RunFromBackgroundThreadButton_Click(object sender, RoutedEventArgs e)
        {
            // Call from a new thread, UI does not freeze
            Thread thread = new Thread(
                () =>
                {
                    LongRunningAlg.Run();
                    ShowDone();

                });
            thread.Start();
        }

        // Shows a "Done" message box.
        // Note: the implementation is irrelevant for us
        async void ShowDone()
        {
            if (!DispatcherQueue.HasThreadAccess)
                DispatcherQueue.TryEnqueue(ShowDone);
            else
            {
                ContentDialog dialog = new ContentDialog
                {
                    Content = "Done.",
                    CloseButtonText = "Ok"
                };
                dialog.XamlRoot = this.Content.XamlRoot;
                await dialog.ShowAsync();
            }
        }
    }
}
