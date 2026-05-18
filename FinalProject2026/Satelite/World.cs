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
    
    public Satelite Sat { get; set; }

    public World(List<SpaceObject> orbitingObjects, SpaceObject centralObject)
    {
        OrbitingObjects = orbitingObjects;
        CentralObject = centralObject;
    }
}