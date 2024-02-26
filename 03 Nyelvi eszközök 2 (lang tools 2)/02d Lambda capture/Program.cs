
class Program
{
    static void Main()
    {
        IncrementFactory incrementFactory = new IncrementFactory();

        // We get a function that can be used to increment values by 10
        var increment1 = incrementFactory.GetIncrementFunc1();
        int res = increment1(100);
        Console.WriteLine(res);

        // We get a function that can be used to increment values defined by a local variable
        var increment2 = incrementFactory.GetIncrementFunc2();
        res = increment2(100);
        Console.WriteLine(res);

        var increment3 = incrementFactory.GetIncrementFunc3(30);
        res = increment3(100);
        Console.WriteLine(res);

        var increment4 = incrementFactory.GetIncrementFunc4();
        res = increment4(100);
        Console.WriteLine(res);
        incrementFactory.MemberDelta = 45;
        res = increment4(100); // This uses the updated MemberDelta value!
        Console.WriteLine(res);
    }
}


class IncrementFactory
{
    public int MemberDelta = 40;

    public Func<int, int> GetIncrementFunc1()
    {
        return n => n + 10;
    }

    public Func<int, int> GetIncrementFunc2()
    {
        // Uses local variable
        int delta = 20;
        return n => n + delta;
    }

    public Func<int, int> GetIncrementFunc3(int delta)
    {
        // Uses parameter
        return n => n + delta;
    }

    public Func<int, int> GetIncrementFunc4()
    {
        // Uses member field
        return n => n + MemberDelta;
    }
}
