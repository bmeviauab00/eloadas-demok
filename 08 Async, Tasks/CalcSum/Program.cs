namespace CalcSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // long res = CalculateSumOfRands(1_000_000_000, 100);
            Task<long> task = CalculateSumOfRandsAsync(1_000_000_000, 100);

            // Itt lehet más feladatot csinálni

            // Várjuk be és kérdezzük le az eredményét
            long res = task.Result;

            Console.WriteLine($"Sum: {res}");
        }

        static long CalculateSumOfRands(long count, int max)
        {
            Random r = new Random();
            long sum = 0;
            for (long i = 0; i <= count; i++)
                sum += r.Next(max + 1); ;
            return sum;
        }

        // A Task.Run a paraméterében kapott függvényt beteszi egy threadpool "sorba"
        // és visszaad egy Task-ot, mely ezt a feladatot reprezentálja. Nem várja meg,
        // hogy befejeződjön a task!
        static Task<long> CalculateSumOfRandsAsync(long count, int max)
        {
            Task<long>  task = Task.Run( () =>
                {
                    Random r = new Random();
                    long sum = 0;
                    for (long i = 0; i <= count; i++)
                        sum += r.Next(max + 1); ;
                    return sum;
                }
                );
            return task;
        }

    }
}