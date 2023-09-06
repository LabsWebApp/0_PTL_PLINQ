// WithExecutionMode
using System.Collections.Concurrent;

const int total = 1000;
ConcurrentDictionary<int, int> dictionary = new ConcurrentDictionary<int, int>();

bool WhereFilter(int number)
{
    dictionary.AddOrUpdate(
        Thread.CurrentThread.ManagedThreadId,
        1,
        (key, value) => ++value);
    //Thread.Sleep(1);
    return number % 2 == 0;
}

var query = from num in Enumerable.Range(0, total)
        .AsParallel()
        .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
            where WhereFilter(num)
    select num;

query.ForAll(x => x++);

Console.WriteLine($"\n\nРезультаты обработки потоков c ForceParallelism:");
foreach (var item in dictionary)
{
    Console.WriteLine($"Поток #{item.Key} обработал {item.Value} элементов.");
}

dictionary.Clear();
query = from num in Enumerable.Range(0, total)
        .AsParallel()
        .WithExecutionMode(ParallelExecutionMode.Default)
        where WhereFilter(num)
    select num;

query.ForAll(x => x++);

Console.WriteLine($"\n\nРезультаты обработки потоков:");
foreach (var item in dictionary)
{
    Console.WriteLine($"Поток #{item.Key} обработал {item.Value} элементов.");
}

Console.ReadKey();

