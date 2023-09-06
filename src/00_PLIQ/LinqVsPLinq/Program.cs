// TEST

using System.Diagnostics;

const int Tests = 1000000;

long Calculate(long num) => (long)(Math.Pow(num, num * 2) + num + 15 * Math.Pow(2, num));

void TestLinq()
{
    Stopwatch timer = Stopwatch.StartNew();
    var list = (from n in Enumerable.Range(0, Tests)
        where n % 2 == 0
        select Calculate(n)).ToList();
    timer.Stop();
    Console.WriteLine($"LINQ  выполнил работу за {timer.ElapsedMilliseconds:N} мс. Посчитал: {list.Count}");
}

void TestPLinq()
{
    Stopwatch timer = Stopwatch.StartNew();
    var list = (from n in Enumerable.Range(0, Tests)
            .AsParallel()
        where n % 2 == 0
        select Calculate(n)).ToList();
    timer.Stop();
    Console.WriteLine($"PLINQ выполнил работу за {timer.ElapsedMilliseconds:N} мс. Посчитал: {list.Count}");
}

for (int i = 0; i < 5; i++)
{
    TestPLinq();
    TestLinq();
    Console.WriteLine();
}

Console.ReadKey();