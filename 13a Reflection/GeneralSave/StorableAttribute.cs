
namespace Storage;

/// <summary>
/// Attribute to denote Saveable fields
/// </summary>
///
[AttributeUsage(AttributeTargets.Field)]
public class StorableAttribute : System.Attribute
{
    string name;
    // El kell-e mentenünk a típust is
    bool saveType;


    public StorableAttribute(string name)
    {
        this.name = name;
        saveType = false;

    }

    public string Name
    {
        get { return name; }
    }

    public bool SaveType
    {
        get { return saveType; }
        set { saveType = value; }
    }

    override public string ToString()
    {
        return  String.Format($"Name: {{0}}; SaveType: {{1}}", name, saveType.ToString());
    }

}
