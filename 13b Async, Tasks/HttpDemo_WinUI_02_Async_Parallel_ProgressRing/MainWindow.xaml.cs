using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace HttpDemo_WinUI_01_Sync;

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainWindow : Window
{
    private readonly HttpClient _httpClient = new HttpClient();

    public MainWindow()
    {
        this.InitializeComponent();
    }
    public async Task<int> GetUrlContentLengthAsync(string url)
    {
        Task<string> getStringTask =
            _httpClient.GetStringAsync(url);

        // ... valamilyen műveletek, melyek nem használják a getStringTask eredményét ...

        string contents = await getStringTask;
        await Task.Delay(2000); // Szimulálja, hogy sokáig eltarthat a művelet

        return contents.Length;
    }

    private async void GetContentLengthButton_Click(object sender, RoutedEventArgs e)
    {
        var sw = Stopwatch.StartNew();
        string url1 = "https://learn.microsoft.com/dotnet";
        string url2 = "https://google.com";
        string url3 = "https://www.aut.bme.hu";

        getContentProgressRing.Visibility = Visibility.Visible;

        Task<int> t1 = GetUrlContentLengthAsync(url1);
        Task<int> t2 = GetUrlContentLengthAsync(url2);
        Task<int> t3 = GetUrlContentLengthAsync(url3);

        int len1 = await t1;
        int len2 = await t2;
        int len3 = await t3;

        getContentProgressRing.Visibility = Visibility.Collapsed;

        sw.Stop();
        contentLengthTextBlock.Text = $"{len1 + len2 + len3} bytes (operation time: {sw.ElapsedMilliseconds / 1000.0} seconds)";
    }
}
