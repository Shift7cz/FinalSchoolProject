namespace FinalProject2026.Sat;

/// <summary>
/// Is th satellite the user is controlling
/// </summary>
public class Satellite
{
    public string? Name { get; set; }
    
    public bool IsConfigured { get; set; }
    
    /// <summary>
    /// Used to simplify math after creation
    /// </summary>
    public double UnifiedFuelAmount { get; set; }
    
    /// <summary>
    /// World object used for positioning the satellite and for passing world data to terminal
    /// </summary>
    public World? SolarSystem { get; set; }
    
    /// <summary>
    /// Used for building the satellite by terminal
    /// </summary>
    public SateliteBuilder? Builder { get; set; }
    
    /// <summary>
    /// Tracks position
    /// </summary>
    public PositionTracker? PosTracker { get; set; }

    public List<SatBattery> SatBattery { get; set; }
    public List<SatFuelTank> SatFuelTank { get; set; }
    public List<SatEngine> SatEngine { get; set; }
    
    public Satellite()
    {
        Name = "n/a";
        SolarSystem = null;
        Builder = null;
        PosTracker = null;
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
        double thrust = 0;
        double weight = 0;
        
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
        }

        return thrust / weight;
    }

    /// <summary>
    /// Converts system of individual fuel tanks into one value system for simpler math
    /// </summary>
    public void UnifyFuel()
    {
        for (int i = 0; i < SatFuelTank.Count; i++)
        {
            UnifiedFuelAmount += SatFuelTank[i].Capacity;
        }
    }

    /// <summary>
    /// Moves in orbit up and down, calculates fuel burn, time for burn and preforms the travel itself with a warp.
    /// </summary>
    /// <param name="newHeight">Target orbital height</param>
    /// <returns>Returns status message that should go to the user</returns>
    public string ChangeOrbitalHeight(int newHeight)
    {
        if (PosTracker != null)
        {
            int deltaR = Math.Abs(newHeight - PosTracker.Distance);
            int totalFuelConsumption = 0;

            for (int i = 0; i < SatEngine.Count; i++)
            {
                totalFuelConsumption += SatEngine[i].FuelConsumption;
            }

            double burnTime = Math.Abs(deltaR) / GetAcceleration();
            double fuelUsed = totalFuelConsumption * burnTime; // in l

            if (fuelUsed > UnifiedFuelAmount)
            {
                return "Not enough fuel";
            }

            if (!Menu.YNoption("Do you want to travel? Total fuel consumed " + fuelUsed + "L out of " + UnifiedFuelAmount + "L and maneuver will take " + newHeight + " days ?",
                    'y'))
            {
                return "Maneuver canceled";
            }
        
            if (Warp.SkipTime(newHeight))
            {
                PosTracker.Distance = newHeight;
                UnifiedFuelAmount -= fuelUsed;
                return "Maneuver successful; Orbital height changed";
            }
        }
        else
        {
            Print.OutDebug("PosTracker is null");
        }

        return "Maneuver unsuccessful";
    }

    /// <summary>
    /// Changes orbital speed, calculates fuel burn, time for burn and preforms the maneuver with a warp (similar to MoveOrbitalHeight)
    /// </summary>
    /// <param name="newSpeed">hte target speed in deg/day</param>
    /// <returns>Returns status message that should go to the user</returns>
    public string ChangeOrbitalSpeed(double newSpeed)
    {
        if (PosTracker != null)
        {
            double deltaWDeg = newSpeed - PosTracker.AngularSpeed;
            double deltaWRad = deltaWDeg * (Math.PI / 180);
            double deltaVDay = deltaWRad * PosTracker.Distance;
            double deltaVSec = deltaVDay / 86400; // converts to secodns
        
            int totalFuelConsumption = 0;

            for (int i = 0; i < SatEngine.Count; i++)
            {
                totalFuelConsumption += SatEngine[i].FuelConsumption;
            }
        
            double burnTime = Math.Abs(deltaVSec) / GetAcceleration();
            double fuelUsed = totalFuelConsumption * burnTime * 100000; // in l; 100000x multiplier to fix the math not working for game balancing
        
            if (fuelUsed > UnifiedFuelAmount)
            {
                return "Not enough fuel";
            }

            if (!Menu.YNoption("Do you want to travel? Total fuel consumed " + fuelUsed + "L out of " + UnifiedFuelAmount + "L ?",
                    'y'))
            {
                return "Maneuver canceled";
            }

            PosTracker.AngularSpeed = newSpeed;
            UnifiedFuelAmount -= fuelUsed;
        }
        else
        {
            Print.OutDebug("PosTracker is null");
        }

        return "Maneuver successful; Orbital speed changed";
    }

    /// <summary>
    /// Snaps orbit to close positon (max 2 degrees robital pos difference and max 1 deg/day difference)
    /// </summary>
    /// <param name="newPos">The target pos</param>
    /// <param name="newSpeed">The target speed</param>
    /// <returns>Returns status message that should go to the user</returns>
    public string SnapOrbit(double newPos, double newSpeed)
    {
        if (PosTracker != null)
        {
            if (Math.Abs(newPos - PosTracker.OrbitalPos) >= 2)
            {
                return "Too far from target positon";
            }

            if (Math.Abs(newSpeed - PosTracker.AngularSpeed) >= 1)
            {
                return "Too much speed difference; slow down";
            }


            PosTracker.OrbitalPos = newPos;
            PosTracker.AngularSpeed = newSpeed;
            
            return "Maneuver successful; Orbit snapped to target positon";
        }
        else
        {
            Print.OutDebug("PosTracker is null");
            return "Maneuver canceled";
        }
    }
    
    /// <summary>
    /// Calculates how much to speed up to get to a space object in set time
    /// </summary>
    /// <param name="targetObject">In string the name of an object</param>
    /// <param name="targetDays">How much time in days should the maneuver take</param>
    /// <returns>Returns status message that should go to the user</returns>
    public string ChangePosition(string targetObject, int targetDays)
    {
        SpaceObject? target = null;
        bool hasFound = false;
        if (SolarSystem != null)
        {
            for (int i = 0; i < SolarSystem.OrbitingObjects.Count; i++)
            {
                if (SolarSystem.OrbitingObjects[i].Name.ToLower() == targetObject)
                {
                    target = SolarSystem.OrbitingObjects[i];
                    hasFound = true;
                }
            }
        }
        else
        {
            Print.OutDebug("SolarSystem is null");
        }

        if (!hasFound)
        {
            return "Target not found";
        }

        if (target != null && PosTracker != null)
        {
            double targetPos = target.CalculateOrbitalPos(target.AngularSpeed * targetDays);
        
            double degreesToTravel = targetPos - PosTracker.OrbitalPos;
            if (degreesToTravel < 0)
            {
                degreesToTravel += 360;
            }
        
            double requiredSpeed = (degreesToTravel)/targetDays;

            ChangeOrbitalSpeed(requiredSpeed);

            if (Warp.SkipTime(targetDays))
            {
                PosTracker.OrbitalPos = targetPos;
                return "Maneuver successful";
            }
        }
        else
        {
            Print.OutDebug("PosTracker or target is null");
        }

        return "Maneuver canceled";
    }
    
    /// <summary>
    /// Resets the satellite to default options
    /// </summary>
    public void Reset()
    {
        SatBattery = new List<SatBattery>();
        SatEngine = new List<SatEngine>();
        SatFuelTank = new List<SatFuelTank>();

        UnifiedFuelAmount = 0;
        IsConfigured = false;
        
        PosTracker = new PositionTracker(150, 0.986);
    }
}