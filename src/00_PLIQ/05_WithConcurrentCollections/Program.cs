// Использование PLINQ совместно с ConcurrentDictionary
// WithDegreeOfParallelism
using System.Collections.Concurrent;

ConcurrentDictionary<int, int> dictionary = new ConcurrentDictionary<int, int>();

bool WhereFilter(int number)
{
    dictionary.AddOrUpdate(
        Thread.CurrentThread.ManagedThreadId, 
        1, 
        (key, value) => ++value);
    return number % 2 == 0;
}

var query = from num in Enumerable.Range(0, 1000)
        .AsParallel()
        .WithDegreeOfParallelism(Environment.ProcessorCount / 2)
    where WhereFilter(num)
    select num;

query.ForAll(x => Console.Write($"{x} "));

Console.WriteLine($"\n\nРезультаты обработки потоков:");
foreach (var item in dictionary)
{
    Console.WriteLine($"Поток #{item.Key} обработал {item.Value} элементов.");
}

Console.ReadKey();
