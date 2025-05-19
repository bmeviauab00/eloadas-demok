using System.Reflection;
using Storage;

namespace GeneralSave;

class SaveUtils
{

    public static void Save(object o)
    {
        Type type = o.GetType();

        // Save is to be called with object of classes that have StorableClassAttribute (so missing attribute is an error)
        object[] attributes =
            type.GetCustomAttributes(Type.GetType("Storage.StorableClassAttribute"), false);

        if (attributes.Length == 0)
            throw new ApplicationException("The type of the object is not marked with StorableClassAttribute.");

        FieldInfo[] fieldInfos =
             type.GetFields(BindingFlags.Public |
             BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);

        foreach (FieldInfo fi in fieldInfos)
        {
            object[] fieldAttributes = fi.GetCustomAttributes(typeof(StorableAttribute), false);
            if (fieldAttributes.Length == 0)
                continue;
            StorableAttribute attr = (StorableAttribute)fieldAttributes[0];

            // As this is just a simplistic demo: do not perform the save, just display data on the console
            if (attr.SaveType == true)
                Console.WriteLine($"Type: {fi.FieldType}");
            Console.WriteLine($"Name: {attr.Name}");
            Console.WriteLine($"Value: {fi.GetValue(o)}");
        }
    }

    // Performs validation: prints out a warning for those classes which have members with StorableAttribute, but the
    // class is not marked with the StorableClassAttribute attribute.
    public static void CheckAssembly(Assembly assembly)
    {
        Type[] types = assembly.GetTypes();

        foreach (Type type in types)
        {
            object[] attributes =
                type.GetCustomAttributes(Type.GetType("Storage.StorableClassAttribute"), false);

            if (attributes.Length != 0)
                continue;

            FieldInfo[] fieldInfos =
             type.GetFields(BindingFlags.Public |
             BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);

            foreach (FieldInfo fi in fieldInfos)
            {
                object[] fieldAttributes = fi.GetCustomAttributes(Type.GetType("Storage.StorableAttribute"), false);
                if (fieldAttributes.Length != 0)
                {
                    Console.WriteLine($"Warning: class {type} is not marked with attribute Storage.StorableAttribute, but members are marked with attribute Storage.StorableAttribute");
                    break;
                }
            }
        }
    }
}
