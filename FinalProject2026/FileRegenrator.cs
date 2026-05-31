namespace FinalProject2026;

/// <summary>
/// Handles file checking
/// </summary>
public static class FileRegenrator
{
    private static void PingFile(string path)
    {
        StreamReader sr = new StreamReader(path);
        sr.ReadLine();
    }
    
    /// <summary>
    /// Checks for missing .txt files. regenerates them in need
    /// </summary>
    public static void CheckSavedFiles()
    {
        string currentPath = Directory.GetCurrentDirectory();
        Print.OutDebug(currentPath);
        
        try
        {
            PingFile("bodies.txt");
            PingFile("sat-battery.txt");
            PingFile("sat-fuel-tank.txt");
            PingFile("sat-engine.txt");
            PingFile("help.txt");
            PingFile("help-time.txt");
            PingFile("help-sat.txt");
            PingFile("help-scan.txt");
            PingFile("points.txt");
        }
        catch (Exception e)
        {
            Print.OutDebug(e.Message);
            if (Menu.YNoption(
                    "Warning -> missing files. Do you want to regenerate Them? Absence of these files will cause a crash!",
                    'y'))
            {
                RegenerateFiles();
            }
        }
    }
    
    public static void RegenerateFiles()
    {
        StreamWriter sw;

        sw = new StreamWriter("bodies.txt");
        sw.WriteLine("Mercury 58 0.055 4880 4.09 2");
        sw.WriteLine("Venus 108 0.815 12104 1.602 1");
        sw.WriteLine("Earth 150 1 12756 0.986 0.5");
        sw.WriteLine("Mars 228 0.107 6779 0.524 1");
        sw.WriteLine("Jupiter 786 317.8 139820 0.038 2");
        sw.WriteLine("Saturn 1434 95.16 116464 0.033 3");
        sw.WriteLine("Uranus 2870 14.54 50720 0.0117 4");
        sw.WriteLine("Neptune 4500 17.15 49528 0.0059 5");
        sw.WriteLine("Pluto 5900 0.0022 2376 0.00403 6");
        sw.Close();

        sw = new StreamWriter("sat-battery.txt");
        sw.WriteLine("aaaBatteryPack battery s 1 1200 100 100 1 100");
        sw.WriteLine("SmallBattery battery s 12 1200 100 100 120 100");
        sw.WriteLine("MediumBattery battery m 56 1800 100 100 480 100");
        sw.WriteLine("LargeBattery battery l 128 2400 100 100 1100 100");
        sw.Close();

        sw = new StreamWriter("sat-fuel-tank.txt");
        sw.WriteLine("LightWeightFuelTank fuelTank s 13 100 36 100");
        sw.WriteLine("SmallFuelTank fuelTank s 28 100 82 100");
        sw.WriteLine("MediumFuelTank fuelTank m 31 100 310 100");
        sw.WriteLine("LargeFuelTank fuelTank l 76 100 760 100");
        sw.WriteLine("InterstellarFuelTank fuelTank l 310 100 8200 100");
        sw.Close();

        sw = new StreamWriter("sat-engine.txt");
        sw.WriteLine("SmallManeuveringEngine engine s 10 100 110 fuel 2");
        sw.WriteLine("IonEngine engine s 10 100 110 electric 20");
        sw.WriteLine("CommercialEngine engine s 160 100 100000 fuel 120");
        sw.WriteLine("9PackIonEngine engine m 90 100 990 electric 180");
        sw.WriteLine("InterplanetaryEngine engine m 2000 100 760000 fuel 320");
        sw.WriteLine("InterstellarEngine engine l 9000 100 1200000 fuel 570");
        sw.Close();

        sw = new StreamWriter("help.txt");
        sw.WriteLine("Help options (type  help [option]  into the terminal): \n" +
                     " | Time (Command) \n" +
                     " | Sat (Command) \n" + 
                     " | Scan (Command) \n" + 
                     // " | faq (frequently asked questions) \n" +
                     // " | Tutorial \n \n" + 
                     "Other commands: \n" +
                     " | Objects -> Lists the objects in the current planetary system and their basic information \n" +
                     " | Clear -> Clears the terminal of all previous text \n \n");
        sw.Close();

        sw = new StreamWriter("help-time.txt");
        sw.WriteLine("Allows to skip time in days by typing \"time [number of days]\". \n" +
                     "Note that skipping time simulates world around you. \n" +
                     "Time gets skipped automatically by \"sat travel height\" and \"sat travel object\" ");
        sw.Close();

        sw = new StreamWriter("help-sat.txt");
        sw.WriteLine("Help for sat [option] command: \n" +
                     " | sat new -> will let you create new satellite. Note that this will also destroy any previous satellite \n" +
                     " | sat status -> will show you satellites status info \n" +
                     " | sat travel -> will let you travel in the current solar system \n \n" +
                     "Help options for sat travel [option] command: \n" +
                     " | sat travel height -> will let you travel to desired height. It will ask you to configure maneuver and than do it. Height option does use timeskip \n" +
                     " | sat travel speed -> will let you change your orbital seed which is tracked in deg/day (degrees a day). Speed option doesnt use timeskip \n" +
                     " | sat travel object -> will let you travel to a desired object in desired time. Note that less time foe manure requires more fuel. Note that this maneuver doesnt change height, only speeds up and moves time\n" +
                     " | sat travel snap -> will let you to change orbital speed and position by tiny amount. Used for close up correction");
        sw.Close();
        
        sw = new StreamWriter("help-scan.txt");
        sw.WriteLine("Allows to scan object if orbital position, speed and height are EXACTLY the ones of an object. use sat travel snap for fine corrections.");
        sw.Close();
        
        sw = new StreamWriter("points.txt");
        sw.WriteLine("0");
        sw.Close();
    }
}