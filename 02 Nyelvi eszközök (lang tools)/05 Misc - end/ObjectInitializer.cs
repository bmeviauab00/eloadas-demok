namespace ObjectInitializer
{
    class Person
    {
        public string Name { get; set; }
        public int YearOfBirth { get; set; }

    }

    class TestClass
    {
        public void UsePerson()
        {
            Person person = new Person()
            {
                Name = "Joe",
                YearOfBirth = 2000
            };
        }
    }
}