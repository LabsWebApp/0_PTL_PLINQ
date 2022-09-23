// WithCancellation

CancellationTokenSource cts = new CancellationTokenSource();
CancellationToken token = cts.Token;

var query = from num in Enumerable.Range(0, 100000)
        .AsParallel()
        .WithCancellation(token)
    where num % 2 == 0
    select num;

cts.CancelAfter(1000);

try
{
    query.ForAll(x => Console.Write($"{x} "));
}
catch (OperationCanceledException ex)
{
    Console.WriteLine("\n\n");
    Console.WriteLine($"Исключение - {ex.GetType()}");
    Console.WriteLine($"Сообщение: {ex.Message}");
    Console.WriteLine($"Hashcode токена исключения: {ex.CancellationToken.GetHashCode()}");
    Console.WriteLine($"Hashcode токена из метода Main: {token.GetHashCode()}");
}

Console.ReadKey();