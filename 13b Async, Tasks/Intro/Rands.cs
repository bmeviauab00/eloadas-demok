using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncIntro;

class Rands
{
    // This is a synchronous CPU bound operation
    public static long CalculateSumOfRands(long count, int max)
    {
        Random r = new Random();
        long sum = 0;
        for (long i = 0; i <= count; i++)
            sum += r.Next(max + 1); ;
        return sum;
    }

    // This is a synchronous IO bound operation
    public static string GetLongestLine(string filePath)
    {
        using StreamReader reader = new StreamReader(filePath);
        string longestLine = string.Empty;
        string line = null;
        while ((line = reader.ReadLine()) != null)
        {
            if (line.Length > longestLine.Length)
                longestLine = line;
        }
        return longestLine;
    }


    // Async attempt. Works asynchronously (does not wait), but:
    // - How will the caller know, when the async operation is ready?
    // - How will the caller get the result?
    // - How will the caller get the errors (if any)?
    public static void BeginCalculateSumOfRands(long count, int max)
    {
        //ThreadPool.QueueUserWorkItem(_ =>
        //    {
        //        Random r = new Random();
        //        long sum = 0;
        //        for (long i = 0; i <= count; i++)
        //            sum += r.Next(max + 1); ;
        //        return sum;
        //    }
        //);
    }

    // A good Task based asynchronous solution
    public static Task<long> CalculateSumOfRandsAsync(long count, int max)
    {
        // Task.Run executes the code on a ThreadPool thread, does not wait for it to finish.
        // Instead, it returns a Task object, that represents this task.
        Task<long> task = Task.Run(() =>
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

    // Async attempt. Works asynchronously (does not wait), but:
    // - We are wasting a thread for serving the request. Instead, we should use true async IO based operations.
    // - How will the caller know, when the async operation is ready?
    // - How will the caller get the result?
    // - How will the caller get the errors (if any)?
    public static void BeginGetLongestLine(string filePath)
    {
        //ThreadPool.QueueUserWorkItem(_ =>
        //    {
        //        using StreamReader reader = new StreamReader(filePath);
        //        string longestLine = string.Empty;
        //        string line = null;
        //        while ((line = reader.ReadLine()) != null)
        //        {
        //            if (line.Length > longestLine.Length)
        //                longestLine = line;
        //        }
        //        return longestLine;
        //    }
        //);
    }

    // A good Task based asynchronous solution
    // (Let's create this operation from the sync version)
    public static async Task<string> GetLongestLineAsync(string filePath)
    {
        using StreamReader reader = new StreamReader(filePath);
        string longestLine = string.Empty;
        string line = null;
        // Don't use .Result to get the result, it would make this operation synchronous! Use await instead! 
        while ((line = await reader.ReadLineAsync()) != null)
        {
            if (line.Length > longestLine.Length)
                longestLine = line;
        }
        return longestLine;
    }

}
