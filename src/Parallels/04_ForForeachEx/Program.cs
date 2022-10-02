//ForEach<TSource, TLocal>(
//      Partitioner<TSource> source,
//      ParallelOptions parallelOptions,
//      Func <TLocal> localInit,
//      Func <TSource, ParallelLoopState, TLocal, TLocal> body,
//      Action <TLocal> localFinally)

object locker = new();
double result = 0;
const int source = 1000000000;

// Параллельный расчет суммы корней всех чисел от 1 до 1,000,000,000
Parallel.ForEach(Enumerable.Range(1, source), Init, Body, Finally);
Console.WriteLine(result);

result = 0;
Parallel.ForEach(
    Enumerable.Range(1, source),
    () => 0D, 
    (x, _, local) => local + Math.Sqrt(x), 
    local => { lock (locker) result += local; });
Console.WriteLine(result);

// Генерирует изначальное значение для локального промежутка
double Init() => 0D;

// Используется в расчете локальной суммы определенной части коллекции
double Body(int x, ParallelLoopState _, double local) => local + Math.Sqrt(x);

// Здесь происходит обращение к общему ресурсу с использованием синхронизации
//      - вычисляется сумма локальных сумм
void Finally(double local)
{
    lock (locker) result += local;
}