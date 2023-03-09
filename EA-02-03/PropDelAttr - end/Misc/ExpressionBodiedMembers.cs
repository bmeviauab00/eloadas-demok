namespace Misc
{
    public class Person
    {
        private string name;
        private int yearOfBirth;

        public Person(string name, int yearOfBirth)
        {
            this.name = name;
            this.yearOfBirth = yearOfBirth;
        }

        public int GetAge() => DateTime.Now.Year - yearOfBirth;

        public void PrintName() => Console.WriteLine(name);

        public string Name
        {
            set => name = value != null ? value: throw new ArgumentNullException(nameof(value));
            get => name;
        }

        // Csak egy egy kifejezésből álló get ág esetén
        public int Age => DateTime.Now.Year - yearOfBirth;
    }
}
