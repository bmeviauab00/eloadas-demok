
using UtilizeCPU;

internal class Program
{
    static void Main(string[] args)
    {
        LongRunningAlg.Run_SingleThreaded();
        LongRunningAlg.Run_MultipleThreaded();
    }
}
