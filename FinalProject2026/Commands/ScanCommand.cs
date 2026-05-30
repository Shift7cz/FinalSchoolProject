using FinalProject2026.Satelite;

namespace FinalProject2026.Commands;

/// <summary>
/// Allows the user to scan all the bodies in the planetary system for points.
/// </summary>
public class ScanCommand : ICommandable
{
    public Terminal Term { get; set; }
    public string Name { get; set; }

    public ScanCommand(Terminal term, string name)
    {
        Term = term;
        Name = name;
    }
    
    public string Run(List<string> input)
    {
        SpaceObject? target = null;

        try
        {
            bool hasFound = false;
            if (Term.VirtualWorld != null)
            {
                for (int i = 0; i < Term.VirtualWorld.OrbitingObjects.Count; i++)
                {
                    if (Term.VirtualWorld.OrbitingObjects[i].Name.ToLower() == input[1])
                    {
                        target = Term.VirtualWorld.OrbitingObjects[i];
                        hasFound = true;
                    }
                }
            }

            if (!hasFound)
            {
                return "Target not found, please enter a valid space object name. (type objects for object names)";
            }
        }
        catch (Exception e)
        {
            Print.OutDebug(e.Message);
            return "User error. Please enter valid name";
        }

        if (Term.Satellite != null && target != null && Term.Satellite.PosTracker != null)
        {

            if (Term.Satellite.PosTracker.Distance != target.Distance)
            {
                return "Distance doesnt match with target";
            }

            // This warning is ok
            if (Term.Satellite.PosTracker.OrbitalPos != target.OrbitalPos)
            {
                return "Orbital position doesnt match with target";
            }

            // This warning is ok
            if (target != null && Term.Satellite != null &&
                Term.Satellite.PosTracker.AngularSpeed != target.AngularSpeed)
            {
                return "Angular speed doesnt match with target";
            }
        }
        else
        {
            Print.OutDebug("Term.Satellite or target or Term.Satellite.PosTracker is null");
        }

        int batteriesLevel = 0;
        int batteriesCapaity = 0;

        if (Term.Satellite != null)
        {
            for (int i = 0; i < Term.Satellite.SatBattery.Count; i++)
            {
                batteriesLevel += Term.Satellite.SatBattery[i].BatteryLevel;
                batteriesCapaity += Term.Satellite.SatBattery[i].Capacity;
            }
        }

        if (Term.Satellite != null && Term.Satellite.SatBattery.Count == 0)
        {
            batteriesLevel /= Term.Satellite.SatBattery.Count;
        }

        Print.OutLn("Please enter the amount of energy you would like to assign to this scan in %. Your current battery reserve is at " +  batteriesLevel + "% which is total of " +  batteriesCapaity*batteriesLevel/100 + "kwh. More power will equal more points: ");
        
        int targetPower;
        while (!int.TryParse(Print.ReadLn(), out targetPower))
        {
            Print.OutLn("Please enter valid whole number");
        }

        if (targetPower > batteriesLevel)
        {
            return "Invalid value. Please enter value in % and make shure that it is less tha the bateries have";
        }


        if (target != null)
        {
            PointsManager.AddPoints((int)(((targetPower * batteriesCapaity) / 100) * target.PointsMultiplier));

            if (Term.Satellite != null)
            {
                for (int i = 0; i < Term.Satellite.SatBattery.Count; i++)
                {
                    Term.Satellite.SatBattery[i].BatteryLevel -= targetPower;
                }
            }
            else
            {
               Print.OutDebug("Term.Satellite is null"); 
            }

            return "Scanned " + target.Name + " successfully.";
        }

        // this will never happen
        return "Warning. Invalid file: bodies.txt";
    }
}