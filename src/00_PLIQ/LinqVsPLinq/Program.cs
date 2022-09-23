// TEST

using System.Diagnostics;

long Calculate(long num) => (long)(Math.Pow(num, num * 2) + num + 15 * Math.Pow(2, num));

void TestLinq()
{
    Stopwatch timer = Stopwatch.StartNew();
    var list = (from n in Enumerable.Range(0, 100_000_000)
        where n % 2 == 0
        select Calculate(n)).ToList();
    timer.Stop();
    Console.WriteLine($"LINQ  выполнил работу за {timer.ElapsedMilliseconds:N} мс. Посчитал: {list.Count}");
}

void TestPLinq()
{
    Stopwatch timer = Stopwatch.StartNew();
    var list = (from n in Enumerable.Range(0, 100_000_000)
            .AsParallel()
        where n % 2 == 0
        select Calculate(n)).ToList();
    timer.Stop();
    Console.WriteLine($"PLINQ выполнил работу за {timer.ElapsedMilliseconds:N} мс. Посчитал: {list.Count}");
}

for (int i = 0; i < 5; i++)
{
    TestLinq();
    TestPLinq();
    Console.WriteLine();
}

Console.ReadKey();