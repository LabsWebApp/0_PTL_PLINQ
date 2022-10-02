// вычисляем квадрат числа
void Square(int n)
{
    Console.WriteLine($"Выполняется задача {Task.CurrentId}");
    Console.WriteLine($"Квадрат числа {n} равен {n * n} (задача {Task.CurrentId})");
    Thread.Sleep(1000);
}

//Parallel.For(2, 5, Square);

//Console.WriteLine("************");
//Thread.Sleep(1500);

//ParallelLoopResult result = Parallel.ForEach<int>(
//    new List<int> { 1, 3, 5, 8 },
//    Square
//);
//Console.WriteLine($"IsCompleted - {result.IsCompleted}; LowestBreakIteration = {result.LowestBreakIteration ?? -1}\n");

//Console.WriteLine("************");
//break; stop;

ParallelLoopResult result = Parallel.For(1, 10, (i, pls) =>
{
    if (i == 5)
        //pls.Break();
        pls.Stop();
    Square(i);
});
Console.WriteLine($"IsCompleted - {result.IsCompleted}; LowestBreakIteration = {result.LowestBreakIteration ?? -1}\n");

Thread.Sleep(1500);
Console.WriteLine("************");

Parallel.ForEach(Enumerable.Range(1, 100), (i, pls) =>
{
    if (pls.IsStopped) return;
    switch (i)
    {
        case 2:
        case 50:
            Thread.Sleep(100);
            break;
        case 5:
            //pls.Break();
            pls.Stop();
            break;
    }
    Square(i);
});
Console.WriteLine($"IsCompleted - {result.IsCompleted}; LowestBreakIteration = {result.LowestBreakIteration ?? -1}");


Console.ReadLine();
