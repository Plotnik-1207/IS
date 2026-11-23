namespace IS
{
    public class Doc
    {
        public Person Owner { get; }
        public DateTime Date { get; }
        public Cost Cost { get; }

        public Doc(string ownerName, DateTime birthDate, DateTime date, int govCost, int marketCost)
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
