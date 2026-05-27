using FinalProject2026.Commands;
using System;
using System.Threading;
using FinalProject2026.Satelite;

namespace FinalProject2026;

/// <summary>
/// Executes the app
/// </summary>
public class App
{
    /// <summary>
    /// Enables debug messages
    /// </summary>
    public bool Debug { get; set; }
    
    public App(bool doDebug)
    {
        Debug = doDebug;
        Print.Debug = Debug;
        
    }
    
    /// <summary>
    /// The start method - strats everything needed for running, does multithreading
    /// </summary>
    public void Run()
    {
        ResetSavedFiles(); // todo: make the file reloading be better

        Satellite satellite = new Satellite();
        
        Terminal t = new Terminal(new List<ICommandable>(), ">");

        Thread terminalThread = new Thread(() => RunTerminal(t)); // wraps the method to make the compiler be quiet
        Thread enviromentThread = new Thread(() => RunEnviroment(t, satellite));
        
        terminalThread.Start();
        enviromentThread.Start();
    }

    /// <summary>
    /// Function to call the "terminal part" of te app
    /// </summary>
    /// <param name="t">Pass the terminal object itself that is created earlier</param>
    public void RunTerminal(Terminal t)
    {
        List<ICommandable> cmndList = new List<ICommandable>()
        {
            new DebugCommand(t, "debug"),
            new WhoAmICommanad(t, "whoami"),
            new NeofetchCommand(t, "neofetch"),
            new ClearCommand(t, "clear"),
            new HelpCommand(t, "help"),
            new SateliteCommand(t, "sat"),
        };
            
        t.CommandList = cmndList;
        t.Run();
    }

    /// <summary>
    /// Function to call the "environment/world/satellite part" of the app
    /// </summary>
    public void RunEnviroment(Terminal t, Satellite sat)
    {
        StreamReader sr = new StreamReader("bodies.txt");

        List<SpaceObject> bodies = new List<SpaceObject>();
        SpaceObject centralBody = new SpaceObject("Sun", 0, 333000, 1390000, 0);

        string line;
        while ((line = sr.ReadLine()) != null)
        {
            List<string> bodiesParams = Terminal.ParseCommand(line);
            bodies.Add(new SpaceObject(bodiesParams[0], int.Parse(bodiesParams[1]), double.Parse(bodiesParams[2]), int.Parse(bodiesParams[3]), double.Parse(bodiesParams[4])));
        }

        World solarSystem = new World(bodies, centralBody);
        
        sat.Builder = new SateliteBuilder();
        sat.SolarSystem = solarSystem;
        sat.PosTracker = new PositionTracker(150, 0);


        t.Satellite = sat;
        t.VirtualWorld = solarSystem;
    }

    /// <summary>
    /// Resets all the safe files, used in development and when migrating platforms
    /// </summary>
    public void ResetSavedFiles() // TODO: Dont forget to run this when moving os nd find a way tht doesnt jsu move the ugly loading think to different class like this
    {
        string currentPath = Directory.GetCurrentDirectory();
        Print.OutDebug(currentPath);
        
        StreamWriter swBodies = new StreamWriter("bodies.txt");
        
        swBodies.WriteLine("Mercury 58 0.055 4880 4.09");
        swBodies.WriteLine("Venus 108 0.815 12104 1.602");
        swBodies.WriteLine("Earth 150 1 12756 0.986");
        swBodies.WriteLine("Mars 228 0.107 6779 0.524");
        swBodies.WriteLine("Jupiter 786 317.8 139820 0.038");
        swBodies.WriteLine("Saturn 1434 95.16 116464 0.033");
        swBodies.WriteLine("Uranus 2870 14.54 50720 0.0117");
        swBodies.WriteLine("Neptune 4500 17.15 49528 0.0059");
        swBodies.WriteLine("Pluto 5900 0.0022 2376 0.00403");
        
        swBodies.Close();
        
        StreamWriter swBattery = new StreamWriter("satBattery.txt");
            
        swBattery.WriteLine("aaaBatteryPack battery s 1 1200 100 100 1 100");
        swBattery.WriteLine("SmallBattery battery s 12 1200 100 100 120 100");
        swBattery.WriteLine("MediumBattery battery m 56 1800 100 100 480 100");
        swBattery.WriteLine("LargeBattery battery l 128 2400 100 100 1100 100");
        
        swBattery.Close();
        
        StreamWriter swFuelTank = new StreamWriter("satFuelTank.txt");
        
        swFuelTank.WriteLine("LightWeightFuelTank fuelTank s 13 100 36 100");
        swFuelTank.WriteLine("SmallFuelTank fuelTank s 28 100 82 100");
        swFuelTank.WriteLine("MediumFuelTank fuelTank m 31 100 310 100");
        swFuelTank.WriteLine("LargeFuelTank fuelTank l 76 100 760 100");
        swFuelTank.WriteLine("InterstellarF`uelTank fuelTank l 310 100 8200 100");
        
        swFuelTank.Close();
        
        StreamWriter swEngine = new StreamWriter("satEngine.txt");
        
        swEngine.WriteLine("SmallManeuveringEngine engine s 10 100 110 fuel 2");
        swEngine.WriteLine("IonEngine engine s 10 100 110 electric 20");
        swEngine.WriteLine("CommercialEngine engine s 160 100 100000 fuel 120");
        swEngine.WriteLine("9PackIonEngine engine m 90 100 990 electric 180");
        swEngine.WriteLine("InterplanetaryEngine engine m 2000 100 760000 fuel 320");
        swEngine.WriteLine("InterstellarEngine engine l 9000 100 1200000 fuel 570");
        
        swEngine.Close();
    }
}