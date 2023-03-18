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

        public int GetAge()
        {
            return DateTime.Now.Year - yearOfBirth;
        }

        public void PrintName()
        {
            Console.WriteLine(name);
        }

        public string Name
        {
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(Name));
                name = value;
            }
            get { return name; }
        }

        public int Age
        {
            get { return DateTime.Now.Year - yearOfBirth; }
        }
    }
}
