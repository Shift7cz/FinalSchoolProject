namespace FinalProject2026.Satelite;

public interface ISatEngineable
{
    /// <summary>
    /// Thrust in (todo: in what?)
    /// </summary>
    public int Thrust { get; set; } // todo: fine a intelligent way to measure ts
    
    /// <summary>
    /// Can be either "electric" or "fuel"
    /// </summary>
    public string FuelType { get; set; }
}