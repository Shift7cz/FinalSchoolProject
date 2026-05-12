namespace FinalProject2026.Satelite;

public class Satelite
{
    public string Name { get; set; }
    public int Fuel { get; set; }
    public World SolarSystem { get; set; }

    public Satelite(string name, int fuel, World solarSystem)
    {
        Name = name;
        Fuel = fuel;
        SolarSystem = solarSystem;
    }
}