using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS
{
    public class Person
    {
        public string Name { get; }
        public string BirthDate { get; }

        public Person(string name, string birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }
        public override string ToString()
        {
            return $"Имя: {Name} | Дата рождения: {BirthDate}";
        }
    }
}
