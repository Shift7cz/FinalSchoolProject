namespace FinalProject2026.Satelite;

/// <summary>
/// The world the satellite moves in.
/// </summary>
public class World
{
    /// <summary>
    /// List of orbiting objects like planets
    /// </summary>
    public List<SpaceObject> OrbitingObjects { get; set; }
    
    /// <summary>
    /// Basically the sun, the think other orbit around
    /// </summary>
    public SpaceObject CentralObject { get; set; }
    
    public Satellite Sat { get; set; }

    public World(List<SpaceObject> orbitingObjects, SpaceObject centralObject, Satellite sat)
    {
        OrbitingObjects = orbitingObjects;
        CentralObject = centralObject;
        Sat = sat;
    }
}