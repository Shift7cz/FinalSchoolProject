using FinalProject2026.Satelite;

namespace FinalProject2026.Commands;

/// <summary>
/// Controls the satellite
/// </summary>
public class SateliteCommand : ICommandable
{
    public Terminal Term { get; set; }
    public string Name { get; set; }
    
    /// <summary>
    /// Collects return in run function for unified return; prevents bugs
    /// </summary>
    private string _returnValue;

    public SateliteCommand(Terminal term, string name)
    {
        Term = term;
        Name = name;
    }
    
    public string Run(List<string> input)
    {
        _returnValue = ""; // resets _returnValue to prevent functions returning previous returns
        
        try
        {
            Print.OutDebug("Entering SatelliteCommand");
            switch (input[1].ToLower())
            {
                case "new": // TODO remake this to dynamic stalemate body system ts is ugly af and temporary af
                    OptionNew();
                    break;

                case "list":
                    _returnValue = "Batteries\n";

                    for (int i = 0; i < Term.Satellite.SatBattery.Count; i++)
                    {
                        _returnValue += " | " + Term.Satellite.SatBattery[i].Name + " \n";
                    }

                    _returnValue += "\nFuel Tanks\n";

                    for (int i = 0; i < Term.Satellite.SatFuelTank.Count; i++)
                    {
                        _returnValue += " | " + Term.Satellite.SatFuelTank[i].Name + "\n";
                    }

                    _returnValue += "\nEngines\n";

                    for (int i = 0; i < Term.Satellite.SatEngine.Count; i++)
                    {
                        _returnValue += " | " + Term.Satellite.SatEngine[i].Name + "\n";
                    }

                    _returnValue += "\n\nPosition Data\n";
                    _returnValue += " | Distance: " + Term.Satellite.PosTracker.Distance + " million Km\n";
                    _returnValue += " | Angular Speed: " + Term.Satellite.PosTracker.AngularSpeed + " deg/day\n";
                    _returnValue += " | Orbital Position: " + Term.Satellite.PosTracker.OrbitalPos + " °\n";

                    break;
                case "travel":
                    TravelOption(input);
                    break;
            }
        }
        catch (Exception e)
        {
            Print.OutDebug(e.Message);
            Print.OutLn("Bad requesr. Type help for help");
        }

        if (_returnValue != string.Empty)
        {
            return _returnValue;
        }
        return "";
    }

    /// <summary>
    /// Wraps the new option command witch so the switch doesn't have 100+ lines
    /// </summary>
    private void OptionNew()
    {
        Print.OutDebug("new option");

        if (Term.VirtualWorld.Sat != null)
        {
            bool proceed =
                Terminal.YNoption(
                    "Are you sure you want to do this? you already have an existing satellite and by running this command it will be destroyed",
                    'n');
            if (proceed) return;
        }

        Print.Out("Enter name of your satellite: ");
        string name = Print.ReadLn();

        Term.Satellite.Name = name;

        Print.OutDebug(Term.Satellite.Name);

        List<string> partList;
        List<ISatelitePartable> partListRaw;

        partList = new List<string>(); // todo: make ths display some part detail
        partListRaw = new List<ISatelitePartable>();

        Print.OutDebug("battery");
        for (int i = 0; i < Term.Satellite.Builder.SatBatteryList.Count; i++)
        {
            partListRaw.Add(Term.Satellite.Builder.SatBatteryList[i]);
            partList.Add("Battery: " + Term.Satellite.Builder.SatBatteryList[i].Name);
            Print.OutDebug(Term.Satellite.Builder.SatBatteryList[i].Name);
        }

        Print.OutDebug("tank");
        for (int i = 0; i < Term.Satellite.Builder.SatFuelTankList.Count; i++)
        {
            partListRaw.Add(Term.Satellite.Builder.SatFuelTankList[i]);
            partList.Add("Fuel Tank: " + Term.Satellite.Builder.SatFuelTankList[i].Name);
            Print.OutDebug(Term.Satellite.Builder.SatFuelTankList[i].Name);
        }

        Print.OutDebug("engine");
        for (int i = 0; i < Term.Satellite.Builder.SatEngineList.Count; i++)
        {
            partListRaw.Add(Term.Satellite.Builder.SatEngineList[i]);
            partList.Add("Engine: " + Term.Satellite.Builder.SatEngineList[i].Name);
            Print.OutDebug(Term.Satellite.Builder.SatEngineList[i].Name);
        }

        List<int> selectedInt = Menu.SelectMultiple("Select parts: ", partList);
        List<ISatelitePartable> selected = new List<ISatelitePartable>();

        if (!Terminal.YNoption("Are you sure you want to create this satellite?", ' ')) // todo: make this display parts
            return;
        
        for (int i = 0; i < selectedInt.Count; i++) // todo: make this not be the loop with extended family ahh
        {
            Print.OutDebug("i = " + i);
            string currentPart = partListRaw[selectedInt[i]].Name;

            for (var j = 0; j < partListRaw.Count; j++)
            {
                Print.OutDebug("j = " + j);
                if (currentPart == partListRaw[j].Name)
                {
                    Print.OutDebug("Match part found, its a");
                    ISatelitePartable currentPartObj = partListRaw[j];

                    if (currentPartObj is SatBattery checkedBattery) // checks if object is the required type and wraps it so the compiler doesn't scream
                    {
                        Print.OutDebug("battery");
                        Term.Satellite.SatBattery.Add(checkedBattery);
                    }
                    else if (currentPartObj is SatFuelTank checkedFuelTank)
                    {
                        Print.OutDebug("fuel tank");
                        Term.Satellite.SatFuelTank.Add(checkedFuelTank);
                    }
                    else if (currentPartObj is SatEngine checkedEngine)
                    {
                        Print.OutDebug("engine");
                        Term.Satellite.SatEngine.Add(checkedEngine);
                    }
                    else
                    {
                        Print.OutDebug("Error at line 97 in SatelliteCommand in checking type of object - object type does not match nay required");
                    }
                }
            }
        }

        Print.OutDebug("Finished");
    }

