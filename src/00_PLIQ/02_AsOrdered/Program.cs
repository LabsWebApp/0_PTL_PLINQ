// AsOrdered, AsUnordered

IEnumerable<int> range = Enumerable.Range(0, 100);

var query1 = 
    from num in range 
        .AsParallel()
        .AsOrdered()
    where num % 2 == 0
    select num;

foreach (var item in query1.ToArray()) Console.Write($"{item} ");
Console.WriteLine();
query1.ForAll(x => Console.Write($"{x} "));

Console.WriteLine($"\n");
//Console.ReadKey();

var query2 = from num in query1
             .AsUnordered()
             where (num & (num - 1)) == 0 //
             select num;

foreach (var item in query2) Console.Write($"{item} ");

Console.ReadKey();