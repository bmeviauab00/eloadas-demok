
List<string> fruits = new List<string>() { "apple", "grape", "peach", "banana", "pineapple" };

// Filtering
var fuits2 = fruits.Where(f => f.Length <= 5);
// The type of fuits2 is IEnumerable<string>, we can use a
// forach to enumerate all items.
foreach (var f in fruits)
    Console.WriteLine(f);

// ToList creates a new List from the IEnumerable<string>
var fuits3 = fruits.Where(f => f.Length <= 5).ToList();


var fuits4 = fruits
    .Where(f => f.Length <= 5)  // Filtering
    .OrderBy(f => f.Length)     // Sorting
    .Select(f => $"Reverse: {f.Reverse()}, Length: {f.Length}") // Projection
    .ToList();


class StringWithLength
{
    public string Val;
    public int Y;
}

