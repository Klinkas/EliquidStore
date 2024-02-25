namespace EliquidStore.Core.Models;

/// <summary>
/// E liquid model
/// </summary>
public class Eliquid
{
    public const int MAX_NAME_LENGTH = 256;
    
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="id"> id </param>
    /// <param name="name"> name </param>
    /// <param name="flavor"> flavor </param>
    /// <param name="capacity"> capacity </param>
    private Eliquid(Guid id, string name, string flavor, int capacity)
    {
        Id = id;
        Name = name;
        Flavor = flavor;
        Capacity = capacity;
    }
    
    /// <summary>
    /// E liquid ID
    /// </summary>
    public Guid Id { get; }
    
    /// <summary>
    /// E liquid name
    /// </summary>
    public string Name { get; } = string.Empty;

    /// <summary>
    /// E liquid flavor
    /// </summary>
    public string Flavor { get; } = string.Empty;

    /// <summary>
    /// E liquid capacity
    /// </summary>
    public int Capacity { get; } = 0;

    /// <summary>
    /// Safely create eliquid model
    /// </summary>
    public static (Eliquid eliquid, string Error) Create(Guid id, string name, string flavor, int capacity)
    {
        var error = string.Empty;

        if (string.IsNullOrEmpty(name) || name.Length > MAX_NAME_LENGTH)
        {
            error = "Name cannot be empty or longer then 256 characters";
        }
        
        var eliquid = new Eliquid(id, name, flavor, capacity);

        return (eliquid, error);
    }
}