    /// <summary>
    /// Wraps the trave option command witch so the switch doesn't have 100+ lines
    /// </summary>
    /// <param name="input">The input command list</param>
    private void TravelOption(List<string> input) // todo: quit function
    {
        switch (input[2].ToLower())
        {
            case "height":
                Print.OutLn("Please enter desired height in million km, current height of orbit around the sun is " +
                            Term.Satellite.PosTracker.Distance + " million km: ");
                int targetHeight;
                while (!int.TryParse(Print.ReadLn(), out targetHeight))
                {
                    Print.OutLn("Please enter valid whole number");
                }

                _returnValue += Term.Satellite.ChangeOrbitalHeight(targetHeight);
                break;
            case "speed":
                Print.OutLn("Please enter desired angular speed in degrees/day. Current angular speed is " +
                            Term.Satellite.PosTracker.AngularSpeed + " deg/day: ");
                double targetSpeed;
                while (!double.TryParse(Print.ReadLn(), out targetSpeed))
                {
                    Print.OutLn("Please enter valid number");
                }

                _returnValue += Term.Satellite.ChageOrbitalSpeed(targetSpeed);
                break;
            case "snap":
                Print.OutLn("Please enter desired angular speed in degrees/day. Current angular speed is " +
                            Term.Satellite.PosTracker.AngularSpeed +
                            " deg/day. Note that this command is only for fine adjustments up to 1 deg/day : ");
                double targetSpeedSnap;
                while (!double.TryParse(Print.ReadLn(), out targetSpeedSnap))
                {
                    Print.OutLn("Please enter valid number");
                }

                Print.OutLn("Please enter desired orbital position in degrees. Current position is " +
                            Term.Satellite.PosTracker.AngularSpeed +
                            " °. Note that this command is only for fine adjustments up to 2° : ");
                double targetPosSnap;
                while (!double.TryParse(Print.ReadLn(), out targetPosSnap))
                {
                    Print.OutLn("Please enter valid number");
                }

                _returnValue += Term.Satellite.SnapOrbit(targetPosSnap, targetSpeedSnap);
                break;
            case "body":
                Print.OutLn("Enter to which body do u want to travel to. Keep in mind that you have to be on the same height to reach its actuall position. Use sat travel height to do so if you haven't already: ");
                string targetBody = Print.ReadLn();
                
                Print.OutLn("Enter target time in days for the transition. Keep in mind that shorter time resoults in less fuel usage: ");
                int targetDays;
                while (!int.TryParse(Print.ReadLn(), out targetDays))
                {
                    Print.OutLn("Please enter valid whole number");
                }
                
                _returnValue = Term.Satellite.ChangePosition(targetBody, targetDays);
                break;
        }
    }
}