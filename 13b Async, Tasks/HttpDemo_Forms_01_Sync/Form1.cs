using System.Diagnostics;
using System.Net.Http;

namespace HttpDemo_Forms
{
    public partial class Form1 : Form
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public Form1()
        {
            InitializeComponent();
        }

        // Szinkron művelet, blokkol
        public int GetUrlContentLength(string url)
        {
            // Egy stringbe letölti az adott url (weboldal) tartalmát
            // Megjegyzés: maga a GetStringAsync aszinkron, de a Result tulajdonság lekérdezése
            // szinkron: blokkol, amíg nincs eredmény.
            var content = _httpClient.GetStringAsync(url).Result;

            Thread.Sleep(2000); // Szimulálja, hogy sokáig eltarthat a művelet
            return content.Length;
        }

        private void bGetContentLength_Click(object sender, EventArgs e) // Gombkatt. eseménykezelő
        {
            string url1 = "https://learn.microsoft.com/dotnet";
            string url2 = "https://google.com";
            string url3 = "https://www.aut.bme.hu";

            var sw = Stopwatch.StartNew(); // Stopwatch objektummal mérjük a futási időt

            int len1 = GetUrlContentLength(url1);
            int len2 = GetUrlContentLength(url2);
            int len3 = GetUrlContentLength(url3);

            sw.Stop();

            lContentLength.Text = $"{len1 + len2 + len3}  bytes " +
                $"(operation time: {sw.ElapsedMilliseconds / 1000.0} seconds)";
        }

    }
}