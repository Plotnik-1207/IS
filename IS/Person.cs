namespace IS
{
    public class Person
    {
        public string Name { get; }
        public DateTime BirthDate { get; }

        public Person(string name, DateTime birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }
        public override string ToString()
        {
            return $"Имя: {Name} | Дата рождения: {BirthDate.ToString()}";
        }
    }
}
