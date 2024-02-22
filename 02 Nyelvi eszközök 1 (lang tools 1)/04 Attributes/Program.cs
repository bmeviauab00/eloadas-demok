using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Attributes
{
    [Serializable]
    class User
    {
        public string Name;
        public int Age;

        [NonSerialized]
        string password;

        [Obsolete("This method is obsolete. Call DeleteUser2 instead.", false)]
        public static void DeleteUser(int userId)
        {
            // ...
        }

        public static void DeleteUser2(int userId)
        {
            // ...
        }


        public User(string name, int age, string password)
        {
            Name = name;
            Age = age;
            this.password = password;
        }

        // ...
    }

    class Program
    {
        static void Main(string[] args)
        {
            User user = new User("Joe", 30, "password");
            // felparaméterezzük ...

            //  Szerializalas egy file stream-be
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream1 = new FileStream("Dump.dat", FileMode.Create);
            formatter.Serialize(stream1, user);
            stream1.Close();

            //  Deszerializalas a file stream-bol
            FileStream stream2 = new FileStream("Dump.dat", FileMode.Open);
            User u = (User)formatter.Deserialize(stream2);
            stream2.Close();

            // Warning a build során, mert Obsolete-nek jeöltük a függvényt
            User.DeleteUser(12);
        }
    }
}
