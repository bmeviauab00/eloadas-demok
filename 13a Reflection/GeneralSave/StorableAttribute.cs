namespace Storage;

/// <summary>
/// Attribute to denote savable fields
/// </summary>
[AttributeUsage(AttributeTargets.Field)]
public class StorableAttribute : System.Attribute
{
    private readonly string name;
    private bool saveType;

    /// <summary>
    /// Initializes a new instance of the <see cref="StorableAttribute"/> class.
    /// </summary>
    /// <param name="name">The name used for storage identification.</param>
    public StorableAttribute(string name)
    {
        this.name = name;
        saveType = false;
    }

    /// <summary>
    /// Gets the name used for storage identification.
    /// </summary>
    public string Name => name;

    /// <summary>
    /// Gets or sets a value indicating whether the type information should be saved.
    /// </summary>
    public bool SaveType
    {
        get => saveType;
        set => saveType = value;
    }

    /// <summary>
    /// Returns a string representation of the attribute.
    /// </summary>
    /// <returns>A string containing the attribute properties.</returns>
    public override string ToString() => $"Name: {name}; SaveType: {saveType}";
}
