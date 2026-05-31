namespace FinalProject2026.Sat;

/// <summary>
/// Class that defines the satellite fuel tank part
/// </summary>
public class SatFuelTank : ISatellitePartable
{
    public string Name { get; set; }
    public string Type { get; set; }
    public char Size { get; set; }
    public int Weight { get; set; }
    public int Hp { get; set; }
    
    /// <summary>
    /// Capacity in l
    /// </summary>
    public int Capacity { get; set; }
    
    /// <summary>
    /// Current fuel level in %
    /// </summary>
    public int FuelLevel { get; set; }
    
    /// <summary>
    /// Additional fuel weight in kg
    /// </summary>
    public int AdditionalWeight { get; set; }
    
    /// <summary>
    /// How much does 1kg of the fue weight
    /// </summary>
    public int FuelWeightPerKg { get; set; }

    public SatFuelTank(string name, string type, char size, int weight, int hp, int capacity, int fuelLevel)
    {
        Name = name;
        Type = type;
        Size = size;
        Weight = weight;
        Hp = hp;
        Capacity = capacity;
        FuelLevel = fuelLevel;
        AdditionalWeight = 0;
        RecalculateAdditionalWeight();
    }
    
    /// <summary>
    /// Recalculates the additional weight
    /// </summary>
    public void RecalculateAdditionalWeight()
    {
        AdditionalWeight = FuelWeightPerKg * (FuelLevel * Capacity);
    }
}