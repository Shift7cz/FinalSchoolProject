namespace FinalProject2026.Satelite;

/// <summary>
/// Is th satellite I'm controlling
/// </summary>
public class Satellite
{
    public string Name { get; set; }
    
    /// <summary>
    /// World object used for positioning the satellite and for passing world data to terminal
    /// </summary>
    public World SolarSystem { get; set; } // todo: find a way to track pos that isn't stupid af
    
    /// <summary>
    /// Used for building the satellite by terminal
    /// </summary>
    public SateliteBuilder Builder { get; set; }
    
    public List<SatBattery> SatBattery { get; set; } // todo temp
    public List<SatFuelTank> SatFuelTank { get; set; } // todo temp
    public List<SatEngine> SatEngine { get; set; } // todo temp

    public Satellite()
    {
        SatBattery = new List<SatBattery>();
        SatEngine = new List<SatEngine>();
        SatFuelTank = new List<SatFuelTank>();
    }
}