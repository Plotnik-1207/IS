using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS
{
    public static class DocParser
    {
        public static Doc Parse(string str)
        {
            var parts = str.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            if (parts.Count < 5)
                throw new Exception();

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
    }
}
