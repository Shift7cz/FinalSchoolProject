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
    public int OrbitalePos { get; set; }

    public PositionTracker(int distance, int orbitalePos)
    {
        Distance = distance;
        OrbitalePos = orbitalePos;
    }
}