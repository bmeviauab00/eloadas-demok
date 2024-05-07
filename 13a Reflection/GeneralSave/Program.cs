namespace GeneralSave;

class Program
{
    static void Main(string[] args)
    {
        Student student = new Student("James Bond", "007007");

        // Az aktuális szerelvént ellenőrizzük,
        // lehetne Assembly.LoadFrommal betöltött assembly is
        SaveUtils.CheckAssembly(typeof(Student).Module.Assembly);
        SaveUtils.Save(student);
    }
}
