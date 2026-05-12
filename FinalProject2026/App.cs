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
        Print.Debug = true;
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
        Thread enviromentThread = new Thread(() => RunEnviroment());
        
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
            new  NeofetchCommand(t, "neofetch"),
            new ClearCommand(t, "clear")
        };
            
        t.CommandList = cmndList;
        t.Run();
    }

    /// <summary>
    /// Function to call the "environment/world/satellite part" of the app
    /// </summary>
    public void RunEnviroment()
    {
        List<SpaceObject> bodies = new List<SpaceObject>()
        {
        };
        // World solarSystem = new World(bodies);
    }

    /// <summary>
    /// Resets all the safe files, used in development and when migrating platforms
    /// </summary>
    public void ResetSavedFiles() // TODO: Dont forget to run this when moving os
    {
        string currentPath = Directory.GetCurrentDirectory();
        Print.OutDebug(currentPath);
        
        StreamWriter sw = new StreamWriter("bodies.txt");
        
        sw.WriteLine("Mercury 58 0.055");
        sw.WriteLine("Venus 108 0.815");
        sw.WriteLine("Earth 150 1");
        sw.WriteLine("Mars 150 0.107");
        sw.WriteLine("Jupiter 786 317.8");
        sw.WriteLine("Saturn 1434 95.16");
        sw.WriteLine("Uranus 2870 14.54");
        sw.WriteLine("Neptune 4500 17.15");
        sw.WriteLine("Pluto 5900 0.0022");
        
        sw.Close();
    }
}