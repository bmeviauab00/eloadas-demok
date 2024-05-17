using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncIntro
{
    internal class FileStatistics
    {
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
}
