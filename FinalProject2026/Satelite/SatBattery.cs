namespace FinalProject2026.Satelite;

/// <summary>
/// Battery object
/// </summary>
public class SatBattery : ISatelitePartable, IDegradeable
{
    public string Name { get; set; }
    public string Type { get; set; }
    public char Size { get; set; }
    public int Weight { get; set; }
    public int DegradeTime { get; set; }
    public int Hp { get; set; }
    
    /// <summary>
    /// Battery level in %
    /// </summary>
    public int BatteryLevel { get; set; }
    
    /// <summary>
    /// Battery capacity in kwh (kilowatt-hours)
    /// </summary>
    public int Capacity { get; set; } // todo: make this be right measurement
    
    /// <summary>
    /// Max level the battery can safely charge to in %
    /// </summary>
    public int MaxChargeLevel { get; set; }

    public SatBattery(string name, string type, char size, int weight, int degradeTime, int hp, int batteryLevel,
        int capacity, int maxChargeLevel)
    {
        Name = name;
        Type = type;
        Size = size;
        Weight = weight;
        DegradeTime = degradeTime;
        Hp = hp;
        BatteryLevel = batteryLevel;
        Capacity = capacity;
        MaxChargeLevel = maxChargeLevel;
        RecalculateMaxChargeLevel();
    }
    
    /// <summary>
    /// Recalculates max charge level based on part hp
    /// </summary>
    public void RecalculateMaxChargeLevel()
    {
        MaxChargeLevel = Capacity - (100 - Hp);
        if (BatteryLevel > MaxChargeLevel)
        {
            BatteryLevel = MaxChargeLevel;
        }
    }
} 