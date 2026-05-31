using FinalProject2026.Commands;
using FinalProject2026.Sat;

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
        FileRegenerator.CheckSavedFiles();
        
        Satellite satellite = new Satellite();
        
        Terminal t = new Terminal(new List<ICommandable>(), ">");

        try
        {
            RunEnviroment(t, satellite);
        }
        catch (Exception e)
        {
            Print.OutLn(e.Message + " Regenerating files.");
            FileRegenerator.RegenerateFiles();
            RunEnviroment(t, satellite);
        }
        
        RunTerminal(t);
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
            new WhoAmICommand(t, "whoami"),
            new NeofetchCommand(t, "neofetch"),
            new ClearCommand(t, "clear"),
            new HelpCommand(t, "help"),
            new SateliteCommand(t, "sat"),
            new TimeCommand(t, "time"),
            new ObjectsCommand(t, "objects"),
            new ScanCommand(t, "scan"),
            new PointsCommand(t, "points"),
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
        SpaceObject centralBody = new SpaceObject("Sun", 0, 333000, 1390000, 0, 0);

        string? line;
        while ((line = sr.ReadLine()) != null)
        {
            List<string> bodiesParams = Terminal.ParseCommand(line);
            bodies.Add(new SpaceObject(bodiesParams[0], int.Parse(bodiesParams[1]), double.Parse(bodiesParams[2]), int.Parse(bodiesParams[3]), double.Parse(bodiesParams[4]), double.Parse(bodiesParams[5])));
        }

        World solarSystem = new World(bodies, centralBody, sat);
        
        sat.Builder = new SateliteBuilder();
        sat.SolarSystem = solarSystem;
        sat.PosTracker = new PositionTracker(150, 0.986);
        sat.IsConfigured = false;

        t.Satellite = sat;
        t.VirtualWorld = solarSystem;
        t.VirtualWorld.Sat = sat;

        Warp.Sat = sat;
    }
}