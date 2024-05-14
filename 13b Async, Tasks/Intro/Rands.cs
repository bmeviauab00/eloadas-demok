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

    // This is a synchronous IO bound operation
    public static int GetLongestLineLength(string filePath)
    {
        using StreamReader reader = new StreamReader(filePath);
        int longestLineLength = -1;
        string line = null;
        while ((line = reader.ReadLine()) != null)
        {
            if (line.Length > longestLineLength)
                longestLineLength = line.Length;
        }
        return longestLineLength;
    }

    // Async attempt. Works asynchronously (does not wait), but:
    // - We are wasting a thread for serving the request. Instead, we should use true async IO based operations.
    // - How will the caller know, when the async operation is ready?
    // - How will the caller get the result?
    // - How will the caller get the errors (if any)?
    public static void BeginGetLongestLineLength(string filePath)
    {
        //ThreadPool.QueueUserWorkItem(_ =>
        //    {
        //        using StreamReader reader = new StreamReader(filePath);
        //        int longestLineLength = -1;
        //        string line = null;
        //        while ((line = reader.ReadLine()) != null)
        //        {
        //            if (line.Length > longestLineLength)
        //                longestLineLength = line.Length;
        //        }
        //        return longestLineLength;
        //    }
        //);
    }

    // A good Task based asynchronous solution
    // (Let's create this operation from the sync version)
    public static async Task<int> GetLongestLineLengthAsync(string filePath)
    {
        using StreamReader reader = new StreamReader(filePath);
        int longestLineLength = -1;
        string line = null;
        while ((line = await reader.ReadLineAsync()) != null)
        {
            if (line.Length > longestLineLength)
                longestLineLength = line.Length;
        }
        return longestLineLength;
    }

}
