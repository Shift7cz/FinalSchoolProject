namespace FinalProject2026.Satelite;

public class SpaceObject
{
    /// <summary>
    /// The name
    /// </summary>
    public string Name{ get; set; }

    /// <summary>
    /// Distance in million km
    /// </summary>
    public int Distance { get; set; }
    
    /// <summary>
    /// Weight in earth masses
    /// </summary>
    public double Weight { get; set; }

    public SpaceObject(string name, int distance, double weight)
    {
        Name = name;
        Distance = distance;
    }
}