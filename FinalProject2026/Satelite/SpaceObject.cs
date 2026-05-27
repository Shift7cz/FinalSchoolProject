namespace FinalProject2026.Satelite;

/// <summary>
/// Object used in the world to define planets, sun and different bodies
/// </summary>
public class SpaceObject
{
    /// <summary>
    /// The name of the object
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
    
    /// <summary>
    /// Orbital position in degrees
    /// </summary>
    public int OrbitalPos{get; set;} // todo: make this work
    
    /// <summary>
    /// Angular speed used for calculating orbit in warp in deg/day
    /// </summary>
    public double AngularSpeed { get; set; }

    public SpaceObject(string name, int distance, double weight, int diameter, double angularSpeed)
    {
        Name = name;
        Distance = distance;
        Weight = weight;
        Diameter = diameter;
        OrbitalPos = 0;
        AngularSpeed = angularSpeed;
    }

    public override string ToString()
    {
        if (Distance <= 0)
        {
            return Name + " -> Weight: " + Weight + " Earth Masses; Diameter: " + Diameter + " km" ;
        }
        return Name + " -> Distance: " + Distance + " million km from the sun; Weight: " + Weight + " Earth Masses; Diameter: " + Diameter + " km; Orbital position: " + OrbitalPos + "°; Angular speed: " + AngularSpeed + " deg/day;";
    }
}