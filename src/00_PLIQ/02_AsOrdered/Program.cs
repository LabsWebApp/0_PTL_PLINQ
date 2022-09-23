// AsOrdered, AsUnordered

IEnumerable<int> range = Enumerable.Range(0, 100_000);

var query1 = from num in range
                .AsParallel()
                .AsOrdered()
             where num % 2 == 0
             select num;
query1.ForAll(x => Console.Write($"{x} "));

Console.WriteLine($"\n\n");
Console.ReadKey();

var query2 = from num in query1
             .AsUnordered()
             where (num & (num - 1)) == 0 //
             select num;

query2.ForAll(x => Console.Write($"{x} "));

Console.ReadKey();