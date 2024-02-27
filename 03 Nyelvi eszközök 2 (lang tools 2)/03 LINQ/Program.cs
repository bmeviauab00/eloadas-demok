
List<string> fruits = new List<string>() { "apple", "grape", "peach", "banana", "pineapple" };

// Filtering
var fruits2 = fruits.Where(f => f.Length <= 5);
// The type of fuits2 is IEnumerable<string>, so we can use a
// forach to enumerate all items.
foreach (var f in fruits2)
    Console.WriteLine(f);

Console.WriteLine();

var fruits3 = fruits
    .Where(f => f.Length <= 6)  // Filtering
    .Select(f => $"Uppercase: {f.ToUpper()}, Length: {f.Length}") // Projection
    .ToList();
foreach (var f in fruits3)
    Console.WriteLine(f);

// ToList creates a new List from the IEnumerable<string>
var fuits4 = fruits.Where(f => f.Length <= 5).ToList();
