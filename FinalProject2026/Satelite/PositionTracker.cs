namespace FinalProject2026.Satelite;

public class PositionTracker
{
    /// <summary>
    /// Orbiting distance from central object in million km
    /// </summary>
    public int Distance{ get; set; }
    
    /// <summary>
    /// Orbital pos in degrees (same as in SpaceObject)
    /// </summary>
    public double OrbitalPos { get; set; }
    
    /// <summary>
    /// Angular speed in deg/day (same as in SpaceObject)
    /// </summary>
    public double AngularSpeed { get; set; }

    public PositionTracker(int distance, double angularSpeed)
    {
        Distance = distance;
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
        double orbitalPos = OrbitalPos;
        if (orbitalPos + value > 360)
        {
            orbitalPos = orbitalPos + value - 360;
        }
        else
        {
            orbitalPos += value;
        }
        
        if (orbitalPos > 360)
        {
            orbitalPos = 360;
        }
        
        return orbitalPos;
    }
}