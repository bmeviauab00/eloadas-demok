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

        public async Task<int> GetUrlContentLengthAsync(string url)
        {
            Task<string> getStringTask =
                _httpClient.GetStringAsync(url);

            // ... valamilyen műveletek, melyek nem használják a getStringTask eredményét ...

            string contents = await getStringTask;
            await Task.Delay(2000); // Szimulálja, hogy sokáig eltarthat a művelet

            return contents.Length;
        }

        private async void bGetContentLength_Click(object sender, EventArgs e)
        {
            var sw = Stopwatch.StartNew();
            string url1 = "https://learn.microsoft.com/dotnet";
            string url2 = "https://google.com";
            string url3 = "https://www.aut.bme.hu";

            Task<int> t1 = GetUrlContentLengthAsync(url1);
            Task<int> t2 = GetUrlContentLengthAsync(url2);
            Task<int> t3 = GetUrlContentLengthAsync(url3);

            int len1 = await t1;
            int len2 = await t2;
            int len3 = await t3;

            sw.Stop();
            lContentLength.Text = $"{len1 + len2 + len3} bytes (operation time: {sw.ElapsedMilliseconds / 1000.0} seconds)";
        }
    }
}