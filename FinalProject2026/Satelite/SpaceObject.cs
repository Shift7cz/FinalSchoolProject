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
    
    /// <summary>
    /// Diameter in km
    /// </summary>
    public int Diameter { get; set; }

    public SpaceObject(string name, int distance, double weight, int diameter)
    {
        Name = name;
        Distance = distance;
        Weight = weight;
        Diameter = diameter;
    }

    public override string ToString()
    {
        if (Distance <= 0)
        {
            return Name + " -> Weight: " + Weight + " Earth Masses; Diameter: " + Diameter + " km" ;
        }
        return Name + " -> Distance: " + Distance + " million km from the sun; Weight: " + Weight + " Earth Masses; Diameter: " + Diameter + " km";
    }
}