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
    public double OrbitalPos{get; set;} // todo: make this work
    
    /// <summary>
    /// Angular speed used for calculating orbit in warp in deg/day
    /// </summary>
    public double AngularSpeed { get; set; }

    public SpaceObject(string name, int distance, double weight, int diameter, double angularSpeed)
    {
        Random rnd = new Random();
        
        Name = name;
        Distance = distance;
        Weight = weight;
        Diameter = diameter;
        OrbitalPos = rnd.Next(0, 360);
        AngularSpeed = angularSpeed;
    }

    /// <summary>
    /// Adds orbital pos and angular speed based so it doesn't overflow 360° (Max degrees value)
    /// </summary>
    /// <param name="value"></param>
    public void AddOrbitalPos(double value)
    {
        if (OrbitalPos + value > 360)
        {
            OrbitalPos = OrbitalPos + value - 360;
        }
        else
        {
            OrbitalPos += value;
        }
    }

    public override string ToString()
    {
        if (Distance <= 0)
        {
            return Name + " -> Weight: " + Weight + " Earth Masses; Diameter: " + Diameter + " km" ;
        }
        return Name + " -> Distance: " + Distance + " million km from the sun; Orbital position: " + OrbitalPos + "°; Angular speed: " + AngularSpeed + " deg/day;";
    }
}