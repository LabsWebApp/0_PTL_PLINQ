// AsParallel()
Console.WriteLine();
long Square(int n) => (long)n * n;

var numbers = Enumerable.Range(1, 20).AsParallel();
var squares = from n in numbers select Square(n);

// ForAll()
squares.ForAll(Console.WriteLine);