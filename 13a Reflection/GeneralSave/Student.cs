using Storage;

namespace GeneralSave
{
    [StorableClass]
    class Student
    {
        [Storable("Name")]
        private string name;
        [Storable("Neptun", SaveType= true)]
        private string neptun;

        public Student(string name, string neptun)
        {
            if (neptun.Length != 6)
                throw new ArgumentOutOfRangeException("neptun", "Neptun code must be 6 characters long.");
            this.name = name;
            this.neptun = neptun;
        }

        public override string ToString()
        {
            return String.Format($"Name: {{0}}; Neptun: {{1}}", name, neptun);
        }
    }
}
