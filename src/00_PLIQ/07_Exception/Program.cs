// Exception

IEnumerable<int> Range(int from, int to)
{
    for (var i = from; i < to; i++)
    {
        yield return i;

        if (i == 10_000) throw new Exception($"Ошибка в метод Range на {i} итерации.");
    }
}

var query = from num in Range(0, 100_000)
        .AsParallel()
    where num % 2 == 0
    select num;

try
{
    foreach (var item in query) Console.Write($"{item} ");
}
catch (AggregateException e)
{
    Console.WriteLine("\n\n");
    Console.WriteLine($"Базовое исключение - {e.GetType()}");
    Console.WriteLine("Вложенные исключения:");

    foreach (var item in e.InnerExceptions)
    {
        Console.WriteLine($"Исключение {item.GetType()}");
        Console.WriteLine($"Сообщение: {item.Message}");
        Console.WriteLine(new string('-', 80));
    }
}

Console.ReadKey();