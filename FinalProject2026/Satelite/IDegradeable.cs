namespace FinalProject2026.Satelite;

public interface IDegradeable
{
    /// <summary>
    /// how long does it take for the part to fully break in seconds; -1 for no degrading
    /// </summary>
    public int DegradeTime { get; set; }
    
    /// <summary>
    /// Recalculates the bp based on DegradeTime
    /// </summary>
    public void RecalculateHp();
}