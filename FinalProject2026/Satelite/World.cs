namespace FinalProject2026.Satelite;

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
    
    /// <summary>
    /// Tracks the current satelites position if empty its not near any.
    /// </summary>
    public SpaceObject SatPos{ get; set; }

    public World(List<SpaceObject> orbitingObjects, SpaceObject centralObject, SpaceObject satPos)
    {
        OrbitingObjects = orbitingObjects;
        CentralObject = centralObject;
        SatPos = satPos;
    }
}