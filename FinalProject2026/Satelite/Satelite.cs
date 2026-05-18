namespace FinalProject2026.Satelite;

public class Satelite
{
    public string Name { get; set; }
    public World SolarSystem { get; set; }

    public Satelite(string name, World solarSystem)
    {
        Name = name;
        SolarSystem = solarSystem;
    }
}