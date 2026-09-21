using IS;
static Doc Parse(string str)
{
    var parts = str.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

    string marketCost = parts[^1];
    parts.RemoveAt(parts.Count - 1);

    string govCost = parts[^1];
    parts.RemoveAt(parts.Count - 1);

    string date = parts[^1];
    parts.RemoveAt(parts.Count - 1);

    string birthDate = parts[^1];
    parts.RemoveAt(parts.Count - 1);

    string ownerName = string.Join(' ', parts).Trim('"');

    return new Doc(ownerName, birthDate, date, govCost, marketCost);
}

var list = new List<IPrintable>();

while (true)
{
    Console.WriteLine("Введите данные в виде: \"ФИО\" гггг.мм.дд гггг.мм.дд кадастровая стоимость рыночная стоимость");
    Console.WriteLine("Пример: \"Иван Иванов\" 2000.12.12 2020.05.09 1200000 2000000");

    string? str = Console.ReadLine();
    if (string.IsNullOrEmpty(str))
        break;

    try
    {
        list.Add(Parse(str));
    }
    catch
    {
        Console.WriteLine("Введённая строка не соответствует шаблону");
    }

    Console.Write("Чтобы продолжить нажмите Enter");
    while (true)
    {
        var key = System.Console.ReadKey(true);
        if (key.Key == ConsoleKey.Enter)
            break;
    }
    Console.Clear();
}