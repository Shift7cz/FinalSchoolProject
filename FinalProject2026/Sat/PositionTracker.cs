namespace FinalProject2026.Sat;

/// <summary>
/// Tracks position of satellite object. Works similar to SpaceObject
/// </summary>
public class PositionTracker
{
    /// <summary>
    /// Orbiting distance from central object in millions km
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
        AngularSpeed = angularSpeed;
    }
    
    /// <summary>
    /// Adds orbital pos by using CalculateOrbitalPos() so it doesnt overflow
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
}