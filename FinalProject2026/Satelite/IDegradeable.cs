namespace FinalProject2026.Satelite;

/// <summary>
/// Adds option for parts to degrade over time todo: implement
/// </summary>
public interface IDegradeable
{
    /// <summary>
    /// how long does it take for part to degrade 1 hp in day
    /// </summary>
    public int DegradeTime { get; set; }
}