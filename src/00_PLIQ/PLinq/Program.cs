// AsParallel()
long Square(int n) => (long)n * n;

var numbers = Enumerable.Range(int.MaxValue - 9, 10).AsParallel();
var squares = 
    from n in numbers
    select new { n, square = Square(n) };

// ForAll()
squares.ForAll(Console.WriteLine);