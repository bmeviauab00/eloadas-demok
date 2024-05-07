using System.Reflection;
using Storage;

namespace GeneralSave;

class SaveUtils
{

    public static void Save(object o)
    {
        Type type = o.GetType();

        // Ha nincs StorableClassAttribute, akkor hib�t adunk
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

            // Ebben a dem�ban nem ment�nk, helyette ki�rjuk a konzolra
            // a ment�shez sz�ks�ges param�tereket.
            if (attr.SaveType == true)
                Console.WriteLine($"Type: {fi.FieldType}");
            Console.WriteLine($"Name: {attr.Name}");
            Console.WriteLine($"Value: {fi.GetValue(o)}");
        }
    }

    // Kisz�ri azokat, akiknek nem StorableClass az oszt�lyuk,
    // de
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
