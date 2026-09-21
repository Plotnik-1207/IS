using IS;
using System.IO;
static void Main()
{
    var list = new List<object>();

    string path = "C:\\Users\\Plotnik\\Documents\\data.txt";
    string[] lines = File.ReadAllLines(path);

    foreach (var str in lines)
    {
        Console.WriteLine($"Текущая строка: {str}");
        try
        {
            Console.WriteLine(DocParser.Parse(str));
            list.Add(DocParser.Parse(str));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
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
/*
while (true)
{
    Console.WriteLine("Введите данные в виде: \"ФИО\" гггг.мм.дд гггг.мм.дд кадастровая стоимость рыночная стоимость");
    Console.WriteLine("Пример: \"Иван Иванов\" 2000.12.12 2020.05.09 1200000 2000000");

    string? str = Console.ReadLine();
    if (string.IsNullOrEmpty(str))
        break;

    try
    {
        list.Add(DocParcer.Parse(str));
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
*/