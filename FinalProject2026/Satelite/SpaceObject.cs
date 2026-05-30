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
    /// Distance in millions km
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
    public double OrbitalPos{get; set;}
    
    /// <summary>
    /// Angular speed used for calculating orbit in warp in deg/day
    /// </summary>
    public double AngularSpeed { get; set; }
    
    /// <summary>
    /// Multiplier for points rewarding the player for reaching more changing locations
    /// </summary>
    public double PointsMultiplier{ get; set; }

    public SpaceObject(string name, int distance, double weight, int diameter, double angularSpeed, double pointsMultiplier)
    {
        Random rnd = new Random();
        
        Name = name;
        Distance = distance;
        Weight = weight;
        Diameter = diameter;
        OrbitalPos = rnd.Next(0, 360);
        AngularSpeed = angularSpeed;
        PointsMultiplier = pointsMultiplier;
    }

    /// <summary>
    /// Adds orbital pos by using ClaculateOrbitalPos() so it doesnt overflow
    /// </summary>
    /// <param name="value">How much to add</param>
    /// <returns>Retnrs orbital pos</returns>
    public double AddOrbitalPos(double value)
    {
        OrbitalPos = CalculateOrbitalPos(value);
        return OrbitalPos;
    }
    
    /// <summary>
    /// Calculates what would orbital pos be after adding value (so it doesn't overflow), doest change the original variable
    /// </summary>
    /// <param name="value">How much to add</param>
    /// <returns>How much would it add up to</returns>
    public double CalculateOrbitalPos(double value)
    {
        return (OrbitalPos + value) % 360;
    }

    public override string ToString()
    {
        if (Distance <= 0)
        {
            return Name + " -> Weight: " + Weight + " Earth Masses; Diameter: " + Diameter + " km" ;
        }
        return Name + " -> Distance: " + Distance + " million km from the sun; Orbital position: " + OrbitalPos + "°; Angular speed: " + AngularSpeed + " deg/day; Points multiplier: " +  PointsMultiplier + ";";
    }
}