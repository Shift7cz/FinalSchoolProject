namespace FinalProject2026.Sat;

/// <summary>
/// Class that defines the satellite engine part
/// </summary>
public class SatEngine : ISatelitePartable
{
    public string Name { get; set; }
    public string Type { get; set; }
    public char Size { get; set; }
    public int Weight { get; set; }
    public int Hp { get; set; }
    
    /// <summary>
    /// Thrust in N (newtons)
    /// </summary>
    public int Thrust { get; set; }
    
    /// <summary>
    /// Can be either "electric" or "fuel" (Not implemented)
    /// </summary>
    public string FuelType { get; set;  }
    
    /// <summary>
    /// How much fuel does the engine eat in L/s
    /// </summary>
    public int FuelConsumption { get; set; }

    public SatEngine(string name, string type, char size, int weight, int hp, int thrust, string fuelType, int fuelConsumption)
    {
        Name = name;
        Type = type;
        Size = size;
        Weight = weight;
        Hp = hp;
        Thrust = thrust;
        FuelType = fuelType;
        FuelConsumption = fuelConsumption;
    }
}