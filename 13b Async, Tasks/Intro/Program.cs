using AsyncIntro;

namespace Intro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // long res = Rands.CalculateSumOfRands(1_000_000_000, 100);

            Task<long> task = Rands.CalculateSumOfRandsAsync(1_000_000_000, 100);
            // CalculateSumOfRandsAsync returned immediately, we could perform other tasks here

            // Let's wait for it (synchronously) to finish and print the result:
            long res = task.Result;
            Console.WriteLine($"Sum: {res}");

            // Console.WriteLine(Rands.GetLongestLine("Data.txt"));

            Console.WriteLine($"Longest line: {Rands.GetLongestLineAsync("Data.txt").Result}");

            // Let's make Main async and use await here as well instead of ".Result"!  (static async Task Main(string[] args))
        }
    }
}
