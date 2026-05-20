namespace FinalProject2026.Satelite;

/// <summary>
/// Adds basic option ofr all sat parts - MANDATORY FOR SATELLITE PARTS
/// </summary>
public interface ISatelitePartable
{
    public string Name { get; set; }
    
    /// <summary>
    /// What is it
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// What's its size, smaller parts can be attached to bigger ports or port can be attached to the prot of the same size ('s', 'm', 'l')
    /// </summary>
    public char Size { get; set; }
    
    /// <summary>
    /// How much does its weight in kg (only the part itself, variable wight is handled per type)
    /// </summary>
    public int Weight { get; set; }
    
    /// <summary>
    /// Health of the part in % (Health Point)
    /// </summary>
    public int Hp { get; set; }
}