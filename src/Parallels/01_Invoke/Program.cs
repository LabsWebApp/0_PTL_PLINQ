// Parallel также является частью TPL и предназначен для упрощения параллельного выполнения кода.

// Invoke
// метод Parallel.Invoke выполняет три метода
Parallel.Invoke(
    Print,
    () =>
    {
        Console.WriteLine($"Выполняется задача {Task.CurrentId} (Lambda)");
        Thread.Sleep(3000);
    },
    () => Square(5)
);

Console.WriteLine("*******************");

Parallel.Invoke(
    new ParallelOptions { MaxDegreeOfParallelism = 1 },
    Print,
    () =>
    {
        Console.WriteLine($"Выполняется задача {Task.CurrentId} (Lambda)");
        Thread.Sleep(3000);
    },
    () => Square(5));

void Print()
{
    Console.WriteLine($"Выполняется задача {Task.CurrentId} (Method)");
    Thread.Sleep(3000);
}
// вычисляем квадрат числа
void Square(int n)
{
    Console.WriteLine($"Выполняется задача {Task.CurrentId} (Square)");
    Thread.Sleep(3000);
    Console.WriteLine($"Результат {n * n} (задача {Task.CurrentId})");
}

Console.WriteLine("Задачи выполнены!");
Console.ReadLine();