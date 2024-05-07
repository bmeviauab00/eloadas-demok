using System.Reflection;

namespace MiscDemos;

class Program
{
    static void Main(string[] args)
    {
        GetTypeAndTypeOfDemo();
        Console.ReadKey(); Console.Clear();

        PrintTypesOfAssembly("MyLib.dll");
        Console.ReadKey(); Console.Clear();

        PrintMembersDemo();
        Console.ReadKey(); Console.Clear();

        CreateAndAccessMembersDemo();
        Console.ReadKey(); Console.Clear();
    }

    static void GetTypeAndTypeOfDemo()
    {
        Complex c1 = new Complex(10, 10);
        Type t1 = c1.GetType(); // A GetType is defined in base class object
        Console.WriteLine(t1.FullName);
        Type t2 = typeof(Complex); // "typeof" is a C# operator
        Console.WriteLine(t2.FullName);

    }

    static void PrintTypesOfAssembly(string assemblyName)
    {
        Assembly assembly;
        assembly = Assembly.LoadFrom(assemblyName);
        Type[] types = assembly.GetTypes();
        foreach (Type type in types)
            Console.WriteLine(type.FullName);
    }

    static void PrintMembersDemo()
    {
        Type type = typeof (Complex);
        Console.WriteLine("Fields:");
        foreach (FieldInfo fi in type.GetFields())
            Console.WriteLine("\t" + fi.Name);
        Console.WriteLine("Methods:");
        foreach (MethodInfo mi in type.GetMethods())
            Console.WriteLine("\t" + mi.Name);
    }

    static void CreateAndAccessMembersDemo()
    {
        // Create a Complex object
        Type complexType = Type.GetType("MiscDemos.Complex");
        ConstructorInfo ci = complexType.GetConstructor(new Type[0]);
        Object instance = ci.Invoke(null);

        // Access fields
        FieldInfo fi = complexType.GetField("Re");
        Console.WriteLine(fi.GetValue(instance));
        fi.SetValue(instance, 10);

        MethodInfo mi = complexType.GetMethod("Print");
        mi.Invoke(instance, null);
    }
}
