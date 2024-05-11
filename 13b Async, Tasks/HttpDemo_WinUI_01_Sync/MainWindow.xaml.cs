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

    public int GetUrlContentLength(string url)
    {
        // Egy stringbe letölti az adott url (weboldal) tartalmát
        // Megjegyzés: maga a GetStringAsync aszinkron, de a Result tulajdonság lekérdezése
        // szinkron: blokkol, amíg nincs eredmény.
        var content = _httpClient.GetStringAsync(url).Result;

        Thread.Sleep(2000); // Szimulálja, hogy sokáig eltarthat a művelet
        return content.Length;
    }

    private void GetContentLengthButton_Click(object sender, RoutedEventArgs e) // Gombkatt. eseménykezelő
    {
        string url1 = "https://learn.microsoft.com/dotnet";
        string url2 = "https://google.com";
        string url3 = "https://www.aut.bme.hu";

        var sw = Stopwatch.StartNew(); // Stopwatch objektummal mérjük a futási időt

        int len1 = GetUrlContentLength(url1);
        int len2 = GetUrlContentLength(url2);
        int len3 = GetUrlContentLength(url3);

        sw.Stop();

        contentLengthTextBlock.Text = $"{len1 + len2 + len3}  bytes " +
            $"(operation time: {sw.ElapsedMilliseconds / 1000.0} seconds)";
    }
}
