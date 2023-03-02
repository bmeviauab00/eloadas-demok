using System.Globalization;

namespace HelloApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello world!");

            // #1 Projekt referencia
            int sum = Math.BasicMath.Add(10, 20);
            Console.WriteLine($"Sum: {sum}");

            // #2 Szerelvény referencia
            string encryptedText = Crypto.Encryptor.Encrypt("alma");
            Console.WriteLine($"encryptedText: {encryptedText}");

            // #3 NuGet használata
            // https://joshclose.github.io/CsvHelper/getting-started/
            // Install-Package CsvHelper
            using (var reader = new StreamReader(@"..\..\..\data\SampleFile.txt"))
            using (var csv = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Person>();

                foreach (var record in records)
                    Console.WriteLine(record);
            }
        }
    }
}