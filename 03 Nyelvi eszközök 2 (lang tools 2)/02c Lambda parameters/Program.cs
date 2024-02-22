// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


// No parameter: empty brackets
Action line = () => Console.WriteLine();

// One parameter: brackets are optional
Func<double, double> cube = x => x * x * x;

// Multiple parameters: same syntax as for normal function parameters
Func<int, int, bool> testForEquality = (x, y) => x == y;

// Remember: in some rare cases the compiler can't infer the type parameters,
// then we have to provide the type of the parameters as well
// (note, that this would not be necessary in this example):
Func<int, string, bool> isTooLong = (int x, string s) => s.Length > x;