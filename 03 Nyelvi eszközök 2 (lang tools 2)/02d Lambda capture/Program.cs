
class Program
{
    static void Main()
    {
        IncrementFactory incrementFactory = new IncrementFactory();

        // We get a function that can be used to increment values by 10
        var increment0 = incrementFactory.GetIncrementFunc0();
        int res = increment0(100);
        Console.WriteLine(res);

        // We get a function that can be used to increment values defined by a local variable
        var increment = incrementFactory.GetIncrementFunc();
        res = increment(100);
        Console.WriteLine(res);

        var increment2 = incrementFactory.GetIncrementFunc2(30);
        res = increment2(100);
        Console.WriteLine(res);

        var increment3 = incrementFactory.GetIncrementFunc3();
        res = increment3(100);
        Console.WriteLine(res);
        incrementFactory.MemberDelta = 45;
        res = increment3(100); // This uses the updated MemberDelta value!
        Console.WriteLine(res);
    }
}


class IncrementFactory
{
    public int MemberDelta = 40;

    public Func<int, int> GetIncrementFunc0()
    {
        return n => n + 10;
    }

    public Func<int, int> GetIncrementFunc()
    {
        // Uses local variable
        int delta = 20;
        return n => n + delta;
    }

    public Func<int, int> GetIncrementFunc2(int delta)
    {
        // Uses parameter
        return n => n + delta;
    }

    public Func<int, int> GetIncrementFunc3()
    {
        // Uses member field
        return n => n + MemberDelta;
    }
}
