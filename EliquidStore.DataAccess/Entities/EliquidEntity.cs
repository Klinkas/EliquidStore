namespace EliquidStore.DataAccess.Entities;

public class EliquidEntity
{
    /// <summary>
    /// E liquid ID
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// E liquid name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// E liquid flavor
    /// </summary>
    public string Flavor { get; set; } = string.Empty;

    /// <summary>
    /// E liquid capacity
    /// </summary>
    public int Capacity { get; set; } = 0;
}