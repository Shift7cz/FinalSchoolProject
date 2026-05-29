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
    public World SolarSystem { get; set; }
    
    /// <summary>
    /// Used for building the satellite by terminal
    /// </summary>
    public SateliteBuilder Builder { get; set; }
    
    /// <summary>
    /// Tracks position
    /// </summary>
    public PositionTracker PosTracker { get; set; }

    public List<SatBattery> SatBattery { get; set; }
    public List<SatFuelTank> SatFuelTank { get; set; }
    public List<SatEngine> SatEngine { get; set; }
    
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
    public bool MoveOrbitalHeight(int newHeight) // todo make this take time
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

        double burnTime = Math.Abs(deltaR) / GetAcceleration();
        double fuelUsed = totalFuelConsumption * burnTime; // in l

        if (fuelUsed > allFuel)
        {
            return false;
        }

        if (!Terminal.YNoption("Do you want to travel? Total fuel consumed " + fuelUsed + "L out of " + allFuel + "L and maneuver will take " + newHeight + " days ?",
                'y'))
        {
            return false;
        }

        PosTracker.Distance = newHeight; // todo: make fuel go out
        Warp.SkipTime(newHeight);
        return true;
    }

    /// <summary>
    /// Changes orbital speed, calculates fuel burn, time for burn and preforms the maneuver with a warp (similar to MoveOrbitalHeight)
    /// </summary>
    /// <param name="newSpeed">hte target speed in deg/day</param>
    /// <returns>Returns true if its possible, returns false if it's impossible or if user cancels</returns>
    public bool ChageOrbitalSpeed(double newSpeed)
    {
        double deltaWDeg = newSpeed - PosTracker.AngularSpeed;
        double deltaWRad = deltaWDeg * (Math.PI / 180);
        double deltaVDay = deltaWRad * PosTracker.Distance;
        double deltaVSec = deltaVDay / 86400; // converts to secodns
        
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
        
        double burnTime = Math.Abs(deltaVSec) / GetAcceleration();
        double fuelUsed = totalFuelConsumption * burnTime; // in l
        
        if (fuelUsed > allFuel)
        {
            return false;
        }

        if (!Terminal.YNoption("Do you want to travel? Total fuel consumed " + fuelUsed + "L out of " + allFuel + "L and maneuver will take " + burnTime/86400 + " days ?",
                'y'))
        {
            return false;
        }

        PosTracker.AngularSpeed = newSpeed;
        Warp.SkipTime((int)burnTime/86400);
        return true;
    }
    
    // TODO: central body gravity?
}
