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
}