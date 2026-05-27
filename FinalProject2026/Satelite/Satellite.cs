namespace FinalProject2026.Satelite;

/// <summary>
/// Is th satellite the user is controlling
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
    
    public PositionTracker PosTracker { get; set; }
    
    public List<SatBattery> SatBattery { get; set; } // todo temp
    public List<SatFuelTank> SatFuelTank { get; set; } // todo temp
    public List<SatEngine> SatEngine { get; set; } // todo temp

    
    public Satellite()
    {
        SatBattery = new List<SatBattery>();
        SatEngine = new List<SatEngine>();
        SatFuelTank = new List<SatFuelTank>(); 
    }

    /// <summary>
    /// Calculates acceleration produced by rocket
    /// </summary>
    /// <returns>The acceleration</returns>
    public double GetAcceleration()
    {
        int thrust = 0;
        int weight = 0;
        
        for (int i = 0; i < SatEngine.Count; i++)
        {
            thrust += SatEngine[i].Thrust;
            weight += SatEngine[i].Weight;
        }
        for (int i = 0; i < SatBattery.Count; i++)
        {
            weight += SatBattery[i].Weight;
        }
        for (int i = 0; i < SatFuelTank.Count; i++)
        {
            SatFuelTank[i].RecalculateAdditionalWeight();
            weight += SatFuelTank[i].Weight;
            weight += SatFuelTank[i].AdditionalWeight;
        }

        return thrust / weight;
    }

    /// <summary>
    /// Moves in orbit up and down, calculates fuel burn, time for burn and preforms the travel itself with a warp.
    /// </summary>
    /// <param name="newHeight">Target orbital height</param>
    /// <returns>Returns true if its possible, returns false if it's impossible or if user cancels</returns>
    public bool MoveOrbitalHeight(int newHeight)
    {
        int deltaR = Math.Abs(newHeight - PosTracker.Distance);
        int totalFuelConsumption = 0;
        int allFuel = 0;

        for (int i = 0; i < SatFuelTank.Count; i++)
        {
            allFuel += (SatFuelTank[i].Capacity / 100) * SatFuelTank[i].FuelLevel;
        }

        for (int i = 0; i < SatEngine.Count; i++)
        {
            totalFuelConsumption += SatEngine[i].FuelConsumption;
        }

        double burnTime = deltaR / GetAcceleration();
        double fuelUsed = totalFuelConsumption * burnTime; // in l

        if (fuelUsed > allFuel)
        {
            return false;
        }

        if (!Terminal.YNoption("Do you want to travel? Total fuel consumed " + fuelUsed + "L out of " + allFuel + "L?",
                'y'))
        {
            return false;
        }

        PosTracker.Distance = newHeight;
        return true;
    }
}