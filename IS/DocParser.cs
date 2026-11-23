using System;
using System.Globalization;
using System.Linq;

namespace IS
{
    public static class DocParser
    {
        public static Doc Parse(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                throw new FormatException("Строка пустая");

            const string format = "yyyy.MM.dd";

            string trimmed = str.Trim();

            if (!trimmed.StartsWith("\""))
                throw new FormatException("Имя должно начинаться с кавычки");

            int closingQuoteIndex = trimmed.IndexOf('"', 1);

            if (closingQuoteIndex < 0)
                throw new FormatException("Имя должно быть закрыто кавычкой");

            string ownerName = trimmed
                .Substring(1, closingQuoteIndex - 1)
                .Trim();

            if (string.IsNullOrWhiteSpace(ownerName))
                throw new FormatException("Имя не может быть пустым");

            string restString = trimmed.Substring(closingQuoteIndex + 1);

            var restParts = restString
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (restParts.Length != 4)
                throw new FormatException("После имени должно быть ровно 4 поля");

            if (!int.TryParse(restParts[3], NumberStyles.Integer, CultureInfo.InvariantCulture, out int marketCost) ||
                !int.TryParse(restParts[2], NumberStyles.Integer, CultureInfo.InvariantCulture, out int govCost))
            {
                throw new ArgumentException("Стоимость записана неправильно");
            }

            if (govCost < 0 || marketCost < 0)
                throw new ArgumentException("Стоимость не может быть отрицательной");

            if (!DateTime.TryParseExact(restParts[1], format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date) ||
                !DateTime.TryParseExact(restParts[0], format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime birthDate))
            {
                throw new ArgumentException("Неправильно введённая дата");
            }

            return new Doc(ownerName, birthDate, date, govCost, marketCost);
        }
    }
}