using FinalProject2026.Commands;
using System;
using System.Threading;
using FinalProject2026.Satelite;

namespace FinalProject2026;

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
        ResetSavedFiles();
        
        Time time = new Time();
        Terminal t = new Terminal(new List<ICommandable>(), ">", time);
        
        time.StartPulse(1);

        Thread terminalThread = new Thread(() => RunTerminal(t)); // wraps the method to make the compiler be quiet
        Thread enviromentThread = new Thread(() => RunEnviroment(t));
        
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
    public void RunEnviroment(Terminal t)
    {
        SateliteBuilder sb = new  SateliteBuilder(); // todo: this doesnt belong here move it somewhere it makes sense
        
        StreamReader sr = new StreamReader("bodies.txt");

        List<SpaceObject> bodies = new List<SpaceObject>();
        
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            List<string> bodiesParams = Terminal.ParseCommand(line);
            bodies.Add(new SpaceObject(bodiesParams[0], int.Parse(bodiesParams[1]), double.Parse(bodiesParams[2]), int.Parse(bodiesParams[3])));
        }

        World solarSystem = new World(bodies, new SpaceObject("Sun", 0, 333000, 1390000));

        t.VirtualWorld = solarSystem;
    }

    /// <summary>
    /// Resets all the safe files, used in development and when migrating platforms
    /// </summary>
    public void ResetSavedFiles() // TODO: Dont forget to run this when moving os
    {
        string currentPath = Directory.GetCurrentDirectory();
        Print.OutDebug(currentPath);
        
        StreamWriter swBodies = new StreamWriter("bodies.txt");
        
        swBodies.WriteLine("Mercury 58 0.055 4880 ");
        swBodies.WriteLine("Venus 108 0.815 12104");
        swBodies.WriteLine("Earth 150 1 12756");
        swBodies.WriteLine("Mars 150 0.107 6779");
        swBodies.WriteLine("Jupiter 786 317.8 139820");
        swBodies.WriteLine("Saturn 1434 95.16 116464");
        swBodies.WriteLine("Uranus 2870 14.54 50720");
        swBodies.WriteLine("Neptune 4500 17.15 49528");
        swBodies.WriteLine("Pluto 5900 0.0022 2376");
        
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
    }
}