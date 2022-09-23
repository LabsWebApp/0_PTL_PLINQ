// AsSequential
string[] cars = { "Nissan", "Aston Martin", "Chevrolet", "Alfa Romeo", "Chrysler", "Dodge", "BMW",
    "Ferrari", "Audi", "Bentley", "Ford", "Lexus", "Mercedes", "Toyota", "Volvo", "Subaru", "Жигули :)"};

IEnumerable<string> auto = cars
    .AsParallel()
    .AsOrdered()
    .Where(p => p.Contains('a'))
    .Take(5) // берём всего 5 элементов ||-изм излишен
    .AsSequential()
    .Where(p => p.Contains('o'))
    .Select(p => p);

foreach (string s in auto) Console.WriteLine("Совпадение: " + s);