using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS
{
    public class Doc
    {
        public Person Owner { get; }
        public string Date { get; }
        public Cost Cost { get; }

        public Doc(string ownerName, string birthDate, string date, string govCost, string marketCost)
        {
            Owner = new Person(ownerName, birthDate);
            Date = date;
            Cost = new Cost(govCost, marketCost);
        }
        public override string ToString()
        {
            return $"Владелец: {Owner.ToString()} | Дата регистрации: {Date} | Стоимость: {Cost.ToString()}";
        }
    }
}
