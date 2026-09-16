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
    Console.WriteLine("Введите данные:");

    string? str = Console.ReadLine();
    if (string.IsNullOrEmpty(str))
        break;

    list.Add(Parse(str));

    Console.Clear();
}