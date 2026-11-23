using IS;

void Main()
{
    var list = new List<Doc>();

    string path = "data.txt";

    if (!File.Exists(path))
    {
        Console.WriteLine($"Файл не найден: {path}");
        return;
    }

    foreach (var str in File.ReadLines(path))
    {
        Console.WriteLine($"Текущая строка: {str}");
        try
        {
            var parsedItem = DocParser.Parse(str);
            Console.WriteLine(parsedItem);
            list.Add(parsedItem);
        }
        catch (Exception e)
        {
            Console.WriteLine("Ошибка: " + e.Message);
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
}

Main();